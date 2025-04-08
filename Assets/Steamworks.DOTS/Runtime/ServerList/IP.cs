using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Steamworks.ServerList
{
    public struct IP : IBufferElementData
    {
        public FixedString64Bytes Value;

        public IP( FixedString64Bytes val )
        {
            Value = val;
        }
    }
    
    [ BurstCompile ]
    [ UpdateInGroup( typeof( ServerListSystemGroup ) ) ]
    internal partial struct RequestIPServerSystem : ISystem
    {
        private EntityQuery _launchRequestQuery;

        private ComponentLookup<SteamMatchmakingServers> _steamMatchmakingServersLookup;
    
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithPresent<Request, MatchMakingKeyValuePair, ResponsiveServerInfo, IP, Refreshed>()
                .WithNone<ResolvedRequest>();
            _launchRequestQuery = state.GetEntityQuery( builder );

            _steamMatchmakingServersLookup = state.GetComponentLookup<SteamMatchmakingServers>( true );
            
            state.RequireForUpdate( _launchRequestQuery );
            state.RequireForUpdate<SteamMatchmakingServers>();
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var steamEntity = SystemAPI.GetSingletonEntity<SteamMatchmakingServers>();
            _steamMatchmakingServersLookup.Update( ref state );
            state.Dependency = new LaunchQueryJob
            {
                SteamEntity = steamEntity,
                SteamMatchmakingServersLookup = _steamMatchmakingServersLookup,
                CommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer( state.WorldUnmanaged ).AsParallelWriter()
            }.ScheduleParallel( _launchRequestQuery, state.Dependency );
        }
        
        [ BurstCompile ]
        private partial struct LaunchQueryJob : IJobEntity
        {
            public Entity SteamEntity;
            [ ReadOnly ] public ComponentLookup<SteamMatchmakingServers> SteamMatchmakingServersLookup;
            public EntityCommandBuffer.ParallelWriter CommandBuffer;
            
            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, in Request request, in DynamicBuffer<IP> ips, EnabledRefRW<Refreshed> refreshed )
            {
                refreshed.ValueRW = false;
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                var filters = new NativeList<MatchMakingKeyValuePair>( 2, Allocator.Temp );

                var len = math.min( ips.Length, 16 );
                filters.Add( new MatchMakingKeyValuePair( "or", $"{len}" ) );
                for ( var i = 0; i < len; ++i )
                {
                    filters.Add( new MatchMakingKeyValuePair( "gameaddr", ips[ i ].Value ) );
                }
                
                using var marshaledFilters = new ServerFilterMarshaler( filters.AsArray(), Allocator.Temp );
                var hServerListRequest = steamMatchmakingServers.Internal.RequestInternetServerList( request.AppId, marshaledFilters.Pointer, ( uint ) marshaledFilters.Count, IntPtr.Zero );
                CommandBuffer.AddComponent( chunkIndex, entity, new ResolvedRequest { Value = hServerListRequest, LastCount = 0 } );
            }
        }
    }
}