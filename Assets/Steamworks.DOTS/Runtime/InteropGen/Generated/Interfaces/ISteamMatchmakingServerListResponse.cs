using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMatchmakingServerListResponse
	{
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		/// Construct use accessor to find interface
		public ISteamMatchmakingServerListResponse( bool isGameServer )
		{
			Self = IntPtr.Zero;
		}
		public ISteamMatchmakingServerListResponse( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded( IntPtr self, HServerListRequest hRequest, int iServer );
		internal void _ServerResponded( HServerListRequest hRequest, int iServer ) => _SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded( Self, hRequest, iServer );
		#endregion
		internal void ServerResponded( HServerListRequest hRequest, int iServer )
		{
			_SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded( Self, hRequest, iServer );
		}
		
		#region SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond( IntPtr self, HServerListRequest hRequest, int iServer );
		internal void _ServerFailedToRespond( HServerListRequest hRequest, int iServer ) => _SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond( Self, hRequest, iServer );
		#endregion
		internal void ServerFailedToRespond( HServerListRequest hRequest, int iServer )
		{
			_SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond( Self, hRequest, iServer );
		}
		
		#region SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete( IntPtr self, HServerListRequest hRequest, EMatchMakingServerResponse response );
		internal void _RefreshComplete( HServerListRequest hRequest, EMatchMakingServerResponse response ) => _SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete( Self, hRequest, response );
		#endregion
		internal void RefreshComplete( HServerListRequest hRequest, EMatchMakingServerResponse response )
		{
			_SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete( Self, hRequest, response );
		}
		
	}
}
