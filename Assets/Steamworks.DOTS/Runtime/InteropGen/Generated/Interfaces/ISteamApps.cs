using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamApps
	{
		public const string Version = "STEAMAPPS_INTERFACE_VERSION008";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamApps_v008", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamApps_v008();
		/// Construct use accessor to find interface
		public ISteamApps( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamApps_v008();
			}
		}
		public ISteamApps( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamApps_BIsSubscribed
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribed", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsSubscribed( IntPtr self );
		#endregion
		internal bool BIsSubscribed()
		{
			var returnValue = _SteamAPI_ISteamApps_BIsSubscribed( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsLowViolence
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsLowViolence", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsLowViolence( IntPtr self );
		#endregion
		internal bool BIsLowViolence()
		{
			var returnValue = _SteamAPI_ISteamApps_BIsLowViolence( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsCybercafe
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsCybercafe", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsCybercafe( IntPtr self );
		#endregion
		internal bool BIsCybercafe()
		{
			var returnValue = _SteamAPI_ISteamApps_BIsCybercafe( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsVACBanned
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsVACBanned", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsVACBanned( IntPtr self );
		#endregion
		internal bool BIsVACBanned()
		{
			var returnValue = _SteamAPI_ISteamApps_BIsVACBanned( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetCurrentGameLanguage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetCurrentGameLanguage", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamApps_GetCurrentGameLanguage( IntPtr self );
		#endregion
		internal string GetCurrentGameLanguage()
		{
			var returnValue = _SteamAPI_ISteamApps_GetCurrentGameLanguage( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetAvailableGameLanguages
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAvailableGameLanguages", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamApps_GetAvailableGameLanguages( IntPtr self );
		#endregion
		internal string GetAvailableGameLanguages()
		{
			var returnValue = _SteamAPI_ISteamApps_GetAvailableGameLanguages( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsSubscribedApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedApp", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsSubscribedApp( IntPtr self, AppId_t appID );
		#endregion
		internal bool BIsSubscribedApp( AppId_t appID )
		{
			var returnValue = _SteamAPI_ISteamApps_BIsSubscribedApp( Self, appID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsDlcInstalled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsDlcInstalled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsDlcInstalled( IntPtr self, AppId_t appID );
		#endregion
		internal bool BIsDlcInstalled( AppId_t appID )
		{
			var returnValue = _SteamAPI_ISteamApps_BIsDlcInstalled( Self, appID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime( IntPtr self, AppId_t nAppID );
		#endregion
		internal uint GetEarliestPurchaseUnixTime( AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime( Self, nAppID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend( IntPtr self );
		#endregion
		internal bool BIsSubscribedFromFreeWeekend()
		{
			var returnValue = _SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetDLCCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetDLCCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamApps_GetDLCCount( IntPtr self );
		#endregion
		internal int GetDLCCount()
		{
			var returnValue = _SteamAPI_ISteamApps_GetDLCCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BGetDLCDataByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BGetDLCDataByIndex", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BGetDLCDataByIndex( IntPtr self, int iDLC, ref AppId_t pAppID, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAvailable, IntPtr pchName, int cchNameBufferSize );
		#endregion
		internal bool BGetDLCDataByIndex( int iDLC, ref AppId_t pAppID, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAvailable, out string pchName, int cchNameBufferSize )
		{
			using var mem__pchName = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamApps_BGetDLCDataByIndex( Self, iDLC, ref pAppID, ref pbAvailable, mem__pchName.Ptr, cchNameBufferSize );
			pchName = Utility.MemoryToString( mem__pchName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_InstallDLC
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_InstallDLC", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamApps_InstallDLC( IntPtr self, AppId_t nAppID );
		#endregion
		internal void InstallDLC( AppId_t nAppID )
		{
			_SteamAPI_ISteamApps_InstallDLC( Self, nAppID );
		}
		
		#region SteamAPI_ISteamApps_UninstallDLC
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_UninstallDLC", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamApps_UninstallDLC( IntPtr self, AppId_t nAppID );
		#endregion
		internal void UninstallDLC( AppId_t nAppID )
		{
			_SteamAPI_ISteamApps_UninstallDLC( Self, nAppID );
		}
		
		#region SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey( IntPtr self, AppId_t nAppID );
		#endregion
		internal void RequestAppProofOfPurchaseKey( AppId_t nAppID )
		{
			_SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey( Self, nAppID );
		}
		
		#region SteamAPI_ISteamApps_GetCurrentBetaName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetCurrentBetaName", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_GetCurrentBetaName( IntPtr self, IntPtr pchName, int cchNameBufferSize );
		#endregion
		internal bool GetCurrentBetaName( out string pchName, int cchNameBufferSize )
		{
			using var mem__pchName = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamApps_GetCurrentBetaName( Self, mem__pchName.Ptr, cchNameBufferSize );
			pchName = Utility.MemoryToString( mem__pchName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_MarkContentCorrupt
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_MarkContentCorrupt", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_MarkContentCorrupt( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bMissingFilesOnly );
		#endregion
		internal bool MarkContentCorrupt( [ MarshalAs( UnmanagedType.U1 ) ] bool bMissingFilesOnly )
		{
			var returnValue = _SteamAPI_ISteamApps_MarkContentCorrupt( Self, bMissingFilesOnly );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetInstalledDepots
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetInstalledDepots", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamApps_GetInstalledDepots( IntPtr self, AppId_t appID, DepotId_t* pvecDepots, uint cMaxDepots );
		#endregion
		internal uint GetInstalledDepots( AppId_t appID, DepotId_t* pvecDepots, uint cMaxDepots )
		{
			var returnValue = _SteamAPI_ISteamApps_GetInstalledDepots( Self, appID, pvecDepots, cMaxDepots );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetAppInstallDir
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAppInstallDir", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamApps_GetAppInstallDir( IntPtr self, AppId_t appID, IntPtr pchFolder, uint cchFolderBufferSize );
		#endregion
		internal uint GetAppInstallDir( AppId_t appID, out string pchFolder, uint cchFolderBufferSize )
		{
			using var mem__pchFolder = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamApps_GetAppInstallDir( Self, appID, mem__pchFolder.Ptr, cchFolderBufferSize );
			pchFolder = Utility.MemoryToString( mem__pchFolder );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsAppInstalled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsAppInstalled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsAppInstalled( IntPtr self, AppId_t appID );
		#endregion
		internal bool BIsAppInstalled( AppId_t appID )
		{
			var returnValue = _SteamAPI_ISteamApps_BIsAppInstalled( Self, appID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetAppOwner
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAppOwner", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamApps_GetAppOwner( IntPtr self );
		#endregion
		internal SteamId GetAppOwner()
		{
			var returnValue = _SteamAPI_ISteamApps_GetAppOwner( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetLaunchQueryParam
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetLaunchQueryParam", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamApps_GetLaunchQueryParam( IntPtr self, IntPtr pchKey );
		#endregion
		internal string GetLaunchQueryParam( string pchKey )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamApps_GetLaunchQueryParam( Self, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetDlcDownloadProgress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetDlcDownloadProgress", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_GetDlcDownloadProgress( IntPtr self, AppId_t nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal );
		#endregion
		internal bool GetDlcDownloadProgress( AppId_t nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal )
		{
			var returnValue = _SteamAPI_ISteamApps_GetDlcDownloadProgress( Self, nAppID, ref punBytesDownloaded, ref punBytesTotal );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetAppBuildId
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAppBuildId", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamApps_GetAppBuildId( IntPtr self );
		#endregion
		internal int GetAppBuildId()
		{
			var returnValue = _SteamAPI_ISteamApps_GetAppBuildId( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys( IntPtr self );
		#endregion
		internal void RequestAllProofOfPurchaseKeys()
		{
			_SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys( Self );
		}
		
		#region SteamAPI_ISteamApps_GetFileDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetFileDetails", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamApps_GetFileDetails( IntPtr self, IntPtr pszFileName );
		#endregion
		internal CallResult<FileDetailsResult_t> GetFileDetails( string pszFileName )
		{
			using var str__pszFileName = new Utf8StringToNative( pszFileName );
			var returnValue = _SteamAPI_ISteamApps_GetFileDetails( Self, str__pszFileName.Pointer );
			return new CallResult<FileDetailsResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamApps_GetLaunchCommandLine
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetLaunchCommandLine", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamApps_GetLaunchCommandLine( IntPtr self, IntPtr pszCommandLine, int cubCommandLine );
		#endregion
		internal int GetLaunchCommandLine( out string pszCommandLine, int cubCommandLine )
		{
			using var mem__pszCommandLine = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamApps_GetLaunchCommandLine( Self, mem__pszCommandLine.Ptr, cubCommandLine );
			pszCommandLine = Utility.MemoryToString( mem__pszCommandLine );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsSubscribedFromFamilySharing
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFamilySharing", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsSubscribedFromFamilySharing( IntPtr self );
		#endregion
		internal bool BIsSubscribedFromFamilySharing()
		{
			var returnValue = _SteamAPI_ISteamApps_BIsSubscribedFromFamilySharing( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_BIsTimedTrial
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsTimedTrial", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_BIsTimedTrial( IntPtr self, ref uint punSecondsAllowed, ref uint punSecondsPlayed );
		#endregion
		internal bool BIsTimedTrial( ref uint punSecondsAllowed, ref uint punSecondsPlayed )
		{
			var returnValue = _SteamAPI_ISteamApps_BIsTimedTrial( Self, ref punSecondsAllowed, ref punSecondsPlayed );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_SetDlcContext
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_SetDlcContext", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_SetDlcContext( IntPtr self, AppId_t nAppID );
		#endregion
		internal bool SetDlcContext( AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamApps_SetDlcContext( Self, nAppID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetNumBetas
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetNumBetas", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamApps_GetNumBetas( IntPtr self, ref int pnAvailable, ref int pnPrivate );
		#endregion
		internal int GetNumBetas( ref int pnAvailable, ref int pnPrivate )
		{
			var returnValue = _SteamAPI_ISteamApps_GetNumBetas( Self, ref pnAvailable, ref pnPrivate );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_GetBetaInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetBetaInfo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_GetBetaInfo( IntPtr self, int iBetaIndex, ref uint punFlags, ref uint punBuildID, IntPtr pchBetaName, int cchBetaName, IntPtr pchDescription, int cchDescription );
		#endregion
		internal bool GetBetaInfo( int iBetaIndex, ref uint punFlags, ref uint punBuildID, out string pchBetaName, int cchBetaName, out string pchDescription, int cchDescription )
		{
			using var mem__pchBetaName = new Utility.Memory( Utility.MemoryBufferSize );
			using var mem__pchDescription = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamApps_GetBetaInfo( Self, iBetaIndex, ref punFlags, ref punBuildID, mem__pchBetaName.Ptr, cchBetaName, mem__pchDescription.Ptr, cchDescription );
			pchBetaName = Utility.MemoryToString( mem__pchBetaName );
			pchDescription = Utility.MemoryToString( mem__pchDescription );
			return returnValue;
		}
		
		#region SteamAPI_ISteamApps_SetActiveBeta
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_SetActiveBeta", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamApps_SetActiveBeta( IntPtr self, IntPtr pchBetaName );
		#endregion
		internal bool SetActiveBeta( string pchBetaName )
		{
			using var str__pchBetaName = new Utf8StringToNative( pchBetaName );
			var returnValue = _SteamAPI_ISteamApps_SetActiveBeta( Self, str__pchBetaName.Pointer );
			return returnValue;
		}
		
	}
}
