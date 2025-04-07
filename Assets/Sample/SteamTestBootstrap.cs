
using Unity.Entities;

namespace Steamworks.Sample
{
    public class SteamTestBootstrap : ICustomBootstrap
    {
        public bool Initialize( string defaultWorldName )
        {
            CreateClientWorld();
            CreateServerWorld();
            return true;
        }

        private void CreateServerWorld()
        {
            var serverWorld = new World( "SteamGameServer", WorldFlags.GameServer );
            var serverSystems = DefaultWorldInitialization.GetAllSystems( WorldSystemFilterFlags.ServerSimulation, false );
            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups( serverWorld, serverSystems );
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop( serverWorld );
            if ( World.DefaultGameObjectInjectionWorld == null )
                World.DefaultGameObjectInjectionWorld = serverWorld;
        }

        private void CreateClientWorld()
        {
            var clientWorld = new World( "SteamClient", WorldFlags.GameClient );
            var clientSystems = DefaultWorldInitialization.GetAllSystems( WorldSystemFilterFlags.ClientSimulation, false );
            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups( clientWorld, clientSystems );
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop( clientWorld );
            if ( World.DefaultGameObjectInjectionWorld == null )
                World.DefaultGameObjectInjectionWorld = clientWorld;
        }
    }
}