using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMatchmakingRulesResponse
	{
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		/// Construct use accessor to find interface
		public ISteamMatchmakingRulesResponse( bool isGameServer )
		{
			Self = IntPtr.Zero;
		}
		public ISteamMatchmakingRulesResponse( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded( IntPtr self, IntPtr pchRule, IntPtr pchValue );
		internal void _RulesResponded( IntPtr pchRule, IntPtr pchValue ) => _SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded( Self, pchRule, pchValue );
		#endregion
		internal void RulesResponded( string pchRule, string pchValue )
		{
			using var str__pchRule = new Utf8StringToNative( pchRule );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			_SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded( Self, str__pchRule.Pointer, str__pchValue.Pointer );
		}
		
		#region SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond( IntPtr self );
		internal void _RulesFailedToRespond(  ) => _SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond( Self );
		#endregion
		internal void RulesFailedToRespond()
		{
			_SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond( Self );
		}
		
		#region SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete( IntPtr self );
		internal void _RulesRefreshComplete(  ) => _SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete( Self );
		#endregion
		internal void RulesRefreshComplete()
		{
			_SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete( Self );
		}
		
	}
}
