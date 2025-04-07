using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamNetworking
	{
		public const string Version = "SteamNetworking006";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworking_v006", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamNetworking_v006();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerNetworking_v006", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerNetworking_v006();
		/// Construct use accessor to find interface
		public ISteamNetworking( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamNetworking_v006();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerNetworking_v006();
			}
		}
		public ISteamNetworking( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamNetworking_SendP2PPacket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_SendP2PPacket", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_SendP2PPacket( IntPtr self, SteamId steamIDRemote, IntPtr pubData, uint cubData, EP2PSend eP2PSendType, int nChannel );
		#endregion
		internal bool SendP2PPacket( SteamId steamIDRemote, IntPtr pubData, uint cubData, EP2PSend eP2PSendType, int nChannel )
		{
			var returnValue = _SteamAPI_ISteamNetworking_SendP2PPacket( Self, steamIDRemote, pubData, cubData, eP2PSendType, nChannel );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_IsP2PPacketAvailable
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_IsP2PPacketAvailable", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_IsP2PPacketAvailable( IntPtr self, ref uint pcubMsgSize, int nChannel );
		#endregion
		internal bool IsP2PPacketAvailable( ref uint pcubMsgSize, int nChannel )
		{
			var returnValue = _SteamAPI_ISteamNetworking_IsP2PPacketAvailable( Self, ref pcubMsgSize, nChannel );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_ReadP2PPacket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_ReadP2PPacket", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_ReadP2PPacket( IntPtr self, IntPtr pubDest, uint cubDest, ref uint pcubMsgSize, ref SteamId psteamIDRemote, int nChannel );
		#endregion
		internal bool ReadP2PPacket( IntPtr pubDest, uint cubDest, ref uint pcubMsgSize, ref SteamId psteamIDRemote, int nChannel )
		{
			var returnValue = _SteamAPI_ISteamNetworking_ReadP2PPacket( Self, pubDest, cubDest, ref pcubMsgSize, ref psteamIDRemote, nChannel );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser( IntPtr self, SteamId steamIDRemote );
		#endregion
		internal bool AcceptP2PSessionWithUser( SteamId steamIDRemote )
		{
			var returnValue = _SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser( Self, steamIDRemote );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_CloseP2PSessionWithUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_CloseP2PSessionWithUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_CloseP2PSessionWithUser( IntPtr self, SteamId steamIDRemote );
		#endregion
		internal bool CloseP2PSessionWithUser( SteamId steamIDRemote )
		{
			var returnValue = _SteamAPI_ISteamNetworking_CloseP2PSessionWithUser( Self, steamIDRemote );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_CloseP2PChannelWithUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_CloseP2PChannelWithUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_CloseP2PChannelWithUser( IntPtr self, SteamId steamIDRemote, int nChannel );
		#endregion
		internal bool CloseP2PChannelWithUser( SteamId steamIDRemote, int nChannel )
		{
			var returnValue = _SteamAPI_ISteamNetworking_CloseP2PChannelWithUser( Self, steamIDRemote, nChannel );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_GetP2PSessionState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_GetP2PSessionState", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_GetP2PSessionState( IntPtr self, SteamId steamIDRemote, ref P2PSessionState_t pConnectionState );
		#endregion
		internal bool GetP2PSessionState( SteamId steamIDRemote, ref P2PSessionState_t pConnectionState )
		{
			var returnValue = _SteamAPI_ISteamNetworking_GetP2PSessionState( Self, steamIDRemote, ref pConnectionState );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_AllowP2PPacketRelay
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_AllowP2PPacketRelay", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworking_AllowP2PPacketRelay( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllow );
		#endregion
		internal bool AllowP2PPacketRelay( [ MarshalAs( UnmanagedType.U1 ) ] bool bAllow )
		{
			var returnValue = _SteamAPI_ISteamNetworking_AllowP2PPacketRelay( Self, bAllow );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworking_CreateP2PConnectionSocket
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworking_CreateP2PConnectionSocket", CallingConvention = Platform.CC ) ]
		internal static extern SNetSocket_t _SteamAPI_ISteamNetworking_CreateP2PConnectionSocket( IntPtr self, SteamId steamIDTarget, int nVirtualPort, int nTimeoutSec, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowUseOfPacketRelay );
		#endregion
		internal SNetSocket_t CreateP2PConnectionSocket( SteamId steamIDTarget, int nVirtualPort, int nTimeoutSec, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowUseOfPacketRelay )
		{
			var returnValue = _SteamAPI_ISteamNetworking_CreateP2PConnectionSocket( Self, steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay );
			return returnValue;
		}
		
	}
}
