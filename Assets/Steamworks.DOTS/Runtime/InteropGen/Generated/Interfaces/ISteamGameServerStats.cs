using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamGameServerStats
	{
		public const string Version = "SteamGameServerStats001";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerStats_v001", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerStats_v001();
		/// Construct use accessor to find interface
		public ISteamGameServerStats( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerStats_v001();
			}
		}
		public ISteamGameServerStats( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamGameServerStats_RequestUserStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_RequestUserStats", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamGameServerStats_RequestUserStats( IntPtr self, SteamId steamIDUser );
		#endregion
		internal SteamAPICall_t RequestUserStats( SteamId steamIDUser )
		{
			var returnValue = _SteamAPI_ISteamGameServerStats_RequestUserStats( Self, steamIDUser );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_GetUserStatInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserStatInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_GetUserStatInt32( IntPtr self, SteamId steamIDUser, IntPtr pchName, ref int pData );
		#endregion
		internal bool GetUserStat( SteamId steamIDUser, string pchName, ref int pData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_GetUserStatInt32( Self, steamIDUser, str__pchName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_GetUserStatFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserStatFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_GetUserStatFloat( IntPtr self, SteamId steamIDUser, IntPtr pchName, ref float pData );
		#endregion
		internal bool GetUserStat( SteamId steamIDUser, string pchName, ref float pData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_GetUserStatFloat( Self, steamIDUser, str__pchName.Pointer, ref pData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_GetUserAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_GetUserAchievement( IntPtr self, SteamId steamIDUser, IntPtr pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved );
		#endregion
		internal bool GetUserAchievement( SteamId steamIDUser, string pchName, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbAchieved )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_GetUserAchievement( Self, steamIDUser, str__pchName.Pointer, ref pbAchieved );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_SetUserStatInt32
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserStatInt32", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_SetUserStatInt32( IntPtr self, SteamId steamIDUser, IntPtr pchName, int nData );
		#endregion
		internal bool SetUserStat( SteamId steamIDUser, string pchName, int nData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_SetUserStatInt32( Self, steamIDUser, str__pchName.Pointer, nData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_SetUserStatFloat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserStatFloat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_SetUserStatFloat( IntPtr self, SteamId steamIDUser, IntPtr pchName, float fData );
		#endregion
		internal bool SetUserStat( SteamId steamIDUser, string pchName, float fData )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_SetUserStatFloat( Self, steamIDUser, str__pchName.Pointer, fData );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat( IntPtr self, SteamId steamIDUser, IntPtr pchName, float flCountThisSession, double dSessionLength );
		#endregion
		internal bool UpdateUserAvgRateStat( SteamId steamIDUser, string pchName, float flCountThisSession, double dSessionLength )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat( Self, steamIDUser, str__pchName.Pointer, flCountThisSession, dSessionLength );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_SetUserAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_SetUserAchievement( IntPtr self, SteamId steamIDUser, IntPtr pchName );
		#endregion
		internal bool SetUserAchievement( SteamId steamIDUser, string pchName )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_SetUserAchievement( Self, steamIDUser, str__pchName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_ClearUserAchievement
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_ClearUserAchievement", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamGameServerStats_ClearUserAchievement( IntPtr self, SteamId steamIDUser, IntPtr pchName );
		#endregion
		internal bool ClearUserAchievement( SteamId steamIDUser, string pchName )
		{
			using var str__pchName = new Utf8StringToNative( pchName );
			var returnValue = _SteamAPI_ISteamGameServerStats_ClearUserAchievement( Self, steamIDUser, str__pchName.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameServerStats_StoreUserStats
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameServerStats_StoreUserStats", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamGameServerStats_StoreUserStats( IntPtr self, SteamId steamIDUser );
		#endregion
		internal SteamAPICall_t StoreUserStats( SteamId steamIDUser )
		{
			var returnValue = _SteamAPI_ISteamGameServerStats_StoreUserStats( Self, steamIDUser );
			return returnValue;
		}
		
	}
}
