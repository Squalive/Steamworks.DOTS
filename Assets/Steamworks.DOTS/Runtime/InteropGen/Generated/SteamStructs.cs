using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks.Data
{
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe partial struct SteamIPAddress_t
	{
		public fixed byte GubIPv6[ 16 ]; // m_rgubIPv6 uint8 [16]
		public ESteamIPType Type; // m_eType ESteamIPType
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamIPAddress_t_IsSet", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsSet( SteamIPAddress_t* self );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ] 
	public unsafe struct FriendGameInfo_t
	{
		public GameId GameID; // m_gameID CGameID
		public uint GameIP; // m_unGameIP uint32
		public ushort GamePort; // m_usGamePort uint16
		public ushort QueryPort; // m_usQueryPort uint16
		public ulong SteamIDLobby; // m_steamIDLobby CSteamID
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ] 
	public unsafe partial struct MatchMakingKeyValuePair_t
	{
		public fixed byte Key[ 256 ]; // m_szKey char [256]
		public fixed byte Value[ 256 ]; // m_szValue char [256]
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_MatchMakingKeyValuePair_t_Construct", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Construct( MatchMakingKeyValuePair_t* self );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe partial struct servernetadr_t
	{
		public ushort ConnectionPort; // m_usConnectionPort uint16
		public ushort QueryPort; // m_usQueryPort uint16
		public uint IP; // m_unIP uint32
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Construct", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Construct( servernetadr_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Init", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Init( servernetadr_t* self, uint ip, ushort usQueryPort, ushort usConnectionPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetQueryPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern ushort SteamAPI_GetQueryPort( servernetadr_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetQueryPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetQueryPort( servernetadr_t* self, ushort usPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern ushort SteamAPI_GetConnectionPort( servernetadr_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetConnectionPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetConnectionPort( servernetadr_t* self, ushort usPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern uint SteamAPI_GetIP( servernetadr_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIP( servernetadr_t* self, uint unIP );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionAddressString", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetConnectionAddressString( servernetadr_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetQueryAddressString", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetQueryAddressString( servernetadr_t* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_IsLessThan", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsLessThan( servernetadr_t* self, ref servernetadr_t netadr );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Assign", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Assign( servernetadr_t* self, ref servernetadr_t that );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ] 
	public unsafe partial struct gameserveritem_t
	{
		public servernetadr_t NetAdr; // m_NetAdr servernetadr_t
		public int Ping; // m_nPing int
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool HadSuccessfulResponse; // m_bHadSuccessfulResponse bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool DoNotRefresh; // m_bDoNotRefresh bool
		public fixed byte GameDir[ 32 ]; // m_szGameDir char [32]
		public fixed byte Map[ 32 ]; // m_szMap char [32]
		public fixed byte GameDescription[ 64 ]; // m_szGameDescription char [64]
		public uint AppID; // m_nAppID uint32
		public int Players; // m_nPlayers int
		public int MaxPlayers; // m_nMaxPlayers int
		public int BotPlayers; // m_nBotPlayers int
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Password; // m_bPassword bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Secure; // m_bSecure bool
		public uint TimeLastPlayed; // m_ulTimeLastPlayed uint32
		public int ServerVersion; // m_nServerVersion int
		public fixed byte ServerName[ 64 ]; // m_szServerName char [64]
		public fixed byte GameTags[ 128 ]; // m_szGameTags char [128]
		public ulong SteamID; // m_steamID CSteamID
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_Construct", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Construct( gameserveritem_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_GetName", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetName( gameserveritem_t* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_SetName", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetName( gameserveritem_t* self, IntPtr pName );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamPartyBeaconLocation_t
	{
		public ESteamPartyBeaconLocationType Type; // m_eType ESteamPartyBeaconLocationType
		public ulong LocationID; // m_ulLocationID uint64
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamParamStringArray_t
	{
		public IntPtr Strings; // m_ppStrings const char **
		public int NumStrings; // m_nNumStrings int32
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct LeaderboardEntry_t
	{
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		public int GlobalRank; // m_nGlobalRank int32
		public int Score; // m_nScore int32
		public int CDetails; // m_cDetails int32
		public ulong UGC; // m_hUGC UGCHandle_t
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct P2PSessionState_t
	{
		public byte ConnectionActive; // m_bConnectionActive uint8
		public byte Connecting; // m_bConnecting uint8
		public byte P2PSessionError; // m_eP2PSessionError uint8
		public byte UsingRelay; // m_bUsingRelay uint8
		public int BytesQueuedForSend; // m_nBytesQueuedForSend int32
		public int PacketsQueuedForSend; // m_nPacketsQueuedForSend int32
		public uint RemoteIP; // m_nRemoteIP uint32
		public ushort RemotePort; // m_nRemotePort uint16
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct InputAnalogActionData_t
	{
		public EInputSourceMode EMode; // eMode EInputSourceMode
		public float X; // x float
		public float Y; // y float
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BActive; // bActive bool
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct InputDigitalActionData_t
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BState; // bState bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BActive; // bActive bool
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct InputMotionData_t
	{
		public float RotQuatX; // rotQuatX float
		public float RotQuatY; // rotQuatY float
		public float RotQuatZ; // rotQuatZ float
		public float RotQuatW; // rotQuatW float
		public float PosAccelX; // posAccelX float
		public float PosAccelY; // posAccelY float
		public float PosAccelZ; // posAccelZ float
		public float RotVelX; // rotVelX float
		public float RotVelY; // rotVelY float
		public float RotVelZ; // rotVelZ float
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamInputActionEvent_t
	{
		public ulong ControllerHandle; // controllerHandle InputHandle_t
		public ESteamInputActionEventType EEventType; // eEventType ESteamInputActionEventType
// public SteamInputActionEvent_t.AnalogAction_t AnalogAction; // analogAction SteamInputActionEvent_t::AnalogAction_t
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamUGCDetails_t
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EResult Result; // m_eResult EResult
		public EWorkshopFileType FileType; // m_eFileType EWorkshopFileType
		public uint CreatorAppID; // m_nCreatorAppID AppId_t
		public uint ConsumerAppID; // m_nConsumerAppID AppId_t
		public fixed byte Title[ 129 ]; // m_rgchTitle char [129]
		public fixed byte Description[ 8000 ]; // m_rgchDescription char [8000]
		public ulong SteamIDOwner; // m_ulSteamIDOwner uint64
		public uint TimeCreated; // m_rtimeCreated uint32
		public uint TimeUpdated; // m_rtimeUpdated uint32
		public uint TimeAddedToUserList; // m_rtimeAddedToUserList uint32
		public ERemoteStoragePublishedFileVisibility Visibility; // m_eVisibility ERemoteStoragePublishedFileVisibility
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Banned; // m_bBanned bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool AcceptedForUse; // m_bAcceptedForUse bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool TagsTruncated; // m_bTagsTruncated bool
		public fixed byte Tags[ 1025 ]; // m_rgchTags char [1025]
		public ulong File; // m_hFile UGCHandle_t
		public ulong PreviewFile; // m_hPreviewFile UGCHandle_t
		public fixed byte PchFileName[ 260 ]; // m_pchFileName char [260]
		public int FileSize; // m_nFileSize int32
		public int PreviewFileSize; // m_nPreviewFileSize int32
		public fixed byte URL[ 256 ]; // m_rgchURL char [256]
		public uint VotesUp; // m_unVotesUp uint32
		public uint VotesDown; // m_unVotesDown uint32
		public float Score; // m_flScore float
		public uint NumChildren; // m_unNumChildren uint32
		public ulong TotalFilesSize; // m_ulTotalFilesSize uint64
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamItemDetails_t
	{
		public ulong ItemId; // m_itemId SteamItemInstanceID_t
		public int Definition; // m_iDefinition SteamItemDef_t
		public ushort Quantity; // m_unQuantity uint16
		public ushort Flags; // m_unFlags uint16
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct RemotePlayInputMouseMotion_t
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Absolute; // m_bAbsolute bool
		public float NormalizedX; // m_flNormalizedX float
		public float NormalizedY; // m_flNormalizedY float
		public int DeltaX; // m_nDeltaX int
		public int DeltaY; // m_nDeltaY int
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct RemotePlayInputMouseWheel_t
	{
		public ERemotePlayMouseWheelDirection Direction; // m_eDirection ERemotePlayMouseWheelDirection
		public float Amount; // m_flAmount float
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct RemotePlayInputKey_t
	{
		public int Scancode; // m_eScancode int
		public uint Modifiers; // m_unModifiers uint32
		public uint Keycode; // m_unKeycode uint32
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct RemotePlayInput_t
	{
		public uint SessionID; // m_unSessionID RemotePlaySessionID_t
		public ERemotePlayInputType Type; // m_eType ERemotePlayInputType
		public fixed byte Padding[ 56 ]; // padding char [56]
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe partial struct SteamNetworkingIPAddr
	{
		public fixed byte Pv6[ 16 ]; // m_ipv6 uint8 [16]
		public ushort Port; // m_port uint16
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_Clear", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Clear( SteamNetworkingIPAddr* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv6AllZeros", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsIPv6AllZeros( SteamNetworkingIPAddr* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv6( SteamNetworkingIPAddr* self, ref byte ipv6, ushort nPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv4( SteamNetworkingIPAddr* self, uint nIP, ushort nPort );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsIPv4( SteamNetworkingIPAddr* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern uint SteamAPI_GetIPv4( SteamNetworkingIPAddr* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6LocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv6LocalHost( SteamNetworkingIPAddr* self, ushort nPort );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsLocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsLocalHost( SteamNetworkingIPAddr* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ToString", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_ToString( SteamNetworkingIPAddr* self, IntPtr buf, uint cbBuf, [ MarshalAs( UnmanagedType.U1 ) ] bool bWithPort );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ParseString", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_ParseString( SteamNetworkingIPAddr* self, IntPtr pszStr );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsEqualTo", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsEqualTo( SteamNetworkingIPAddr* self, ref SteamNetworkingIPAddr x );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetFakeIPType", CallingConvention = Platform.CC ) ]
		public static unsafe extern ESteamNetworkingFakeIPType SteamAPI_GetFakeIPType( SteamNetworkingIPAddr* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsFakeIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsFakeIP( SteamNetworkingIPAddr* self );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe partial struct SteamNetworkingIdentity
	{
		public ESteamNetworkingIdentityType Type; // m_eType ESteamNetworkingIdentityType
		public int CbSize; // m_cbSize int
		public fixed byte UnknownRawString[ 128 ]; // m_szUnknownRawString char [128]
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_Clear", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Clear( SteamNetworkingIdentity* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsInvalid", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsInvalid( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetSteamID( SteamNetworkingIdentity* self, SteamId steamID );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID", CallingConvention = Platform.CC ) ]
		public static unsafe extern SteamId SteamAPI_GetSteamID( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID64", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetSteamID64( SteamNetworkingIdentity* self, ulong steamID );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID64", CallingConvention = Platform.CC ) ]
		public static unsafe extern ulong SteamAPI_GetSteamID64( SteamNetworkingIdentity* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetXboxPairwiseID", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_SetXboxPairwiseID( SteamNetworkingIdentity* self, IntPtr pszString );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetXboxPairwiseID", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetXboxPairwiseID( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetPSNID", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetPSNID( SteamNetworkingIdentity* self, ulong id );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetPSNID", CallingConvention = Platform.CC ) ]
		public static unsafe extern ulong SteamAPI_GetPSNID( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPAddr", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPAddr( SteamNetworkingIdentity* self, ref SteamNetworkingIPAddr addr );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPAddr", CallingConvention = Platform.CC ) ]
		public static unsafe extern IntPtr SteamAPI_GetIPAddr( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPv4Addr", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv4Addr( SteamNetworkingIdentity* self, uint nIPv4, ushort nPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern uint SteamAPI_GetIPv4( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetFakeIPType", CallingConvention = Platform.CC ) ]
		public static unsafe extern ESteamNetworkingFakeIPType SteamAPI_GetFakeIPType( SteamNetworkingIdentity* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsFakeIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsFakeIP( SteamNetworkingIdentity* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetLocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetLocalHost( SteamNetworkingIdentity* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsLocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsLocalHost( SteamNetworkingIdentity* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericString", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_SetGenericString( SteamNetworkingIdentity* self, IntPtr pszString );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericString", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetGenericString( SteamNetworkingIdentity* self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericBytes", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_SetGenericBytes( SteamNetworkingIdentity* self, IntPtr data, uint cbLen );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericBytes", CallingConvention = Platform.CC ) ]
		public static unsafe extern byte SteamAPI_GetGenericBytes( SteamNetworkingIdentity* self, ref int cbLen );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsEqualTo", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsEqualTo( SteamNetworkingIdentity* self, ref SteamNetworkingIdentity x );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ToString", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_ToString( SteamNetworkingIdentity* self, IntPtr buf, uint cbBuf );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ParseString", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_ParseString( SteamNetworkingIdentity* self, IntPtr pszStr );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamNetConnectionInfo_t
	{
		public SteamNetworkingIdentity DentityRemote; // m_identityRemote SteamNetworkingIdentity
		public long UserData; // m_nUserData int64
		public uint ListenSocket; // m_hListenSocket HSteamListenSocket
		public SteamNetworkingIPAddr AddrRemote; // m_addrRemote SteamNetworkingIPAddr
		public ushort _pad1; // m__pad1 uint16
		public uint DPOPRemote; // m_idPOPRemote SteamNetworkingPOPID
		public uint DPOPRelay; // m_idPOPRelay SteamNetworkingPOPID
		public ESteamNetworkingConnectionState State; // m_eState ESteamNetworkingConnectionState
		public int EndReason; // m_eEndReason int
		public fixed byte EndDebug[ 128 ]; // m_szEndDebug char [128]
		public fixed byte ConnectionDescription[ 128 ]; // m_szConnectionDescription char [128]
		public int Flags; // m_nFlags int
		public fixed uint Reserved[ 63 ]; // reserved uint32 [63]
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamNetConnectionRealTimeStatus_t
	{
		public ESteamNetworkingConnectionState State; // m_eState ESteamNetworkingConnectionState
		public int Ping; // m_nPing int
		public float ConnectionQualityLocal; // m_flConnectionQualityLocal float
		public float ConnectionQualityRemote; // m_flConnectionQualityRemote float
		public float OutPacketsPerSec; // m_flOutPacketsPerSec float
		public float OutBytesPerSec; // m_flOutBytesPerSec float
		public float InPacketsPerSec; // m_flInPacketsPerSec float
		public float InBytesPerSec; // m_flInBytesPerSec float
		public int SendRateBytesPerSecond; // m_nSendRateBytesPerSecond int
		public int CbPendingUnreliable; // m_cbPendingUnreliable int
		public int CbPendingReliable; // m_cbPendingReliable int
		public int CbSentUnackedReliable; // m_cbSentUnackedReliable int
		public long EcQueueTime; // m_usecQueueTime SteamNetworkingMicroseconds
		public fixed uint Reserved[ 16 ]; // reserved uint32 [16]
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamNetConnectionRealTimeLaneStatus_t
	{
		public int CbPendingUnreliable; // m_cbPendingUnreliable int
		public int CbPendingReliable; // m_cbPendingReliable int
		public int CbSentUnackedReliable; // m_cbSentUnackedReliable int
		public int _reservePad1; // _reservePad1 int
		public long EcQueueTime; // m_usecQueueTime SteamNetworkingMicroseconds
		public fixed uint Reserved[ 10 ]; // reserved uint32 [10]
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamNetworkPingLocation_t
	{
		public fixed byte Data[ 512 ]; // m_data uint8 [512]
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe partial struct SteamNetworkingConfigValue_t
	{
		public ESteamNetworkingConfigValue Value; // m_eValue ESteamNetworkingConfigValue
		public ESteamNetworkingConfigDataType DataType; // m_eDataType ESteamNetworkingConfigDataType
		public long Nt64; // m_int64 int64_t
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt32", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetInt32( SteamNetworkingConfigValue_t* self, ESteamNetworkingConfigValue eVal, int data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt64", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetInt64( SteamNetworkingConfigValue_t* self, ESteamNetworkingConfigValue eVal, long data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetFloat", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetFloat( SteamNetworkingConfigValue_t* self, ESteamNetworkingConfigValue eVal, float data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetPtr", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetPtr( SteamNetworkingConfigValue_t* self, ESteamNetworkingConfigValue eVal, IntPtr data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetString", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetString( SteamNetworkingConfigValue_t* self, ESteamNetworkingConfigValue eVal, IntPtr data );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe partial struct SteamDatagramHostedAddress
	{
		public int CbSize; // m_cbSize int
		public fixed byte Data[ 128 ]; // m_data char [128]
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_Clear", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Clear( SteamDatagramHostedAddress* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_GetPopID", CallingConvention = Platform.CC ) ]
		public static unsafe extern SteamNetworkingPOPID SteamAPI_GetPopID( SteamDatagramHostedAddress* self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_SetDevAddress", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetDevAddress( SteamDatagramHostedAddress* self, uint nIP, ushort nPort, SteamNetworkingPOPID popid );
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ] 
	public unsafe struct SteamDatagramGameCoordinatorServerLogin
	{
		public SteamNetworkingIdentity Dentity; // m_identity SteamNetworkingIdentity
		public SteamDatagramHostedAddress Outing; // m_routing SteamDatagramHostedAddress
		public uint AppID; // m_nAppID AppId_t
		public uint Time; // m_rtime RTime32
		public int CbAppData; // m_cbAppData int
		public fixed byte AppData[ 2048 ]; // m_appData char [2048]
		
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamServersConnected_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamServersConnected_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamServersConnected_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamServerConnectFailure_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool StillRetrying; // m_bStillRetrying bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamServerConnectFailure_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamServerConnectFailure_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamServersDisconnected_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamServersDisconnected_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamServersDisconnected_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ClientGameServerDeny_t : ISteamCallback
	{
		public uint AppID; // m_uAppID uint32
		public uint GameServerIP; // m_unGameServerIP uint32
		public ushort GameServerPort; // m_usGameServerPort uint16
		public ushort Secure; // m_bSecure uint16
		public uint Reason; // m_uReason uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ClientGameServerDeny_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ClientGameServerDeny_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct IPCFailure_t : ISteamCallback
	{
		public byte FailureType; // m_eFailureType uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<IPCFailure_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.IPCFailure_t;
		#endregion
		public enum EFailureType : int
		{
			FlushedCallbackQueue = 0,
			PipeFail = 1,
		}
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LicensesUpdated_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LicensesUpdated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LicensesUpdated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct ValidateAuthTicketResponse_t : ISteamCallback
	{
		public ulong SteamID; // m_SteamID CSteamID
		public EAuthSessionResponse AuthSessionResponse; // m_eAuthSessionResponse EAuthSessionResponse
		public ulong OwnerSteamID; // m_OwnerSteamID CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ValidateAuthTicketResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ValidateAuthTicketResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MicroTxnAuthorizationResponse_t : ISteamCallback
	{
		public uint AppID; // m_unAppID uint32
		public ulong OrderID; // m_ulOrderID uint64
		public byte Authorized; // m_bAuthorized uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MicroTxnAuthorizationResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MicroTxnAuthorizationResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct EncryptedAppTicketResponse_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<EncryptedAppTicketResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.EncryptedAppTicketResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GetAuthSessionTicketResponse_t : ISteamCallback
	{
		public uint AuthTicket; // m_hAuthTicket HAuthTicket
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GetAuthSessionTicketResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GetAuthSessionTicketResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GameWebCallback_t : ISteamCallback
	{
		public fixed byte URL[ 256 ]; // m_szURL char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameWebCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameWebCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct StoreAuthURLResponse_t : ISteamCallback
	{
		public fixed byte URL[ 512 ]; // m_szURL char [512]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<StoreAuthURLResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.StoreAuthURLResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MarketEligibilityResponse_t : ISteamCallback
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Allowed; // m_bAllowed bool
		public EMarketNotAllowedReasonFlags NotAllowedReason; // m_eNotAllowedReason EMarketNotAllowedReasonFlags
		public uint TAllowedAtTime; // m_rtAllowedAtTime RTime32
		public int CdaySteamGuardRequiredDays; // m_cdaySteamGuardRequiredDays int
		public int CdayNewDeviceCooldown; // m_cdayNewDeviceCooldown int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MarketEligibilityResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MarketEligibilityResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct DurationControl_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public uint Appid; // m_appid AppId_t
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Applicable; // m_bApplicable bool
		public int CsecsLast5h; // m_csecsLast5h int32
		public EDurationControlProgress Progress; // m_progress EDurationControlProgress
		public EDurationControlNotification Otification; // m_notification EDurationControlNotification
		public int CsecsToday; // m_csecsToday int32
		public int CsecsRemaining; // m_csecsRemaining int32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<DurationControl_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.DurationControl_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GetTicketForWebApiResponse_t : ISteamCallback
	{
		public uint AuthTicket; // m_hAuthTicket HAuthTicket
		public EResult Result; // m_eResult EResult
		public int Ticket; // m_cubTicket int
		public fixed byte GubTicket[ 2560 ]; // m_rgubTicket uint8 [2560]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GetTicketForWebApiResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GetTicketForWebApiResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct PersonaStateChange_t : ISteamCallback
	{
		public ulong SteamID; // m_ulSteamID uint64
		public int ChangeFlags; // m_nChangeFlags int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<PersonaStateChange_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.PersonaStateChange_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GameOverlayActivated_t : ISteamCallback
	{
		public byte Active; // m_bActive uint8
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UserInitiated; // m_bUserInitiated bool
		public uint AppID; // m_nAppID AppId_t
		public uint DwOverlayPID; // m_dwOverlayPID uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameOverlayActivated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameOverlayActivated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GameServerChangeRequested_t : ISteamCallback
	{
		public fixed byte Server[ 64 ]; // m_rgchServer char [64]
		public fixed byte Password[ 64 ]; // m_rgchPassword char [64]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameServerChangeRequested_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameServerChangeRequested_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GameLobbyJoinRequested_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_steamIDLobby CSteamID
		public ulong SteamIDFriend; // m_steamIDFriend CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameLobbyJoinRequested_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameLobbyJoinRequested_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AvatarImageLoaded_t : ISteamCallback
	{
		public ulong SteamID; // m_steamID CSteamID
		public int Image; // m_iImage int
		public int Wide; // m_iWide int
		public int Tall; // m_iTall int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AvatarImageLoaded_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AvatarImageLoaded_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ClanOfficerListResponse_t : ISteamCallback
	{
		public ulong SteamIDClan; // m_steamIDClan CSteamID
		public int COfficers; // m_cOfficers int
		public byte Success; // m_bSuccess uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ClanOfficerListResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ClanOfficerListResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct FriendRichPresenceUpdate_t : ISteamCallback
	{
		public ulong SteamIDFriend; // m_steamIDFriend CSteamID
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FriendRichPresenceUpdate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FriendRichPresenceUpdate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GameRichPresenceJoinRequested_t : ISteamCallback
	{
		public ulong SteamIDFriend; // m_steamIDFriend CSteamID
		public fixed byte Connect[ 256 ]; // m_rgchConnect char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameRichPresenceJoinRequested_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameRichPresenceJoinRequested_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GameConnectedClanChatMsg_t : ISteamCallback
	{
		public ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		public int MessageID; // m_iMessageID int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameConnectedClanChatMsg_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameConnectedClanChatMsg_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GameConnectedChatJoin_t : ISteamCallback
	{
		public ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameConnectedChatJoin_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameConnectedChatJoin_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GameConnectedChatLeave_t : ISteamCallback
	{
		public ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Kicked; // m_bKicked bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Dropped; // m_bDropped bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameConnectedChatLeave_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameConnectedChatLeave_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct DownloadClanActivityCountsResult_t : ISteamCallback
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Success; // m_bSuccess bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<DownloadClanActivityCountsResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.DownloadClanActivityCountsResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct JoinClanChatRoomCompletionResult_t : ISteamCallback
	{
		public ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
		public EChatRoomEnterResponse ChatRoomEnterResponse; // m_eChatRoomEnterResponse EChatRoomEnterResponse
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<JoinClanChatRoomCompletionResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.JoinClanChatRoomCompletionResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GameConnectedFriendChatMsg_t : ISteamCallback
	{
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		public int MessageID; // m_iMessageID int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GameConnectedFriendChatMsg_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GameConnectedFriendChatMsg_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct FriendsGetFollowerCount_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamID; // m_steamID CSteamID
		public int Count; // m_nCount int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FriendsGetFollowerCount_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FriendsGetFollowerCount_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct FriendsIsFollowing_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamID; // m_steamID CSteamID
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool IsFollowing; // m_bIsFollowing bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FriendsIsFollowing_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FriendsIsFollowing_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct FriendsEnumerateFollowingList_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public fixed ulong GSteamID[ 50 ]; // m_rgSteamID CSteamID [50]
		public int ResultsReturned; // m_nResultsReturned int32
		public int TotalResultCount; // m_nTotalResultCount int32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FriendsEnumerateFollowingList_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FriendsEnumerateFollowingList_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UnreadChatMessagesChanged_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UnreadChatMessagesChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UnreadChatMessagesChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct OverlayBrowserProtocolNavigation_t : ISteamCallback
	{
		public fixed byte RgchURI[ 1024 ]; // rgchURI char [1024]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<OverlayBrowserProtocolNavigation_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.OverlayBrowserProtocolNavigation_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct EquippedProfileItemsChanged_t : ISteamCallback
	{
		public ulong SteamID; // m_steamID CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<EquippedProfileItemsChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.EquippedProfileItemsChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct EquippedProfileItems_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamID; // m_steamID CSteamID
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool HasAnimatedAvatar; // m_bHasAnimatedAvatar bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool HasAvatarFrame; // m_bHasAvatarFrame bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool HasProfileModifier; // m_bHasProfileModifier bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool HasProfileBackground; // m_bHasProfileBackground bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool HasMiniProfileBackground; // m_bHasMiniProfileBackground bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool FromCache; // m_bFromCache bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<EquippedProfileItems_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.EquippedProfileItems_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct IPCountry_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<IPCountry_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.IPCountry_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LowBatteryPower_t : ISteamCallback
	{
		public byte MinutesBatteryLeft; // m_nMinutesBatteryLeft uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LowBatteryPower_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LowBatteryPower_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamAPICallCompleted_t : ISteamCallback
	{
		public ulong AsyncCall; // m_hAsyncCall SteamAPICall_t
		public int Callback; // m_iCallback int
		public uint ParamCount; // m_cubParam uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamAPICallCompleted_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamAPICallCompleted_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamShutdown_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamShutdown_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamShutdown_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct CheckFileSignature_t : ISteamCallback
	{
		public ECheckFileSignature CheckFileSignature; // m_eCheckFileSignature ECheckFileSignature
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<CheckFileSignature_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.CheckFileSignature_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GamepadTextInputDismissed_t : ISteamCallback
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Submitted; // m_bSubmitted bool
		public uint SubmittedText; // m_unSubmittedText uint32
		public uint AppID; // m_unAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GamepadTextInputDismissed_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GamepadTextInputDismissed_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AppResumingFromSuspend_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AppResumingFromSuspend_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AppResumingFromSuspend_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct FloatingGamepadTextInputDismissed_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FloatingGamepadTextInputDismissed_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FloatingGamepadTextInputDismissed_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct FilterTextDictionaryChanged_t : ISteamCallback
	{
		public int Language; // m_eLanguage int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FilterTextDictionaryChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FilterTextDictionaryChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct FavoritesListChanged_t : ISteamCallback
	{
		public uint IP; // m_nIP uint32
		public uint QueryPort; // m_nQueryPort uint32
		public uint ConnPort; // m_nConnPort uint32
		public uint AppID; // m_nAppID uint32
		public uint Flags; // m_nFlags uint32
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Add; // m_bAdd bool
		public uint AccountId; // m_unAccountId AccountID_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FavoritesListChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FavoritesListChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyInvite_t : ISteamCallback
	{
		public ulong SteamIDUser; // m_ulSteamIDUser uint64
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public ulong GameID; // m_ulGameID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyInvite_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyInvite_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyEnter_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public uint GfChatPermissions; // m_rgfChatPermissions uint32
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Locked; // m_bLocked bool
		public uint EChatRoomEnterResponse; // m_EChatRoomEnterResponse uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyEnter_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyEnter_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyDataUpdate_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public ulong SteamIDMember; // m_ulSteamIDMember uint64
		public byte Success; // m_bSuccess uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyDataUpdate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyDataUpdate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyChatUpdate_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public ulong SteamIDUserChanged; // m_ulSteamIDUserChanged uint64
		public ulong SteamIDMakingChange; // m_ulSteamIDMakingChange uint64
		public uint GfChatMemberStateChange; // m_rgfChatMemberStateChange uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyChatUpdate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyChatUpdate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyChatMsg_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public ulong SteamIDUser; // m_ulSteamIDUser uint64
		public byte ChatEntryType; // m_eChatEntryType uint8
		public uint ChatID; // m_iChatID uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyChatMsg_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyChatMsg_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyGameCreated_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public ulong SteamIDGameServer; // m_ulSteamIDGameServer uint64
		public uint IP; // m_unIP uint32
		public ushort Port; // m_usPort uint16
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyGameCreated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyGameCreated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyMatchList_t : ISteamCallback
	{
		public uint LobbiesMatching; // m_nLobbiesMatching uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyMatchList_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyMatchList_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyKicked_t : ISteamCallback
	{
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		public ulong SteamIDAdmin; // m_ulSteamIDAdmin uint64
		public byte KickedDueToDisconnect; // m_bKickedDueToDisconnect uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyKicked_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyKicked_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LobbyCreated_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamIDLobby; // m_ulSteamIDLobby uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LobbyCreated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LobbyCreated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct FavoritesListAccountsUpdated_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FavoritesListAccountsUpdated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FavoritesListAccountsUpdated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct SearchForGameProgressCallback_t : ISteamCallback
	{
		public ulong LSearchID; // m_ullSearchID uint64
		public EResult Result; // m_eResult EResult
		public ulong LobbyID; // m_lobbyID CSteamID
		public ulong SteamIDEndedSearch; // m_steamIDEndedSearch CSteamID
		public int SecondsRemainingEstimate; // m_nSecondsRemainingEstimate int32
		public int CPlayersSearching; // m_cPlayersSearching int32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SearchForGameProgressCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SearchForGameProgressCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct SearchForGameResultCallback_t : ISteamCallback
	{
		public ulong LSearchID; // m_ullSearchID uint64
		public EResult Result; // m_eResult EResult
		public int CountPlayersInGame; // m_nCountPlayersInGame int32
		public int CountAcceptedGame; // m_nCountAcceptedGame int32
		public ulong SteamIDHost; // m_steamIDHost CSteamID
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool FinalCallback; // m_bFinalCallback bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SearchForGameResultCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SearchForGameResultCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RequestPlayersForGameProgressCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong LSearchID; // m_ullSearchID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RequestPlayersForGameProgressCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RequestPlayersForGameProgressCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct RequestPlayersForGameResultCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong LSearchID; // m_ullSearchID uint64
		public ulong SteamIDPlayerFound; // m_SteamIDPlayerFound CSteamID
		public ulong SteamIDLobby; // m_SteamIDLobby CSteamID
		public RequestPlayersForGameResultCallback_t.PlayerAcceptState_t PlayerAcceptState; // m_ePlayerAcceptState RequestPlayersForGameResultCallback_t::PlayerAcceptState_t
		public int PlayerIndex; // m_nPlayerIndex int32
		public int TotalPlayersFound; // m_nTotalPlayersFound int32
		public int TotalPlayersAcceptedGame; // m_nTotalPlayersAcceptedGame int32
		public int SuggestedTeamIndex; // m_nSuggestedTeamIndex int32
		public ulong LUniqueGameID; // m_ullUniqueGameID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RequestPlayersForGameResultCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RequestPlayersForGameResultCallback_t;
		#endregion
		public enum PlayerAcceptState_t : int
		{
			Unknown = 0,
			PlayerAccepted = 1,
			PlayerDeclined = 2,
		}
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RequestPlayersForGameFinalResultCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong LSearchID; // m_ullSearchID uint64
		public ulong LUniqueGameID; // m_ullUniqueGameID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RequestPlayersForGameFinalResultCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RequestPlayersForGameFinalResultCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct SubmitPlayerResultResultCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong UllUniqueGameID; // ullUniqueGameID uint64
		public ulong SteamIDPlayer; // steamIDPlayer CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SubmitPlayerResultResultCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SubmitPlayerResultResultCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct EndGameResultCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong UllUniqueGameID; // ullUniqueGameID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<EndGameResultCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.EndGameResultCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct JoinPartyCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong BeaconID; // m_ulBeaconID PartyBeaconID_t
		public ulong SteamIDBeaconOwner; // m_SteamIDBeaconOwner CSteamID
		public fixed byte ConnectString[ 256 ]; // m_rgchConnectString char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<JoinPartyCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.JoinPartyCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct CreateBeaconCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong BeaconID; // m_ulBeaconID PartyBeaconID_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<CreateBeaconCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.CreateBeaconCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct ReservationNotificationCallback_t : ISteamCallback
	{
		public ulong BeaconID; // m_ulBeaconID PartyBeaconID_t
		public ulong SteamIDJoiner; // m_steamIDJoiner CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ReservationNotificationCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ReservationNotificationCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ChangeNumOpenSlotsCallback_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ChangeNumOpenSlotsCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ChangeNumOpenSlotsCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AvailableBeaconLocationsUpdated_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AvailableBeaconLocationsUpdated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AvailableBeaconLocationsUpdated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ActiveBeaconsUpdated_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ActiveBeaconsUpdated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ActiveBeaconsUpdated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageFileShareResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong File; // m_hFile UGCHandle_t
		public fixed byte Filename[ 260 ]; // m_rgchFilename char [260]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageFileShareResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageFileShareResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStoragePublishFileResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStoragePublishFileResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStoragePublishFileResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageDeletePublishedFileResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageDeletePublishedFileResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageDeletePublishedFileResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageEnumerateUserPublishedFilesResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public int ResultsReturned; // m_nResultsReturned int32
		public int TotalResultCount; // m_nTotalResultCount int32
		public fixed ulong GPublishedFileId[ 50 ]; // m_rgPublishedFileId PublishedFileId_t [50]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageEnumerateUserPublishedFilesResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageEnumerateUserPublishedFilesResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageSubscribePublishedFileResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageSubscribePublishedFileResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageSubscribePublishedFileResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageEnumerateUserSubscribedFilesResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public int ResultsReturned; // m_nResultsReturned int32
		public int TotalResultCount; // m_nTotalResultCount int32
		public fixed ulong GPublishedFileId[ 50 ]; // m_rgPublishedFileId PublishedFileId_t [50]
		public fixed uint GRTimeSubscribed[ 50 ]; // m_rgRTimeSubscribed uint32 [50]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageEnumerateUserSubscribedFilesResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageEnumerateUserSubscribedFilesResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageUnsubscribePublishedFileResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageUnsubscribePublishedFileResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageUnsubscribePublishedFileResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageUpdatePublishedFileResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageUpdatePublishedFileResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageUpdatePublishedFileResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageDownloadUGCResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong File; // m_hFile UGCHandle_t
		public uint AppID; // m_nAppID AppId_t
		public int SizeInBytes; // m_nSizeInBytes int32
		public fixed byte PchFileName[ 260 ]; // m_pchFileName char [260]
		public ulong SteamIDOwner; // m_ulSteamIDOwner uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageDownloadUGCResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageDownloadUGCResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageGetPublishedFileDetailsResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint CreatorAppID; // m_nCreatorAppID AppId_t
		public uint ConsumerAppID; // m_nConsumerAppID AppId_t
		public fixed byte Title[ 129 ]; // m_rgchTitle char [129]
		public fixed byte Description[ 8000 ]; // m_rgchDescription char [8000]
		public ulong File; // m_hFile UGCHandle_t
		public ulong PreviewFile; // m_hPreviewFile UGCHandle_t
		public ulong SteamIDOwner; // m_ulSteamIDOwner uint64
		public uint TimeCreated; // m_rtimeCreated uint32
		public uint TimeUpdated; // m_rtimeUpdated uint32
		public ERemoteStoragePublishedFileVisibility Visibility; // m_eVisibility ERemoteStoragePublishedFileVisibility
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Banned; // m_bBanned bool
		public fixed byte Tags[ 1025 ]; // m_rgchTags char [1025]
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool TagsTruncated; // m_bTagsTruncated bool
		public fixed byte PchFileName[ 260 ]; // m_pchFileName char [260]
		public int FileSize; // m_nFileSize int32
		public int PreviewFileSize; // m_nPreviewFileSize int32
		public fixed byte URL[ 256 ]; // m_rgchURL char [256]
		public EWorkshopFileType FileType; // m_eFileType EWorkshopFileType
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool AcceptedForUse; // m_bAcceptedForUse bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageGetPublishedFileDetailsResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageGetPublishedFileDetailsResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageEnumerateWorkshopFilesResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public int ResultsReturned; // m_nResultsReturned int32
		public int TotalResultCount; // m_nTotalResultCount int32
		public fixed ulong GPublishedFileId[ 50 ]; // m_rgPublishedFileId PublishedFileId_t [50]
		public fixed float GScore[ 50 ]; // m_rgScore float [50]
		public uint AppId; // m_nAppId AppId_t
		public uint StartIndex; // m_unStartIndex uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageEnumerateWorkshopFilesResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageEnumerateWorkshopFilesResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageGetPublishedItemVoteDetailsResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_unPublishedFileId PublishedFileId_t
		public int VotesFor; // m_nVotesFor int32
		public int VotesAgainst; // m_nVotesAgainst int32
		public int Reports; // m_nReports int32
		public float FScore; // m_fScore float
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageGetPublishedItemVoteDetailsResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageGetPublishedItemVoteDetailsResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStoragePublishedFileSubscribed_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStoragePublishedFileSubscribed_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStoragePublishedFileSubscribed_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStoragePublishedFileUnsubscribed_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStoragePublishedFileUnsubscribed_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStoragePublishedFileUnsubscribed_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStoragePublishedFileDeleted_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStoragePublishedFileDeleted_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStoragePublishedFileDeleted_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageUpdateUserPublishedItemVoteResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageUpdateUserPublishedItemVoteResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageUpdateUserPublishedItemVoteResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageUserVoteDetails_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EWorkshopVote Vote; // m_eVote EWorkshopVote
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageUserVoteDetails_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageUserVoteDetails_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public int ResultsReturned; // m_nResultsReturned int32
		public int TotalResultCount; // m_nTotalResultCount int32
		public fixed ulong GPublishedFileId[ 50 ]; // m_rgPublishedFileId PublishedFileId_t [50]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageEnumerateUserSharedWorkshopFilesResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageEnumerateUserSharedWorkshopFilesResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageSetUserPublishedFileActionResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EWorkshopFileAction Action; // m_eAction EWorkshopFileAction
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageSetUserPublishedFileActionResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageSetUserPublishedFileActionResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public EWorkshopFileAction Action; // m_eAction EWorkshopFileAction
		public int ResultsReturned; // m_nResultsReturned int32
		public int TotalResultCount; // m_nTotalResultCount int32
		public fixed ulong GPublishedFileId[ 50 ]; // m_rgPublishedFileId PublishedFileId_t [50]
		public fixed uint GRTimeUpdated[ 50 ]; // m_rgRTimeUpdated uint32 [50]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageEnumeratePublishedFilesByUserActionResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageEnumeratePublishedFilesByUserActionResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStoragePublishFileProgress_t : ISteamCallback
	{
		public double DPercentFile; // m_dPercentFile double
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Preview; // m_bPreview bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStoragePublishFileProgress_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStoragePublishFileProgress_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStoragePublishedFileUpdated_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint AppID; // m_nAppID AppId_t
		public ulong Unused; // m_ulUnused uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStoragePublishedFileUpdated_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStoragePublishedFileUpdated_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageFileWriteAsyncComplete_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageFileWriteAsyncComplete_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageFileWriteAsyncComplete_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageFileReadAsyncComplete_t : ISteamCallback
	{
		public ulong FileReadAsync; // m_hFileReadAsync SteamAPICall_t
		public EResult Result; // m_eResult EResult
		public uint Offset; // m_nOffset uint32
		public uint Read; // m_cubRead uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageFileReadAsyncComplete_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageFileReadAsyncComplete_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoteStorageLocalFileChange_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoteStorageLocalFileChange_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoteStorageLocalFileChange_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct UserStatsReceived_t : ISteamCallback
	{
		public ulong GameID; // m_nGameID uint64
		public EResult Result; // m_eResult EResult
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserStatsReceived_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserStatsReceived_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UserStatsStored_t : ISteamCallback
	{
		public ulong GameID; // m_nGameID uint64
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserStatsStored_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserStatsStored_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UserAchievementStored_t : ISteamCallback
	{
		public ulong GameID; // m_nGameID uint64
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool GroupAchievement; // m_bGroupAchievement bool
		public fixed byte AchievementName[ 128 ]; // m_rgchAchievementName char [128]
		public uint CurProgress; // m_nCurProgress uint32
		public uint MaxProgress; // m_nMaxProgress uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserAchievementStored_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserAchievementStored_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LeaderboardFindResult_t : ISteamCallback
	{
		public ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
		public byte LeaderboardFound; // m_bLeaderboardFound uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LeaderboardFindResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LeaderboardFindResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LeaderboardScoresDownloaded_t : ISteamCallback
	{
		public ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
		public ulong SteamLeaderboardEntries; // m_hSteamLeaderboardEntries SteamLeaderboardEntries_t
		public int CEntryCount; // m_cEntryCount int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LeaderboardScoresDownloaded_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LeaderboardScoresDownloaded_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LeaderboardScoreUploaded_t : ISteamCallback
	{
		public byte Success; // m_bSuccess uint8
		public ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
		public int Score; // m_nScore int32
		public byte ScoreChanged; // m_bScoreChanged uint8
		public int GlobalRankNew; // m_nGlobalRankNew int
		public int GlobalRankPrevious; // m_nGlobalRankPrevious int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LeaderboardScoreUploaded_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LeaderboardScoreUploaded_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct NumberOfCurrentPlayers_t : ISteamCallback
	{
		public byte Success; // m_bSuccess uint8
		public int CPlayers; // m_cPlayers int32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<NumberOfCurrentPlayers_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.NumberOfCurrentPlayers_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UserStatsUnloaded_t : ISteamCallback
	{
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserStatsUnloaded_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserStatsUnloaded_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UserAchievementIconFetched_t : ISteamCallback
	{
		public GameId GameID; // m_nGameID CGameID
		public fixed byte AchievementName[ 128 ]; // m_rgchAchievementName char [128]
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Achieved; // m_bAchieved bool
		public int IconHandle; // m_nIconHandle int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserAchievementIconFetched_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserAchievementIconFetched_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GlobalAchievementPercentagesReady_t : ISteamCallback
	{
		public ulong GameID; // m_nGameID uint64
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GlobalAchievementPercentagesReady_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GlobalAchievementPercentagesReady_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct LeaderboardUGCSet_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamLeaderboard; // m_hSteamLeaderboard SteamLeaderboard_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<LeaderboardUGCSet_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.LeaderboardUGCSet_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GlobalStatsReceived_t : ISteamCallback
	{
		public ulong GameID; // m_nGameID uint64
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GlobalStatsReceived_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GlobalStatsReceived_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct DlcInstalled_t : ISteamCallback
	{
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<DlcInstalled_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.DlcInstalled_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct NewUrlLaunchParameters_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<NewUrlLaunchParameters_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.NewUrlLaunchParameters_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AppProofOfPurchaseKeyResponse_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public uint AppID; // m_nAppID uint32
		public uint CchKeyLength; // m_cchKeyLength uint32
		public fixed byte Key[ 240 ]; // m_rgchKey char [240]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AppProofOfPurchaseKeyResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AppProofOfPurchaseKeyResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct FileDetailsResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong FileSize; // m_ulFileSize uint64
		public fixed byte FileSHA[ 20 ]; // m_FileSHA uint8 [20]
		public uint Flags; // m_unFlags uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<FileDetailsResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.FileDetailsResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct TimedTrialStatus_t : ISteamCallback
	{
		public uint AppID; // m_unAppID AppId_t
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool IsOffline; // m_bIsOffline bool
		public uint SecondsAllowed; // m_unSecondsAllowed uint32
		public uint SecondsPlayed; // m_unSecondsPlayed uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<TimedTrialStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.TimedTrialStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct P2PSessionRequest_t : ISteamCallback
	{
		public ulong SteamIDRemote; // m_steamIDRemote CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<P2PSessionRequest_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.P2PSessionRequest_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct P2PSessionConnectFail_t : ISteamCallback
	{
		public ulong SteamIDRemote; // m_steamIDRemote CSteamID
		public byte P2PSessionError; // m_eP2PSessionError uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<P2PSessionConnectFail_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.P2PSessionConnectFail_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ScreenshotReady_t : ISteamCallback
	{
		public uint Local; // m_hLocal ScreenshotHandle
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ScreenshotReady_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ScreenshotReady_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ScreenshotRequested_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ScreenshotRequested_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ScreenshotRequested_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct PlaybackStatusHasChanged_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<PlaybackStatusHasChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.PlaybackStatusHasChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct VolumeHasChanged_t : ISteamCallback
	{
		public float NewVolume; // m_flNewVolume float
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<VolumeHasChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.VolumeHasChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerRemoteWillActivate_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerRemoteWillActivate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerRemoteWillActivate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerRemoteWillDeactivate_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerRemoteWillDeactivate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerRemoteWillDeactivate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerRemoteToFront_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerRemoteToFront_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerRemoteToFront_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWillQuit_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWillQuit_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWillQuit_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsPlay_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsPlay_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsPlay_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsPause_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsPause_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsPause_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsPlayPrevious_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsPlayPrevious_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsPlayPrevious_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsPlayNext_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsPlayNext_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsPlayNext_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsShuffled_t : ISteamCallback
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Shuffled; // m_bShuffled bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsShuffled_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsShuffled_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsLooped_t : ISteamCallback
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Looped; // m_bLooped bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsLooped_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsLooped_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsVolume_t : ISteamCallback
	{
		public float NewVolume; // m_flNewVolume float
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsVolume_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsVolume_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerSelectsQueueEntry_t : ISteamCallback
	{
		public int NID; // nID int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerSelectsQueueEntry_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerSelectsQueueEntry_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerSelectsPlaylistEntry_t : ISteamCallback
	{
		public int NID; // nID int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerSelectsPlaylistEntry_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerSelectsPlaylistEntry_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct MusicPlayerWantsPlayingRepeatStatus_t : ISteamCallback
	{
		public int PlayingRepeatStatus; // m_nPlayingRepeatStatus int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<MusicPlayerWantsPlayingRepeatStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.MusicPlayerWantsPlayingRepeatStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTTPRequestCompleted_t : ISteamCallback
	{
		public uint Request; // m_hRequest HTTPRequestHandle
		public ulong ContextValue; // m_ulContextValue uint64
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool RequestSuccessful; // m_bRequestSuccessful bool
		public EHTTPStatusCode StatusCode; // m_eStatusCode EHTTPStatusCode
		public uint BodySize; // m_unBodySize uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTTPRequestCompleted_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTTPRequestCompleted_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTTPRequestHeadersReceived_t : ISteamCallback
	{
		public uint Request; // m_hRequest HTTPRequestHandle
		public ulong ContextValue; // m_ulContextValue uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTTPRequestHeadersReceived_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTTPRequestHeadersReceived_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTTPRequestDataReceived_t : ISteamCallback
	{
		public uint Request; // m_hRequest HTTPRequestHandle
		public ulong ContextValue; // m_ulContextValue uint64
		public uint COffset; // m_cOffset uint32
		public uint CBytesReceived; // m_cBytesReceived uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTTPRequestDataReceived_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTTPRequestDataReceived_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInputDeviceConnected_t : ISteamCallback
	{
		public ulong ConnectedDeviceHandle; // m_ulConnectedDeviceHandle InputHandle_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInputDeviceConnected_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInputDeviceConnected_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInputDeviceDisconnected_t : ISteamCallback
	{
		public ulong DisconnectedDeviceHandle; // m_ulDisconnectedDeviceHandle InputHandle_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInputDeviceDisconnected_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInputDeviceDisconnected_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct SteamInputConfigurationLoaded_t : ISteamCallback
	{
		public uint AppID; // m_unAppID AppId_t
		public ulong DeviceHandle; // m_ulDeviceHandle InputHandle_t
		public ulong MappingCreator; // m_ulMappingCreator CSteamID
		public uint MajorRevision; // m_unMajorRevision uint32
		public uint MinorRevision; // m_unMinorRevision uint32
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UsesSteamInputAPI; // m_bUsesSteamInputAPI bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UsesGamepadAPI; // m_bUsesGamepadAPI bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInputConfigurationLoaded_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInputConfigurationLoaded_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInputGamepadSlotChange_t : ISteamCallback
	{
		public uint AppID; // m_unAppID AppId_t
		public ulong DeviceHandle; // m_ulDeviceHandle InputHandle_t
		public ESteamInputType DeviceType; // m_eDeviceType ESteamInputType
		public int OldGamepadSlot; // m_nOldGamepadSlot int
		public int NewGamepadSlot; // m_nNewGamepadSlot int
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInputGamepadSlotChange_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInputGamepadSlotChange_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamUGCQueryCompleted_t : ISteamCallback
	{
		public ulong Handle; // m_handle UGCQueryHandle_t
		public EResult Result; // m_eResult EResult
		public uint NumResultsReturned; // m_unNumResultsReturned uint32
		public uint TotalMatchingResults; // m_unTotalMatchingResults uint32
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool CachedData; // m_bCachedData bool
		public fixed byte NextCursor[ 256 ]; // m_rgchNextCursor char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamUGCQueryCompleted_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamUGCQueryCompleted_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamUGCRequestUGCDetailsResult_t : ISteamCallback
	{
		public SteamUGCDetails_t Details; // m_details SteamUGCDetails_t
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool CachedData; // m_bCachedData bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamUGCRequestUGCDetailsResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamUGCRequestUGCDetailsResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct CreateItemResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<CreateItemResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.CreateItemResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SubmitItemUpdateResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SubmitItemUpdateResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SubmitItemUpdateResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct ItemInstalled_t : ISteamCallback
	{
		public uint AppID; // m_unAppID AppId_t
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public ulong LegacyContent; // m_hLegacyContent UGCHandle_t
		public ulong ManifestID; // m_unManifestID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ItemInstalled_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ItemInstalled_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct DownloadItemResult_t : ISteamCallback
	{
		public uint AppID; // m_unAppID AppId_t
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<DownloadItemResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.DownloadItemResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UserFavoriteItemsListChanged_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EResult Result; // m_eResult EResult
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool WasAddRequest; // m_bWasAddRequest bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserFavoriteItemsListChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserFavoriteItemsListChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SetUserItemVoteResult_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EResult Result; // m_eResult EResult
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool VoteUp; // m_bVoteUp bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SetUserItemVoteResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SetUserItemVoteResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GetUserItemVoteResult_t : ISteamCallback
	{
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public EResult Result; // m_eResult EResult
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool VotedUp; // m_bVotedUp bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool VotedDown; // m_bVotedDown bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool VoteSkipped; // m_bVoteSkipped bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GetUserItemVoteResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GetUserItemVoteResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct StartPlaytimeTrackingResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<StartPlaytimeTrackingResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.StartPlaytimeTrackingResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct StopPlaytimeTrackingResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<StopPlaytimeTrackingResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.StopPlaytimeTrackingResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AddUGCDependencyResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public ulong ChildPublishedFileId; // m_nChildPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AddUGCDependencyResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AddUGCDependencyResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoveUGCDependencyResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public ulong ChildPublishedFileId; // m_nChildPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoveUGCDependencyResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoveUGCDependencyResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AddAppDependencyResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AddAppDependencyResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AddAppDependencyResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct RemoveAppDependencyResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<RemoveAppDependencyResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.RemoveAppDependencyResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GetAppDependenciesResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public fixed uint GAppIDs[ 32 ]; // m_rgAppIDs AppId_t [32]
		public uint NumAppDependencies; // m_nNumAppDependencies uint32
		public uint TotalNumAppDependencies; // m_nTotalNumAppDependencies uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GetAppDependenciesResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GetAppDependenciesResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct DeleteItemResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<DeleteItemResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.DeleteItemResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct UserSubscribedItemsListChanged_t : ISteamCallback
	{
		public uint AppID; // m_nAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<UserSubscribedItemsListChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.UserSubscribedItemsListChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct WorkshopEULAStatus_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public uint AppID; // m_nAppID AppId_t
		public uint Version; // m_unVersion uint32
		public uint TAction; // m_rtAction RTime32
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Accepted; // m_bAccepted bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool NeedsAction; // m_bNeedsAction bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<WorkshopEULAStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.WorkshopEULAStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_BrowserReady_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_BrowserReady_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_BrowserReady_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_NeedsPaint_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PBGRA; // pBGRA const char *
		public uint UnWide; // unWide uint32
		public uint UnTall; // unTall uint32
		public uint UnUpdateX; // unUpdateX uint32
		public uint UnUpdateY; // unUpdateY uint32
		public uint UnUpdateWide; // unUpdateWide uint32
		public uint UnUpdateTall; // unUpdateTall uint32
		public uint UnScrollX; // unScrollX uint32
		public uint UnScrollY; // unScrollY uint32
		public float FlPageScale; // flPageScale float
		public uint UnPageSerial; // unPageSerial uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_NeedsPaint_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_NeedsPaint_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_StartRequest_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchURL; // pchURL const char *
		public IntPtr PchTarget; // pchTarget const char *
		public IntPtr PchPostData; // pchPostData const char *
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BIsRedirect; // bIsRedirect bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_StartRequest_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_StartRequest_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_CloseBrowser_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_CloseBrowser_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_CloseBrowser_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_URLChanged_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchURL; // pchURL const char *
		public IntPtr PchPostData; // pchPostData const char *
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BIsRedirect; // bIsRedirect bool
		public IntPtr PchPageTitle; // pchPageTitle const char *
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BNewNavigation; // bNewNavigation bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_URLChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_URLChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_FinishedRequest_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchURL; // pchURL const char *
		public IntPtr PchPageTitle; // pchPageTitle const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_FinishedRequest_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_FinishedRequest_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_OpenLinkInNewTab_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchURL; // pchURL const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_OpenLinkInNewTab_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_OpenLinkInNewTab_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_ChangedTitle_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchTitle; // pchTitle const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_ChangedTitle_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_ChangedTitle_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_SearchResults_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public uint UnResults; // unResults uint32
		public uint UnCurrentMatch; // unCurrentMatch uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_SearchResults_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_SearchResults_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_CanGoBackAndForward_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BCanGoBack; // bCanGoBack bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BCanGoForward; // bCanGoForward bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_CanGoBackAndForward_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_CanGoBackAndForward_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_HorizontalScroll_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public uint UnScrollMax; // unScrollMax uint32
		public uint UnScrollCurrent; // unScrollCurrent uint32
		public float FlPageScale; // flPageScale float
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BVisible; // bVisible bool
		public uint UnPageSize; // unPageSize uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_HorizontalScroll_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_HorizontalScroll_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_VerticalScroll_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public uint UnScrollMax; // unScrollMax uint32
		public uint UnScrollCurrent; // unScrollCurrent uint32
		public float FlPageScale; // flPageScale float
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BVisible; // bVisible bool
		public uint UnPageSize; // unPageSize uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_VerticalScroll_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_VerticalScroll_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_LinkAtPosition_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public uint X; // x uint32
		public uint Y; // y uint32
		public IntPtr PchURL; // pchURL const char *
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BInput; // bInput bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool BLiveLink; // bLiveLink bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_LinkAtPosition_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_LinkAtPosition_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_JSAlert_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchMessage; // pchMessage const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_JSAlert_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_JSAlert_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_JSConfirm_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchMessage; // pchMessage const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_JSConfirm_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_JSConfirm_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_FileOpenDialog_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchTitle; // pchTitle const char *
		public IntPtr PchInitialFile; // pchInitialFile const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_FileOpenDialog_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_FileOpenDialog_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_NewWindow_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchURL; // pchURL const char *
		public uint UnX; // unX uint32
		public uint UnY; // unY uint32
		public uint UnWide; // unWide uint32
		public uint UnTall; // unTall uint32
		public uint UnNewWindow_BrowserHandle_IGNORE; // unNewWindow_BrowserHandle_IGNORE HHTMLBrowser
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_NewWindow_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_NewWindow_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_SetCursor_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public uint EMouseCursor; // eMouseCursor uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_SetCursor_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_SetCursor_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_StatusText_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchMsg; // pchMsg const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_StatusText_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_StatusText_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_ShowToolTip_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchMsg; // pchMsg const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_ShowToolTip_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_ShowToolTip_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_UpdateToolTip_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public IntPtr PchMsg; // pchMsg const char *
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_UpdateToolTip_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_UpdateToolTip_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_HideToolTip_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_HideToolTip_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_HideToolTip_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct HTML_BrowserRestarted_t : ISteamCallback
	{
		public uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
		public uint UnOldBrowserHandle; // unOldBrowserHandle HHTMLBrowser
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<HTML_BrowserRestarted_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.HTML_BrowserRestarted_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInventoryResultReady_t : ISteamCallback
	{
		public int Handle; // m_handle SteamInventoryResult_t
		public EResult Result; // m_result EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInventoryResultReady_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInventoryResultReady_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInventoryFullUpdate_t : ISteamCallback
	{
		public int Handle; // m_handle SteamInventoryResult_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInventoryFullUpdate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInventoryFullUpdate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInventoryDefinitionUpdate_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInventoryDefinitionUpdate_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInventoryDefinitionUpdate_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct SteamInventoryEligiblePromoItemDefIDs_t : ISteamCallback
	{
		public EResult Result; // m_result EResult
		public ulong SteamID; // m_steamID CSteamID
		public int UmEligiblePromoItemDefs; // m_numEligiblePromoItemDefs int
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool CachedData; // m_bCachedData bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInventoryEligiblePromoItemDefIDs_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInventoryEligiblePromoItemDefIDs_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInventoryStartPurchaseResult_t : ISteamCallback
	{
		public EResult Result; // m_result EResult
		public ulong OrderID; // m_ulOrderID uint64
		public ulong TransID; // m_ulTransID uint64
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInventoryStartPurchaseResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInventoryStartPurchaseResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamInventoryRequestPricesResult_t : ISteamCallback
	{
		public EResult Result; // m_result EResult
		public fixed byte Currency[ 4 ]; // m_rgchCurrency char [4]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamInventoryRequestPricesResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamInventoryRequestPricesResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamTimelineGamePhaseRecordingExists_t : ISteamCallback
	{
		public fixed byte PhaseID[ 64 ]; // m_rgchPhaseID char [64]
		public ulong RecordingMS; // m_ulRecordingMS uint64
		public ulong LongestClipMS; // m_ulLongestClipMS uint64
		public uint ClipCount; // m_unClipCount uint32
		public uint ScreenshotCount; // m_unScreenshotCount uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamTimelineGamePhaseRecordingExists_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamTimelineGamePhaseRecordingExists_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamTimelineEventRecordingExists_t : ISteamCallback
	{
		public ulong EventID; // m_ulEventID uint64
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool RecordingExists; // m_bRecordingExists bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamTimelineEventRecordingExists_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamTimelineEventRecordingExists_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GetVideoURLResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public uint VideoAppID; // m_unVideoAppID AppId_t
		public fixed byte URL[ 256 ]; // m_rgchURL char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GetVideoURLResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GetVideoURLResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GetOPFSettingsResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public uint VideoAppID; // m_unVideoAppID AppId_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GetOPFSettingsResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GetOPFSettingsResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct BroadcastUploadStart_t : ISteamCallback
	{
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool IsRTMP; // m_bIsRTMP bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<BroadcastUploadStart_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.BroadcastUploadStart_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct BroadcastUploadStop_t : ISteamCallback
	{
		public EBroadcastUploadResult Result; // m_eResult EBroadcastUploadResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<BroadcastUploadStop_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.BroadcastUploadStop_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamParentalSettingsChanged_t : ISteamCallback
	{
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamParentalSettingsChanged_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamParentalSettingsChanged_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamRemotePlaySessionConnected_t : ISteamCallback
	{
		public uint SessionID; // m_unSessionID RemotePlaySessionID_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamRemotePlaySessionConnected_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamRemotePlaySessionConnected_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamRemotePlaySessionDisconnected_t : ISteamCallback
	{
		public uint SessionID; // m_unSessionID RemotePlaySessionID_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamRemotePlaySessionDisconnected_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamRemotePlaySessionDisconnected_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamRemotePlayTogetherGuestInvite_t : ISteamCallback
	{
		public fixed byte ConnectURL[ 1024 ]; // m_szConnectURL char [1024]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamRemotePlayTogetherGuestInvite_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamRemotePlayTogetherGuestInvite_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamNetworkingMessagesSessionRequest_t : ISteamCallback
	{
		public SteamNetworkingIdentity DentityRemote; // m_identityRemote SteamNetworkingIdentity
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamNetworkingMessagesSessionRequest_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamNetworkingMessagesSessionRequest_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamNetworkingMessagesSessionFailed_t : ISteamCallback
	{
		public SteamNetConnectionInfo_t Nfo; // m_info SteamNetConnectionInfo_t
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamNetworkingMessagesSessionFailed_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamNetworkingMessagesSessionFailed_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamNetConnectionStatusChangedCallback_t : ISteamCallback
	{
		public uint Conn; // m_hConn HSteamNetConnection
		public SteamNetConnectionInfo_t Nfo; // m_info SteamNetConnectionInfo_t
		public ESteamNetworkingConnectionState OldState; // m_eOldState ESteamNetworkingConnectionState
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamNetConnectionStatusChangedCallback_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamNetConnectionStatusChangedCallback_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamNetAuthenticationStatus_t : ISteamCallback
	{
		public ESteamNetworkingAvailability Avail; // m_eAvail ESteamNetworkingAvailability
		public fixed byte DebugMsg[ 256 ]; // m_debugMsg char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamNetAuthenticationStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamNetAuthenticationStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamRelayNetworkStatus_t : ISteamCallback
	{
		public ESteamNetworkingAvailability Avail; // m_eAvail ESteamNetworkingAvailability
		public int PingMeasurementInProgress; // m_bPingMeasurementInProgress int
		public ESteamNetworkingAvailability AvailNetworkConfig; // m_eAvailNetworkConfig ESteamNetworkingAvailability
		public ESteamNetworkingAvailability AvailAnyRelay; // m_eAvailAnyRelay ESteamNetworkingAvailability
		public fixed byte DebugMsg[ 256 ]; // m_debugMsg char [256]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamRelayNetworkStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamRelayNetworkStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GSClientApprove_t : ISteamCallback
	{
		public ulong SteamID; // m_SteamID CSteamID
		public ulong OwnerSteamID; // m_OwnerSteamID CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSClientApprove_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSClientApprove_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSClientDeny_t : ISteamCallback
	{
		public ulong SteamID; // m_SteamID CSteamID
		public EDenyReason DenyReason; // m_eDenyReason EDenyReason
		public fixed byte OptionalText[ 128 ]; // m_rgchOptionalText char [128]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSClientDeny_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSClientDeny_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSClientKick_t : ISteamCallback
	{
		public ulong SteamID; // m_SteamID CSteamID
		public EDenyReason DenyReason; // m_eDenyReason EDenyReason
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSClientKick_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSClientKick_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSClientAchievementStatus_t : ISteamCallback
	{
		public ulong SteamID; // m_SteamID uint64
		public fixed byte PchAchievement[ 128 ]; // m_pchAchievement char [128]
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Unlocked; // m_bUnlocked bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSClientAchievementStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSClientAchievementStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSPolicyResponse_t : ISteamCallback
	{
		public byte Secure; // m_bSecure uint8
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSPolicyResponse_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSPolicyResponse_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSGameplayStats_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public int Rank; // m_nRank int32
		public uint TotalConnects; // m_unTotalConnects uint32
		public uint TotalMinutesPlayed; // m_unTotalMinutesPlayed uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSGameplayStats_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSGameplayStats_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GSClientGroupStatus_t : ISteamCallback
	{
		public ulong SteamIDUser; // m_SteamIDUser CSteamID
		public ulong SteamIDGroup; // m_SteamIDGroup CSteamID
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Member; // m_bMember bool
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Officer; // m_bOfficer bool
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSClientGroupStatus_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSClientGroupStatus_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSReputation_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public uint ReputationScore; // m_unReputationScore uint32
		[ MarshalAs( UnmanagedType.I1 ) ]
		public bool Banned; // m_bBanned bool
		public uint BannedIP; // m_unBannedIP uint32
		public ushort BannedPort; // m_usBannedPort uint16
		public ulong BannedGameID; // m_ulBannedGameID uint64
		public uint BanExpires; // m_unBanExpires uint32
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSReputation_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSReputation_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct AssociateWithClanResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<AssociateWithClanResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.AssociateWithClanResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct ComputeNewPlayerCompatibilityResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public int CPlayersThatDontLikeCandidate; // m_cPlayersThatDontLikeCandidate int
		public int CPlayersThatCandidateDoesntLike; // m_cPlayersThatCandidateDoesntLike int
		public int CClanPlayersThatDontLikeCandidate; // m_cClanPlayersThatDontLikeCandidate int
		public ulong SteamIDCandidate; // m_SteamIDCandidate CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<ComputeNewPlayerCompatibilityResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.ComputeNewPlayerCompatibilityResult_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GSStatsReceived_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSStatsReceived_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSStatsReceived_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize ) ]
	public unsafe struct GSStatsStored_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSStatsStored_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSStatsStored_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct GSStatsUnloaded_t : ISteamCallback
	{
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<GSStatsUnloaded_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.GSStatsUnloaded_t;
		#endregion
	}
	
	[ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
	public unsafe struct SteamNetworkingFakeIPResult_t : ISteamCallback
	{
		public EResult Result; // m_eResult EResult
		public SteamNetworkingIdentity Dentity; // m_identity SteamNetworkingIdentity
		public uint IP; // m_unIP uint32
		public fixed ushort Ports[ 8 ]; // m_unPorts uint16 [8]
		
		#region SteamCallback
		public static int _datasize = UnsafeUtility.SizeOf<SteamNetworkingFakeIPResult_t>();
		public int DataSize => _datasize;
		public CallbackType CallbackType => CallbackType.SteamNetworkingFakeIPResult_t;
		#endregion
	}
	
}
