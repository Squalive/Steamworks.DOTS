
using Unity.Entities;

namespace Steamworks.Sample
{
    public class ServerBootstrap : ICustomBootstrap
    {
        public bool Initialize( string defaultWorldName )
        {
            var world = new World( "SteamGameServer", WorldFlags.GameServer );
            var systems = DefaultWorldInitialization.GetAllSystems( WorldSystemFilterFlags.ServerSimulation, false );
            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups( world, systems );
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop( world );
            if ( World.DefaultGameObjectInjectionWorld == null )
                World.DefaultGameObjectInjectionWorld = world;
            return true;
        }
    }
}