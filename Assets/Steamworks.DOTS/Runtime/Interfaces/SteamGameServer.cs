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

        public bool AdvertiseServer
        {
            set => Internal.SetAdvertiseServerActive( value );
        }

        public bool DedicatedServer
        {
            set => Internal.SetDedicatedServer( value );
        }

        public int MaxPlayers
        {
            set => Internal.SetMaxPlayerCount( value );
        }

        public int BotCount
        {
            set => Internal.SetBotPlayerCount( value );
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

        public string ServerName
        {
            set => Internal.SetServerName( value );
        }

        public bool Passworded
        {
            set => Internal.SetPasswordProtected( value );
        }

        public string GameTags
        {
            set => Internal.SetGameTags( value );
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
                return Internal.BeginAuthSession( ( IntPtr ) data.GetUnsafeReadOnlyPtr(), data.Length, steamId );
            }
        }

        public void EndAuthSession( SteamId steamId )
        {
            Internal.EndAuthSession( steamId );
        }

        public EUserHasLicenseForAppResult UserHasLicenseForApp( SteamId steamId, AppId_t appId )
        {
            return Internal.UserHasLicenseForApp( steamId, appId );
        }
    }
}