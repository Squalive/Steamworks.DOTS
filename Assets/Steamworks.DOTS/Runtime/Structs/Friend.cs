using System;
using System.Collections.Generic;
using Steamworks.Data;
using Unity.Collections;

namespace Steamworks
{
    public struct Friend : IEquatable<Friend>
    {
        public SteamId Id;

        public Friend( SteamId id )
        {
            Id = id;
        }

        public bool Equals( Friend other )
        {
            return Id.Equals( other.Id );
        }

        public override bool Equals( object obj )
        {
            return obj is Friend other && Equals( other );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public TStr Name<TStr>( SteamFriends steamFriends, bool nicked = false ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            if ( nicked )
            {
                var nickedNamePtr = steamFriends.Internal._GetPlayerNickname( Id );
                if ( nickedNamePtr.Ptr != IntPtr.Zero ) return nickedNamePtr.ToUnsafeString<TStr>();
            }

            return steamFriends.Internal._GetFriendPersonaName( Id ).ToUnsafeString<TStr>();
        }

        public string Name( SteamFriends steamFriends, bool nicked = false )
        {
            if ( nicked )
            {
                var nickedNamePtr = steamFriends.Internal._GetPlayerNickname( Id );
                if ( nickedNamePtr.Ptr != IntPtr.Zero ) return nickedNamePtr;
            }

            return steamFriends.Internal.GetFriendPersonaName( Id );
        }

        public IEnumerable<KeyValuePair<string, string>> GetRichPresence( SteamFriends steamFriends )
        {
            var count = steamFriends.Internal.GetFriendRichPresenceKeyCount( Id );
            for ( var i = 0; i < count; ++i )
            {
                var key = steamFriends.Internal.GetFriendRichPresenceKeyByIndex( Id, i );
                var value = steamFriends.Internal.GetFriendRichPresence( Id, key );
                yield return new KeyValuePair<string, string>( key, value );
            }
        }

        public EPersonaState GetPersonaState( SteamFriends steamFriends )
        {
            return steamFriends.Internal.GetFriendPersonaState( Id );
        }

        public EFriendRelationship GetRelationship( SteamFriends steamFriends )
        {
            return steamFriends.Internal.GetFriendRelationship( Id );
        }

        /// <summary>
        /// Checks if the specified friend is in a game, and gets info about the game if they are.
        /// </summary>
        /// <returns>true if the user is a friend and is in a game; otherwise, false.</returns>
        public bool GetGamePlayed( SteamFriends steamFriends, out FriendGameInfo_t info )
        {
            info = default;
            return steamFriends.Internal.GetFriendGamePlayed( Id, ref info );
        }

        public bool IsFriend( SteamFriends steamFriends, EFriendFlags flags )
        {
            return steamFriends.Internal.HasFriend( Id, ( int ) flags );
        }
    }
}