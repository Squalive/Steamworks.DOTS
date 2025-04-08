using System;
using Steamworks.Data;
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

        internal unsafe bool HasServerResponded( HServerListRequest hServerListRequest, int iServer )
        {
            var returnValue = Internal._GetServerDetails( hServerListRequest, iServer );
            if ( returnValue == IntPtr.Zero ) return false;

            var item = ( gameserveritem_t* ) returnValue;
            return item->HadSuccessfulResponse;
        }
    }
}