using Unity.Entities;

namespace Steamworks.Sample
{
    public struct GameServerLogged : IComponentData {}
    
    [ WorldSystemFilter( WorldSystemFilterFlags.ServerSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    [ UpdateBefore( typeof( SteamServerSystem ) ) ]
    public partial struct SteamGameServerRequestInitSystem : ISystem
    {
        public void OnUpdate( ref SystemState state )
        {
            if ( SystemAPI.HasSingleton<GameServerLogged>() ) return;
            
            if ( SystemAPI.TryGetSingletonEntity<SteamGameServerInitResult>( out var steamEntity ) )
            {
                // state.EntityManager.RemoveComponent<SteamAPIInitResult>( steamEntity );
                var result = state.EntityManager.GetComponentData<SteamGameServerInitResult>( steamEntity );
                if ( result.Result == SteamInitResult.Ok )
                {
                    var steamGameServer = SystemAPI.GetComponent<SteamGameServer>( steamEntity );
                    steamGameServer.LogOnAnonymous();
                    steamGameServer.SetAdvertiseServerActive( true );
                }
                else
                {
                    UnityEngine.Debug.LogError(result.ErrorMsg);
                }
                state.EntityManager.AddComponent<GameServerLogged>( steamEntity );
                
            }
            else if ( !SystemAPI.HasSingleton<SteamInternal>() )
            {
                var initEntity = state.EntityManager.CreateEntity();
                state.EntityManager.AddComponentData( initEntity, new SteamGameServerRequestInit( 480, "SpaceWar", "Yippe" ) );
            }
        }
    }
}