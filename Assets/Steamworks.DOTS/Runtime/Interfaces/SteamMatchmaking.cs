using System;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamMatchmaking : IComponentData
    {
        internal ISteamMatchmaking Internal;
        internal SteamMatchmaking( IntPtr iface )
        {
            Internal = new ISteamMatchmaking( iface );
        }
        
        
    }
}