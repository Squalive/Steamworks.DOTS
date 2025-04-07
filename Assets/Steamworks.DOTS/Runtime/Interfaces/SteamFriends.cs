using System;
using Steamworks.Data;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamFriends : IComponentData
    {
        internal ISteamFriends Internal;

        internal SteamFriends( IntPtr iface )
        {
            Internal = new ISteamFriends( iface );
        }

        public int GetFriendCount( EFriendFlags flags )
        {
            return Internal.GetFriendCount( ( int ) flags );
        }

        public CallResult<FriendsIsFollowing_t> IsFollowing( SteamId steamId )
        {
            return Internal.IsFollowing( steamId );
        }
    }
}