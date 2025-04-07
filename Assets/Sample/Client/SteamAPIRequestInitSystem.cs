using Unity.Entities;

namespace Steamworks.Sample
{
    public struct ClientLogged : IComponentData {}
    
    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    [ UpdateBefore( typeof( SteamClientSystem ) ) ]
    public partial struct SteamClientRequestInitSystem : ISystem
    {
        public void OnUpdate( ref SystemState state )
        {
            if ( SystemAPI.HasSingleton<ClientLogged>() ) return;
            
            if ( SystemAPI.TryGetSingletonEntity<SteamAPIInitResult>( out var steamEntity ) )
            {
                // state.EntityManager.RemoveComponent<SteamAPIInitResult>( steamEntity );
                var result = state.EntityManager.GetComponentData<SteamAPIInitResult>( steamEntity );
                if ( result.Result == SteamInitResult.Ok )
                {
                    var steamFriends = SystemAPI.GetComponent<SteamFriends>( steamEntity );
                    var localId = SystemAPI.GetSingleton<SteamLocal>().Id;
                    var callResult = steamFriends.IsFollowing( localId );
                    var targetEntity = state.EntityManager.CreateEntity();
                    callResult.Set( SystemAPI.GetSingleton<SteamCallResultSingleton>(), targetEntity );
                }
                else
                {
                    UnityEngine.Debug.LogError( result.ErrorMsg );
                }
                state.EntityManager.AddComponent<ClientLogged>( steamEntity );
            }
            else if ( !SystemAPI.HasSingleton<SteamInternal>() )
            {
                var initEntity = state.EntityManager.CreateEntity();
                state.EntityManager.AddComponentData( initEntity, new SteamAPIRequestInit( 480 ) );
            }
        }
    }
}