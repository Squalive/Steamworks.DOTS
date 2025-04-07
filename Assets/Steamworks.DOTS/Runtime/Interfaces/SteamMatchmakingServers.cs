using System;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamMatchmakingServers : IComponentData
    {
        internal ISteamMatchmakingServers Internal;
        internal SteamMatchmakingServers( IntPtr iface )
        {
            Internal = new ISteamMatchmakingServers( iface );
        }
    }
}