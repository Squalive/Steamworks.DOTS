using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamHTMLSurface
	{
		public const string Version = "STEAMHTMLSURFACE_INTERFACE_VERSION_005";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamHTMLSurface_v005", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamHTMLSurface_v005();
		/// Construct use accessor to find interface
		public ISteamHTMLSurface( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamHTMLSurface_v005();
			}
		}
		public ISteamHTMLSurface( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamHTMLSurface_Init
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_Init", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTMLSurface_Init( IntPtr self );
		internal bool _Init(  ) => _SteamAPI_ISteamHTMLSurface_Init( Self );
		#endregion
		internal bool Init()
		{
			var returnValue = _SteamAPI_ISteamHTMLSurface_Init( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTMLSurface_Shutdown
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_Shutdown", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTMLSurface_Shutdown( IntPtr self );
		internal bool _Shutdown(  ) => _SteamAPI_ISteamHTMLSurface_Shutdown( Self );
		#endregion
		internal bool Shutdown()
		{
			var returnValue = _SteamAPI_ISteamHTMLSurface_Shutdown( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTMLSurface_CreateBrowser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_CreateBrowser", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamHTMLSurface_CreateBrowser( IntPtr self, IntPtr pchUserAgent, IntPtr pchUserCSS );
		internal SteamAPICall_t _CreateBrowser( IntPtr pchUserAgent, IntPtr pchUserCSS ) => _SteamAPI_ISteamHTMLSurface_CreateBrowser( Self, pchUserAgent, pchUserCSS );
		#endregion
		internal CallResult<HTML_BrowserReady_t> CreateBrowser( string pchUserAgent, string pchUserCSS )
		{
			using var str__pchUserAgent = new Utf8StringToNative( pchUserAgent );
			using var str__pchUserCSS = new Utf8StringToNative( pchUserCSS );
			var returnValue = _SteamAPI_ISteamHTMLSurface_CreateBrowser( Self, str__pchUserAgent.Pointer, str__pchUserCSS.Pointer );
			return new CallResult<HTML_BrowserReady_t>( returnValue );
		}
		
		#region SteamAPI_ISteamHTMLSurface_RemoveBrowser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_RemoveBrowser", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_RemoveBrowser( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _RemoveBrowser( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_RemoveBrowser( Self, unBrowserHandle );
		#endregion
		internal void RemoveBrowser( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_RemoveBrowser( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_LoadURL
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_LoadURL", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_LoadURL( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr pchURL, IntPtr pchPostData );
		internal void _LoadURL( HHTMLBrowser unBrowserHandle, IntPtr pchURL, IntPtr pchPostData ) => _SteamAPI_ISteamHTMLSurface_LoadURL( Self, unBrowserHandle, pchURL, pchPostData );
		#endregion
		internal void LoadURL( HHTMLBrowser unBrowserHandle, string pchURL, string pchPostData )
		{
			using var str__pchURL = new Utf8StringToNative( pchURL );
			using var str__pchPostData = new Utf8StringToNative( pchPostData );
			_SteamAPI_ISteamHTMLSurface_LoadURL( Self, unBrowserHandle, str__pchURL.Pointer, str__pchPostData.Pointer );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetSize
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetSize", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetSize( IntPtr self, HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight );
		internal void _SetSize( HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight ) => _SteamAPI_ISteamHTMLSurface_SetSize( Self, unBrowserHandle, unWidth, unHeight );
		#endregion
		internal void SetSize( HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight )
		{
			_SteamAPI_ISteamHTMLSurface_SetSize( Self, unBrowserHandle, unWidth, unHeight );
		}
		
		#region SteamAPI_ISteamHTMLSurface_StopLoad
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopLoad", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_StopLoad( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _StopLoad( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_StopLoad( Self, unBrowserHandle );
		#endregion
		internal void StopLoad( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_StopLoad( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_Reload
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_Reload", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_Reload( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _Reload( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_Reload( Self, unBrowserHandle );
		#endregion
		internal void Reload( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_Reload( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_GoBack
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoBack", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_GoBack( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _GoBack( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_GoBack( Self, unBrowserHandle );
		#endregion
		internal void GoBack( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_GoBack( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_GoForward
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoForward", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_GoForward( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _GoForward( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_GoForward( Self, unBrowserHandle );
		#endregion
		internal void GoForward( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_GoForward( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_AddHeader
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_AddHeader", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_AddHeader( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr pchKey, IntPtr pchValue );
		internal void _AddHeader( HHTMLBrowser unBrowserHandle, IntPtr pchKey, IntPtr pchValue ) => _SteamAPI_ISteamHTMLSurface_AddHeader( Self, unBrowserHandle, pchKey, pchValue );
		#endregion
		internal void AddHeader( HHTMLBrowser unBrowserHandle, string pchKey, string pchValue )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			_SteamAPI_ISteamHTMLSurface_AddHeader( Self, unBrowserHandle, str__pchKey.Pointer, str__pchValue.Pointer );
		}
		
		#region SteamAPI_ISteamHTMLSurface_ExecuteJavascript
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_ExecuteJavascript", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_ExecuteJavascript( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr pchScript );
		internal void _ExecuteJavascript( HHTMLBrowser unBrowserHandle, IntPtr pchScript ) => _SteamAPI_ISteamHTMLSurface_ExecuteJavascript( Self, unBrowserHandle, pchScript );
		#endregion
		internal void ExecuteJavascript( HHTMLBrowser unBrowserHandle, string pchScript )
		{
			using var str__pchScript = new Utf8StringToNative( pchScript );
			_SteamAPI_ISteamHTMLSurface_ExecuteJavascript( Self, unBrowserHandle, str__pchScript.Pointer );
		}
		
		#region SteamAPI_ISteamHTMLSurface_MouseUp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseUp", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_MouseUp( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr eMouseButton );
		internal void _MouseUp( HHTMLBrowser unBrowserHandle, IntPtr eMouseButton ) => _SteamAPI_ISteamHTMLSurface_MouseUp( Self, unBrowserHandle, eMouseButton );
		#endregion
		internal void MouseUp( HHTMLBrowser unBrowserHandle, IntPtr eMouseButton )
		{
			_SteamAPI_ISteamHTMLSurface_MouseUp( Self, unBrowserHandle, eMouseButton );
		}
		
		#region SteamAPI_ISteamHTMLSurface_MouseDown
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDown", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_MouseDown( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr eMouseButton );
		internal void _MouseDown( HHTMLBrowser unBrowserHandle, IntPtr eMouseButton ) => _SteamAPI_ISteamHTMLSurface_MouseDown( Self, unBrowserHandle, eMouseButton );
		#endregion
		internal void MouseDown( HHTMLBrowser unBrowserHandle, IntPtr eMouseButton )
		{
			_SteamAPI_ISteamHTMLSurface_MouseDown( Self, unBrowserHandle, eMouseButton );
		}
		
		#region SteamAPI_ISteamHTMLSurface_MouseDoubleClick
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDoubleClick", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_MouseDoubleClick( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr eMouseButton );
		internal void _MouseDoubleClick( HHTMLBrowser unBrowserHandle, IntPtr eMouseButton ) => _SteamAPI_ISteamHTMLSurface_MouseDoubleClick( Self, unBrowserHandle, eMouseButton );
		#endregion
		internal void MouseDoubleClick( HHTMLBrowser unBrowserHandle, IntPtr eMouseButton )
		{
			_SteamAPI_ISteamHTMLSurface_MouseDoubleClick( Self, unBrowserHandle, eMouseButton );
		}
		
		#region SteamAPI_ISteamHTMLSurface_MouseMove
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseMove", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_MouseMove( IntPtr self, HHTMLBrowser unBrowserHandle, int x, int y );
		internal void _MouseMove( HHTMLBrowser unBrowserHandle, int x, int y ) => _SteamAPI_ISteamHTMLSurface_MouseMove( Self, unBrowserHandle, x, y );
		#endregion
		internal void MouseMove( HHTMLBrowser unBrowserHandle, int x, int y )
		{
			_SteamAPI_ISteamHTMLSurface_MouseMove( Self, unBrowserHandle, x, y );
		}
		
		#region SteamAPI_ISteamHTMLSurface_MouseWheel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseWheel", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_MouseWheel( IntPtr self, HHTMLBrowser unBrowserHandle, int nDelta );
		internal void _MouseWheel( HHTMLBrowser unBrowserHandle, int nDelta ) => _SteamAPI_ISteamHTMLSurface_MouseWheel( Self, unBrowserHandle, nDelta );
		#endregion
		internal void MouseWheel( HHTMLBrowser unBrowserHandle, int nDelta )
		{
			_SteamAPI_ISteamHTMLSurface_MouseWheel( Self, unBrowserHandle, nDelta );
		}
		
		#region SteamAPI_ISteamHTMLSurface_KeyDown
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyDown", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_KeyDown( IntPtr self, HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers, [ MarshalAs( UnmanagedType.U1 ) ] bool bIsSystemKey );
		internal void _KeyDown( HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers, [ MarshalAs( UnmanagedType.U1 ) ] bool bIsSystemKey ) => _SteamAPI_ISteamHTMLSurface_KeyDown( Self, unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers, bIsSystemKey );
		#endregion
		internal void KeyDown( HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers, [ MarshalAs( UnmanagedType.U1 ) ] bool bIsSystemKey )
		{
			_SteamAPI_ISteamHTMLSurface_KeyDown( Self, unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers, bIsSystemKey );
		}
		
		#region SteamAPI_ISteamHTMLSurface_KeyUp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyUp", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_KeyUp( IntPtr self, HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers );
		internal void _KeyUp( HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers ) => _SteamAPI_ISteamHTMLSurface_KeyUp( Self, unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers );
		#endregion
		internal void KeyUp( HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers )
		{
			_SteamAPI_ISteamHTMLSurface_KeyUp( Self, unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers );
		}
		
		#region SteamAPI_ISteamHTMLSurface_KeyChar
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyChar", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_KeyChar( IntPtr self, HHTMLBrowser unBrowserHandle, uint cUnicodeChar, IntPtr eHTMLKeyModifiers );
		internal void _KeyChar( HHTMLBrowser unBrowserHandle, uint cUnicodeChar, IntPtr eHTMLKeyModifiers ) => _SteamAPI_ISteamHTMLSurface_KeyChar( Self, unBrowserHandle, cUnicodeChar, eHTMLKeyModifiers );
		#endregion
		internal void KeyChar( HHTMLBrowser unBrowserHandle, uint cUnicodeChar, IntPtr eHTMLKeyModifiers )
		{
			_SteamAPI_ISteamHTMLSurface_KeyChar( Self, unBrowserHandle, cUnicodeChar, eHTMLKeyModifiers );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetHorizontalScroll
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetHorizontalScroll", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetHorizontalScroll( IntPtr self, HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll );
		internal void _SetHorizontalScroll( HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll ) => _SteamAPI_ISteamHTMLSurface_SetHorizontalScroll( Self, unBrowserHandle, nAbsolutePixelScroll );
		#endregion
		internal void SetHorizontalScroll( HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll )
		{
			_SteamAPI_ISteamHTMLSurface_SetHorizontalScroll( Self, unBrowserHandle, nAbsolutePixelScroll );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetVerticalScroll
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetVerticalScroll", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetVerticalScroll( IntPtr self, HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll );
		internal void _SetVerticalScroll( HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll ) => _SteamAPI_ISteamHTMLSurface_SetVerticalScroll( Self, unBrowserHandle, nAbsolutePixelScroll );
		#endregion
		internal void SetVerticalScroll( HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll )
		{
			_SteamAPI_ISteamHTMLSurface_SetVerticalScroll( Self, unBrowserHandle, nAbsolutePixelScroll );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetKeyFocus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetKeyFocus", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetKeyFocus( IntPtr self, HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bHasKeyFocus );
		internal void _SetKeyFocus( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bHasKeyFocus ) => _SteamAPI_ISteamHTMLSurface_SetKeyFocus( Self, unBrowserHandle, bHasKeyFocus );
		#endregion
		internal void SetKeyFocus( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bHasKeyFocus )
		{
			_SteamAPI_ISteamHTMLSurface_SetKeyFocus( Self, unBrowserHandle, bHasKeyFocus );
		}
		
		#region SteamAPI_ISteamHTMLSurface_ViewSource
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_ViewSource", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_ViewSource( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _ViewSource( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_ViewSource( Self, unBrowserHandle );
		#endregion
		internal void ViewSource( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_ViewSource( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_CopyToClipboard
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_CopyToClipboard", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_CopyToClipboard( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _CopyToClipboard( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_CopyToClipboard( Self, unBrowserHandle );
		#endregion
		internal void CopyToClipboard( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_CopyToClipboard( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_PasteFromClipboard
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_PasteFromClipboard", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_PasteFromClipboard( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _PasteFromClipboard( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_PasteFromClipboard( Self, unBrowserHandle );
		#endregion
		internal void PasteFromClipboard( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_PasteFromClipboard( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_Find
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_Find", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_Find( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr pchSearchStr, [ MarshalAs( UnmanagedType.U1 ) ] bool bCurrentlyInFind, [ MarshalAs( UnmanagedType.U1 ) ] bool bReverse );
		internal void _Find( HHTMLBrowser unBrowserHandle, IntPtr pchSearchStr, [ MarshalAs( UnmanagedType.U1 ) ] bool bCurrentlyInFind, [ MarshalAs( UnmanagedType.U1 ) ] bool bReverse ) => _SteamAPI_ISteamHTMLSurface_Find( Self, unBrowserHandle, pchSearchStr, bCurrentlyInFind, bReverse );
		#endregion
		internal void Find( HHTMLBrowser unBrowserHandle, string pchSearchStr, [ MarshalAs( UnmanagedType.U1 ) ] bool bCurrentlyInFind, [ MarshalAs( UnmanagedType.U1 ) ] bool bReverse )
		{
			using var str__pchSearchStr = new Utf8StringToNative( pchSearchStr );
			_SteamAPI_ISteamHTMLSurface_Find( Self, unBrowserHandle, str__pchSearchStr.Pointer, bCurrentlyInFind, bReverse );
		}
		
		#region SteamAPI_ISteamHTMLSurface_StopFind
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopFind", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_StopFind( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _StopFind( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_StopFind( Self, unBrowserHandle );
		#endregion
		internal void StopFind( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_StopFind( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_GetLinkAtPosition
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_GetLinkAtPosition", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_GetLinkAtPosition( IntPtr self, HHTMLBrowser unBrowserHandle, int x, int y );
		internal void _GetLinkAtPosition( HHTMLBrowser unBrowserHandle, int x, int y ) => _SteamAPI_ISteamHTMLSurface_GetLinkAtPosition( Self, unBrowserHandle, x, y );
		#endregion
		internal void GetLinkAtPosition( HHTMLBrowser unBrowserHandle, int x, int y )
		{
			_SteamAPI_ISteamHTMLSurface_GetLinkAtPosition( Self, unBrowserHandle, x, y );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetCookie
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetCookie", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetCookie( IntPtr self, IntPtr pchHostname, IntPtr pchKey, IntPtr pchValue, IntPtr pchPath, RTime32 nExpires, [ MarshalAs( UnmanagedType.U1 ) ] bool bSecure, [ MarshalAs( UnmanagedType.U1 ) ] bool bHTTPOnly );
		internal void _SetCookie( IntPtr pchHostname, IntPtr pchKey, IntPtr pchValue, IntPtr pchPath, RTime32 nExpires, [ MarshalAs( UnmanagedType.U1 ) ] bool bSecure, [ MarshalAs( UnmanagedType.U1 ) ] bool bHTTPOnly ) => _SteamAPI_ISteamHTMLSurface_SetCookie( Self, pchHostname, pchKey, pchValue, pchPath, nExpires, bSecure, bHTTPOnly );
		#endregion
		internal void SetCookie( string pchHostname, string pchKey, string pchValue, string pchPath, RTime32 nExpires, [ MarshalAs( UnmanagedType.U1 ) ] bool bSecure, [ MarshalAs( UnmanagedType.U1 ) ] bool bHTTPOnly )
		{
			using var str__pchHostname = new Utf8StringToNative( pchHostname );
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			using var str__pchPath = new Utf8StringToNative( pchPath );
			_SteamAPI_ISteamHTMLSurface_SetCookie( Self, str__pchHostname.Pointer, str__pchKey.Pointer, str__pchValue.Pointer, str__pchPath.Pointer, nExpires, bSecure, bHTTPOnly );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetPageScaleFactor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetPageScaleFactor", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetPageScaleFactor( IntPtr self, HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY );
		internal void _SetPageScaleFactor( HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY ) => _SteamAPI_ISteamHTMLSurface_SetPageScaleFactor( Self, unBrowserHandle, flZoom, nPointX, nPointY );
		#endregion
		internal void SetPageScaleFactor( HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY )
		{
			_SteamAPI_ISteamHTMLSurface_SetPageScaleFactor( Self, unBrowserHandle, flZoom, nPointX, nPointY );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetBackgroundMode
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetBackgroundMode", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetBackgroundMode( IntPtr self, HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bBackgroundMode );
		internal void _SetBackgroundMode( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bBackgroundMode ) => _SteamAPI_ISteamHTMLSurface_SetBackgroundMode( Self, unBrowserHandle, bBackgroundMode );
		#endregion
		internal void SetBackgroundMode( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bBackgroundMode )
		{
			_SteamAPI_ISteamHTMLSurface_SetBackgroundMode( Self, unBrowserHandle, bBackgroundMode );
		}
		
		#region SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor( IntPtr self, HHTMLBrowser unBrowserHandle, float flDPIScaling );
		internal void _SetDPIScalingFactor( HHTMLBrowser unBrowserHandle, float flDPIScaling ) => _SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor( Self, unBrowserHandle, flDPIScaling );
		#endregion
		internal void SetDPIScalingFactor( HHTMLBrowser unBrowserHandle, float flDPIScaling )
		{
			_SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor( Self, unBrowserHandle, flDPIScaling );
		}
		
		#region SteamAPI_ISteamHTMLSurface_OpenDeveloperTools
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_OpenDeveloperTools", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_OpenDeveloperTools( IntPtr self, HHTMLBrowser unBrowserHandle );
		internal void _OpenDeveloperTools( HHTMLBrowser unBrowserHandle ) => _SteamAPI_ISteamHTMLSurface_OpenDeveloperTools( Self, unBrowserHandle );
		#endregion
		internal void OpenDeveloperTools( HHTMLBrowser unBrowserHandle )
		{
			_SteamAPI_ISteamHTMLSurface_OpenDeveloperTools( Self, unBrowserHandle );
		}
		
		#region SteamAPI_ISteamHTMLSurface_AllowStartRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_AllowStartRequest", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_AllowStartRequest( IntPtr self, HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowed );
		internal void _AllowStartRequest( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowed ) => _SteamAPI_ISteamHTMLSurface_AllowStartRequest( Self, unBrowserHandle, bAllowed );
		#endregion
		internal void AllowStartRequest( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowed )
		{
			_SteamAPI_ISteamHTMLSurface_AllowStartRequest( Self, unBrowserHandle, bAllowed );
		}
		
		#region SteamAPI_ISteamHTMLSurface_JSDialogResponse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_JSDialogResponse", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_JSDialogResponse( IntPtr self, HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bResult );
		internal void _JSDialogResponse( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bResult ) => _SteamAPI_ISteamHTMLSurface_JSDialogResponse( Self, unBrowserHandle, bResult );
		#endregion
		internal void JSDialogResponse( HHTMLBrowser unBrowserHandle, [ MarshalAs( UnmanagedType.U1 ) ] bool bResult )
		{
			_SteamAPI_ISteamHTMLSurface_JSDialogResponse( Self, unBrowserHandle, bResult );
		}
		
		#region SteamAPI_ISteamHTMLSurface_FileLoadDialogResponse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTMLSurface_FileLoadDialogResponse", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamHTMLSurface_FileLoadDialogResponse( IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles );
		internal void _FileLoadDialogResponse( HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles ) => _SteamAPI_ISteamHTMLSurface_FileLoadDialogResponse( Self, unBrowserHandle, pchSelectedFiles );
		#endregion
		internal void FileLoadDialogResponse( HHTMLBrowser unBrowserHandle, string pchSelectedFiles )
		{
			using var str__pchSelectedFiles = new Utf8StringToNative( pchSelectedFiles );
			_SteamAPI_ISteamHTMLSurface_FileLoadDialogResponse( Self, unBrowserHandle, str__pchSelectedFiles.Pointer );
		}
		
	}
}
