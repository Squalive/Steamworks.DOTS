using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMusicRemote
	{
		public const string Version = "STEAMMUSICREMOTE_INTERFACE_VERSION001";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamMusicRemote_v001", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamMusicRemote_v001();
		/// Construct use accessor to find interface
		public ISteamMusicRemote( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamMusicRemote_v001();
			}
		}
		public ISteamMusicRemote( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote( IntPtr self, IntPtr pchName );
		#endregion
		internal bool RegisterSteamMusicRemote( string pchName )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote( Self, str__pchName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote( IntPtr self );
		#endregion
		internal bool DeregisterSteamMusicRemote()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote( IntPtr self );
		#endregion
		internal bool BIsCurrentMusicRemote()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_BActivationSuccess
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_BActivationSuccess", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_BActivationSuccess( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool BActivationSuccess( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_BActivationSuccess( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_SetDisplayName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_SetDisplayName", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_SetDisplayName( IntPtr self, IntPtr pchDisplayName );
		#endregion
		internal bool SetDisplayName( string pchDisplayName )
		{
			using var str__pchDisplayName = new Utf8StringToNative( pchDisplayName );
			var returnValue = _SteamAPI_ISteamMusicRemote_SetDisplayName( Self, str__pchDisplayName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64( IntPtr self, IntPtr pvBuffer, uint cbBufferLength );
		#endregion
		internal bool SetPNGIcon_64x64( IntPtr pvBuffer, uint cbBufferLength )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64( Self, pvBuffer, cbBufferLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_EnablePlayPrevious
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayPrevious", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_EnablePlayPrevious( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool EnablePlayPrevious( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_EnablePlayPrevious( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_EnablePlayNext
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayNext", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_EnablePlayNext( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool EnablePlayNext( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_EnablePlayNext( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_EnableShuffled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableShuffled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_EnableShuffled( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool EnableShuffled( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_EnableShuffled( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_EnableLooped
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableLooped", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_EnableLooped( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool EnableLooped( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_EnableLooped( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_EnableQueue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableQueue", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_EnableQueue( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool EnableQueue( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_EnableQueue( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_EnablePlaylists
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlaylists", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_EnablePlaylists( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool EnablePlaylists( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_EnablePlaylists( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus( IntPtr self, AudioPlayback_Status nStatus );
		#endregion
		internal bool UpdatePlaybackStatus( AudioPlayback_Status nStatus )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus( Self, nStatus );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdateShuffled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateShuffled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdateShuffled( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool UpdateShuffled( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdateShuffled( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdateLooped
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateLooped", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdateLooped( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bValue );
		#endregion
		internal bool UpdateLooped( [ MarshalAs( UnmanagedType.U1 ) ] bool bValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdateLooped( Self, bValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdateVolume
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateVolume", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdateVolume( IntPtr self, float flValue );
		#endregion
		internal bool UpdateVolume( float flValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdateVolume( Self, flValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_CurrentEntryWillChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryWillChange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_CurrentEntryWillChange( IntPtr self );
		#endregion
		internal bool CurrentEntryWillChange()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_CurrentEntryWillChange( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bAvailable );
		#endregion
		internal bool CurrentEntryIsAvailable( [ MarshalAs( UnmanagedType.U1 ) ] bool bAvailable )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable( Self, bAvailable );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText( IntPtr self, IntPtr pchText );
		#endregion
		internal bool UpdateCurrentEntryText( string pchText )
		{
			using var str__pchText = new Utf8StringToNative( pchText );
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText( Self, str__pchText.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds( IntPtr self, int nValue );
		#endregion
		internal bool UpdateCurrentEntryElapsedSeconds( int nValue )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds( Self, nValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt( IntPtr self, IntPtr pvBuffer, uint cbBufferLength );
		#endregion
		internal bool UpdateCurrentEntryCoverArt( IntPtr pvBuffer, uint cbBufferLength )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt( Self, pvBuffer, cbBufferLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_CurrentEntryDidChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryDidChange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_CurrentEntryDidChange( IntPtr self );
		#endregion
		internal bool CurrentEntryDidChange()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_CurrentEntryDidChange( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_QueueWillChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueWillChange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_QueueWillChange( IntPtr self );
		#endregion
		internal bool QueueWillChange()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_QueueWillChange( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_ResetQueueEntries
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetQueueEntries", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_ResetQueueEntries( IntPtr self );
		#endregion
		internal bool ResetQueueEntries()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_ResetQueueEntries( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_SetQueueEntry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_SetQueueEntry", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_SetQueueEntry( IntPtr self, int nID, int nPosition, IntPtr pchEntryText );
		#endregion
		internal bool SetQueueEntry( int nID, int nPosition, string pchEntryText )
		{
			using var str__pchEntryText = new Utf8StringToNative( pchEntryText );
			var returnValue = _SteamAPI_ISteamMusicRemote_SetQueueEntry( Self, nID, nPosition, str__pchEntryText.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry( IntPtr self, int nID );
		#endregion
		internal bool SetCurrentQueueEntry( int nID )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry( Self, nID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_QueueDidChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueDidChange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_QueueDidChange( IntPtr self );
		#endregion
		internal bool QueueDidChange()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_QueueDidChange( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_PlaylistWillChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistWillChange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_PlaylistWillChange( IntPtr self );
		#endregion
		internal bool PlaylistWillChange()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_PlaylistWillChange( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_ResetPlaylistEntries
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetPlaylistEntries", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_ResetPlaylistEntries( IntPtr self );
		#endregion
		internal bool ResetPlaylistEntries()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_ResetPlaylistEntries( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_SetPlaylistEntry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPlaylistEntry", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_SetPlaylistEntry( IntPtr self, int nID, int nPosition, IntPtr pchEntryText );
		#endregion
		internal bool SetPlaylistEntry( int nID, int nPosition, string pchEntryText )
		{
			using var str__pchEntryText = new Utf8StringToNative( pchEntryText );
			var returnValue = _SteamAPI_ISteamMusicRemote_SetPlaylistEntry( Self, nID, nPosition, str__pchEntryText.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry( IntPtr self, int nID );
		#endregion
		internal bool SetCurrentPlaylistEntry( int nID )
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry( Self, nID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMusicRemote_PlaylistDidChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistDidChange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMusicRemote_PlaylistDidChange( IntPtr self );
		#endregion
		internal bool PlaylistDidChange()
		{
			var returnValue = _SteamAPI_ISteamMusicRemote_PlaylistDidChange( Self );
			return returnValue;
		}
		
	}
}
