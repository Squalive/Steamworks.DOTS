using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMusic
	{
		public const string Version = "STEAMMUSIC_INTERFACE_VERSION001";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamMusic_v001", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamMusic_v001();
		/// Construct use accessor to find interface
		public ISteamMusic( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamMusic_v001();
			}
		}
		public ISteamMusic( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMusic_BIsEnabled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_BIsEnabled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusic_BIsEnabled( IntPtr self );
		internal bool _BIsEnabled(  ) => _SteamAPI_ISteamMusic_BIsEnabled( Self );
		#endregion
		internal bool BIsEnabled()
		{
			var returnValue = _SteamAPI_ISteamMusic_BIsEnabled( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusic_BIsPlaying
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_BIsPlaying", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusic_BIsPlaying( IntPtr self );
		internal bool _BIsPlaying(  ) => _SteamAPI_ISteamMusic_BIsPlaying( Self );
		#endregion
		internal bool BIsPlaying()
		{
			var returnValue = _SteamAPI_ISteamMusic_BIsPlaying( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusic_GetPlaybackStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_GetPlaybackStatus", CallingConvention = Platform.CC ) ]
		internal static extern AudioPlayback_Status _SteamAPI_ISteamMusic_GetPlaybackStatus( IntPtr self );
		internal AudioPlayback_Status _GetPlaybackStatus(  ) => _SteamAPI_ISteamMusic_GetPlaybackStatus( Self );
		#endregion
		internal AudioPlayback_Status GetPlaybackStatus()
		{
			var returnValue = _SteamAPI_ISteamMusic_GetPlaybackStatus( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusic_Play
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_Play", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMusic_Play( IntPtr self );
		internal void _Play(  ) => _SteamAPI_ISteamMusic_Play( Self );
		#endregion
		internal void Play()
		{
			_SteamAPI_ISteamMusic_Play( Self );
		}
		
		#region SteamAPI_ISteamMusic_Pause
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_Pause", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMusic_Pause( IntPtr self );
		internal void _Pause(  ) => _SteamAPI_ISteamMusic_Pause( Self );
		#endregion
		internal void Pause()
		{
			_SteamAPI_ISteamMusic_Pause( Self );
		}
		
		#region SteamAPI_ISteamMusic_PlayPrevious
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_PlayPrevious", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMusic_PlayPrevious( IntPtr self );
		internal void _PlayPrevious(  ) => _SteamAPI_ISteamMusic_PlayPrevious( Self );
		#endregion
		internal void PlayPrevious()
		{
			_SteamAPI_ISteamMusic_PlayPrevious( Self );
		}
		
		#region SteamAPI_ISteamMusic_PlayNext
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_PlayNext", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMusic_PlayNext( IntPtr self );
		internal void _PlayNext(  ) => _SteamAPI_ISteamMusic_PlayNext( Self );
		#endregion
		internal void PlayNext()
		{
			_SteamAPI_ISteamMusic_PlayNext( Self );
		}
		
		#region SteamAPI_ISteamMusic_SetVolume
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_SetVolume", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMusic_SetVolume( IntPtr self, float flVolume );
		internal void _SetVolume( float flVolume ) => _SteamAPI_ISteamMusic_SetVolume( Self, flVolume );
		#endregion
		internal void SetVolume( float flVolume )
		{
			_SteamAPI_ISteamMusic_SetVolume( Self, flVolume );
		}
		
		#region SteamAPI_ISteamMusic_GetVolume
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_GetVolume", CallingConvention = Platform.CC ) ]
		internal static extern float _SteamAPI_ISteamMusic_GetVolume( IntPtr self );
		internal float _GetVolume(  ) => _SteamAPI_ISteamMusic_GetVolume( Self );
		#endregion
		internal float GetVolume()
		{
			var returnValue = _SteamAPI_ISteamMusic_GetVolume( Self );
			return returnValue;
		}
		
	}
}
