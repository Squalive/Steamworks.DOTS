using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamNetworkingMessages
	{
		public const string Version = "SteamNetworkingMessages002";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingMessages_SteamAPI_v002", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamNetworkingMessages_SteamAPI_v002();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002();
		/// Construct use accessor to find interface
		public ISteamNetworkingMessages( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamNetworkingMessages_SteamAPI_v002();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerNetworkingMessages_SteamAPI_v002();
			}
		}
		public ISteamNetworkingMessages( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamNetworkingMessages_SendMessageToUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingMessages_SendMessageToUser", CallingConvention = Platform.CC ) ]
		internal static extern EResult _SteamAPI_ISteamNetworkingMessages_SendMessageToUser( IntPtr self, ref SteamNetworkingIdentity identityRemote, IntPtr* pubData, uint cubData, int nSendFlags, int nRemoteChannel );
		internal EResult _SendMessageToUser( ref SteamNetworkingIdentity identityRemote, IntPtr* pubData, uint cubData, int nSendFlags, int nRemoteChannel ) => _SteamAPI_ISteamNetworkingMessages_SendMessageToUser( Self, ref identityRemote, pubData, cubData, nSendFlags, nRemoteChannel );
		#endregion
		internal EResult SendMessageToUser( ref SteamNetworkingIdentity identityRemote, IntPtr* pubData, uint cubData, int nSendFlags, int nRemoteChannel )
		{
			var returnValue = _SteamAPI_ISteamNetworkingMessages_SendMessageToUser( Self, ref identityRemote, pubData, cubData, nSendFlags, nRemoteChannel );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingMessages_ReceiveMessagesOnChannel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingMessages_ReceiveMessagesOnChannel", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamNetworkingMessages_ReceiveMessagesOnChannel( IntPtr self, int nLocalChannel, IntPtr ppOutMessages, int nMaxMessages );
		internal int _ReceiveMessagesOnChannel( int nLocalChannel, IntPtr ppOutMessages, int nMaxMessages ) => _SteamAPI_ISteamNetworkingMessages_ReceiveMessagesOnChannel( Self, nLocalChannel, ppOutMessages, nMaxMessages );
		#endregion
		internal int ReceiveMessagesOnChannel( int nLocalChannel, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _SteamAPI_ISteamNetworkingMessages_ReceiveMessagesOnChannel( Self, nLocalChannel, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingMessages_AcceptSessionWithUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingMessages_AcceptSessionWithUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingMessages_AcceptSessionWithUser( IntPtr self, ref SteamNetworkingIdentity identityRemote );
		internal bool _AcceptSessionWithUser( ref SteamNetworkingIdentity identityRemote ) => _SteamAPI_ISteamNetworkingMessages_AcceptSessionWithUser( Self, ref identityRemote );
		#endregion
		internal bool AcceptSessionWithUser( ref SteamNetworkingIdentity identityRemote )
		{
			var returnValue = _SteamAPI_ISteamNetworkingMessages_AcceptSessionWithUser( Self, ref identityRemote );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingMessages_CloseSessionWithUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingMessages_CloseSessionWithUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingMessages_CloseSessionWithUser( IntPtr self, ref SteamNetworkingIdentity identityRemote );
		internal bool _CloseSessionWithUser( ref SteamNetworkingIdentity identityRemote ) => _SteamAPI_ISteamNetworkingMessages_CloseSessionWithUser( Self, ref identityRemote );
		#endregion
		internal bool CloseSessionWithUser( ref SteamNetworkingIdentity identityRemote )
		{
			var returnValue = _SteamAPI_ISteamNetworkingMessages_CloseSessionWithUser( Self, ref identityRemote );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingMessages_CloseChannelWithUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingMessages_CloseChannelWithUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamNetworkingMessages_CloseChannelWithUser( IntPtr self, ref SteamNetworkingIdentity identityRemote, int nLocalChannel );
		internal bool _CloseChannelWithUser( ref SteamNetworkingIdentity identityRemote, int nLocalChannel ) => _SteamAPI_ISteamNetworkingMessages_CloseChannelWithUser( Self, ref identityRemote, nLocalChannel );
		#endregion
		internal bool CloseChannelWithUser( ref SteamNetworkingIdentity identityRemote, int nLocalChannel )
		{
			var returnValue = _SteamAPI_ISteamNetworkingMessages_CloseChannelWithUser( Self, ref identityRemote, nLocalChannel );
			return returnValue;
		}
		
		#region SteamAPI_ISteamNetworkingMessages_GetSessionConnectionInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingMessages_GetSessionConnectionInfo", CallingConvention = Platform.CC ) ]
		internal static extern ESteamNetworkingConnectionState _SteamAPI_ISteamNetworkingMessages_GetSessionConnectionInfo( IntPtr self, ref SteamNetworkingIdentity identityRemote, ref SteamNetConnectionInfo_t pConnectionInfo, ref SteamNetConnectionRealTimeStatus_t pQuickStatus );
		internal ESteamNetworkingConnectionState _GetSessionConnectionInfo( ref SteamNetworkingIdentity identityRemote, ref SteamNetConnectionInfo_t pConnectionInfo, ref SteamNetConnectionRealTimeStatus_t pQuickStatus ) => _SteamAPI_ISteamNetworkingMessages_GetSessionConnectionInfo( Self, ref identityRemote, ref pConnectionInfo, ref pQuickStatus );
		#endregion
		internal ESteamNetworkingConnectionState GetSessionConnectionInfo( ref SteamNetworkingIdentity identityRemote, ref SteamNetConnectionInfo_t pConnectionInfo, ref SteamNetConnectionRealTimeStatus_t pQuickStatus )
		{
			var returnValue = _SteamAPI_ISteamNetworkingMessages_GetSessionConnectionInfo( Self, ref identityRemote, ref pConnectionInfo, ref pQuickStatus );
			return returnValue;
		}
		
	}
}
