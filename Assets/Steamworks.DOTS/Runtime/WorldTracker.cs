using System.Collections.Generic;
using Unity.Entities;

namespace Steamworks
{
    public static class WorldTracker
    {
        public static List<World> ServerWorlds = new();
        public static List<World> ClientWorlds = new();
    }
}