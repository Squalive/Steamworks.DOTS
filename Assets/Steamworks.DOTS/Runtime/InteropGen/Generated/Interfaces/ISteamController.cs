using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamController
	{
		public const string Version = "SteamController008";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamController_v008", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamController_v008();
		/// Construct use accessor to find interface
		public ISteamController( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamController_v008();
			}
		}
		public ISteamController( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamController_Init
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_Init", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamController_Init( IntPtr self );
		#endregion
		internal bool Init()
		{
			var returnValue = _SteamAPI_ISteamController_Init( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_Shutdown
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_Shutdown", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamController_Shutdown( IntPtr self );
		#endregion
		internal bool Shutdown()
		{
			var returnValue = _SteamAPI_ISteamController_Shutdown( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_RunFrame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_RunFrame", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_RunFrame( IntPtr self );
		#endregion
		internal void RunFrame()
		{
			_SteamAPI_ISteamController_RunFrame( Self );
		}
		
		#region SteamAPI_ISteamController_GetConnectedControllers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamController_GetConnectedControllers( IntPtr self, ControllerHandle_t* handlesOut );
		#endregion
		internal int GetConnectedControllers( ControllerHandle_t* handlesOut )
		{
			var returnValue = _SteamAPI_ISteamController_GetConnectedControllers( Self, handlesOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetActionSetHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetActionSetHandle", CallingConvention = Platform.CC ) ]
		private static extern ControllerActionSetHandle_t _SteamAPI_ISteamController_GetActionSetHandle( IntPtr self, IntPtr pszActionSetName );
		#endregion
		internal ControllerActionSetHandle_t GetActionSetHandle( string pszActionSetName )
		{
			using var str__pszActionSetName = new Utf8StringToNative( pszActionSetName );
			var returnValue = _SteamAPI_ISteamController_GetActionSetHandle( Self, str__pszActionSetName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_ActivateActionSet
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_ActivateActionSet", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_ActivateActionSet( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle );
		#endregion
		internal void ActivateActionSet( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle )
		{
			_SteamAPI_ISteamController_ActivateActionSet( Self, controllerHandle, actionSetHandle );
		}
		
		#region SteamAPI_ISteamController_GetCurrentActionSet
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetCurrentActionSet", CallingConvention = Platform.CC ) ]
		private static extern ControllerActionSetHandle_t _SteamAPI_ISteamController_GetCurrentActionSet( IntPtr self, ControllerHandle_t controllerHandle );
		#endregion
		internal ControllerActionSetHandle_t GetCurrentActionSet( ControllerHandle_t controllerHandle )
		{
			var returnValue = _SteamAPI_ISteamController_GetCurrentActionSet( Self, controllerHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_ActivateActionSetLayer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_ActivateActionSetLayer", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_ActivateActionSetLayer( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle );
		#endregion
		internal void ActivateActionSetLayer( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle )
		{
			_SteamAPI_ISteamController_ActivateActionSetLayer( Self, controllerHandle, actionSetLayerHandle );
		}
		
		#region SteamAPI_ISteamController_DeactivateActionSetLayer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_DeactivateActionSetLayer", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_DeactivateActionSetLayer( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle );
		#endregion
		internal void DeactivateActionSetLayer( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle )
		{
			_SteamAPI_ISteamController_DeactivateActionSetLayer( Self, controllerHandle, actionSetLayerHandle );
		}
		
		#region SteamAPI_ISteamController_DeactivateAllActionSetLayers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_DeactivateAllActionSetLayers", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_DeactivateAllActionSetLayers( IntPtr self, ControllerHandle_t controllerHandle );
		#endregion
		internal void DeactivateAllActionSetLayers( ControllerHandle_t controllerHandle )
		{
			_SteamAPI_ISteamController_DeactivateAllActionSetLayers( Self, controllerHandle );
		}
		
		#region SteamAPI_ISteamController_GetActiveActionSetLayers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetActiveActionSetLayers", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamController_GetActiveActionSetLayers( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t* handlesOut );
		#endregion
		internal int GetActiveActionSetLayers( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t* handlesOut )
		{
			var returnValue = _SteamAPI_ISteamController_GetActiveActionSetLayers( Self, controllerHandle, handlesOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetDigitalActionHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionHandle", CallingConvention = Platform.CC ) ]
		private static extern ControllerDigitalActionHandle_t _SteamAPI_ISteamController_GetDigitalActionHandle( IntPtr self, IntPtr pszActionName );
		#endregion
		internal ControllerDigitalActionHandle_t GetDigitalActionHandle( string pszActionName )
		{
			using var str__pszActionName = new Utf8StringToNative( pszActionName );
			var returnValue = _SteamAPI_ISteamController_GetDigitalActionHandle( Self, str__pszActionName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetDigitalActionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionData", CallingConvention = Platform.CC ) ]
		private static extern InputDigitalActionData_t _SteamAPI_ISteamController_GetDigitalActionData( IntPtr self, ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle );
		#endregion
		internal InputDigitalActionData_t GetDigitalActionData( ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle )
		{
			var returnValue = _SteamAPI_ISteamController_GetDigitalActionData( Self, controllerHandle, digitalActionHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetDigitalActionOrigins
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamController_GetDigitalActionOrigins( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, ref EControllerActionOrigin originsOut );
		#endregion
		internal int GetDigitalActionOrigins( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, ref EControllerActionOrigin originsOut )
		{
			var returnValue = _SteamAPI_ISteamController_GetDigitalActionOrigins( Self, controllerHandle, actionSetHandle, digitalActionHandle, ref originsOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetAnalogActionHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionHandle", CallingConvention = Platform.CC ) ]
		private static extern ControllerAnalogActionHandle_t _SteamAPI_ISteamController_GetAnalogActionHandle( IntPtr self, IntPtr pszActionName );
		#endregion
		internal ControllerAnalogActionHandle_t GetAnalogActionHandle( string pszActionName )
		{
			using var str__pszActionName = new Utf8StringToNative( pszActionName );
			var returnValue = _SteamAPI_ISteamController_GetAnalogActionHandle( Self, str__pszActionName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetAnalogActionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionData", CallingConvention = Platform.CC ) ]
		private static extern InputAnalogActionData_t _SteamAPI_ISteamController_GetAnalogActionData( IntPtr self, ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle );
		#endregion
		internal InputAnalogActionData_t GetAnalogActionData( ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle )
		{
			var returnValue = _SteamAPI_ISteamController_GetAnalogActionData( Self, controllerHandle, analogActionHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetAnalogActionOrigins
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamController_GetAnalogActionOrigins( IntPtr self, ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, ref EControllerActionOrigin originsOut );
		#endregion
		internal int GetAnalogActionOrigins( ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, ref EControllerActionOrigin originsOut )
		{
			var returnValue = _SteamAPI_ISteamController_GetAnalogActionOrigins( Self, controllerHandle, actionSetHandle, analogActionHandle, ref originsOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetGlyphForActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetGlyphForActionOrigin", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamController_GetGlyphForActionOrigin( IntPtr self, EControllerActionOrigin eOrigin );
		#endregion
		internal string GetGlyphForActionOrigin( EControllerActionOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamController_GetGlyphForActionOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetStringForActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetStringForActionOrigin", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamController_GetStringForActionOrigin( IntPtr self, EControllerActionOrigin eOrigin );
		#endregion
		internal string GetStringForActionOrigin( EControllerActionOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamController_GetStringForActionOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_StopAnalogActionMomentum
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_StopAnalogActionMomentum", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_StopAnalogActionMomentum( IntPtr self, ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction );
		#endregion
		internal void StopAnalogActionMomentum( ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction )
		{
			_SteamAPI_ISteamController_StopAnalogActionMomentum( Self, controllerHandle, eAction );
		}
		
		#region SteamAPI_ISteamController_GetMotionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetMotionData", CallingConvention = Platform.CC ) ]
		private static extern InputMotionData_t _SteamAPI_ISteamController_GetMotionData( IntPtr self, ControllerHandle_t controllerHandle );
		#endregion
		internal InputMotionData_t GetMotionData( ControllerHandle_t controllerHandle )
		{
			var returnValue = _SteamAPI_ISteamController_GetMotionData( Self, controllerHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_TriggerHapticPulse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TriggerHapticPulse", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_TriggerHapticPulse( IntPtr self, ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec );
		#endregion
		internal void TriggerHapticPulse( ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec )
		{
			_SteamAPI_ISteamController_TriggerHapticPulse( Self, controllerHandle, eTargetPad, usDurationMicroSec );
		}
		
		#region SteamAPI_ISteamController_TriggerRepeatedHapticPulse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TriggerRepeatedHapticPulse", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_TriggerRepeatedHapticPulse( IntPtr self, ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags );
		#endregion
		internal void TriggerRepeatedHapticPulse( ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags )
		{
			_SteamAPI_ISteamController_TriggerRepeatedHapticPulse( Self, controllerHandle, eTargetPad, usDurationMicroSec, usOffMicroSec, unRepeat, nFlags );
		}
		
		#region SteamAPI_ISteamController_TriggerVibration
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TriggerVibration", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_TriggerVibration( IntPtr self, ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed );
		#endregion
		internal void TriggerVibration( ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed )
		{
			_SteamAPI_ISteamController_TriggerVibration( Self, controllerHandle, usLeftSpeed, usRightSpeed );
		}
		
		#region SteamAPI_ISteamController_SetLEDColor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_SetLEDColor", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamController_SetLEDColor( IntPtr self, ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags );
		#endregion
		internal void SetLEDColor( ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags )
		{
			_SteamAPI_ISteamController_SetLEDColor( Self, controllerHandle, nColorR, nColorG, nColorB, nFlags );
		}
		
		#region SteamAPI_ISteamController_ShowBindingPanel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_ShowBindingPanel", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamController_ShowBindingPanel( IntPtr self, ControllerHandle_t controllerHandle );
		#endregion
		internal bool ShowBindingPanel( ControllerHandle_t controllerHandle )
		{
			var returnValue = _SteamAPI_ISteamController_ShowBindingPanel( Self, controllerHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetInputTypeForHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetInputTypeForHandle", CallingConvention = Platform.CC ) ]
		private static extern ESteamInputType _SteamAPI_ISteamController_GetInputTypeForHandle( IntPtr self, ControllerHandle_t controllerHandle );
		#endregion
		internal ESteamInputType GetInputTypeForHandle( ControllerHandle_t controllerHandle )
		{
			var returnValue = _SteamAPI_ISteamController_GetInputTypeForHandle( Self, controllerHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetControllerForGamepadIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetControllerForGamepadIndex", CallingConvention = Platform.CC ) ]
		private static extern ControllerHandle_t _SteamAPI_ISteamController_GetControllerForGamepadIndex( IntPtr self, int nIndex );
		#endregion
		internal ControllerHandle_t GetControllerForGamepadIndex( int nIndex )
		{
			var returnValue = _SteamAPI_ISteamController_GetControllerForGamepadIndex( Self, nIndex );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetGamepadIndexForController
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetGamepadIndexForController", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamController_GetGamepadIndexForController( IntPtr self, ControllerHandle_t ulControllerHandle );
		#endregion
		internal int GetGamepadIndexForController( ControllerHandle_t ulControllerHandle )
		{
			var returnValue = _SteamAPI_ISteamController_GetGamepadIndexForController( Self, ulControllerHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetStringForXboxOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetStringForXboxOrigin", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamController_GetStringForXboxOrigin( IntPtr self, EXboxOrigin eOrigin );
		#endregion
		internal string GetStringForXboxOrigin( EXboxOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamController_GetStringForXboxOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetGlyphForXboxOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetGlyphForXboxOrigin", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamController_GetGlyphForXboxOrigin( IntPtr self, EXboxOrigin eOrigin );
		#endregion
		internal string GetGlyphForXboxOrigin( EXboxOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamController_GetGlyphForXboxOrigin( Self, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetActionOriginFromXboxOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetActionOriginFromXboxOrigin", CallingConvention = Platform.CC ) ]
		private static extern EControllerActionOrigin _SteamAPI_ISteamController_GetActionOriginFromXboxOrigin( IntPtr self, ControllerHandle_t controllerHandle, EXboxOrigin eOrigin );
		#endregion
		internal EControllerActionOrigin GetActionOriginFromXboxOrigin( ControllerHandle_t controllerHandle, EXboxOrigin eOrigin )
		{
			var returnValue = _SteamAPI_ISteamController_GetActionOriginFromXboxOrigin( Self, controllerHandle, eOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_TranslateActionOrigin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_TranslateActionOrigin", CallingConvention = Platform.CC ) ]
		private static extern EControllerActionOrigin _SteamAPI_ISteamController_TranslateActionOrigin( IntPtr self, ESteamInputType eDestinationInputType, EControllerActionOrigin eSourceOrigin );
		#endregion
		internal EControllerActionOrigin TranslateActionOrigin( ESteamInputType eDestinationInputType, EControllerActionOrigin eSourceOrigin )
		{
			var returnValue = _SteamAPI_ISteamController_TranslateActionOrigin( Self, eDestinationInputType, eSourceOrigin );
			return returnValue;
		}
		
		#region SteamAPI_ISteamController_GetControllerBindingRevision
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamController_GetControllerBindingRevision", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamController_GetControllerBindingRevision( IntPtr self, ControllerHandle_t controllerHandle, ref int pMajor, ref int pMinor );
		#endregion
		internal bool GetControllerBindingRevision( ControllerHandle_t controllerHandle, ref int pMajor, ref int pMinor )
		{
			var returnValue = _SteamAPI_ISteamController_GetControllerBindingRevision( Self, controllerHandle, ref pMajor, ref pMinor );
			return returnValue;
		}
		
	}
}
