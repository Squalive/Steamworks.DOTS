using Unity.Entities;

namespace Steamworks
{
    public struct SteamLocal : IComponentData
    {
        public SteamId Id;
    }
}