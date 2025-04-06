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
		private static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryUserUGCRequest( IntPtr self, AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage );
		#endregion
		internal UGCQueryHandle_t CreateQueryUserUGCRequest( AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryUserUGCRequest( Self, unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage", CallingConvention = Platform.CC ) ]
		private static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage( IntPtr self, EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage );
		#endregion
		internal UGCQueryHandle_t CreateQueryAllUGCRequest( EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestPage( Self, eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor", CallingConvention = Platform.CC ) ]
		private static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor( IntPtr self, EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, IntPtr pchCursor );
		#endregion
		internal UGCQueryHandle_t CreateQueryAllUGCRequest( EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, string pchCursor )
		{
			using var str__pchCursor = new Utf8StringToNative( pchCursor );
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryAllUGCRequestCursor( Self, eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, str__pchCursor.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest", CallingConvention = Platform.CC ) ]
		private static extern UGCQueryHandle_t _SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs );
		#endregion
		internal UGCQueryHandle_t CreateQueryUGCDetailsRequest( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest( Self, pvecPublishedFileID, unNumPublishedFileIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SendQueryUGCRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SendQueryUGCRequest", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_SendQueryUGCRequest( IntPtr self, UGCQueryHandle_t handle );
		#endregion
		internal SteamAPICall_t SendQueryUGCRequest( UGCQueryHandle_t handle )
		{
			var returnValue = _SteamAPI_ISteamUGC_SendQueryUGCRequest( Self, handle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCResult", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCResult( IntPtr self, UGCQueryHandle_t handle, uint index, ref SteamUGCDetails_t pDetails );
		#endregion
		internal bool GetQueryUGCResult( UGCQueryHandle_t handle, uint index, ref SteamUGCDetails_t pDetails )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCResult( Self, handle, index, ref pDetails );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCNumTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumTags", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamUGC_GetQueryUGCNumTags( IntPtr self, UGCQueryHandle_t handle, uint index );
		#endregion
		internal uint GetQueryUGCNumTags( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCNumTags( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCTag( IntPtr self, UGCQueryHandle_t handle, uint index, uint indexTag, IntPtr pchValue, uint cchValueSize );
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
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCTagDisplayName( IntPtr self, UGCQueryHandle_t handle, uint index, uint indexTag, IntPtr pchValue, uint cchValueSize );
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
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCPreviewURL( IntPtr self, UGCQueryHandle_t handle, uint index, IntPtr pchURL, uint cchURLSize );
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
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCMetadata( IntPtr self, UGCQueryHandle_t handle, uint index, IntPtr pchMetadata, uint cchMetadatasize );
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
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCChildren( IntPtr self, UGCQueryHandle_t handle, uint index, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries );
		#endregion
		internal bool GetQueryUGCChildren( UGCQueryHandle_t handle, uint index, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCChildren( Self, handle, index, pvecPublishedFileID, cMaxEntries );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCStatistic
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCStatistic", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCStatistic( IntPtr self, UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, ref ulong pStatValue );
		#endregion
		internal bool GetQueryUGCStatistic( UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, ref ulong pStatValue )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCStatistic( Self, handle, index, eStatType, ref pStatValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews( IntPtr self, UGCQueryHandle_t handle, uint index );
		#endregion
		internal uint GetQueryUGCNumAdditionalPreviews( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview( IntPtr self, UGCQueryHandle_t handle, uint index, uint previewIndex, IntPtr pchURLOrVideoID, uint cchURLSize, IntPtr pchOriginalFileName, uint cchOriginalFileNameSize, ref EItemPreviewType pPreviewType );
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
		private static extern uint _SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags( IntPtr self, UGCQueryHandle_t handle, uint index );
		#endregion
		internal uint GetQueryUGCNumKeyValueTags( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag( IntPtr self, UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, IntPtr pchKey, uint cchKeySize, IntPtr pchValue, uint cchValueSize );
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
		private static extern bool _SteamAPI_ISteamUGC_GetQueryFirstUGCKeyValueTag( IntPtr self, UGCQueryHandle_t handle, uint index, IntPtr pchKey, IntPtr pchValue, uint cchValueSize );
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
		private static extern uint _SteamAPI_ISteamUGC_GetNumSupportedGameVersions( IntPtr self, UGCQueryHandle_t handle, uint index );
		#endregion
		internal uint GetNumSupportedGameVersions( UGCQueryHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetNumSupportedGameVersions( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetSupportedGameVersionData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetSupportedGameVersionData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetSupportedGameVersionData( IntPtr self, UGCQueryHandle_t handle, uint index, uint versionIndex, IntPtr pchGameBranchMin, IntPtr pchGameBranchMax, uint cchGameBranchSize );
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
		private static extern uint _SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors( IntPtr self, UGCQueryHandle_t handle, uint index, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries );
		#endregion
		internal uint GetQueryUGCContentDescriptors( UGCQueryHandle_t handle, uint index, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetQueryUGCContentDescriptors( Self, handle, index, pvecDescriptors, cMaxEntries );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_ReleaseQueryUGCRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_ReleaseQueryUGCRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_ReleaseQueryUGCRequest( IntPtr self, UGCQueryHandle_t handle );
		#endregion
		internal bool ReleaseQueryUGCRequest( UGCQueryHandle_t handle )
		{
			var returnValue = _SteamAPI_ISteamUGC_ReleaseQueryUGCRequest( Self, handle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddRequiredTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_AddRequiredTag( IntPtr self, UGCQueryHandle_t handle, IntPtr pTagName );
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
		private static extern bool _SteamAPI_ISteamUGC_AddRequiredTagGroup( IntPtr self, UGCQueryHandle_t handle, ref SteamParamStringArray_t pTagGroups );
		#endregion
		internal bool AddRequiredTagGroup( UGCQueryHandle_t handle, ref SteamParamStringArray_t pTagGroups )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddRequiredTagGroup( Self, handle, ref pTagGroups );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddExcludedTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddExcludedTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_AddExcludedTag( IntPtr self, UGCQueryHandle_t handle, IntPtr pTagName );
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
		private static extern bool _SteamAPI_ISteamUGC_SetReturnOnlyIDs( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnOnlyIDs );
		#endregion
		internal bool SetReturnOnlyIDs( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnOnlyIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnOnlyIDs( Self, handle, bReturnOnlyIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnKeyValueTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnKeyValueTags( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnKeyValueTags );
		#endregion
		internal bool SetReturnKeyValueTags( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnKeyValueTags )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnKeyValueTags( Self, handle, bReturnKeyValueTags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnLongDescription
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnLongDescription", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnLongDescription( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnLongDescription );
		#endregion
		internal bool SetReturnLongDescription( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnLongDescription )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnLongDescription( Self, handle, bReturnLongDescription );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnMetadata
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnMetadata", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnMetadata( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnMetadata );
		#endregion
		internal bool SetReturnMetadata( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnMetadata )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnMetadata( Self, handle, bReturnMetadata );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnChildren
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnChildren", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnChildren( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnChildren );
		#endregion
		internal bool SetReturnChildren( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnChildren )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnChildren( Self, handle, bReturnChildren );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnAdditionalPreviews
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnAdditionalPreviews", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnAdditionalPreviews( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnAdditionalPreviews );
		#endregion
		internal bool SetReturnAdditionalPreviews( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnAdditionalPreviews )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnAdditionalPreviews( Self, handle, bReturnAdditionalPreviews );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnTotalOnly
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnTotalOnly", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnTotalOnly( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnTotalOnly );
		#endregion
		internal bool SetReturnTotalOnly( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bReturnTotalOnly )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnTotalOnly( Self, handle, bReturnTotalOnly );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetReturnPlaytimeStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetReturnPlaytimeStats", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetReturnPlaytimeStats( IntPtr self, UGCQueryHandle_t handle, uint unDays );
		#endregion
		internal bool SetReturnPlaytimeStats( UGCQueryHandle_t handle, uint unDays )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetReturnPlaytimeStats( Self, handle, unDays );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetLanguage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetLanguage", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetLanguage( IntPtr self, UGCQueryHandle_t handle, IntPtr pchLanguage );
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
		private static extern bool _SteamAPI_ISteamUGC_SetAllowCachedResponse( IntPtr self, UGCQueryHandle_t handle, uint unMaxAgeSeconds );
		#endregion
		internal bool SetAllowCachedResponse( UGCQueryHandle_t handle, uint unMaxAgeSeconds )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetAllowCachedResponse( Self, handle, unMaxAgeSeconds );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetAdminQuery
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetAdminQuery", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetAdminQuery( IntPtr self, UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAdminQuery );
		#endregion
		internal bool SetAdminQuery( UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAdminQuery )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetAdminQuery( Self, handle, bAdminQuery );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetCloudFileNameFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetCloudFileNameFilter", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetCloudFileNameFilter( IntPtr self, UGCQueryHandle_t handle, IntPtr pMatchCloudFileName );
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
		private static extern bool _SteamAPI_ISteamUGC_SetMatchAnyTag( IntPtr self, UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bMatchAnyTag );
		#endregion
		internal bool SetMatchAnyTag( UGCQueryHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bMatchAnyTag )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetMatchAnyTag( Self, handle, bMatchAnyTag );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetSearchText
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetSearchText", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetSearchText( IntPtr self, UGCQueryHandle_t handle, IntPtr pSearchText );
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
		private static extern bool _SteamAPI_ISteamUGC_SetRankedByTrendDays( IntPtr self, UGCQueryHandle_t handle, uint unDays );
		#endregion
		internal bool SetRankedByTrendDays( UGCQueryHandle_t handle, uint unDays )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetRankedByTrendDays( Self, handle, unDays );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetTimeCreatedDateRange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetTimeCreatedDateRange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetTimeCreatedDateRange( IntPtr self, UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd );
		#endregion
		internal bool SetTimeCreatedDateRange( UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetTimeCreatedDateRange( Self, handle, rtStart, rtEnd );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetTimeUpdatedDateRange
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetTimeUpdatedDateRange", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetTimeUpdatedDateRange( IntPtr self, UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd );
		#endregion
		internal bool SetTimeUpdatedDateRange( UGCQueryHandle_t handle, RTime32 rtStart, RTime32 rtEnd )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetTimeUpdatedDateRange( Self, handle, rtStart, rtEnd );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddRequiredKeyValueTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredKeyValueTag", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_AddRequiredKeyValueTag( IntPtr self, UGCQueryHandle_t handle, IntPtr pKey, IntPtr pValue );
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
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_CreateItem( IntPtr self, AppId_t nConsumerAppId, EWorkshopFileType eFileType );
		#endregion
		internal SteamAPICall_t CreateItem( AppId_t nConsumerAppId, EWorkshopFileType eFileType )
		{
			var returnValue = _SteamAPI_ISteamUGC_CreateItem( Self, nConsumerAppId, eFileType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_StartItemUpdate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StartItemUpdate", CallingConvention = Platform.CC ) ]
		private static extern UGCUpdateHandle_t _SteamAPI_ISteamUGC_StartItemUpdate( IntPtr self, AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID );
		#endregion
		internal UGCUpdateHandle_t StartItemUpdate( AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_StartItemUpdate( Self, nConsumerAppId, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemTitle
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemTitle", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetItemTitle( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchTitle );
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
		private static extern bool _SteamAPI_ISteamUGC_SetItemDescription( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchDescription );
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
		private static extern bool _SteamAPI_ISteamUGC_SetItemUpdateLanguage( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchLanguage );
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
		private static extern bool _SteamAPI_ISteamUGC_SetItemMetadata( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchMetaData );
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
		private static extern bool _SteamAPI_ISteamUGC_SetItemVisibility( IntPtr self, UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility );
		#endregion
		internal bool SetItemVisibility( UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetItemVisibility( Self, handle, eVisibility );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetItemTags( IntPtr self, UGCUpdateHandle_t updateHandle, ref SteamParamStringArray_t pTags, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowAdminTags );
		#endregion
		internal bool SetItemTags( UGCUpdateHandle_t updateHandle, ref SteamParamStringArray_t pTags, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowAdminTags )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetItemTags( Self, updateHandle, ref pTags, bAllowAdminTags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemContent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemContent", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetItemContent( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszContentFolder );
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
		private static extern bool _SteamAPI_ISteamUGC_SetItemPreview( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszPreviewFile );
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
		private static extern bool _SteamAPI_ISteamUGC_SetAllowLegacyUpload( IntPtr self, UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowLegacyUpload );
		#endregion
		internal bool SetAllowLegacyUpload( UGCUpdateHandle_t handle, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowLegacyUpload )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetAllowLegacyUpload( Self, handle, bAllowLegacyUpload );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags( IntPtr self, UGCUpdateHandle_t handle );
		#endregion
		internal bool RemoveAllItemKeyValueTags( UGCUpdateHandle_t handle )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveAllItemKeyValueTags( Self, handle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveItemKeyValueTags
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemKeyValueTags", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_RemoveItemKeyValueTags( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchKey );
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
		private static extern bool _SteamAPI_ISteamUGC_AddItemKeyValueTag( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchKey, IntPtr pchValue );
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
		private static extern bool _SteamAPI_ISteamUGC_AddItemPreviewFile( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszPreviewFile, EItemPreviewType type );
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
		private static extern bool _SteamAPI_ISteamUGC_AddItemPreviewVideo( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszVideoID );
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
		private static extern bool _SteamAPI_ISteamUGC_UpdateItemPreviewFile( IntPtr self, UGCUpdateHandle_t handle, uint index, IntPtr pszPreviewFile );
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
		private static extern bool _SteamAPI_ISteamUGC_UpdateItemPreviewVideo( IntPtr self, UGCUpdateHandle_t handle, uint index, IntPtr pszVideoID );
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
		private static extern bool _SteamAPI_ISteamUGC_RemoveItemPreview( IntPtr self, UGCUpdateHandle_t handle, uint index );
		#endregion
		internal bool RemoveItemPreview( UGCUpdateHandle_t handle, uint index )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveItemPreview( Self, handle, index );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddContentDescriptor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddContentDescriptor", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_AddContentDescriptor( IntPtr self, UGCUpdateHandle_t handle, EUGCContentDescriptorID descid );
		#endregion
		internal bool AddContentDescriptor( UGCUpdateHandle_t handle, EUGCContentDescriptorID descid )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddContentDescriptor( Self, handle, descid );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveContentDescriptor
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveContentDescriptor", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_RemoveContentDescriptor( IntPtr self, UGCUpdateHandle_t handle, EUGCContentDescriptorID descid );
		#endregion
		internal bool RemoveContentDescriptor( UGCUpdateHandle_t handle, EUGCContentDescriptorID descid )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveContentDescriptor( Self, handle, descid );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetRequiredGameVersions
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetRequiredGameVersions", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetRequiredGameVersions( IntPtr self, UGCUpdateHandle_t handle, IntPtr pszGameBranchMin, IntPtr pszGameBranchMax );
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
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_SubmitItemUpdate( IntPtr self, UGCUpdateHandle_t handle, IntPtr pchChangeNote );
		#endregion
		internal SteamAPICall_t SubmitItemUpdate( UGCUpdateHandle_t handle, string pchChangeNote )
		{
			using var str__pchChangeNote = new Utf8StringToNative( pchChangeNote );
			var returnValue = _SteamAPI_ISteamUGC_SubmitItemUpdate( Self, handle, str__pchChangeNote.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetItemUpdateProgress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemUpdateProgress", CallingConvention = Platform.CC ) ]
		private static extern EItemUpdateStatus _SteamAPI_ISteamUGC_GetItemUpdateProgress( IntPtr self, UGCUpdateHandle_t handle, ref ulong punBytesProcessed, ref ulong punBytesTotal );
		#endregion
		internal EItemUpdateStatus GetItemUpdateProgress( UGCUpdateHandle_t handle, ref ulong punBytesProcessed, ref ulong punBytesTotal )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetItemUpdateProgress( Self, handle, ref punBytesProcessed, ref punBytesTotal );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetUserItemVote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetUserItemVote", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_SetUserItemVote( IntPtr self, PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVoteUp );
		#endregion
		internal SteamAPICall_t SetUserItemVote( PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bVoteUp )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetUserItemVote( Self, nPublishedFileID, bVoteUp );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetUserItemVote
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetUserItemVote", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_GetUserItemVote( IntPtr self, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t GetUserItemVote( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetUserItemVote( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddItemToFavorites
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddItemToFavorites", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_AddItemToFavorites( IntPtr self, AppId_t nAppId, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t AddItemToFavorites( AppId_t nAppId, PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddItemToFavorites( Self, nAppId, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveItemFromFavorites
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemFromFavorites", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_RemoveItemFromFavorites( IntPtr self, AppId_t nAppId, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t RemoveItemFromFavorites( AppId_t nAppId, PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveItemFromFavorites( Self, nAppId, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SubscribeItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SubscribeItem", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_SubscribeItem( IntPtr self, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t SubscribeItem( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_SubscribeItem( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_UnsubscribeItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_UnsubscribeItem", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_UnsubscribeItem( IntPtr self, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t UnsubscribeItem( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_UnsubscribeItem( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetNumSubscribedItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetNumSubscribedItems", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamUGC_GetNumSubscribedItems( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled );
		#endregion
		internal uint GetNumSubscribedItems( [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetNumSubscribedItems( Self, bIncludeLocallyDisabled );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetSubscribedItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetSubscribedItems", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamUGC_GetSubscribedItems( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled );
		#endregion
		internal uint GetSubscribedItems( PublishedFileId_t* pvecPublishedFileID, uint cMaxEntries, [ MarshalAs( UnmanagedType.U1 ) ] bool bIncludeLocallyDisabled )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetSubscribedItems( Self, pvecPublishedFileID, cMaxEntries, bIncludeLocallyDisabled );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetItemState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemState", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamUGC_GetItemState( IntPtr self, PublishedFileId_t nPublishedFileID );
		#endregion
		internal uint GetItemState( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetItemState( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetItemInstallInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetItemInstallInfo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_GetItemInstallInfo( IntPtr self, PublishedFileId_t nPublishedFileID, ref ulong punSizeOnDisk, IntPtr pchFolder, uint cchFolderSize, ref uint punTimeStamp );
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
		private static extern bool _SteamAPI_ISteamUGC_GetItemDownloadInfo( IntPtr self, PublishedFileId_t nPublishedFileID, ref ulong punBytesDownloaded, ref ulong punBytesTotal );
		#endregion
		internal bool GetItemDownloadInfo( PublishedFileId_t nPublishedFileID, ref ulong punBytesDownloaded, ref ulong punBytesTotal )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetItemDownloadInfo( Self, nPublishedFileID, ref punBytesDownloaded, ref punBytesTotal );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_DownloadItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_DownloadItem", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_DownloadItem( IntPtr self, PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bHighPriority );
		#endregion
		internal bool DownloadItem( PublishedFileId_t nPublishedFileID, [ MarshalAs( UnmanagedType.U1 ) ] bool bHighPriority )
		{
			var returnValue = _SteamAPI_ISteamUGC_DownloadItem( Self, nPublishedFileID, bHighPriority );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_BInitWorkshopForGameServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_BInitWorkshopForGameServer", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_BInitWorkshopForGameServer( IntPtr self, DepotId_t unWorkshopDepotID, IntPtr pszFolder );
		#endregion
		internal bool BInitWorkshopForGameServer( DepotId_t unWorkshopDepotID, string pszFolder )
		{
			using var str__pszFolder = new Utf8StringToNative( pszFolder );
			var returnValue = _SteamAPI_ISteamUGC_BInitWorkshopForGameServer( Self, unWorkshopDepotID, str__pszFolder.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SuspendDownloads
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SuspendDownloads", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamUGC_SuspendDownloads( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bSuspend );
		#endregion
		internal void SuspendDownloads( [ MarshalAs( UnmanagedType.U1 ) ] bool bSuspend )
		{
			_SteamAPI_ISteamUGC_SuspendDownloads( Self, bSuspend );
		}
		
		#region SteamAPI_ISteamUGC_StartPlaytimeTracking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StartPlaytimeTracking", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_StartPlaytimeTracking( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs );
		#endregion
		internal SteamAPICall_t StartPlaytimeTracking( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_StartPlaytimeTracking( Self, pvecPublishedFileID, unNumPublishedFileIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_StopPlaytimeTracking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTracking", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_StopPlaytimeTracking( IntPtr self, PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs );
		#endregion
		internal SteamAPICall_t StopPlaytimeTracking( PublishedFileId_t* pvecPublishedFileID, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_StopPlaytimeTracking( Self, pvecPublishedFileID, unNumPublishedFileIDs );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems( IntPtr self );
		#endregion
		internal SteamAPICall_t StopPlaytimeTrackingForAllItems()
		{
			var returnValue = _SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddDependency", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_AddDependency( IntPtr self, PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID );
		#endregion
		internal SteamAPICall_t AddDependency( PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddDependency( Self, nParentPublishedFileID, nChildPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveDependency", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_RemoveDependency( IntPtr self, PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID );
		#endregion
		internal SteamAPICall_t RemoveDependency( PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveDependency( Self, nParentPublishedFileID, nChildPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_AddAppDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_AddAppDependency", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_AddAppDependency( IntPtr self, PublishedFileId_t nPublishedFileID, AppId_t nAppID );
		#endregion
		internal SteamAPICall_t AddAppDependency( PublishedFileId_t nPublishedFileID, AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamUGC_AddAppDependency( Self, nPublishedFileID, nAppID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_RemoveAppDependency
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_RemoveAppDependency", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_RemoveAppDependency( IntPtr self, PublishedFileId_t nPublishedFileID, AppId_t nAppID );
		#endregion
		internal SteamAPICall_t RemoveAppDependency( PublishedFileId_t nPublishedFileID, AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamUGC_RemoveAppDependency( Self, nPublishedFileID, nAppID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetAppDependencies
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetAppDependencies", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_GetAppDependencies( IntPtr self, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t GetAppDependencies( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetAppDependencies( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_DeleteItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_DeleteItem", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_DeleteItem( IntPtr self, PublishedFileId_t nPublishedFileID );
		#endregion
		internal SteamAPICall_t DeleteItem( PublishedFileId_t nPublishedFileID )
		{
			var returnValue = _SteamAPI_ISteamUGC_DeleteItem( Self, nPublishedFileID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_ShowWorkshopEULA
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_ShowWorkshopEULA", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_ShowWorkshopEULA( IntPtr self );
		#endregion
		internal bool ShowWorkshopEULA()
		{
			var returnValue = _SteamAPI_ISteamUGC_ShowWorkshopEULA( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetWorkshopEULAStatus
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetWorkshopEULAStatus", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamUGC_GetWorkshopEULAStatus( IntPtr self );
		#endregion
		internal SteamAPICall_t GetWorkshopEULAStatus()
		{
			var returnValue = _SteamAPI_ISteamUGC_GetWorkshopEULAStatus( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences( IntPtr self, EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries );
		#endregion
		internal uint GetUserContentDescriptorPreferences( EUGCContentDescriptorID* pvecDescriptors, uint cMaxEntries )
		{
			var returnValue = _SteamAPI_ISteamUGC_GetUserContentDescriptorPreferences( Self, pvecDescriptors, cMaxEntries );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetItemsDisabledLocally
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetItemsDisabledLocally", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetItemsDisabledLocally( IntPtr self, PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs, [ MarshalAs( UnmanagedType.U1 ) ] bool bDisabledLocally );
		#endregion
		internal bool SetItemsDisabledLocally( PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs, [ MarshalAs( UnmanagedType.U1 ) ] bool bDisabledLocally )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetItemsDisabledLocally( Self, pvecPublishedFileIDs, unNumPublishedFileIDs, bDisabledLocally );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder( IntPtr self, PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs );
		#endregion
		internal bool SetSubscriptionsLoadOrder( PublishedFileId_t* pvecPublishedFileIDs, uint unNumPublishedFileIDs )
		{
			var returnValue = _SteamAPI_ISteamUGC_SetSubscriptionsLoadOrder( Self, pvecPublishedFileIDs, unNumPublishedFileIDs );
			return returnValue;
		}
		
	}
}
