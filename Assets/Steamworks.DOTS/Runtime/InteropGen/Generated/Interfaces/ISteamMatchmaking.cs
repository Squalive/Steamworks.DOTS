using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamMatchmaking
	{
		public const string Version = "SteamMatchMaking009";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamMatchmaking_v009", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamMatchmaking_v009();
		/// Construct use accessor to find interface
		public ISteamMatchmaking( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamMatchmaking_v009();
			}
		}
		public ISteamMatchmaking( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamMatchmaking_GetFavoriteGameCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGameCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmaking_GetFavoriteGameCount( IntPtr self );
		#endregion
		internal int GetFavoriteGameCount()
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetFavoriteGameCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetFavoriteGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGame", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_GetFavoriteGame( IntPtr self, int iGame, ref AppId_t pnAppID, ref uint pnIP, ref ushort pnConnPort, ref ushort pnQueryPort, ref uint punFlags, ref uint pRTime32LastPlayedOnServer );
		#endregion
		internal bool GetFavoriteGame( int iGame, ref AppId_t pnAppID, ref uint pnIP, ref ushort pnConnPort, ref ushort pnQueryPort, ref uint punFlags, ref uint pRTime32LastPlayedOnServer )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetFavoriteGame( Self, iGame, ref pnAppID, ref pnIP, ref pnConnPort, ref pnQueryPort, ref punFlags, ref pRTime32LastPlayedOnServer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_AddFavoriteGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddFavoriteGame", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmaking_AddFavoriteGame( IntPtr self, AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer );
		#endregion
		internal int AddFavoriteGame( AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_AddFavoriteGame( Self, nAppID, nIP, nConnPort, nQueryPort, unFlags, rTime32LastPlayedOnServer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_RemoveFavoriteGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_RemoveFavoriteGame", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_RemoveFavoriteGame( IntPtr self, AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags );
		#endregion
		internal bool RemoveFavoriteGame( AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_RemoveFavoriteGame( Self, nAppID, nIP, nConnPort, nQueryPort, unFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_RequestLobbyList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyList", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamMatchmaking_RequestLobbyList( IntPtr self );
		#endregion
		internal SteamAPICall_t RequestLobbyList()
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_RequestLobbyList( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter( IntPtr self, IntPtr pchKeyToMatch, IntPtr pchValueToMatch, ELobbyComparison eComparisonType );
		#endregion
		internal void AddRequestLobbyListStringFilter( string pchKeyToMatch, string pchValueToMatch, ELobbyComparison eComparisonType )
		{
			using var str__pchKeyToMatch = new Utf8StringToNative( pchKeyToMatch );
			using var str__pchValueToMatch = new Utf8StringToNative( pchValueToMatch );
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter( Self, str__pchKeyToMatch.Pointer, str__pchValueToMatch.Pointer, eComparisonType );
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter( IntPtr self, IntPtr pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType );
		#endregion
		internal void AddRequestLobbyListNumericalFilter( string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType )
		{
			using var str__pchKeyToMatch = new Utf8StringToNative( pchKeyToMatch );
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter( Self, str__pchKeyToMatch.Pointer, nValueToMatch, eComparisonType );
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter( IntPtr self, IntPtr pchKeyToMatch, int nValueToBeCloseTo );
		#endregion
		internal void AddRequestLobbyListNearValueFilter( string pchKeyToMatch, int nValueToBeCloseTo )
		{
			using var str__pchKeyToMatch = new Utf8StringToNative( pchKeyToMatch );
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter( Self, str__pchKeyToMatch.Pointer, nValueToBeCloseTo );
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable( IntPtr self, int nSlotsAvailable );
		#endregion
		internal void AddRequestLobbyListFilterSlotsAvailable( int nSlotsAvailable )
		{
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable( Self, nSlotsAvailable );
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter( IntPtr self, ELobbyDistanceFilter eLobbyDistanceFilter );
		#endregion
		internal void AddRequestLobbyListDistanceFilter( ELobbyDistanceFilter eLobbyDistanceFilter )
		{
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter( Self, eLobbyDistanceFilter );
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter( IntPtr self, int cMaxResults );
		#endregion
		internal void AddRequestLobbyListResultCountFilter( int cMaxResults )
		{
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter( Self, cMaxResults );
		}
		
		#region SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal void AddRequestLobbyListCompatibleMembersFilter( SteamId steamIDLobby )
		{
			_SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter( Self, steamIDLobby );
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyByIndex", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamMatchmaking_GetLobbyByIndex( IntPtr self, int iLobby );
		#endregion
		internal SteamId GetLobbyByIndex( int iLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyByIndex( Self, iLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_CreateLobby
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_CreateLobby", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamMatchmaking_CreateLobby( IntPtr self, ELobbyType eLobbyType, int cMaxMembers );
		#endregion
		internal SteamAPICall_t CreateLobby( ELobbyType eLobbyType, int cMaxMembers )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_CreateLobby( Self, eLobbyType, cMaxMembers );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_JoinLobby
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_JoinLobby", CallingConvention = Platform.CC ) ]
		internal static extern SteamAPICall_t _SteamAPI_ISteamMatchmaking_JoinLobby( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal SteamAPICall_t JoinLobby( SteamId steamIDLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_JoinLobby( Self, steamIDLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_LeaveLobby
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_LeaveLobby", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_LeaveLobby( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal void LeaveLobby( SteamId steamIDLobby )
		{
			_SteamAPI_ISteamMatchmaking_LeaveLobby( Self, steamIDLobby );
		}
		
		#region SteamAPI_ISteamMatchmaking_InviteUserToLobby
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_InviteUserToLobby", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_InviteUserToLobby( IntPtr self, SteamId steamIDLobby, SteamId steamIDInvitee );
		#endregion
		internal bool InviteUserToLobby( SteamId steamIDLobby, SteamId steamIDInvitee )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_InviteUserToLobby( Self, steamIDLobby, steamIDInvitee );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetNumLobbyMembers
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetNumLobbyMembers", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmaking_GetNumLobbyMembers( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal int GetNumLobbyMembers( SteamId steamIDLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetNumLobbyMembers( Self, steamIDLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex( IntPtr self, SteamId steamIDLobby, int iMember );
		#endregion
		internal SteamId GetLobbyMemberByIndex( SteamId steamIDLobby, int iMember )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex( Self, steamIDLobby, iMember );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyData", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamMatchmaking_GetLobbyData( IntPtr self, SteamId steamIDLobby, IntPtr pchKey );
		#endregion
		internal string GetLobbyData( SteamId steamIDLobby, string pchKey )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyData( Self, steamIDLobby, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SetLobbyData( IntPtr self, SteamId steamIDLobby, IntPtr pchKey, IntPtr pchValue );
		#endregion
		internal bool SetLobbyData( SteamId steamIDLobby, string pchKey, string pchValue )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			var returnValue = _SteamAPI_ISteamMatchmaking_SetLobbyData( Self, steamIDLobby, str__pchKey.Pointer, str__pchValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyDataCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataCount", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmaking_GetLobbyDataCount( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal int GetLobbyDataCount( SteamId steamIDLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyDataCount( Self, steamIDLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex( IntPtr self, SteamId steamIDLobby, int iLobbyData, IntPtr pchKey, int cchKeyBufferSize, IntPtr pchValue, int cchValueBufferSize );
		#endregion
		internal bool GetLobbyDataByIndex( SteamId steamIDLobby, int iLobbyData, out string pchKey, int cchKeyBufferSize, out string pchValue, int cchValueBufferSize )
		{
			using var mem__pchKey = new Utility.Memory( Utility.MemoryBufferSize );
			using var mem__pchValue = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex( Self, steamIDLobby, iLobbyData, mem__pchKey.Ptr, cchKeyBufferSize, mem__pchValue.Ptr, cchValueBufferSize );
			pchKey = Utility.MemoryToString( mem__pchKey );
			pchValue = Utility.MemoryToString( mem__pchValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_DeleteLobbyData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_DeleteLobbyData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_DeleteLobbyData( IntPtr self, SteamId steamIDLobby, IntPtr pchKey );
		#endregion
		internal bool DeleteLobbyData( SteamId steamIDLobby, string pchKey )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamMatchmaking_DeleteLobbyData( Self, steamIDLobby, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyMemberData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberData", CallingConvention = Platform.CC ) ]
		internal static extern Utf8StringPtr _SteamAPI_ISteamMatchmaking_GetLobbyMemberData( IntPtr self, SteamId steamIDLobby, SteamId steamIDUser, IntPtr pchKey );
		#endregion
		internal string GetLobbyMemberData( SteamId steamIDLobby, SteamId steamIDUser, string pchKey )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyMemberData( Self, steamIDLobby, steamIDUser, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyMemberData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberData", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_SetLobbyMemberData( IntPtr self, SteamId steamIDLobby, IntPtr pchKey, IntPtr pchValue );
		#endregion
		internal void SetLobbyMemberData( SteamId steamIDLobby, string pchKey, string pchValue )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			_SteamAPI_ISteamMatchmaking_SetLobbyMemberData( Self, steamIDLobby, str__pchKey.Pointer, str__pchValue.Pointer );
		}
		
		#region SteamAPI_ISteamMatchmaking_SendLobbyChatMsg
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SendLobbyChatMsg", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SendLobbyChatMsg( IntPtr self, SteamId steamIDLobby, IntPtr pvMsgBody, int cubMsgBody );
		#endregion
		internal bool SendLobbyChatMsg( SteamId steamIDLobby, IntPtr pvMsgBody, int cubMsgBody )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_SendLobbyChatMsg( Self, steamIDLobby, pvMsgBody, cubMsgBody );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyChatEntry
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyChatEntry", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmaking_GetLobbyChatEntry( IntPtr self, SteamId steamIDLobby, int iChatID, ref SteamId pSteamIDUser, IntPtr pvData, int cubData, ref EChatEntryType peChatEntryType );
		#endregion
		internal int GetLobbyChatEntry( SteamId steamIDLobby, int iChatID, ref SteamId pSteamIDUser, IntPtr pvData, int cubData, ref EChatEntryType peChatEntryType )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyChatEntry( Self, steamIDLobby, iChatID, ref pSteamIDUser, pvData, cubData, ref peChatEntryType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_RequestLobbyData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_RequestLobbyData( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal bool RequestLobbyData( SteamId steamIDLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_RequestLobbyData( Self, steamIDLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyGameServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyGameServer", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamMatchmaking_SetLobbyGameServer( IntPtr self, SteamId steamIDLobby, uint unGameServerIP, ushort unGameServerPort, SteamId steamIDGameServer );
		#endregion
		internal void SetLobbyGameServer( SteamId steamIDLobby, uint unGameServerIP, ushort unGameServerPort, SteamId steamIDGameServer )
		{
			_SteamAPI_ISteamMatchmaking_SetLobbyGameServer( Self, steamIDLobby, unGameServerIP, unGameServerPort, steamIDGameServer );
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyGameServer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyGameServer", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_GetLobbyGameServer( IntPtr self, SteamId steamIDLobby, ref uint punGameServerIP, ref ushort punGameServerPort, ref SteamId psteamIDGameServer );
		#endregion
		internal bool GetLobbyGameServer( SteamId steamIDLobby, ref uint punGameServerIP, ref ushort punGameServerPort, ref SteamId psteamIDGameServer )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyGameServer( Self, steamIDLobby, ref punGameServerIP, ref punGameServerPort, ref psteamIDGameServer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit( IntPtr self, SteamId steamIDLobby, int cMaxMembers );
		#endregion
		internal bool SetLobbyMemberLimit( SteamId steamIDLobby, int cMaxMembers )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit( Self, steamIDLobby, cMaxMembers );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit", CallingConvention = Platform.CC ) ]
		internal static extern int _SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal int GetLobbyMemberLimit( SteamId steamIDLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit( Self, steamIDLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyType
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyType", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SetLobbyType( IntPtr self, SteamId steamIDLobby, ELobbyType eLobbyType );
		#endregion
		internal bool SetLobbyType( SteamId steamIDLobby, ELobbyType eLobbyType )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_SetLobbyType( Self, steamIDLobby, eLobbyType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyJoinable
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyJoinable", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SetLobbyJoinable( IntPtr self, SteamId steamIDLobby, [ MarshalAs( UnmanagedType.U1 ) ] bool bLobbyJoinable );
		#endregion
		internal bool SetLobbyJoinable( SteamId steamIDLobby, [ MarshalAs( UnmanagedType.U1 ) ] bool bLobbyJoinable )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_SetLobbyJoinable( Self, steamIDLobby, bLobbyJoinable );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_GetLobbyOwner
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyOwner", CallingConvention = Platform.CC ) ]
		internal static extern SteamId _SteamAPI_ISteamMatchmaking_GetLobbyOwner( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal SteamId GetLobbyOwner( SteamId steamIDLobby )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_GetLobbyOwner( Self, steamIDLobby );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLobbyOwner
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyOwner", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SetLobbyOwner( IntPtr self, SteamId steamIDLobby, SteamId steamIDNewOwner );
		#endregion
		internal bool SetLobbyOwner( SteamId steamIDLobby, SteamId steamIDNewOwner )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_SetLobbyOwner( Self, steamIDLobby, steamIDNewOwner );
			return returnValue;
		}
		
		#region SteamAPI_ISteamMatchmaking_SetLinkedLobby
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLinkedLobby", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamMatchmaking_SetLinkedLobby( IntPtr self, SteamId steamIDLobby, SteamId steamIDLobbyDependent );
		#endregion
		internal bool SetLinkedLobby( SteamId steamIDLobby, SteamId steamIDLobbyDependent )
		{
			var returnValue = _SteamAPI_ISteamMatchmaking_SetLinkedLobby( Self, steamIDLobby, steamIDLobbyDependent );
			return returnValue;
		}
		
	}
}
