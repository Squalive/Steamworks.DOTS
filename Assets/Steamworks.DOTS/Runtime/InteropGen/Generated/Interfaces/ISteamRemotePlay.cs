using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamRemotePlay
	{
		public const string Version = "STEAMREMOTEPLAY_INTERFACE_VERSION003";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamRemotePlay_v003", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamRemotePlay_v003();
		/// Construct use accessor to find interface
		public ISteamRemotePlay( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamRemotePlay_v003();
			}
		}
		public ISteamRemotePlay( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamRemotePlay_GetSessionCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionCount", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamRemotePlay_GetSessionCount( IntPtr self );
		internal uint _GetSessionCount(  ) => _SteamAPI_ISteamRemotePlay_GetSessionCount( Self );
		#endregion
		internal uint GetSessionCount()
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_GetSessionCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_GetSessionID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionID", CallingConvention = Platform.CC ) ]
		internal static extern RemotePlaySessionID_t _SteamAPI_ISteamRemotePlay_GetSessionID( IntPtr self, int iSessionIndex );
		internal RemotePlaySessionID_t _GetSessionID( int iSessionIndex ) => _SteamAPI_ISteamRemotePlay_GetSessionID( Self, iSessionIndex );
		#endregion
		internal RemotePlaySessionID_t GetSessionID( int iSessionIndex )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_GetSessionID( Self, iSessionIndex );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_GetSessionSteamID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionSteamID", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamRemotePlay_GetSessionSteamID( IntPtr self, RemotePlaySessionID_t unSessionID );
		internal SteamId _GetSessionSteamID( RemotePlaySessionID_t unSessionID ) => _SteamAPI_ISteamRemotePlay_GetSessionSteamID( Self, unSessionID );
		#endregion
		internal SteamId GetSessionSteamID( RemotePlaySessionID_t unSessionID )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_GetSessionSteamID( Self, unSessionID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_GetSessionClientName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionClientName", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamRemotePlay_GetSessionClientName( IntPtr self, RemotePlaySessionID_t unSessionID );
		internal Utf8StringPtr _GetSessionClientName( RemotePlaySessionID_t unSessionID ) => _SteamAPI_ISteamRemotePlay_GetSessionClientName( Self, unSessionID );
		#endregion
		internal string GetSessionClientName( RemotePlaySessionID_t unSessionID )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_GetSessionClientName( Self, unSessionID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_GetSessionClientFormFactor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionClientFormFactor", CallingConvention = Platform.CC ) ]
		internal static extern ESteamDeviceFormFactor _SteamAPI_ISteamRemotePlay_GetSessionClientFormFactor( IntPtr self, RemotePlaySessionID_t unSessionID );
		internal ESteamDeviceFormFactor _GetSessionClientFormFactor( RemotePlaySessionID_t unSessionID ) => _SteamAPI_ISteamRemotePlay_GetSessionClientFormFactor( Self, unSessionID );
		#endregion
		internal ESteamDeviceFormFactor GetSessionClientFormFactor( RemotePlaySessionID_t unSessionID )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_GetSessionClientFormFactor( Self, unSessionID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_BGetSessionClientResolution
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_BGetSessionClientResolution", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemotePlay_BGetSessionClientResolution( IntPtr self, RemotePlaySessionID_t unSessionID, ref int pnResolutionX, ref int pnResolutionY );
		internal bool _BGetSessionClientResolution( RemotePlaySessionID_t unSessionID, ref int pnResolutionX, ref int pnResolutionY ) => _SteamAPI_ISteamRemotePlay_BGetSessionClientResolution( Self, unSessionID, ref pnResolutionX, ref pnResolutionY );
		#endregion
		internal bool BGetSessionClientResolution( RemotePlaySessionID_t unSessionID, ref int pnResolutionX, ref int pnResolutionY )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_BGetSessionClientResolution( Self, unSessionID, ref pnResolutionX, ref pnResolutionY );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_ShowRemotePlayTogetherUI
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_ShowRemotePlayTogetherUI", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemotePlay_ShowRemotePlayTogetherUI( IntPtr self );
		internal bool _ShowRemotePlayTogetherUI(  ) => _SteamAPI_ISteamRemotePlay_ShowRemotePlayTogetherUI( Self );
		#endregion
		internal bool ShowRemotePlayTogetherUI()
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_ShowRemotePlayTogetherUI( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_BSendRemotePlayTogetherInvite
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_BSendRemotePlayTogetherInvite", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemotePlay_BSendRemotePlayTogetherInvite( IntPtr self, SteamId steamIDFriend );
		internal bool _BSendRemotePlayTogetherInvite( SteamId steamIDFriend ) => _SteamAPI_ISteamRemotePlay_BSendRemotePlayTogetherInvite( Self, steamIDFriend );
		#endregion
		internal bool BSendRemotePlayTogetherInvite( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_BSendRemotePlayTogetherInvite( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_BEnableRemotePlayTogetherDirectInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_BEnableRemotePlayTogetherDirectInput", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemotePlay_BEnableRemotePlayTogetherDirectInput( IntPtr self );
		internal bool _BEnableRemotePlayTogetherDirectInput(  ) => _SteamAPI_ISteamRemotePlay_BEnableRemotePlayTogetherDirectInput( Self );
		#endregion
		internal bool BEnableRemotePlayTogetherDirectInput()
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_BEnableRemotePlayTogetherDirectInput( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_DisableRemotePlayTogetherDirectInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_DisableRemotePlayTogetherDirectInput", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamRemotePlay_DisableRemotePlayTogetherDirectInput( IntPtr self );
		internal void _DisableRemotePlayTogetherDirectInput(  ) => _SteamAPI_ISteamRemotePlay_DisableRemotePlayTogetherDirectInput( Self );
		#endregion
		internal void DisableRemotePlayTogetherDirectInput()
		{
			_SteamAPI_ISteamRemotePlay_DisableRemotePlayTogetherDirectInput( Self );
		}
		
		#region SteamAPI_ISteamRemotePlay_GetInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_GetInput", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamRemotePlay_GetInput( IntPtr self, ref RemotePlayInput_t pInput, uint unMaxEvents );
		internal uint _GetInput( ref RemotePlayInput_t pInput, uint unMaxEvents ) => _SteamAPI_ISteamRemotePlay_GetInput( Self, ref pInput, unMaxEvents );
		#endregion
		internal uint GetInput( ref RemotePlayInput_t pInput, uint unMaxEvents )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_GetInput( Self, ref pInput, unMaxEvents );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_SetMouseVisibility
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_SetMouseVisibility", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamRemotePlay_SetMouseVisibility( IntPtr self, RemotePlaySessionID_t unSessionID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVisible );
		internal void _SetMouseVisibility( RemotePlaySessionID_t unSessionID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVisible ) => _SteamAPI_ISteamRemotePlay_SetMouseVisibility( Self, unSessionID, bVisible );
		#endregion
		internal void SetMouseVisibility( RemotePlaySessionID_t unSessionID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVisible )
		{
			_SteamAPI_ISteamRemotePlay_SetMouseVisibility( Self, unSessionID, bVisible );
		}
		
		#region SteamAPI_ISteamRemotePlay_SetMousePosition
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_SetMousePosition", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamRemotePlay_SetMousePosition( IntPtr self, RemotePlaySessionID_t unSessionID, float flNormalizedX, float flNormalizedY );
		internal void _SetMousePosition( RemotePlaySessionID_t unSessionID, float flNormalizedX, float flNormalizedY ) => _SteamAPI_ISteamRemotePlay_SetMousePosition( Self, unSessionID, flNormalizedX, flNormalizedY );
		#endregion
		internal void SetMousePosition( RemotePlaySessionID_t unSessionID, float flNormalizedX, float flNormalizedY )
		{
			_SteamAPI_ISteamRemotePlay_SetMousePosition( Self, unSessionID, flNormalizedX, flNormalizedY );
		}
		
		#region SteamAPI_ISteamRemotePlay_CreateMouseCursor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_CreateMouseCursor", CallingConvention = Platform.CC ) ]
		internal static extern RemotePlayCursorID_t _SteamAPI_ISteamRemotePlay_CreateMouseCursor( IntPtr self, int nWidth, int nHeight, int nHotX, int nHotY, IntPtr pBGRA, int nPitch );
		internal RemotePlayCursorID_t _CreateMouseCursor( int nWidth, int nHeight, int nHotX, int nHotY, IntPtr pBGRA, int nPitch ) => _SteamAPI_ISteamRemotePlay_CreateMouseCursor( Self, nWidth, nHeight, nHotX, nHotY, pBGRA, nPitch );
		#endregion
		internal RemotePlayCursorID_t CreateMouseCursor( int nWidth, int nHeight, int nHotX, int nHotY, IntPtr pBGRA, int nPitch )
		{
			var returnValue = _SteamAPI_ISteamRemotePlay_CreateMouseCursor( Self, nWidth, nHeight, nHotX, nHotY, pBGRA, nPitch );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemotePlay_SetMouseCursor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemotePlay_SetMouseCursor", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamRemotePlay_SetMouseCursor( IntPtr self, RemotePlaySessionID_t unSessionID, RemotePlayCursorID_t unCursorID );
		internal void _SetMouseCursor( RemotePlaySessionID_t unSessionID, RemotePlayCursorID_t unCursorID ) => _SteamAPI_ISteamRemotePlay_SetMouseCursor( Self, unSessionID, unCursorID );
		#endregion
		internal void SetMouseCursor( RemotePlaySessionID_t unSessionID, RemotePlayCursorID_t unCursorID )
		{
			_SteamAPI_ISteamRemotePlay_SetMouseCursor( Self, unSessionID, unCursorID );
		}
		
	}
}
