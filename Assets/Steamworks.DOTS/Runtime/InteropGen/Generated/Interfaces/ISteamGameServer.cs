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
		internal void _SetProduct( IntPtr pszProduct ) => _SteamAPI_ISteamGameServer_SetProduct( Self, pszProduct );
		#endregion
		internal void SetProduct( string pszProduct )
		{
			using var str__pszProduct = new Utf8StringToNative( pszProduct );
			_SteamAPI_ISteamGameServer_SetProduct( Self, str__pszProduct.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetGameDescription
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetGameDescription", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetGameDescription( IntPtr self, IntPtr pszGameDescription );
		internal void _SetGameDescription( IntPtr pszGameDescription ) => _SteamAPI_ISteamGameServer_SetGameDescription( Self, pszGameDescription );
		#endregion
		internal void SetGameDescription( string pszGameDescription )
		{
			using var str__pszGameDescription = new Utf8StringToNative( pszGameDescription );
			_SteamAPI_ISteamGameServer_SetGameDescription( Self, str__pszGameDescription.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetModDir
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetModDir", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetModDir( IntPtr self, IntPtr pszModDir );
		internal void _SetModDir( IntPtr pszModDir ) => _SteamAPI_ISteamGameServer_SetModDir( Self, pszModDir );
		#endregion
		internal void SetModDir( string pszModDir )
		{
			using var str__pszModDir = new Utf8StringToNative( pszModDir );
			_SteamAPI_ISteamGameServer_SetModDir( Self, str__pszModDir.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetDedicatedServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetDedicatedServer", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetDedicatedServer( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bDedicated );
		internal void _SetDedicatedServer( [ MarshalAs( UnmanagedType.U1 ) ] bool bDedicated ) => _SteamAPI_ISteamGameServer_SetDedicatedServer( Self, bDedicated );
		#endregion
		internal void SetDedicatedServer( [ MarshalAs( UnmanagedType.U1 ) ] bool bDedicated )
		{
			_SteamAPI_ISteamGameServer_SetDedicatedServer( Self, bDedicated );
		}
		
		#region SteamAPI_ISteamGameServer_LogOn
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_LogOn", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_LogOn( IntPtr self, IntPtr pszToken );
		internal void _LogOn( IntPtr pszToken ) => _SteamAPI_ISteamGameServer_LogOn( Self, pszToken );
		#endregion
		internal void LogOn( string pszToken )
		{
			using var str__pszToken = new Utf8StringToNative( pszToken );
			_SteamAPI_ISteamGameServer_LogOn( Self, str__pszToken.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_LogOnAnonymous
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_LogOnAnonymous", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_LogOnAnonymous( IntPtr self );
		internal void _LogOnAnonymous(  ) => _SteamAPI_ISteamGameServer_LogOnAnonymous( Self );
		#endregion
		internal void LogOnAnonymous()
		{
			_SteamAPI_ISteamGameServer_LogOnAnonymous( Self );
		}
		
		#region SteamAPI_ISteamGameServer_LogOff
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_LogOff", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_LogOff( IntPtr self );
		internal void _LogOff(  ) => _SteamAPI_ISteamGameServer_LogOff( Self );
		#endregion
		internal void LogOff()
		{
			_SteamAPI_ISteamGameServer_LogOff( Self );
		}
		
		#region SteamAPI_ISteamGameServer_BLoggedOn
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BLoggedOn", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_BLoggedOn( IntPtr self );
		internal bool _BLoggedOn(  ) => _SteamAPI_ISteamGameServer_BLoggedOn( Self );
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
		internal bool _BSecure(  ) => _SteamAPI_ISteamGameServer_BSecure( Self );
		#endregion
		internal bool BSecure()
		{
			var returnValue = _SteamAPI_ISteamGameServer_BSecure( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetSteamID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetSteamID", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamGameServer_GetSteamID( IntPtr self );
		internal SteamId _GetSteamID(  ) => _SteamAPI_ISteamGameServer_GetSteamID( Self );
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
		internal bool _WasRestartRequested(  ) => _SteamAPI_ISteamGameServer_WasRestartRequested( Self );
		#endregion
		internal bool WasRestartRequested()
		{
			var returnValue = _SteamAPI_ISteamGameServer_WasRestartRequested( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_SetMaxPlayerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetMaxPlayerCount", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetMaxPlayerCount( IntPtr self, int cPlayersMax );
		internal void _SetMaxPlayerCount( int cPlayersMax ) => _SteamAPI_ISteamGameServer_SetMaxPlayerCount( Self, cPlayersMax );
		#endregion
		internal void SetMaxPlayerCount( int cPlayersMax )
		{
			_SteamAPI_ISteamGameServer_SetMaxPlayerCount( Self, cPlayersMax );
		}
		
		#region SteamAPI_ISteamGameServer_SetBotPlayerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetBotPlayerCount", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetBotPlayerCount( IntPtr self, int cBotplayers );
		internal void _SetBotPlayerCount( int cBotplayers ) => _SteamAPI_ISteamGameServer_SetBotPlayerCount( Self, cBotplayers );
		#endregion
		internal void SetBotPlayerCount( int cBotplayers )
		{
			_SteamAPI_ISteamGameServer_SetBotPlayerCount( Self, cBotplayers );
		}
		
		#region SteamAPI_ISteamGameServer_SetServerName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetServerName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetServerName( IntPtr self, IntPtr pszServerName );
		internal void _SetServerName( IntPtr pszServerName ) => _SteamAPI_ISteamGameServer_SetServerName( Self, pszServerName );
		#endregion
		internal void SetServerName( string pszServerName )
		{
			using var str__pszServerName = new Utf8StringToNative( pszServerName );
			_SteamAPI_ISteamGameServer_SetServerName( Self, str__pszServerName.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetMapName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetMapName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetMapName( IntPtr self, IntPtr pszMapName );
		internal void _SetMapName( IntPtr pszMapName ) => _SteamAPI_ISteamGameServer_SetMapName( Self, pszMapName );
		#endregion
		internal void SetMapName( string pszMapName )
		{
			using var str__pszMapName = new Utf8StringToNative( pszMapName );
			_SteamAPI_ISteamGameServer_SetMapName( Self, str__pszMapName.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetPasswordProtected
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetPasswordProtected", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetPasswordProtected( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bPasswordProtected );
		internal void _SetPasswordProtected( [ MarshalAs( UnmanagedType.U1 ) ] bool bPasswordProtected ) => _SteamAPI_ISteamGameServer_SetPasswordProtected( Self, bPasswordProtected );
		#endregion
		internal void SetPasswordProtected( [ MarshalAs( UnmanagedType.U1 ) ] bool bPasswordProtected )
		{
			_SteamAPI_ISteamGameServer_SetPasswordProtected( Self, bPasswordProtected );
		}
		
		#region SteamAPI_ISteamGameServer_SetSpectatorPort
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorPort", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetSpectatorPort( IntPtr self, ushort unSpectatorPort );
		internal void _SetSpectatorPort( ushort unSpectatorPort ) => _SteamAPI_ISteamGameServer_SetSpectatorPort( Self, unSpectatorPort );
		#endregion
		internal void SetSpectatorPort( ushort unSpectatorPort )
		{
			_SteamAPI_ISteamGameServer_SetSpectatorPort( Self, unSpectatorPort );
		}
		
		#region SteamAPI_ISteamGameServer_SetSpectatorServerName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorServerName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetSpectatorServerName( IntPtr self, IntPtr pszSpectatorServerName );
		internal void _SetSpectatorServerName( IntPtr pszSpectatorServerName ) => _SteamAPI_ISteamGameServer_SetSpectatorServerName( Self, pszSpectatorServerName );
		#endregion
		internal void SetSpectatorServerName( string pszSpectatorServerName )
		{
			using var str__pszSpectatorServerName = new Utf8StringToNative( pszSpectatorServerName );
			_SteamAPI_ISteamGameServer_SetSpectatorServerName( Self, str__pszSpectatorServerName.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_ClearAllKeyValues
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_ClearAllKeyValues", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_ClearAllKeyValues( IntPtr self );
		internal void _ClearAllKeyValues(  ) => _SteamAPI_ISteamGameServer_ClearAllKeyValues( Self );
		#endregion
		internal void ClearAllKeyValues()
		{
			_SteamAPI_ISteamGameServer_ClearAllKeyValues( Self );
		}
		
		#region SteamAPI_ISteamGameServer_SetKeyValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetKeyValue", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetKeyValue( IntPtr self, IntPtr pKey, IntPtr pValue );
		internal void _SetKeyValue( IntPtr pKey, IntPtr pValue ) => _SteamAPI_ISteamGameServer_SetKeyValue( Self, pKey, pValue );
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
		internal void _SetGameTags( IntPtr pchGameTags ) => _SteamAPI_ISteamGameServer_SetGameTags( Self, pchGameTags );
		#endregion
		internal void SetGameTags( string pchGameTags )
		{
			using var str__pchGameTags = new Utf8StringToNative( pchGameTags );
			_SteamAPI_ISteamGameServer_SetGameTags( Self, str__pchGameTags.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetGameData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetGameData", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetGameData( IntPtr self, IntPtr pchGameData );
		internal void _SetGameData( IntPtr pchGameData ) => _SteamAPI_ISteamGameServer_SetGameData( Self, pchGameData );
		#endregion
		internal void SetGameData( string pchGameData )
		{
			using var str__pchGameData = new Utf8StringToNative( pchGameData );
			_SteamAPI_ISteamGameServer_SetGameData( Self, str__pchGameData.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetRegion
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetRegion", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetRegion( IntPtr self, IntPtr pszRegion );
		internal void _SetRegion( IntPtr pszRegion ) => _SteamAPI_ISteamGameServer_SetRegion( Self, pszRegion );
		#endregion
		internal void SetRegion( string pszRegion )
		{
			using var str__pszRegion = new Utf8StringToNative( pszRegion );
			_SteamAPI_ISteamGameServer_SetRegion( Self, str__pszRegion.Pointer );
		}
		
		#region SteamAPI_ISteamGameServer_SetAdvertiseServerActive
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SetAdvertiseServerActive", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SetAdvertiseServerActive( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bActive );
		internal void _SetAdvertiseServerActive( [ MarshalAs( UnmanagedType.U1 ) ] bool bActive ) => _SteamAPI_ISteamGameServer_SetAdvertiseServerActive( Self, bActive );
		#endregion
		internal void SetAdvertiseServerActive( [ MarshalAs( UnmanagedType.U1 ) ] bool bActive )
		{
			_SteamAPI_ISteamGameServer_SetAdvertiseServerActive( Self, bActive );
		}
		
		#region SteamAPI_ISteamGameServer_GetAuthSessionTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetAuthSessionTicket", CallingConvention = Platform.CC ) ]
		internal static extern HAuthTicket _SteamAPI_ISteamGameServer_GetAuthSessionTicket( IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSnid );
		internal HAuthTicket _GetAuthSessionTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSnid ) => _SteamAPI_ISteamGameServer_GetAuthSessionTicket( Self, pTicket, cbMaxTicket, ref pcbTicket, ref pSnid );
		#endregion
		internal HAuthTicket GetAuthSessionTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket, ref SteamNetworkingIdentity pSnid )
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetAuthSessionTicket( Self, pTicket, cbMaxTicket, ref pcbTicket, ref pSnid );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_BeginAuthSession
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BeginAuthSession", CallingConvention = Platform.CC ) ]
		internal static extern EBeginAuthSessionResult _SteamAPI_ISteamGameServer_BeginAuthSession( IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID );
		internal EBeginAuthSessionResult _BeginAuthSession( IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID ) => _SteamAPI_ISteamGameServer_BeginAuthSession( Self, pAuthTicket, cbAuthTicket, steamID );
		#endregion
		internal EBeginAuthSessionResult BeginAuthSession( IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamGameServer_BeginAuthSession( Self, pAuthTicket, cbAuthTicket, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_EndAuthSession
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_EndAuthSession", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_EndAuthSession( IntPtr self, SteamId steamID );
		internal void _EndAuthSession( SteamId steamID ) => _SteamAPI_ISteamGameServer_EndAuthSession( Self, steamID );
		#endregion
		internal void EndAuthSession( SteamId steamID )
		{
			_SteamAPI_ISteamGameServer_EndAuthSession( Self, steamID );
		}
		
		#region SteamAPI_ISteamGameServer_CancelAuthTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_CancelAuthTicket", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_CancelAuthTicket( IntPtr self, HAuthTicket hAuthTicket );
		internal void _CancelAuthTicket( HAuthTicket hAuthTicket ) => _SteamAPI_ISteamGameServer_CancelAuthTicket( Self, hAuthTicket );
		#endregion
		internal void CancelAuthTicket( HAuthTicket hAuthTicket )
		{
			_SteamAPI_ISteamGameServer_CancelAuthTicket( Self, hAuthTicket );
		}
		
		#region SteamAPI_ISteamGameServer_UserHasLicenseForApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_UserHasLicenseForApp", CallingConvention = Platform.CC ) ]
		internal static extern EUserHasLicenseForAppResult _SteamAPI_ISteamGameServer_UserHasLicenseForApp( IntPtr self, SteamId steamID, AppId_t appID );
		internal EUserHasLicenseForAppResult _UserHasLicenseForApp( SteamId steamID, AppId_t appID ) => _SteamAPI_ISteamGameServer_UserHasLicenseForApp( Self, steamID, appID );
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
		internal bool _RequestUserGroupStatus( SteamId steamIDUser, SteamId steamIDGroup ) => _SteamAPI_ISteamGameServer_RequestUserGroupStatus( Self, steamIDUser, steamIDGroup );
		#endregion
		internal bool RequestUserGroupStatus( SteamId steamIDUser, SteamId steamIDGroup )
		{
			var returnValue = _SteamAPI_ISteamGameServer_RequestUserGroupStatus( Self, steamIDUser, steamIDGroup );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetGameplayStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetGameplayStats", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_GetGameplayStats( IntPtr self );
		internal void _GetGameplayStats(  ) => _SteamAPI_ISteamGameServer_GetGameplayStats( Self );
		#endregion
		internal void GetGameplayStats()
		{
			_SteamAPI_ISteamGameServer_GetGameplayStats( Self );
		}
		
		#region SteamAPI_ISteamGameServer_GetServerReputation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetServerReputation", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamGameServer_GetServerReputation( IntPtr self );
		internal SteamAPICall_t _GetServerReputation(  ) => _SteamAPI_ISteamGameServer_GetServerReputation( Self );
		#endregion
		internal CallResult<GSReputation_t> GetServerReputation()
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetServerReputation( Self );
			return new CallResult<GSReputation_t>( returnValue );
		}
		
		#region SteamAPI_ISteamGameServer_GetPublicIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetPublicIP", CallingConvention = Platform.CC ) ]
		internal static extern SteamIPAddress_t _SteamAPI_ISteamGameServer_GetPublicIP( IntPtr self );
		internal SteamIPAddress_t _GetPublicIP(  ) => _SteamAPI_ISteamGameServer_GetPublicIP( Self );
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
		internal bool _HandleIncomingPacket( IntPtr pData, int cbData, uint srcIP, ushort srcPort ) => _SteamAPI_ISteamGameServer_HandleIncomingPacket( Self, pData, cbData, srcIP, srcPort );
		#endregion
		internal bool HandleIncomingPacket( IntPtr pData, int cbData, uint srcIP, ushort srcPort )
		{
			var returnValue = _SteamAPI_ISteamGameServer_HandleIncomingPacket( Self, pData, cbData, srcIP, srcPort );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_GetNextOutgoingPacket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_GetNextOutgoingPacket", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamGameServer_GetNextOutgoingPacket( IntPtr self, IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort );
		internal int _GetNextOutgoingPacket( IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort ) => _SteamAPI_ISteamGameServer_GetNextOutgoingPacket( Self, pOut, cbMaxOut, ref pNetAdr, ref pPort );
		#endregion
		internal int GetNextOutgoingPacket( IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort )
		{
			var returnValue = _SteamAPI_ISteamGameServer_GetNextOutgoingPacket( Self, pOut, cbMaxOut, ref pNetAdr, ref pPort );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_AssociateWithClan
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_AssociateWithClan", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamGameServer_AssociateWithClan( IntPtr self, SteamId steamIDClan );
		internal SteamAPICall_t _AssociateWithClan( SteamId steamIDClan ) => _SteamAPI_ISteamGameServer_AssociateWithClan( Self, steamIDClan );
		#endregion
		internal CallResult<AssociateWithClanResult_t> AssociateWithClan( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamGameServer_AssociateWithClan( Self, steamIDClan );
			return new CallResult<AssociateWithClanResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility( IntPtr self, SteamId steamIDNewPlayer );
		internal SteamAPICall_t _ComputeNewPlayerCompatibility( SteamId steamIDNewPlayer ) => _SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility( Self, steamIDNewPlayer );
		#endregion
		internal CallResult<ComputeNewPlayerCompatibilityResult_t> ComputeNewPlayerCompatibility( SteamId steamIDNewPlayer )
		{
			var returnValue = _SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility( Self, steamIDNewPlayer );
			return new CallResult<ComputeNewPlayerCompatibilityResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED( IntPtr self, uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser );
		internal bool _SendUserConnectAndAuthenticate_DEPRECATED( uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser ) => _SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED( Self, unIPClient, pvAuthBlob, cubAuthBlobSize, ref pSteamIDUser );
		#endregion
		internal bool SendUserConnectAndAuthenticate_DEPRECATED( uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser )
		{
			var returnValue = _SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED( Self, unIPClient, pvAuthBlob, cubAuthBlobSize, ref pSteamIDUser );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection( IntPtr self );
		internal SteamId _CreateUnauthenticatedUserConnection(  ) => _SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection( Self );
		#endregion
		internal SteamId CreateUnauthenticatedUserConnection()
		{
			var returnValue = _SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED( IntPtr self, SteamId steamIDUser );
		internal void _SendUserDisconnect_DEPRECATED( SteamId steamIDUser ) => _SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED( Self, steamIDUser );
		#endregion
		internal void SendUserDisconnect_DEPRECATED( SteamId steamIDUser )
		{
			_SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED( Self, steamIDUser );
		}
		
		#region SteamAPI_ISteamGameServer_BUpdateUserData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BUpdateUserData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamGameServer_BUpdateUserData( IntPtr self, SteamId steamIDUser, IntPtr pchPlayerName, uint uScore );
		internal bool _BUpdateUserData( SteamId steamIDUser, IntPtr pchPlayerName, uint uScore ) => _SteamAPI_ISteamGameServer_BUpdateUserData( Self, steamIDUser, pchPlayerName, uScore );
		#endregion
		internal bool BUpdateUserData( SteamId steamIDUser, string pchPlayerName, uint uScore )
		{
			using var str__pchPlayerName = new Utf8StringToNative( pchPlayerName );
			var returnValue = _SteamAPI_ISteamGameServer_BUpdateUserData( Self, steamIDUser, str__pchPlayerName.Pointer, uScore );
			return returnValue;
		}
		
	}
}
