using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks
{
    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.ServerSimulation ) ]
    [ UpdateInGroup( typeof( SimulationSystemGroup ), OrderLast = true ) ]
    [ CreateAfter( typeof( SteamCallbacksSystem ) ) ]
    public partial struct SteamServerLocalSystem : ISystem
    {
        private CallbackQuery<SteamServersConnected_t> _steamServerConnectedQuery;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var dispatch = SystemAPI.GetSingleton<Dispatch>();
            dispatch.Install<SteamServersConnected_t>();

            _steamServerConnectedQuery = new CallbackQuery<SteamServersConnected_t>( ref state );
            state.RequireForUpdate( _steamServerConnectedQuery );
        }
        
        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            if ( SystemAPI.HasSingleton<SteamLocal>() ) return;
            
            var steamEntity = SystemAPI.GetSingletonEntity<SteamGameServer>();
            var steamGameServer = SystemAPI.GetComponent<SteamGameServer>( steamEntity );
            foreach ( var _ in _steamServerConnectedQuery.ToCallbackArray( Allocator.Temp ) )
            {
                state.EntityManager.AddComponentData( steamEntity, new SteamLocal { Id = steamGameServer.SteamId } );
                break;
            }

            UnityEngine.Debug.Log(steamGameServer.SteamId.Value  );
            state.EntityManager.DestroyEntity( _steamServerConnectedQuery );
        }
    }
}