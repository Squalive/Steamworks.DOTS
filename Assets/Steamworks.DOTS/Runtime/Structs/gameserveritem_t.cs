using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
    [ StructLayout( LayoutKind.Explicit, Pack = Platform.StructPackSize, Size = 372 ) ]
    public unsafe struct gameserveritem_t
    {
        [ FieldOffset( 0 ) ]
        public servernetadr_t NetAdr; // m_NetAdr servernetadr_t
        [ FieldOffset( 8 ) ]
        public int Ping; // m_nPing int
        [ FieldOffset( 12 ) ]
        public bool HadSuccessfulResponse; // m_bHadSuccessfulResponse bool
        [ FieldOffset( 13 ) ]
        public bool DoNotRefresh; // m_bDoNotRefresh bool
        [ FieldOffset( 14 ) ]
        public fixed byte GameDir[ 32 ]; // m_szGameDir char [32]
        [ FieldOffset( 46 ) ]
        public fixed byte Map[ 32 ]; // m_szMap char [32]
        [ FieldOffset( 78 ) ]
        public fixed byte GameDescription[ 64 ]; // m_szGameDescription char [64]
        [ FieldOffset( 144 ) ]
        public uint AppID; // m_nAppID uint32
        [ FieldOffset( 148 ) ]
        public int Players; // m_nPlayers int
        [ FieldOffset( 152 ) ]
        public int MaxPlayers; // m_nMaxPlayers int
        [ FieldOffset( 156 ) ]
        public int BotPlayers; // m_nBotPlayers int
        [ FieldOffset( 160 ) ]
        public bool Password; // m_bPassword bool
        [ FieldOffset( 161 ) ]
        public bool Secure; // m_bSecure bool
        [ FieldOffset( 164 ) ]
        public uint TimeLastPlayed; // m_ulTimeLastPlayed uint32
        [ FieldOffset( 168 ) ]
        public int ServerVersion; // m_nServerVersion int
        [ FieldOffset( 172 ) ]
        public fixed byte ServerName[ 64 ]; // m_szServerName char [64]
        [ FieldOffset( 236 ) ]
        public fixed byte GameTags[ 128 ]; // m_szGameTags char [128]
        [ FieldOffset( 364 ) ]
        public SteamId SteamID; // m_steamID CSteamID
		
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_Construct", CallingConvention = Platform.CC ) ]
        public static unsafe extern void SteamAPI_Construct( gameserveritem_t* self );
		
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_GetName", CallingConvention = Platform.CC ) ]
        public static unsafe extern Utf8StringPtr SteamAPI_GetName( gameserveritem_t* self );
		
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_SetName", CallingConvention = Platform.CC ) ]
        public static unsafe extern void SteamAPI_SetName( gameserveritem_t* self, IntPtr pName );
    }
}