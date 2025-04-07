using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks.ServerList
{
    public struct Request : IComponentData
    {
        public struct Favorites : IComponentData
        {
            
        }
        
        public AppId_t AppId;
    }

    public struct ResolvedRequest : ICleanupComponentData
    {
        [ NativeDisableUnsafePtrRestriction ] public HServerListRequest Value;
        public int LastCount;
    }

    public struct ResolvedServerInfo : IBufferElementData
    {
        internal gameserveritem_t RawValue;
        internal ResolvedServerInfo( gameserveritem_t rawValue )
        {
            RawValue = rawValue;
        }
    }

    public struct Refreshed : IComponentData
    {
        
    }
    
    public struct MatchMakingKeyValuePair : IComponentData
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
    
    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( SimulationSystemGroup ) ) ]
    [ RequireMatchingQueriesForUpdate ]
    public partial struct UpdateSystem : ISystem
    {
        private ComponentLookup<SteamMatchmakingServers> _steamMatchmakingServersLookup;
        
        private EntityQuery _needToReleaseQuery;
        private EntityQuery _cancelQuery;
        private EntityQuery _refreshingQuery;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithAll<ResolvedRequest>()
                .WithNone<Request, MatchMakingKeyValuePair, CancelRequest>();
            _needToReleaseQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithAll<ResolvedRequest, CancelRequest>();
            _cancelQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithAll<ResolvedRequest>()
                .WithNone<Refreshed>();
            _refreshingQuery = state.GetEntityQuery( builder );

            _steamMatchmakingServersLookup = state.GetComponentLookup<SteamMatchmakingServers>( true );
            
            state.RequireForUpdate<SteamMatchmakingServers>();
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var steamEntity = SystemAPI.GetSingletonEntity<SteamMatchmakingServers>();
            _steamMatchmakingServersLookup.Update( ref state );
            var commandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer( state.WorldUnmanaged );
            var parallelCommandBuffer = commandBuffer.AsParallelWriter();
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
                    CommandBuffer = parallelCommandBuffer
                }.ScheduleParallel( _refreshingQuery, state.Dependency );
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
            public EntityCommandBuffer.ParallelWriter CommandBuffer;
            
            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, ref ResolvedRequest resolvedRequest, DynamicBuffer<ResolvedServerInfo> resolvedServerInfos )
            {
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                if ( !steamMatchmakingServers.Internal.IsRefreshing( resolvedRequest.Value ) )
                    CommandBuffer.AddComponent<Refreshed>( chunkIndex, entity );

                UpdatePending( steamMatchmakingServers, ref resolvedRequest, resolvedServerInfos );
            }

            private void UpdatePending( SteamMatchmakingServers steamMatchmakingServers, ref ResolvedRequest resolvedRequest, DynamicBuffer<ResolvedServerInfo> resolvedServerInfos )
            {
                var respondedCount = steamMatchmakingServers.Internal.GetServerCount( resolvedRequest.Value );
                if ( respondedCount == resolvedRequest.LastCount ) return;
                for ( var i = resolvedRequest.LastCount; i < respondedCount; ++i )
                {
                    var serverInfo = steamMatchmakingServers.Internal.GetServerDetails( resolvedRequest.Value, i );
                    if ( serverInfo.HadSuccessfulResponse )
                    {
                        resolvedServerInfos.Add( new ResolvedServerInfo( serverInfo ) );
                    }
                }

                resolvedRequest.LastCount = respondedCount;
            }
        }
    }
}

