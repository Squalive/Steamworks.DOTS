using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks.ServerList
{
    public struct Request : IComponentData
    {
        public AppId_t AppId;

        public Request( AppId_t appId )
        {
            AppId = appId;
        }
    }

    public struct ResolvedRequest : ICleanupComponentData
    {
        [ NativeDisableUnsafePtrRestriction ] public HServerListRequest Value;
        public int LastCount;
    }

    [ InternalBufferCapacity( 128 ) ]
    internal struct PendingServer : IBufferElementData
    {
        public int ServerIndex;
    }

    public struct ResponsiveServerInfo : IBufferElementData
    {
        public ServerInfo Info;
        internal unsafe ResponsiveServerInfo( gameserveritem_t* rawValue )
        {
            Info = new ServerInfo( rawValue );
        }
    }

    public struct UnresponsiveServerInfo : IBufferElementData
    {
        public ServerInfo Info;
        internal unsafe UnresponsiveServerInfo( gameserveritem_t* rawValue )
        {
            Info = new ServerInfo( rawValue );
        }
    }

    internal struct Timeout : IComponentData
    {
        public float InitialRemaining;
        public float RemainingSeconds;
    }

    public struct RefreshRequest : IComponentData
    {
        
    }
    
    public struct Refreshed : IComponentData, IEnableableComponent
    {
        
    }
    
    public struct MatchMakingKeyValuePair : IBufferElementData
    {
        public FixedString128Bytes Key;
        public FixedString128Bytes Value;

        public MatchMakingKeyValuePair( in FixedString128Bytes key, in FixedString128Bytes value )
        {
            Key = key;
            Value = value;
        }
    }

    public struct CancelRequest : IComponentData { }
    
    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation,
        WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( SimulationSystemGroup ) ) ]
    public partial class ServerListSystemGroup : ComponentSystemGroup
    {
        
    }
    
    [ BurstCompile ]
    [ UpdateInGroup( typeof( ServerListSystemGroup ) ) ]
    [ RequireMatchingQueriesForUpdate ]
    public partial struct UpdateSystem : ISystem
    {
        private const float DefaultTimeout = 120;
        
        private ComponentLookup<SteamMatchmakingServers> _steamMatchmakingServersLookup;

        private EntityQuery _fillRequestQuery;
        private EntityQuery _needToReleaseQuery;
        private EntityQuery _cancelQuery;
        private EntityQuery _refreshingQuery;
        private EntityQuery _unfinallizedQuery;
        private EntityQuery _requestRefreshQuery;

        private ComponentTypeSet _requestTypeSet;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithPresent<Request>()
                .WithAbsent<ResolvedRequest, MatchMakingKeyValuePair, PendingServer, ResponsiveServerInfo, Refreshed, UnresponsiveServerInfo>();
            _fillRequestQuery = state.GetEntityQuery( builder );
            
            builder.Reset()
                .WithAll<ResolvedRequest>()
                .WithNone<Request, MatchMakingKeyValuePair>();
            _needToReleaseQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithPresent<ResolvedRequest, CancelRequest>();
            _cancelQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithPresent<Request, ResolvedRequest, Timeout, ResponsiveServerInfo, UnresponsiveServerInfo, PendingServer>()
                .WithDisabled<Refreshed>();
            _refreshingQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithPresent<ResolvedRequest>()
                .WithAbsent<Timeout>();
            _unfinallizedQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithPresent<Request, ResolvedRequest, Timeout, Refreshed, ResponsiveServerInfo, UnresponsiveServerInfo, PendingServer>()
                .WithAll<RefreshRequest>()
                .WithAbsent<CancelRequest>();
            _requestRefreshQuery = state.GetEntityQuery( builder );

            _requestTypeSet = new ComponentTypeSet(
                ComponentType.ReadWrite<MatchMakingKeyValuePair>(),
                ComponentType.ReadWrite<ResponsiveServerInfo>(),
                ComponentType.ReadWrite<Refreshed>(),
                ComponentType.ReadWrite<PendingServer>(),
                ComponentType.ReadWrite<UnresponsiveServerInfo>() );
            
            _steamMatchmakingServersLookup = state.GetComponentLookup<SteamMatchmakingServers>( true );
            state.RequireForUpdate<SteamMatchmakingServers>();
        }

        [ BurstCompile ]
        public void OnDestroy( ref SystemState state )
        {
            if ( SystemAPI.TryGetSingleton( out SteamMatchmakingServers steamMatchmakingServers ) )
            {
                foreach ( var resolvedRequest in SystemAPI.Query<RefRO<ResolvedRequest>>() )
                {
                    steamMatchmakingServers.Internal.ReleaseRequest( resolvedRequest.ValueRO.Value );
                }
            }
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var steamEntity = SystemAPI.GetSingletonEntity<SteamMatchmakingServers>();
            _steamMatchmakingServersLookup.Update( ref state );
            var commandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer( state.WorldUnmanaged );
            var parallelCommandBuffer = commandBuffer.AsParallelWriter();
            if ( !_fillRequestQuery.IsEmptyIgnoreFilter )
            {
                commandBuffer.AddComponent( _fillRequestQuery, _requestTypeSet, EntityQueryCaptureMode.AtPlayback );
            }

            if ( !_unfinallizedQuery.IsEmptyIgnoreFilter )
            {
                commandBuffer.AddComponent( _unfinallizedQuery, new Timeout { RemainingSeconds = DefaultTimeout } );
            }
            
            if ( !_cancelQuery.IsEmptyIgnoreFilter )
            {
                state.Dependency = new CancelJob
                {
                    SteamEntity = steamEntity,
                    SteamMatchmakingServersLookup = _steamMatchmakingServersLookup,
                    CommandBuffer = parallelCommandBuffer
                }.ScheduleParallel( _cancelQuery, state.Dependency );   
            }
            
            if ( !_needToReleaseQuery.IsEmptyIgnoreFilter )
            {
                state.Dependency = new ReleaseJob
                {
                    SteamEntity = steamEntity,
                    SteamMatchmakingServersLookup = _steamMatchmakingServersLookup
                }.ScheduleParallel( _needToReleaseQuery, state.Dependency );
            }

            if ( !_refreshingQuery.IsEmptyIgnoreFilter )
            {
                state.Dependency = new RefreshJob
                {
                    SteamEntity = steamEntity,
                    SteamMatchmakingServersLookup = _steamMatchmakingServersLookup,
                    DeltaTime = SystemAPI.Time.DeltaTime,
                }.ScheduleParallel( _refreshingQuery, state.Dependency );
            }

            if ( !_requestRefreshQuery.IsEmptyIgnoreFilter )
            {
                state.Dependency = new RequestRefreshJob
                {
                    SteamEntity = steamEntity,
                    SteamMatchmakingServersLookup = _steamMatchmakingServersLookup,
                    CommandBuffer = parallelCommandBuffer,
                }.ScheduleParallel( _requestRefreshQuery, state.Dependency );
            }
        }
        
        [ BurstCompile ]
        private partial struct RequestRefreshJob : IJobEntity
        {
            public Entity SteamEntity;
            [ ReadOnly ] public ComponentLookup<SteamMatchmakingServers> SteamMatchmakingServersLookup;
            public EntityCommandBuffer.ParallelWriter CommandBuffer;

            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, 
                ref ResolvedRequest resolvedRequest,
                ref Timeout timeout,
                ref DynamicBuffer<ResponsiveServerInfo> responsiveServerInfos,
                ref DynamicBuffer<UnresponsiveServerInfo> unresponsiveServerInfos,
                ref DynamicBuffer<PendingServer> pendingServers,
                EnabledRefRW<Refreshed> refreshed )
            {
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                steamMatchmakingServers.Internal.ReleaseRequest( resolvedRequest.Value );
                
                responsiveServerInfos.Clear();
                pendingServers.Clear();
                resolvedRequest.Value = default;
                resolvedRequest.LastCount = 0;
                refreshed.ValueRW = false;
                timeout.RemainingSeconds = timeout.InitialRemaining != 0f ? timeout.InitialRemaining : DefaultTimeout;
                
                CommandBuffer.RemoveComponent<ResolvedRequest>( chunkIndex, entity );
                CommandBuffer.RemoveComponent<RefreshRequest>( chunkIndex, entity );
            }
        }
        
        [ BurstCompile ]
        private partial struct CancelJob : IJobEntity
        {
            public Entity SteamEntity;
            [ ReadOnly ] public ComponentLookup<SteamMatchmakingServers> SteamMatchmakingServersLookup;
            public EntityCommandBuffer.ParallelWriter CommandBuffer;

            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, ref ResolvedRequest resolvedRequest )
            {
                CommandBuffer.RemoveComponent<CancelRequest>( chunkIndex, entity );
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                steamMatchmakingServers.Internal.CancelQuery( resolvedRequest.Value );
            }
        }
        
        [ BurstCompile ]
        private partial struct ReleaseJob : IJobEntity
        {
            public Entity SteamEntity;
            [ ReadOnly ] public ComponentLookup<SteamMatchmakingServers> SteamMatchmakingServersLookup;
            
            private void Execute( ref ResolvedRequest resolvedRequest )
            {
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                steamMatchmakingServers.Internal.ReleaseRequest( resolvedRequest.Value );
            }
        }

        [ BurstCompile ]
        private partial struct RefreshJob : IJobEntity
        {
            public Entity SteamEntity;
            [ ReadOnly ] public ComponentLookup<SteamMatchmakingServers> SteamMatchmakingServersLookup;
            public float DeltaTime;
            
            private void Execute( in Entity entity, 
                Request request,
                ref ResolvedRequest resolvedRequest, 
                ref Timeout timeout,
                EnabledRefRW<Refreshed> refreshed, 
                DynamicBuffer<PendingServer> pendingServers,
                DynamicBuffer<ResponsiveServerInfo> resolvedServerInfos,
                DynamicBuffer<UnresponsiveServerInfo> unresponsiveServerInfos )
            {
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                timeout.RemainingSeconds -= DeltaTime;
                if ( !steamMatchmakingServers.Internal.IsRefreshing( resolvedRequest.Value ) || timeout.RemainingSeconds <= 0 )
                {
                    for ( var i = 0; i < pendingServers.Length; ++i )
                    {
                        unsafe
                        {
                            var item = ( gameserveritem_t* ) steamMatchmakingServers.Internal._GetServerDetails( resolvedRequest.Value, pendingServers[ i ].ServerIndex );
                            unresponsiveServerInfos.Add( new UnresponsiveServerInfo( item ) );
                        }
                    }
                    pendingServers.Clear();
                    refreshed.ValueRW = true;
                    return;
                }
                
                UpdatePending( steamMatchmakingServers, ref resolvedRequest, pendingServers );
                UpdateResponsiveness( steamMatchmakingServers, request, ref resolvedRequest, pendingServers, resolvedServerInfos );
            }

            private void UpdatePending( 
                SteamMatchmakingServers steamMatchmakingServers,
                ref ResolvedRequest resolvedRequest,
                DynamicBuffer<PendingServer> pendingServers )
            {
                var respondedCount = steamMatchmakingServers.Internal.GetServerCount( resolvedRequest.Value );
                if ( respondedCount <= resolvedRequest.LastCount ) return;
                for ( var i = resolvedRequest.LastCount; i < respondedCount; ++i )
                {
                    pendingServers.Add( new PendingServer { ServerIndex = i } );
                }
                resolvedRequest.LastCount = respondedCount;
            }

            private unsafe void UpdateResponsiveness( 
                SteamMatchmakingServers steamMatchmakingServers,
                Request request,
                ref ResolvedRequest resolvedRequest,
                DynamicBuffer<PendingServer> pendingServers,
                DynamicBuffer<ResponsiveServerInfo> resolvedServerInfos )
            {
                for ( var i = 0; i < pendingServers.Length; ++i )
                {
                    var pending = pendingServers[ i ].ServerIndex; 

                    if ( steamMatchmakingServers.HasServerResponded( resolvedRequest.Value, pending ) )
                    {
                        var info = ( gameserveritem_t* ) steamMatchmakingServers.Internal._GetServerDetails( resolvedRequest.Value, pending );
                        // if ( info->AppID == request.AppId )
                        // {
                        // }
                        resolvedServerInfos.Add( new ResponsiveServerInfo( info ) );
                        pendingServers.RemoveAt( i );
                        --i;
                    }
                }
            }
        }
    }
}

