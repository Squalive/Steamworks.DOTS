using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamScreenshots
	{
		public const string Version = "STEAMSCREENSHOTS_INTERFACE_VERSION003";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamScreenshots_v003", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamScreenshots_v003();
		/// Construct use accessor to find interface
		public ISteamScreenshots( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamScreenshots_v003();
			}
		}
		public ISteamScreenshots( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamScreenshots_WriteScreenshot
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_WriteScreenshot", CallingConvention = Platform.CC ) ]
		internal static extern ScreenshotHandle _SteamAPI_ISteamScreenshots_WriteScreenshot( IntPtr self, IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight );
		#endregion
		internal ScreenshotHandle WriteScreenshot( IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight )
		{
			var returnValue = _SteamAPI_ISteamScreenshots_WriteScreenshot( Self, pubRGB, cubRGB, nWidth, nHeight );
			return returnValue;
		}
		
		#region SteamAPI_ISteamScreenshots_AddScreenshotToLibrary
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_AddScreenshotToLibrary", CallingConvention = Platform.CC ) ]
		internal static extern ScreenshotHandle _SteamAPI_ISteamScreenshots_AddScreenshotToLibrary( IntPtr self, IntPtr pchFilename, IntPtr pchThumbnailFilename, int nWidth, int nHeight );
		#endregion
		internal ScreenshotHandle AddScreenshotToLibrary( string pchFilename, string pchThumbnailFilename, int nWidth, int nHeight )
		{
			using var str__pchFilename = new Utf8StringToNative( pchFilename );
			using var str__pchThumbnailFilename = new Utf8StringToNative( pchThumbnailFilename );
			var returnValue = _SteamAPI_ISteamScreenshots_AddScreenshotToLibrary( Self, str__pchFilename.Pointer, str__pchThumbnailFilename.Pointer, nWidth, nHeight );
			return returnValue;
		}
		
		#region SteamAPI_ISteamScreenshots_TriggerScreenshot
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_TriggerScreenshot", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamScreenshots_TriggerScreenshot( IntPtr self );
		#endregion
		internal void TriggerScreenshot()
		{
			_SteamAPI_ISteamScreenshots_TriggerScreenshot( Self );
		}
		
		#region SteamAPI_ISteamScreenshots_HookScreenshots
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_HookScreenshots", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamScreenshots_HookScreenshots( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bHook );
		#endregion
		internal void HookScreenshots( [ MarshalAs( UnmanagedType.U1 ) ] bool bHook )
		{
			_SteamAPI_ISteamScreenshots_HookScreenshots( Self, bHook );
		}
		
		#region SteamAPI_ISteamScreenshots_SetLocation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_SetLocation", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamScreenshots_SetLocation( IntPtr self, ScreenshotHandle hScreenshot, IntPtr pchLocation );
		#endregion
		internal bool SetLocation( ScreenshotHandle hScreenshot, string pchLocation )
		{
			using var str__pchLocation = new Utf8StringToNative( pchLocation );
			var returnValue = _SteamAPI_ISteamScreenshots_SetLocation( Self, hScreenshot, str__pchLocation.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamScreenshots_TagUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_TagUser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamScreenshots_TagUser( IntPtr self, ScreenshotHandle hScreenshot, SteamId steamID );
		#endregion
		internal bool TagUser( ScreenshotHandle hScreenshot, SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamScreenshots_TagUser( Self, hScreenshot, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamScreenshots_TagPublishedFile
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_TagPublishedFile", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamScreenshots_TagPublishedFile( IntPtr self, ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID );
		#endregion
		internal bool TagPublishedFile( ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamScreenshots_TagPublishedFile( Self, hScreenshot, unPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamScreenshots_IsScreenshotsHooked
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_IsScreenshotsHooked", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamScreenshots_IsScreenshotsHooked( IntPtr self );
		#endregion
		internal bool IsScreenshotsHooked()
		{
			var returnValue = _SteamAPI_ISteamScreenshots_IsScreenshotsHooked( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary", CallingConvention = Platform.CC ) ]
		internal static extern ScreenshotHandle _SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary( IntPtr self, EVRScreenshotType eType, IntPtr pchFilename, IntPtr pchVRFilename );
		#endregion
		internal ScreenshotHandle AddVRScreenshotToLibrary( EVRScreenshotType eType, string pchFilename, string pchVRFilename )
		{
			using var str__pchFilename = new Utf8StringToNative( pchFilename );
			using var str__pchVRFilename = new Utf8StringToNative( pchVRFilename );
			var returnValue = _SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary( Self, eType, str__pchFilename.Pointer, str__pchVRFilename.Pointer );
			return returnValue;
		}
		
	}
}
