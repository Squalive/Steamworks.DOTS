using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamUser
	{
		public const string Version = "SteamUser023";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamUser_v023", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamUser_v023();
		/// Construct use accessor to find interface
		public ISteamUser( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamUser_v023();
			}
		}
		public ISteamUser( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamUser_GetHSteamUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser", CallingConvention = Platform.CC ) ]
		internal static extern HSteamUser _SteamAPI_ISteamUser_GetHSteamUser( IntPtr self );
		#endregion
		internal HSteamUser GetHSteamUser()
		{
			var returnValue = _SteamAPI_ISteamUser_GetHSteamUser( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BLoggedOn
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BLoggedOn", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BLoggedOn( IntPtr self );
		#endregion
		internal bool BLoggedOn()
		{
			var returnValue = _SteamAPI_ISteamUser_BLoggedOn( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetSteamID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetSteamID", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamUser_GetSteamID( IntPtr self );
		#endregion
		internal SteamId GetSteamID()
		{
			var returnValue = _SteamAPI_ISteamUser_GetSteamID( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_InitiateGameConnection_DEPRECATED
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection_DEPRECATED", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUser_InitiateGameConnection_DEPRECATED( IntPtr self, IntPtr pAuthBlob, int cbMaxAuthBlob, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer, [ MarshalAs( UnmanagedType.U1 ) ] bool bSecure );
		#endregion
		internal int InitiateGameConnection_DEPRECATED( IntPtr pAuthBlob, int cbMaxAuthBlob, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer, [ MarshalAs( UnmanagedType.U1 ) ] bool bSecure )
		{
			var returnValue = _SteamAPI_ISteamUser_InitiateGameConnection_DEPRECATED( Self, pAuthBlob, cbMaxAuthBlob, steamIDGameServer, unIPServer, usPortServer, bSecure );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_TerminateGameConnection_DEPRECATED
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection_DEPRECATED", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_TerminateGameConnection_DEPRECATED( IntPtr self, uint unIPServer, ushort usPortServer );
		#endregion
		internal void TerminateGameConnection_DEPRECATED( uint unIPServer, ushort usPortServer )
		{
			_SteamAPI_ISteamUser_TerminateGameConnection_DEPRECATED( Self, unIPServer, usPortServer );
		}
		
		#region SteamAPI_ISteamUser_TrackAppUsageEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_TrackAppUsageEvent( IntPtr self, GameId gameID, int eAppUsageEvent, IntPtr pchExtraInfo );
		#endregion
		internal void TrackAppUsageEvent( GameId gameID, int eAppUsageEvent, string pchExtraInfo )
		{
			using var str__pchExtraInfo = new Utf8StringToNative( pchExtraInfo );
			_SteamAPI_ISteamUser_TrackAppUsageEvent( Self, gameID, eAppUsageEvent, str__pchExtraInfo.Pointer );
		}
		
		#region SteamAPI_ISteamUser_GetUserDataFolder
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_GetUserDataFolder( IntPtr self, IntPtr pchBuffer, int cubBuffer );
		#endregion
		internal bool GetUserDataFolder( out string pchBuffer, int cubBuffer )
		{
			using var mem__pchBuffer = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUser_GetUserDataFolder( Self, mem__pchBuffer.Ptr, cubBuffer );
			pchBuffer = Utility.MemoryToString( mem__pchBuffer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_StartVoiceRecording
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_StartVoiceRecording( IntPtr self );
		#endregion
		internal void StartVoiceRecording()
		{
			_SteamAPI_ISteamUser_StartVoiceRecording( Self );
		}
		
		#region SteamAPI_ISteamUser_StopVoiceRecording
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_StopVoiceRecording( IntPtr self );
		#endregion
		internal void StopVoiceRecording()
		{
			_SteamAPI_ISteamUser_StopVoiceRecording( Self );
		}
		
		#region SteamAPI_ISteamUser_GetAvailableVoice
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice", CallingConvention = Platform.CC ) ]
		internal static extern EVoiceResult _SteamAPI_ISteamUser_GetAvailableVoice( IntPtr self, ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated );
		#endregion
		internal EVoiceResult GetAvailableVoice( ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated )
		{
			var returnValue = _SteamAPI_ISteamUser_GetAvailableVoice( Self, ref pcbCompressed, ref pcbUncompressed_Deprecated, nUncompressedVoiceDesiredSampleRate_Deprecated );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetVoice
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetVoice", CallingConvention = Platform.CC ) ]
		internal static extern EVoiceResult _SteamAPI_ISteamUser_GetVoice( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, [ MarshalAs( UnmanagedType.U1 ) ] bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated );
		#endregion
		internal EVoiceResult GetVoice( [ MarshalAs( UnmanagedType.U1 ) ] bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, [ MarshalAs( UnmanagedType.U1 ) ] bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated )
		{
			var returnValue = _SteamAPI_ISteamUser_GetVoice( Self, bWantCompressed, pDestBuffer, cbDestBufferSize, ref nBytesWritten, bWantUncompressed_Deprecated, pUncompressedDestBuffer_Deprecated, cbUncompressedDestBufferSize_Deprecated, ref nUncompressBytesWritten_Deprecated, nUncompressedVoiceDesiredSampleRate_Deprecated );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_DecompressVoice
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_DecompressVoice", CallingConvention = Platform.CC ) ]
		internal static extern EVoiceResult _SteamAPI_ISteamUser_DecompressVoice( IntPtr self, IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate );
		#endregion
		internal EVoiceResult DecompressVoice( IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate )
		{
			var returnValue = _SteamAPI_ISteamUser_DecompressVoice( Self, pCompressed, cbCompressed, pDestBuffer, cbDestBufferSize, ref nBytesWritten, nDesiredSampleRate );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetVoiceOptimalSampleRate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUser_GetVoiceOptimalSampleRate( IntPtr self );
		#endregion
		internal uint GetVoiceOptimalSampleRate()
		{
			var returnValue = _SteamAPI_ISteamUser_GetVoiceOptimalSampleRate( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetAuthSessionTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket", CallingConvention = Platform.CC ) ]
		internal static extern HAuthTicket _SteamAPI_ISteamUser_GetAuthSessionTicket( IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSteamNetworkingIdentity );
		#endregion
		internal HAuthTicket GetAuthSessionTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSteamNetworkingIdentity )
		{
			var returnValue = _SteamAPI_ISteamUser_GetAuthSessionTicket( Self, pTicket, cbMaxTicket, ref pcbTicket, ref pSteamNetworkingIdentity );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetAuthTicketForWebApi
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetAuthTicketForWebApi", CallingConvention = Platform.CC ) ]
		internal static extern HAuthTicket _SteamAPI_ISteamUser_GetAuthTicketForWebApi( IntPtr self, IntPtr pchIdentity );
		#endregion
		internal HAuthTicket GetAuthTicketForWebApi( string pchIdentity )
		{
			using var str__pchIdentity = new Utf8StringToNative( pchIdentity );
			var returnValue = _SteamAPI_ISteamUser_GetAuthTicketForWebApi( Self, str__pchIdentity.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BeginAuthSession
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession", CallingConvention = Platform.CC ) ]
		internal static extern EBeginAuthSessionResult _SteamAPI_ISteamUser_BeginAuthSession( IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID );
		#endregion
		internal EBeginAuthSessionResult BeginAuthSession( IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamUser_BeginAuthSession( Self, pAuthTicket, cbAuthTicket, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_EndAuthSession
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_EndAuthSession", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_EndAuthSession( IntPtr self, SteamId steamID );
		#endregion
		internal void EndAuthSession( SteamId steamID )
		{
			_SteamAPI_ISteamUser_EndAuthSession( Self, steamID );
		}
		
		#region SteamAPI_ISteamUser_CancelAuthTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_CancelAuthTicket( IntPtr self, HAuthTicket hAuthTicket );
		#endregion
		internal void CancelAuthTicket( HAuthTicket hAuthTicket )
		{
			_SteamAPI_ISteamUser_CancelAuthTicket( Self, hAuthTicket );
		}
		
		#region SteamAPI_ISteamUser_UserHasLicenseForApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp", CallingConvention = Platform.CC ) ]
		internal static extern EUserHasLicenseForAppResult _SteamAPI_ISteamUser_UserHasLicenseForApp( IntPtr self, SteamId steamID, AppId_t appID );
		#endregion
		internal EUserHasLicenseForAppResult UserHasLicenseForApp( SteamId steamID, AppId_t appID )
		{
			var returnValue = _SteamAPI_ISteamUser_UserHasLicenseForApp( Self, steamID, appID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BIsBehindNAT
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BIsBehindNAT( IntPtr self );
		#endregion
		internal bool BIsBehindNAT()
		{
			var returnValue = _SteamAPI_ISteamUser_BIsBehindNAT( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_AdvertiseGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUser_AdvertiseGame( IntPtr self, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer );
		#endregion
		internal void AdvertiseGame( SteamId steamIDGameServer, uint unIPServer, ushort usPortServer )
		{
			_SteamAPI_ISteamUser_AdvertiseGame( Self, steamIDGameServer, unIPServer, usPortServer );
		}
		
		#region SteamAPI_ISteamUser_RequestEncryptedAppTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUser_RequestEncryptedAppTicket( IntPtr self, IntPtr pDataToInclude, int cbDataToInclude );
		#endregion
		internal SteamAPICall_t RequestEncryptedAppTicket( IntPtr pDataToInclude, int cbDataToInclude )
		{
			var returnValue = _SteamAPI_ISteamUser_RequestEncryptedAppTicket( Self, pDataToInclude, cbDataToInclude );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetEncryptedAppTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_GetEncryptedAppTicket( IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket );
		#endregion
		internal bool GetEncryptedAppTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket )
		{
			var returnValue = _SteamAPI_ISteamUser_GetEncryptedAppTicket( Self, pTicket, cbMaxTicket, ref pcbTicket );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetGameBadgeLevel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUser_GetGameBadgeLevel( IntPtr self, int nSeries, [ MarshalAs( UnmanagedType.U1 ) ] bool bFoil );
		#endregion
		internal int GetGameBadgeLevel( int nSeries, [ MarshalAs( UnmanagedType.U1 ) ] bool bFoil )
		{
			var returnValue = _SteamAPI_ISteamUser_GetGameBadgeLevel( Self, nSeries, bFoil );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetPlayerSteamLevel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUser_GetPlayerSteamLevel( IntPtr self );
		#endregion
		internal int GetPlayerSteamLevel()
		{
			var returnValue = _SteamAPI_ISteamUser_GetPlayerSteamLevel( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_RequestStoreAuthURL
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUser_RequestStoreAuthURL( IntPtr self, IntPtr pchRedirectURL );
		#endregion
		internal SteamAPICall_t RequestStoreAuthURL( string pchRedirectURL )
		{
			using var str__pchRedirectURL = new Utf8StringToNative( pchRedirectURL );
			var returnValue = _SteamAPI_ISteamUser_RequestStoreAuthURL( Self, str__pchRedirectURL.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BIsPhoneVerified
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneVerified", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BIsPhoneVerified( IntPtr self );
		#endregion
		internal bool BIsPhoneVerified()
		{
			var returnValue = _SteamAPI_ISteamUser_BIsPhoneVerified( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BIsTwoFactorEnabled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsTwoFactorEnabled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BIsTwoFactorEnabled( IntPtr self );
		#endregion
		internal bool BIsTwoFactorEnabled()
		{
			var returnValue = _SteamAPI_ISteamUser_BIsTwoFactorEnabled( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BIsPhoneIdentifying
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneIdentifying", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BIsPhoneIdentifying( IntPtr self );
		#endregion
		internal bool BIsPhoneIdentifying()
		{
			var returnValue = _SteamAPI_ISteamUser_BIsPhoneIdentifying( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BIsPhoneRequiringVerification
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneRequiringVerification", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BIsPhoneRequiringVerification( IntPtr self );
		#endregion
		internal bool BIsPhoneRequiringVerification()
		{
			var returnValue = _SteamAPI_ISteamUser_BIsPhoneRequiringVerification( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetMarketEligibility
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetMarketEligibility", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUser_GetMarketEligibility( IntPtr self );
		#endregion
		internal SteamAPICall_t GetMarketEligibility()
		{
			var returnValue = _SteamAPI_ISteamUser_GetMarketEligibility( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_GetDurationControl
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetDurationControl", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUser_GetDurationControl( IntPtr self );
		#endregion
		internal SteamAPICall_t GetDurationControl()
		{
			var returnValue = _SteamAPI_ISteamUser_GetDurationControl( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUser_BSetDurationControlOnlineState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BSetDurationControlOnlineState", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUser_BSetDurationControlOnlineState( IntPtr self, EDurationControlOnlineState eNewState );
		#endregion
		internal bool BSetDurationControlOnlineState( EDurationControlOnlineState eNewState )
		{
			var returnValue = _SteamAPI_ISteamUser_BSetDurationControlOnlineState( Self, eNewState );
			return returnValue;
		}
		
	}
}
