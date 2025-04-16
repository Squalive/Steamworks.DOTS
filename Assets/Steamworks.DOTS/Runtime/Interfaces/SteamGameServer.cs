using System;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamGameServer : IComponentData
    {
        internal ISteamGameServer Internal;

        internal SteamGameServer( IntPtr iface )
        {
            Internal = new ISteamGameServer( iface );
        }

        public string MapName
        {
            set => Internal.SetMapName( value );
        }

        public string ModDir
        {
            set => Internal.SetModDir( value );
        }

        public string Product
        {
            set => Internal.SetProduct( value );
        }

        public string GameDescription
        {
            set => Internal.SetGameDescription( value );
        }

        public SteamId SteamId => Internal.GetSteamID();

        public void LogOnAnonymous()
        {
            Internal.LogOnAnonymous();
        }

        public void LogOn( string token )
        {
            Internal.LogOn( token );
        }

        public void LogOn<TStr>( in TStr token ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var hToken = Utf8StringToNative.CreateFromUnsafeString( token );
            ISteamGameServer._SteamAPI_ISteamGameServer_LogOn( Internal.Self, hToken );
        }

        public void LogOff()
        {
            Internal.LogOff();
        }

        public bool LoggedOn => Internal.BLoggedOn();

        public SteamIPAddress_t PublicIp => Internal.GetPublicIP();

        public void UpdatePlayer( SteamId steamId, string name, int score )
        {
            Internal.BUpdateUserData( steamId, name, ( uint ) score );
        }

        public EBeginAuthSessionResult BeginAuthSession( in NativeArray<byte> data, SteamId steamId )
        {
            if ( !data.IsCreated ) return EBeginAuthSessionResult.InvalidTicket;
            unsafe
            {
                return BeginAuthSession( ( IntPtr ) data.GetUnsafeReadOnlyPtr(), data.Length, steamId );
            }
        }

        public EBeginAuthSessionResult BeginAuthSession( IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID )
        {
            return Internal.BeginAuthSession( pAuthTicket, cbAuthTicket, steamID );
        }

        public void EndAuthSession( SteamId steamId )
        {
            Internal.EndAuthSession( steamId );
        }

        public EUserHasLicenseForAppResult UserHasLicenseForApp( SteamId steamId, AppId_t appId )
        {
            return Internal.UserHasLicenseForApp( steamId, appId );
        }

        public void SetKeyValue( string key, string value )
        {
            Internal.SetKeyValue( key, value );
        }

        public void SetKeyValue<TKey, TValue>( in TKey key, in TValue value )
            where TKey : unmanaged, INativeList<byte>, IUTF8Bytes
            where TValue : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var hKey = Utf8StringToNative.CreateFromUnsafeString( key );
            using var hValue = Utf8StringToNative.CreateFromUnsafeString( value );
            ISteamGameServer._SteamAPI_ISteamGameServer_SetKeyValue( Internal.Self, hKey, hValue );
        }

        public void SetServerName<TStr>( in TStr serverName ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var hServerName = Utf8StringToNative.CreateFromUnsafeString( serverName );
            ISteamGameServer._SteamAPI_ISteamGameServer_SetServerName( Internal.Self, hServerName );
        }

        public void SetGameTags<TStr>( in TStr gameTags ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var hGameTags = Utf8StringToNative.CreateFromUnsafeString( gameTags );
            ISteamGameServer._SteamAPI_ISteamGameServer_SetGameTags( Internal.Self, hGameTags );
        }

        public void SetMapName<TStr>( in TStr mapName ) where TStr : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            using var hMapName = Utf8StringToNative.CreateFromUnsafeString( mapName );
            ISteamGameServer._SteamAPI_ISteamGameServer_SetMapName( Internal.Self, hMapName );
        }

        public void SetPasswordProtected( bool passworded )
        {
            Internal.SetPasswordProtected( passworded );
        }

        public void SetAdvertiseServerActive( bool bValue )
        {
            Internal.SetAdvertiseServerActive( bValue );
        }

        public void SetDedicatedServer( bool bValue )
        {
            Internal.SetDedicatedServer( bValue );
        }

        public void SetMaxPlayerCount( int iValue )
        {
            Internal.SetMaxPlayerCount( iValue );
        }

        public void SetBotPlayerCount( int iValue )
        {
            Internal.SetBotPlayerCount( iValue );
        }
    }
}