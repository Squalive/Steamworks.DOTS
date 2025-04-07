using Steamworks;
using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks.Sample
{
    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.ServerSimulation ) ]
    [ UpdateInGroup( typeof( SimulationSystemGroup ) ) ]
    [ CreateAfter( typeof( SteamCallbacksSystem ) ) ]
    [ RequireMatchingQueriesForUpdate ]
    public partial struct SteamServerConnectedSystem : ISystem
    {
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var dispatch = SystemAPI.GetSingleton<Dispatch>();
            dispatch.Install<SteamServersConnected_t>();
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var steamGameServer = SystemAPI.GetSingleton<SteamGameServer>();
            var query = SystemAPI.QueryBuilder().WithAll<SteamCallback, SteamCallback<SteamServersConnected_t>>().Build();
            foreach ( var _ in query.ToComponentDataArray<SteamCallback>( Allocator.Temp ) )
            {
                steamGameServer.SetMaxPlayerCount( 100 );
                steamGameServer.SetPasswordProtected( false );
                steamGameServer.SetServerName( ( FixedString32Bytes ) "Yippe Server" );
                steamGameServer.SetBotPlayerCount( 0 );
                steamGameServer.SetMapName( ( FixedString32Bytes ) "IDK" );
                
                UnityEngine.Debug.Log( "steam server connected" );
            }

            state.EntityManager.DestroyEntity( query );
        }
    }
}