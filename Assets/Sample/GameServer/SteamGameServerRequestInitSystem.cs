using Unity.Entities;

namespace Steamworks.Sample
{
    public struct SteamGameServerTriedLoggedOn : IComponentData
    {
        
    }
    
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    [ UpdateBefore( typeof( SteamServerSystem ) ) ]
    public partial struct SteamGameServerRequestInitSystem : ISystem
    {
        public void OnUpdate( ref SystemState state )
        {
            if ( !SystemAPI.TryGetSingletonEntity<SteamGameServer>( out var gameServerEntity ) )
            {
                var initEntity = state.EntityManager.CreateEntity();
                state.EntityManager.AddComponentData( initEntity, new SteamGameServerRequestInit( 480, "SpaceWar", "Yippe" ) );
            }
            else
            {
                state.EntityManager.RemoveComponent<SteamGameServerInitResult>( gameServerEntity );
                var steamGameServer = SystemAPI.GetComponent<SteamGameServer>( gameServerEntity );
                steamGameServer.LogOnAnonymous();
                state.EntityManager.AddComponent<SteamGameServerTriedLoggedOn>( gameServerEntity );
                steamGameServer.SetAdvertiseServerActive( true );
            }
        }
    }
}