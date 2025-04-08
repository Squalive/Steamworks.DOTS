using System;
using System.Net;
using Unity.Collections;

namespace Steamworks.Data
{
    public struct ServerInfo : IEquatable<ServerInfo>
    {
        internal servernetadr_t Address;
        public SteamId SteamId;
        public int Ping;
        public AppId_t AppId;
        public int Players;
        public int MaxPlayers;
        public int BotPlayers;
        public bool Password;
        public bool Secure;
        public uint TimeLastPlayed;
        public int ServerVersion;
        public FixedString64Bytes ServerName;
        public FixedString128Bytes GameTags;
        public FixedString32Bytes GameDir, Map;
        public FixedString64Bytes GameDescription;
        public uint IP => Address.IP;
        public IPAddress IPAddress => Utility.Int32ToIp( Address.IP );
        public ushort QueryPort => Address.QueryPort;
        public ushort ConnectionPort => Address.ConnectionPort;
        
        public unsafe ServerInfo( gameserveritem_t* rawValue )
        {
            Address = rawValue->NetAdr;
            SteamId = rawValue->SteamID;

            Ping = rawValue->Ping;
            AppId = rawValue->AppID;
            Players = rawValue->Players;
            MaxPlayers = rawValue->MaxPlayers;
            BotPlayers = rawValue->BotPlayers;
            Password = rawValue->Password;
            Secure = rawValue->Secure;
            TimeLastPlayed = rawValue->TimeLastPlayed;
            ServerVersion = rawValue->ServerVersion;
            
            ServerName = new Utf8StringPtr( rawValue->ServerName ).ToUnsafeString<FixedString64Bytes>();
            GameTags = new Utf8StringPtr( rawValue->GameTags ).ToUnsafeString<FixedString128Bytes>();
            GameDir = new Utf8StringPtr( rawValue->GameDir ).ToUnsafeString<FixedString32Bytes>();
            Map = new Utf8StringPtr( rawValue->Map ).ToUnsafeString<FixedString32Bytes>();
            GameDescription = new Utf8StringPtr( rawValue->GameDescription ).ToUnsafeString<FixedString64Bytes>();
        }

        public void AddToHistory( SteamMatchmaking steamMatchmaking )
        {
            steamMatchmaking.Internal.AddFavoriteGame( AppId, IP, ConnectionPort, QueryPort, Defines.k_unFavoriteFlagHistory, ( uint ) Epoch.Current );
        }

        public void RemoveFromHistory( SteamMatchmaking steamMatchmaking )
        {
            steamMatchmaking.Internal.RemoveFavoriteGame( AppId, IP, ConnectionPort, QueryPort, Defines.k_unFavoriteFlagHistory );
        }

        public void AddToFavourites( SteamMatchmaking steamMatchmaking )
        {
            steamMatchmaking.Internal.AddFavoriteGame( AppId, IP, ConnectionPort, QueryPort, Defines.k_unFavoriteFlagFavorite, ( uint ) Epoch.Current );
        }

        public void RemoveFromFavourites( SteamMatchmaking steamMatchmaking )
        {
            steamMatchmaking.Internal.RemoveFavoriteGame( AppId, IP, ConnectionPort, QueryPort, Defines.k_unFavoriteFlagFavorite );
        }

        public bool Equals( ServerInfo other )
        {
            return IP == other.IP && QueryPort == other.QueryPort && ConnectionPort == other.ConnectionPort && SteamId == other.SteamId;
        }

        public override bool Equals( object obj )
        {
            return obj is ServerInfo other && Equals( other );
        }

        public override int GetHashCode()
        {
            return IP.GetHashCode() ^ QueryPort.GetHashCode() ^ ConnectionPort.GetHashCode() ^ SteamId.GetHashCode();
        }
    }
}