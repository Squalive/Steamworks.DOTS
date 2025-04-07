using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamNetworkingUtils
	{
		public const string Version = "SteamNetworkingUtils004";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingUtils_SteamAPI_v004", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamNetworkingUtils_SteamAPI_v004();
		/// Construct use accessor to find interface
		public ISteamNetworkingUtils( bool isGameServer )
		{
			Self = IntPtr.Zero;
			Self = SteamAPI_SteamNetworkingUtils_SteamAPI_v004();
		}
		public ISteamNetworkingUtils( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamNetworkingUtils_AllocateMessage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_AllocateMessage", CallingConvention = Platform.CC ) ]
		internal static extern NetMsg* _SteamAPI_ISteamNetworkingUtils_AllocateMessage( IntPtr self, int cbAllocateBuffer );
		internal NetMsg* _AllocateMessage( int cbAllocateBuffer ) => _SteamAPI_ISteamNetworkingUtils_AllocateMessage( Self, cbAllocateBuffer );
		#endregion
		internal NetMsg* AllocateMessage( int cbAllocateBuffer )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_AllocateMessage( Self, cbAllocateBuffer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess( IntPtr self );
		internal void _InitRelayNetworkAccess(  ) => _SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess( Self );
		#endregion
		internal void InitRelayNetworkAccess()
		{
			_SteamAPI_ISteamNetworkingUtils_InitRelayNetworkAccess( Self );
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingAvailability _SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus( IntPtr self, ref SteamRelayNetworkStatus_t pDetails );
		internal ESteamNetworkingAvailability _GetRelayNetworkStatus( ref SteamRelayNetworkStatus_t pDetails ) => _SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus( Self, ref pDetails );
		#endregion
		internal ESteamNetworkingAvailability GetRelayNetworkStatus( ref SteamRelayNetworkStatus_t pDetails )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetRelayNetworkStatus( Self, ref pDetails );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetLocalPingLocation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetLocalPingLocation", CallingConvention = Platform.CC ) ]
		internal static extern float _SteamAPI_ISteamNetworkingUtils_GetLocalPingLocation( IntPtr self, ref SteamNetworkPingLocation_t result );
		internal float _GetLocalPingLocation( ref SteamNetworkPingLocation_t result ) => _SteamAPI_ISteamNetworkingUtils_GetLocalPingLocation( Self, ref result );
		#endregion
		internal float GetLocalPingLocation( ref SteamNetworkPingLocation_t result )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetLocalPingLocation( Self, ref result );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations( IntPtr self, ref SteamNetworkPingLocation_t location1, ref SteamNetworkPingLocation_t location2 );
		internal int _EstimatePingTimeBetweenTwoLocations( ref SteamNetworkPingLocation_t location1, ref SteamNetworkPingLocation_t location2 ) => _SteamAPI_ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations( Self, ref location1, ref location2 );
		#endregion
		internal int EstimatePingTimeBetweenTwoLocations( ref SteamNetworkPingLocation_t location1, ref SteamNetworkPingLocation_t location2 )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_EstimatePingTimeBetweenTwoLocations( Self, ref location1, ref location2 );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_EstimatePingTimeFromLocalHost
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_EstimatePingTimeFromLocalHost", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingUtils_EstimatePingTimeFromLocalHost( IntPtr self, ref SteamNetworkPingLocation_t remoteLocation );
		internal int _EstimatePingTimeFromLocalHost( ref SteamNetworkPingLocation_t remoteLocation ) => _SteamAPI_ISteamNetworkingUtils_EstimatePingTimeFromLocalHost( Self, ref remoteLocation );
		#endregion
		internal int EstimatePingTimeFromLocalHost( ref SteamNetworkPingLocation_t remoteLocation )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_EstimatePingTimeFromLocalHost( Self, ref remoteLocation );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_ConvertPingLocationToString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_ConvertPingLocationToString", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingUtils_ConvertPingLocationToString( IntPtr self, ref SteamNetworkPingLocation_t location, IntPtr pszBuf, int cchBufSize );
		internal void _ConvertPingLocationToString( ref SteamNetworkPingLocation_t location, IntPtr pszBuf, int cchBufSize ) => _SteamAPI_ISteamNetworkingUtils_ConvertPingLocationToString( Self, ref location, pszBuf, cchBufSize );
		#endregion
		internal void ConvertPingLocationToString( ref SteamNetworkPingLocation_t location, out string pszBuf, int cchBufSize )
		{
			using var mem__pszBuf = new Utility.Memory( Utility.MemoryBufferSize );
			_SteamAPI_ISteamNetworkingUtils_ConvertPingLocationToString( Self, ref location, mem__pszBuf.Ptr, cchBufSize );
			pszBuf = Utility.MemoryToString( mem__pszBuf );
		}
		
		#region SteamAPI_ISteamNetworkingUtils_ParsePingLocationString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_ParsePingLocationString", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_ParsePingLocationString( IntPtr self, IntPtr pszString, ref SteamNetworkPingLocation_t result );
		internal bool _ParsePingLocationString( IntPtr pszString, ref SteamNetworkPingLocation_t result ) => _SteamAPI_ISteamNetworkingUtils_ParsePingLocationString( Self, pszString, ref result );
		#endregion
		internal bool ParsePingLocationString( string pszString, ref SteamNetworkPingLocation_t result )
		{
			using var str__pszString = new Utf8StringToNative( pszString );
			var returnValue = _SteamAPI_ISteamNetworkingUtils_ParsePingLocationString( Self, str__pszString.Pointer, ref result );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_CheckPingDataUpToDate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_CheckPingDataUpToDate", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_CheckPingDataUpToDate( IntPtr self, float flMaxAgeSeconds );
		internal bool _CheckPingDataUpToDate( float flMaxAgeSeconds ) => _SteamAPI_ISteamNetworkingUtils_CheckPingDataUpToDate( Self, flMaxAgeSeconds );
		#endregion
		internal bool CheckPingDataUpToDate( float flMaxAgeSeconds )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_CheckPingDataUpToDate( Self, flMaxAgeSeconds );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetPingToDataCenter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetPingToDataCenter", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingUtils_GetPingToDataCenter( IntPtr self, SteamNetworkingPOPID popID, ref SteamNetworkingPOPID pViaRelayPoP );
		internal int _GetPingToDataCenter( SteamNetworkingPOPID popID, ref SteamNetworkingPOPID pViaRelayPoP ) => _SteamAPI_ISteamNetworkingUtils_GetPingToDataCenter( Self, popID, ref pViaRelayPoP );
		#endregion
		internal int GetPingToDataCenter( SteamNetworkingPOPID popID, ref SteamNetworkingPOPID pViaRelayPoP )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetPingToDataCenter( Self, popID, ref pViaRelayPoP );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetDirectPingToPOP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetDirectPingToPOP", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingUtils_GetDirectPingToPOP( IntPtr self, SteamNetworkingPOPID popID );
		internal int _GetDirectPingToPOP( SteamNetworkingPOPID popID ) => _SteamAPI_ISteamNetworkingUtils_GetDirectPingToPOP( Self, popID );
		#endregion
		internal int GetDirectPingToPOP( SteamNetworkingPOPID popID )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetDirectPingToPOP( Self, popID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetPOPCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetPOPCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingUtils_GetPOPCount( IntPtr self );
		internal int _GetPOPCount(  ) => _SteamAPI_ISteamNetworkingUtils_GetPOPCount( Self );
		#endregion
		internal int GetPOPCount()
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetPOPCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetPOPList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetPOPList", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingUtils_GetPOPList( IntPtr self, ref SteamNetworkingPOPID list, int nListSz );
		internal int _GetPOPList( ref SteamNetworkingPOPID list, int nListSz ) => _SteamAPI_ISteamNetworkingUtils_GetPOPList( Self, ref list, nListSz );
		#endregion
		internal int GetPOPList( ref SteamNetworkingPOPID list, int nListSz )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetPOPList( Self, ref list, nListSz );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetLocalTimestamp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetLocalTimestamp", CallingConvention = Platform.CC ) ]
		internal static extern SteamNetworkingMicroseconds _SteamAPI_ISteamNetworkingUtils_GetLocalTimestamp( IntPtr self );
		internal SteamNetworkingMicroseconds _GetLocalTimestamp(  ) => _SteamAPI_ISteamNetworkingUtils_GetLocalTimestamp( Self );
		#endregion
		internal SteamNetworkingMicroseconds GetLocalTimestamp()
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetLocalTimestamp( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetDebugOutputFunction
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetDebugOutputFunction", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingUtils_SetDebugOutputFunction( IntPtr self, ESteamNetworkingSocketsDebugOutputType eDetailLevel, NetDebugFunc pfnFunc );
		internal void _SetDebugOutputFunction( ESteamNetworkingSocketsDebugOutputType eDetailLevel, NetDebugFunc pfnFunc ) => _SteamAPI_ISteamNetworkingUtils_SetDebugOutputFunction( Self, eDetailLevel, pfnFunc );
		#endregion
		internal void SetDebugOutputFunction( ESteamNetworkingSocketsDebugOutputType eDetailLevel, NetDebugFunc pfnFunc )
		{
			_SteamAPI_ISteamNetworkingUtils_SetDebugOutputFunction( Self, eDetailLevel, pfnFunc );
		}
		
		#region SteamAPI_ISteamNetworkingUtils_IsFakeIPv4
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_IsFakeIPv4", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_IsFakeIPv4( IntPtr self, uint nIPv4 );
		internal bool _IsFakeIPv4( uint nIPv4 ) => _SteamAPI_ISteamNetworkingUtils_IsFakeIPv4( Self, nIPv4 );
		#endregion
		internal bool IsFakeIPv4( uint nIPv4 )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_IsFakeIPv4( Self, nIPv4 );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetIPv4FakeIPType
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetIPv4FakeIPType", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingFakeIPType _SteamAPI_ISteamNetworkingUtils_GetIPv4FakeIPType( IntPtr self, uint nIPv4 );
		internal ESteamNetworkingFakeIPType _GetIPv4FakeIPType( uint nIPv4 ) => _SteamAPI_ISteamNetworkingUtils_GetIPv4FakeIPType( Self, nIPv4 );
		#endregion
		internal ESteamNetworkingFakeIPType GetIPv4FakeIPType( uint nIPv4 )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetIPv4FakeIPType( Self, nIPv4 );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetRealIdentityForFakeIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetRealIdentityForFakeIP", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingUtils_GetRealIdentityForFakeIP( IntPtr self, ref SteamNetworkingIPAddr fakeIP, SteamNetworkingIdentity* pOutRealIdentity );
		internal EResult _GetRealIdentityForFakeIP( ref SteamNetworkingIPAddr fakeIP, SteamNetworkingIdentity* pOutRealIdentity ) => _SteamAPI_ISteamNetworkingUtils_GetRealIdentityForFakeIP( Self, ref fakeIP, pOutRealIdentity );
		#endregion
		internal EResult GetRealIdentityForFakeIP( ref SteamNetworkingIPAddr fakeIP, SteamNetworkingIdentity* pOutRealIdentity )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetRealIdentityForFakeIP( Self, ref fakeIP, pOutRealIdentity );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueInt32( IntPtr self, ESteamNetworkingConfigValue eValue, int val );
		internal bool _SetGlobalConfigValueInt32( ESteamNetworkingConfigValue eValue, int val ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueInt32( Self, eValue, val );
		#endregion
		internal bool SetGlobalConfigValueInt32( ESteamNetworkingConfigValue eValue, int val )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueInt32( Self, eValue, val );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueFloat( IntPtr self, ESteamNetworkingConfigValue eValue, float val );
		internal bool _SetGlobalConfigValueFloat( ESteamNetworkingConfigValue eValue, float val ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueFloat( Self, eValue, val );
		#endregion
		internal bool SetGlobalConfigValueFloat( ESteamNetworkingConfigValue eValue, float val )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueFloat( Self, eValue, val );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueString", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueString( IntPtr self, ESteamNetworkingConfigValue eValue, IntPtr val );
		internal bool _SetGlobalConfigValueString( ESteamNetworkingConfigValue eValue, IntPtr val ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueString( Self, eValue, val );
		#endregion
		internal bool SetGlobalConfigValueString( ESteamNetworkingConfigValue eValue, string val )
		{
			using var str__val = new Utf8StringToNative( val );
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValueString( Self, eValue, str__val.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValuePtr
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValuePtr", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValuePtr( IntPtr self, ESteamNetworkingConfigValue eValue, IntPtr val );
		internal bool _SetGlobalConfigValuePtr( ESteamNetworkingConfigValue eValue, IntPtr val ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValuePtr( Self, eValue, val );
		#endregion
		internal bool SetGlobalConfigValuePtr( ESteamNetworkingConfigValue eValue, IntPtr val )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalConfigValuePtr( Self, eValue, val );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueInt32( IntPtr self, HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, int val );
		internal bool _SetConnectionConfigValueInt32( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, int val ) => _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueInt32( Self, hConn, eValue, val );
		#endregion
		internal bool SetConnectionConfigValueInt32( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, int val )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueInt32( Self, hConn, eValue, val );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueFloat( IntPtr self, HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, float val );
		internal bool _SetConnectionConfigValueFloat( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, float val ) => _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueFloat( Self, hConn, eValue, val );
		#endregion
		internal bool SetConnectionConfigValueFloat( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, float val )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueFloat( Self, hConn, eValue, val );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueString", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueString( IntPtr self, HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, IntPtr val );
		internal bool _SetConnectionConfigValueString( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, IntPtr val ) => _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueString( Self, hConn, eValue, val );
		#endregion
		internal bool SetConnectionConfigValueString( HSteamNetConnection hConn, ESteamNetworkingConfigValue eValue, string val )
		{
			using var str__val = new Utf8StringToNative( val );
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetConnectionConfigValueString( Self, hConn, eValue, str__val.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetConnectionStatusChanged
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetConnectionStatusChanged", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetConnectionStatusChanged( IntPtr self, FnSteamNetConnectionStatusChanged fnCallback );
		internal bool _SetGlobalCallback_SteamNetConnectionStatusChanged( FnSteamNetConnectionStatusChanged fnCallback ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetConnectionStatusChanged( Self, fnCallback );
		#endregion
		internal bool SetGlobalCallback_SteamNetConnectionStatusChanged( FnSteamNetConnectionStatusChanged fnCallback )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetConnectionStatusChanged( Self, fnCallback );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetAuthenticationStatusChanged
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetAuthenticationStatusChanged", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetAuthenticationStatusChanged( IntPtr self, FnSteamNetAuthenticationStatusChanged fnCallback );
		internal bool _SetGlobalCallback_SteamNetAuthenticationStatusChanged( FnSteamNetAuthenticationStatusChanged fnCallback ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetAuthenticationStatusChanged( Self, fnCallback );
		#endregion
		internal bool SetGlobalCallback_SteamNetAuthenticationStatusChanged( FnSteamNetAuthenticationStatusChanged fnCallback )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamNetAuthenticationStatusChanged( Self, fnCallback );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamRelayNetworkStatusChanged
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamRelayNetworkStatusChanged", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamRelayNetworkStatusChanged( IntPtr self, FnSteamRelayNetworkStatusChanged fnCallback );
		internal bool _SetGlobalCallback_SteamRelayNetworkStatusChanged( FnSteamRelayNetworkStatusChanged fnCallback ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamRelayNetworkStatusChanged( Self, fnCallback );
		#endregion
		internal bool SetGlobalCallback_SteamRelayNetworkStatusChanged( FnSteamRelayNetworkStatusChanged fnCallback )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_SteamRelayNetworkStatusChanged( Self, fnCallback );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_FakeIPResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_FakeIPResult", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_FakeIPResult( IntPtr self, FnSteamNetworkingFakeIPResult fnCallback );
		internal bool _SetGlobalCallback_FakeIPResult( FnSteamNetworkingFakeIPResult fnCallback ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_FakeIPResult( Self, fnCallback );
		#endregion
		internal bool SetGlobalCallback_FakeIPResult( FnSteamNetworkingFakeIPResult fnCallback )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_FakeIPResult( Self, fnCallback );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionRequest( IntPtr self, FnSteamNetworkingMessagesSessionRequest fnCallback );
		internal bool _SetGlobalCallback_MessagesSessionRequest( FnSteamNetworkingMessagesSessionRequest fnCallback ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionRequest( Self, fnCallback );
		#endregion
		internal bool SetGlobalCallback_MessagesSessionRequest( FnSteamNetworkingMessagesSessionRequest fnCallback )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionRequest( Self, fnCallback );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionFailed
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionFailed", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionFailed( IntPtr self, FnSteamNetworkingMessagesSessionFailed fnCallback );
		internal bool _SetGlobalCallback_MessagesSessionFailed( FnSteamNetworkingMessagesSessionFailed fnCallback ) => _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionFailed( Self, fnCallback );
		#endregion
		internal bool SetGlobalCallback_MessagesSessionFailed( FnSteamNetworkingMessagesSessionFailed fnCallback )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetGlobalCallback_MessagesSessionFailed( Self, fnCallback );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetConfigValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetConfigValue", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetConfigValue( IntPtr self, ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ESteamNetworkingConfigDataType eDataType, IntPtr pArg );
		internal bool _SetConfigValue( ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ESteamNetworkingConfigDataType eDataType, IntPtr pArg ) => _SteamAPI_ISteamNetworkingUtils_SetConfigValue( Self, eValue, eScopeType, scopeObj, eDataType, pArg );
		#endregion
		internal bool SetConfigValue( ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ESteamNetworkingConfigDataType eDataType, IntPtr pArg )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetConfigValue( Self, eValue, eScopeType, scopeObj, eDataType, pArg );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SetConfigValueStruct
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SetConfigValueStruct", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SetConfigValueStruct( IntPtr self, ref SteamNetworkingConfigValue_t opt, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj );
		internal bool _SetConfigValueStruct( ref SteamNetworkingConfigValue_t opt, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj ) => _SteamAPI_ISteamNetworkingUtils_SetConfigValueStruct( Self, ref opt, eScopeType, scopeObj );
		#endregion
		internal bool SetConfigValueStruct( ref SteamNetworkingConfigValue_t opt, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SetConfigValueStruct( Self, ref opt, eScopeType, scopeObj );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetConfigValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetConfigValue", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingGetConfigValueResult _SteamAPI_ISteamNetworkingUtils_GetConfigValue( IntPtr self, ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ref ESteamNetworkingConfigDataType pOutDataType, IntPtr pResult, ref UIntPtr cbResult );
		internal ESteamNetworkingGetConfigValueResult _GetConfigValue( ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ref ESteamNetworkingConfigDataType pOutDataType, IntPtr pResult, ref UIntPtr cbResult ) => _SteamAPI_ISteamNetworkingUtils_GetConfigValue( Self, eValue, eScopeType, scopeObj, ref pOutDataType, pResult, ref cbResult );
		#endregion
		internal ESteamNetworkingGetConfigValueResult GetConfigValue( ESteamNetworkingConfigValue eValue, ESteamNetworkingConfigScope eScopeType, IntPtr scopeObj, ref ESteamNetworkingConfigDataType pOutDataType, IntPtr pResult, ref UIntPtr cbResult )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetConfigValue( Self, eValue, eScopeType, scopeObj, ref pOutDataType, pResult, ref cbResult );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_GetConfigValueInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_GetConfigValueInfo", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamNetworkingUtils_GetConfigValueInfo( IntPtr self, ESteamNetworkingConfigValue eValue, ref ESteamNetworkingConfigDataType pOutDataType, ESteamNetworkingConfigScope* pOutScope );
		internal Utf8StringPtr _GetConfigValueInfo( ESteamNetworkingConfigValue eValue, ref ESteamNetworkingConfigDataType pOutDataType, ESteamNetworkingConfigScope* pOutScope ) => _SteamAPI_ISteamNetworkingUtils_GetConfigValueInfo( Self, eValue, ref pOutDataType, pOutScope );
		#endregion
		internal string GetConfigValueInfo( ESteamNetworkingConfigValue eValue, ref ESteamNetworkingConfigDataType pOutDataType, ESteamNetworkingConfigScope* pOutScope )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_GetConfigValueInfo( Self, eValue, ref pOutDataType, pOutScope );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_IterateGenericEditableConfigValues
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_IterateGenericEditableConfigValues", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingConfigValue _SteamAPI_ISteamNetworkingUtils_IterateGenericEditableConfigValues( IntPtr self, ESteamNetworkingConfigValue eCurrent, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnumerateDevVars );
		internal ESteamNetworkingConfigValue _IterateGenericEditableConfigValues( ESteamNetworkingConfigValue eCurrent, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnumerateDevVars ) => _SteamAPI_ISteamNetworkingUtils_IterateGenericEditableConfigValues( Self, eCurrent, bEnumerateDevVars );
		#endregion
		internal ESteamNetworkingConfigValue IterateGenericEditableConfigValues( ESteamNetworkingConfigValue eCurrent, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnumerateDevVars )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_IterateGenericEditableConfigValues( Self, eCurrent, bEnumerateDevVars );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString( IntPtr self, ref SteamNetworkingIPAddr addr, IntPtr buf, uint cbBuf, [ MarshalAs( UnmanagedType.U1 ) ] bool bWithPort );
		internal void _SteamNetworkingIPAddr_ToString( ref SteamNetworkingIPAddr addr, IntPtr buf, uint cbBuf, [ MarshalAs( UnmanagedType.U1 ) ] bool bWithPort ) => _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString( Self, ref addr, buf, cbBuf, bWithPort );
		#endregion
		internal void SteamNetworkingIPAddr_ToString( ref SteamNetworkingIPAddr addr, out string buf, uint cbBuf, [ MarshalAs( UnmanagedType.U1 ) ] bool bWithPort )
		{
			using var mem__buf = new Utility.Memory( Utility.MemoryBufferSize );
			_SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ToString( Self, ref addr, mem__buf.Ptr, cbBuf, bWithPort );
			buf = Utility.MemoryToString( mem__buf );
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString( IntPtr self, ref SteamNetworkingIPAddr pAddr, IntPtr pszStr );
		internal bool _SteamNetworkingIPAddr_ParseString( ref SteamNetworkingIPAddr pAddr, IntPtr pszStr ) => _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString( Self, ref pAddr, pszStr );
		#endregion
		internal bool SteamNetworkingIPAddr_ParseString( ref SteamNetworkingIPAddr pAddr, string pszStr )
		{
			using var str__pszStr = new Utf8StringToNative( pszStr );
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_ParseString( Self, ref pAddr, str__pszStr.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingFakeIPType _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType( IntPtr self, ref SteamNetworkingIPAddr addr );
		internal ESteamNetworkingFakeIPType _SteamNetworkingIPAddr_GetFakeIPType( ref SteamNetworkingIPAddr addr ) => _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType( Self, ref addr );
		#endregion
		internal ESteamNetworkingFakeIPType SteamNetworkingIPAddr_GetFakeIPType( ref SteamNetworkingIPAddr addr )
		{
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIPAddr_GetFakeIPType( Self, ref addr );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ToString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ToString", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ToString( IntPtr self, ref SteamNetworkingIdentity identity, IntPtr buf, uint cbBuf );
		internal void _SteamNetworkingIdentity_ToString( ref SteamNetworkingIdentity identity, IntPtr buf, uint cbBuf ) => _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ToString( Self, ref identity, buf, cbBuf );
		#endregion
		internal void SteamNetworkingIdentity_ToString( ref SteamNetworkingIdentity identity, out string buf, uint cbBuf )
		{
			using var mem__buf = new Utility.Memory( Utility.MemoryBufferSize );
			_SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ToString( Self, ref identity, mem__buf.Ptr, cbBuf );
			buf = Utility.MemoryToString( mem__buf );
		}
		
		#region SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString( IntPtr self, ref SteamNetworkingIdentity pIdentity, IntPtr pszStr );
		internal bool _SteamNetworkingIdentity_ParseString( ref SteamNetworkingIdentity pIdentity, IntPtr pszStr ) => _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString( Self, ref pIdentity, pszStr );
		#endregion
		internal bool SteamNetworkingIdentity_ParseString( ref SteamNetworkingIdentity pIdentity, string pszStr )
		{
			using var str__pszStr = new Utf8StringToNative( pszStr );
			var returnValue = _SteamAPI_ISteamNetworkingUtils_SteamNetworkingIdentity_ParseString( Self, ref pIdentity, str__pszStr.Pointer );
			return returnValue;
		}
		
	}
}
