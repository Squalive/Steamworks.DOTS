using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamInput
	{
		public const string Version = "SteamInput006";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamInput_v006", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamInput_v006();
		/// Construct use accessor to find interface
		public ISteamInput( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamInput_v006();
			}
		}
		public ISteamInput( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamInput_Init
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_Init", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_Init( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bExplicitlyCallRunFrame );
		internal bool _Init( [ MarshalAs( UnmanagedType.U1 ) ] bool bExplicitlyCallRunFrame ) => _SteamAPI_ISteamInput_Init( Self, bExplicitlyCallRunFrame );
		#endregion
		internal bool Init( [ MarshalAs( UnmanagedType.U1 ) ] bool bExplicitlyCallRunFrame )
		{
			var returnValue = _SteamAPI_ISteamInput_Init( Self, bExplicitlyCallRunFrame );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_Shutdown
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_Shutdown", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_Shutdown( IntPtr self );
		internal bool _Shutdown(  ) => _SteamAPI_ISteamInput_Shutdown( Self );
		#endregion
		internal bool Shutdown()
		{
			var returnValue = _SteamAPI_ISteamInput_Shutdown( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_SetInputActionManifestFilePath
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_SetInputActionManifestFilePath", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_SetInputActionManifestFilePath( IntPtr self, IntPtr pchInputActionManifestAbsolutePath );
		internal bool _SetInputActionManifestFilePath( IntPtr pchInputActionManifestAbsolutePath ) => _SteamAPI_ISteamInput_SetInputActionManifestFilePath( Self, pchInputActionManifestAbsolutePath );
		#endregion
		internal bool SetInputActionManifestFilePath( string pchInputActionManifestAbsolutePath )
		{
			using var str__pchInputActionManifestAbsolutePath = new Utf8StringToNative( pchInputActionManifestAbsolutePath );
			var returnValue = _SteamAPI_ISteamInput_SetInputActionManifestFilePath( Self, str__pchInputActionManifestAbsolutePath.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_RunFrame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_RunFrame", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_RunFrame( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bReservedValue );
		internal void _RunFrame( [ MarshalAs( UnmanagedType.U1 ) ] bool bReservedValue ) => _SteamAPI_ISteamInput_RunFrame( Self, bReservedValue );
		#endregion
		internal void RunFrame( [ MarshalAs( UnmanagedType.U1 ) ] bool bReservedValue )
		{
			_SteamAPI_ISteamInput_RunFrame( Self, bReservedValue );
		}
		
		#region SteamAPI_ISteamInput_BWaitForData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_BWaitForData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_BWaitForData( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bWaitForever, uint unTimeout );
		internal bool _BWaitForData( [ MarshalAs( UnmanagedType.U1 ) ] bool bWaitForever, uint unTimeout ) => _SteamAPI_ISteamInput_BWaitForData( Self, bWaitForever, unTimeout );
		#endregion
		internal bool BWaitForData( [ MarshalAs( UnmanagedType.U1 ) ] bool bWaitForever, uint unTimeout )
		{
			var returnValue = _SteamAPI_ISteamInput_BWaitForData( Self, bWaitForever, unTimeout );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_BNewDataAvailable
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_BNewDataAvailable", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_BNewDataAvailable( IntPtr self );
		internal bool _BNewDataAvailable(  ) => _SteamAPI_ISteamInput_BNewDataAvailable( Self );
		#endregion
		internal bool BNewDataAvailable()
		{
			var returnValue = _SteamAPI_ISteamInput_BNewDataAvailable( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetConnectedControllers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetConnectedControllers", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamInput_GetConnectedControllers( IntPtr self, InputHandle_t* handlesOut );
		internal int _GetConnectedControllers( InputHandle_t* handlesOut ) => _SteamAPI_ISteamInput_GetConnectedControllers( Self, handlesOut );
		#endregion
		internal int GetConnectedControllers( InputHandle_t* handlesOut )
		{
			var returnValue = _SteamAPI_ISteamInput_GetConnectedControllers( Self, handlesOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_EnableDeviceCallbacks
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_EnableDeviceCallbacks", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_EnableDeviceCallbacks( IntPtr self );
		internal void _EnableDeviceCallbacks(  ) => _SteamAPI_ISteamInput_EnableDeviceCallbacks( Self );
		#endregion
		internal void EnableDeviceCallbacks()
		{
			_SteamAPI_ISteamInput_EnableDeviceCallbacks( Self );
		}
		
		#region SteamAPI_ISteamInput_GetActionSetHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetActionSetHandle", CallingConvention = Platform.CC ) ]
		internal static extern InputActionSetHandle_t _SteamAPI_ISteamInput_GetActionSetHandle( IntPtr self, IntPtr pszActionSetName );
		internal InputActionSetHandle_t _GetActionSetHandle( IntPtr pszActionSetName ) => _SteamAPI_ISteamInput_GetActionSetHandle( Self, pszActionSetName );
		#endregion
		internal InputActionSetHandle_t GetActionSetHandle( string pszActionSetName )
		{
			using var str__pszActionSetName = new Utf8StringToNative( pszActionSetName );
			var returnValue = _SteamAPI_ISteamInput_GetActionSetHandle( Self, str__pszActionSetName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_ActivateActionSet
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_ActivateActionSet", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_ActivateActionSet( IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle );
		internal void _ActivateActionSet( InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle ) => _SteamAPI_ISteamInput_ActivateActionSet( Self, inputHandle, actionSetHandle );
		#endregion
		internal void ActivateActionSet( InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle )
		{
			_SteamAPI_ISteamInput_ActivateActionSet( Self, inputHandle, actionSetHandle );
		}
		
		#region SteamAPI_ISteamInput_GetCurrentActionSet
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetCurrentActionSet", CallingConvention = Platform.CC ) ]
		internal static extern InputActionSetHandle_t _SteamAPI_ISteamInput_GetCurrentActionSet( IntPtr self, InputHandle_t inputHandle );
		internal InputActionSetHandle_t _GetCurrentActionSet( InputHandle_t inputHandle ) => _SteamAPI_ISteamInput_GetCurrentActionSet( Self, inputHandle );
		#endregion
		internal InputActionSetHandle_t GetCurrentActionSet( InputHandle_t inputHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetCurrentActionSet( Self, inputHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_ActivateActionSetLayer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_ActivateActionSetLayer", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_ActivateActionSetLayer( IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle );
		internal void _ActivateActionSetLayer( InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle ) => _SteamAPI_ISteamInput_ActivateActionSetLayer( Self, inputHandle, actionSetLayerHandle );
		#endregion
		internal void ActivateActionSetLayer( InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle )
		{
			_SteamAPI_ISteamInput_ActivateActionSetLayer( Self, inputHandle, actionSetLayerHandle );
		}
		
		#region SteamAPI_ISteamInput_DeactivateActionSetLayer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_DeactivateActionSetLayer", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_DeactivateActionSetLayer( IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle );
		internal void _DeactivateActionSetLayer( InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle ) => _SteamAPI_ISteamInput_DeactivateActionSetLayer( Self, inputHandle, actionSetLayerHandle );
		#endregion
		internal void DeactivateActionSetLayer( InputHandle_t inputHandle, InputActionSetHandle_t actionSetLayerHandle )
		{
			_SteamAPI_ISteamInput_DeactivateActionSetLayer( Self, inputHandle, actionSetLayerHandle );
		}
		
		#region SteamAPI_ISteamInput_DeactivateAllActionSetLayers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_DeactivateAllActionSetLayers", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_DeactivateAllActionSetLayers( IntPtr self, InputHandle_t inputHandle );
		internal void _DeactivateAllActionSetLayers( InputHandle_t inputHandle ) => _SteamAPI_ISteamInput_DeactivateAllActionSetLayers( Self, inputHandle );
		#endregion
		internal void DeactivateAllActionSetLayers( InputHandle_t inputHandle )
		{
			_SteamAPI_ISteamInput_DeactivateAllActionSetLayers( Self, inputHandle );
		}
		
		#region SteamAPI_ISteamInput_GetActiveActionSetLayers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetActiveActionSetLayers", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamInput_GetActiveActionSetLayers( IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t* handlesOut );
		internal int _GetActiveActionSetLayers( InputHandle_t inputHandle, InputActionSetHandle_t* handlesOut ) => _SteamAPI_ISteamInput_GetActiveActionSetLayers( Self, inputHandle, handlesOut );
		#endregion
		internal int GetActiveActionSetLayers( InputHandle_t inputHandle, InputActionSetHandle_t* handlesOut )
		{
			var returnValue = _SteamAPI_ISteamInput_GetActiveActionSetLayers( Self, inputHandle, handlesOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetDigitalActionHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetDigitalActionHandle", CallingConvention = Platform.CC ) ]
		internal static extern InputDigitalActionHandle_t _SteamAPI_ISteamInput_GetDigitalActionHandle( IntPtr self, IntPtr pszActionName );
		internal InputDigitalActionHandle_t _GetDigitalActionHandle( IntPtr pszActionName ) => _SteamAPI_ISteamInput_GetDigitalActionHandle( Self, pszActionName );
		#endregion
		internal InputDigitalActionHandle_t GetDigitalActionHandle( string pszActionName )
		{
			using var str__pszActionName = new Utf8StringToNative( pszActionName );
			var returnValue = _SteamAPI_ISteamInput_GetDigitalActionHandle( Self, str__pszActionName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetDigitalActionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetDigitalActionData", CallingConvention = Platform.CC ) ]
		internal static extern InputDigitalActionData_t _SteamAPI_ISteamInput_GetDigitalActionData( IntPtr self, InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle );
		internal InputDigitalActionData_t _GetDigitalActionData( InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle ) => _SteamAPI_ISteamInput_GetDigitalActionData( Self, inputHandle, digitalActionHandle );
		#endregion
		internal InputDigitalActionData_t GetDigitalActionData( InputHandle_t inputHandle, InputDigitalActionHandle_t digitalActionHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetDigitalActionData( Self, inputHandle, digitalActionHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetDigitalActionOrigins
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetDigitalActionOrigins", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamInput_GetDigitalActionOrigins( IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, ref EInputActionOrigin originsOut );
		internal int _GetDigitalActionOrigins( InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, ref EInputActionOrigin originsOut ) => _SteamAPI_ISteamInput_GetDigitalActionOrigins( Self, inputHandle, actionSetHandle, digitalActionHandle, ref originsOut );
		#endregion
		internal int GetDigitalActionOrigins( InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle, ref EInputActionOrigin originsOut )
		{
			var returnValue = _SteamAPI_ISteamInput_GetDigitalActionOrigins( Self, inputHandle, actionSetHandle, digitalActionHandle, ref originsOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetStringForDigitalActionName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetStringForDigitalActionName", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetStringForDigitalActionName( IntPtr self, InputDigitalActionHandle_t eActionHandle );
		internal Utf8StringPtr _GetStringForDigitalActionName( InputDigitalActionHandle_t eActionHandle ) => _SteamAPI_ISteamInput_GetStringForDigitalActionName( Self, eActionHandle );
		#endregion
		internal string GetStringForDigitalActionName( InputDigitalActionHandle_t eActionHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetStringForDigitalActionName( Self, eActionHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetAnalogActionHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetAnalogActionHandle", CallingConvention = Platform.CC ) ]
		internal static extern InputAnalogActionHandle_t _SteamAPI_ISteamInput_GetAnalogActionHandle( IntPtr self, IntPtr pszActionName );
		internal InputAnalogActionHandle_t _GetAnalogActionHandle( IntPtr pszActionName ) => _SteamAPI_ISteamInput_GetAnalogActionHandle( Self, pszActionName );
		#endregion
		internal InputAnalogActionHandle_t GetAnalogActionHandle( string pszActionName )
		{
			using var str__pszActionName = new Utf8StringToNative( pszActionName );
			var returnValue = _SteamAPI_ISteamInput_GetAnalogActionHandle( Self, str__pszActionName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetAnalogActionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetAnalogActionData", CallingConvention = Platform.CC ) ]
		internal static extern InputAnalogActionData_t _SteamAPI_ISteamInput_GetAnalogActionData( IntPtr self, InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle );
		internal InputAnalogActionData_t _GetAnalogActionData( InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle ) => _SteamAPI_ISteamInput_GetAnalogActionData( Self, inputHandle, analogActionHandle );
		#endregion
		internal InputAnalogActionData_t GetAnalogActionData( InputHandle_t inputHandle, InputAnalogActionHandle_t analogActionHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetAnalogActionData( Self, inputHandle, analogActionHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetAnalogActionOrigins
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetAnalogActionOrigins", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamInput_GetAnalogActionOrigins( IntPtr self, InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, ref EInputActionOrigin originsOut );
		internal int _GetAnalogActionOrigins( InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, ref EInputActionOrigin originsOut ) => _SteamAPI_ISteamInput_GetAnalogActionOrigins( Self, inputHandle, actionSetHandle, analogActionHandle, ref originsOut );
		#endregion
		internal int GetAnalogActionOrigins( InputHandle_t inputHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle, ref EInputActionOrigin originsOut )
		{
			var returnValue = _SteamAPI_ISteamInput_GetAnalogActionOrigins( Self, inputHandle, actionSetHandle, analogActionHandle, ref originsOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetGlyphPNGForActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetGlyphPNGForActionOrigin", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetGlyphPNGForActionOrigin( IntPtr self, EInputActionOrigin eOrigin, ESteamInputGlyphSize eSize, uint unFlags );
		internal Utf8StringPtr _GetGlyphPNGForActionOrigin( EInputActionOrigin eOrigin, ESteamInputGlyphSize eSize, uint unFlags ) => _SteamAPI_ISteamInput_GetGlyphPNGForActionOrigin( Self, eOrigin, eSize, unFlags );
		#endregion
		internal string GetGlyphPNGForActionOrigin( EInputActionOrigin eOrigin, ESteamInputGlyphSize eSize, uint unFlags )
		{
			var returnValue = _SteamAPI_ISteamInput_GetGlyphPNGForActionOrigin( Self, eOrigin, eSize, unFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetGlyphSVGForActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetGlyphSVGForActionOrigin", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetGlyphSVGForActionOrigin( IntPtr self, EInputActionOrigin eOrigin, uint unFlags );
		internal Utf8StringPtr _GetGlyphSVGForActionOrigin( EInputActionOrigin eOrigin, uint unFlags ) => _SteamAPI_ISteamInput_GetGlyphSVGForActionOrigin( Self, eOrigin, unFlags );
		#endregion
		internal string GetGlyphSVGForActionOrigin( EInputActionOrigin eOrigin, uint unFlags )
		{
			var returnValue = _SteamAPI_ISteamInput_GetGlyphSVGForActionOrigin( Self, eOrigin, unFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetGlyphForActionOrigin_Legacy
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetGlyphForActionOrigin_Legacy", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetGlyphForActionOrigin_Legacy( IntPtr self, EInputActionOrigin eOrigin );
		internal Utf8StringPtr _GetGlyphForActionOrigin_Legacy( EInputActionOrigin eOrigin ) => _SteamAPI_ISteamInput_GetGlyphForActionOrigin_Legacy( Self, eOrigin );
		#endregion
		internal string GetGlyphForActionOrigin_Legacy( EInputActionOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamInput_GetGlyphForActionOrigin_Legacy( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetStringForActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetStringForActionOrigin", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetStringForActionOrigin( IntPtr self, EInputActionOrigin eOrigin );
		internal Utf8StringPtr _GetStringForActionOrigin( EInputActionOrigin eOrigin ) => _SteamAPI_ISteamInput_GetStringForActionOrigin( Self, eOrigin );
		#endregion
		internal string GetStringForActionOrigin( EInputActionOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamInput_GetStringForActionOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetStringForAnalogActionName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetStringForAnalogActionName", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetStringForAnalogActionName( IntPtr self, InputAnalogActionHandle_t eActionHandle );
		internal Utf8StringPtr _GetStringForAnalogActionName( InputAnalogActionHandle_t eActionHandle ) => _SteamAPI_ISteamInput_GetStringForAnalogActionName( Self, eActionHandle );
		#endregion
		internal string GetStringForAnalogActionName( InputAnalogActionHandle_t eActionHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetStringForAnalogActionName( Self, eActionHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_StopAnalogActionMomentum
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_StopAnalogActionMomentum", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_StopAnalogActionMomentum( IntPtr self, InputHandle_t inputHandle, InputAnalogActionHandle_t eAction );
		internal void _StopAnalogActionMomentum( InputHandle_t inputHandle, InputAnalogActionHandle_t eAction ) => _SteamAPI_ISteamInput_StopAnalogActionMomentum( Self, inputHandle, eAction );
		#endregion
		internal void StopAnalogActionMomentum( InputHandle_t inputHandle, InputAnalogActionHandle_t eAction )
		{
			_SteamAPI_ISteamInput_StopAnalogActionMomentum( Self, inputHandle, eAction );
		}
		
		#region SteamAPI_ISteamInput_GetMotionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetMotionData", CallingConvention = Platform.CC ) ]
		internal static extern InputMotionData_t _SteamAPI_ISteamInput_GetMotionData( IntPtr self, InputHandle_t inputHandle );
		internal InputMotionData_t _GetMotionData( InputHandle_t inputHandle ) => _SteamAPI_ISteamInput_GetMotionData( Self, inputHandle );
		#endregion
		internal InputMotionData_t GetMotionData( InputHandle_t inputHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetMotionData( Self, inputHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_TriggerVibration
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_TriggerVibration", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_TriggerVibration( IntPtr self, InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed );
		internal void _TriggerVibration( InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed ) => _SteamAPI_ISteamInput_TriggerVibration( Self, inputHandle, usLeftSpeed, usRightSpeed );
		#endregion
		internal void TriggerVibration( InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed )
		{
			_SteamAPI_ISteamInput_TriggerVibration( Self, inputHandle, usLeftSpeed, usRightSpeed );
		}
		
		#region SteamAPI_ISteamInput_TriggerVibrationExtended
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_TriggerVibrationExtended", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_TriggerVibrationExtended( IntPtr self, InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed, ushort usLeftTriggerSpeed, ushort usRightTriggerSpeed );
		internal void _TriggerVibrationExtended( InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed, ushort usLeftTriggerSpeed, ushort usRightTriggerSpeed ) => _SteamAPI_ISteamInput_TriggerVibrationExtended( Self, inputHandle, usLeftSpeed, usRightSpeed, usLeftTriggerSpeed, usRightTriggerSpeed );
		#endregion
		internal void TriggerVibrationExtended( InputHandle_t inputHandle, ushort usLeftSpeed, ushort usRightSpeed, ushort usLeftTriggerSpeed, ushort usRightTriggerSpeed )
		{
			_SteamAPI_ISteamInput_TriggerVibrationExtended( Self, inputHandle, usLeftSpeed, usRightSpeed, usLeftTriggerSpeed, usRightTriggerSpeed );
		}
		
		#region SteamAPI_ISteamInput_TriggerSimpleHapticEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_TriggerSimpleHapticEvent", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_TriggerSimpleHapticEvent( IntPtr self, InputHandle_t inputHandle, EControllerHapticLocation eHapticLocation, byte nIntensity, char nGainDB, byte nOtherIntensity, char nOtherGainDB );
		internal void _TriggerSimpleHapticEvent( InputHandle_t inputHandle, EControllerHapticLocation eHapticLocation, byte nIntensity, char nGainDB, byte nOtherIntensity, char nOtherGainDB ) => _SteamAPI_ISteamInput_TriggerSimpleHapticEvent( Self, inputHandle, eHapticLocation, nIntensity, nGainDB, nOtherIntensity, nOtherGainDB );
		#endregion
		internal void TriggerSimpleHapticEvent( InputHandle_t inputHandle, EControllerHapticLocation eHapticLocation, byte nIntensity, char nGainDB, byte nOtherIntensity, char nOtherGainDB )
		{
			_SteamAPI_ISteamInput_TriggerSimpleHapticEvent( Self, inputHandle, eHapticLocation, nIntensity, nGainDB, nOtherIntensity, nOtherGainDB );
		}
		
		#region SteamAPI_ISteamInput_SetLEDColor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_SetLEDColor", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_SetLEDColor( IntPtr self, InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags );
		internal void _SetLEDColor( InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags ) => _SteamAPI_ISteamInput_SetLEDColor( Self, inputHandle, nColorR, nColorG, nColorB, nFlags );
		#endregion
		internal void SetLEDColor( InputHandle_t inputHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags )
		{
			_SteamAPI_ISteamInput_SetLEDColor( Self, inputHandle, nColorR, nColorG, nColorB, nFlags );
		}
		
		#region SteamAPI_ISteamInput_Legacy_TriggerHapticPulse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_Legacy_TriggerHapticPulse", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_Legacy_TriggerHapticPulse( IntPtr self, InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec );
		internal void _Legacy_TriggerHapticPulse( InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec ) => _SteamAPI_ISteamInput_Legacy_TriggerHapticPulse( Self, inputHandle, eTargetPad, usDurationMicroSec );
		#endregion
		internal void Legacy_TriggerHapticPulse( InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec )
		{
			_SteamAPI_ISteamInput_Legacy_TriggerHapticPulse( Self, inputHandle, eTargetPad, usDurationMicroSec );
		}
		
		#region SteamAPI_ISteamInput_Legacy_TriggerRepeatedHapticPulse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_Legacy_TriggerRepeatedHapticPulse", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamInput_Legacy_TriggerRepeatedHapticPulse( IntPtr self, InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags );
		internal void _Legacy_TriggerRepeatedHapticPulse( InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags ) => _SteamAPI_ISteamInput_Legacy_TriggerRepeatedHapticPulse( Self, inputHandle, eTargetPad, usDurationMicroSec, usOffMicroSec, unRepeat, nFlags );
		#endregion
		internal void Legacy_TriggerRepeatedHapticPulse( InputHandle_t inputHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags )
		{
			_SteamAPI_ISteamInput_Legacy_TriggerRepeatedHapticPulse( Self, inputHandle, eTargetPad, usDurationMicroSec, usOffMicroSec, unRepeat, nFlags );
		}
		
		#region SteamAPI_ISteamInput_ShowBindingPanel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_ShowBindingPanel", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_ShowBindingPanel( IntPtr self, InputHandle_t inputHandle );
		internal bool _ShowBindingPanel( InputHandle_t inputHandle ) => _SteamAPI_ISteamInput_ShowBindingPanel( Self, inputHandle );
		#endregion
		internal bool ShowBindingPanel( InputHandle_t inputHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_ShowBindingPanel( Self, inputHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetInputTypeForHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetInputTypeForHandle", CallingConvention = Platform.CC ) ]
		internal static extern ESteamInputType _SteamAPI_ISteamInput_GetInputTypeForHandle( IntPtr self, InputHandle_t inputHandle );
		internal ESteamInputType _GetInputTypeForHandle( InputHandle_t inputHandle ) => _SteamAPI_ISteamInput_GetInputTypeForHandle( Self, inputHandle );
		#endregion
		internal ESteamInputType GetInputTypeForHandle( InputHandle_t inputHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetInputTypeForHandle( Self, inputHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetControllerForGamepadIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetControllerForGamepadIndex", CallingConvention = Platform.CC ) ]
		internal static extern InputHandle_t _SteamAPI_ISteamInput_GetControllerForGamepadIndex( IntPtr self, int nIndex );
		internal InputHandle_t _GetControllerForGamepadIndex( int nIndex ) => _SteamAPI_ISteamInput_GetControllerForGamepadIndex( Self, nIndex );
		#endregion
		internal InputHandle_t GetControllerForGamepadIndex( int nIndex )
		{
			var returnValue = _SteamAPI_ISteamInput_GetControllerForGamepadIndex( Self, nIndex );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetGamepadIndexForController
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetGamepadIndexForController", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamInput_GetGamepadIndexForController( IntPtr self, InputHandle_t ulinputHandle );
		internal int _GetGamepadIndexForController( InputHandle_t ulinputHandle ) => _SteamAPI_ISteamInput_GetGamepadIndexForController( Self, ulinputHandle );
		#endregion
		internal int GetGamepadIndexForController( InputHandle_t ulinputHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetGamepadIndexForController( Self, ulinputHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetStringForXboxOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetStringForXboxOrigin", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetStringForXboxOrigin( IntPtr self, EXboxOrigin eOrigin );
		internal Utf8StringPtr _GetStringForXboxOrigin( EXboxOrigin eOrigin ) => _SteamAPI_ISteamInput_GetStringForXboxOrigin( Self, eOrigin );
		#endregion
		internal string GetStringForXboxOrigin( EXboxOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamInput_GetStringForXboxOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetGlyphForXboxOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetGlyphForXboxOrigin", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamInput_GetGlyphForXboxOrigin( IntPtr self, EXboxOrigin eOrigin );
		internal Utf8StringPtr _GetGlyphForXboxOrigin( EXboxOrigin eOrigin ) => _SteamAPI_ISteamInput_GetGlyphForXboxOrigin( Self, eOrigin );
		#endregion
		internal string GetGlyphForXboxOrigin( EXboxOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamInput_GetGlyphForXboxOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetActionOriginFromXboxOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetActionOriginFromXboxOrigin", CallingConvention = Platform.CC ) ]
		internal static extern EInputActionOrigin _SteamAPI_ISteamInput_GetActionOriginFromXboxOrigin( IntPtr self, InputHandle_t inputHandle, EXboxOrigin eOrigin );
		internal EInputActionOrigin _GetActionOriginFromXboxOrigin( InputHandle_t inputHandle, EXboxOrigin eOrigin ) => _SteamAPI_ISteamInput_GetActionOriginFromXboxOrigin( Self, inputHandle, eOrigin );
		#endregion
		internal EInputActionOrigin GetActionOriginFromXboxOrigin( InputHandle_t inputHandle, EXboxOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamInput_GetActionOriginFromXboxOrigin( Self, inputHandle, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_TranslateActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_TranslateActionOrigin", CallingConvention = Platform.CC ) ]
		internal static extern EInputActionOrigin _SteamAPI_ISteamInput_TranslateActionOrigin( IntPtr self, ESteamInputType eDestinationInputType, EInputActionOrigin eSourceOrigin );
		internal EInputActionOrigin _TranslateActionOrigin( ESteamInputType eDestinationInputType, EInputActionOrigin eSourceOrigin ) => _SteamAPI_ISteamInput_TranslateActionOrigin( Self, eDestinationInputType, eSourceOrigin );
		#endregion
		internal EInputActionOrigin TranslateActionOrigin( ESteamInputType eDestinationInputType, EInputActionOrigin eSourceOrigin )
		{
			var returnValue = _SteamAPI_ISteamInput_TranslateActionOrigin( Self, eDestinationInputType, eSourceOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetDeviceBindingRevision
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetDeviceBindingRevision", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamInput_GetDeviceBindingRevision( IntPtr self, InputHandle_t inputHandle, ref int pMajor, ref int pMinor );
		internal bool _GetDeviceBindingRevision( InputHandle_t inputHandle, ref int pMajor, ref int pMinor ) => _SteamAPI_ISteamInput_GetDeviceBindingRevision( Self, inputHandle, ref pMajor, ref pMinor );
		#endregion
		internal bool GetDeviceBindingRevision( InputHandle_t inputHandle, ref int pMajor, ref int pMinor )
		{
			var returnValue = _SteamAPI_ISteamInput_GetDeviceBindingRevision( Self, inputHandle, ref pMajor, ref pMinor );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetRemotePlaySessionID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetRemotePlaySessionID", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamInput_GetRemotePlaySessionID( IntPtr self, InputHandle_t inputHandle );
		internal uint _GetRemotePlaySessionID( InputHandle_t inputHandle ) => _SteamAPI_ISteamInput_GetRemotePlaySessionID( Self, inputHandle );
		#endregion
		internal uint GetRemotePlaySessionID( InputHandle_t inputHandle )
		{
			var returnValue = _SteamAPI_ISteamInput_GetRemotePlaySessionID( Self, inputHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamInput_GetSessionInputConfigurationSettings
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamInput_GetSessionInputConfigurationSettings", CallingConvention = Platform.CC ) ]
		internal static extern ushort _SteamAPI_ISteamInput_GetSessionInputConfigurationSettings( IntPtr self );
		internal ushort _GetSessionInputConfigurationSettings(  ) => _SteamAPI_ISteamInput_GetSessionInputConfigurationSettings( Self );
		#endregion
		internal ushort GetSessionInputConfigurationSettings()
		{
			var returnValue = _SteamAPI_ISteamInput_GetSessionInputConfigurationSettings( Self );
			return returnValue;
		}
		
	}
}
