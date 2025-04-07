using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamParentalSettings
	{
		public const string Version = "STEAMPARENTALSETTINGS_INTERFACE_VERSION001";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamParentalSettings_v001", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamParentalSettings_v001();
		/// Construct use accessor to find interface
		public ISteamParentalSettings( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamParentalSettings_v001();
			}
		}
		public ISteamParentalSettings( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled( IntPtr self );
		internal bool _BIsParentalLockEnabled(  ) => _SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled( Self );
		#endregion
		internal bool BIsParentalLockEnabled()
		{
			var returnValue = _SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParentalSettings_BIsParentalLockLocked
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsParentalLockLocked", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParentalSettings_BIsParentalLockLocked( IntPtr self );
		internal bool _BIsParentalLockLocked(  ) => _SteamAPI_ISteamParentalSettings_BIsParentalLockLocked( Self );
		#endregion
		internal bool BIsParentalLockLocked()
		{
			var returnValue = _SteamAPI_ISteamParentalSettings_BIsParentalLockLocked( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParentalSettings_BIsAppBlocked
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsAppBlocked", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParentalSettings_BIsAppBlocked( IntPtr self, AppId_t nAppID );
		internal bool _BIsAppBlocked( AppId_t nAppID ) => _SteamAPI_ISteamParentalSettings_BIsAppBlocked( Self, nAppID );
		#endregion
		internal bool BIsAppBlocked( AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamParentalSettings_BIsAppBlocked( Self, nAppID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParentalSettings_BIsAppInBlockList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsAppInBlockList", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParentalSettings_BIsAppInBlockList( IntPtr self, AppId_t nAppID );
		internal bool _BIsAppInBlockList( AppId_t nAppID ) => _SteamAPI_ISteamParentalSettings_BIsAppInBlockList( Self, nAppID );
		#endregion
		internal bool BIsAppInBlockList( AppId_t nAppID )
		{
			var returnValue = _SteamAPI_ISteamParentalSettings_BIsAppInBlockList( Self, nAppID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParentalSettings_BIsFeatureBlocked
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsFeatureBlocked", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParentalSettings_BIsFeatureBlocked( IntPtr self, EParentalFeature eFeature );
		internal bool _BIsFeatureBlocked( EParentalFeature eFeature ) => _SteamAPI_ISteamParentalSettings_BIsFeatureBlocked( Self, eFeature );
		#endregion
		internal bool BIsFeatureBlocked( EParentalFeature eFeature )
		{
			var returnValue = _SteamAPI_ISteamParentalSettings_BIsFeatureBlocked( Self, eFeature );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList( IntPtr self, EParentalFeature eFeature );
		internal bool _BIsFeatureInBlockList( EParentalFeature eFeature ) => _SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList( Self, eFeature );
		#endregion
		internal bool BIsFeatureInBlockList( EParentalFeature eFeature )
		{
			var returnValue = _SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList( Self, eFeature );
			return returnValue;
		}
		
	}
}
