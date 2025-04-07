using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamNetworkingFakeUDPPort
	{
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		/// Construct use accessor to find interface
		public ISteamNetworkingFakeUDPPort( bool isGameServer )
		{
			Self = IntPtr.Zero;
		}
		public ISteamNetworkingFakeUDPPort( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamNetworkingFakeUDPPort_DestroyFakeUDPPort
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingFakeUDPPort_DestroyFakeUDPPort", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingFakeUDPPort_DestroyFakeUDPPort( IntPtr self );
		#endregion
		internal void DestroyFakeUDPPort()
		{
			_SteamAPI_ISteamNetworkingFakeUDPPort_DestroyFakeUDPPort( Self );
		}
		
		#region SteamAPI_ISteamNetworkingFakeUDPPort_SendMessageToFakeIP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingFakeUDPPort_SendMessageToFakeIP", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingFakeUDPPort_SendMessageToFakeIP( IntPtr self, ref SteamNetworkingIPAddr remoteAddress, IntPtr pData, uint cbData, int nSendFlags );
		#endregion
		internal EResult SendMessageToFakeIP( ref SteamNetworkingIPAddr remoteAddress, IntPtr pData, uint cbData, int nSendFlags )
		{
			var returnValue = _SteamAPI_ISteamNetworkingFakeUDPPort_SendMessageToFakeIP( Self, ref remoteAddress, pData, cbData, nSendFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingFakeUDPPort_ReceiveMessages
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingFakeUDPPort_ReceiveMessages", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingFakeUDPPort_ReceiveMessages( IntPtr self, IntPtr ppOutMessages, int nMaxMessages );
		#endregion
		internal int ReceiveMessages( IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _SteamAPI_ISteamNetworkingFakeUDPPort_ReceiveMessages( Self, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingFakeUDPPort_ScheduleCleanup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingFakeUDPPort_ScheduleCleanup", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamNetworkingFakeUDPPort_ScheduleCleanup( IntPtr self, ref SteamNetworkingIPAddr remoteAddress );
		#endregion
		internal void ScheduleCleanup( ref SteamNetworkingIPAddr remoteAddress )
		{
			_SteamAPI_ISteamNetworkingFakeUDPPort_ScheduleCleanup( Self, ref remoteAddress );
		}
		
	}
}
