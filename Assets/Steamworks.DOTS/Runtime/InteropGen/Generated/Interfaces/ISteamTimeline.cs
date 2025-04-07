using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamTimeline
	{
		public const string Version = "STEAMTIMELINE_INTERFACE_V004";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamTimeline_v004", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamTimeline_v004();
		/// Construct use accessor to find interface
		public ISteamTimeline( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamTimeline_v004();
			}
		}
		public ISteamTimeline( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamTimeline_SetTimelineTooltip
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_SetTimelineTooltip", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_SetTimelineTooltip( IntPtr self, IntPtr pchDescription, float flTimeDelta );
		#endregion
		internal void SetTimelineTooltip( string pchDescription, float flTimeDelta )
		{
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			_SteamAPI_ISteamTimeline_SetTimelineTooltip( Self, str__pchDescription.Pointer, flTimeDelta );
		}
		
		#region SteamAPI_ISteamTimeline_ClearTimelineTooltip
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_ClearTimelineTooltip", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_ClearTimelineTooltip( IntPtr self, float flTimeDelta );
		#endregion
		internal void ClearTimelineTooltip( float flTimeDelta )
		{
			_SteamAPI_ISteamTimeline_ClearTimelineTooltip( Self, flTimeDelta );
		}
		
		#region SteamAPI_ISteamTimeline_SetTimelineGameMode
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_SetTimelineGameMode", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_SetTimelineGameMode( IntPtr self, ETimelineGameMode eMode );
		#endregion
		internal void SetTimelineGameMode( ETimelineGameMode eMode )
		{
			_SteamAPI_ISteamTimeline_SetTimelineGameMode( Self, eMode );
		}
		
		#region SteamAPI_ISteamTimeline_AddInstantaneousTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_AddInstantaneousTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern TimelineEventHandle_t _SteamAPI_ISteamTimeline_AddInstantaneousTimelineEvent( IntPtr self, IntPtr pchTitle, IntPtr pchDescription, IntPtr pchIcon, uint unIconPriority, float flStartOffsetSeconds, ETimelineEventClipPriority ePossibleClip );
		#endregion
		internal TimelineEventHandle_t AddInstantaneousTimelineEvent( string pchTitle, string pchDescription, string pchIcon, uint unIconPriority, float flStartOffsetSeconds, ETimelineEventClipPriority ePossibleClip )
		{
			using var str__pchTitle = new Utf8StringToNative( pchTitle );
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			using var str__pchIcon = new Utf8StringToNative( pchIcon );
			var returnValue = _SteamAPI_ISteamTimeline_AddInstantaneousTimelineEvent( Self, str__pchTitle.Pointer, str__pchDescription.Pointer, str__pchIcon.Pointer, unIconPriority, flStartOffsetSeconds, ePossibleClip );
			return returnValue;
		}
		
		#region SteamAPI_ISteamTimeline_AddRangeTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_AddRangeTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern TimelineEventHandle_t _SteamAPI_ISteamTimeline_AddRangeTimelineEvent( IntPtr self, IntPtr pchTitle, IntPtr pchDescription, IntPtr pchIcon, uint unIconPriority, float flStartOffsetSeconds, float flDuration, ETimelineEventClipPriority ePossibleClip );
		#endregion
		internal TimelineEventHandle_t AddRangeTimelineEvent( string pchTitle, string pchDescription, string pchIcon, uint unIconPriority, float flStartOffsetSeconds, float flDuration, ETimelineEventClipPriority ePossibleClip )
		{
			using var str__pchTitle = new Utf8StringToNative( pchTitle );
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			using var str__pchIcon = new Utf8StringToNative( pchIcon );
			var returnValue = _SteamAPI_ISteamTimeline_AddRangeTimelineEvent( Self, str__pchTitle.Pointer, str__pchDescription.Pointer, str__pchIcon.Pointer, unIconPriority, flStartOffsetSeconds, flDuration, ePossibleClip );
			return returnValue;
		}
		
		#region SteamAPI_ISteamTimeline_StartRangeTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_StartRangeTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern TimelineEventHandle_t _SteamAPI_ISteamTimeline_StartRangeTimelineEvent( IntPtr self, IntPtr pchTitle, IntPtr pchDescription, IntPtr pchIcon, uint unPriority, float flStartOffsetSeconds, ETimelineEventClipPriority ePossibleClip );
		#endregion
		internal TimelineEventHandle_t StartRangeTimelineEvent( string pchTitle, string pchDescription, string pchIcon, uint unPriority, float flStartOffsetSeconds, ETimelineEventClipPriority ePossibleClip )
		{
			using var str__pchTitle = new Utf8StringToNative( pchTitle );
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			using var str__pchIcon = new Utf8StringToNative( pchIcon );
			var returnValue = _SteamAPI_ISteamTimeline_StartRangeTimelineEvent( Self, str__pchTitle.Pointer, str__pchDescription.Pointer, str__pchIcon.Pointer, unPriority, flStartOffsetSeconds, ePossibleClip );
			return returnValue;
		}
		
		#region SteamAPI_ISteamTimeline_UpdateRangeTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_UpdateRangeTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_UpdateRangeTimelineEvent( IntPtr self, TimelineEventHandle_t ulEvent, IntPtr pchTitle, IntPtr pchDescription, IntPtr pchIcon, uint unPriority, ETimelineEventClipPriority ePossibleClip );
		#endregion
		internal void UpdateRangeTimelineEvent( TimelineEventHandle_t ulEvent, string pchTitle, string pchDescription, string pchIcon, uint unPriority, ETimelineEventClipPriority ePossibleClip )
		{
			using var str__pchTitle = new Utf8StringToNative( pchTitle );
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			using var str__pchIcon = new Utf8StringToNative( pchIcon );
			_SteamAPI_ISteamTimeline_UpdateRangeTimelineEvent( Self, ulEvent, str__pchTitle.Pointer, str__pchDescription.Pointer, str__pchIcon.Pointer, unPriority, ePossibleClip );
		}
		
		#region SteamAPI_ISteamTimeline_EndRangeTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_EndRangeTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_EndRangeTimelineEvent( IntPtr self, TimelineEventHandle_t ulEvent, float flEndOffsetSeconds );
		#endregion
		internal void EndRangeTimelineEvent( TimelineEventHandle_t ulEvent, float flEndOffsetSeconds )
		{
			_SteamAPI_ISteamTimeline_EndRangeTimelineEvent( Self, ulEvent, flEndOffsetSeconds );
		}
		
		#region SteamAPI_ISteamTimeline_RemoveTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_RemoveTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_RemoveTimelineEvent( IntPtr self, TimelineEventHandle_t ulEvent );
		#endregion
		internal void RemoveTimelineEvent( TimelineEventHandle_t ulEvent )
		{
			_SteamAPI_ISteamTimeline_RemoveTimelineEvent( Self, ulEvent );
		}
		
		#region SteamAPI_ISteamTimeline_DoesEventRecordingExist
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_DoesEventRecordingExist", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamTimeline_DoesEventRecordingExist( IntPtr self, TimelineEventHandle_t ulEvent );
		#endregion
		internal CallResult<SteamTimelineEventRecordingExists_t> DoesEventRecordingExist( TimelineEventHandle_t ulEvent )
		{
			var returnValue = _SteamAPI_ISteamTimeline_DoesEventRecordingExist( Self, ulEvent );
			return new CallResult<SteamTimelineEventRecordingExists_t>( returnValue );
		}
		
		#region SteamAPI_ISteamTimeline_StartGamePhase
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_StartGamePhase", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_StartGamePhase( IntPtr self );
		#endregion
		internal void StartGamePhase()
		{
			_SteamAPI_ISteamTimeline_StartGamePhase( Self );
		}
		
		#region SteamAPI_ISteamTimeline_EndGamePhase
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_EndGamePhase", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_EndGamePhase( IntPtr self );
		#endregion
		internal void EndGamePhase()
		{
			_SteamAPI_ISteamTimeline_EndGamePhase( Self );
		}
		
		#region SteamAPI_ISteamTimeline_SetGamePhaseID
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_SetGamePhaseID", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_SetGamePhaseID( IntPtr self, IntPtr pchPhaseID );
		#endregion
		internal void SetGamePhaseID( string pchPhaseID )
		{
			using var str__pchPhaseID = new Utf8StringToNative( pchPhaseID );
			_SteamAPI_ISteamTimeline_SetGamePhaseID( Self, str__pchPhaseID.Pointer );
		}
		
		#region SteamAPI_ISteamTimeline_DoesGamePhaseRecordingExist
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_DoesGamePhaseRecordingExist", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamTimeline_DoesGamePhaseRecordingExist( IntPtr self, IntPtr pchPhaseID );
		#endregion
		internal CallResult<SteamTimelineGamePhaseRecordingExists_t> DoesGamePhaseRecordingExist( string pchPhaseID )
		{
			using var str__pchPhaseID = new Utf8StringToNative( pchPhaseID );
			var returnValue = _SteamAPI_ISteamTimeline_DoesGamePhaseRecordingExist( Self, str__pchPhaseID.Pointer );
			return new CallResult<SteamTimelineGamePhaseRecordingExists_t>( returnValue );
		}
		
		#region SteamAPI_ISteamTimeline_AddGamePhaseTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_AddGamePhaseTag", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_AddGamePhaseTag( IntPtr self, IntPtr pchTagName, IntPtr pchTagIcon, IntPtr pchTagGroup, uint unPriority );
		#endregion
		internal void AddGamePhaseTag( string pchTagName, string pchTagIcon, string pchTagGroup, uint unPriority )
		{
			using var str__pchTagName = new Utf8StringToNative( pchTagName );
			using var str__pchTagIcon = new Utf8StringToNative( pchTagIcon );
			using var str__pchTagGroup = new Utf8StringToNative( pchTagGroup );
			_SteamAPI_ISteamTimeline_AddGamePhaseTag( Self, str__pchTagName.Pointer, str__pchTagIcon.Pointer, str__pchTagGroup.Pointer, unPriority );
		}
		
		#region SteamAPI_ISteamTimeline_SetGamePhaseAttribute
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_SetGamePhaseAttribute", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_SetGamePhaseAttribute( IntPtr self, IntPtr pchAttributeGroup, IntPtr pchAttributeValue, uint unPriority );
		#endregion
		internal void SetGamePhaseAttribute( string pchAttributeGroup, string pchAttributeValue, uint unPriority )
		{
			using var str__pchAttributeGroup = new Utf8StringToNative( pchAttributeGroup );
			using var str__pchAttributeValue = new Utf8StringToNative( pchAttributeValue );
			_SteamAPI_ISteamTimeline_SetGamePhaseAttribute( Self, str__pchAttributeGroup.Pointer, str__pchAttributeValue.Pointer, unPriority );
		}
		
		#region SteamAPI_ISteamTimeline_OpenOverlayToGamePhase
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_OpenOverlayToGamePhase", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_OpenOverlayToGamePhase( IntPtr self, IntPtr pchPhaseID );
		#endregion
		internal void OpenOverlayToGamePhase( string pchPhaseID )
		{
			using var str__pchPhaseID = new Utf8StringToNative( pchPhaseID );
			_SteamAPI_ISteamTimeline_OpenOverlayToGamePhase( Self, str__pchPhaseID.Pointer );
		}
		
		#region SteamAPI_ISteamTimeline_OpenOverlayToTimelineEvent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamTimeline_OpenOverlayToTimelineEvent", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamTimeline_OpenOverlayToTimelineEvent( IntPtr self, TimelineEventHandle_t ulEvent );
		#endregion
		internal void OpenOverlayToTimelineEvent( TimelineEventHandle_t ulEvent )
		{
			_SteamAPI_ISteamTimeline_OpenOverlayToTimelineEvent( Self, ulEvent );
		}
		
	}
}
