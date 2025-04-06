using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamFriends
	{
		public const string Version = "SteamFriends018";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamFriends_v018", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamFriends_v018();
		/// Construct use accessor to find interface
		public ISteamFriends( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamFriends_v018();
			}
		}
		public ISteamFriends( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamFriends_GetPersonaName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaName", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetPersonaName( IntPtr self );
		#endregion
		internal string GetPersonaName()
		{
			var returnValue = _SteamAPI_ISteamFriends_GetPersonaName( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetPersonaState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaState", CallingConvention = Platform.CC ) ]
		private static extern EPersonaState _SteamAPI_ISteamFriends_GetPersonaState( IntPtr self );
		#endregion
		internal EPersonaState GetPersonaState()
		{
			var returnValue = _SteamAPI_ISteamFriends_GetPersonaState( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendCount( IntPtr self, int iFriendFlags );
		#endregion
		internal int GetFriendCount( int iFriendFlags )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendCount( Self, iFriendFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendByIndex", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetFriendByIndex( IntPtr self, int iFriend, int iFriendFlags );
		#endregion
		internal SteamId GetFriendByIndex( int iFriend, int iFriendFlags )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendByIndex( Self, iFriend, iFriendFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendRelationship
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRelationship", CallingConvention = Platform.CC ) ]
		private static extern EFriendRelationship _SteamAPI_ISteamFriends_GetFriendRelationship( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal EFriendRelationship GetFriendRelationship( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendRelationship( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendPersonaState
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaState", CallingConvention = Platform.CC ) ]
		private static extern EPersonaState _SteamAPI_ISteamFriends_GetFriendPersonaState( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal EPersonaState GetFriendPersonaState( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendPersonaState( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendPersonaName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaName", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetFriendPersonaName( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal string GetFriendPersonaName( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendPersonaName( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendGamePlayed
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendGamePlayed", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_GetFriendGamePlayed( IntPtr self, SteamId steamIDFriend, ref FriendGameInfo_t pFriendGameInfo );
		#endregion
		internal bool GetFriendGamePlayed( SteamId steamIDFriend, ref FriendGameInfo_t pFriendGameInfo )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendGamePlayed( Self, steamIDFriend, ref pFriendGameInfo );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendPersonaNameHistory
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaNameHistory", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetFriendPersonaNameHistory( IntPtr self, SteamId steamIDFriend, int iPersonaName );
		#endregion
		internal string GetFriendPersonaNameHistory( SteamId steamIDFriend, int iPersonaName )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendPersonaNameHistory( Self, steamIDFriend, iPersonaName );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendSteamLevel
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendSteamLevel", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendSteamLevel( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal int GetFriendSteamLevel( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendSteamLevel( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetPlayerNickname
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetPlayerNickname", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetPlayerNickname( IntPtr self, SteamId steamIDPlayer );
		#endregion
		internal string GetPlayerNickname( SteamId steamIDPlayer )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetPlayerNickname( Self, steamIDPlayer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendsGroupCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendsGroupCount( IntPtr self );
		#endregion
		internal int GetFriendsGroupCount()
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendsGroupCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex", CallingConvention = Platform.CC ) ]
		private static extern FriendsGroupID_t _SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex( IntPtr self, int iFG );
		#endregion
		internal FriendsGroupID_t GetFriendsGroupIDByIndex( int iFG )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex( Self, iFG );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendsGroupName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupName", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetFriendsGroupName( IntPtr self, FriendsGroupID_t friendsGroupID );
		#endregion
		internal string GetFriendsGroupName( FriendsGroupID_t friendsGroupID )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendsGroupName( Self, friendsGroupID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendsGroupMembersCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendsGroupMembersCount( IntPtr self, FriendsGroupID_t friendsGroupID );
		#endregion
		internal int GetFriendsGroupMembersCount( FriendsGroupID_t friendsGroupID )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendsGroupMembersCount( Self, friendsGroupID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendsGroupMembersList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersList", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_GetFriendsGroupMembersList( IntPtr self, FriendsGroupID_t friendsGroupID, SteamId* pOutSteamIDMembers, int nMembersCount );
		#endregion
		internal void GetFriendsGroupMembersList( FriendsGroupID_t friendsGroupID, SteamId* pOutSteamIDMembers, int nMembersCount )
		{
			_SteamAPI_ISteamFriends_GetFriendsGroupMembersList( Self, friendsGroupID, pOutSteamIDMembers, nMembersCount );
		}
		
		#region SteamAPI_ISteamFriends_HasFriend
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_HasFriend", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_HasFriend( IntPtr self, SteamId steamIDFriend, int iFriendFlags );
		#endregion
		internal bool HasFriend( SteamId steamIDFriend, int iFriendFlags )
		{
			var returnValue = _SteamAPI_ISteamFriends_HasFriend( Self, steamIDFriend, iFriendFlags );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetClanCount( IntPtr self );
		#endregion
		internal int GetClanCount()
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanByIndex", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetClanByIndex( IntPtr self, int iClan );
		#endregion
		internal SteamId GetClanByIndex( int iClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanByIndex( Self, iClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanName
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanName", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetClanName( IntPtr self, SteamId steamIDClan );
		#endregion
		internal string GetClanName( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanName( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanTag
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanTag", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetClanTag( IntPtr self, SteamId steamIDClan );
		#endregion
		internal string GetClanTag( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanTag( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanActivityCounts
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanActivityCounts", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_GetClanActivityCounts( IntPtr self, SteamId steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting );
		#endregion
		internal bool GetClanActivityCounts( SteamId steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanActivityCounts( Self, steamIDClan, ref pnOnline, ref pnInGame, ref pnChatting );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_DownloadClanActivityCounts
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_DownloadClanActivityCounts", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_DownloadClanActivityCounts( IntPtr self, SteamId* psteamIDClans, int cClansToRequest );
		#endregion
		internal SteamAPICall_t DownloadClanActivityCounts( SteamId* psteamIDClans, int cClansToRequest )
		{
			var returnValue = _SteamAPI_ISteamFriends_DownloadClanActivityCounts( Self, psteamIDClans, cClansToRequest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendCountFromSource
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCountFromSource", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendCountFromSource( IntPtr self, SteamId steamIDSource );
		#endregion
		internal int GetFriendCountFromSource( SteamId steamIDSource )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendCountFromSource( Self, steamIDSource );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendFromSourceByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendFromSourceByIndex", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetFriendFromSourceByIndex( IntPtr self, SteamId steamIDSource, int iFriend );
		#endregion
		internal SteamId GetFriendFromSourceByIndex( SteamId steamIDSource, int iFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendFromSourceByIndex( Self, steamIDSource, iFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_IsUserInSource
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsUserInSource", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_IsUserInSource( IntPtr self, SteamId steamIDUser, SteamId steamIDSource );
		#endregion
		internal bool IsUserInSource( SteamId steamIDUser, SteamId steamIDSource )
		{
			var returnValue = _SteamAPI_ISteamFriends_IsUserInSource( Self, steamIDUser, steamIDSource );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_SetInGameVoiceSpeaking
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetInGameVoiceSpeaking", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_SetInGameVoiceSpeaking( IntPtr self, SteamId steamIDUser, [ MarshalAs( UnmanagedType.U1 ) ] bool bSpeaking );
		#endregion
		internal void SetInGameVoiceSpeaking( SteamId steamIDUser, [ MarshalAs( UnmanagedType.U1 ) ] bool bSpeaking )
		{
			_SteamAPI_ISteamFriends_SetInGameVoiceSpeaking( Self, steamIDUser, bSpeaking );
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlay
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlay", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlay( IntPtr self, IntPtr pchDialog );
		#endregion
		internal void ActivateGameOverlay( string pchDialog )
		{
			using var str__pchDialog = new Utf8StringToNative( pchDialog );
			_SteamAPI_ISteamFriends_ActivateGameOverlay( Self, str__pchDialog.Pointer );
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlayToUser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToUser", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlayToUser( IntPtr self, IntPtr pchDialog, SteamId steamID );
		#endregion
		internal void ActivateGameOverlayToUser( string pchDialog, SteamId steamID )
		{
			using var str__pchDialog = new Utf8StringToNative( pchDialog );
			_SteamAPI_ISteamFriends_ActivateGameOverlayToUser( Self, str__pchDialog.Pointer, steamID );
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage( IntPtr self, IntPtr pchURL, EActivateGameOverlayToWebPageMode eMode );
		#endregion
		internal void ActivateGameOverlayToWebPage( string pchURL, EActivateGameOverlayToWebPageMode eMode )
		{
			using var str__pchURL = new Utf8StringToNative( pchURL );
			_SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage( Self, str__pchURL.Pointer, eMode );
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlayToStore
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToStore", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlayToStore( IntPtr self, AppId_t nAppID, EOverlayToStoreFlag eFlag );
		#endregion
		internal void ActivateGameOverlayToStore( AppId_t nAppID, EOverlayToStoreFlag eFlag )
		{
			_SteamAPI_ISteamFriends_ActivateGameOverlayToStore( Self, nAppID, eFlag );
		}
		
		#region SteamAPI_ISteamFriends_SetPlayedWith
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetPlayedWith", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_SetPlayedWith( IntPtr self, SteamId steamIDUserPlayedWith );
		#endregion
		internal void SetPlayedWith( SteamId steamIDUserPlayedWith )
		{
			_SteamAPI_ISteamFriends_SetPlayedWith( Self, steamIDUserPlayedWith );
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal void ActivateGameOverlayInviteDialog( SteamId steamIDLobby )
		{
			_SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog( Self, steamIDLobby );
		}
		
		#region SteamAPI_ISteamFriends_GetSmallFriendAvatar
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetSmallFriendAvatar", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetSmallFriendAvatar( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal int GetSmallFriendAvatar( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetSmallFriendAvatar( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetMediumFriendAvatar
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetMediumFriendAvatar", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetMediumFriendAvatar( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal int GetMediumFriendAvatar( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetMediumFriendAvatar( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetLargeFriendAvatar
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetLargeFriendAvatar", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetLargeFriendAvatar( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal int GetLargeFriendAvatar( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetLargeFriendAvatar( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_RequestUserInformation
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestUserInformation", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_RequestUserInformation( IntPtr self, SteamId steamIDUser, [ MarshalAs( UnmanagedType.U1 ) ] bool bRequireNameOnly );
		#endregion
		internal bool RequestUserInformation( SteamId steamIDUser, [ MarshalAs( UnmanagedType.U1 ) ] bool bRequireNameOnly )
		{
			var returnValue = _SteamAPI_ISteamFriends_RequestUserInformation( Self, steamIDUser, bRequireNameOnly );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_RequestClanOfficerList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestClanOfficerList", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_RequestClanOfficerList( IntPtr self, SteamId steamIDClan );
		#endregion
		internal SteamAPICall_t RequestClanOfficerList( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_RequestClanOfficerList( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanOwner
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanOwner", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetClanOwner( IntPtr self, SteamId steamIDClan );
		#endregion
		internal SteamId GetClanOwner( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanOwner( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanOfficerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetClanOfficerCount( IntPtr self, SteamId steamIDClan );
		#endregion
		internal int GetClanOfficerCount( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanOfficerCount( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanOfficerByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerByIndex", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetClanOfficerByIndex( IntPtr self, SteamId steamIDClan, int iOfficer );
		#endregion
		internal SteamId GetClanOfficerByIndex( SteamId steamIDClan, int iOfficer )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanOfficerByIndex( Self, steamIDClan, iOfficer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_SetRichPresence
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetRichPresence", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_SetRichPresence( IntPtr self, IntPtr pchKey, IntPtr pchValue );
		#endregion
		internal bool SetRichPresence( string pchKey, string pchValue )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			using var str__pchValue = new Utf8StringToNative( pchValue );
			var returnValue = _SteamAPI_ISteamFriends_SetRichPresence( Self, str__pchKey.Pointer, str__pchValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_ClearRichPresence
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ClearRichPresence", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ClearRichPresence( IntPtr self );
		#endregion
		internal void ClearRichPresence()
		{
			_SteamAPI_ISteamFriends_ClearRichPresence( Self );
		}
		
		#region SteamAPI_ISteamFriends_GetFriendRichPresence
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresence", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetFriendRichPresence( IntPtr self, SteamId steamIDFriend, IntPtr pchKey );
		#endregion
		internal string GetFriendRichPresence( SteamId steamIDFriend, string pchKey )
		{
			using var str__pchKey = new Utf8StringToNative( pchKey );
			var returnValue = _SteamAPI_ISteamFriends_GetFriendRichPresence( Self, steamIDFriend, str__pchKey.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal int GetFriendRichPresenceKeyCount( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex( IntPtr self, SteamId steamIDFriend, int iKey );
		#endregion
		internal string GetFriendRichPresenceKeyByIndex( SteamId steamIDFriend, int iKey )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex( Self, steamIDFriend, iKey );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_RequestFriendRichPresence
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestFriendRichPresence", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_RequestFriendRichPresence( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal void RequestFriendRichPresence( SteamId steamIDFriend )
		{
			_SteamAPI_ISteamFriends_RequestFriendRichPresence( Self, steamIDFriend );
		}
		
		#region SteamAPI_ISteamFriends_InviteUserToGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_InviteUserToGame", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_InviteUserToGame( IntPtr self, SteamId steamIDFriend, IntPtr pchConnectString );
		#endregion
		internal bool InviteUserToGame( SteamId steamIDFriend, string pchConnectString )
		{
			using var str__pchConnectString = new Utf8StringToNative( pchConnectString );
			var returnValue = _SteamAPI_ISteamFriends_InviteUserToGame( Self, steamIDFriend, str__pchConnectString.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetCoplayFriendCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriendCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetCoplayFriendCount( IntPtr self );
		#endregion
		internal int GetCoplayFriendCount()
		{
			var returnValue = _SteamAPI_ISteamFriends_GetCoplayFriendCount( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetCoplayFriend
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriend", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetCoplayFriend( IntPtr self, int iCoplayFriend );
		#endregion
		internal SteamId GetCoplayFriend( int iCoplayFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetCoplayFriend( Self, iCoplayFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendCoplayTime
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayTime", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendCoplayTime( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal int GetFriendCoplayTime( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendCoplayTime( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendCoplayGame
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayGame", CallingConvention = Platform.CC ) ]
		private static extern AppId_t _SteamAPI_ISteamFriends_GetFriendCoplayGame( IntPtr self, SteamId steamIDFriend );
		#endregion
		internal AppId_t GetFriendCoplayGame( SteamId steamIDFriend )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendCoplayGame( Self, steamIDFriend );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_JoinClanChatRoom
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_JoinClanChatRoom", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_JoinClanChatRoom( IntPtr self, SteamId steamIDClan );
		#endregion
		internal SteamAPICall_t JoinClanChatRoom( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_JoinClanChatRoom( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_LeaveClanChatRoom
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_LeaveClanChatRoom", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_LeaveClanChatRoom( IntPtr self, SteamId steamIDClan );
		#endregion
		internal bool LeaveClanChatRoom( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_LeaveClanChatRoom( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanChatMemberCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMemberCount", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetClanChatMemberCount( IntPtr self, SteamId steamIDClan );
		#endregion
		internal int GetClanChatMemberCount( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanChatMemberCount( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetChatMemberByIndex
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetChatMemberByIndex", CallingConvention = Platform.CC ) ]
		private static extern SteamId _SteamAPI_ISteamFriends_GetChatMemberByIndex( IntPtr self, SteamId steamIDClan, int iUser );
		#endregion
		internal SteamId GetChatMemberByIndex( SteamId steamIDClan, int iUser )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetChatMemberByIndex( Self, steamIDClan, iUser );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_SendClanChatMessage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SendClanChatMessage", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_SendClanChatMessage( IntPtr self, SteamId steamIDClanChat, IntPtr pchText );
		#endregion
		internal bool SendClanChatMessage( SteamId steamIDClanChat, string pchText )
		{
			using var str__pchText = new Utf8StringToNative( pchText );
			var returnValue = _SteamAPI_ISteamFriends_SendClanChatMessage( Self, steamIDClanChat, str__pchText.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetClanChatMessage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMessage", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetClanChatMessage( IntPtr self, SteamId steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref EChatEntryType peChatEntryType, ref SteamId psteamidChatter );
		#endregion
		internal int GetClanChatMessage( SteamId steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref EChatEntryType peChatEntryType, ref SteamId psteamidChatter )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetClanChatMessage( Self, steamIDClanChat, iMessage, prgchText, cchTextMax, ref peChatEntryType, ref psteamidChatter );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_IsClanChatAdmin
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatAdmin", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_IsClanChatAdmin( IntPtr self, SteamId steamIDClanChat, SteamId steamIDUser );
		#endregion
		internal bool IsClanChatAdmin( SteamId steamIDClanChat, SteamId steamIDUser )
		{
			var returnValue = _SteamAPI_ISteamFriends_IsClanChatAdmin( Self, steamIDClanChat, steamIDUser );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam( IntPtr self, SteamId steamIDClanChat );
		#endregion
		internal bool IsClanChatWindowOpenInSteam( SteamId steamIDClanChat )
		{
			var returnValue = _SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam( Self, steamIDClanChat );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_OpenClanChatWindowInSteam
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_OpenClanChatWindowInSteam", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_OpenClanChatWindowInSteam( IntPtr self, SteamId steamIDClanChat );
		#endregion
		internal bool OpenClanChatWindowInSteam( SteamId steamIDClanChat )
		{
			var returnValue = _SteamAPI_ISteamFriends_OpenClanChatWindowInSteam( Self, steamIDClanChat );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_CloseClanChatWindowInSteam
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_CloseClanChatWindowInSteam", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_CloseClanChatWindowInSteam( IntPtr self, SteamId steamIDClanChat );
		#endregion
		internal bool CloseClanChatWindowInSteam( SteamId steamIDClanChat )
		{
			var returnValue = _SteamAPI_ISteamFriends_CloseClanChatWindowInSteam( Self, steamIDClanChat );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_SetListenForFriendsMessages
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetListenForFriendsMessages", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_SetListenForFriendsMessages( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bInterceptEnabled );
		#endregion
		internal bool SetListenForFriendsMessages( [ MarshalAs( UnmanagedType.U1 ) ] bool bInterceptEnabled )
		{
			var returnValue = _SteamAPI_ISteamFriends_SetListenForFriendsMessages( Self, bInterceptEnabled );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_ReplyToFriendMessage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ReplyToFriendMessage", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_ReplyToFriendMessage( IntPtr self, SteamId steamIDFriend, IntPtr pchMsgToSend );
		#endregion
		internal bool ReplyToFriendMessage( SteamId steamIDFriend, string pchMsgToSend )
		{
			using var str__pchMsgToSend = new Utf8StringToNative( pchMsgToSend );
			var returnValue = _SteamAPI_ISteamFriends_ReplyToFriendMessage( Self, steamIDFriend, str__pchMsgToSend.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFriendMessage
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendMessage", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetFriendMessage( IntPtr self, SteamId steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref EChatEntryType peChatEntryType );
		#endregion
		internal int GetFriendMessage( SteamId steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref EChatEntryType peChatEntryType )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFriendMessage( Self, steamIDFriend, iMessageID, pvData, cubData, ref peChatEntryType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetFollowerCount
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFollowerCount", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_GetFollowerCount( IntPtr self, SteamId steamID );
		#endregion
		internal SteamAPICall_t GetFollowerCount( SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetFollowerCount( Self, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_IsFollowing
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsFollowing", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_IsFollowing( IntPtr self, SteamId steamID );
		#endregion
		internal SteamAPICall_t IsFollowing( SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamFriends_IsFollowing( Self, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_EnumerateFollowingList
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_EnumerateFollowingList", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_EnumerateFollowingList( IntPtr self, uint unStartIndex );
		#endregion
		internal SteamAPICall_t EnumerateFollowingList( uint unStartIndex )
		{
			var returnValue = _SteamAPI_ISteamFriends_EnumerateFollowingList( Self, unStartIndex );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_IsClanPublic
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanPublic", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_IsClanPublic( IntPtr self, SteamId steamIDClan );
		#endregion
		internal bool IsClanPublic( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_IsClanPublic( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_IsClanOfficialGameGroup
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanOfficialGameGroup", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_IsClanOfficialGameGroup( IntPtr self, SteamId steamIDClan );
		#endregion
		internal bool IsClanOfficialGameGroup( SteamId steamIDClan )
		{
			var returnValue = _SteamAPI_ISteamFriends_IsClanOfficialGameGroup( Self, steamIDClan );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetNumChatsWithUnreadPriorityMessages
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetNumChatsWithUnreadPriorityMessages", CallingConvention = Platform.CC ) ]
		private static extern int _SteamAPI_ISteamFriends_GetNumChatsWithUnreadPriorityMessages( IntPtr self );
		#endregion
		internal int GetNumChatsWithUnreadPriorityMessages()
		{
			var returnValue = _SteamAPI_ISteamFriends_GetNumChatsWithUnreadPriorityMessages( Self );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlayRemotePlayTogetherInviteDialog
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayRemotePlayTogetherInviteDialog", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlayRemotePlayTogetherInviteDialog( IntPtr self, SteamId steamIDLobby );
		#endregion
		internal void ActivateGameOverlayRemotePlayTogetherInviteDialog( SteamId steamIDLobby )
		{
			_SteamAPI_ISteamFriends_ActivateGameOverlayRemotePlayTogetherInviteDialog( Self, steamIDLobby );
		}
		
		#region SteamAPI_ISteamFriends_RegisterProtocolInOverlayBrowser
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RegisterProtocolInOverlayBrowser", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_RegisterProtocolInOverlayBrowser( IntPtr self, IntPtr pchProtocol );
		#endregion
		internal bool RegisterProtocolInOverlayBrowser( string pchProtocol )
		{
			using var str__pchProtocol = new Utf8StringToNative( pchProtocol );
			var returnValue = _SteamAPI_ISteamFriends_RegisterProtocolInOverlayBrowser( Self, str__pchProtocol.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialogConnectString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialogConnectString", CallingConvention = Platform.CC ) ]
		private static extern void _SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialogConnectString( IntPtr self, IntPtr pchConnectString );
		#endregion
		internal void ActivateGameOverlayInviteDialogConnectString( string pchConnectString )
		{
			using var str__pchConnectString = new Utf8StringToNative( pchConnectString );
			_SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialogConnectString( Self, str__pchConnectString.Pointer );
		}
		
		#region SteamAPI_ISteamFriends_RequestEquippedProfileItems
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestEquippedProfileItems", CallingConvention = Platform.CC ) ]
		private static extern SteamAPICall_t _SteamAPI_ISteamFriends_RequestEquippedProfileItems( IntPtr self, SteamId steamID );
		#endregion
		internal SteamAPICall_t RequestEquippedProfileItems( SteamId steamID )
		{
			var returnValue = _SteamAPI_ISteamFriends_RequestEquippedProfileItems( Self, steamID );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_BHasEquippedProfileItem
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_BHasEquippedProfileItem", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		private static extern bool _SteamAPI_ISteamFriends_BHasEquippedProfileItem( IntPtr self, SteamId steamID, ECommunityProfileItemType itemType );
		#endregion
		internal bool BHasEquippedProfileItem( SteamId steamID, ECommunityProfileItemType itemType )
		{
			var returnValue = _SteamAPI_ISteamFriends_BHasEquippedProfileItem( Self, steamID, itemType );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetProfileItemPropertyString
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetProfileItemPropertyString", CallingConvention = Platform.CC ) ]
		private static extern Utf8StringPtr _SteamAPI_ISteamFriends_GetProfileItemPropertyString( IntPtr self, SteamId steamID, ECommunityProfileItemType itemType, ECommunityProfileItemProperty prop );
		#endregion
		internal string GetProfileItemPropertyString( SteamId steamID, ECommunityProfileItemType itemType, ECommunityProfileItemProperty prop )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetProfileItemPropertyString( Self, steamID, itemType, prop );
			return returnValue;
		}
		
		#region SteamAPI_ISteamFriends_GetProfileItemPropertyUint
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetProfileItemPropertyUint", CallingConvention = Platform.CC ) ]
		private static extern uint _SteamAPI_ISteamFriends_GetProfileItemPropertyUint( IntPtr self, SteamId steamID, ECommunityProfileItemType itemType, ECommunityProfileItemProperty prop );
		#endregion
		internal uint GetProfileItemPropertyUint( SteamId steamID, ECommunityProfileItemType itemType, ECommunityProfileItemProperty prop )
		{
			var returnValue = _SteamAPI_ISteamFriends_GetProfileItemPropertyUint( Self, steamID, itemType, prop );
			return returnValue;
		}
		
	}
}
