using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamUtils
	{
		public const string Version = "SteamUtils010";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamUtils_v010", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamUtils_v010();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerUtils_v010", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerUtils_v010();
		/// Construct use accessor to find interface
		public ISteamUtils( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamUtils_v010();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerUtils_v010();
			}
		}
		public ISteamUtils( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamUtils_GetSecondsSinceAppActive
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceAppActive", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUtils_GetSecondsSinceAppActive( IntPtr self );
		#endregion
		internal uint GetSecondsSinceAppActive()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetSecondsSinceAppActive( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetSecondsSinceComputerActive
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceComputerActive", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUtils_GetSecondsSinceComputerActive( IntPtr self );
		#endregion
		internal uint GetSecondsSinceComputerActive()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetSecondsSinceComputerActive( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetConnectedUniverse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetConnectedUniverse", CallingConvention = Platform.CC ) ]
		internal static extern EUniverse _SteamAPI_ISteamUtils_GetConnectedUniverse( IntPtr self );
		#endregion
		internal EUniverse GetConnectedUniverse()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetConnectedUniverse( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetServerRealTime
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetServerRealTime", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUtils_GetServerRealTime( IntPtr self );
		#endregion
		internal uint GetServerRealTime()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetServerRealTime( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetIPCountry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetIPCountry", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamUtils_GetIPCountry( IntPtr self );
		#endregion
		internal string GetIPCountry()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetIPCountry( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetImageSize
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetImageSize", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_GetImageSize( IntPtr self, int iImage, ref uint pnWidth, ref uint pnHeight );
		#endregion
		internal bool GetImageSize( int iImage, ref uint pnWidth, ref uint pnHeight )
		{
			var returnValue = _SteamAPI_ISteamUtils_GetImageSize( Self, iImage, ref pnWidth, ref pnHeight );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetImageRGBA
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetImageRGBA", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_GetImageRGBA( IntPtr self, int iImage, byte* pubDest, int nDestBufferSize );
		#endregion
		internal bool GetImageRGBA( int iImage, byte* pubDest, int nDestBufferSize )
		{
			var returnValue = _SteamAPI_ISteamUtils_GetImageRGBA( Self, iImage, pubDest, nDestBufferSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetCurrentBatteryPower
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetCurrentBatteryPower", CallingConvention = Platform.CC ) ]
		internal static extern byte _SteamAPI_ISteamUtils_GetCurrentBatteryPower( IntPtr self );
		#endregion
		internal byte GetCurrentBatteryPower()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetCurrentBatteryPower( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetAppID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetAppID", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUtils_GetAppID( IntPtr self );
		#endregion
		internal uint GetAppID()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetAppID( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_SetOverlayNotificationPosition
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationPosition", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUtils_SetOverlayNotificationPosition( IntPtr self, ENotificationPosition eNotificationPosition );
		#endregion
		internal void SetOverlayNotificationPosition( ENotificationPosition eNotificationPosition )
		{
			_SteamAPI_ISteamUtils_SetOverlayNotificationPosition( Self, eNotificationPosition );
		}
		
		#region SteamAPI_ISteamUtils_IsAPICallCompleted
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsAPICallCompleted", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsAPICallCompleted( IntPtr self, SteamAPICall_t hSteamAPICall, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbFailed );
		#endregion
		internal bool IsAPICallCompleted( SteamAPICall_t hSteamAPICall, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbFailed )
		{
			var returnValue = _SteamAPI_ISteamUtils_IsAPICallCompleted( Self, hSteamAPICall, ref pbFailed );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetAPICallFailureReason
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallFailureReason", CallingConvention = Platform.CC ) ]
		internal static extern ESteamAPICallFailure _SteamAPI_ISteamUtils_GetAPICallFailureReason( IntPtr self, SteamAPICall_t hSteamAPICall );
		#endregion
		internal ESteamAPICallFailure GetAPICallFailureReason( SteamAPICall_t hSteamAPICall )
		{
			var returnValue = _SteamAPI_ISteamUtils_GetAPICallFailureReason( Self, hSteamAPICall );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetAPICallResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallResult", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_GetAPICallResult( IntPtr self, SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbFailed );
		#endregion
		internal bool GetAPICallResult( SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbFailed )
		{
			var returnValue = _SteamAPI_ISteamUtils_GetAPICallResult( Self, hSteamAPICall, pCallback, cubCallback, iCallbackExpected, ref pbFailed );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetIPCCallCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetIPCCallCount", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUtils_GetIPCCallCount( IntPtr self );
		#endregion
		internal uint GetIPCCallCount()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetIPCCallCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_SetWarningMessageHook
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_SetWarningMessageHook", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUtils_SetWarningMessageHook( IntPtr self, IntPtr pFunction );
		#endregion
		internal void SetWarningMessageHook( IntPtr pFunction )
		{
			_SteamAPI_ISteamUtils_SetWarningMessageHook( Self, pFunction );
		}
		
		#region SteamAPI_ISteamUtils_IsOverlayEnabled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsOverlayEnabled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsOverlayEnabled( IntPtr self );
		#endregion
		internal bool IsOverlayEnabled()
		{
			var returnValue = _SteamAPI_ISteamUtils_IsOverlayEnabled( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_BOverlayNeedsPresent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_BOverlayNeedsPresent", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_BOverlayNeedsPresent( IntPtr self );
		#endregion
		internal bool BOverlayNeedsPresent()
		{
			var returnValue = _SteamAPI_ISteamUtils_BOverlayNeedsPresent( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_CheckFileSignature
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_CheckFileSignature", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUtils_CheckFileSignature( IntPtr self, IntPtr szFileName );
		#endregion
		internal CallResult<CheckFileSignature_t> CheckFileSignature( string szFileName )
		{
			using var str__szFileName = new Utf8StringToNative( szFileName );
			var returnValue = _SteamAPI_ISteamUtils_CheckFileSignature( Self, str__szFileName.Pointer );
			return new CallResult<CheckFileSignature_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUtils_ShowGamepadTextInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_ShowGamepadTextInput", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_ShowGamepadTextInput( IntPtr self, EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, IntPtr pchDescription, uint unCharMax, IntPtr pchExistingText );
		#endregion
		internal bool ShowGamepadTextInput( EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText )
		{
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			using var str__pchExistingText = new Utf8StringToNative( pchExistingText );
			var returnValue = _SteamAPI_ISteamUtils_ShowGamepadTextInput( Self, eInputMode, eLineInputMode, str__pchDescription.Pointer, unCharMax, str__pchExistingText.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetEnteredGamepadTextLength
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextLength", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUtils_GetEnteredGamepadTextLength( IntPtr self );
		#endregion
		internal uint GetEnteredGamepadTextLength()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetEnteredGamepadTextLength( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetEnteredGamepadTextInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextInput", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_GetEnteredGamepadTextInput( IntPtr self, IntPtr pchText, uint cchText );
		#endregion
		internal bool GetEnteredGamepadTextInput( out string pchText, uint cchText )
		{
			using var mem__pchText = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUtils_GetEnteredGamepadTextInput( Self, mem__pchText.Ptr, cchText );
			pchText = Utility.MemoryToString( mem__pchText );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetSteamUILanguage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetSteamUILanguage", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamUtils_GetSteamUILanguage( IntPtr self );
		#endregion
		internal string GetSteamUILanguage()
		{
			var returnValue = _SteamAPI_ISteamUtils_GetSteamUILanguage( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_IsSteamRunningInVR
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningInVR", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsSteamRunningInVR( IntPtr self );
		#endregion
		internal bool IsSteamRunningInVR()
		{
			var returnValue = _SteamAPI_ISteamUtils_IsSteamRunningInVR( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_SetOverlayNotificationInset
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationInset", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUtils_SetOverlayNotificationInset( IntPtr self, int nHorizontalInset, int nVerticalInset );
		#endregion
		internal void SetOverlayNotificationInset( int nHorizontalInset, int nVerticalInset )
		{
			_SteamAPI_ISteamUtils_SetOverlayNotificationInset( Self, nHorizontalInset, nVerticalInset );
		}
		
		#region SteamAPI_ISteamUtils_IsSteamInBigPictureMode
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsSteamInBigPictureMode", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsSteamInBigPictureMode( IntPtr self );
		#endregion
		internal bool IsSteamInBigPictureMode()
		{
			var returnValue = _SteamAPI_ISteamUtils_IsSteamInBigPictureMode( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_StartVRDashboard
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_StartVRDashboard", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUtils_StartVRDashboard( IntPtr self );
		#endregion
		internal void StartVRDashboard()
		{
			_SteamAPI_ISteamUtils_StartVRDashboard( Self );
		}
		
		#region SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled( IntPtr self );
		#endregion
		internal bool IsVRHeadsetStreamingEnabled()
		{
			var returnValue = _SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnabled );
		#endregion
		internal void SetVRHeadsetStreamingEnabled( [ MarshalAs( UnmanagedType.U1 ) ] bool bEnabled )
		{
			_SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled( Self, bEnabled );
		}
		
		#region SteamAPI_ISteamUtils_IsSteamChinaLauncher
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsSteamChinaLauncher", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsSteamChinaLauncher( IntPtr self );
		#endregion
		internal bool IsSteamChinaLauncher()
		{
			var returnValue = _SteamAPI_ISteamUtils_IsSteamChinaLauncher( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_InitFilterText
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_InitFilterText", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_InitFilterText( IntPtr self, uint unFilterOptions );
		#endregion
		internal bool InitFilterText( uint unFilterOptions )
		{
			var returnValue = _SteamAPI_ISteamUtils_InitFilterText( Self, unFilterOptions );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_FilterText
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_FilterText", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUtils_FilterText( IntPtr self, ETextFilteringContext eContext, SteamId sourceSteamID, IntPtr pchInputMessage, IntPtr pchOutFilteredText, uint nByteSizeOutFilteredText );
		#endregion
		internal int FilterText( ETextFilteringContext eContext, SteamId sourceSteamID, string pchInputMessage, out string pchOutFilteredText, uint nByteSizeOutFilteredText )
		{
			using var str__pchInputMessage = new Utf8StringToNative( pchInputMessage );
			using var mem__pchOutFilteredText = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUtils_FilterText( Self, eContext, sourceSteamID, str__pchInputMessage.Pointer, mem__pchOutFilteredText.Ptr, nByteSizeOutFilteredText );
			pchOutFilteredText = Utility.MemoryToString( mem__pchOutFilteredText );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_GetIPv6ConnectivityState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_GetIPv6ConnectivityState", CallingConvention = Platform.CC ) ]
		internal static extern ESteamIPv6ConnectivityState _SteamAPI_ISteamUtils_GetIPv6ConnectivityState( IntPtr self, ESteamIPv6ConnectivityProtocol eProtocol );
		#endregion
		internal ESteamIPv6ConnectivityState GetIPv6ConnectivityState( ESteamIPv6ConnectivityProtocol eProtocol )
		{
			var returnValue = _SteamAPI_ISteamUtils_GetIPv6ConnectivityState( Self, eProtocol );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_IsSteamRunningOnSteamDeck
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningOnSteamDeck", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_IsSteamRunningOnSteamDeck( IntPtr self );
		#endregion
		internal bool IsSteamRunningOnSteamDeck()
		{
			var returnValue = _SteamAPI_ISteamUtils_IsSteamRunningOnSteamDeck( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_ShowFloatingGamepadTextInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_ShowFloatingGamepadTextInput", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_ShowFloatingGamepadTextInput( IntPtr self, EFloatingGamepadTextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight );
		#endregion
		internal bool ShowFloatingGamepadTextInput( EFloatingGamepadTextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight )
		{
			var returnValue = _SteamAPI_ISteamUtils_ShowFloatingGamepadTextInput( Self, eKeyboardMode, nTextFieldXPosition, nTextFieldYPosition, nTextFieldWidth, nTextFieldHeight );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_SetGameLauncherMode
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_SetGameLauncherMode", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUtils_SetGameLauncherMode( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bLauncherMode );
		#endregion
		internal void SetGameLauncherMode( [ MarshalAs( UnmanagedType.U1 ) ] bool bLauncherMode )
		{
			_SteamAPI_ISteamUtils_SetGameLauncherMode( Self, bLauncherMode );
		}
		
		#region SteamAPI_ISteamUtils_DismissFloatingGamepadTextInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_DismissFloatingGamepadTextInput", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_DismissFloatingGamepadTextInput( IntPtr self );
		#endregion
		internal bool DismissFloatingGamepadTextInput()
		{
			var returnValue = _SteamAPI_ISteamUtils_DismissFloatingGamepadTextInput( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUtils_DismissGamepadTextInput
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUtils_DismissGamepadTextInput", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUtils_DismissGamepadTextInput( IntPtr self );
		#endregion
		internal bool DismissGamepadTextInput()
		{
			var returnValue = _SteamAPI_ISteamUtils_DismissGamepadTextInput( Self );
			return returnValue;
		}
		
	}
}
