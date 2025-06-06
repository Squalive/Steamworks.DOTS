using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamNetworkingSockets
	{
		public const string Version = "SteamNetworkingSockets012";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingSockets_SteamAPI_v012", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamNetworkingSockets_SteamAPI_v012();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v012", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v012();
		/// Construct use accessor to find interface
		public ISteamNetworkingSockets( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamNetworkingSockets_SteamAPI_v012();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v012();
			}
		}
		public ISteamNetworkingSockets( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP", CallingConvention = Platform.CC ) ]
		internal static extern HSteamListenSocket _SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP( IntPtr self, ref SteamNetworkingIPAddr localAddress, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamListenSocket _CreateListenSocketIP( ref SteamNetworkingIPAddr localAddress, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP( Self, ref localAddress, nOptions, pOptions );
		#endregion
		internal HSteamListenSocket CreateListenSocketIP( ref SteamNetworkingIPAddr localAddress, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP( Self, ref localAddress, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress", CallingConvention = Platform.CC ) ]
		internal static extern HSteamNetConnection _SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress( IntPtr self, ref SteamNetworkingIPAddr address, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamNetConnection _ConnectByIPAddress( ref SteamNetworkingIPAddr address, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress( Self, ref address, nOptions, pOptions );
		#endregion
		internal HSteamNetConnection ConnectByIPAddress( ref SteamNetworkingIPAddr address, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress( Self, ref address, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P", CallingConvention = Platform.CC ) ]
		internal static extern HSteamListenSocket _SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P( IntPtr self, int nLocalVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamListenSocket _CreateListenSocketP2P( int nLocalVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P( Self, nLocalVirtualPort, nOptions, pOptions );
		#endregion
		internal HSteamListenSocket CreateListenSocketP2P( int nLocalVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P( Self, nLocalVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ConnectP2P
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectP2P", CallingConvention = Platform.CC ) ]
		internal static extern HSteamNetConnection _SteamAPI_ISteamNetworkingSockets_ConnectP2P( IntPtr self, ref SteamNetworkingIdentity identityRemote, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamNetConnection _ConnectP2P( ref SteamNetworkingIdentity identityRemote, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_ConnectP2P( Self, ref identityRemote, nRemoteVirtualPort, nOptions, pOptions );
		#endregion
		internal HSteamNetConnection ConnectP2P( ref SteamNetworkingIdentity identityRemote, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ConnectP2P( Self, ref identityRemote, nRemoteVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_AcceptConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_AcceptConnection", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_AcceptConnection( IntPtr self, HSteamNetConnection hConn );
		internal EResult _AcceptConnection( HSteamNetConnection hConn ) => _SteamAPI_ISteamNetworkingSockets_AcceptConnection( Self, hConn );
		#endregion
		internal EResult AcceptConnection( HSteamNetConnection hConn )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_AcceptConnection( Self, hConn );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CloseConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CloseConnection", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_CloseConnection( IntPtr self, HSteamNetConnection hPeer, int nReason, IntPtr pszDebug, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnableLinger );
		internal bool _CloseConnection( HSteamNetConnection hPeer, int nReason, IntPtr pszDebug, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnableLinger ) => _SteamAPI_ISteamNetworkingSockets_CloseConnection( Self, hPeer, nReason, pszDebug, bEnableLinger );
		#endregion
		internal bool CloseConnection( HSteamNetConnection hPeer, int nReason, string pszDebug, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnableLinger )
		{
			using var str__pszDebug = new Utf8StringToNative( pszDebug );
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CloseConnection( Self, hPeer, nReason, str__pszDebug.Pointer, bEnableLinger );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CloseListenSocket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CloseListenSocket", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_CloseListenSocket( IntPtr self, HSteamListenSocket hSocket );
		internal bool _CloseListenSocket( HSteamListenSocket hSocket ) => _SteamAPI_ISteamNetworkingSockets_CloseListenSocket( Self, hSocket );
		#endregion
		internal bool CloseListenSocket( HSteamListenSocket hSocket )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CloseListenSocket( Self, hSocket );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_SetConnectionUserData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionUserData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_SetConnectionUserData( IntPtr self, HSteamNetConnection hPeer, long nUserData );
		internal bool _SetConnectionUserData( HSteamNetConnection hPeer, long nUserData ) => _SteamAPI_ISteamNetworkingSockets_SetConnectionUserData( Self, hPeer, nUserData );
		#endregion
		internal bool SetConnectionUserData( HSteamNetConnection hPeer, long nUserData )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_SetConnectionUserData( Self, hPeer, nUserData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetConnectionUserData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionUserData", CallingConvention = Platform.CC ) ]
		internal static extern long _SteamAPI_ISteamNetworkingSockets_GetConnectionUserData( IntPtr self, HSteamNetConnection hPeer );
		internal long _GetConnectionUserData( HSteamNetConnection hPeer ) => _SteamAPI_ISteamNetworkingSockets_GetConnectionUserData( Self, hPeer );
		#endregion
		internal long GetConnectionUserData( HSteamNetConnection hPeer )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetConnectionUserData( Self, hPeer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_SetConnectionName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionName", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingSockets_SetConnectionName( IntPtr self, HSteamNetConnection hPeer, IntPtr pszName );
		internal void _SetConnectionName( HSteamNetConnection hPeer, IntPtr pszName ) => _SteamAPI_ISteamNetworkingSockets_SetConnectionName( Self, hPeer, pszName );
		#endregion
		internal void SetConnectionName( HSteamNetConnection hPeer, string pszName )
		{
			using var str__pszName = new Utf8StringToNative( pszName );
			_SteamAPI_ISteamNetworkingSockets_SetConnectionName( Self, hPeer, str__pszName.Pointer );
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetConnectionName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionName", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_GetConnectionName( IntPtr self, HSteamNetConnection hPeer, IntPtr pszName, int nMaxLen );
		internal bool _GetConnectionName( HSteamNetConnection hPeer, IntPtr pszName, int nMaxLen ) => _SteamAPI_ISteamNetworkingSockets_GetConnectionName( Self, hPeer, pszName, nMaxLen );
		#endregion
		internal bool GetConnectionName( HSteamNetConnection hPeer, out string pszName, int nMaxLen )
		{
			using var mem__pszName = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetConnectionName( Self, hPeer, mem__pszName.Ptr, nMaxLen );
			pszName = Utility.MemoryToString( mem__pszName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_SendMessageToConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SendMessageToConnection", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_SendMessageToConnection( IntPtr self, HSteamNetConnection hConn, IntPtr pData, uint cbData, int nSendFlags, ref long pOutMessageNumber );
		internal EResult _SendMessageToConnection( HSteamNetConnection hConn, IntPtr pData, uint cbData, int nSendFlags, ref long pOutMessageNumber ) => _SteamAPI_ISteamNetworkingSockets_SendMessageToConnection( Self, hConn, pData, cbData, nSendFlags, ref pOutMessageNumber );
		#endregion
		internal EResult SendMessageToConnection( HSteamNetConnection hConn, IntPtr pData, uint cbData, int nSendFlags, ref long pOutMessageNumber )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_SendMessageToConnection( Self, hConn, pData, cbData, nSendFlags, ref pOutMessageNumber );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_SendMessages
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SendMessages", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingSockets_SendMessages( IntPtr self, int nMessages, NetMsg** pMessages, long* pOutMessageNumberOrResult );
		internal void _SendMessages( int nMessages, NetMsg** pMessages, long* pOutMessageNumberOrResult ) => _SteamAPI_ISteamNetworkingSockets_SendMessages( Self, nMessages, pMessages, pOutMessageNumberOrResult );
		#endregion
		internal void SendMessages( int nMessages, NetMsg** pMessages, long* pOutMessageNumberOrResult )
		{
			_SteamAPI_ISteamNetworkingSockets_SendMessages( Self, nMessages, pMessages, pOutMessageNumberOrResult );
		}
		
		#region SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection( IntPtr self, HSteamNetConnection hConn );
		internal EResult _FlushMessagesOnConnection( HSteamNetConnection hConn ) => _SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection( Self, hConn );
		#endregion
		internal EResult FlushMessagesOnConnection( HSteamNetConnection hConn )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection( Self, hConn );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection( IntPtr self, HSteamNetConnection hConn, IntPtr ppOutMessages, int nMaxMessages );
		internal int _ReceiveMessagesOnConnection( HSteamNetConnection hConn, IntPtr ppOutMessages, int nMaxMessages ) => _SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection( Self, hConn, ppOutMessages, nMaxMessages );
		#endregion
		internal int ReceiveMessagesOnConnection( HSteamNetConnection hConn, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection( Self, hConn, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetConnectionInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionInfo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_GetConnectionInfo( IntPtr self, HSteamNetConnection hConn, ref SteamNetConnectionInfo_t pInfo );
		internal bool _GetConnectionInfo( HSteamNetConnection hConn, ref SteamNetConnectionInfo_t pInfo ) => _SteamAPI_ISteamNetworkingSockets_GetConnectionInfo( Self, hConn, ref pInfo );
		#endregion
		internal bool GetConnectionInfo( HSteamNetConnection hConn, ref SteamNetConnectionInfo_t pInfo )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetConnectionInfo( Self, hConn, ref pInfo );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetConnectionRealTimeStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionRealTimeStatus", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_GetConnectionRealTimeStatus( IntPtr self, HSteamNetConnection hConn, ref SteamNetConnectionRealTimeStatus_t pStatus, int nLanes, SteamNetConnectionRealTimeLaneStatus_t* pLanes );
		internal EResult _GetConnectionRealTimeStatus( HSteamNetConnection hConn, ref SteamNetConnectionRealTimeStatus_t pStatus, int nLanes, SteamNetConnectionRealTimeLaneStatus_t* pLanes ) => _SteamAPI_ISteamNetworkingSockets_GetConnectionRealTimeStatus( Self, hConn, ref pStatus, nLanes, pLanes );
		#endregion
		internal EResult GetConnectionRealTimeStatus( HSteamNetConnection hConn, ref SteamNetConnectionRealTimeStatus_t pStatus, int nLanes, SteamNetConnectionRealTimeLaneStatus_t* pLanes )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetConnectionRealTimeStatus( Self, hConn, ref pStatus, nLanes, pLanes );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus( IntPtr self, HSteamNetConnection hConn, IntPtr pszBuf, int cbBuf );
		internal int _GetDetailedConnectionStatus( HSteamNetConnection hConn, IntPtr pszBuf, int cbBuf ) => _SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus( Self, hConn, pszBuf, cbBuf );
		#endregion
		internal int GetDetailedConnectionStatus( HSteamNetConnection hConn, out string pszBuf, int cbBuf )
		{
			using var mem__pszBuf = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus( Self, hConn, mem__pszBuf.Ptr, cbBuf );
			pszBuf = Utility.MemoryToString( mem__pszBuf );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress( IntPtr self, HSteamListenSocket hSocket, ref SteamNetworkingIPAddr address );
		internal bool _GetListenSocketAddress( HSteamListenSocket hSocket, ref SteamNetworkingIPAddr address ) => _SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress( Self, hSocket, ref address );
		#endregion
		internal bool GetListenSocketAddress( HSteamListenSocket hSocket, ref SteamNetworkingIPAddr address )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress( Self, hSocket, ref address );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CreateSocketPair
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateSocketPair", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_CreateSocketPair( IntPtr self, HSteamNetConnection* pOutConnection1, HSteamNetConnection* pOutConnection2, [ MarshalAs( UnmanagedType.U1 ) ] bool bUseNetworkLoopback, ref SteamNetworkingIdentity pIdentity1, ref SteamNetworkingIdentity pIdentity2 );
		internal bool _CreateSocketPair( HSteamNetConnection* pOutConnection1, HSteamNetConnection* pOutConnection2, [ MarshalAs( UnmanagedType.U1 ) ] bool bUseNetworkLoopback, ref SteamNetworkingIdentity pIdentity1, ref SteamNetworkingIdentity pIdentity2 ) => _SteamAPI_ISteamNetworkingSockets_CreateSocketPair( Self, pOutConnection1, pOutConnection2, bUseNetworkLoopback, ref pIdentity1, ref pIdentity2 );
		#endregion
		internal bool CreateSocketPair( HSteamNetConnection* pOutConnection1, HSteamNetConnection* pOutConnection2, [ MarshalAs( UnmanagedType.U1 ) ] bool bUseNetworkLoopback, ref SteamNetworkingIdentity pIdentity1, ref SteamNetworkingIdentity pIdentity2 )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreateSocketPair( Self, pOutConnection1, pOutConnection2, bUseNetworkLoopback, ref pIdentity1, ref pIdentity2 );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ConfigureConnectionLanes
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConfigureConnectionLanes", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_ConfigureConnectionLanes( IntPtr self, HSteamNetConnection hConn, int nNumLanes, int* pLanePriorities, ushort* pLaneWeights );
		internal EResult _ConfigureConnectionLanes( HSteamNetConnection hConn, int nNumLanes, int* pLanePriorities, ushort* pLaneWeights ) => _SteamAPI_ISteamNetworkingSockets_ConfigureConnectionLanes( Self, hConn, nNumLanes, pLanePriorities, pLaneWeights );
		#endregion
		internal EResult ConfigureConnectionLanes( HSteamNetConnection hConn, int nNumLanes, int* pLanePriorities, ushort* pLaneWeights )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ConfigureConnectionLanes( Self, hConn, nNumLanes, pLanePriorities, pLaneWeights );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetIdentity
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetIdentity", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_GetIdentity( IntPtr self, ref SteamNetworkingIdentity pIdentity );
		internal bool _GetIdentity( ref SteamNetworkingIdentity pIdentity ) => _SteamAPI_ISteamNetworkingSockets_GetIdentity( Self, ref pIdentity );
		#endregion
		internal bool GetIdentity( ref SteamNetworkingIdentity pIdentity )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetIdentity( Self, ref pIdentity );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_InitAuthentication
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_InitAuthentication", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingAvailability _SteamAPI_ISteamNetworkingSockets_InitAuthentication( IntPtr self );
		internal ESteamNetworkingAvailability _InitAuthentication(  ) => _SteamAPI_ISteamNetworkingSockets_InitAuthentication( Self );
		#endregion
		internal ESteamNetworkingAvailability InitAuthentication()
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_InitAuthentication( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingAvailability _SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus( IntPtr self, ref SteamNetAuthenticationStatus_t pDetails );
		internal ESteamNetworkingAvailability _GetAuthenticationStatus( ref SteamNetAuthenticationStatus_t pDetails ) => _SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus( Self, ref pDetails );
		#endregion
		internal ESteamNetworkingAvailability GetAuthenticationStatus( ref SteamNetAuthenticationStatus_t pDetails )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus( Self, ref pDetails );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CreatePollGroup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreatePollGroup", CallingConvention = Platform.CC ) ]
		internal static extern HSteamNetPollGroup _SteamAPI_ISteamNetworkingSockets_CreatePollGroup( IntPtr self );
		internal HSteamNetPollGroup _CreatePollGroup(  ) => _SteamAPI_ISteamNetworkingSockets_CreatePollGroup( Self );
		#endregion
		internal HSteamNetPollGroup CreatePollGroup()
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreatePollGroup( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_DestroyPollGroup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_DestroyPollGroup", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_DestroyPollGroup( IntPtr self, HSteamNetPollGroup hPollGroup );
		internal bool _DestroyPollGroup( HSteamNetPollGroup hPollGroup ) => _SteamAPI_ISteamNetworkingSockets_DestroyPollGroup( Self, hPollGroup );
		#endregion
		internal bool DestroyPollGroup( HSteamNetPollGroup hPollGroup )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_DestroyPollGroup( Self, hPollGroup );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup( IntPtr self, HSteamNetConnection hConn, HSteamNetPollGroup hPollGroup );
		internal bool _SetConnectionPollGroup( HSteamNetConnection hConn, HSteamNetPollGroup hPollGroup ) => _SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup( Self, hConn, hPollGroup );
		#endregion
		internal bool SetConnectionPollGroup( HSteamNetConnection hConn, HSteamNetPollGroup hPollGroup )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup( Self, hConn, hPollGroup );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup( IntPtr self, HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages );
		internal int _ReceiveMessagesOnPollGroup( HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages ) => _SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup( Self, hPollGroup, ppOutMessages, nMaxMessages );
		#endregion
		internal int ReceiveMessagesOnPollGroup( HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup( Self, hPollGroup, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket( IntPtr self, IntPtr pvTicket, int cbTicket, SteamDatagramRelayAuthTicket* pOutParsedTicket );
		internal bool _ReceivedRelayAuthTicket( IntPtr pvTicket, int cbTicket, SteamDatagramRelayAuthTicket* pOutParsedTicket ) => _SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket( Self, pvTicket, cbTicket, pOutParsedTicket );
		#endregion
		internal bool ReceivedRelayAuthTicket( IntPtr pvTicket, int cbTicket, SteamDatagramRelayAuthTicket* pOutParsedTicket )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket( Self, pvTicket, cbTicket, pOutParsedTicket );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer( IntPtr self, ref SteamNetworkingIdentity identityGameServer, int nRemoteVirtualPort, SteamDatagramRelayAuthTicket* pOutParsedTicket );
		internal int _FindRelayAuthTicketForServer( ref SteamNetworkingIdentity identityGameServer, int nRemoteVirtualPort, SteamDatagramRelayAuthTicket* pOutParsedTicket ) => _SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer( Self, ref identityGameServer, nRemoteVirtualPort, pOutParsedTicket );
		#endregion
		internal int FindRelayAuthTicketForServer( ref SteamNetworkingIdentity identityGameServer, int nRemoteVirtualPort, SteamDatagramRelayAuthTicket* pOutParsedTicket )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer( Self, ref identityGameServer, nRemoteVirtualPort, pOutParsedTicket );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer", CallingConvention = Platform.CC ) ]
		internal static extern HSteamNetConnection _SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer( IntPtr self, ref SteamNetworkingIdentity identityTarget, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamNetConnection _ConnectToHostedDedicatedServer( ref SteamNetworkingIdentity identityTarget, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer( Self, ref identityTarget, nRemoteVirtualPort, nOptions, pOptions );
		#endregion
		internal HSteamNetConnection ConnectToHostedDedicatedServer( ref SteamNetworkingIdentity identityTarget, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer( Self, ref identityTarget, nRemoteVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort", CallingConvention = Platform.CC ) ]
		internal static extern ushort _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort( IntPtr self );
		internal ushort _GetHostedDedicatedServerPort(  ) => _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort( Self );
		#endregion
		internal ushort GetHostedDedicatedServerPort()
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID", CallingConvention = Platform.CC ) ]
		internal static extern SteamNetworkingPOPID _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID( IntPtr self );
		internal SteamNetworkingPOPID _GetHostedDedicatedServerPOPID(  ) => _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID( Self );
		#endregion
		internal SteamNetworkingPOPID GetHostedDedicatedServerPOPID()
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress( IntPtr self, ref SteamDatagramHostedAddress pRouting );
		internal EResult _GetHostedDedicatedServerAddress( ref SteamDatagramHostedAddress pRouting ) => _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress( Self, ref pRouting );
		#endregion
		internal EResult GetHostedDedicatedServerAddress( ref SteamDatagramHostedAddress pRouting )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress( Self, ref pRouting );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket", CallingConvention = Platform.CC ) ]
		internal static extern HSteamListenSocket _SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket( IntPtr self, int nLocalVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamListenSocket _CreateHostedDedicatedServerListenSocket( int nLocalVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket( Self, nLocalVirtualPort, nOptions, pOptions );
		#endregion
		internal HSteamListenSocket CreateHostedDedicatedServerListenSocket( int nLocalVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket( Self, nLocalVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin( IntPtr self, ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob );
		internal EResult _GetGameCoordinatorServerLogin( ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob ) => _SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin( Self, ref pLoginInfo, ref pcbSignedBlob, pBlob );
		#endregion
		internal EResult GetGameCoordinatorServerLogin( ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin( Self, ref pLoginInfo, ref pcbSignedBlob, pBlob );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling", CallingConvention = Platform.CC ) ]
		internal static extern HSteamNetConnection _SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling( IntPtr self, IntPtr pSignaling, ref SteamNetworkingIdentity pPeerIdentity, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamNetConnection _ConnectP2PCustomSignaling( IntPtr pSignaling, ref SteamNetworkingIdentity pPeerIdentity, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling( Self, pSignaling, ref pPeerIdentity, nRemoteVirtualPort, nOptions, pOptions );
		#endregion
		internal HSteamNetConnection ConnectP2PCustomSignaling( IntPtr pSignaling, ref SteamNetworkingIdentity pPeerIdentity, int nRemoteVirtualPort, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling( Self, pSignaling, ref pPeerIdentity, nRemoteVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal( IntPtr self, IntPtr pMsg, int cbMsg, IntPtr pContext );
		internal bool _ReceivedP2PCustomSignal( IntPtr pMsg, int cbMsg, IntPtr pContext ) => _SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal( Self, pMsg, cbMsg, pContext );
		#endregion
		internal bool ReceivedP2PCustomSignal( IntPtr pMsg, int cbMsg, IntPtr pContext )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal( Self, pMsg, cbMsg, pContext );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetCertificateRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetCertificateRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_GetCertificateRequest( IntPtr self, ref int pcbBlob, IntPtr pBlob, ref NetErrorMessage errMsg );
		internal bool _GetCertificateRequest( ref int pcbBlob, IntPtr pBlob, ref NetErrorMessage errMsg ) => _SteamAPI_ISteamNetworkingSockets_GetCertificateRequest( Self, ref pcbBlob, pBlob, ref errMsg );
		#endregion
		internal bool GetCertificateRequest( ref int pcbBlob, IntPtr pBlob, ref NetErrorMessage errMsg )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetCertificateRequest( Self, ref pcbBlob, pBlob, ref errMsg );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_SetCertificate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetCertificate", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_SetCertificate( IntPtr self, IntPtr pCertificate, int cbCertificate, ref NetErrorMessage errMsg );
		internal bool _SetCertificate( IntPtr pCertificate, int cbCertificate, ref NetErrorMessage errMsg ) => _SteamAPI_ISteamNetworkingSockets_SetCertificate( Self, pCertificate, cbCertificate, ref errMsg );
		#endregion
		internal bool SetCertificate( IntPtr pCertificate, int cbCertificate, ref NetErrorMessage errMsg )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_SetCertificate( Self, pCertificate, cbCertificate, ref errMsg );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_ResetIdentity
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ResetIdentity", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingSockets_ResetIdentity( IntPtr self, ref SteamNetworkingIdentity pIdentity );
		internal void _ResetIdentity( ref SteamNetworkingIdentity pIdentity ) => _SteamAPI_ISteamNetworkingSockets_ResetIdentity( Self, ref pIdentity );
		#endregion
		internal void ResetIdentity( ref SteamNetworkingIdentity pIdentity )
		{
			_SteamAPI_ISteamNetworkingSockets_ResetIdentity( Self, ref pIdentity );
		}
		
		#region SteamAPI_ISteamNetworkingSockets_RunCallbacks
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_RunCallbacks", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingSockets_RunCallbacks( IntPtr self );
		internal void _RunCallbacks(  ) => _SteamAPI_ISteamNetworkingSockets_RunCallbacks( Self );
		#endregion
		internal void RunCallbacks()
		{
			_SteamAPI_ISteamNetworkingSockets_RunCallbacks( Self );
		}
		
		#region SteamAPI_ISteamNetworkingSockets_BeginAsyncRequestFakeIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_BeginAsyncRequestFakeIP", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingSockets_BeginAsyncRequestFakeIP( IntPtr self, int nNumPorts );
		internal bool _BeginAsyncRequestFakeIP( int nNumPorts ) => _SteamAPI_ISteamNetworkingSockets_BeginAsyncRequestFakeIP( Self, nNumPorts );
		#endregion
		internal bool BeginAsyncRequestFakeIP( int nNumPorts )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_BeginAsyncRequestFakeIP( Self, nNumPorts );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetFakeIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetFakeIP", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingSockets_GetFakeIP( IntPtr self, int idxFirstPort, ref SteamNetworkingFakeIPResult_t pInfo );
		internal void _GetFakeIP( int idxFirstPort, ref SteamNetworkingFakeIPResult_t pInfo ) => _SteamAPI_ISteamNetworkingSockets_GetFakeIP( Self, idxFirstPort, ref pInfo );
		#endregion
		internal void GetFakeIP( int idxFirstPort, ref SteamNetworkingFakeIPResult_t pInfo )
		{
			_SteamAPI_ISteamNetworkingSockets_GetFakeIP( Self, idxFirstPort, ref pInfo );
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2PFakeIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2PFakeIP", CallingConvention = Platform.CC ) ]
		internal static extern HSteamListenSocket _SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2PFakeIP( IntPtr self, int idxFakePort, int nOptions, SteamNetworkingConfigValue_t* pOptions );
		internal HSteamListenSocket _CreateListenSocketP2PFakeIP( int idxFakePort, int nOptions, SteamNetworkingConfigValue_t* pOptions ) => _SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2PFakeIP( Self, idxFakePort, nOptions, pOptions );
		#endregion
		internal HSteamListenSocket CreateListenSocketP2PFakeIP( int idxFakePort, int nOptions, SteamNetworkingConfigValue_t* pOptions )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2PFakeIP( Self, idxFakePort, nOptions, pOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_GetRemoteFakeIPForConnection
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetRemoteFakeIPForConnection", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingSockets_GetRemoteFakeIPForConnection( IntPtr self, HSteamNetConnection hConn, SteamNetworkingIPAddr* pOutAddr );
		internal EResult _GetRemoteFakeIPForConnection( HSteamNetConnection hConn, SteamNetworkingIPAddr* pOutAddr ) => _SteamAPI_ISteamNetworkingSockets_GetRemoteFakeIPForConnection( Self, hConn, pOutAddr );
		#endregion
		internal EResult GetRemoteFakeIPForConnection( HSteamNetConnection hConn, SteamNetworkingIPAddr* pOutAddr )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_GetRemoteFakeIPForConnection( Self, hConn, pOutAddr );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingSockets_CreateFakeUDPPort
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateFakeUDPPort", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamNetworkingSockets_CreateFakeUDPPort( IntPtr self, int idxFakeServerPort );
		internal IntPtr _CreateFakeUDPPort( int idxFakeServerPort ) => _SteamAPI_ISteamNetworkingSockets_CreateFakeUDPPort( Self, idxFakeServerPort );
		#endregion
		internal IntPtr CreateFakeUDPPort( int idxFakeServerPort )
		{
			var returnValue = _SteamAPI_ISteamNetworkingSockets_CreateFakeUDPPort( Self, idxFakeServerPort );
			return returnValue;
		}
		
	}
}
