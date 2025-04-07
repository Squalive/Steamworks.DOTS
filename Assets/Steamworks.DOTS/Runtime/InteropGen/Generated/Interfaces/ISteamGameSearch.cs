using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamGameSearch
	{
		public const string Version = "SteamMatchGameSearch001";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameSearch_v001", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameSearch_v001();
		/// Construct use accessor to find interface
		public ISteamGameSearch( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamGameSearch_v001();
			}
		}
		public ISteamGameSearch( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamGameSearch_AddGameSearchParams
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_AddGameSearchParams", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_AddGameSearchParams( IntPtr self, IntPtr pchKeyToFind, IntPtr pchValuesToFind );
		internal EGameSearchErrorCode_t _AddGameSearchParams( IntPtr pchKeyToFind, IntPtr pchValuesToFind ) => _SteamAPI_ISteamGameSearch_AddGameSearchParams( Self, pchKeyToFind, pchValuesToFind );
		#endregion
		internal EGameSearchErrorCode_t AddGameSearchParams( string pchKeyToFind, string pchValuesToFind )
		{
			using var str__pchKeyToFind = new Utf8StringToNative( pchKeyToFind );
			using var str__pchValuesToFind = new Utf8StringToNative( pchValuesToFind );
			var returnValue = _SteamAPI_ISteamGameSearch_AddGameSearchParams( Self, str__pchKeyToFind.Pointer, str__pchValuesToFind.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_SearchForGameWithLobby
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_SearchForGameWithLobby", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_SearchForGameWithLobby( IntPtr self, SteamId steamIDLobby, int nPlayerMin, int nPlayerMax );
		internal EGameSearchErrorCode_t _SearchForGameWithLobby( SteamId steamIDLobby, int nPlayerMin, int nPlayerMax ) => _SteamAPI_ISteamGameSearch_SearchForGameWithLobby( Self, steamIDLobby, nPlayerMin, nPlayerMax );
		#endregion
		internal EGameSearchErrorCode_t SearchForGameWithLobby( SteamId steamIDLobby, int nPlayerMin, int nPlayerMax )
		{
			var returnValue = _SteamAPI_ISteamGameSearch_SearchForGameWithLobby( Self, steamIDLobby, nPlayerMin, nPlayerMax );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_SearchForGameSolo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_SearchForGameSolo", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_SearchForGameSolo( IntPtr self, int nPlayerMin, int nPlayerMax );
		internal EGameSearchErrorCode_t _SearchForGameSolo( int nPlayerMin, int nPlayerMax ) => _SteamAPI_ISteamGameSearch_SearchForGameSolo( Self, nPlayerMin, nPlayerMax );
		#endregion
		internal EGameSearchErrorCode_t SearchForGameSolo( int nPlayerMin, int nPlayerMax )
		{
			var returnValue = _SteamAPI_ISteamGameSearch_SearchForGameSolo( Self, nPlayerMin, nPlayerMax );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_AcceptGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_AcceptGame", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_AcceptGame( IntPtr self );
		internal EGameSearchErrorCode_t _AcceptGame(  ) => _SteamAPI_ISteamGameSearch_AcceptGame( Self );
		#endregion
		internal EGameSearchErrorCode_t AcceptGame()
		{
			var returnValue = _SteamAPI_ISteamGameSearch_AcceptGame( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_DeclineGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_DeclineGame", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_DeclineGame( IntPtr self );
		internal EGameSearchErrorCode_t _DeclineGame(  ) => _SteamAPI_ISteamGameSearch_DeclineGame( Self );
		#endregion
		internal EGameSearchErrorCode_t DeclineGame()
		{
			var returnValue = _SteamAPI_ISteamGameSearch_DeclineGame( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_RetrieveConnectionDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_RetrieveConnectionDetails", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_RetrieveConnectionDetails( IntPtr self, SteamId steamIDHost, IntPtr pchConnectionDetails, int cubConnectionDetails );
		internal EGameSearchErrorCode_t _RetrieveConnectionDetails( SteamId steamIDHost, IntPtr pchConnectionDetails, int cubConnectionDetails ) => _SteamAPI_ISteamGameSearch_RetrieveConnectionDetails( Self, steamIDHost, pchConnectionDetails, cubConnectionDetails );
		#endregion
		internal EGameSearchErrorCode_t RetrieveConnectionDetails( SteamId steamIDHost, out string pchConnectionDetails, int cubConnectionDetails )
		{
			using var mem__pchConnectionDetails = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamGameSearch_RetrieveConnectionDetails( Self, steamIDHost, mem__pchConnectionDetails.Ptr, cubConnectionDetails );
			pchConnectionDetails = Utility.MemoryToString( mem__pchConnectionDetails );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_EndGameSearch
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_EndGameSearch", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_EndGameSearch( IntPtr self );
		internal EGameSearchErrorCode_t _EndGameSearch(  ) => _SteamAPI_ISteamGameSearch_EndGameSearch( Self );
		#endregion
		internal EGameSearchErrorCode_t EndGameSearch()
		{
			var returnValue = _SteamAPI_ISteamGameSearch_EndGameSearch( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_SetGameHostParams
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_SetGameHostParams", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_SetGameHostParams( IntPtr self, IntPtr pchKey, IntPtr pchValue );
		internal EGameSearchErrorCode_t _SetGameHostParams( IntPtr pchKey, IntPtr pchValue ) => _SteamAPI_ISteamGameSearch_SetGameHostParams( Self, pchKey, pchValue );
		#endregion
		internal EGameSearchErrorCode_t SetGameHostParams( string pchKey, string pchValue )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			var returnValue = _SteamAPI_ISteamGameSearch_SetGameHostParams( Self, str__pchKey.Pointer, str__pchValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_SetConnectionDetails
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_SetConnectionDetails", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_SetConnectionDetails( IntPtr self, IntPtr pchConnectionDetails, int cubConnectionDetails );
		internal EGameSearchErrorCode_t _SetConnectionDetails( IntPtr pchConnectionDetails, int cubConnectionDetails ) => _SteamAPI_ISteamGameSearch_SetConnectionDetails( Self, pchConnectionDetails, cubConnectionDetails );
		#endregion
		internal EGameSearchErrorCode_t SetConnectionDetails( string pchConnectionDetails, int cubConnectionDetails )
		{
			using var str__pchConnectionDetails = new Utf8StringToNative( pchConnectionDetails );
			var returnValue = _SteamAPI_ISteamGameSearch_SetConnectionDetails( Self, str__pchConnectionDetails.Pointer, cubConnectionDetails );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_RequestPlayersForGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_RequestPlayersForGame", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_RequestPlayersForGame( IntPtr self, int nPlayerMin, int nPlayerMax, int nMaxTeamSize );
		internal EGameSearchErrorCode_t _RequestPlayersForGame( int nPlayerMin, int nPlayerMax, int nMaxTeamSize ) => _SteamAPI_ISteamGameSearch_RequestPlayersForGame( Self, nPlayerMin, nPlayerMax, nMaxTeamSize );
		#endregion
		internal EGameSearchErrorCode_t RequestPlayersForGame( int nPlayerMin, int nPlayerMax, int nMaxTeamSize )
		{
			var returnValue = _SteamAPI_ISteamGameSearch_RequestPlayersForGame( Self, nPlayerMin, nPlayerMax, nMaxTeamSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_HostConfirmGameStart
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_HostConfirmGameStart", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_HostConfirmGameStart( IntPtr self, ulong ullUniqueGameID );
		internal EGameSearchErrorCode_t _HostConfirmGameStart( ulong ullUniqueGameID ) => _SteamAPI_ISteamGameSearch_HostConfirmGameStart( Self, ullUniqueGameID );
		#endregion
		internal EGameSearchErrorCode_t HostConfirmGameStart( ulong ullUniqueGameID )
		{
			var returnValue = _SteamAPI_ISteamGameSearch_HostConfirmGameStart( Self, ullUniqueGameID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_CancelRequestPlayersForGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_CancelRequestPlayersForGame", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_CancelRequestPlayersForGame( IntPtr self );
		internal EGameSearchErrorCode_t _CancelRequestPlayersForGame(  ) => _SteamAPI_ISteamGameSearch_CancelRequestPlayersForGame( Self );
		#endregion
		internal EGameSearchErrorCode_t CancelRequestPlayersForGame()
		{
			var returnValue = _SteamAPI_ISteamGameSearch_CancelRequestPlayersForGame( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_SubmitPlayerResult
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_SubmitPlayerResult", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_SubmitPlayerResult( IntPtr self, ulong ullUniqueGameID, SteamId steamIDPlayer, EPlayerResult_t EPlayerResult );
		internal EGameSearchErrorCode_t _SubmitPlayerResult( ulong ullUniqueGameID, SteamId steamIDPlayer, EPlayerResult_t EPlayerResult ) => _SteamAPI_ISteamGameSearch_SubmitPlayerResult( Self, ullUniqueGameID, steamIDPlayer, EPlayerResult );
		#endregion
		internal EGameSearchErrorCode_t SubmitPlayerResult( ulong ullUniqueGameID, SteamId steamIDPlayer, EPlayerResult_t EPlayerResult )
		{
			var returnValue = _SteamAPI_ISteamGameSearch_SubmitPlayerResult( Self, ullUniqueGameID, steamIDPlayer, EPlayerResult );
			return returnValue;
		}
		
		#region SteamAPI_ISteamGameSearch_EndGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamGameSearch_EndGame", CallingConvention = Platform.CC ) ]
		internal static extern EGameSearchErrorCode_t _SteamAPI_ISteamGameSearch_EndGame( IntPtr self, ulong ullUniqueGameID );
		internal EGameSearchErrorCode_t _EndGame( ulong ullUniqueGameID ) => _SteamAPI_ISteamGameSearch_EndGame( Self, ullUniqueGameID );
		#endregion
		internal EGameSearchErrorCode_t EndGame( ulong ullUniqueGameID )
		{
			var returnValue = _SteamAPI_ISteamGameSearch_EndGame( Self, ullUniqueGameID );
			return returnValue;
		}
		
	}
}
