using System;
using System.Collections.Generic;
using Steamworks.Data;
using Unity.Collections;
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

        public void ActivateGameOverlay<TStr>( in TStr str ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var str__pchDialog = Utf8StringToNative.CreateFromUnsafeString( str );
            Internal._ActivateGameOverlay( str__pchDialog );
        }

        public void ActivateGameOverlayInviteDialog( SteamId steamIDLobby )
        {
            Internal.ActivateGameOverlayInviteDialog( steamIDLobby );
        }

        public void ActivateGameOverlayToStore( AppId_t nAppID, EOverlayToStoreFlag eFlag )
        {
            Internal.ActivateGameOverlayToStore( nAppID, eFlag );
        }
        
        public void ActivateGameOverlayToUser<TStr>( in TStr str, SteamId steamID ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var str__pchDialog = Utf8StringToNative.CreateFromUnsafeString( str );
            ISteamFriends._SteamAPI_ISteamFriends_ActivateGameOverlayToUser( Internal.Self, str__pchDialog, steamID );
        }

        public void ActivateGameOverlayToWebPage<TStr>( in TStr str, EActivateGameOverlayToWebPageMode webPageMode ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var str__pchDialog = Utf8StringToNative.CreateFromUnsafeString( str );
            ISteamFriends._SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage( Internal.Self, str__pchDialog, webPageMode );
        }

        public void ClearRichPresence()
        {
            Internal.ClearRichPresence();
        }

        public void SetRichPresence<TKey, TValue>( in TKey key, in TValue value )
            where TKey : unmanaged, INativeList<byte>, IUTF8Bytes
            where TValue : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var strKey = Utf8StringToNative.CreateFromUnsafeString( key );
            using var strValue = Utf8StringToNative.CreateFromUnsafeString( value );
            Internal._SetRichPresence( strKey, strValue );
        }

        public TPresense GetFriendRichPresence<TPresense, TKey>( SteamId steamIdFriend, in TKey pchKey )
            where TPresense : unmanaged, INativeList<byte>, IUTF8Bytes
            where TKey : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var strKey = Utf8StringToNative.CreateFromUnsafeString( pchKey );
            return Internal._GetFriendRichPresence( steamIdFriend, strKey ).ToUnsafeString<TPresense>();
        }

        public TStr GetPersonaName<TStr>()
            where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            return Internal._GetPersonaName().ToUnsafeString<TStr>();
        }

        public EPersonaState GetPersonaState()
        {
            return Internal.GetPersonaState();
        }

        public CallResult<FriendsIsFollowing_t> IsFollowing( SteamId steamId )
        {
            return Internal.IsFollowing( steamId );
        }

        public IEnumerable<Friend> GetFriends()
        {
            return GetFriendsWithFlag( EFriendFlags.Immediate );
        }

        public IEnumerable<Friend> GetBlocked()
        {
            return GetFriendsWithFlag( EFriendFlags.Blocked );
        }

        public IEnumerable<Friend> GetFriendsRequested()
        {
            return GetFriendsWithFlag( EFriendFlags.FriendshipRequested );
        }

        public IEnumerable<Friend> GetFriendsRequestingFriendship()
        {
            return GetFriendsWithFlag( EFriendFlags.RequestingFriendship );
        }

        public IEnumerable<Friend> GetFriendsClanMembers()
        {
            return GetFriendsWithFlag( EFriendFlags.ClanMember );
        }

        public IEnumerable<Friend> GetFriendsOnGameServer()
        {
            return GetFriendsWithFlag( EFriendFlags.OnGameServer );
        }

        public IEnumerable<Friend> GetFriendsWithFlag( EFriendFlags flags )
        {
            for ( int i = 0, count = Internal.GetFriendCount( ( int ) flags ); i < count; ++i )
            {
                yield return new Friend( Internal.GetFriendByIndex( i, ( int ) flags ) );
            }
        }

        public IEnumerable<Friend> GetPlayedWith()
        {
            for ( int i = 0, count = Internal.GetCoplayFriendCount(); i < count; ++i )
            {
                yield return new Friend( Internal.GetCoplayFriend( i ) );
            }
        }

        public IEnumerable<Friend> GetFromSource( SteamId source )
        {
            for ( int i = 0, count = Internal.GetFriendCountFromSource( source ); i < count; ++i )
            {
                yield return new Friend( Internal.GetFriendFromSourceByIndex( source, i ) );
            }
        }

        public void SetPlayedWith( SteamId steamIDUserPlayedWith )
        {
            Internal.SetPlayedWith( steamIDUserPlayedWith );
        } 

        /// <summary>
        /// Requests the persona name and optionally the avatar of a specified user.
        /// NOTE: It's a lot slower to download avatars and churns the local cache, so if you don't need avatars, don't request them.
        /// returns true if we're fetching the data, false if we already have it
        /// </summary>
        public bool RequestUserInformation( SteamId userId, bool nameonly = true ) => Internal.RequestUserInformation( userId, nameonly );
    }
}