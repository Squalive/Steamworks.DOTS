using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamParties
	{
		public const string Version = "SteamParties002";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamParties_v002", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamParties_v002();
		/// Construct use accessor to find interface
		public ISteamParties( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamParties_v002();
			}
		}
		public ISteamParties( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamParties_GetNumActiveBeacons
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_GetNumActiveBeacons", CallingConvention = Platform.CC ) ]
		internal static extern uint _SteamAPI_ISteamParties_GetNumActiveBeacons( IntPtr self );
		internal uint _GetNumActiveBeacons(  ) => _SteamAPI_ISteamParties_GetNumActiveBeacons( Self );
		#endregion
		internal uint GetNumActiveBeacons()
		{
			var returnValue = _SteamAPI_ISteamParties_GetNumActiveBeacons( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParties_GetBeaconByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_GetBeaconByIndex", CallingConvention = Platform.CC ) ]
		internal static extern PartyBeaconID_t _SteamAPI_ISteamParties_GetBeaconByIndex( IntPtr self, uint unIndex );
		internal PartyBeaconID_t _GetBeaconByIndex( uint unIndex ) => _SteamAPI_ISteamParties_GetBeaconByIndex( Self, unIndex );
		#endregion
		internal PartyBeaconID_t GetBeaconByIndex( uint unIndex )
		{
			var returnValue = _SteamAPI_ISteamParties_GetBeaconByIndex( Self, unIndex );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParties_GetBeaconDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_GetBeaconDetails", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParties_GetBeaconDetails( IntPtr self, PartyBeaconID_t ulBeaconID, ref SteamId pSteamIDBeaconOwner, ref SteamPartyBeaconLocation_t pLocation, IntPtr pchMetadata, int cchMetadata );
		internal bool _GetBeaconDetails( PartyBeaconID_t ulBeaconID, ref SteamId pSteamIDBeaconOwner, ref SteamPartyBeaconLocation_t pLocation, IntPtr pchMetadata, int cchMetadata ) => _SteamAPI_ISteamParties_GetBeaconDetails( Self, ulBeaconID, ref pSteamIDBeaconOwner, ref pLocation, pchMetadata, cchMetadata );
		#endregion
		internal bool GetBeaconDetails( PartyBeaconID_t ulBeaconID, ref SteamId pSteamIDBeaconOwner, ref SteamPartyBeaconLocation_t pLocation, out string pchMetadata, int cchMetadata )
		{
			using var mem__pchMetadata = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamParties_GetBeaconDetails( Self, ulBeaconID, ref pSteamIDBeaconOwner, ref pLocation, mem__pchMetadata.Ptr, cchMetadata );
			pchMetadata = Utility.MemoryToString( mem__pchMetadata );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParties_JoinParty
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_JoinParty", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamParties_JoinParty( IntPtr self, PartyBeaconID_t ulBeaconID );
		internal SteamAPICall_t _JoinParty( PartyBeaconID_t ulBeaconID ) => _SteamAPI_ISteamParties_JoinParty( Self, ulBeaconID );
		#endregion
		internal CallResult<JoinPartyCallback_t> JoinParty( PartyBeaconID_t ulBeaconID )
		{
			var returnValue = _SteamAPI_ISteamParties_JoinParty( Self, ulBeaconID );
			return new CallResult<JoinPartyCallback_t>( returnValue );
		}
		
		#region SteamAPI_ISteamParties_GetNumAvailableBeaconLocations
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_GetNumAvailableBeaconLocations", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParties_GetNumAvailableBeaconLocations( IntPtr self, ref uint puNumLocations );
		internal bool _GetNumAvailableBeaconLocations( ref uint puNumLocations ) => _SteamAPI_ISteamParties_GetNumAvailableBeaconLocations( Self, ref puNumLocations );
		#endregion
		internal bool GetNumAvailableBeaconLocations( ref uint puNumLocations )
		{
			var returnValue = _SteamAPI_ISteamParties_GetNumAvailableBeaconLocations( Self, ref puNumLocations );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParties_GetAvailableBeaconLocations
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_GetAvailableBeaconLocations", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParties_GetAvailableBeaconLocations( IntPtr self, ref SteamPartyBeaconLocation_t pLocationList, uint uMaxNumLocations );
		internal bool _GetAvailableBeaconLocations( ref SteamPartyBeaconLocation_t pLocationList, uint uMaxNumLocations ) => _SteamAPI_ISteamParties_GetAvailableBeaconLocations( Self, ref pLocationList, uMaxNumLocations );
		#endregion
		internal bool GetAvailableBeaconLocations( ref SteamPartyBeaconLocation_t pLocationList, uint uMaxNumLocations )
		{
			var returnValue = _SteamAPI_ISteamParties_GetAvailableBeaconLocations( Self, ref pLocationList, uMaxNumLocations );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParties_CreateBeacon
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_CreateBeacon", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamParties_CreateBeacon( IntPtr self, uint unOpenSlots, ref SteamPartyBeaconLocation_t pBeaconLocation, IntPtr pchConnectString, IntPtr pchMetadata );
		internal SteamAPICall_t _CreateBeacon( uint unOpenSlots, ref SteamPartyBeaconLocation_t pBeaconLocation, IntPtr pchConnectString, IntPtr pchMetadata ) => _SteamAPI_ISteamParties_CreateBeacon( Self, unOpenSlots, ref pBeaconLocation, pchConnectString, pchMetadata );
		#endregion
		internal CallResult<CreateBeaconCallback_t> CreateBeacon( uint unOpenSlots, ref SteamPartyBeaconLocation_t pBeaconLocation, string pchConnectString, string pchMetadata )
		{
			using var str__pchConnectString = new Utf8StringToNative( pchConnectString );
			using var str__pchMetadata = new Utf8StringToNative( pchMetadata );
			var returnValue = _SteamAPI_ISteamParties_CreateBeacon( Self, unOpenSlots, ref pBeaconLocation, str__pchConnectString.Pointer, str__pchMetadata.Pointer );
			return new CallResult<CreateBeaconCallback_t>( returnValue );
		}
		
		#region SteamAPI_ISteamParties_OnReservationCompleted
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_OnReservationCompleted", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamParties_OnReservationCompleted( IntPtr self, PartyBeaconID_t ulBeacon, SteamId steamIDUser );
		internal void _OnReservationCompleted( PartyBeaconID_t ulBeacon, SteamId steamIDUser ) => _SteamAPI_ISteamParties_OnReservationCompleted( Self, ulBeacon, steamIDUser );
		#endregion
		internal void OnReservationCompleted( PartyBeaconID_t ulBeacon, SteamId steamIDUser )
		{
			_SteamAPI_ISteamParties_OnReservationCompleted( Self, ulBeacon, steamIDUser );
		}
		
		#region SteamAPI_ISteamParties_CancelReservation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_CancelReservation", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamParties_CancelReservation( IntPtr self, PartyBeaconID_t ulBeacon, SteamId steamIDUser );
		internal void _CancelReservation( PartyBeaconID_t ulBeacon, SteamId steamIDUser ) => _SteamAPI_ISteamParties_CancelReservation( Self, ulBeacon, steamIDUser );
		#endregion
		internal void CancelReservation( PartyBeaconID_t ulBeacon, SteamId steamIDUser )
		{
			_SteamAPI_ISteamParties_CancelReservation( Self, ulBeacon, steamIDUser );
		}
		
		#region SteamAPI_ISteamParties_ChangeNumOpenSlots
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_ChangeNumOpenSlots", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamParties_ChangeNumOpenSlots( IntPtr self, PartyBeaconID_t ulBeacon, uint unOpenSlots );
		internal SteamAPICall_t _ChangeNumOpenSlots( PartyBeaconID_t ulBeacon, uint unOpenSlots ) => _SteamAPI_ISteamParties_ChangeNumOpenSlots( Self, ulBeacon, unOpenSlots );
		#endregion
		internal CallResult<ChangeNumOpenSlotsCallback_t> ChangeNumOpenSlots( PartyBeaconID_t ulBeacon, uint unOpenSlots )
		{
			var returnValue = _SteamAPI_ISteamParties_ChangeNumOpenSlots( Self, ulBeacon, unOpenSlots );
			return new CallResult<ChangeNumOpenSlotsCallback_t>( returnValue );
		}
		
		#region SteamAPI_ISteamParties_DestroyBeacon
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_DestroyBeacon", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParties_DestroyBeacon( IntPtr self, PartyBeaconID_t ulBeacon );
		internal bool _DestroyBeacon( PartyBeaconID_t ulBeacon ) => _SteamAPI_ISteamParties_DestroyBeacon( Self, ulBeacon );
		#endregion
		internal bool DestroyBeacon( PartyBeaconID_t ulBeacon )
		{
			var returnValue = _SteamAPI_ISteamParties_DestroyBeacon( Self, ulBeacon );
			return returnValue;
		}
		
		#region SteamAPI_ISteamParties_GetBeaconLocationData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamParties_GetBeaconLocationData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamParties_GetBeaconLocationData( IntPtr self, SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, IntPtr pchDataStringOut, int cchDataStringOut );
		internal bool _GetBeaconLocationData( SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, IntPtr pchDataStringOut, int cchDataStringOut ) => _SteamAPI_ISteamParties_GetBeaconLocationData( Self, BeaconLocation, eData, pchDataStringOut, cchDataStringOut );
		#endregion
		internal bool GetBeaconLocationData( SteamPartyBeaconLocation_t BeaconLocation, ESteamPartyBeaconLocationData eData, out string pchDataStringOut, int cchDataStringOut )
		{
			using var mem__pchDataStringOut = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamParties_GetBeaconLocationData( Self, BeaconLocation, eData, mem__pchDataStringOut.Ptr, cchDataStringOut );
			pchDataStringOut = Utility.MemoryToString( mem__pchDataStringOut );
			return returnValue;
		}
		
	}
}
