using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamClient
	{
		public const string Version = "SteamClient021";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		/// Construct use accessor to find interface
		public ISteamClient( bool isGameServer )
		{
			Self = IntPtr.Zero;
		}
		public ISteamClient( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamClient_CreateSteamPipe
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe", CallingConvention = Platform.CC ) ]
		internal static extern HSteamPipe _SteamAPI_ISteamClient_CreateSteamPipe( IntPtr self );
		#endregion
		internal HSteamPipe CreateSteamPipe()
		{
			var returnValue = _SteamAPI_ISteamClient_CreateSteamPipe( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_BReleaseSteamPipe
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamClient_BReleaseSteamPipe( IntPtr self, HSteamPipe hSteamPipe );
		#endregion
		internal bool BReleaseSteamPipe( HSteamPipe hSteamPipe )
		{
			var returnValue = _SteamAPI_ISteamClient_BReleaseSteamPipe( Self, hSteamPipe );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_ConnectToGlobalUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser", CallingConvention = Platform.CC ) ]
		internal static extern HSteamUser _SteamAPI_ISteamClient_ConnectToGlobalUser( IntPtr self, HSteamPipe hSteamPipe );
		#endregion
		internal HSteamUser ConnectToGlobalUser( HSteamPipe hSteamPipe )
		{
			var returnValue = _SteamAPI_ISteamClient_ConnectToGlobalUser( Self, hSteamPipe );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_CreateLocalUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser", CallingConvention = Platform.CC ) ]
		internal static extern HSteamUser _SteamAPI_ISteamClient_CreateLocalUser( IntPtr self, ref HSteamPipe phSteamPipe, EAccountType eAccountType );
		#endregion
		internal HSteamUser CreateLocalUser( ref HSteamPipe phSteamPipe, EAccountType eAccountType )
		{
			var returnValue = _SteamAPI_ISteamClient_CreateLocalUser( Self, ref phSteamPipe, eAccountType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_ReleaseUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_ReleaseUser", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamClient_ReleaseUser( IntPtr self, HSteamPipe hSteamPipe, HSteamUser hUser );
		#endregion
		internal void ReleaseUser( HSteamPipe hSteamPipe, HSteamUser hUser )
		{
			_SteamAPI_ISteamClient_ReleaseUser( Self, hSteamPipe, hUser );
		}
		
		#region SteamAPI_ISteamClient_GetISteamUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUser", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamUser( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamUser( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamUser( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamGameServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamGameServer( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamGameServer( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamGameServer( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_SetLocalIPBinding
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamClient_SetLocalIPBinding( IntPtr self, ref SteamIPAddress_t unIP, ushort usPort );
		#endregion
		internal void SetLocalIPBinding( ref SteamIPAddress_t unIP, ushort usPort )
		{
			_SteamAPI_ISteamClient_SetLocalIPBinding( Self, ref unIP, usPort );
		}
		
		#region SteamAPI_ISteamClient_GetISteamFriends
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamFriends( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamFriends( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamFriends( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamUtils
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamUtils( IntPtr self, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamUtils( HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamUtils( Self, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamMatchmaking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamMatchmaking( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamMatchmaking( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamMatchmaking( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamMatchmakingServers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamMatchmakingServers( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamMatchmakingServers( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamMatchmakingServers( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamGenericInterface
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamGenericInterface( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamGenericInterface( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamGenericInterface( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamUserStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamUserStats( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamUserStats( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamUserStats( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamGameServerStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamGameServerStats( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamGameServerStats( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamGameServerStats( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamApps
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamApps", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamApps( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamApps( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamApps( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamNetworking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamNetworking( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamNetworking( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamNetworking( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamRemoteStorage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamRemoteStorage( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamRemoteStorage( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamRemoteStorage( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamScreenshots
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamScreenshots( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamScreenshots( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamScreenshots( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamGameSearch
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameSearch", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamGameSearch( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamGameSearch( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamGameSearch( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetIPCCallCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamClient_GetIPCCallCount( IntPtr self );
		#endregion
		internal uint GetIPCCallCount()
		{
			var returnValue = _SteamAPI_ISteamClient_GetIPCCallCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_SetWarningMessageHook
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamClient_SetWarningMessageHook( IntPtr self, IntPtr pFunction );
		#endregion
		internal void SetWarningMessageHook( IntPtr pFunction )
		{
			_SteamAPI_ISteamClient_SetWarningMessageHook( Self, pFunction );
		}
		
		#region SteamAPI_ISteamClient_BShutdownIfAllPipesClosed
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamClient_BShutdownIfAllPipesClosed( IntPtr self );
		#endregion
		internal bool BShutdownIfAllPipesClosed()
		{
			var returnValue = _SteamAPI_ISteamClient_BShutdownIfAllPipesClosed( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamHTTP
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamHTTP( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamHTTP( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamHTTP( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamController
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamController", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamController( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamController( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamController( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamUGC
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamUGC( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamUGC( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamUGC( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamMusic
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamMusic( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamMusic( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamMusic( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamMusicRemote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamMusicRemote( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamMusicRemote( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamMusicRemote( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamHTMLSurface
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamHTMLSurface( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamHTMLSurface( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamHTMLSurface( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamInventory
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamInventory( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamInventory( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamInventory( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamVideo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamVideo( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamVideo( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamVideo( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamParentalSettings
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamParentalSettings", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamParentalSettings( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamParentalSettings( HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamParentalSettings( Self, hSteamuser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamInput", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamInput( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamInput( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamInput( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamParties
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamParties", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamParties( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamParties( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamParties( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamClient_GetISteamRemotePlay
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemotePlay", CallingConvention = Platform.CC ) ]
		internal static extern IntPtr _SteamAPI_ISteamClient_GetISteamRemotePlay( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, IntPtr pchVersion );
		#endregion
		internal IntPtr GetISteamRemotePlay( HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion )
		{
			using var str__pchVersion = new Utf8StringToNative( pchVersion );
			var returnValue = _SteamAPI_ISteamClient_GetISteamRemotePlay( Self, hSteamUser, hSteamPipe, str__pchVersion.Pointer );
			return returnValue;
		}
		
	}
}
