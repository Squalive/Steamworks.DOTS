using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamUserStats
	{
		public const string Version = "STEAMUSERSTATS_INTERFACE_VERSION013";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamUserStats_v013", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamUserStats_v013();
		/// Construct use accessor to find interface
		public ISteamUserStats( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamUserStats_v013();
			}
		}
		public ISteamUserStats( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamUserStats_GetStatInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetStatInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetStatInt32( IntPtr self, IntPtr pchName, ref int pData );
		internal bool _GetStat( IntPtr pchName, ref int pData ) => _SteamAPI_ISteamUserStats_GetStatInt32( Self, pchName, ref pData );
		#endregion
		internal bool GetStat( string pchName, ref int pData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetStatInt32( Self, str__pchName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetStatFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetStatFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetStatFloat( IntPtr self, IntPtr pchName, ref float pData );
		internal bool _GetStat( IntPtr pchName, ref float pData ) => _SteamAPI_ISteamUserStats_GetStatFloat( Self, pchName, ref pData );
		#endregion
		internal bool GetStat( string pchName, ref float pData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetStatFloat( Self, str__pchName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_SetStatInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_SetStatInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_SetStatInt32( IntPtr self, IntPtr pchName, int nData );
		internal bool _SetStat( IntPtr pchName, int nData ) => _SteamAPI_ISteamUserStats_SetStatInt32( Self, pchName, nData );
		#endregion
		internal bool SetStat( string pchName, int nData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_SetStatInt32( Self, str__pchName.Pointer, nData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_SetStatFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_SetStatFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_SetStatFloat( IntPtr self, IntPtr pchName, float fData );
		internal bool _SetStat( IntPtr pchName, float fData ) => _SteamAPI_ISteamUserStats_SetStatFloat( Self, pchName, fData );
		#endregion
		internal bool SetStat( string pchName, float fData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_SetStatFloat( Self, str__pchName.Pointer, fData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_UpdateAvgRateStat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_UpdateAvgRateStat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_UpdateAvgRateStat( IntPtr self, IntPtr pchName, float flCountThisSession, double dSessionLength );
		internal bool _UpdateAvgRateStat( IntPtr pchName, float flCountThisSession, double dSessionLength ) => _SteamAPI_ISteamUserStats_UpdateAvgRateStat( Self, pchName, flCountThisSession, dSessionLength );
		#endregion
		internal bool UpdateAvgRateStat( string pchName, float flCountThisSession, double dSessionLength )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_UpdateAvgRateStat( Self, str__pchName.Pointer, flCountThisSession, dSessionLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetAchievement( IntPtr self, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved );
		internal bool _GetAchievement( IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved ) => _SteamAPI_ISteamUserStats_GetAchievement( Self, pchName, ref pbAchieved );
		#endregion
		internal bool GetAchievement( string pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievement( Self, str__pchName.Pointer, ref pbAchieved );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_SetAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_SetAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_SetAchievement( IntPtr self, IntPtr pchName );
		internal bool _SetAchievement( IntPtr pchName ) => _SteamAPI_ISteamUserStats_SetAchievement( Self, pchName );
		#endregion
		internal bool SetAchievement( string pchName )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_SetAchievement( Self, str__pchName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_ClearAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_ClearAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_ClearAchievement( IntPtr self, IntPtr pchName );
		internal bool _ClearAchievement( IntPtr pchName ) => _SteamAPI_ISteamUserStats_ClearAchievement( Self, pchName );
		#endregion
		internal bool ClearAchievement( string pchName )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_ClearAchievement( Self, str__pchName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime( IntPtr self, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved, ref uint punUnlockTime );
		internal bool _GetAchievementAndUnlockTime( IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved, ref uint punUnlockTime ) => _SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime( Self, pchName, ref pbAchieved, ref punUnlockTime );
		#endregion
		internal bool GetAchievementAndUnlockTime( string pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved, ref uint punUnlockTime )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime( Self, str__pchName.Pointer, ref pbAchieved, ref punUnlockTime );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_StoreStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_StoreStats", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_StoreStats( IntPtr self );
		internal bool _StoreStats(  ) => _SteamAPI_ISteamUserStats_StoreStats( Self );
		#endregion
		internal bool StoreStats()
		{
			var returnValue = _SteamAPI_ISteamUserStats_StoreStats( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementIcon
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementIcon", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUserStats_GetAchievementIcon( IntPtr self, IntPtr pchName );
		internal int _GetAchievementIcon( IntPtr pchName ) => _SteamAPI_ISteamUserStats_GetAchievementIcon( Self, pchName );
		#endregion
		internal int GetAchievementIcon( string pchName )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementIcon( Self, str__pchName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute( IntPtr self, IntPtr pchName, IntPtr pchKey );
		internal Utf8StringPtr _GetAchievementDisplayAttribute( IntPtr pchName, IntPtr pchKey ) => _SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute( Self, pchName, pchKey );
		#endregion
		internal string GetAchievementDisplayAttribute( string pchName, string pchKey )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute( Self, str__pchName.Pointer, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_IndicateAchievementProgress
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_IndicateAchievementProgress", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_IndicateAchievementProgress( IntPtr self, IntPtr pchName, uint nCurProgress, uint nMaxProgress );
		internal bool _IndicateAchievementProgress( IntPtr pchName, uint nCurProgress, uint nMaxProgress ) => _SteamAPI_ISteamUserStats_IndicateAchievementProgress( Self, pchName, nCurProgress, nMaxProgress );
		#endregion
		internal bool IndicateAchievementProgress( string pchName, uint nCurProgress, uint nMaxProgress )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_IndicateAchievementProgress( Self, str__pchName.Pointer, nCurProgress, nMaxProgress );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetNumAchievements
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetNumAchievements", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamUserStats_GetNumAchievements( IntPtr self );
		internal uint _GetNumAchievements(  ) => _SteamAPI_ISteamUserStats_GetNumAchievements( Self );
		#endregion
		internal uint GetNumAchievements()
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetNumAchievements( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementName", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamUserStats_GetAchievementName( IntPtr self, uint iAchievement );
		internal Utf8StringPtr _GetAchievementName( uint iAchievement ) => _SteamAPI_ISteamUserStats_GetAchievementName( Self, iAchievement );
		#endregion
		internal string GetAchievementName( uint iAchievement )
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementName( Self, iAchievement );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_RequestUserStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestUserStats", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_RequestUserStats( IntPtr self, SteamId steamIDUser );
		internal SteamAPICall_t _RequestUserStats( SteamId steamIDUser ) => _SteamAPI_ISteamUserStats_RequestUserStats( Self, steamIDUser );
		#endregion
		internal CallResult<UserStatsReceived_t> RequestUserStats( SteamId steamIDUser )
		{
			var returnValue = _SteamAPI_ISteamUserStats_RequestUserStats( Self, steamIDUser );
			return new CallResult<UserStatsReceived_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_GetUserStatInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStatInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetUserStatInt32( IntPtr self, SteamId steamIDUser, IntPtr pchName, ref int pData );
		internal bool _GetUserStat( SteamId steamIDUser, IntPtr pchName, ref int pData ) => _SteamAPI_ISteamUserStats_GetUserStatInt32( Self, steamIDUser, pchName, ref pData );
		#endregion
		internal bool GetUserStat( SteamId steamIDUser, string pchName, ref int pData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetUserStatInt32( Self, steamIDUser, str__pchName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetUserStatFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStatFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetUserStatFloat( IntPtr self, SteamId steamIDUser, IntPtr pchName, ref float pData );
		internal bool _GetUserStat( SteamId steamIDUser, IntPtr pchName, ref float pData ) => _SteamAPI_ISteamUserStats_GetUserStatFloat( Self, steamIDUser, pchName, ref pData );
		#endregion
		internal bool GetUserStat( SteamId steamIDUser, string pchName, ref float pData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetUserStatFloat( Self, steamIDUser, str__pchName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetUserAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetUserAchievement( IntPtr self, SteamId steamIDUser, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved );
		internal bool _GetUserAchievement( SteamId steamIDUser, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved ) => _SteamAPI_ISteamUserStats_GetUserAchievement( Self, steamIDUser, pchName, ref pbAchieved );
		#endregion
		internal bool GetUserAchievement( SteamId steamIDUser, string pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetUserAchievement( Self, steamIDUser, str__pchName.Pointer, ref pbAchieved );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime( IntPtr self, SteamId steamIDUser, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved, ref uint punUnlockTime );
		internal bool _GetUserAchievementAndUnlockTime( SteamId steamIDUser, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved, ref uint punUnlockTime ) => _SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime( Self, steamIDUser, pchName, ref pbAchieved, ref punUnlockTime );
		#endregion
		internal bool GetUserAchievementAndUnlockTime( SteamId steamIDUser, string pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved, ref uint punUnlockTime )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime( Self, steamIDUser, str__pchName.Pointer, ref pbAchieved, ref punUnlockTime );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_ResetAllStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_ResetAllStats", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_ResetAllStats( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bAchievementsToo );
		internal bool _ResetAllStats( [ MarshalAs( UnmanagedType.U1 ) ] bool bAchievementsToo ) => _SteamAPI_ISteamUserStats_ResetAllStats( Self, bAchievementsToo );
		#endregion
		internal bool ResetAllStats( [ MarshalAs( UnmanagedType.U1 ) ] bool bAchievementsToo )
		{
			var returnValue = _SteamAPI_ISteamUserStats_ResetAllStats( Self, bAchievementsToo );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_FindOrCreateLeaderboard
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_FindOrCreateLeaderboard", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_FindOrCreateLeaderboard( IntPtr self, IntPtr pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType );
		internal SteamAPICall_t _FindOrCreateLeaderboard( IntPtr pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType ) => _SteamAPI_ISteamUserStats_FindOrCreateLeaderboard( Self, pchLeaderboardName, eLeaderboardSortMethod, eLeaderboardDisplayType );
		#endregion
		internal CallResult<LeaderboardFindResult_t> FindOrCreateLeaderboard( string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType )
		{
			using var str__pchLeaderboardName = new Utf8StringToNative( pchLeaderboardName );
			var returnValue = _SteamAPI_ISteamUserStats_FindOrCreateLeaderboard( Self, str__pchLeaderboardName.Pointer, eLeaderboardSortMethod, eLeaderboardDisplayType );
			return new CallResult<LeaderboardFindResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_FindLeaderboard
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_FindLeaderboard", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_FindLeaderboard( IntPtr self, IntPtr pchLeaderboardName );
		internal SteamAPICall_t _FindLeaderboard( IntPtr pchLeaderboardName ) => _SteamAPI_ISteamUserStats_FindLeaderboard( Self, pchLeaderboardName );
		#endregion
		internal CallResult<LeaderboardFindResult_t> FindLeaderboard( string pchLeaderboardName )
		{
			using var str__pchLeaderboardName = new Utf8StringToNative( pchLeaderboardName );
			var returnValue = _SteamAPI_ISteamUserStats_FindLeaderboard( Self, str__pchLeaderboardName.Pointer );
			return new CallResult<LeaderboardFindResult_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_GetLeaderboardName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardName", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamUserStats_GetLeaderboardName( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		internal Utf8StringPtr _GetLeaderboardName( SteamLeaderboard_t hSteamLeaderboard ) => _SteamAPI_ISteamUserStats_GetLeaderboardName( Self, hSteamLeaderboard );
		#endregion
		internal string GetLeaderboardName( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetLeaderboardName( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetLeaderboardEntryCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardEntryCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUserStats_GetLeaderboardEntryCount( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		internal int _GetLeaderboardEntryCount( SteamLeaderboard_t hSteamLeaderboard ) => _SteamAPI_ISteamUserStats_GetLeaderboardEntryCount( Self, hSteamLeaderboard );
		#endregion
		internal int GetLeaderboardEntryCount( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetLeaderboardEntryCount( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetLeaderboardSortMethod
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardSortMethod", CallingConvention = Platform.CC ) ]
		internal static extern ELeaderboardSortMethod _SteamAPI_ISteamUserStats_GetLeaderboardSortMethod( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		internal ELeaderboardSortMethod _GetLeaderboardSortMethod( SteamLeaderboard_t hSteamLeaderboard ) => _SteamAPI_ISteamUserStats_GetLeaderboardSortMethod( Self, hSteamLeaderboard );
		#endregion
		internal ELeaderboardSortMethod GetLeaderboardSortMethod( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetLeaderboardSortMethod( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetLeaderboardDisplayType
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardDisplayType", CallingConvention = Platform.CC ) ]
		internal static extern ELeaderboardDisplayType _SteamAPI_ISteamUserStats_GetLeaderboardDisplayType( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		internal ELeaderboardDisplayType _GetLeaderboardDisplayType( SteamLeaderboard_t hSteamLeaderboard ) => _SteamAPI_ISteamUserStats_GetLeaderboardDisplayType( Self, hSteamLeaderboard );
		#endregion
		internal ELeaderboardDisplayType GetLeaderboardDisplayType( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetLeaderboardDisplayType( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_DownloadLeaderboardEntries
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntries", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_DownloadLeaderboardEntries( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd );
		internal SteamAPICall_t _DownloadLeaderboardEntries( SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd ) => _SteamAPI_ISteamUserStats_DownloadLeaderboardEntries( Self, hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd );
		#endregion
		internal CallResult<LeaderboardScoresDownloaded_t> DownloadLeaderboardEntries( SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd )
		{
			var returnValue = _SteamAPI_ISteamUserStats_DownloadLeaderboardEntries( Self, hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd );
			return new CallResult<LeaderboardScoresDownloaded_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, SteamId* prgUsers, int cUsers );
		internal SteamAPICall_t _DownloadLeaderboardEntriesForUsers( SteamLeaderboard_t hSteamLeaderboard, SteamId* prgUsers, int cUsers ) => _SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers( Self, hSteamLeaderboard, prgUsers, cUsers );
		#endregion
		internal CallResult<LeaderboardScoresDownloaded_t> DownloadLeaderboardEntriesForUsers( SteamLeaderboard_t hSteamLeaderboard, SteamId* prgUsers, int cUsers )
		{
			var returnValue = _SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers( Self, hSteamLeaderboard, prgUsers, cUsers );
			return new CallResult<LeaderboardScoresDownloaded_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry( IntPtr self, SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, int* pDetails, int cDetailsMax );
		internal bool _GetDownloadedLeaderboardEntry( SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, int* pDetails, int cDetailsMax ) => _SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry( Self, hSteamLeaderboardEntries, index, ref pLeaderboardEntry, pDetails, cDetailsMax );
		#endregion
		internal bool GetDownloadedLeaderboardEntry( SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, int* pDetails, int cDetailsMax )
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry( Self, hSteamLeaderboardEntries, index, ref pLeaderboardEntry, pDetails, cDetailsMax );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_UploadLeaderboardScore
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_UploadLeaderboardScore", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_UploadLeaderboardScore( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int* pScoreDetails, int cScoreDetailsCount );
		internal SteamAPICall_t _UploadLeaderboardScore( SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int* pScoreDetails, int cScoreDetailsCount ) => _SteamAPI_ISteamUserStats_UploadLeaderboardScore( Self, hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount );
		#endregion
		internal CallResult<LeaderboardScoreUploaded_t> UploadLeaderboardScore( SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int* pScoreDetails, int cScoreDetailsCount )
		{
			var returnValue = _SteamAPI_ISteamUserStats_UploadLeaderboardScore( Self, hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount );
			return new CallResult<LeaderboardScoreUploaded_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_AttachLeaderboardUGC
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_AttachLeaderboardUGC", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_AttachLeaderboardUGC( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC );
		internal SteamAPICall_t _AttachLeaderboardUGC( SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC ) => _SteamAPI_ISteamUserStats_AttachLeaderboardUGC( Self, hSteamLeaderboard, hUGC );
		#endregion
		internal CallResult<LeaderboardUGCSet_t> AttachLeaderboardUGC( SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC )
		{
			var returnValue = _SteamAPI_ISteamUserStats_AttachLeaderboardUGC( Self, hSteamLeaderboard, hUGC );
			return new CallResult<LeaderboardUGCSet_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers( IntPtr self );
		internal SteamAPICall_t _GetNumberOfCurrentPlayers(  ) => _SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers( Self );
		#endregion
		internal CallResult<NumberOfCurrentPlayers_t> GetNumberOfCurrentPlayers()
		{
			var returnValue = _SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers( Self );
			return new CallResult<NumberOfCurrentPlayers_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages( IntPtr self );
		internal SteamAPICall_t _RequestGlobalAchievementPercentages(  ) => _SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages( Self );
		#endregion
		internal CallResult<GlobalAchievementPercentagesReady_t> RequestGlobalAchievementPercentages()
		{
			var returnValue = _SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages( Self );
			return new CallResult<GlobalAchievementPercentagesReady_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo( IntPtr self, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved );
		internal int _GetMostAchievedAchievementInfo( IntPtr pchName, uint unNameBufLen, ref float pflPercent, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved ) => _SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo( Self, pchName, unNameBufLen, ref pflPercent, ref pbAchieved );
		#endregion
		internal int GetMostAchievedAchievementInfo( out string pchName, uint unNameBufLen, ref float pflPercent, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved )
		{
			using var mem__pchName = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo( Self, mem__pchName.Ptr, unNameBufLen, ref pflPercent, ref pbAchieved );
			pchName = Utility.MemoryToString( mem__pchName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo( IntPtr self, int iIteratorPrevious, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved );
		internal int _GetNextMostAchievedAchievementInfo( int iIteratorPrevious, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved ) => _SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo( Self, iIteratorPrevious, pchName, unNameBufLen, ref pflPercent, ref pbAchieved );
		#endregion
		internal int GetNextMostAchievedAchievementInfo( int iIteratorPrevious, out string pchName, uint unNameBufLen, ref float pflPercent, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved )
		{
			using var mem__pchName = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo( Self, iIteratorPrevious, mem__pchName.Ptr, unNameBufLen, ref pflPercent, ref pbAchieved );
			pchName = Utility.MemoryToString( mem__pchName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementAchievedPercent
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAchievedPercent", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetAchievementAchievedPercent( IntPtr self, IntPtr pchName, ref float pflPercent );
		internal bool _GetAchievementAchievedPercent( IntPtr pchName, ref float pflPercent ) => _SteamAPI_ISteamUserStats_GetAchievementAchievedPercent( Self, pchName, ref pflPercent );
		#endregion
		internal bool GetAchievementAchievedPercent( string pchName, ref float pflPercent )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementAchievedPercent( Self, str__pchName.Pointer, ref pflPercent );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_RequestGlobalStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalStats", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamUserStats_RequestGlobalStats( IntPtr self, int nHistoryDays );
		internal SteamAPICall_t _RequestGlobalStats( int nHistoryDays ) => _SteamAPI_ISteamUserStats_RequestGlobalStats( Self, nHistoryDays );
		#endregion
		internal CallResult<GlobalStatsReceived_t> RequestGlobalStats( int nHistoryDays )
		{
			var returnValue = _SteamAPI_ISteamUserStats_RequestGlobalStats( Self, nHistoryDays );
			return new CallResult<GlobalStatsReceived_t>( returnValue );
		}
		
		#region SteamAPI_ISteamUserStats_GetGlobalStatInt64
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatInt64", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetGlobalStatInt64( IntPtr self, IntPtr pchStatName, ref long pData );
		internal bool _GetGlobalStat( IntPtr pchStatName, ref long pData ) => _SteamAPI_ISteamUserStats_GetGlobalStatInt64( Self, pchStatName, ref pData );
		#endregion
		internal bool GetGlobalStat( string pchStatName, ref long pData )
		{
			using var str__pchStatName = new Utf8StringToNative( pchStatName );
			var returnValue = _SteamAPI_ISteamUserStats_GetGlobalStatInt64( Self, str__pchStatName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetGlobalStatDouble
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatDouble", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetGlobalStatDouble( IntPtr self, IntPtr pchStatName, ref double pData );
		internal bool _GetGlobalStat( IntPtr pchStatName, ref double pData ) => _SteamAPI_ISteamUserStats_GetGlobalStatDouble( Self, pchStatName, ref pData );
		#endregion
		internal bool GetGlobalStat( string pchStatName, ref double pData )
		{
			using var str__pchStatName = new Utf8StringToNative( pchStatName );
			var returnValue = _SteamAPI_ISteamUserStats_GetGlobalStatDouble( Self, str__pchStatName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64( IntPtr self, IntPtr pchStatName, long* pData, uint cubData );
		internal int _GetGlobalStatHistory( IntPtr pchStatName, long* pData, uint cubData ) => _SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64( Self, pchStatName, pData, cubData );
		#endregion
		internal int GetGlobalStatHistory( string pchStatName, long* pData, uint cubData )
		{
			using var str__pchStatName = new Utf8StringToNative( pchStatName );
			var returnValue = _SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64( Self, str__pchStatName.Pointer, pData, cubData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble( IntPtr self, IntPtr pchStatName, double* pData, uint cubData );
		internal int _GetGlobalStatHistory( IntPtr pchStatName, double* pData, uint cubData ) => _SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble( Self, pchStatName, pData, cubData );
		#endregion
		internal int GetGlobalStatHistory( string pchStatName, double* pData, uint cubData )
		{
			using var str__pchStatName = new Utf8StringToNative( pchStatName );
			var returnValue = _SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble( Self, str__pchStatName.Pointer, pData, cubData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32( IntPtr self, IntPtr pchName, ref int pnMinProgress, ref int pnMaxProgress );
		internal bool _GetAchievementProgressLimits( IntPtr pchName, ref int pnMinProgress, ref int pnMaxProgress ) => _SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32( Self, pchName, ref pnMinProgress, ref pnMaxProgress );
		#endregion
		internal bool GetAchievementProgressLimits( string pchName, ref int pnMinProgress, ref int pnMaxProgress )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32( Self, str__pchName.Pointer, ref pnMinProgress, ref pnMaxProgress );
			return returnValue;
		}
		
		#region SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat( IntPtr self, IntPtr pchName, ref float pfMinProgress, ref float pfMaxProgress );
		internal bool _GetAchievementProgressLimits( IntPtr pchName, ref float pfMinProgress, ref float pfMaxProgress ) => _SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat( Self, pchName, ref pfMinProgress, ref pfMaxProgress );
		#endregion
		internal bool GetAchievementProgressLimits( string pchName, ref float pfMinProgress, ref float pfMaxProgress )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat( Self, str__pchName.Pointer, ref pfMinProgress, ref pfMaxProgress );
			return returnValue;
		}
		
	}
}
