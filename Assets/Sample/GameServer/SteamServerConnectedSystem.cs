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
        private Steamworks.CallbackQuery<SteamServersConnected_t> _steamServerConnectedQuery;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var dispatch = SystemAPI.GetSingleton<Dispatch>();
            dispatch.Install<SteamServersConnected_t>();
            state.RequireForUpdate<SteamGameServer>();

            _steamServerConnectedQuery = new CallbackQuery<SteamServersConnected_t>( ref state );
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var steamGameServer = SystemAPI.GetSingleton<SteamGameServer>();
            
            foreach ( var _ in _steamServerConnectedQuery.ToCallbackArray( Allocator.Temp ) )
            {
                steamGameServer.SetMaxPlayerCount( 100 );
                steamGameServer.SetPasswordProtected( false );
                steamGameServer.SetBotPlayerCount( 0 );
                FixedString32Bytes serverName = "Yippe Server";
                steamGameServer.SetServerName( serverName );
                FixedString32Bytes mapName = "MapName";
                steamGameServer.SetMapName( mapName );

                FixedString32Bytes key = "gamemod";
                FixedString32Bytes value = "vanilla";
                steamGameServer.SetKeyValue( key, value );
                
                UnityEngine.Debug.Log( "steam server connected" );
            }

            state.EntityManager.DestroyEntity( _steamServerConnectedQuery );
        }
    }
}