using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamGameServer
	{
		public const string Version = "SteamGameServer015";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServer_v015", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServer_v015();
		/// Construct use accessor to find interface
		public ISteamGameServer( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServer_v015();
			}
		}
		public ISteamGameServer( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamGameServer_SetProduct
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetProduct", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetProduct( IntPtr self, IntPtr pszProduct );
		#endregion
		internal void SetProduct( string pszProduct )
		{
			using var str__pszProduct = new Utf8StringToNative( pszProduct );
			_SteamAPI_ISteamGameServer_SetProduct( Self, str__pszProduct.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetGameDescription
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetGameDescription", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetGameDescription( IntPtr self, IntPtr pszGameDescription );
		#endregion
		internal void SetGameDescription( string pszGameDescription )
		{
			using var str__pszGameDescription = new Utf8StringToNative( pszGameDescription );
			_SteamAPI_ISteamGameServer_SetGameDescription( Self, str__pszGameDescription.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetModDir
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetModDir", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetModDir( IntPtr self, IntPtr pszModDir );
		#endregion
		internal void SetModDir( string pszModDir )
		{
			using var str__pszModDir = new Utf8StringToNative( pszModDir );
			_SteamAPI_ISteamGameServer_SetModDir( Self, str__pszModDir.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetDedicatedServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetDedicatedServer", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetDedicatedServer( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bDedicated );
		#endregion
		internal void SetDedicatedServer( [ MarshalAs( UnmanagedType.U1 ) ] bool bDedicated )
		{
			_SteamAPI_ISteamGameServer_SetDedicatedServer( Self, bDedicated );
		}
		
		#region SteamAPI_ISteamGameServer_LogOn
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_LogOn", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_LogOn( IntPtr self, IntPtr pszToken );
		#endregion
		internal void LogOn( string pszToken )
		{
			using var str__pszToken = new Utf8StringToNative( pszToken );
			_SteamAPI_ISteamGameServer_LogOn( Self, str__pszToken.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_LogOnAnonymous
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_LogOnAnonymous", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_LogOnAnonymous( IntPtr self );
		#endregion
		internal void LogOnAnonymous()
		{
			_SteamAPI_ISteamGameServer_LogOnAnonymous( Self );
		}
		
		#region SteamAPI_ISteamGameServer_LogOff
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_LogOff", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_LogOff( IntPtr self );
		#endregion
		internal void LogOff()
		{
			_SteamAPI_ISteamGameServer_LogOff( Self );
		}
		
		#region SteamAPI_ISteamGameServer_BLoggedOn
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BLoggedOn", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_BLoggedOn( IntPtr self );
		#endregion
		internal bool BLoggedOn()
		{
			var returnValue = _SteamAPI_ISteamGameServer_BLoggedOn( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_BSecure
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BSecure", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_BSecure( IntPtr self );
		#endregion
		internal bool BSecure()
		{
			var returnValue = _SteamAPI_ISteamGameServer_BSecure( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetSteamID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetSteamID", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamGameServer_GetSteamID( IntPtr self );
		#endregion
		internal SteamId GetSteamID()
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetSteamID( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_WasRestartRequested
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_WasRestartRequested", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_WasRestartRequested( IntPtr self );
		#endregion
		internal bool WasRestartRequested()
		{
			var returnValue = _SteamAPI_ISteamGameServer_WasRestartRequested( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_SetMaxPlayerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetMaxPlayerCount", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetMaxPlayerCount( IntPtr self, int cPlayersMax );
		#endregion
		internal void SetMaxPlayerCount( int cPlayersMax )
		{
			_SteamAPI_ISteamGameServer_SetMaxPlayerCount( Self, cPlayersMax );
		}
		
		#region SteamAPI_ISteamGameServer_SetBotPlayerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetBotPlayerCount", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetBotPlayerCount( IntPtr self, int cBotplayers );
		#endregion
		internal void SetBotPlayerCount( int cBotplayers )
		{
			_SteamAPI_ISteamGameServer_SetBotPlayerCount( Self, cBotplayers );
		}
		
		#region SteamAPI_ISteamGameServer_SetServerName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetServerName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetServerName( IntPtr self, IntPtr pszServerName );
		#endregion
		internal void SetServerName( string pszServerName )
		{
			using var str__pszServerName = new Utf8StringToNative( pszServerName );
			_SteamAPI_ISteamGameServer_SetServerName( Self, str__pszServerName.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetMapName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetMapName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetMapName( IntPtr self, IntPtr pszMapName );
		#endregion
		internal void SetMapName( string pszMapName )
		{
			using var str__pszMapName = new Utf8StringToNative( pszMapName );
			_SteamAPI_ISteamGameServer_SetMapName( Self, str__pszMapName.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetPasswordProtected
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetPasswordProtected", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetPasswordProtected( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bPasswordProtected );
		#endregion
		internal void SetPasswordProtected( [ MarshalAs( UnmanagedType.U1 ) ] bool bPasswordProtected )
		{
			_SteamAPI_ISteamGameServer_SetPasswordProtected( Self, bPasswordProtected );
		}
		
		#region SteamAPI_ISteamGameServer_SetSpectatorPort
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorPort", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetSpectatorPort( IntPtr self, ushort unSpectatorPort );
		#endregion
		internal void SetSpectatorPort( ushort unSpectatorPort )
		{
			_SteamAPI_ISteamGameServer_SetSpectatorPort( Self, unSpectatorPort );
		}
		
		#region SteamAPI_ISteamGameServer_SetSpectatorServerName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorServerName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetSpectatorServerName( IntPtr self, IntPtr pszSpectatorServerName );
		#endregion
		internal void SetSpectatorServerName( string pszSpectatorServerName )
		{
			using var str__pszSpectatorServerName = new Utf8StringToNative( pszSpectatorServerName );
			_SteamAPI_ISteamGameServer_SetSpectatorServerName( Self, str__pszSpectatorServerName.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_ClearAllKeyValues
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_ClearAllKeyValues", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_ClearAllKeyValues( IntPtr self );
		#endregion
		internal void ClearAllKeyValues()
		{
			_SteamAPI_ISteamGameServer_ClearAllKeyValues( Self );
		}
		
		#region SteamAPI_ISteamGameServer_SetKeyValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetKeyValue", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetKeyValue( IntPtr self, IntPtr pKey, IntPtr pValue );
		#endregion
		internal void SetKeyValue( string pKey, string pValue )
		{
			using var str__pKey = new Utf8StringToNative( pKey );
			using var str__pValue = new Utf8StringToNative( pValue );
			_SteamAPI_ISteamGameServer_SetKeyValue( Self, str__pKey.Pointer, str__pValue.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetGameTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetGameTags", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetGameTags( IntPtr self, IntPtr pchGameTags );
		#endregion
		internal void SetGameTags( string pchGameTags )
		{
			using var str__pchGameTags = new Utf8StringToNative( pchGameTags );
			_SteamAPI_ISteamGameServer_SetGameTags( Self, str__pchGameTags.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetGameData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetGameData", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetGameData( IntPtr self, IntPtr pchGameData );
		#endregion
		internal void SetGameData( string pchGameData )
		{
			using var str__pchGameData = new Utf8StringToNative( pchGameData );
			_SteamAPI_ISteamGameServer_SetGameData( Self, str__pchGameData.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetRegion
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetRegion", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetRegion( IntPtr self, IntPtr pszRegion );
		#endregion
		internal void SetRegion( string pszRegion )
		{
			using var str__pszRegion = new Utf8StringToNative( pszRegion );
			_SteamAPI_ISteamGameServer_SetRegion( Self, str__pszRegion.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetAdvertiseServerActive
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetAdvertiseServerActive", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetAdvertiseServerActive( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bActive );
		#endregion
		internal void SetAdvertiseServerActive( [ MarshalAs( UnmanagedType.U1 ) ] bool bActive )
		{
			_SteamAPI_ISteamGameServer_SetAdvertiseServerActive( Self, bActive );
		}
		
		#region SteamAPI_ISteamGameServer_GetAuthSessionTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetAuthSessionTicket", CallingConvention = Platform.CC ) ]
		internal static extern HAuthTicket _SteamAPI_ISteamGameServer_GetAuthSessionTicket( IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSnid );
		#endregion
		internal HAuthTicket GetAuthSessionTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSnid )
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetAuthSessionTicket( Self, pTicket, cbMaxTicket, ref pcbTicket, ref pSnid );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_BeginAuthSession
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BeginAuthSession", CallingConvention = Platform.CC ) ]
		internal static extern EBeginAuthSessionResult _SteamAPI_ISteamGameServer_BeginAuthSession( IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID );
		#endregion
		internal EBeginAuthSessionResult BeginAuthSession( IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamGameServer_BeginAuthSession( Self, pAuthTicket, cbAuthTicket, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_EndAuthSession
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_EndAuthSession", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_EndAuthSession( IntPtr self, SteamId steamID );
		#endregion
		internal void EndAuthSession( SteamId steamID )
		{
			_SteamAPI_ISteamGameServer_EndAuthSession( Self, steamID );
		}
		
		#region SteamAPI_ISteamGameServer_CancelAuthTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_CancelAuthTicket", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_CancelAuthTicket( IntPtr self, HAuthTicket hAuthTicket );
		#endregion
		internal void CancelAuthTicket( HAuthTicket hAuthTicket )
		{
			_SteamAPI_ISteamGameServer_CancelAuthTicket( Self, hAuthTicket );
		}
		
		#region SteamAPI_ISteamGameServer_UserHasLicenseForApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_UserHasLicenseForApp", CallingConvention = Platform.CC ) ]
		internal static extern EUserHasLicenseForAppResult _SteamAPI_ISteamGameServer_UserHasLicenseForApp( IntPtr self, SteamId steamID, AppId_t appID );
		#endregion
		internal EUserHasLicenseForAppResult UserHasLicenseForApp( SteamId steamID, AppId_t appID )
		{
			var returnValue = _SteamAPI_ISteamGameServer_UserHasLicenseForApp( Self, steamID, appID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_RequestUserGroupStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_RequestUserGroupStatus", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_RequestUserGroupStatus( IntPtr self, SteamId steamIDUser, SteamId steamIDGroup );
		#endregion
		internal bool RequestUserGroupStatus( SteamId steamIDUser, SteamId steamIDGroup )
		{
			var returnValue = _SteamAPI_ISteamGameServer_RequestUserGroupStatus( Self, steamIDUser, steamIDGroup );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetGameplayStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetGameplayStats", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_GetGameplayStats( IntPtr self );
		#endregion
		internal void GetGameplayStats()
		{
			_SteamAPI_ISteamGameServer_GetGameplayStats( Self );
		}
		
		#region SteamAPI_ISteamGameServer_GetServerReputation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetServerReputation", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamGameServer_GetServerReputation( IntPtr self );
		#endregion
		internal SteamAPICall_t GetServerReputation()
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetServerReputation( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetPublicIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetPublicIP", CallingConvention = Platform.CC ) ]
		internal static extern SteamIPAddress_t _SteamAPI_ISteamGameServer_GetPublicIP( IntPtr self );
		#endregion
		internal SteamIPAddress_t GetPublicIP()
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetPublicIP( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_HandleIncomingPacket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_HandleIncomingPacket", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_HandleIncomingPacket( IntPtr self, IntPtr pData, int cbData, uint srcIP, ushort srcPort );
		#endregion
		internal bool HandleIncomingPacket( IntPtr pData, int cbData, uint srcIP, ushort srcPort )
		{
			var returnValue = _SteamAPI_ISteamGameServer_HandleIncomingPacket( Self, pData, cbData, srcIP, srcPort );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetNextOutgoingPacket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetNextOutgoingPacket", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamGameServer_GetNextOutgoingPacket( IntPtr self, IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort );
		#endregion
		internal int GetNextOutgoingPacket( IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort )
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetNextOutgoingPacket( Self, pOut, cbMaxOut, ref pNetAdr, ref pPort );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_AssociateWithClan
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_AssociateWithClan", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamGameServer_AssociateWithClan( IntPtr self, SteamId steamIDClan );
		#endregion
		internal SteamAPICall_t AssociateWithClan( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamGameServer_AssociateWithClan( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility( IntPtr self, SteamId steamIDNewPlayer );
		#endregion
		internal SteamAPICall_t ComputeNewPlayerCompatibility( SteamId steamIDNewPlayer )
		{
			var returnValue = _SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility( Self, steamIDNewPlayer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED( IntPtr self, uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser );
		#endregion
		internal bool SendUserConnectAndAuthenticate_DEPRECATED( uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser )
		{
			var returnValue = _SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED( Self, unIPClient, pvAuthBlob, cubAuthBlobSize, ref pSteamIDUser );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection( IntPtr self );
		#endregion
		internal SteamId CreateUnauthenticatedUserConnection()
		{
			var returnValue = _SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED( IntPtr self, SteamId steamIDUser );
		#endregion
		internal void SendUserDisconnect_DEPRECATED( SteamId steamIDUser )
		{
			_SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED( Self, steamIDUser );
		}
		
		#region SteamAPI_ISteamGameServer_BUpdateUserData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BUpdateUserData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_BUpdateUserData( IntPtr self, SteamId steamIDUser, IntPtr pchPlayerName, uint uScore );
		#endregion
		internal bool BUpdateUserData( SteamId steamIDUser, string pchPlayerName, uint uScore )
		{
			using var str__pchPlayerName = new Utf8StringToNative( pchPlayerName );
			var returnValue = _SteamAPI_ISteamGameServer_BUpdateUserData( Self, steamIDUser, str__pchPlayerName.Pointer, uScore );
			return returnValue;
		}
		
	}
}
