using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMatchmakingServers
	{
		public const string Version = "SteamMatchMakingServers002";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamMatchmakingServers_v002", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamMatchmakingServers_v002();
		/// Construct use accessor to find interface
		public ISteamMatchmakingServers( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamMatchmakingServers_v002();
			}
		}
		public ISteamMatchmakingServers( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMatchmakingServers_RequestInternetServerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestInternetServerList", CallingConvention = Platform.CC ) ]
		internal static extern HServerListRequest _SteamAPI_ISteamMatchmakingServers_RequestInternetServerList( IntPtr self, AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		internal HServerListRequest _RequestInternetServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_RequestInternetServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
		#endregion
		internal HServerListRequest RequestInternetServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_RequestInternetServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RequestLANServerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestLANServerList", CallingConvention = Platform.CC ) ]
		internal static extern HServerListRequest _SteamAPI_ISteamMatchmakingServers_RequestLANServerList( IntPtr self, AppId_t iApp, IntPtr pRequestServersResponse );
		internal HServerListRequest _RequestLANServerList( AppId_t iApp, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_RequestLANServerList( Self, iApp, pRequestServersResponse );
		#endregion
		internal HServerListRequest RequestLANServerList( AppId_t iApp, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_RequestLANServerList( Self, iApp, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList", CallingConvention = Platform.CC ) ]
		internal static extern HServerListRequest _SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList( IntPtr self, AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		internal HServerListRequest _RequestFriendsServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
		#endregion
		internal HServerListRequest RequestFriendsServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList", CallingConvention = Platform.CC ) ]
		internal static extern HServerListRequest _SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList( IntPtr self, AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		internal HServerListRequest _RequestFavoritesServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
		#endregion
		internal HServerListRequest RequestFavoritesServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList", CallingConvention = Platform.CC ) ]
		internal static extern HServerListRequest _SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList( IntPtr self, AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		internal HServerListRequest _RequestHistoryServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
		#endregion
		internal HServerListRequest RequestHistoryServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList", CallingConvention = Platform.CC ) ]
		internal static extern HServerListRequest _SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList( IntPtr self, AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		internal HServerListRequest _RequestSpectatorServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
		#endregion
		internal HServerListRequest RequestSpectatorServerList( AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList( Self, iApp, ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_ReleaseRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ReleaseRequest", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServers_ReleaseRequest( IntPtr self, HServerListRequest hServerListRequest );
		internal void _ReleaseRequest( HServerListRequest hServerListRequest ) => _SteamAPI_ISteamMatchmakingServers_ReleaseRequest( Self, hServerListRequest );
		#endregion
		internal void ReleaseRequest( HServerListRequest hServerListRequest )
		{
			_SteamAPI_ISteamMatchmakingServers_ReleaseRequest( Self, hServerListRequest );
		}
		
		#region SteamAPI_ISteamMatchmakingServers_GetServerDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerDetails", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamMatchmakingServers_GetServerDetails( IntPtr self, HServerListRequest hRequest, int iServer );
		internal IntPtr _GetServerDetails( HServerListRequest hRequest, int iServer ) => _SteamAPI_ISteamMatchmakingServers_GetServerDetails( Self, hRequest, iServer );
		#endregion
		internal gameserveritem_t GetServerDetails( HServerListRequest hRequest, int iServer )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_GetServerDetails( Self, hRequest, iServer );
			return UnsafeUtility.AsRef<gameserveritem_t>( ( void* ) returnValue );
		}
		
		#region SteamAPI_ISteamMatchmakingServers_CancelQuery
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelQuery", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServers_CancelQuery( IntPtr self, HServerListRequest hRequest );
		internal void _CancelQuery( HServerListRequest hRequest ) => _SteamAPI_ISteamMatchmakingServers_CancelQuery( Self, hRequest );
		#endregion
		internal void CancelQuery( HServerListRequest hRequest )
		{
			_SteamAPI_ISteamMatchmakingServers_CancelQuery( Self, hRequest );
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RefreshQuery
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshQuery", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServers_RefreshQuery( IntPtr self, HServerListRequest hRequest );
		internal void _RefreshQuery( HServerListRequest hRequest ) => _SteamAPI_ISteamMatchmakingServers_RefreshQuery( Self, hRequest );
		#endregion
		internal void RefreshQuery( HServerListRequest hRequest )
		{
			_SteamAPI_ISteamMatchmakingServers_RefreshQuery( Self, hRequest );
		}
		
		#region SteamAPI_ISteamMatchmakingServers_IsRefreshing
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_IsRefreshing", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmakingServers_IsRefreshing( IntPtr self, HServerListRequest hRequest );
		internal bool _IsRefreshing( HServerListRequest hRequest ) => _SteamAPI_ISteamMatchmakingServers_IsRefreshing( Self, hRequest );
		#endregion
		internal bool IsRefreshing( HServerListRequest hRequest )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_IsRefreshing( Self, hRequest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_GetServerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmakingServers_GetServerCount( IntPtr self, HServerListRequest hRequest );
		internal int _GetServerCount( HServerListRequest hRequest ) => _SteamAPI_ISteamMatchmakingServers_GetServerCount( Self, hRequest );
		#endregion
		internal int GetServerCount( HServerListRequest hRequest )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_GetServerCount( Self, hRequest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_RefreshServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshServer", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServers_RefreshServer( IntPtr self, HServerListRequest hRequest, int iServer );
		internal void _RefreshServer( HServerListRequest hRequest, int iServer ) => _SteamAPI_ISteamMatchmakingServers_RefreshServer( Self, hRequest, iServer );
		#endregion
		internal void RefreshServer( HServerListRequest hRequest, int iServer )
		{
			_SteamAPI_ISteamMatchmakingServers_RefreshServer( Self, hRequest, iServer );
		}
		
		#region SteamAPI_ISteamMatchmakingServers_PingServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PingServer", CallingConvention = Platform.CC ) ]
		internal static extern HServerQuery _SteamAPI_ISteamMatchmakingServers_PingServer( IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse );
		internal HServerQuery _PingServer( uint unIP, ushort usPort, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_PingServer( Self, unIP, usPort, pRequestServersResponse );
		#endregion
		internal HServerQuery PingServer( uint unIP, ushort usPort, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_PingServer( Self, unIP, usPort, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_PlayerDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PlayerDetails", CallingConvention = Platform.CC ) ]
		internal static extern HServerQuery _SteamAPI_ISteamMatchmakingServers_PlayerDetails( IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse );
		internal HServerQuery _PlayerDetails( uint unIP, ushort usPort, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_PlayerDetails( Self, unIP, usPort, pRequestServersResponse );
		#endregion
		internal HServerQuery PlayerDetails( uint unIP, ushort usPort, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_PlayerDetails( Self, unIP, usPort, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_ServerRules
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ServerRules", CallingConvention = Platform.CC ) ]
		internal static extern HServerQuery _SteamAPI_ISteamMatchmakingServers_ServerRules( IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse );
		internal HServerQuery _ServerRules( uint unIP, ushort usPort, IntPtr pRequestServersResponse ) => _SteamAPI_ISteamMatchmakingServers_ServerRules( Self, unIP, usPort, pRequestServersResponse );
		#endregion
		internal HServerQuery ServerRules( uint unIP, ushort usPort, IntPtr pRequestServersResponse )
		{
			var returnValue = _SteamAPI_ISteamMatchmakingServers_ServerRules( Self, unIP, usPort, pRequestServersResponse );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmakingServers_CancelServerQuery
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelServerQuery", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServers_CancelServerQuery( IntPtr self, HServerQuery hServerQuery );
		internal void _CancelServerQuery( HServerQuery hServerQuery ) => _SteamAPI_ISteamMatchmakingServers_CancelServerQuery( Self, hServerQuery );
		#endregion
		internal void CancelServerQuery( HServerQuery hServerQuery )
		{
			_SteamAPI_ISteamMatchmakingServers_CancelServerQuery( Self, hServerQuery );
		}
		
	}
}
