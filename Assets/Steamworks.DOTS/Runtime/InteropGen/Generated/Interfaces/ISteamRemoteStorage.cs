using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamRemoteStorage
	{
		public const string Version = "STEAMREMOTESTORAGE_INTERFACE_VERSION016";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamRemoteStorage_v016", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamRemoteStorage_v016();
		/// Construct use accessor to find interface
		public ISteamRemoteStorage( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamRemoteStorage_v016();
			}
		}
		public ISteamRemoteStorage( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamRemoteStorage_FileWrite
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWrite", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileWrite( IntPtr self, IntPtr pchFile, IntPtr pvData, int cubData );
		internal bool _FileWrite( IntPtr pchFile, IntPtr pvData, int cubData ) => _SteamAPI_ISteamRemoteStorage_FileWrite( Self, pchFile, pvData, cubData );
		#endregion
		internal bool FileWrite( string pchFile, IntPtr pvData, int cubData )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileWrite( Self, str__pchFile.Pointer, pvData, cubData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileRead
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileRead", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamRemoteStorage_FileRead( IntPtr self, IntPtr pchFile, IntPtr pvData, int cubDataToRead );
		internal int _FileRead( IntPtr pchFile, IntPtr pvData, int cubDataToRead ) => _SteamAPI_ISteamRemoteStorage_FileRead( Self, pchFile, pvData, cubDataToRead );
		#endregion
		internal int FileRead( string pchFile, IntPtr pvData, int cubDataToRead )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileRead( Self, str__pchFile.Pointer, pvData, cubDataToRead );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileWriteAsync
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteAsync", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamRemoteStorage_FileWriteAsync( IntPtr self, IntPtr pchFile, IntPtr pvData, uint cubData );
		internal SteamAPICall_t _FileWriteAsync( IntPtr pchFile, IntPtr pvData, uint cubData ) => _SteamAPI_ISteamRemoteStorage_FileWriteAsync( Self, pchFile, pvData, cubData );
		#endregion
		internal CallResult<RemoteStorageFileWriteAsyncComplete_t> FileWriteAsync( string pchFile, IntPtr pvData, uint cubData )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileWriteAsync( Self, str__pchFile.Pointer, pvData, cubData );
			return new CallResult<RemoteStorageFileWriteAsyncComplete_t>( returnValue );
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileReadAsync
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileReadAsync", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamRemoteStorage_FileReadAsync( IntPtr self, IntPtr pchFile, uint nOffset, uint cubToRead );
		internal SteamAPICall_t _FileReadAsync( IntPtr pchFile, uint nOffset, uint cubToRead ) => _SteamAPI_ISteamRemoteStorage_FileReadAsync( Self, pchFile, nOffset, cubToRead );
		#endregion
		internal CallResult<RemoteStorageFileReadAsyncComplete_t> FileReadAsync( string pchFile, uint nOffset, uint cubToRead )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileReadAsync( Self, str__pchFile.Pointer, nOffset, cubToRead );
			return new CallResult<RemoteStorageFileReadAsyncComplete_t>( returnValue );
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete( IntPtr self, SteamAPICall_t hReadCall, IntPtr pvBuffer, uint cubToRead );
		internal bool _FileReadAsyncComplete( SteamAPICall_t hReadCall, IntPtr pvBuffer, uint cubToRead ) => _SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete( Self, hReadCall, pvBuffer, cubToRead );
		#endregion
		internal bool FileReadAsyncComplete( SteamAPICall_t hReadCall, IntPtr pvBuffer, uint cubToRead )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete( Self, hReadCall, pvBuffer, cubToRead );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileForget
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileForget", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileForget( IntPtr self, IntPtr pchFile );
		internal bool _FileForget( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_FileForget( Self, pchFile );
		#endregion
		internal bool FileForget( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileForget( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileDelete
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileDelete", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileDelete( IntPtr self, IntPtr pchFile );
		internal bool _FileDelete( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_FileDelete( Self, pchFile );
		#endregion
		internal bool FileDelete( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileDelete( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileShare
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileShare", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamRemoteStorage_FileShare( IntPtr self, IntPtr pchFile );
		internal SteamAPICall_t _FileShare( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_FileShare( Self, pchFile );
		#endregion
		internal CallResult<RemoteStorageFileShareResult_t> FileShare( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileShare( Self, str__pchFile.Pointer );
			return new CallResult<RemoteStorageFileShareResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamRemoteStorage_SetSyncPlatforms
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetSyncPlatforms", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_SetSyncPlatforms( IntPtr self, IntPtr pchFile, ERemoteStoragePlatform eRemoteStoragePlatform );
		internal bool _SetSyncPlatforms( IntPtr pchFile, ERemoteStoragePlatform eRemoteStoragePlatform ) => _SteamAPI_ISteamRemoteStorage_SetSyncPlatforms( Self, pchFile, eRemoteStoragePlatform );
		#endregion
		internal bool SetSyncPlatforms( string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_SetSyncPlatforms( Self, str__pchFile.Pointer, eRemoteStoragePlatform );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen", CallingConvention = Platform.CC ) ]
		internal static extern UGCFileWriteStreamHandle_t _SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen( IntPtr self, IntPtr pchFile );
		internal UGCFileWriteStreamHandle_t _FileWriteStreamOpen( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen( Self, pchFile );
		#endregion
		internal UGCFileWriteStreamHandle_t FileWriteStreamOpen( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk( IntPtr self, UGCFileWriteStreamHandle_t writeHandle, IntPtr pvData, int cubData );
		internal bool _FileWriteStreamWriteChunk( UGCFileWriteStreamHandle_t writeHandle, IntPtr pvData, int cubData ) => _SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk( Self, writeHandle, pvData, cubData );
		#endregion
		internal bool FileWriteStreamWriteChunk( UGCFileWriteStreamHandle_t writeHandle, IntPtr pvData, int cubData )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk( Self, writeHandle, pvData, cubData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileWriteStreamClose
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamClose", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileWriteStreamClose( IntPtr self, UGCFileWriteStreamHandle_t writeHandle );
		internal bool _FileWriteStreamClose( UGCFileWriteStreamHandle_t writeHandle ) => _SteamAPI_ISteamRemoteStorage_FileWriteStreamClose( Self, writeHandle );
		#endregion
		internal bool FileWriteStreamClose( UGCFileWriteStreamHandle_t writeHandle )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileWriteStreamClose( Self, writeHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel( IntPtr self, UGCFileWriteStreamHandle_t writeHandle );
		internal bool _FileWriteStreamCancel( UGCFileWriteStreamHandle_t writeHandle ) => _SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel( Self, writeHandle );
		#endregion
		internal bool FileWriteStreamCancel( UGCFileWriteStreamHandle_t writeHandle )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel( Self, writeHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FileExists
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileExists", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FileExists( IntPtr self, IntPtr pchFile );
		internal bool _FileExists( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_FileExists( Self, pchFile );
		#endregion
		internal bool FileExists( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FileExists( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_FilePersisted
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_FilePersisted", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_FilePersisted( IntPtr self, IntPtr pchFile );
		internal bool _FilePersisted( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_FilePersisted( Self, pchFile );
		#endregion
		internal bool FilePersisted( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_FilePersisted( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetFileSize
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileSize", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamRemoteStorage_GetFileSize( IntPtr self, IntPtr pchFile );
		internal int _GetFileSize( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_GetFileSize( Self, pchFile );
		#endregion
		internal int GetFileSize( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetFileSize( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetFileTimestamp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileTimestamp", CallingConvention = Platform.CC ) ]
		internal static extern long _SteamAPI_ISteamRemoteStorage_GetFileTimestamp( IntPtr self, IntPtr pchFile );
		internal long _GetFileTimestamp( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_GetFileTimestamp( Self, pchFile );
		#endregion
		internal long GetFileTimestamp( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetFileTimestamp( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetSyncPlatforms
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetSyncPlatforms", CallingConvention = Platform.CC ) ]
		internal static extern ERemoteStoragePlatform _SteamAPI_ISteamRemoteStorage_GetSyncPlatforms( IntPtr self, IntPtr pchFile );
		internal ERemoteStoragePlatform _GetSyncPlatforms( IntPtr pchFile ) => _SteamAPI_ISteamRemoteStorage_GetSyncPlatforms( Self, pchFile );
		#endregion
		internal ERemoteStoragePlatform GetSyncPlatforms( string pchFile )
		{
			using var str__pchFile = new Utf8StringToNative( pchFile );
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetSyncPlatforms( Self, str__pchFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetFileCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamRemoteStorage_GetFileCount( IntPtr self );
		internal int _GetFileCount(  ) => _SteamAPI_ISteamRemoteStorage_GetFileCount( Self );
		#endregion
		internal int GetFileCount()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetFileCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetFileNameAndSize
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileNameAndSize", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamRemoteStorage_GetFileNameAndSize( IntPtr self, int iFile, ref int pnFileSizeInBytes );
		internal Utf8StringPtr _GetFileNameAndSize( int iFile, ref int pnFileSizeInBytes ) => _SteamAPI_ISteamRemoteStorage_GetFileNameAndSize( Self, iFile, ref pnFileSizeInBytes );
		#endregion
		internal string GetFileNameAndSize( int iFile, ref int pnFileSizeInBytes )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetFileNameAndSize( Self, iFile, ref pnFileSizeInBytes );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetQuota
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetQuota", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_GetQuota( IntPtr self, ref ulong pnTotalBytes, ref ulong puAvailableBytes );
		internal bool _GetQuota( ref ulong pnTotalBytes, ref ulong puAvailableBytes ) => _SteamAPI_ISteamRemoteStorage_GetQuota( Self, ref pnTotalBytes, ref puAvailableBytes );
		#endregion
		internal bool GetQuota( ref ulong pnTotalBytes, ref ulong puAvailableBytes )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetQuota( Self, ref pnTotalBytes, ref puAvailableBytes );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount( IntPtr self );
		internal bool _IsCloudEnabledForAccount(  ) => _SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount( Self );
		#endregion
		internal bool IsCloudEnabledForAccount()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp( IntPtr self );
		internal bool _IsCloudEnabledForApp(  ) => _SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp( Self );
		#endregion
		internal bool IsCloudEnabledForApp()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bEnabled );
		internal void _SetCloudEnabledForApp( [ MarshalAs( UnmanagedType.U1 ) ] bool bEnabled ) => _SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp( Self, bEnabled );
		#endregion
		internal void SetCloudEnabledForApp( [ MarshalAs( UnmanagedType.U1 ) ] bool bEnabled )
		{
			_SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp( Self, bEnabled );
		}
		
		#region SteamAPI_ISteamRemoteStorage_UGCDownload
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCDownload", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamRemoteStorage_UGCDownload( IntPtr self, UGCHandle_t hContent, uint unPriority );
		internal SteamAPICall_t _UGCDownload( UGCHandle_t hContent, uint unPriority ) => _SteamAPI_ISteamRemoteStorage_UGCDownload( Self, hContent, unPriority );
		#endregion
		internal CallResult<RemoteStorageDownloadUGCResult_t> UGCDownload( UGCHandle_t hContent, uint unPriority )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_UGCDownload( Self, hContent, unPriority );
			return new CallResult<RemoteStorageDownloadUGCResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress( IntPtr self, UGCHandle_t hContent, ref int pnBytesDownloaded, ref int pnBytesExpected );
		internal bool _GetUGCDownloadProgress( UGCHandle_t hContent, ref int pnBytesDownloaded, ref int pnBytesExpected ) => _SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress( Self, hContent, ref pnBytesDownloaded, ref pnBytesExpected );
		#endregion
		internal bool GetUGCDownloadProgress( UGCHandle_t hContent, ref int pnBytesDownloaded, ref int pnBytesExpected )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress( Self, hContent, ref pnBytesDownloaded, ref pnBytesExpected );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetUGCDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUGCDetails", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_GetUGCDetails( IntPtr self, UGCHandle_t hContent, ref AppId_t pnAppID, ref char* ppchName, ref int pnFileSizeInBytes, ref SteamId pSteamIDOwner );
		internal bool _GetUGCDetails( UGCHandle_t hContent, ref AppId_t pnAppID, ref char* ppchName, ref int pnFileSizeInBytes, ref SteamId pSteamIDOwner ) => _SteamAPI_ISteamRemoteStorage_GetUGCDetails( Self, hContent, ref pnAppID, ref ppchName, ref pnFileSizeInBytes, ref pSteamIDOwner );
		#endregion
		internal bool GetUGCDetails( UGCHandle_t hContent, ref AppId_t pnAppID, ref char* ppchName, ref int pnFileSizeInBytes, ref SteamId pSteamIDOwner )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetUGCDetails( Self, hContent, ref pnAppID, ref ppchName, ref pnFileSizeInBytes, ref pSteamIDOwner );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_UGCRead
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCRead", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamRemoteStorage_UGCRead( IntPtr self, UGCHandle_t hContent, IntPtr pvData, int cubDataToRead, uint cOffset, EUGCReadAction eAction );
		internal int _UGCRead( UGCHandle_t hContent, IntPtr pvData, int cubDataToRead, uint cOffset, EUGCReadAction eAction ) => _SteamAPI_ISteamRemoteStorage_UGCRead( Self, hContent, pvData, cubDataToRead, cOffset, eAction );
		#endregion
		internal int UGCRead( UGCHandle_t hContent, IntPtr pvData, int cubDataToRead, uint cOffset, EUGCReadAction eAction )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_UGCRead( Self, hContent, pvData, cubDataToRead, cOffset, eAction );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetCachedUGCCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetCachedUGCCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamRemoteStorage_GetCachedUGCCount( IntPtr self );
		internal int _GetCachedUGCCount(  ) => _SteamAPI_ISteamRemoteStorage_GetCachedUGCCount( Self );
		#endregion
		internal int GetCachedUGCCount()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetCachedUGCCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle", CallingConvention = Platform.CC ) ]
		internal static extern UGCHandle_t _SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle( IntPtr self, int iCachedContent );
		internal UGCHandle_t _GetCachedUGCHandle( int iCachedContent ) => _SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle( Self, iCachedContent );
		#endregion
		internal UGCHandle_t GetCachedUGCHandle( int iCachedContent )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle( Self, iCachedContent );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation( IntPtr self, UGCHandle_t hContent, IntPtr pchLocation, uint unPriority );
		internal SteamAPICall_t _UGCDownloadToLocation( UGCHandle_t hContent, IntPtr pchLocation, uint unPriority ) => _SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation( Self, hContent, pchLocation, unPriority );
		#endregion
		internal CallResult<RemoteStorageDownloadUGCResult_t> UGCDownloadToLocation( UGCHandle_t hContent, string pchLocation, uint unPriority )
		{
			using var str__pchLocation = new Utf8StringToNative( pchLocation );
			var returnValue = _SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation( Self, hContent, str__pchLocation.Pointer, unPriority );
			return new CallResult<RemoteStorageDownloadUGCResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetLocalFileChangeCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetLocalFileChangeCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamRemoteStorage_GetLocalFileChangeCount( IntPtr self );
		internal int _GetLocalFileChangeCount(  ) => _SteamAPI_ISteamRemoteStorage_GetLocalFileChangeCount( Self );
		#endregion
		internal int GetLocalFileChangeCount()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetLocalFileChangeCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_GetLocalFileChange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetLocalFileChange", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamRemoteStorage_GetLocalFileChange( IntPtr self, int iFile, ref ERemoteStorageLocalFileChange pEChangeType, ref ERemoteStorageFilePathType pEFilePathType );
		internal Utf8StringPtr _GetLocalFileChange( int iFile, ref ERemoteStorageLocalFileChange pEChangeType, ref ERemoteStorageFilePathType pEFilePathType ) => _SteamAPI_ISteamRemoteStorage_GetLocalFileChange( Self, iFile, ref pEChangeType, ref pEFilePathType );
		#endregion
		internal string GetLocalFileChange( int iFile, ref ERemoteStorageLocalFileChange pEChangeType, ref ERemoteStorageFilePathType pEFilePathType )
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_GetLocalFileChange( Self, iFile, ref pEChangeType, ref pEFilePathType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_BeginFileWriteBatch
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_BeginFileWriteBatch", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_BeginFileWriteBatch( IntPtr self );
		internal bool _BeginFileWriteBatch(  ) => _SteamAPI_ISteamRemoteStorage_BeginFileWriteBatch( Self );
		#endregion
		internal bool BeginFileWriteBatch()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_BeginFileWriteBatch( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamRemoteStorage_EndFileWriteBatch
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamRemoteStorage_EndFileWriteBatch", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamRemoteStorage_EndFileWriteBatch( IntPtr self );
		internal bool _EndFileWriteBatch(  ) => _SteamAPI_ISteamRemoteStorage_EndFileWriteBatch( Self );
		#endregion
		internal bool EndFileWriteBatch()
		{
			var returnValue = _SteamAPI_ISteamRemoteStorage_EndFileWriteBatch( Self );
			return returnValue;
		}
		
	}
}
