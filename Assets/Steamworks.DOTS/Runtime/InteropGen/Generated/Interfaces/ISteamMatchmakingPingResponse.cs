using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMatchmakingPingResponse
	{
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		/// Construct use accessor to find interface
		public ISteamMatchmakingPingResponse( bool isGameServer )
		{
			Self = IntPtr.Zero;
		}
		public ISteamMatchmakingPingResponse( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMatchmakingPingResponse_ServerResponded
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerResponded", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingPingResponse_ServerResponded( IntPtr self, ref gameserveritem_t server );
		#endregion
		internal void ServerResponded( ref gameserveritem_t server )
		{
			_SteamAPI_ISteamMatchmakingPingResponse_ServerResponded( Self, ref server );
		}
		
		#region SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond( IntPtr self );
		#endregion
		internal void ServerFailedToRespond()
		{
			_SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond( Self );
		}
		
	}
}
