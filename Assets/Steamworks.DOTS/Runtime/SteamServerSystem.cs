using Unity.Burst;
using Unity.Entities;

namespace Steamworks
{
    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.ServerSimulation ) ]
    [ UpdateInGroup( typeof( SimulationSystemGroup ) ) ]
    public partial struct SteamServerSystem : ISystem
    {
        public void OnCreate( ref SystemState state )
        {
            var steamSingleton = state.EntityManager.CreateEntity(
                ComponentType.ReadWrite<SteamGameServer>()
            );
            state.EntityManager.SetName( steamSingleton, "Steam" );

            SystemAPI.SetSingleton( new SteamGameServer( CSteamGameServerAPIContext.SteamGameServer ) );
            
            WorldTracker.ServerWorlds.Add( state.World );
        }

        public void OnDestroy( ref SystemState state )
        {
            WorldTracker.ServerWorlds.Remove( state.World );
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            
        }
    }
}