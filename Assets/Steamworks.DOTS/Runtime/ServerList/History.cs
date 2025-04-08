using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks.ServerList
{
    public struct History : IComponentData
    {
            
    }
    
    [ BurstCompile ]
    [ UpdateInGroup( typeof( ServerListSystemGroup ) ) ]
    internal partial struct RequestHistoryServerSystem : ISystem
    {
        private EntityQuery _launchRequestQuery;

        private ComponentLookup<SteamMatchmakingServers> _steamMatchmakingServersLookup;
    
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithPresent<Request, MatchMakingKeyValuePair, ResponsiveServerInfo, History, Refreshed>()
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
            
            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, in Request request, in History history, EnabledRefRW<Refreshed> refreshed, in DynamicBuffer<MatchMakingKeyValuePair> pairs )
            {
                refreshed.ValueRW = false;
                var steamMatchmakingServers = SteamMatchmakingServersLookup[ SteamEntity ];
                using var serverFilters = new ServerFilterMarshaler( pairs, Allocator.Temp );
                var hServerListRequest = steamMatchmakingServers.Internal.RequestHistoryServerList( request.AppId, serverFilters.Pointer, ( uint ) serverFilters.Count, IntPtr.Zero );
                CommandBuffer.AddComponent( chunkIndex, entity, new ResolvedRequest { Value = hServerListRequest, LastCount = 0 } );
            }
        }
    }
}