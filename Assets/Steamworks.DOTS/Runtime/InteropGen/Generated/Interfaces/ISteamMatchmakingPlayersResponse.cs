using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMatchmakingPlayersResponse
	{
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		/// Construct use accessor to find interface
		public ISteamMatchmakingPlayersResponse( bool isGameServer )
		{
			Self = IntPtr.Zero;
		}
		public ISteamMatchmakingPlayersResponse( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList( IntPtr self, IntPtr pchName, int nScore, float flTimePlayed );
		#endregion
		internal void AddPlayerToList( string pchName, int nScore, float flTimePlayed )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			_SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList( Self, str__pchName.Pointer, nScore, flTimePlayed );
		}
		
		#region SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond( IntPtr self );
		#endregion
		internal void PlayersFailedToRespond()
		{
			_SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond( Self );
		}
		
		#region SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete( IntPtr self );
		#endregion
		internal void PlayersRefreshComplete()
		{
			_SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete( Self );
		}
		
	}
}
