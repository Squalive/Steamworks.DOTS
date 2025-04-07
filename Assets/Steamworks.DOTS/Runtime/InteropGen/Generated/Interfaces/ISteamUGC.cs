using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamUGC
	{
		public const string Version = "STEAMUGC_INTERFACE_VERSION021";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamUGC_v021", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamUGC_v021();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerUGC_v021", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerUGC_v021();
		/// Construct use accessor to find interface
		public ISteamUGC( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamUGC_v021();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerUGC_v021();
			}
		}
		public ISteamUGC( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamUGC_CreateQueryUserUGCRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUserUGCRequest", CallingConvention = Platform.CC ) ]
		internal static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryUserUGCRequest( IntPtr self, AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage );
		internal UGCQueryHandle_t _CreateQueryUserUGCRequest( AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage ) => _SteamAPI_ISteamUGC_CreateQueryUserUGCRequest( Self, unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage );
		#endregion
		internal UGCQueryHandle_t CreateQueryUserUGCRequest( AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryUserUGCRequest( Self, unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage", CallingConvention = Platform.CC ) ]
		internal static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage( IntPtr self, EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage );
		internal UGCQueryHandle_t _CreateQueryAllUGCRequest( EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage ) => _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage( Self, eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage );
		#endregion
		internal UGCQueryHandle_t CreateQueryAllUGCRequest( EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage( Self, eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor", CallingConvention = Platform.CC ) ]
		internal static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor( IntPtr self, EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, IntPtr pchCursor );
		internal UGCQueryHandle_t _CreateQueryAllUGCRequest( EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, IntPtr pchCursor ) => _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor( Self, eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, pchCursor );
		#endregion
		internal UGCQueryHandle_t CreateQueryAllUGCRequest( EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, string pchCursor )
		{
			using var str__pchCursor = new Utf8StringToNative( pchCursor );
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor( Self, eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, str__pchCursor.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest", CallingConvention = Platform.CC ) ]
		internal static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs );
		internal UGCQueryHandle_t _CreateQueryUGCDetailsRequest( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs ) => _SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest( Self, pvecPublishedFileID, unNumPublishedFileIDs );
		#endregion
		internal UGCQueryHandle_t CreateQueryUGCDetailsRequest( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest( Self, pvecPublishedFileID, unNumPublishedFileIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SendQueryUGCRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SendQueryUGCRequest", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_SendQueryUGCRequest( IntPtr self, UGCQueryHandle_t handle );
		internal SteamAPICall_t _SendQueryUGCRequest( UGCQueryHandle_t handle ) => _SteamAPI_ISteamUGC_SendQueryUGCRequest( Self, handle );
		#endregion
		internal CallResult<SteamUGCQueryCompleted_t> SendQueryUGCRequest( UGCQueryHandle_t handle )
		{
			var returnValue = _SteamAPI_ISteamUGC_SendQueryUGCRequest( Self, handle );
			return new CallResult<SteamUGCQueryCompleted_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCResult", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCResult( IntPtr self, UGCQueryHandle_t handle, uint index, ref SteamUGCDetails_t pDetails );
		internal bool _GetQueryUGCResult( UGCQueryHandle_t handle, uint index, ref SteamUGCDetails_t pDetails ) => _SteamAPI_ISteamUGC_GetQueryUGCResult( Self, handle, index, ref pDetails );
		#endregion
		internal bool GetQueryUGCResult( UGCQueryHandle_t handle, uint index, ref SteamUGCDetails_t pDetails )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCResult( Self, handle, index, ref pDetails );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCNumTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumTags", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetQueryUGCNumTags( IntPtr self, UGCQueryHandle_t handle, uint index );
		internal uint _GetQueryUGCNumTags( UGCQueryHandle_t handle, uint index ) => _SteamAPI_ISteamUGC_GetQueryUGCNumTags( Self, handle, index );
		#endregion
		internal uint GetQueryUGCNumTags( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCNumTags( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCTag( IntPtr self, UGCQueryHandle_t handle, uint index, uint indexTag, IntPtr pchValue, uint cchValueSize );
		internal bool _GetQueryUGCTag( UGCQueryHandle_t handle, uint index, uint indexTag, IntPtr pchValue, uint cchValueSize ) => _SteamAPI_ISteamUGC_GetQueryUGCTag( Self, handle, index, indexTag, pchValue, cchValueSize );
		#endregion
		internal bool GetQueryUGCTag( UGCQueryHandle_t handle, uint index, uint indexTag, out string pchValue, uint cchValueSize )
		{
			using var mem__pchValue = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCTag( Self, handle, index, indexTag, mem__pchValue.Ptr, cchValueSize );
			pchValue = Utility.MemoryToString( mem__pchValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCTagDisplayName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCTagDisplayName", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCTagDisplayName( IntPtr self, UGCQueryHandle_t handle, uint index, uint indexTag, IntPtr pchValue, uint cchValueSize );
		internal bool _GetQueryUGCTagDisplayName( UGCQueryHandle_t handle, uint index, uint indexTag, IntPtr pchValue, uint cchValueSize ) => _SteamAPI_ISteamUGC_GetQueryUGCTagDisplayName( Self, handle, index, indexTag, pchValue, cchValueSize );
		#endregion
		internal bool GetQueryUGCTagDisplayName( UGCQueryHandle_t handle, uint index, uint indexTag, out string pchValue, uint cchValueSize )
		{
			using var mem__pchValue = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCTagDisplayName( Self, handle, index, indexTag, mem__pchValue.Ptr, cchValueSize );
			pchValue = Utility.MemoryToString( mem__pchValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCPreviewURL
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCPreviewURL", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCPreviewURL( IntPtr self, UGCQueryHandle_t handle, uint index, IntPtr pchURL, uint cchURLSize );
		internal bool _GetQueryUGCPreviewURL( UGCQueryHandle_t handle, uint index, IntPtr pchURL, uint cchURLSize ) => _SteamAPI_ISteamUGC_GetQueryUGCPreviewURL( Self, handle, index, pchURL, cchURLSize );
		#endregion
		internal bool GetQueryUGCPreviewURL( UGCQueryHandle_t handle, uint index, out string pchURL, uint cchURLSize )
		{
			using var mem__pchURL = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCPreviewURL( Self, handle, index, mem__pchURL.Ptr, cchURLSize );
			pchURL = Utility.MemoryToString( mem__pchURL );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCMetadata
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCMetadata", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCMetadata( IntPtr self, UGCQueryHandle_t handle, uint index, IntPtr pchMetadata, uint cchMetadatasize );
		internal bool _GetQueryUGCMetadata( UGCQueryHandle_t handle, uint index, IntPtr pchMetadata, uint cchMetadatasize ) => _SteamAPI_ISteamUGC_GetQueryUGCMetadata( Self, handle, index, pchMetadata, cchMetadatasize );
		#endregion
		internal bool GetQueryUGCMetadata( UGCQueryHandle_t handle, uint index, out string pchMetadata, uint cchMetadatasize )
		{
			using var mem__pchMetadata = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCMetadata( Self, handle, index, mem__pchMetadata.Ptr, cchMetadatasize );
			pchMetadata = Utility.MemoryToString( mem__pchMetadata );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCChildren
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCChildren", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCChildren( IntPtr self, UGCQueryHandle_t handle, uint index, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries );
		internal bool _GetQueryUGCChildren( UGCQueryHandle_t handle, uint index, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries ) => _SteamAPI_ISteamUGC_GetQueryUGCChildren( Self, handle, index, pvecPublishedFileID, cMaxEntries );
		#endregion
		internal bool GetQueryUGCChildren( UGCQueryHandle_t handle, uint index, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCChildren( Self, handle, index, pvecPublishedFileID, cMaxEntries );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCStatistic
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCStatistic", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCStatistic( IntPtr self, UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, ref ulong pStatValue );
		internal bool _GetQueryUGCStatistic( UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, ref ulong pStatValue ) => _SteamAPI_ISteamUGC_GetQueryUGCStatistic( Self, handle, index, eStatType, ref pStatValue );
		#endregion
		internal bool GetQueryUGCStatistic( UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, ref ulong pStatValue )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCStatistic( Self, handle, index, eStatType, ref pStatValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews( IntPtr self, UGCQueryHandle_t handle, uint index );
		internal uint _GetQueryUGCNumAdditionalPreviews( UGCQueryHandle_t handle, uint index ) => _SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews( Self, handle, index );
		#endregion
		internal uint GetQueryUGCNumAdditionalPreviews( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview( IntPtr self, UGCQueryHandle_t handle, uint index, uint previewIndex, IntPtr pchURLOrVideoID, uint cchURLSize, IntPtr pchOriginalFileName, uint cchOriginalFileNameSize, ref EItemPreviewType pPreviewType );
		internal bool _GetQueryUGCAdditionalPreview( UGCQueryHandle_t handle, uint index, uint previewIndex, IntPtr pchURLOrVideoID, uint cchURLSize, IntPtr pchOriginalFileName, uint cchOriginalFileNameSize, ref EItemPreviewType pPreviewType ) => _SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview( Self, handle, index, previewIndex, pchURLOrVideoID, cchURLSize, pchOriginalFileName, cchOriginalFileNameSize, ref pPreviewType );
		#endregion
		internal bool GetQueryUGCAdditionalPreview( UGCQueryHandle_t handle, uint index, uint previewIndex, out string pchURLOrVideoID, uint cchURLSize, out string pchOriginalFileName, uint cchOriginalFileNameSize, ref EItemPreviewType pPreviewType )
		{
			using var mem__pchURLOrVideoID = new Utility.Memory( Utility.MemoryBufferSize );
			using var mem__pchOriginalFileName = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview( Self, handle, index, previewIndex, mem__pchURLOrVideoID.Ptr, cchURLSize, mem__pchOriginalFileName.Ptr, cchOriginalFileNameSize, ref pPreviewType );
			pchURLOrVideoID = Utility.MemoryToString( mem__pchURLOrVideoID );
			pchOriginalFileName = Utility.MemoryToString( mem__pchOriginalFileName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags( IntPtr self, UGCQueryHandle_t handle, uint index );
		internal uint _GetQueryUGCNumKeyValueTags( UGCQueryHandle_t handle, uint index ) => _SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags( Self, handle, index );
		#endregion
		internal uint GetQueryUGCNumKeyValueTags( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag( IntPtr self, UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, IntPtr pchKey, uint cchKeySize, IntPtr pchValue, uint cchValueSize );
		internal bool _GetQueryUGCKeyValueTag( UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, IntPtr pchKey, uint cchKeySize, IntPtr pchValue, uint cchValueSize ) => _SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag( Self, handle, index, keyValueTagIndex, pchKey, cchKeySize, pchValue, cchValueSize );
		#endregion
		internal bool GetQueryUGCKeyValueTag( UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, out string pchKey, uint cchKeySize, out string pchValue, uint cchValueSize )
		{
			using var mem__pchKey = new Utility.Memory( Utility.MemoryBufferSize );
			using var mem__pchValue = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag( Self, handle, index, keyValueTagIndex, mem__pchKey.Ptr, cchKeySize, mem__pchValue.Ptr, cchValueSize );
			pchKey = Utility.MemoryToString( mem__pchKey );
			pchValue = Utility.MemoryToString( mem__pchValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryFirstUGCKeyValueTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryFirstUGCKeyValueTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetQueryFirstUGCKeyValueTag( IntPtr self, UGCQueryHandle_t handle, uint index, IntPtr pchKey, IntPtr pchValue, uint cchValueSize );
		internal bool _GetQueryUGCKeyValueTag( UGCQueryHandle_t handle, uint index, IntPtr pchKey, IntPtr pchValue, uint cchValueSize ) => _SteamAPI_ISteamUGC_GetQueryFirstUGCKeyValueTag( Self, handle, index, pchKey, pchValue, cchValueSize );
		#endregion
		internal bool GetQueryUGCKeyValueTag( UGCQueryHandle_t handle, uint index, string pchKey, out string pchValue, uint cchValueSize )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var mem__pchValue = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetQueryFirstUGCKeyValueTag( Self, handle, index, str__pchKey.Pointer, mem__pchValue.Ptr, cchValueSize );
			pchValue = Utility.MemoryToString( mem__pchValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetNumSupportedGameVersions
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetNumSupportedGameVersions", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetNumSupportedGameVersions( IntPtr self, UGCQueryHandle_t handle, uint index );
		internal uint _GetNumSupportedGameVersions( UGCQueryHandle_t handle, uint index ) => _SteamAPI_ISteamUGC_GetNumSupportedGameVersions( Self, handle, index );
		#endregion
		internal uint GetNumSupportedGameVersions( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetNumSupportedGameVersions( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetSupportedGameVersionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetSupportedGameVersionData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetSupportedGameVersionData( IntPtr self, UGCQueryHandle_t handle, uint index, uint versionIndex, IntPtr pchGameBranchMin, IntPtr pchGameBranchMax, uint cchGameBranchSize );
		internal bool _GetSupportedGameVersionData( UGCQueryHandle_t handle, uint index, uint versionIndex, IntPtr pchGameBranchMin, IntPtr pchGameBranchMax, uint cchGameBranchSize ) => _SteamAPI_ISteamUGC_GetSupportedGameVersionData( Self, handle, index, versionIndex, pchGameBranchMin, pchGameBranchMax, cchGameBranchSize );
		#endregion
		internal bool GetSupportedGameVersionData( UGCQueryHandle_t handle, uint index, uint versionIndex, out string pchGameBranchMin, out string pchGameBranchMax, uint cchGameBranchSize )
		{
			using var mem__pchGameBranchMin = new Utility.Memory( Utility.MemoryBufferSize );
			using var mem__pchGameBranchMax = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetSupportedGameVersionData( Self, handle, index, versionIndex, mem__pchGameBranchMin.Ptr, mem__pchGameBranchMax.Ptr, cchGameBranchSize );
			pchGameBranchMin = Utility.MemoryToString( mem__pchGameBranchMin );
			pchGameBranchMax = Utility.MemoryToString( mem__pchGameBranchMax );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors( IntPtr self, UGCQueryHandle_t handle, uint index, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries );
		internal uint _GetQueryUGCContentDescriptors( UGCQueryHandle_t handle, uint index, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries ) => _SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors( Self, handle, index, pvecDescriptors, cMaxEntries );
		#endregion
		internal uint GetQueryUGCContentDescriptors( UGCQueryHandle_t handle, uint index, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors( Self, handle, index, pvecDescriptors, cMaxEntries );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_ReleaseQueryUGCRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_ReleaseQueryUGCRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_ReleaseQueryUGCRequest( IntPtr self, UGCQueryHandle_t handle );
		internal bool _ReleaseQueryUGCRequest( UGCQueryHandle_t handle ) => _SteamAPI_ISteamUGC_ReleaseQueryUGCRequest( Self, handle );
		#endregion
		internal bool ReleaseQueryUGCRequest( UGCQueryHandle_t handle )
		{
			var returnValue = _SteamAPI_ISteamUGC_ReleaseQueryUGCRequest( Self, handle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddRequiredTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddRequiredTag( IntPtr self, UGCQueryHandle_t handle, IntPtr pTagName );
		internal bool _AddRequiredTag( UGCQueryHandle_t handle, IntPtr pTagName ) => _SteamAPI_ISteamUGC_AddRequiredTag( Self, handle, pTagName );
		#endregion
		internal bool AddRequiredTag( UGCQueryHandle_t handle, string pTagName )
		{
			using var str__pTagName = new Utf8StringToNative( pTagName );
			var returnValue = _SteamAPI_ISteamUGC_AddRequiredTag( Self, handle, str__pTagName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddRequiredTagGroup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredTagGroup", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddRequiredTagGroup( IntPtr self, UGCQueryHandle_t handle, ref SteamParamStringArray_t pTagGroups );
		internal bool _AddRequiredTagGroup( UGCQueryHandle_t handle, ref SteamParamStringArray_t pTagGroups ) => _SteamAPI_ISteamUGC_AddRequiredTagGroup( Self, handle, ref pTagGroups );
		#endregion
		internal bool AddRequiredTagGroup( UGCQueryHandle_t handle, ref SteamParamStringArray_t pTagGroups )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddRequiredTagGroup( Self, handle, ref pTagGroups );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddExcludedTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddExcludedTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddExcludedTag( IntPtr self, UGCQueryHandle_t handle, IntPtr pTagName );
		internal bool _AddExcludedTag( UGCQueryHandle_t handle, IntPtr pTagName ) => _SteamAPI_ISteamUGC_AddExcludedTag( Self, handle, pTagName );
		#endregion
		internal bool AddExcludedTag( UGCQueryHandle_t handle, string pTagName )
		{
			using var str__pTagName = new Utf8StringToNative( pTagName );
			var returnValue = _SteamAPI_ISteamUGC_AddExcludedTag( Self, handle, str__pTagName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnOnlyIDs
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnOnlyIDs", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnOnlyIDs( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnOnlyIDs );
		internal bool _SetReturnOnlyIDs( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnOnlyIDs ) => _SteamAPI_ISteamUGC_SetReturnOnlyIDs( Self, handle, bReturnOnlyIDs );
		#endregion
		internal bool SetReturnOnlyIDs( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnOnlyIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnOnlyIDs( Self, handle, bReturnOnlyIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnKeyValueTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnKeyValueTags( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnKeyValueTags );
		internal bool _SetReturnKeyValueTags( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnKeyValueTags ) => _SteamAPI_ISteamUGC_SetReturnKeyValueTags( Self, handle, bReturnKeyValueTags );
		#endregion
		internal bool SetReturnKeyValueTags( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnKeyValueTags )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnKeyValueTags( Self, handle, bReturnKeyValueTags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnLongDescription
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnLongDescription", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnLongDescription( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnLongDescription );
		internal bool _SetReturnLongDescription( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnLongDescription ) => _SteamAPI_ISteamUGC_SetReturnLongDescription( Self, handle, bReturnLongDescription );
		#endregion
		internal bool SetReturnLongDescription( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnLongDescription )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnLongDescription( Self, handle, bReturnLongDescription );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnMetadata
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnMetadata", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnMetadata( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnMetadata );
		internal bool _SetReturnMetadata( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnMetadata ) => _SteamAPI_ISteamUGC_SetReturnMetadata( Self, handle, bReturnMetadata );
		#endregion
		internal bool SetReturnMetadata( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnMetadata )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnMetadata( Self, handle, bReturnMetadata );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnChildren
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnChildren", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnChildren( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnChildren );
		internal bool _SetReturnChildren( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnChildren ) => _SteamAPI_ISteamUGC_SetReturnChildren( Self, handle, bReturnChildren );
		#endregion
		internal bool SetReturnChildren( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnChildren )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnChildren( Self, handle, bReturnChildren );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnAdditionalPreviews
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnAdditionalPreviews", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnAdditionalPreviews( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnAdditionalPreviews );
		internal bool _SetReturnAdditionalPreviews( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnAdditionalPreviews ) => _SteamAPI_ISteamUGC_SetReturnAdditionalPreviews( Self, handle, bReturnAdditionalPreviews );
		#endregion
		internal bool SetReturnAdditionalPreviews( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnAdditionalPreviews )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnAdditionalPreviews( Self, handle, bReturnAdditionalPreviews );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnTotalOnly
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnTotalOnly", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnTotalOnly( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnTotalOnly );
		internal bool _SetReturnTotalOnly( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnTotalOnly ) => _SteamAPI_ISteamUGC_SetReturnTotalOnly( Self, handle, bReturnTotalOnly );
		#endregion
		internal bool SetReturnTotalOnly( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnTotalOnly )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnTotalOnly( Self, handle, bReturnTotalOnly );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnPlaytimeStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnPlaytimeStats", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetReturnPlaytimeStats( IntPtr self, UGCQueryHandle_t handle, uint unDays );
		internal bool _SetReturnPlaytimeStats( UGCQueryHandle_t handle, uint unDays ) => _SteamAPI_ISteamUGC_SetReturnPlaytimeStats( Self, handle, unDays );
		#endregion
		internal bool SetReturnPlaytimeStats( UGCQueryHandle_t handle, uint unDays )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnPlaytimeStats( Self, handle, unDays );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetLanguage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetLanguage", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetLanguage( IntPtr self, UGCQueryHandle_t handle, IntPtr pchLanguage );
		internal bool _SetLanguage( UGCQueryHandle_t handle, IntPtr pchLanguage ) => _SteamAPI_ISteamUGC_SetLanguage( Self, handle, pchLanguage );
		#endregion
		internal bool SetLanguage( UGCQueryHandle_t handle, string pchLanguage )
		{
			using var str__pchLanguage = new Utf8StringToNative( pchLanguage );
			var returnValue = _SteamAPI_ISteamUGC_SetLanguage( Self, handle, str__pchLanguage.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetAllowCachedResponse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetAllowCachedResponse", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetAllowCachedResponse( IntPtr self, UGCQueryHandle_t handle, uint unMaxAgeSeconds );
		internal bool _SetAllowCachedResponse( UGCQueryHandle_t handle, uint unMaxAgeSeconds ) => _SteamAPI_ISteamUGC_SetAllowCachedResponse( Self, handle, unMaxAgeSeconds );
		#endregion
		internal bool SetAllowCachedResponse( UGCQueryHandle_t handle, uint unMaxAgeSeconds )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetAllowCachedResponse( Self, handle, unMaxAgeSeconds );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetAdminQuery
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetAdminQuery", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetAdminQuery( IntPtr self, UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAdminQuery );
		internal bool _SetAdminQuery( UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAdminQuery ) => _SteamAPI_ISteamUGC_SetAdminQuery( Self, handle, bAdminQuery );
		#endregion
		internal bool SetAdminQuery( UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAdminQuery )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetAdminQuery( Self, handle, bAdminQuery );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetCloudFileNameFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetCloudFileNameFilter", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetCloudFileNameFilter( IntPtr self, UGCQueryHandle_t handle, IntPtr pMatchCloudFileName );
		internal bool _SetCloudFileNameFilter( UGCQueryHandle_t handle, IntPtr pMatchCloudFileName ) => _SteamAPI_ISteamUGC_SetCloudFileNameFilter( Self, handle, pMatchCloudFileName );
		#endregion
		internal bool SetCloudFileNameFilter( UGCQueryHandle_t handle, string pMatchCloudFileName )
		{
			using var str__pMatchCloudFileName = new Utf8StringToNative( pMatchCloudFileName );
			var returnValue = _SteamAPI_ISteamUGC_SetCloudFileNameFilter( Self, handle, str__pMatchCloudFileName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetMatchAnyTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetMatchAnyTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetMatchAnyTag( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bMatchAnyTag );
		internal bool _SetMatchAnyTag( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bMatchAnyTag ) => _SteamAPI_ISteamUGC_SetMatchAnyTag( Self, handle, bMatchAnyTag );
		#endregion
		internal bool SetMatchAnyTag( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bMatchAnyTag )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetMatchAnyTag( Self, handle, bMatchAnyTag );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetSearchText
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetSearchText", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetSearchText( IntPtr self, UGCQueryHandle_t handle, IntPtr pSearchText );
		internal bool _SetSearchText( UGCQueryHandle_t handle, IntPtr pSearchText ) => _SteamAPI_ISteamUGC_SetSearchText( Self, handle, pSearchText );
		#endregion
		internal bool SetSearchText( UGCQueryHandle_t handle, string pSearchText )
		{
			using var str__pSearchText = new Utf8StringToNative( pSearchText );
			var returnValue = _SteamAPI_ISteamUGC_SetSearchText( Self, handle, str__pSearchText.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetRankedByTrendDays
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetRankedByTrendDays", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetRankedByTrendDays( IntPtr self, UGCQueryHandle_t handle, uint unDays );
		internal bool _SetRankedByTrendDays( UGCQueryHandle_t handle, uint unDays ) => _SteamAPI_ISteamUGC_SetRankedByTrendDays( Self, handle, unDays );
		#endregion
		internal bool SetRankedByTrendDays( UGCQueryHandle_t handle, uint unDays )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetRankedByTrendDays( Self, handle, unDays );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetTimeCreatedDateRange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetTimeCreatedDateRange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetTimeCreatedDateRange( IntPtr self, UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd );
		internal bool _SetTimeCreatedDateRange( UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd ) => _SteamAPI_ISteamUGC_SetTimeCreatedDateRange( Self, handle, rtStart, rtEnd );
		#endregion
		internal bool SetTimeCreatedDateRange( UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetTimeCreatedDateRange( Self, handle, rtStart, rtEnd );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetTimeUpdatedDateRange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetTimeUpdatedDateRange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetTimeUpdatedDateRange( IntPtr self, UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd );
		internal bool _SetTimeUpdatedDateRange( UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd ) => _SteamAPI_ISteamUGC_SetTimeUpdatedDateRange( Self, handle, rtStart, rtEnd );
		#endregion
		internal bool SetTimeUpdatedDateRange( UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetTimeUpdatedDateRange( Self, handle, rtStart, rtEnd );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddRequiredKeyValueTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredKeyValueTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddRequiredKeyValueTag( IntPtr self, UGCQueryHandle_t handle, IntPtr pKey, IntPtr pValue );
		internal bool _AddRequiredKeyValueTag( UGCQueryHandle_t handle, IntPtr pKey, IntPtr pValue ) => _SteamAPI_ISteamUGC_AddRequiredKeyValueTag( Self, handle, pKey, pValue );
		#endregion
		internal bool AddRequiredKeyValueTag( UGCQueryHandle_t handle, string pKey, string pValue )
		{
			using var str__pKey = new Utf8StringToNative( pKey );
			using var str__pValue = new Utf8StringToNative( pValue );
			var returnValue = _SteamAPI_ISteamUGC_AddRequiredKeyValueTag( Self, handle, str__pKey.Pointer, str__pValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateItem", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_CreateItem( IntPtr self, AppId_t nConsumerAppId, EWorkshopFileType eFileType );
		internal SteamAPICall_t _CreateItem( AppId_t nConsumerAppId, EWorkshopFileType eFileType ) => _SteamAPI_ISteamUGC_CreateItem( Self, nConsumerAppId, eFileType );
		#endregion
		internal CallResult<CreateItemResult_t> CreateItem( AppId_t nConsumerAppId, EWorkshopFileType eFileType )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateItem( Self, nConsumerAppId, eFileType );
			return new CallResult<CreateItemResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_StartItemUpdate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StartItemUpdate", CallingConvention = Platform.CC ) ]
		internal static extern UGCUpdateHandle_t _SteamAPI_ISteamUGC_StartItemUpdate( IntPtr self, AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID );
		internal UGCUpdateHandle_t _StartItemUpdate( AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_StartItemUpdate( Self, nConsumerAppId, nPublishedFileID );
		#endregion
		internal UGCUpdateHandle_t StartItemUpdate( AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_StartItemUpdate( Self, nConsumerAppId, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemTitle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemTitle", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemTitle( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchTitle );
		internal bool _SetItemTitle( UGCUpdateHandle_t handle, IntPtr pchTitle ) => _SteamAPI_ISteamUGC_SetItemTitle( Self, handle, pchTitle );
		#endregion
		internal bool SetItemTitle( UGCUpdateHandle_t handle, string pchTitle )
		{
			using var str__pchTitle = new Utf8StringToNative( pchTitle );
			var returnValue = _SteamAPI_ISteamUGC_SetItemTitle( Self, handle, str__pchTitle.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemDescription
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemDescription", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemDescription( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchDescription );
		internal bool _SetItemDescription( UGCUpdateHandle_t handle, IntPtr pchDescription ) => _SteamAPI_ISteamUGC_SetItemDescription( Self, handle, pchDescription );
		#endregion
		internal bool SetItemDescription( UGCUpdateHandle_t handle, string pchDescription )
		{
			using var str__pchDescription = new Utf8StringToNative( pchDescription );
			var returnValue = _SteamAPI_ISteamUGC_SetItemDescription( Self, handle, str__pchDescription.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemUpdateLanguage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemUpdateLanguage", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemUpdateLanguage( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchLanguage );
		internal bool _SetItemUpdateLanguage( UGCUpdateHandle_t handle, IntPtr pchLanguage ) => _SteamAPI_ISteamUGC_SetItemUpdateLanguage( Self, handle, pchLanguage );
		#endregion
		internal bool SetItemUpdateLanguage( UGCUpdateHandle_t handle, string pchLanguage )
		{
			using var str__pchLanguage = new Utf8StringToNative( pchLanguage );
			var returnValue = _SteamAPI_ISteamUGC_SetItemUpdateLanguage( Self, handle, str__pchLanguage.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemMetadata
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemMetadata", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemMetadata( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchMetaData );
		internal bool _SetItemMetadata( UGCUpdateHandle_t handle, IntPtr pchMetaData ) => _SteamAPI_ISteamUGC_SetItemMetadata( Self, handle, pchMetaData );
		#endregion
		internal bool SetItemMetadata( UGCUpdateHandle_t handle, string pchMetaData )
		{
			using var str__pchMetaData = new Utf8StringToNative( pchMetaData );
			var returnValue = _SteamAPI_ISteamUGC_SetItemMetadata( Self, handle, str__pchMetaData.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemVisibility
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemVisibility", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemVisibility( IntPtr self, UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility );
		internal bool _SetItemVisibility( UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility ) => _SteamAPI_ISteamUGC_SetItemVisibility( Self, handle, eVisibility );
		#endregion
		internal bool SetItemVisibility( UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetItemVisibility( Self, handle, eVisibility );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemTags( IntPtr self, UGCUpdateHandle_t updateHandle, ref SteamParamStringArray_t pTags, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowAdminTags );
		internal bool _SetItemTags( UGCUpdateHandle_t updateHandle, ref SteamParamStringArray_t pTags, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowAdminTags ) => _SteamAPI_ISteamUGC_SetItemTags( Self, updateHandle, ref pTags, bAllowAdminTags );
		#endregion
		internal bool SetItemTags( UGCUpdateHandle_t updateHandle, ref SteamParamStringArray_t pTags, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowAdminTags )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetItemTags( Self, updateHandle, ref pTags, bAllowAdminTags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemContent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemContent", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemContent( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszContentFolder );
		internal bool _SetItemContent( UGCUpdateHandle_t handle, IntPtr pszContentFolder ) => _SteamAPI_ISteamUGC_SetItemContent( Self, handle, pszContentFolder );
		#endregion
		internal bool SetItemContent( UGCUpdateHandle_t handle, string pszContentFolder )
		{
			using var str__pszContentFolder = new Utf8StringToNative( pszContentFolder );
			var returnValue = _SteamAPI_ISteamUGC_SetItemContent( Self, handle, str__pszContentFolder.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemPreview
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemPreview", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemPreview( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszPreviewFile );
		internal bool _SetItemPreview( UGCUpdateHandle_t handle, IntPtr pszPreviewFile ) => _SteamAPI_ISteamUGC_SetItemPreview( Self, handle, pszPreviewFile );
		#endregion
		internal bool SetItemPreview( UGCUpdateHandle_t handle, string pszPreviewFile )
		{
			using var str__pszPreviewFile = new Utf8StringToNative( pszPreviewFile );
			var returnValue = _SteamAPI_ISteamUGC_SetItemPreview( Self, handle, str__pszPreviewFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetAllowLegacyUpload
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetAllowLegacyUpload", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetAllowLegacyUpload( IntPtr self, UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowLegacyUpload );
		internal bool _SetAllowLegacyUpload( UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowLegacyUpload ) => _SteamAPI_ISteamUGC_SetAllowLegacyUpload( Self, handle, bAllowLegacyUpload );
		#endregion
		internal bool SetAllowLegacyUpload( UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowLegacyUpload )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetAllowLegacyUpload( Self, handle, bAllowLegacyUpload );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags( IntPtr self, UGCUpdateHandle_t handle );
		internal bool _RemoveAllItemKeyValueTags( UGCUpdateHandle_t handle ) => _SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags( Self, handle );
		#endregion
		internal bool RemoveAllItemKeyValueTags( UGCUpdateHandle_t handle )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags( Self, handle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveItemKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemKeyValueTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_RemoveItemKeyValueTags( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchKey );
		internal bool _RemoveItemKeyValueTags( UGCUpdateHandle_t handle, IntPtr pchKey ) => _SteamAPI_ISteamUGC_RemoveItemKeyValueTags( Self, handle, pchKey );
		#endregion
		internal bool RemoveItemKeyValueTags( UGCUpdateHandle_t handle, string pchKey )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamUGC_RemoveItemKeyValueTags( Self, handle, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddItemKeyValueTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddItemKeyValueTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddItemKeyValueTag( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchKey, IntPtr pchValue );
		internal bool _AddItemKeyValueTag( UGCUpdateHandle_t handle, IntPtr pchKey, IntPtr pchValue ) => _SteamAPI_ISteamUGC_AddItemKeyValueTag( Self, handle, pchKey, pchValue );
		#endregion
		internal bool AddItemKeyValueTag( UGCUpdateHandle_t handle, string pchKey, string pchValue )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			var returnValue = _SteamAPI_ISteamUGC_AddItemKeyValueTag( Self, handle, str__pchKey.Pointer, str__pchValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddItemPreviewFile
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddItemPreviewFile", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddItemPreviewFile( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszPreviewFile, EItemPreviewType type );
		internal bool _AddItemPreviewFile( UGCUpdateHandle_t handle, IntPtr pszPreviewFile, EItemPreviewType type ) => _SteamAPI_ISteamUGC_AddItemPreviewFile( Self, handle, pszPreviewFile, type );
		#endregion
		internal bool AddItemPreviewFile( UGCUpdateHandle_t handle, string pszPreviewFile, EItemPreviewType type )
		{
			using var str__pszPreviewFile = new Utf8StringToNative( pszPreviewFile );
			var returnValue = _SteamAPI_ISteamUGC_AddItemPreviewFile( Self, handle, str__pszPreviewFile.Pointer, type );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddItemPreviewVideo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddItemPreviewVideo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddItemPreviewVideo( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszVideoID );
		internal bool _AddItemPreviewVideo( UGCUpdateHandle_t handle, IntPtr pszVideoID ) => _SteamAPI_ISteamUGC_AddItemPreviewVideo( Self, handle, pszVideoID );
		#endregion
		internal bool AddItemPreviewVideo( UGCUpdateHandle_t handle, string pszVideoID )
		{
			using var str__pszVideoID = new Utf8StringToNative( pszVideoID );
			var returnValue = _SteamAPI_ISteamUGC_AddItemPreviewVideo( Self, handle, str__pszVideoID.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_UpdateItemPreviewFile
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_UpdateItemPreviewFile", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_UpdateItemPreviewFile( IntPtr self, UGCUpdateHandle_t handle, uint index, IntPtr pszPreviewFile );
		internal bool _UpdateItemPreviewFile( UGCUpdateHandle_t handle, uint index, IntPtr pszPreviewFile ) => _SteamAPI_ISteamUGC_UpdateItemPreviewFile( Self, handle, index, pszPreviewFile );
		#endregion
		internal bool UpdateItemPreviewFile( UGCUpdateHandle_t handle, uint index, string pszPreviewFile )
		{
			using var str__pszPreviewFile = new Utf8StringToNative( pszPreviewFile );
			var returnValue = _SteamAPI_ISteamUGC_UpdateItemPreviewFile( Self, handle, index, str__pszPreviewFile.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_UpdateItemPreviewVideo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_UpdateItemPreviewVideo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_UpdateItemPreviewVideo( IntPtr self, UGCUpdateHandle_t handle, uint index, IntPtr pszVideoID );
		internal bool _UpdateItemPreviewVideo( UGCUpdateHandle_t handle, uint index, IntPtr pszVideoID ) => _SteamAPI_ISteamUGC_UpdateItemPreviewVideo( Self, handle, index, pszVideoID );
		#endregion
		internal bool UpdateItemPreviewVideo( UGCUpdateHandle_t handle, uint index, string pszVideoID )
		{
			using var str__pszVideoID = new Utf8StringToNative( pszVideoID );
			var returnValue = _SteamAPI_ISteamUGC_UpdateItemPreviewVideo( Self, handle, index, str__pszVideoID.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveItemPreview
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemPreview", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_RemoveItemPreview( IntPtr self, UGCUpdateHandle_t handle, uint index );
		internal bool _RemoveItemPreview( UGCUpdateHandle_t handle, uint index ) => _SteamAPI_ISteamUGC_RemoveItemPreview( Self, handle, index );
		#endregion
		internal bool RemoveItemPreview( UGCUpdateHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveItemPreview( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddContentDescriptor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddContentDescriptor", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_AddContentDescriptor( IntPtr self, UGCUpdateHandle_t handle, EUGCContentDescriptorID descid );
		internal bool _AddContentDescriptor( UGCUpdateHandle_t handle, EUGCContentDescriptorID descid ) => _SteamAPI_ISteamUGC_AddContentDescriptor( Self, handle, descid );
		#endregion
		internal bool AddContentDescriptor( UGCUpdateHandle_t handle, EUGCContentDescriptorID descid )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddContentDescriptor( Self, handle, descid );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveContentDescriptor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveContentDescriptor", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_RemoveContentDescriptor( IntPtr self, UGCUpdateHandle_t handle, EUGCContentDescriptorID descid );
		internal bool _RemoveContentDescriptor( UGCUpdateHandle_t handle, EUGCContentDescriptorID descid ) => _SteamAPI_ISteamUGC_RemoveContentDescriptor( Self, handle, descid );
		#endregion
		internal bool RemoveContentDescriptor( UGCUpdateHandle_t handle, EUGCContentDescriptorID descid )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveContentDescriptor( Self, handle, descid );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetRequiredGameVersions
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetRequiredGameVersions", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetRequiredGameVersions( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszGameBranchMin, IntPtr pszGameBranchMax );
		internal bool _SetRequiredGameVersions( UGCUpdateHandle_t handle, IntPtr pszGameBranchMin, IntPtr pszGameBranchMax ) => _SteamAPI_ISteamUGC_SetRequiredGameVersions( Self, handle, pszGameBranchMin, pszGameBranchMax );
		#endregion
		internal bool SetRequiredGameVersions( UGCUpdateHandle_t handle, string pszGameBranchMin, string pszGameBranchMax )
		{
			using var str__pszGameBranchMin = new Utf8StringToNative( pszGameBranchMin );
			using var str__pszGameBranchMax = new Utf8StringToNative( pszGameBranchMax );
			var returnValue = _SteamAPI_ISteamUGC_SetRequiredGameVersions( Self, handle, str__pszGameBranchMin.Pointer, str__pszGameBranchMax.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SubmitItemUpdate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SubmitItemUpdate", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_SubmitItemUpdate( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchChangeNote );
		internal SteamAPICall_t _SubmitItemUpdate( UGCUpdateHandle_t handle, IntPtr pchChangeNote ) => _SteamAPI_ISteamUGC_SubmitItemUpdate( Self, handle, pchChangeNote );
		#endregion
		internal CallResult<SubmitItemUpdateResult_t> SubmitItemUpdate( UGCUpdateHandle_t handle, string pchChangeNote )
		{
			using var str__pchChangeNote = new Utf8StringToNative( pchChangeNote );
			var returnValue = _SteamAPI_ISteamUGC_SubmitItemUpdate( Self, handle, str__pchChangeNote.Pointer );
			return new CallResult<SubmitItemUpdateResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_GetItemUpdateProgress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemUpdateProgress", CallingConvention = Platform.CC ) ]
		internal static extern EItemUpdateStatus _SteamAPI_ISteamUGC_GetItemUpdateProgress( IntPtr self, UGCUpdateHandle_t handle, ref ulong punBytesProcessed, ref ulong punBytesTotal );
		internal EItemUpdateStatus _GetItemUpdateProgress( UGCUpdateHandle_t handle, ref ulong punBytesProcessed, ref ulong punBytesTotal ) => _SteamAPI_ISteamUGC_GetItemUpdateProgress( Self, handle, ref punBytesProcessed, ref punBytesTotal );
		#endregion
		internal EItemUpdateStatus GetItemUpdateProgress( UGCUpdateHandle_t handle, ref ulong punBytesProcessed, ref ulong punBytesTotal )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetItemUpdateProgress( Self, handle, ref punBytesProcessed, ref punBytesTotal );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetUserItemVote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetUserItemVote", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_SetUserItemVote( IntPtr self, PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVoteUp );
		internal SteamAPICall_t _SetUserItemVote( PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVoteUp ) => _SteamAPI_ISteamUGC_SetUserItemVote( Self, nPublishedFileID, bVoteUp );
		#endregion
		internal CallResult<SetUserItemVoteResult_t> SetUserItemVote( PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVoteUp )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetUserItemVote( Self, nPublishedFileID, bVoteUp );
			return new CallResult<SetUserItemVoteResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_GetUserItemVote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetUserItemVote", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_GetUserItemVote( IntPtr self, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _GetUserItemVote( PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_GetUserItemVote( Self, nPublishedFileID );
		#endregion
		internal CallResult<GetUserItemVoteResult_t> GetUserItemVote( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetUserItemVote( Self, nPublishedFileID );
			return new CallResult<GetUserItemVoteResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_AddItemToFavorites
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddItemToFavorites", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_AddItemToFavorites( IntPtr self, AppId_t nAppId, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _AddItemToFavorites( AppId_t nAppId, PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_AddItemToFavorites( Self, nAppId, nPublishedFileID );
		#endregion
		internal CallResult<UserFavoriteItemsListChanged_t> AddItemToFavorites( AppId_t nAppId, PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddItemToFavorites( Self, nAppId, nPublishedFileID );
			return new CallResult<UserFavoriteItemsListChanged_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_RemoveItemFromFavorites
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemFromFavorites", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_RemoveItemFromFavorites( IntPtr self, AppId_t nAppId, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _RemoveItemFromFavorites( AppId_t nAppId, PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_RemoveItemFromFavorites( Self, nAppId, nPublishedFileID );
		#endregion
		internal CallResult<UserFavoriteItemsListChanged_t> RemoveItemFromFavorites( AppId_t nAppId, PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveItemFromFavorites( Self, nAppId, nPublishedFileID );
			return new CallResult<UserFavoriteItemsListChanged_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_SubscribeItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SubscribeItem", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_SubscribeItem( IntPtr self, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _SubscribeItem( PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_SubscribeItem( Self, nPublishedFileID );
		#endregion
		internal CallResult<RemoteStorageSubscribePublishedFileResult_t> SubscribeItem( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_SubscribeItem( Self, nPublishedFileID );
			return new CallResult<RemoteStorageSubscribePublishedFileResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_UnsubscribeItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_UnsubscribeItem", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_UnsubscribeItem( IntPtr self, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _UnsubscribeItem( PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_UnsubscribeItem( Self, nPublishedFileID );
		#endregion
		internal CallResult<RemoteStorageUnsubscribePublishedFileResult_t> UnsubscribeItem( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_UnsubscribeItem( Self, nPublishedFileID );
			return new CallResult<RemoteStorageUnsubscribePublishedFileResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_GetNumSubscribedItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetNumSubscribedItems", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetNumSubscribedItems( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled );
		internal uint _GetNumSubscribedItems( [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled ) => _SteamAPI_ISteamUGC_GetNumSubscribedItems( Self, bIncludeLocallyDisabled );
		#endregion
		internal uint GetNumSubscribedItems( [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetNumSubscribedItems( Self, bIncludeLocallyDisabled );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetSubscribedItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetSubscribedItems", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetSubscribedItems( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled );
		internal uint _GetSubscribedItems( PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled ) => _SteamAPI_ISteamUGC_GetSubscribedItems( Self, pvecPublishedFileID, cMaxEntries, bIncludeLocallyDisabled );
		#endregion
		internal uint GetSubscribedItems( PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetSubscribedItems( Self, pvecPublishedFileID, cMaxEntries, bIncludeLocallyDisabled );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetItemState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemState", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetItemState( IntPtr self, PublishedFileId_t nPublishedFileID );
		internal uint _GetItemState( PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_GetItemState( Self, nPublishedFileID );
		#endregion
		internal uint GetItemState( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetItemState( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetItemInstallInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemInstallInfo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetItemInstallInfo( IntPtr self, PublishedFileId_t nPublishedFileID, ref ulong punSizeOnDisk, IntPtr pchFolder, uint cchFolderSize, ref uint punTimeStamp );
		internal bool _GetItemInstallInfo( PublishedFileId_t nPublishedFileID, ref ulong punSizeOnDisk, IntPtr pchFolder, uint cchFolderSize, ref uint punTimeStamp ) => _SteamAPI_ISteamUGC_GetItemInstallInfo( Self, nPublishedFileID, ref punSizeOnDisk, pchFolder, cchFolderSize, ref punTimeStamp );
		#endregion
		internal bool GetItemInstallInfo( PublishedFileId_t nPublishedFileID, ref ulong punSizeOnDisk, out string pchFolder, uint cchFolderSize, ref uint punTimeStamp )
		{
			using var mem__pchFolder = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUGC_GetItemInstallInfo( Self, nPublishedFileID, ref punSizeOnDisk, mem__pchFolder.Ptr, cchFolderSize, ref punTimeStamp );
			pchFolder = Utility.MemoryToString( mem__pchFolder );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetItemDownloadInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemDownloadInfo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_GetItemDownloadInfo( IntPtr self, PublishedFileId_t nPublishedFileID, ref ulong punBytesDownloaded, ref ulong punBytesTotal );
		internal bool _GetItemDownloadInfo( PublishedFileId_t nPublishedFileID, ref ulong punBytesDownloaded, ref ulong punBytesTotal ) => _SteamAPI_ISteamUGC_GetItemDownloadInfo( Self, nPublishedFileID, ref punBytesDownloaded, ref punBytesTotal );
		#endregion
		internal bool GetItemDownloadInfo( PublishedFileId_t nPublishedFileID, ref ulong punBytesDownloaded, ref ulong punBytesTotal )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetItemDownloadInfo( Self, nPublishedFileID, ref punBytesDownloaded, ref punBytesTotal );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_DownloadItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_DownloadItem", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_DownloadItem( IntPtr self, PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bHighPriority );
		internal bool _DownloadItem( PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bHighPriority ) => _SteamAPI_ISteamUGC_DownloadItem( Self, nPublishedFileID, bHighPriority );
		#endregion
		internal bool DownloadItem( PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bHighPriority )
		{
			var returnValue = _SteamAPI_ISteamUGC_DownloadItem( Self, nPublishedFileID, bHighPriority );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_BInitWorkshopForGameServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_BInitWorkshopForGameServer", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_BInitWorkshopForGameServer( IntPtr self, DepotId_t unWorkshopDepotID, IntPtr pszFolder );
		internal bool _BInitWorkshopForGameServer( DepotId_t unWorkshopDepotID, IntPtr pszFolder ) => _SteamAPI_ISteamUGC_BInitWorkshopForGameServer( Self, unWorkshopDepotID, pszFolder );
		#endregion
		internal bool BInitWorkshopForGameServer( DepotId_t unWorkshopDepotID, string pszFolder )
		{
			using var str__pszFolder = new Utf8StringToNative( pszFolder );
			var returnValue = _SteamAPI_ISteamUGC_BInitWorkshopForGameServer( Self, unWorkshopDepotID, str__pszFolder.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SuspendDownloads
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SuspendDownloads", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamUGC_SuspendDownloads( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bSuspend );
		internal void _SuspendDownloads( [ MarshalAs( UnmanagedType.U1 ) ] bool bSuspend ) => _SteamAPI_ISteamUGC_SuspendDownloads( Self, bSuspend );
		#endregion
		internal void SuspendDownloads( [ MarshalAs( UnmanagedType.U1 ) ] bool bSuspend )
		{
			_SteamAPI_ISteamUGC_SuspendDownloads( Self, bSuspend );
		}
		
		#region SteamAPI_ISteamUGC_StartPlaytimeTracking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StartPlaytimeTracking", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_StartPlaytimeTracking( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs );
		internal SteamAPICall_t _StartPlaytimeTracking( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs ) => _SteamAPI_ISteamUGC_StartPlaytimeTracking( Self, pvecPublishedFileID, unNumPublishedFileIDs );
		#endregion
		internal CallResult<StartPlaytimeTrackingResult_t> StartPlaytimeTracking( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_StartPlaytimeTracking( Self, pvecPublishedFileID, unNumPublishedFileIDs );
			return new CallResult<StartPlaytimeTrackingResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_StopPlaytimeTracking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTracking", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_StopPlaytimeTracking( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs );
		internal SteamAPICall_t _StopPlaytimeTracking( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs ) => _SteamAPI_ISteamUGC_StopPlaytimeTracking( Self, pvecPublishedFileID, unNumPublishedFileIDs );
		#endregion
		internal CallResult<StopPlaytimeTrackingResult_t> StopPlaytimeTracking( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_StopPlaytimeTracking( Self, pvecPublishedFileID, unNumPublishedFileIDs );
			return new CallResult<StopPlaytimeTrackingResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems( IntPtr self );
		internal SteamAPICall_t _StopPlaytimeTrackingForAllItems(  ) => _SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems( Self );
		#endregion
		internal CallResult<StopPlaytimeTrackingResult_t> StopPlaytimeTrackingForAllItems()
		{
			var returnValue = _SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems( Self );
			return new CallResult<StopPlaytimeTrackingResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_AddDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddDependency", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_AddDependency( IntPtr self, PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID );
		internal SteamAPICall_t _AddDependency( PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID ) => _SteamAPI_ISteamUGC_AddDependency( Self, nParentPublishedFileID, nChildPublishedFileID );
		#endregion
		internal CallResult<AddUGCDependencyResult_t> AddDependency( PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddDependency( Self, nParentPublishedFileID, nChildPublishedFileID );
			return new CallResult<AddUGCDependencyResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_RemoveDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveDependency", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_RemoveDependency( IntPtr self, PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID );
		internal SteamAPICall_t _RemoveDependency( PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID ) => _SteamAPI_ISteamUGC_RemoveDependency( Self, nParentPublishedFileID, nChildPublishedFileID );
		#endregion
		internal CallResult<RemoveUGCDependencyResult_t> RemoveDependency( PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveDependency( Self, nParentPublishedFileID, nChildPublishedFileID );
			return new CallResult<RemoveUGCDependencyResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_AddAppDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddAppDependency", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_AddAppDependency( IntPtr self, PublishedFileId_t nPublishedFileID, AppId_t nAppID );
		internal SteamAPICall_t _AddAppDependency( PublishedFileId_t nPublishedFileID, AppId_t nAppID ) => _SteamAPI_ISteamUGC_AddAppDependency( Self, nPublishedFileID, nAppID );
		#endregion
		internal CallResult<AddAppDependencyResult_t> AddAppDependency( PublishedFileId_t nPublishedFileID, AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddAppDependency( Self, nPublishedFileID, nAppID );
			return new CallResult<AddAppDependencyResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_RemoveAppDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveAppDependency", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_RemoveAppDependency( IntPtr self, PublishedFileId_t nPublishedFileID, AppId_t nAppID );
		internal SteamAPICall_t _RemoveAppDependency( PublishedFileId_t nPublishedFileID, AppId_t nAppID ) => _SteamAPI_ISteamUGC_RemoveAppDependency( Self, nPublishedFileID, nAppID );
		#endregion
		internal CallResult<RemoveAppDependencyResult_t> RemoveAppDependency( PublishedFileId_t nPublishedFileID, AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveAppDependency( Self, nPublishedFileID, nAppID );
			return new CallResult<RemoveAppDependencyResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_GetAppDependencies
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetAppDependencies", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_GetAppDependencies( IntPtr self, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _GetAppDependencies( PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_GetAppDependencies( Self, nPublishedFileID );
		#endregion
		internal CallResult<GetAppDependenciesResult_t> GetAppDependencies( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetAppDependencies( Self, nPublishedFileID );
			return new CallResult<GetAppDependenciesResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_DeleteItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_DeleteItem", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_DeleteItem( IntPtr self, PublishedFileId_t nPublishedFileID );
		internal SteamAPICall_t _DeleteItem( PublishedFileId_t nPublishedFileID ) => _SteamAPI_ISteamUGC_DeleteItem( Self, nPublishedFileID );
		#endregion
		internal CallResult<DeleteItemResult_t> DeleteItem( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_DeleteItem( Self, nPublishedFileID );
			return new CallResult<DeleteItemResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_ShowWorkshopEULA
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_ShowWorkshopEULA", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_ShowWorkshopEULA( IntPtr self );
		internal bool _ShowWorkshopEULA(  ) => _SteamAPI_ISteamUGC_ShowWorkshopEULA( Self );
		#endregion
		internal bool ShowWorkshopEULA()
		{
			var returnValue = _SteamAPI_ISteamUGC_ShowWorkshopEULA( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetWorkshopEULAStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetWorkshopEULAStatus", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUGC_GetWorkshopEULAStatus( IntPtr self );
		internal SteamAPICall_t _GetWorkshopEULAStatus(  ) => _SteamAPI_ISteamUGC_GetWorkshopEULAStatus( Self );
		#endregion
		internal CallResult<WorkshopEULAStatus_t> GetWorkshopEULAStatus()
		{
			var returnValue = _SteamAPI_ISteamUGC_GetWorkshopEULAStatus( Self );
			return new CallResult<WorkshopEULAStatus_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences( IntPtr self, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries );
		internal uint _GetUserContentDescriptorPreferences( EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries ) => _SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences( Self, pvecDescriptors, cMaxEntries );
		#endregion
		internal uint GetUserContentDescriptorPreferences( EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences( Self, pvecDescriptors, cMaxEntries );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemsDisabledLocally
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemsDisabledLocally", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetItemsDisabledLocally( IntPtr self, PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs, [ MarshalAs( UnmanagedType.U1 ) ] bool bDisabledLocally );
		internal bool _SetItemsDisabledLocally( PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs, [ MarshalAs( UnmanagedType.U1 ) ] bool bDisabledLocally ) => _SteamAPI_ISteamUGC_SetItemsDisabledLocally( Self, pvecPublishedFileIDs, unNumPublishedFileIDs, bDisabledLocally );
		#endregion
		internal bool SetItemsDisabledLocally( PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs, [ MarshalAs( UnmanagedType.U1 ) ] bool bDisabledLocally )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetItemsDisabledLocally( Self, pvecPublishedFileIDs, unNumPublishedFileIDs, bDisabledLocally );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder( IntPtr self, PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs );
		internal bool _SetSubscriptionsLoadOrder( PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs ) => _SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder( Self, pvecPublishedFileIDs, unNumPublishedFileIDs );
		#endregion
		internal bool SetSubscriptionsLoadOrder( PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder( Self, pvecPublishedFileIDs, unNumPublishedFileIDs );
			return returnValue;
		}
		
	}
}
