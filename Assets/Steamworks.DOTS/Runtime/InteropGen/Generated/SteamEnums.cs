using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	///
	/// ESteamIPType
	///
	public enum ESteamIPType : int
	{
		ESteamIPType4 = 0,
		ESteamIPType6 = 1,
	}
	
	///
	/// EUniverse
	///
	public enum EUniverse : int
	{
		Invalid = 0,
		Public = 1,
		Beta = 2,
		Internal = 3,
		Dev = 4,
		Max = 5,
	}
	
	///
	/// EResult
	///
	public enum EResult : int
	{
		k_EResultNone = 0,
		k_EResultOK = 1,
		k_EResultFail = 2,
		k_EResultNoConnection = 3,
		k_EResultInvalidPassword = 5,
		k_EResultLoggedInElsewhere = 6,
		k_EResultInvalidProtocolVer = 7,
		k_EResultInvalidParam = 8,
		k_EResultFileNotFound = 9,
		k_EResultBusy = 10,
		k_EResultInvalidState = 11,
		k_EResultInvalidName = 12,
		k_EResultInvalidEmail = 13,
		k_EResultDuplicateName = 14,
		k_EResultAccessDenied = 15,
		k_EResultTimeout = 16,
		k_EResultBanned = 17,
		k_EResultAccountNotFound = 18,
		k_EResultInvalidSteamID = 19,
		k_EResultServiceUnavailable = 20,
		k_EResultNotLoggedOn = 21,
		k_EResultPending = 22,
		k_EResultEncryptionFailure = 23,
		k_EResultInsufficientPrivilege = 24,
		k_EResultLimitExceeded = 25,
		k_EResultRevoked = 26,
		k_EResultExpired = 27,
		k_EResultAlreadyRedeemed = 28,
		k_EResultDuplicateRequest = 29,
		k_EResultAlreadyOwned = 30,
		k_EResultIPNotFound = 31,
		k_EResultPersistFailed = 32,
		k_EResultLockingFailed = 33,
		k_EResultLogonSessionReplaced = 34,
		k_EResultConnectFailed = 35,
		k_EResultHandshakeFailed = 36,
		k_EResultIOFailure = 37,
		k_EResultRemoteDisconnect = 38,
		k_EResultShoppingCartNotFound = 39,
		k_EResultBlocked = 40,
		k_EResultIgnored = 41,
		k_EResultNoMatch = 42,
		k_EResultAccountDisabled = 43,
		k_EResultServiceReadOnly = 44,
		k_EResultAccountNotFeatured = 45,
		k_EResultAdministratorOK = 46,
		k_EResultContentVersion = 47,
		k_EResultTryAnotherCM = 48,
		k_EResultPasswordRequiredToKickSession = 49,
		k_EResultAlreadyLoggedInElsewhere = 50,
		k_EResultSuspended = 51,
		k_EResultCancelled = 52,
		k_EResultDataCorruption = 53,
		k_EResultDiskFull = 54,
		k_EResultRemoteCallFailed = 55,
		k_EResultPasswordUnset = 56,
		k_EResultExternalAccountUnlinked = 57,
		k_EResultPSNTicketInvalid = 58,
		k_EResultExternalAccountAlreadyLinked = 59,
		k_EResultRemoteFileConflict = 60,
		k_EResultIllegalPassword = 61,
		k_EResultSameAsPreviousValue = 62,
		k_EResultAccountLogonDenied = 63,
		k_EResultCannotUseOldPassword = 64,
		k_EResultInvalidLoginAuthCode = 65,
		k_EResultAccountLogonDeniedNoMail = 66,
		k_EResultHardwareNotCapableOfIPT = 67,
		k_EResultIPTInitError = 68,
		k_EResultParentalControlRestricted = 69,
		k_EResultFacebookQueryError = 70,
		k_EResultExpiredLoginAuthCode = 71,
		k_EResultIPLoginRestrictionFailed = 72,
		k_EResultAccountLockedDown = 73,
		k_EResultAccountLogonDeniedVerifiedEmailRequired = 74,
		k_EResultNoMatchingURL = 75,
		k_EResultBadResponse = 76,
		k_EResultRequirePasswordReEntry = 77,
		k_EResultValueOutOfRange = 78,
		k_EResultUnexpectedError = 79,
		k_EResultDisabled = 80,
		k_EResultInvalidCEGSubmission = 81,
		k_EResultRestrictedDevice = 82,
		k_EResultRegionLocked = 83,
		k_EResultRateLimitExceeded = 84,
		k_EResultAccountLoginDeniedNeedTwoFactor = 85,
		k_EResultItemDeleted = 86,
		k_EResultAccountLoginDeniedThrottle = 87,
		k_EResultTwoFactorCodeMismatch = 88,
		k_EResultTwoFactorActivationCodeMismatch = 89,
		k_EResultAccountAssociatedToMultiplePartners = 90,
		k_EResultNotModified = 91,
		k_EResultNoMobileDevice = 92,
		k_EResultTimeNotSynced = 93,
		k_EResultSmsCodeFailed = 94,
		k_EResultAccountLimitExceeded = 95,
		k_EResultAccountActivityLimitExceeded = 96,
		k_EResultPhoneActivityLimitExceeded = 97,
		k_EResultRefundToWallet = 98,
		k_EResultEmailSendFailure = 99,
		k_EResultNotSettled = 100,
		k_EResultNeedCaptcha = 101,
		k_EResultGSLTDenied = 102,
		k_EResultGSOwnerDenied = 103,
		k_EResultInvalidItemType = 104,
		k_EResultIPBanned = 105,
		k_EResultGSLTExpired = 106,
		k_EResultInsufficientFunds = 107,
		k_EResultTooManyPending = 108,
		k_EResultNoSiteLicensesFound = 109,
		k_EResultWGNetworkSendExceeded = 110,
		k_EResultAccountNotFriends = 111,
		k_EResultLimitedUserAccount = 112,
		k_EResultCantRemoveItem = 113,
		k_EResultAccountDeleted = 114,
		k_EResultExistingUserCancelledLicense = 115,
		k_EResultCommunityCooldown = 116,
		k_EResultNoLauncherSpecified = 117,
		k_EResultMustAgreeToSSA = 118,
		k_EResultLauncherMigrated = 119,
		k_EResultSteamRealmMismatch = 120,
		k_EResultInvalidSignature = 121,
		k_EResultParseFailure = 122,
		k_EResultNoVerifiedPhone = 123,
		k_EResultInsufficientBattery = 124,
		k_EResultChargerRequired = 125,
		k_EResultCachedCredentialInvalid = 126,
		K_EResultPhoneNumberIsVOIP = 127,
		k_EResultNotSupported = 128,
		k_EResultFamilySizeLimitExceeded = 129,
		k_EResultOfflineAppCacheInvalid = 130,
	}
	
	///
	/// EVoiceResult
	///
	public enum EVoiceResult : int
	{
		OK = 0,
		NotInitialized = 1,
		NotRecording = 2,
		NoData = 3,
		BufferTooSmall = 4,
		DataCorrupted = 5,
		Restricted = 6,
		UnsupportedCodec = 7,
		ReceiverOutOfDate = 8,
		ReceiverDidNotAnswer = 9,
	}
	
	///
	/// EDenyReason
	///
	public enum EDenyReason : int
	{
		Invalid = 0,
		InvalidVersion = 1,
		Generic = 2,
		NotLoggedOn = 3,
		NoLicense = 4,
		Cheater = 5,
		LoggedInElseWhere = 6,
		UnknownText = 7,
		IncompatibleAnticheat = 8,
		MemoryCorruption = 9,
		IncompatibleSoftware = 10,
		SteamConnectionLost = 11,
		SteamConnectionError = 12,
		SteamResponseTimedOut = 13,
		SteamValidationStalled = 14,
		SteamOwnerLeftGuestUser = 15,
	}
	
	///
	/// EBeginAuthSessionResult
	///
	public enum EBeginAuthSessionResult : int
	{
		OK = 0,
		InvalidTicket = 1,
		DuplicateRequest = 2,
		InvalidVersion = 3,
		GameMismatch = 4,
		ExpiredTicket = 5,
	}
	
	///
	/// EAuthSessionResponse
	///
	public enum EAuthSessionResponse : int
	{
		OK = 0,
		UserNotConnectedToSteam = 1,
		NoLicenseOrExpired = 2,
		VACBanned = 3,
		LoggedInElseWhere = 4,
		VACCheckTimedOut = 5,
		AuthTicketCanceled = 6,
		AuthTicketInvalidAlreadyUsed = 7,
		AuthTicketInvalid = 8,
		PublisherIssuedBan = 9,
		AuthTicketNetworkIdentityFailure = 10,
	}
	
	///
	/// EUserHasLicenseForAppResult
	///
	public enum EUserHasLicenseForAppResult : int
	{
		HasLicense = 0,
		DoesNotHaveLicense = 1,
		NoAuth = 2,
	}
	
	///
	/// EAccountType
	///
	public enum EAccountType : int
	{
		Invalid = 0,
		Individual = 1,
		Multiseat = 2,
		GameServer = 3,
		AnonGameServer = 4,
		Pending = 5,
		ContentServer = 6,
		Clan = 7,
		Chat = 8,
		ConsoleUser = 9,
		AnonUser = 10,
		Max = 11,
	}
	
	///
	/// EChatEntryType
	///
	public enum EChatEntryType : int
	{
		Invalid = 0,
		ChatMsg = 1,
		Typing = 2,
		InviteGame = 3,
		Emote = 4,
		LeftConversation = 6,
		Entered = 7,
		WasKicked = 8,
		WasBanned = 9,
		Disconnected = 10,
		HistoricalChat = 11,
		LinkBlocked = 14,
	}
	
	///
	/// EChatRoomEnterResponse
	///
	public enum EChatRoomEnterResponse : int
	{
		Success = 1,
		DoesntExist = 2,
		NotAllowed = 3,
		Full = 4,
		Error = 5,
		Banned = 6,
		Limited = 7,
		ClanDisabled = 8,
		CommunityBan = 9,
		MemberBlockedYou = 10,
		YouBlockedMember = 11,
		RatelimitExceeded = 15,
	}
	
	///
	/// EChatSteamIDInstanceFlags
	///
	public enum EChatSteamIDInstanceFlags : int
	{
		AccountInstanceMask = 4095,
		InstanceFlagClan = 524288,
		InstanceFlagLobby = 262144,
		InstanceFlagMMSLobby = 131072,
	}
	
	///
	/// ENotificationPosition
	///
	public enum ENotificationPosition : int
	{
		Invalid = -1,
		TopLeft = 0,
		TopRight = 1,
		BottomLeft = 2,
		BottomRight = 3,
	}
	
	///
	/// EBroadcastUploadResult
	///
	public enum EBroadcastUploadResult : int
	{
		None = 0,
		OK = 1,
		InitFailed = 2,
		FrameFailed = 3,
		Timeout = 4,
		BandwidthExceeded = 5,
		LowFPS = 6,
		MissingKeyFrames = 7,
		NoConnection = 8,
		RelayFailed = 9,
		SettingsChanged = 10,
		MissingAudio = 11,
		TooFarBehind = 12,
		TranscodeBehind = 13,
		NotAllowedToPlay = 14,
		Busy = 15,
		Banned = 16,
		AlreadyActive = 17,
		ForcedOff = 18,
		AudioBehind = 19,
		Shutdown = 20,
		Disconnect = 21,
		VideoInitFailed = 22,
		AudioInitFailed = 23,
	}
	
	///
	/// EMarketNotAllowedReasonFlags
	///
	public enum EMarketNotAllowedReasonFlags : int
	{
		None = 0,
		TemporaryFailure = 1,
		AccountDisabled = 2,
		AccountLockedDown = 4,
		AccountLimited = 8,
		TradeBanned = 16,
		AccountNotTrusted = 32,
		SteamGuardNotEnabled = 64,
		SteamGuardOnlyRecentlyEnabled = 128,
		RecentPasswordReset = 256,
		NewPaymentMethod = 512,
		InvalidCookie = 1024,
		UsingNewDevice = 2048,
		RecentSelfRefund = 4096,
		NewPaymentMethodCannotBeVerified = 8192,
		NoRecentPurchases = 16384,
		AcceptedWalletGift = 32768,
	}
	
	///
	/// EDurationControlProgress
	///
	public enum EDurationControlProgress : int
	{
		Progress_Full = 0,
		Progress_Half = 1,
		Progress_None = 2,
		ExitSoon_3h = 3,
		ExitSoon_5h = 4,
		ExitSoon_Night = 5,
	}
	
	///
	/// EDurationControlNotification
	///
	public enum EDurationControlNotification : int
	{
		None = 0,
		EDurationControlNotification1Hour = 1,
		EDurationControlNotification3Hours = 2,
		HalfProgress = 3,
		NoProgress = 4,
		ExitSoon_3h = 5,
		ExitSoon_5h = 6,
		ExitSoon_Night = 7,
	}
	
	///
	/// EDurationControlOnlineState
	///
	public enum EDurationControlOnlineState : int
	{
		Invalid = 0,
		Offline = 1,
		Online = 2,
		OnlineHighPri = 3,
	}
	
	///
	/// EBetaBranchFlags
	///
	public enum EBetaBranchFlags : int
	{
		None = 0,
		Default = 1,
		Available = 2,
		Private = 4,
		Selected = 8,
		Installed = 16,
	}
	
	///
	/// EGameSearchErrorCode_t
	///
	public enum EGameSearchErrorCode_t : int
	{
		OK = 1,
		Failed_Search_Already_In_Progress = 2,
		Failed_No_Search_In_Progress = 3,
		Failed_Not_Lobby_Leader = 4,
		Failed_No_Host_Available = 5,
		Failed_Search_Params_Invalid = 6,
		Failed_Offline = 7,
		Failed_NotAuthorized = 8,
		Failed_Unknown_Error = 9,
	}
	
	///
	/// EPlayerResult_t
	///
	public enum EPlayerResult_t : int
	{
		FailedToConnect = 1,
		Abandoned = 2,
		Kicked = 3,
		Incomplete = 4,
		Completed = 5,
	}
	
	///
	/// ESteamIPv6ConnectivityProtocol
	///
	public enum ESteamIPv6ConnectivityProtocol : int
	{
		Invalid = 0,
		HTTP = 1,
		UDP = 2,
	}
	
	///
	/// ESteamIPv6ConnectivityState
	///
	public enum ESteamIPv6ConnectivityState : int
	{
		Unknown = 0,
		Good = 1,
		Bad = 2,
	}
	
	///
	/// EFriendRelationship
	///
	public enum EFriendRelationship : int
	{
		None = 0,
		Blocked = 1,
		RequestRecipient = 2,
		Friend = 3,
		RequestInitiator = 4,
		Ignored = 5,
		IgnoredFriend = 6,
		Suggested_DEPRECATED = 7,
		Max = 8,
	}
	
	///
	/// EPersonaState
	///
	public enum EPersonaState : int
	{
		Offline = 0,
		Online = 1,
		Busy = 2,
		Away = 3,
		Snooze = 4,
		LookingToTrade = 5,
		LookingToPlay = 6,
		Invisible = 7,
		Max = 8,
	}
	
	///
	/// EFriendFlags
	///
	public enum EFriendFlags : int
	{
		None = 0,
		Blocked = 1,
		FriendshipRequested = 2,
		Immediate = 4,
		ClanMember = 8,
		OnGameServer = 16,
		RequestingFriendship = 128,
		RequestingInfo = 256,
		Ignored = 512,
		IgnoredFriend = 1024,
		ChatMember = 4096,
		All = 65535,
	}
	
	///
	/// EOverlayToStoreFlag
	///
	public enum EOverlayToStoreFlag : int
	{
		None = 0,
		AddToCart = 1,
		AddToCartAndShow = 2,
	}
	
	///
	/// EActivateGameOverlayToWebPageMode
	///
	public enum EActivateGameOverlayToWebPageMode : int
	{
		Default = 0,
		Modal = 1,
	}
	
	///
	/// ECommunityProfileItemType
	///
	public enum ECommunityProfileItemType : int
	{
		AnimatedAvatar = 0,
		AvatarFrame = 1,
		ProfileModifier = 2,
		ProfileBackground = 3,
		MiniProfileBackground = 4,
	}
	
	///
	/// ECommunityProfileItemProperty
	///
	public enum ECommunityProfileItemProperty : int
	{
		ImageSmall = 0,
		ImageLarge = 1,
		InternalName = 2,
		Title = 3,
		Description = 4,
		AppID = 5,
		TypeID = 6,
		Class = 7,
		MovieWebM = 8,
		MovieMP4 = 9,
		MovieWebMSmall = 10,
		MovieMP4Small = 11,
	}
	
	///
	/// EPersonaChange
	///
	public enum EPersonaChange : int
	{
		Name = 1,
		Status = 2,
		ComeOnline = 4,
		GoneOffline = 8,
		GamePlayed = 16,
		GameServer = 32,
		Avatar = 64,
		JoinedSource = 128,
		LeftSource = 256,
		RelationshipChanged = 512,
		NameFirstSet = 1024,
		Broadcast = 2048,
		Nickname = 4096,
		SteamLevel = 8192,
		RichPresence = 16384,
	}
	
	///
	/// ESteamAPICallFailure
	///
	public enum ESteamAPICallFailure : int
	{
		None = -1,
		SteamGone = 0,
		NetworkFailure = 1,
		InvalidHandle = 2,
		MismatchedCallback = 3,
	}
	
	///
	/// EGamepadTextInputMode
	///
	public enum EGamepadTextInputMode : int
	{
		Normal = 0,
		Password = 1,
	}
	
	///
	/// EGamepadTextInputLineMode
	///
	public enum EGamepadTextInputLineMode : int
	{
		SingleLine = 0,
		MultipleLines = 1,
	}
	
	///
	/// EFloatingGamepadTextInputMode
	///
	public enum EFloatingGamepadTextInputMode : int
	{
		SingleLine = 0,
		MultipleLines = 1,
		Email = 2,
		Numeric = 3,
	}
	
	///
	/// ETextFilteringContext
	///
	public enum ETextFilteringContext : int
	{
		Unknown = 0,
		GameContent = 1,
		Chat = 2,
		Name = 3,
	}
	
	///
	/// ECheckFileSignature
	///
	public enum ECheckFileSignature : int
	{
		InvalidSignature = 0,
		ValidSignature = 1,
		FileNotFound = 2,
		NoSignaturesFoundForThisApp = 3,
		NoSignaturesFoundForThisFile = 4,
	}
	
	///
	/// EMatchMakingServerResponse
	///
	public enum EMatchMakingServerResponse : int
	{
		ServerResponded = 0,
		ServerFailedToRespond = 1,
		NoServersListedOnMasterServer = 2,
	}
	
	///
	/// ELobbyType
	///
	public enum ELobbyType : int
	{
		Private = 0,
		FriendsOnly = 1,
		Public = 2,
		Invisible = 3,
		PrivateUnique = 4,
	}
	
	///
	/// ELobbyComparison
	///
	public enum ELobbyComparison : int
	{
		EqualToOrLessThan = -2,
		LessThan = -1,
		Equal = 0,
		GreaterThan = 1,
		EqualToOrGreaterThan = 2,
		NotEqual = 3,
	}
	
	///
	/// ELobbyDistanceFilter
	///
	public enum ELobbyDistanceFilter : int
	{
		Close = 0,
		Default = 1,
		Far = 2,
		Worldwide = 3,
	}
	
	///
	/// EChatMemberStateChange
	///
	public enum EChatMemberStateChange : int
	{
		Entered = 1,
		Left = 2,
		Disconnected = 4,
		Kicked = 8,
		Banned = 16,
	}
	
	///
	/// ESteamPartyBeaconLocationType
	///
	public enum ESteamPartyBeaconLocationType : int
	{
		Invalid = 0,
		ChatGroup = 1,
		Max = 2,
	}
	
	///
	/// ESteamPartyBeaconLocationData
	///
	public enum ESteamPartyBeaconLocationData : int
	{
		Invalid = 0,
		Name = 1,
		IconURLSmall = 2,
		IconURLMedium = 3,
		IconURLLarge = 4,
	}
	
	///
	/// ERemoteStoragePlatform
	///
	public enum ERemoteStoragePlatform : int
	{
		None = 0,
		Windows = 1,
		OSX = 2,
		PS3 = 4,
		Linux = 8,
		Switch = 16,
		Android = 32,
		IOS = 64,
		All = -1,
	}
	
	///
	/// ERemoteStoragePublishedFileVisibility
	///
	public enum ERemoteStoragePublishedFileVisibility : int
	{
		Public = 0,
		FriendsOnly = 1,
		Private = 2,
		Unlisted = 3,
	}
	
	///
	/// EWorkshopFileType
	///
	public enum EWorkshopFileType : int
	{
		First = 0,
		Community = 0,
		Microtransaction = 1,
		Collection = 2,
		Art = 3,
		Video = 4,
		Screenshot = 5,
		Game = 6,
		Software = 7,
		Concept = 8,
		WebGuide = 9,
		IntegratedGuide = 10,
		Merch = 11,
		ControllerBinding = 12,
		SteamworksAccessInvite = 13,
		SteamVideo = 14,
		GameManagedItem = 15,
		Clip = 16,
		Max = 17,
	}
	
	///
	/// EWorkshopVote
	///
	public enum EWorkshopVote : int
	{
		Unvoted = 0,
		For = 1,
		Against = 2,
		Later = 3,
	}
	
	///
	/// EWorkshopFileAction
	///
	public enum EWorkshopFileAction : int
	{
		Played = 0,
		Completed = 1,
	}
	
	///
	/// EWorkshopEnumerationType
	///
	public enum EWorkshopEnumerationType : int
	{
		RankedByVote = 0,
		Recent = 1,
		Trending = 2,
		FavoritesOfFriends = 3,
		VotedByFriends = 4,
		ContentByFriends = 5,
		RecentFromFollowedUsers = 6,
	}
	
	///
	/// EWorkshopVideoProvider
	///
	public enum EWorkshopVideoProvider : int
	{
		None = 0,
		Youtube = 1,
	}
	
	///
	/// EUGCReadAction
	///
	public enum EUGCReadAction : int
	{
		ontinueReadingUntilFinished = 0,
		ontinueReading = 1,
		lose = 2,
	}
	
	///
	/// ERemoteStorageLocalFileChange
	///
	public enum ERemoteStorageLocalFileChange : int
	{
		Invalid = 0,
		FileUpdated = 1,
		FileDeleted = 2,
	}
	
	///
	/// ERemoteStorageFilePathType
	///
	public enum ERemoteStorageFilePathType : int
	{
		Invalid = 0,
		Absolute = 1,
		APIFilename = 2,
	}
	
	///
	/// ELeaderboardDataRequest
	///
	public enum ELeaderboardDataRequest : int
	{
		Global = 0,
		GlobalAroundUser = 1,
		Friends = 2,
		Users = 3,
	}
	
	///
	/// ELeaderboardSortMethod
	///
	public enum ELeaderboardSortMethod : int
	{
		None = 0,
		Ascending = 1,
		Descending = 2,
	}
	
	///
	/// ELeaderboardDisplayType
	///
	public enum ELeaderboardDisplayType : int
	{
		None = 0,
		Numeric = 1,
		TimeSeconds = 2,
		TimeMilliSeconds = 3,
	}
	
	///
	/// ELeaderboardUploadScoreMethod
	///
	public enum ELeaderboardUploadScoreMethod : int
	{
		None = 0,
		KeepBest = 1,
		ForceUpdate = 2,
	}
	
	///
	/// EP2PSessionError
	///
	public enum EP2PSessionError : int
	{
		None = 0,
		NoRightsToApp = 2,
		Timeout = 4,
		NotRunningApp_DELETED = 1,
		DestinationNotLoggedIn_DELETED = 3,
		Max = 5,
	}
	
	///
	/// EP2PSend
	///
	public enum EP2PSend : int
	{
		Unreliable = 0,
		UnreliableNoDelay = 1,
		Reliable = 2,
		ReliableWithBuffering = 3,
	}
	
	///
	/// ESNetSocketState
	///
	public enum ESNetSocketState : int
	{
		Invalid = 0,
		Connected = 1,
		Initiated = 10,
		LocalCandidatesFound = 11,
		ReceivedRemoteCandidates = 12,
		ChallengeHandshake = 15,
		Disconnecting = 21,
		LocalDisconnect = 22,
		TimeoutDuringConnect = 23,
		RemoteEndDisconnected = 24,
		ConnectionBroken = 25,
	}
	
	///
	/// ESNetSocketConnectionType
	///
	public enum ESNetSocketConnectionType : int
	{
		NotConnected = 0,
		UDP = 1,
		UDPRelay = 2,
	}
	
	///
	/// EVRScreenshotType
	///
	public enum EVRScreenshotType : int
	{
		None = 0,
		Mono = 1,
		Stereo = 2,
		MonoCubemap = 3,
		MonoPanorama = 4,
		StereoPanorama = 5,
	}
	
	///
	/// AudioPlayback_Status
	///
	public enum AudioPlayback_Status : int
	{
		Undefined = 0,
		Playing = 1,
		Paused = 2,
		Idle = 3,
	}
	
	///
	/// EHTTPMethod
	///
	public enum EHTTPMethod : int
	{
		Invalid = 0,
		GET = 1,
		HEAD = 2,
		POST = 3,
		PUT = 4,
		DELETE = 5,
		OPTIONS = 6,
		PATCH = 7,
	}
	
	///
	/// EHTTPStatusCode
	///
	public enum EHTTPStatusCode : int
	{
		Invalid = 0,
		EHTTPStatusCode100Continue = 100,
		EHTTPStatusCode101SwitchingProtocols = 101,
		EHTTPStatusCode200OK = 200,
		EHTTPStatusCode201Created = 201,
		EHTTPStatusCode202Accepted = 202,
		EHTTPStatusCode203NonAuthoritative = 203,
		EHTTPStatusCode204NoContent = 204,
		EHTTPStatusCode205ResetContent = 205,
		EHTTPStatusCode206PartialContent = 206,
		EHTTPStatusCode300MultipleChoices = 300,
		EHTTPStatusCode301MovedPermanently = 301,
		EHTTPStatusCode302Found = 302,
		EHTTPStatusCode303SeeOther = 303,
		EHTTPStatusCode304NotModified = 304,
		EHTTPStatusCode305UseProxy = 305,
		EHTTPStatusCode307TemporaryRedirect = 307,
		EHTTPStatusCode308PermanentRedirect = 308,
		EHTTPStatusCode400BadRequest = 400,
		EHTTPStatusCode401Unauthorized = 401,
		EHTTPStatusCode402PaymentRequired = 402,
		EHTTPStatusCode403Forbidden = 403,
		EHTTPStatusCode404NotFound = 404,
		EHTTPStatusCode405MethodNotAllowed = 405,
		EHTTPStatusCode406NotAcceptable = 406,
		EHTTPStatusCode407ProxyAuthRequired = 407,
		EHTTPStatusCode408RequestTimeout = 408,
		EHTTPStatusCode409Conflict = 409,
		EHTTPStatusCode410Gone = 410,
		EHTTPStatusCode411LengthRequired = 411,
		EHTTPStatusCode412PreconditionFailed = 412,
		EHTTPStatusCode413RequestEntityTooLarge = 413,
		EHTTPStatusCode414RequestURITooLong = 414,
		EHTTPStatusCode415UnsupportedMediaType = 415,
		EHTTPStatusCode416RequestedRangeNotSatisfiable = 416,
		EHTTPStatusCode417ExpectationFailed = 417,
		EHTTPStatusCode4xxUnknown = 418,
		EHTTPStatusCode429TooManyRequests = 429,
		EHTTPStatusCode444ConnectionClosed = 444,
		EHTTPStatusCode500InternalServerError = 500,
		EHTTPStatusCode501NotImplemented = 501,
		EHTTPStatusCode502BadGateway = 502,
		EHTTPStatusCode503ServiceUnavailable = 503,
		EHTTPStatusCode504GatewayTimeout = 504,
		EHTTPStatusCode505HTTPVersionNotSupported = 505,
		EHTTPStatusCode5xxUnknown = 599,
	}
	
	///
	/// EInputSourceMode
	///
	public enum EInputSourceMode : int
	{
		None = 0,
		Dpad = 1,
		Buttons = 2,
		FourButtons = 3,
		AbsoluteMouse = 4,
		RelativeMouse = 5,
		JoystickMove = 6,
		JoystickMouse = 7,
		JoystickCamera = 8,
		ScrollWheel = 9,
		Trigger = 10,
		TouchMenu = 11,
		MouseJoystick = 12,
		MouseRegion = 13,
		RadialMenu = 14,
		SingleButton = 15,
		Switches = 16,
	}
	
	///
	/// EInputActionOrigin
	///
	public enum EInputActionOrigin : int
	{
		None = 0,
		SteamController_A = 1,
		SteamController_B = 2,
		SteamController_X = 3,
		SteamController_Y = 4,
		SteamController_LeftBumper = 5,
		SteamController_RightBumper = 6,
		SteamController_LeftGrip = 7,
		SteamController_RightGrip = 8,
		SteamController_Start = 9,
		SteamController_Back = 10,
		SteamController_LeftPad_Touch = 11,
		SteamController_LeftPad_Swipe = 12,
		SteamController_LeftPad_Click = 13,
		SteamController_LeftPad_DPadNorth = 14,
		SteamController_LeftPad_DPadSouth = 15,
		SteamController_LeftPad_DPadWest = 16,
		SteamController_LeftPad_DPadEast = 17,
		SteamController_RightPad_Touch = 18,
		SteamController_RightPad_Swipe = 19,
		SteamController_RightPad_Click = 20,
		SteamController_RightPad_DPadNorth = 21,
		SteamController_RightPad_DPadSouth = 22,
		SteamController_RightPad_DPadWest = 23,
		SteamController_RightPad_DPadEast = 24,
		SteamController_LeftTrigger_Pull = 25,
		SteamController_LeftTrigger_Click = 26,
		SteamController_RightTrigger_Pull = 27,
		SteamController_RightTrigger_Click = 28,
		SteamController_LeftStick_Move = 29,
		SteamController_LeftStick_Click = 30,
		SteamController_LeftStick_DPadNorth = 31,
		SteamController_LeftStick_DPadSouth = 32,
		SteamController_LeftStick_DPadWest = 33,
		SteamController_LeftStick_DPadEast = 34,
		SteamController_Gyro_Move = 35,
		SteamController_Gyro_Pitch = 36,
		SteamController_Gyro_Yaw = 37,
		SteamController_Gyro_Roll = 38,
		SteamController_Reserved0 = 39,
		SteamController_Reserved1 = 40,
		SteamController_Reserved2 = 41,
		SteamController_Reserved3 = 42,
		SteamController_Reserved4 = 43,
		SteamController_Reserved5 = 44,
		SteamController_Reserved6 = 45,
		SteamController_Reserved7 = 46,
		SteamController_Reserved8 = 47,
		SteamController_Reserved9 = 48,
		SteamController_Reserved10 = 49,
		PS4_X = 50,
		PS4_Circle = 51,
		PS4_Triangle = 52,
		PS4_Square = 53,
		PS4_LeftBumper = 54,
		PS4_RightBumper = 55,
		PS4_Options = 56,
		PS4_Share = 57,
		PS4_LeftPad_Touch = 58,
		PS4_LeftPad_Swipe = 59,
		PS4_LeftPad_Click = 60,
		PS4_LeftPad_DPadNorth = 61,
		PS4_LeftPad_DPadSouth = 62,
		PS4_LeftPad_DPadWest = 63,
		PS4_LeftPad_DPadEast = 64,
		PS4_RightPad_Touch = 65,
		PS4_RightPad_Swipe = 66,
		PS4_RightPad_Click = 67,
		PS4_RightPad_DPadNorth = 68,
		PS4_RightPad_DPadSouth = 69,
		PS4_RightPad_DPadWest = 70,
		PS4_RightPad_DPadEast = 71,
		PS4_CenterPad_Touch = 72,
		PS4_CenterPad_Swipe = 73,
		PS4_CenterPad_Click = 74,
		PS4_CenterPad_DPadNorth = 75,
		PS4_CenterPad_DPadSouth = 76,
		PS4_CenterPad_DPadWest = 77,
		PS4_CenterPad_DPadEast = 78,
		PS4_LeftTrigger_Pull = 79,
		PS4_LeftTrigger_Click = 80,
		PS4_RightTrigger_Pull = 81,
		PS4_RightTrigger_Click = 82,
		PS4_LeftStick_Move = 83,
		PS4_LeftStick_Click = 84,
		PS4_LeftStick_DPadNorth = 85,
		PS4_LeftStick_DPadSouth = 86,
		PS4_LeftStick_DPadWest = 87,
		PS4_LeftStick_DPadEast = 88,
		PS4_RightStick_Move = 89,
		PS4_RightStick_Click = 90,
		PS4_RightStick_DPadNorth = 91,
		PS4_RightStick_DPadSouth = 92,
		PS4_RightStick_DPadWest = 93,
		PS4_RightStick_DPadEast = 94,
		PS4_DPad_North = 95,
		PS4_DPad_South = 96,
		PS4_DPad_West = 97,
		PS4_DPad_East = 98,
		PS4_Gyro_Move = 99,
		PS4_Gyro_Pitch = 100,
		PS4_Gyro_Yaw = 101,
		PS4_Gyro_Roll = 102,
		PS4_DPad_Move = 103,
		PS4_Reserved1 = 104,
		PS4_Reserved2 = 105,
		PS4_Reserved3 = 106,
		PS4_Reserved4 = 107,
		PS4_Reserved5 = 108,
		PS4_Reserved6 = 109,
		PS4_Reserved7 = 110,
		PS4_Reserved8 = 111,
		PS4_Reserved9 = 112,
		PS4_Reserved10 = 113,
		XBoxOne_A = 114,
		XBoxOne_B = 115,
		XBoxOne_X = 116,
		XBoxOne_Y = 117,
		XBoxOne_LeftBumper = 118,
		XBoxOne_RightBumper = 119,
		XBoxOne_Menu = 120,
		XBoxOne_View = 121,
		XBoxOne_LeftTrigger_Pull = 122,
		XBoxOne_LeftTrigger_Click = 123,
		XBoxOne_RightTrigger_Pull = 124,
		XBoxOne_RightTrigger_Click = 125,
		XBoxOne_LeftStick_Move = 126,
		XBoxOne_LeftStick_Click = 127,
		XBoxOne_LeftStick_DPadNorth = 128,
		XBoxOne_LeftStick_DPadSouth = 129,
		XBoxOne_LeftStick_DPadWest = 130,
		XBoxOne_LeftStick_DPadEast = 131,
		XBoxOne_RightStick_Move = 132,
		XBoxOne_RightStick_Click = 133,
		XBoxOne_RightStick_DPadNorth = 134,
		XBoxOne_RightStick_DPadSouth = 135,
		XBoxOne_RightStick_DPadWest = 136,
		XBoxOne_RightStick_DPadEast = 137,
		XBoxOne_DPad_North = 138,
		XBoxOne_DPad_South = 139,
		XBoxOne_DPad_West = 140,
		XBoxOne_DPad_East = 141,
		XBoxOne_DPad_Move = 142,
		XBoxOne_LeftGrip_Lower = 143,
		XBoxOne_LeftGrip_Upper = 144,
		XBoxOne_RightGrip_Lower = 145,
		XBoxOne_RightGrip_Upper = 146,
		XBoxOne_Share = 147,
		XBoxOne_Reserved6 = 148,
		XBoxOne_Reserved7 = 149,
		XBoxOne_Reserved8 = 150,
		XBoxOne_Reserved9 = 151,
		XBoxOne_Reserved10 = 152,
		XBox360_A = 153,
		XBox360_B = 154,
		XBox360_X = 155,
		XBox360_Y = 156,
		XBox360_LeftBumper = 157,
		XBox360_RightBumper = 158,
		XBox360_Start = 159,
		XBox360_Back = 160,
		XBox360_LeftTrigger_Pull = 161,
		XBox360_LeftTrigger_Click = 162,
		XBox360_RightTrigger_Pull = 163,
		XBox360_RightTrigger_Click = 164,
		XBox360_LeftStick_Move = 165,
		XBox360_LeftStick_Click = 166,
		XBox360_LeftStick_DPadNorth = 167,
		XBox360_LeftStick_DPadSouth = 168,
		XBox360_LeftStick_DPadWest = 169,
		XBox360_LeftStick_DPadEast = 170,
		XBox360_RightStick_Move = 171,
		XBox360_RightStick_Click = 172,
		XBox360_RightStick_DPadNorth = 173,
		XBox360_RightStick_DPadSouth = 174,
		XBox360_RightStick_DPadWest = 175,
		XBox360_RightStick_DPadEast = 176,
		XBox360_DPad_North = 177,
		XBox360_DPad_South = 178,
		XBox360_DPad_West = 179,
		XBox360_DPad_East = 180,
		XBox360_DPad_Move = 181,
		XBox360_Reserved1 = 182,
		XBox360_Reserved2 = 183,
		XBox360_Reserved3 = 184,
		XBox360_Reserved4 = 185,
		XBox360_Reserved5 = 186,
		XBox360_Reserved6 = 187,
		XBox360_Reserved7 = 188,
		XBox360_Reserved8 = 189,
		XBox360_Reserved9 = 190,
		XBox360_Reserved10 = 191,
		Switch_A = 192,
		Switch_B = 193,
		Switch_X = 194,
		Switch_Y = 195,
		Switch_LeftBumper = 196,
		Switch_RightBumper = 197,
		Switch_Plus = 198,
		Switch_Minus = 199,
		Switch_Capture = 200,
		Switch_LeftTrigger_Pull = 201,
		Switch_LeftTrigger_Click = 202,
		Switch_RightTrigger_Pull = 203,
		Switch_RightTrigger_Click = 204,
		Switch_LeftStick_Move = 205,
		Switch_LeftStick_Click = 206,
		Switch_LeftStick_DPadNorth = 207,
		Switch_LeftStick_DPadSouth = 208,
		Switch_LeftStick_DPadWest = 209,
		Switch_LeftStick_DPadEast = 210,
		Switch_RightStick_Move = 211,
		Switch_RightStick_Click = 212,
		Switch_RightStick_DPadNorth = 213,
		Switch_RightStick_DPadSouth = 214,
		Switch_RightStick_DPadWest = 215,
		Switch_RightStick_DPadEast = 216,
		Switch_DPad_North = 217,
		Switch_DPad_South = 218,
		Switch_DPad_West = 219,
		Switch_DPad_East = 220,
		Switch_ProGyro_Move = 221,
		Switch_ProGyro_Pitch = 222,
		Switch_ProGyro_Yaw = 223,
		Switch_ProGyro_Roll = 224,
		Switch_DPad_Move = 225,
		Switch_Reserved1 = 226,
		Switch_Reserved2 = 227,
		Switch_Reserved3 = 228,
		Switch_Reserved4 = 229,
		Switch_Reserved5 = 230,
		Switch_Reserved6 = 231,
		Switch_Reserved7 = 232,
		Switch_Reserved8 = 233,
		Switch_Reserved9 = 234,
		Switch_Reserved10 = 235,
		Switch_RightGyro_Move = 236,
		Switch_RightGyro_Pitch = 237,
		Switch_RightGyro_Yaw = 238,
		Switch_RightGyro_Roll = 239,
		Switch_LeftGyro_Move = 240,
		Switch_LeftGyro_Pitch = 241,
		Switch_LeftGyro_Yaw = 242,
		Switch_LeftGyro_Roll = 243,
		Switch_LeftGrip_Lower = 244,
		Switch_LeftGrip_Upper = 245,
		Switch_RightGrip_Lower = 246,
		Switch_RightGrip_Upper = 247,
		Switch_JoyConButton_N = 248,
		Switch_JoyConButton_E = 249,
		Switch_JoyConButton_S = 250,
		Switch_JoyConButton_W = 251,
		Switch_Reserved15 = 252,
		Switch_Reserved16 = 253,
		Switch_Reserved17 = 254,
		Switch_Reserved18 = 255,
		Switch_Reserved19 = 256,
		Switch_Reserved20 = 257,
		PS5_X = 258,
		PS5_Circle = 259,
		PS5_Triangle = 260,
		PS5_Square = 261,
		PS5_LeftBumper = 262,
		PS5_RightBumper = 263,
		PS5_Option = 264,
		PS5_Create = 265,
		PS5_Mute = 266,
		PS5_LeftPad_Touch = 267,
		PS5_LeftPad_Swipe = 268,
		PS5_LeftPad_Click = 269,
		PS5_LeftPad_DPadNorth = 270,
		PS5_LeftPad_DPadSouth = 271,
		PS5_LeftPad_DPadWest = 272,
		PS5_LeftPad_DPadEast = 273,
		PS5_RightPad_Touch = 274,
		PS5_RightPad_Swipe = 275,
		PS5_RightPad_Click = 276,
		PS5_RightPad_DPadNorth = 277,
		PS5_RightPad_DPadSouth = 278,
		PS5_RightPad_DPadWest = 279,
		PS5_RightPad_DPadEast = 280,
		PS5_CenterPad_Touch = 281,
		PS5_CenterPad_Swipe = 282,
		PS5_CenterPad_Click = 283,
		PS5_CenterPad_DPadNorth = 284,
		PS5_CenterPad_DPadSouth = 285,
		PS5_CenterPad_DPadWest = 286,
		PS5_CenterPad_DPadEast = 287,
		PS5_LeftTrigger_Pull = 288,
		PS5_LeftTrigger_Click = 289,
		PS5_RightTrigger_Pull = 290,
		PS5_RightTrigger_Click = 291,
		PS5_LeftStick_Move = 292,
		PS5_LeftStick_Click = 293,
		PS5_LeftStick_DPadNorth = 294,
		PS5_LeftStick_DPadSouth = 295,
		PS5_LeftStick_DPadWest = 296,
		PS5_LeftStick_DPadEast = 297,
		PS5_RightStick_Move = 298,
		PS5_RightStick_Click = 299,
		PS5_RightStick_DPadNorth = 300,
		PS5_RightStick_DPadSouth = 301,
		PS5_RightStick_DPadWest = 302,
		PS5_RightStick_DPadEast = 303,
		PS5_DPad_North = 304,
		PS5_DPad_South = 305,
		PS5_DPad_West = 306,
		PS5_DPad_East = 307,
		PS5_Gyro_Move = 308,
		PS5_Gyro_Pitch = 309,
		PS5_Gyro_Yaw = 310,
		PS5_Gyro_Roll = 311,
		PS5_DPad_Move = 312,
		PS5_LeftGrip = 313,
		PS5_RightGrip = 314,
		PS5_LeftFn = 315,
		PS5_RightFn = 316,
		PS5_Reserved5 = 317,
		PS5_Reserved6 = 318,
		PS5_Reserved7 = 319,
		PS5_Reserved8 = 320,
		PS5_Reserved9 = 321,
		PS5_Reserved10 = 322,
		PS5_Reserved11 = 323,
		PS5_Reserved12 = 324,
		PS5_Reserved13 = 325,
		PS5_Reserved14 = 326,
		PS5_Reserved15 = 327,
		PS5_Reserved16 = 328,
		PS5_Reserved17 = 329,
		PS5_Reserved18 = 330,
		PS5_Reserved19 = 331,
		PS5_Reserved20 = 332,
		SteamDeck_A = 333,
		SteamDeck_B = 334,
		SteamDeck_X = 335,
		SteamDeck_Y = 336,
		SteamDeck_L1 = 337,
		SteamDeck_R1 = 338,
		SteamDeck_Menu = 339,
		SteamDeck_View = 340,
		SteamDeck_LeftPad_Touch = 341,
		SteamDeck_LeftPad_Swipe = 342,
		SteamDeck_LeftPad_Click = 343,
		SteamDeck_LeftPad_DPadNorth = 344,
		SteamDeck_LeftPad_DPadSouth = 345,
		SteamDeck_LeftPad_DPadWest = 346,
		SteamDeck_LeftPad_DPadEast = 347,
		SteamDeck_RightPad_Touch = 348,
		SteamDeck_RightPad_Swipe = 349,
		SteamDeck_RightPad_Click = 350,
		SteamDeck_RightPad_DPadNorth = 351,
		SteamDeck_RightPad_DPadSouth = 352,
		SteamDeck_RightPad_DPadWest = 353,
		SteamDeck_RightPad_DPadEast = 354,
		SteamDeck_L2_SoftPull = 355,
		SteamDeck_L2 = 356,
		SteamDeck_R2_SoftPull = 357,
		SteamDeck_R2 = 358,
		SteamDeck_LeftStick_Move = 359,
		SteamDeck_L3 = 360,
		SteamDeck_LeftStick_DPadNorth = 361,
		SteamDeck_LeftStick_DPadSouth = 362,
		SteamDeck_LeftStick_DPadWest = 363,
		SteamDeck_LeftStick_DPadEast = 364,
		SteamDeck_LeftStick_Touch = 365,
		SteamDeck_RightStick_Move = 366,
		SteamDeck_R3 = 367,
		SteamDeck_RightStick_DPadNorth = 368,
		SteamDeck_RightStick_DPadSouth = 369,
		SteamDeck_RightStick_DPadWest = 370,
		SteamDeck_RightStick_DPadEast = 371,
		SteamDeck_RightStick_Touch = 372,
		SteamDeck_L4 = 373,
		SteamDeck_R4 = 374,
		SteamDeck_L5 = 375,
		SteamDeck_R5 = 376,
		SteamDeck_DPad_Move = 377,
		SteamDeck_DPad_North = 378,
		SteamDeck_DPad_South = 379,
		SteamDeck_DPad_West = 380,
		SteamDeck_DPad_East = 381,
		SteamDeck_Gyro_Move = 382,
		SteamDeck_Gyro_Pitch = 383,
		SteamDeck_Gyro_Yaw = 384,
		SteamDeck_Gyro_Roll = 385,
		SteamDeck_Reserved1 = 386,
		SteamDeck_Reserved2 = 387,
		SteamDeck_Reserved3 = 388,
		SteamDeck_Reserved4 = 389,
		SteamDeck_Reserved5 = 390,
		SteamDeck_Reserved6 = 391,
		SteamDeck_Reserved7 = 392,
		SteamDeck_Reserved8 = 393,
		SteamDeck_Reserved9 = 394,
		SteamDeck_Reserved10 = 395,
		SteamDeck_Reserved11 = 396,
		SteamDeck_Reserved12 = 397,
		SteamDeck_Reserved13 = 398,
		SteamDeck_Reserved14 = 399,
		SteamDeck_Reserved15 = 400,
		SteamDeck_Reserved16 = 401,
		SteamDeck_Reserved17 = 402,
		SteamDeck_Reserved18 = 403,
		SteamDeck_Reserved19 = 404,
		SteamDeck_Reserved20 = 405,
		Horipad_M1 = 406,
		Horipad_M2 = 407,
		Horipad_L4 = 408,
		Horipad_R4 = 409,
		Count = 410,
		MaximumPossibleValue = 32767,
	}
	
	///
	/// EXboxOrigin
	///
	public enum EXboxOrigin : int
	{
		A = 0,
		B = 1,
		X = 2,
		Y = 3,
		LeftBumper = 4,
		RightBumper = 5,
		Menu = 6,
		View = 7,
		LeftTrigger_Pull = 8,
		LeftTrigger_Click = 9,
		RightTrigger_Pull = 10,
		RightTrigger_Click = 11,
		LeftStick_Move = 12,
		LeftStick_Click = 13,
		LeftStick_DPadNorth = 14,
		LeftStick_DPadSouth = 15,
		LeftStick_DPadWest = 16,
		LeftStick_DPadEast = 17,
		RightStick_Move = 18,
		RightStick_Click = 19,
		RightStick_DPadNorth = 20,
		RightStick_DPadSouth = 21,
		RightStick_DPadWest = 22,
		RightStick_DPadEast = 23,
		DPad_North = 24,
		DPad_South = 25,
		DPad_West = 26,
		DPad_East = 27,
		Count = 28,
	}
	
	///
	/// ESteamControllerPad
	///
	public enum ESteamControllerPad : int
	{
		Left = 0,
		Right = 1,
	}
	
	///
	/// EControllerHapticLocation
	///
	public enum EControllerHapticLocation : int
	{
		Left = 1,
		Right = 2,
		Both = 3,
	}
	
	///
	/// EControllerHapticType
	///
	public enum EControllerHapticType : int
	{
		Off = 0,
		Tick = 1,
		Click = 2,
	}
	
	///
	/// ESteamInputType
	///
	public enum ESteamInputType : int
	{
		Unknown = 0,
		SteamController = 1,
		XBox360Controller = 2,
		XBoxOneController = 3,
		GenericGamepad = 4,
		PS4Controller = 5,
		AppleMFiController = 6,
		AndroidController = 7,
		SwitchJoyConPair = 8,
		SwitchJoyConSingle = 9,
		SwitchProController = 10,
		MobileTouch = 11,
		PS3Controller = 12,
		PS5Controller = 13,
		SteamDeckController = 14,
		Count = 15,
		MaximumPossibleValue = 255,
	}
	
	///
	/// ESteamInputConfigurationEnableType
	///
	public enum ESteamInputConfigurationEnableType : int
	{
		None = 0,
		Playstation = 1,
		Xbox = 2,
		Generic = 4,
		Switch = 8,
	}
	
	///
	/// ESteamInputLEDFlag
	///
	public enum ESteamInputLEDFlag : int
	{
		SetColor = 0,
		RestoreUserDefault = 1,
	}
	
	///
	/// ESteamInputGlyphSize
	///
	public enum ESteamInputGlyphSize : int
	{
		Small = 0,
		Medium = 1,
		Large = 2,
		Count = 3,
	}
	
	///
	/// ESteamInputGlyphStyle
	///
	public enum ESteamInputGlyphStyle : int
	{
		Knockout = 0,
		Light = 1,
		Dark = 2,
		NeutralColorABXY = 16,
		SolidABXY = 32,
	}
	
	///
	/// ESteamInputActionEventType
	///
	public enum ESteamInputActionEventType : int
	{
		DigitalAction = 0,
		AnalogAction = 1,
	}
	
	///
	/// EControllerActionOrigin
	///
	public enum EControllerActionOrigin : int
	{
		None = 0,
		A = 1,
		B = 2,
		X = 3,
		Y = 4,
		LeftBumper = 5,
		RightBumper = 6,
		LeftGrip = 7,
		RightGrip = 8,
		Start = 9,
		Back = 10,
		LeftPad_Touch = 11,
		LeftPad_Swipe = 12,
		LeftPad_Click = 13,
		LeftPad_DPadNorth = 14,
		LeftPad_DPadSouth = 15,
		LeftPad_DPadWest = 16,
		LeftPad_DPadEast = 17,
		RightPad_Touch = 18,
		RightPad_Swipe = 19,
		RightPad_Click = 20,
		RightPad_DPadNorth = 21,
		RightPad_DPadSouth = 22,
		RightPad_DPadWest = 23,
		RightPad_DPadEast = 24,
		LeftTrigger_Pull = 25,
		LeftTrigger_Click = 26,
		RightTrigger_Pull = 27,
		RightTrigger_Click = 28,
		LeftStick_Move = 29,
		LeftStick_Click = 30,
		LeftStick_DPadNorth = 31,
		LeftStick_DPadSouth = 32,
		LeftStick_DPadWest = 33,
		LeftStick_DPadEast = 34,
		Gyro_Move = 35,
		Gyro_Pitch = 36,
		Gyro_Yaw = 37,
		Gyro_Roll = 38,
		PS4_X = 39,
		PS4_Circle = 40,
		PS4_Triangle = 41,
		PS4_Square = 42,
		PS4_LeftBumper = 43,
		PS4_RightBumper = 44,
		PS4_Options = 45,
		PS4_Share = 46,
		PS4_LeftPad_Touch = 47,
		PS4_LeftPad_Swipe = 48,
		PS4_LeftPad_Click = 49,
		PS4_LeftPad_DPadNorth = 50,
		PS4_LeftPad_DPadSouth = 51,
		PS4_LeftPad_DPadWest = 52,
		PS4_LeftPad_DPadEast = 53,
		PS4_RightPad_Touch = 54,
		PS4_RightPad_Swipe = 55,
		PS4_RightPad_Click = 56,
		PS4_RightPad_DPadNorth = 57,
		PS4_RightPad_DPadSouth = 58,
		PS4_RightPad_DPadWest = 59,
		PS4_RightPad_DPadEast = 60,
		PS4_CenterPad_Touch = 61,
		PS4_CenterPad_Swipe = 62,
		PS4_CenterPad_Click = 63,
		PS4_CenterPad_DPadNorth = 64,
		PS4_CenterPad_DPadSouth = 65,
		PS4_CenterPad_DPadWest = 66,
		PS4_CenterPad_DPadEast = 67,
		PS4_LeftTrigger_Pull = 68,
		PS4_LeftTrigger_Click = 69,
		PS4_RightTrigger_Pull = 70,
		PS4_RightTrigger_Click = 71,
		PS4_LeftStick_Move = 72,
		PS4_LeftStick_Click = 73,
		PS4_LeftStick_DPadNorth = 74,
		PS4_LeftStick_DPadSouth = 75,
		PS4_LeftStick_DPadWest = 76,
		PS4_LeftStick_DPadEast = 77,
		PS4_RightStick_Move = 78,
		PS4_RightStick_Click = 79,
		PS4_RightStick_DPadNorth = 80,
		PS4_RightStick_DPadSouth = 81,
		PS4_RightStick_DPadWest = 82,
		PS4_RightStick_DPadEast = 83,
		PS4_DPad_North = 84,
		PS4_DPad_South = 85,
		PS4_DPad_West = 86,
		PS4_DPad_East = 87,
		PS4_Gyro_Move = 88,
		PS4_Gyro_Pitch = 89,
		PS4_Gyro_Yaw = 90,
		PS4_Gyro_Roll = 91,
		XBoxOne_A = 92,
		XBoxOne_B = 93,
		XBoxOne_X = 94,
		XBoxOne_Y = 95,
		XBoxOne_LeftBumper = 96,
		XBoxOne_RightBumper = 97,
		XBoxOne_Menu = 98,
		XBoxOne_View = 99,
		XBoxOne_LeftTrigger_Pull = 100,
		XBoxOne_LeftTrigger_Click = 101,
		XBoxOne_RightTrigger_Pull = 102,
		XBoxOne_RightTrigger_Click = 103,
		XBoxOne_LeftStick_Move = 104,
		XBoxOne_LeftStick_Click = 105,
		XBoxOne_LeftStick_DPadNorth = 106,
		XBoxOne_LeftStick_DPadSouth = 107,
		XBoxOne_LeftStick_DPadWest = 108,
		XBoxOne_LeftStick_DPadEast = 109,
		XBoxOne_RightStick_Move = 110,
		XBoxOne_RightStick_Click = 111,
		XBoxOne_RightStick_DPadNorth = 112,
		XBoxOne_RightStick_DPadSouth = 113,
		XBoxOne_RightStick_DPadWest = 114,
		XBoxOne_RightStick_DPadEast = 115,
		XBoxOne_DPad_North = 116,
		XBoxOne_DPad_South = 117,
		XBoxOne_DPad_West = 118,
		XBoxOne_DPad_East = 119,
		XBox360_A = 120,
		XBox360_B = 121,
		XBox360_X = 122,
		XBox360_Y = 123,
		XBox360_LeftBumper = 124,
		XBox360_RightBumper = 125,
		XBox360_Start = 126,
		XBox360_Back = 127,
		XBox360_LeftTrigger_Pull = 128,
		XBox360_LeftTrigger_Click = 129,
		XBox360_RightTrigger_Pull = 130,
		XBox360_RightTrigger_Click = 131,
		XBox360_LeftStick_Move = 132,
		XBox360_LeftStick_Click = 133,
		XBox360_LeftStick_DPadNorth = 134,
		XBox360_LeftStick_DPadSouth = 135,
		XBox360_LeftStick_DPadWest = 136,
		XBox360_LeftStick_DPadEast = 137,
		XBox360_RightStick_Move = 138,
		XBox360_RightStick_Click = 139,
		XBox360_RightStick_DPadNorth = 140,
		XBox360_RightStick_DPadSouth = 141,
		XBox360_RightStick_DPadWest = 142,
		XBox360_RightStick_DPadEast = 143,
		XBox360_DPad_North = 144,
		XBox360_DPad_South = 145,
		XBox360_DPad_West = 146,
		XBox360_DPad_East = 147,
		SteamV2_A = 148,
		SteamV2_B = 149,
		SteamV2_X = 150,
		SteamV2_Y = 151,
		SteamV2_LeftBumper = 152,
		SteamV2_RightBumper = 153,
		SteamV2_LeftGrip_Lower = 154,
		SteamV2_LeftGrip_Upper = 155,
		SteamV2_RightGrip_Lower = 156,
		SteamV2_RightGrip_Upper = 157,
		SteamV2_LeftBumper_Pressure = 158,
		SteamV2_RightBumper_Pressure = 159,
		SteamV2_LeftGrip_Pressure = 160,
		SteamV2_RightGrip_Pressure = 161,
		SteamV2_LeftGrip_Upper_Pressure = 162,
		SteamV2_RightGrip_Upper_Pressure = 163,
		SteamV2_Start = 164,
		SteamV2_Back = 165,
		SteamV2_LeftPad_Touch = 166,
		SteamV2_LeftPad_Swipe = 167,
		SteamV2_LeftPad_Click = 168,
		SteamV2_LeftPad_Pressure = 169,
		SteamV2_LeftPad_DPadNorth = 170,
		SteamV2_LeftPad_DPadSouth = 171,
		SteamV2_LeftPad_DPadWest = 172,
		SteamV2_LeftPad_DPadEast = 173,
		SteamV2_RightPad_Touch = 174,
		SteamV2_RightPad_Swipe = 175,
		SteamV2_RightPad_Click = 176,
		SteamV2_RightPad_Pressure = 177,
		SteamV2_RightPad_DPadNorth = 178,
		SteamV2_RightPad_DPadSouth = 179,
		SteamV2_RightPad_DPadWest = 180,
		SteamV2_RightPad_DPadEast = 181,
		SteamV2_LeftTrigger_Pull = 182,
		SteamV2_LeftTrigger_Click = 183,
		SteamV2_RightTrigger_Pull = 184,
		SteamV2_RightTrigger_Click = 185,
		SteamV2_LeftStick_Move = 186,
		SteamV2_LeftStick_Click = 187,
		SteamV2_LeftStick_DPadNorth = 188,
		SteamV2_LeftStick_DPadSouth = 189,
		SteamV2_LeftStick_DPadWest = 190,
		SteamV2_LeftStick_DPadEast = 191,
		SteamV2_Gyro_Move = 192,
		SteamV2_Gyro_Pitch = 193,
		SteamV2_Gyro_Yaw = 194,
		SteamV2_Gyro_Roll = 195,
		Switch_A = 196,
		Switch_B = 197,
		Switch_X = 198,
		Switch_Y = 199,
		Switch_LeftBumper = 200,
		Switch_RightBumper = 201,
		Switch_Plus = 202,
		Switch_Minus = 203,
		Switch_Capture = 204,
		Switch_LeftTrigger_Pull = 205,
		Switch_LeftTrigger_Click = 206,
		Switch_RightTrigger_Pull = 207,
		Switch_RightTrigger_Click = 208,
		Switch_LeftStick_Move = 209,
		Switch_LeftStick_Click = 210,
		Switch_LeftStick_DPadNorth = 211,
		Switch_LeftStick_DPadSouth = 212,
		Switch_LeftStick_DPadWest = 213,
		Switch_LeftStick_DPadEast = 214,
		Switch_RightStick_Move = 215,
		Switch_RightStick_Click = 216,
		Switch_RightStick_DPadNorth = 217,
		Switch_RightStick_DPadSouth = 218,
		Switch_RightStick_DPadWest = 219,
		Switch_RightStick_DPadEast = 220,
		Switch_DPad_North = 221,
		Switch_DPad_South = 222,
		Switch_DPad_West = 223,
		Switch_DPad_East = 224,
		Switch_ProGyro_Move = 225,
		Switch_ProGyro_Pitch = 226,
		Switch_ProGyro_Yaw = 227,
		Switch_ProGyro_Roll = 228,
		Switch_RightGyro_Move = 229,
		Switch_RightGyro_Pitch = 230,
		Switch_RightGyro_Yaw = 231,
		Switch_RightGyro_Roll = 232,
		Switch_LeftGyro_Move = 233,
		Switch_LeftGyro_Pitch = 234,
		Switch_LeftGyro_Yaw = 235,
		Switch_LeftGyro_Roll = 236,
		Switch_LeftGrip_Lower = 237,
		Switch_LeftGrip_Upper = 238,
		Switch_RightGrip_Lower = 239,
		Switch_RightGrip_Upper = 240,
		PS4_DPad_Move = 241,
		XBoxOne_DPad_Move = 242,
		XBox360_DPad_Move = 243,
		Switch_DPad_Move = 244,
		PS5_X = 245,
		PS5_Circle = 246,
		PS5_Triangle = 247,
		PS5_Square = 248,
		PS5_LeftBumper = 249,
		PS5_RightBumper = 250,
		PS5_Option = 251,
		PS5_Create = 252,
		PS5_Mute = 253,
		PS5_LeftPad_Touch = 254,
		PS5_LeftPad_Swipe = 255,
		PS5_LeftPad_Click = 256,
		PS5_LeftPad_DPadNorth = 257,
		PS5_LeftPad_DPadSouth = 258,
		PS5_LeftPad_DPadWest = 259,
		PS5_LeftPad_DPadEast = 260,
		PS5_RightPad_Touch = 261,
		PS5_RightPad_Swipe = 262,
		PS5_RightPad_Click = 263,
		PS5_RightPad_DPadNorth = 264,
		PS5_RightPad_DPadSouth = 265,
		PS5_RightPad_DPadWest = 266,
		PS5_RightPad_DPadEast = 267,
		PS5_CenterPad_Touch = 268,
		PS5_CenterPad_Swipe = 269,
		PS5_CenterPad_Click = 270,
		PS5_CenterPad_DPadNorth = 271,
		PS5_CenterPad_DPadSouth = 272,
		PS5_CenterPad_DPadWest = 273,
		PS5_CenterPad_DPadEast = 274,
		PS5_LeftTrigger_Pull = 275,
		PS5_LeftTrigger_Click = 276,
		PS5_RightTrigger_Pull = 277,
		PS5_RightTrigger_Click = 278,
		PS5_LeftStick_Move = 279,
		PS5_LeftStick_Click = 280,
		PS5_LeftStick_DPadNorth = 281,
		PS5_LeftStick_DPadSouth = 282,
		PS5_LeftStick_DPadWest = 283,
		PS5_LeftStick_DPadEast = 284,
		PS5_RightStick_Move = 285,
		PS5_RightStick_Click = 286,
		PS5_RightStick_DPadNorth = 287,
		PS5_RightStick_DPadSouth = 288,
		PS5_RightStick_DPadWest = 289,
		PS5_RightStick_DPadEast = 290,
		PS5_DPad_Move = 291,
		PS5_DPad_North = 292,
		PS5_DPad_South = 293,
		PS5_DPad_West = 294,
		PS5_DPad_East = 295,
		PS5_Gyro_Move = 296,
		PS5_Gyro_Pitch = 297,
		PS5_Gyro_Yaw = 298,
		PS5_Gyro_Roll = 299,
		XBoxOne_LeftGrip_Lower = 300,
		XBoxOne_LeftGrip_Upper = 301,
		XBoxOne_RightGrip_Lower = 302,
		XBoxOne_RightGrip_Upper = 303,
		XBoxOne_Share = 304,
		SteamDeck_A = 305,
		SteamDeck_B = 306,
		SteamDeck_X = 307,
		SteamDeck_Y = 308,
		SteamDeck_L1 = 309,
		SteamDeck_R1 = 310,
		SteamDeck_Menu = 311,
		SteamDeck_View = 312,
		SteamDeck_LeftPad_Touch = 313,
		SteamDeck_LeftPad_Swipe = 314,
		SteamDeck_LeftPad_Click = 315,
		SteamDeck_LeftPad_DPadNorth = 316,
		SteamDeck_LeftPad_DPadSouth = 317,
		SteamDeck_LeftPad_DPadWest = 318,
		SteamDeck_LeftPad_DPadEast = 319,
		SteamDeck_RightPad_Touch = 320,
		SteamDeck_RightPad_Swipe = 321,
		SteamDeck_RightPad_Click = 322,
		SteamDeck_RightPad_DPadNorth = 323,
		SteamDeck_RightPad_DPadSouth = 324,
		SteamDeck_RightPad_DPadWest = 325,
		SteamDeck_RightPad_DPadEast = 326,
		SteamDeck_L2_SoftPull = 327,
		SteamDeck_L2 = 328,
		SteamDeck_R2_SoftPull = 329,
		SteamDeck_R2 = 330,
		SteamDeck_LeftStick_Move = 331,
		SteamDeck_L3 = 332,
		SteamDeck_LeftStick_DPadNorth = 333,
		SteamDeck_LeftStick_DPadSouth = 334,
		SteamDeck_LeftStick_DPadWest = 335,
		SteamDeck_LeftStick_DPadEast = 336,
		SteamDeck_LeftStick_Touch = 337,
		SteamDeck_RightStick_Move = 338,
		SteamDeck_R3 = 339,
		SteamDeck_RightStick_DPadNorth = 340,
		SteamDeck_RightStick_DPadSouth = 341,
		SteamDeck_RightStick_DPadWest = 342,
		SteamDeck_RightStick_DPadEast = 343,
		SteamDeck_RightStick_Touch = 344,
		SteamDeck_L4 = 345,
		SteamDeck_R4 = 346,
		SteamDeck_L5 = 347,
		SteamDeck_R5 = 348,
		SteamDeck_DPad_Move = 349,
		SteamDeck_DPad_North = 350,
		SteamDeck_DPad_South = 351,
		SteamDeck_DPad_West = 352,
		SteamDeck_DPad_East = 353,
		SteamDeck_Gyro_Move = 354,
		SteamDeck_Gyro_Pitch = 355,
		SteamDeck_Gyro_Yaw = 356,
		SteamDeck_Gyro_Roll = 357,
		SteamDeck_Reserved1 = 358,
		SteamDeck_Reserved2 = 359,
		SteamDeck_Reserved3 = 360,
		SteamDeck_Reserved4 = 361,
		SteamDeck_Reserved5 = 362,
		SteamDeck_Reserved6 = 363,
		SteamDeck_Reserved7 = 364,
		SteamDeck_Reserved8 = 365,
		SteamDeck_Reserved9 = 366,
		SteamDeck_Reserved10 = 367,
		SteamDeck_Reserved11 = 368,
		SteamDeck_Reserved12 = 369,
		SteamDeck_Reserved13 = 370,
		SteamDeck_Reserved14 = 371,
		SteamDeck_Reserved15 = 372,
		SteamDeck_Reserved16 = 373,
		SteamDeck_Reserved17 = 374,
		SteamDeck_Reserved18 = 375,
		SteamDeck_Reserved19 = 376,
		SteamDeck_Reserved20 = 377,
		Switch_JoyConButton_N = 378,
		Switch_JoyConButton_E = 379,
		Switch_JoyConButton_S = 380,
		Switch_JoyConButton_W = 381,
		PS5_LeftGrip = 382,
		PS5_RightGrip = 383,
		PS5_LeftFn = 384,
		PS5_RightFn = 385,
		Horipad_M1 = 386,
		Horipad_M2 = 387,
		Horipad_L4 = 388,
		Horipad_R4 = 389,
		Count = 390,
		MaximumPossibleValue = 32767,
	}
	
	///
	/// ESteamControllerLEDFlag
	///
	public enum ESteamControllerLEDFlag : int
	{
		SetColor = 0,
		RestoreUserDefault = 1,
	}
	
	///
	/// EUGCMatchingUGCType
	///
	public enum EUGCMatchingUGCType : int
	{
		Items = 0,
		Items_Mtx = 1,
		Items_ReadyToUse = 2,
		Collections = 3,
		Artwork = 4,
		Videos = 5,
		Screenshots = 6,
		AllGuides = 7,
		WebGuides = 8,
		IntegratedGuides = 9,
		UsableInGame = 10,
		ControllerBindings = 11,
		GameManagedItems = 12,
		All = -1,
	}
	
	///
	/// EUserUGCList
	///
	public enum EUserUGCList : int
	{
		Published = 0,
		VotedOn = 1,
		VotedUp = 2,
		VotedDown = 3,
		WillVoteLater = 4,
		Favorited = 5,
		Subscribed = 6,
		UsedOrPlayed = 7,
		Followed = 8,
	}
	
	///
	/// EUserUGCListSortOrder
	///
	public enum EUserUGCListSortOrder : int
	{
		CreationOrderDesc = 0,
		CreationOrderAsc = 1,
		TitleAsc = 2,
		LastUpdatedDesc = 3,
		SubscriptionDateDesc = 4,
		VoteScoreDesc = 5,
		ForModeration = 6,
	}
	
	///
	/// EUGCQuery
	///
	public enum EUGCQuery : int
	{
		RankedByVote = 0,
		RankedByPublicationDate = 1,
		AcceptedForGameRankedByAcceptanceDate = 2,
		RankedByTrend = 3,
		FavoritedByFriendsRankedByPublicationDate = 4,
		CreatedByFriendsRankedByPublicationDate = 5,
		RankedByNumTimesReported = 6,
		CreatedByFollowedUsersRankedByPublicationDate = 7,
		NotYetRated = 8,
		RankedByTotalVotesAsc = 9,
		RankedByVotesUp = 10,
		RankedByTextSearch = 11,
		RankedByTotalUniqueSubscriptions = 12,
		RankedByPlaytimeTrend = 13,
		RankedByTotalPlaytime = 14,
		RankedByAveragePlaytimeTrend = 15,
		RankedByLifetimeAveragePlaytime = 16,
		RankedByPlaytimeSessionsTrend = 17,
		RankedByLifetimePlaytimeSessions = 18,
		RankedByLastUpdatedDate = 19,
	}
	
	///
	/// EItemUpdateStatus
	///
	public enum EItemUpdateStatus : int
	{
		Invalid = 0,
		PreparingConfig = 1,
		PreparingContent = 2,
		UploadingContent = 3,
		UploadingPreviewFile = 4,
		CommittingChanges = 5,
	}
	
	///
	/// EItemState
	///
	public enum EItemState : int
	{
		None = 0,
		Subscribed = 1,
		LegacyItem = 2,
		Installed = 4,
		NeedsUpdate = 8,
		Downloading = 16,
		DownloadPending = 32,
		DisabledLocally = 64,
	}
	
	///
	/// EItemStatistic
	///
	public enum EItemStatistic : int
	{
		NumSubscriptions = 0,
		NumFavorites = 1,
		NumFollowers = 2,
		NumUniqueSubscriptions = 3,
		NumUniqueFavorites = 4,
		NumUniqueFollowers = 5,
		NumUniqueWebsiteViews = 6,
		ReportScore = 7,
		NumSecondsPlayed = 8,
		NumPlaytimeSessions = 9,
		NumComments = 10,
		NumSecondsPlayedDuringTimePeriod = 11,
		NumPlaytimeSessionsDuringTimePeriod = 12,
	}
	
	///
	/// EItemPreviewType
	///
	public enum EItemPreviewType : int
	{
		Image = 0,
		YouTubeVideo = 1,
		Sketchfab = 2,
		EnvironmentMap_HorizontalCross = 3,
		EnvironmentMap_LatLong = 4,
		Clip = 5,
		ReservedMax = 255,
	}
	
	///
	/// EUGCContentDescriptorID
	///
	public enum EUGCContentDescriptorID : int
	{
		NudityOrSexualContent = 1,
		FrequentViolenceOrGore = 2,
		AdultOnlySexualContent = 3,
		GratuitousSexualContent = 4,
		AnyMatureContent = 5,
	}
	
	///
	/// ESteamItemFlags
	///
	public enum ESteamItemFlags : int
	{
		NoTrade = 1,
		Removed = 256,
		Consumed = 512,
	}
	
	///
	/// ETimelineGameMode
	///
	public enum ETimelineGameMode : int
	{
		Invalid = 0,
		Playing = 1,
		Staging = 2,
		Menus = 3,
		LoadingScreen = 4,
		Max = 5,
	}
	
	///
	/// ETimelineEventClipPriority
	///
	public enum ETimelineEventClipPriority : int
	{
		Invalid = 0,
		None = 1,
		Standard = 2,
		Featured = 3,
	}
	
	///
	/// EParentalFeature
	///
	public enum EParentalFeature : int
	{
		Invalid = 0,
		Store = 1,
		Community = 2,
		Profile = 3,
		Friends = 4,
		News = 5,
		Trading = 6,
		Settings = 7,
		Console = 8,
		Browser = 9,
		ParentalSetup = 10,
		Library = 11,
		Test = 12,
		SiteLicense = 13,
		KioskMode_Deprecated = 14,
		BlockAlways = 15,
		Max = 16,
	}
	
	///
	/// ESteamDeviceFormFactor
	///
	public enum ESteamDeviceFormFactor : int
	{
		Unknown = 0,
		Phone = 1,
		Tablet = 2,
		Computer = 3,
		TV = 4,
		VRHeadset = 5,
	}
	
	///
	/// ERemotePlayInputType
	///
	public enum ERemotePlayInputType : int
	{
		Unknown = 0,
		MouseMotion = 1,
		MouseButtonDown = 2,
		MouseButtonUp = 3,
		MouseWheel = 4,
		KeyDown = 5,
		KeyUp = 6,
	}
	
	///
	/// ERemotePlayMouseButton
	///
	public enum ERemotePlayMouseButton : int
	{
		Left = 1,
		Right = 2,
		Middle = 16,
		X1 = 32,
		X2 = 64,
	}
	
	///
	/// ERemotePlayMouseWheelDirection
	///
	public enum ERemotePlayMouseWheelDirection : int
	{
		Up = 1,
		Down = 2,
		Left = 3,
		Right = 4,
	}
	
	///
	/// ERemotePlayScancode
	///
	public enum ERemotePlayScancode : int
	{
		Unknown = 0,
		A = 4,
		B = 5,
		C = 6,
		D = 7,
		E = 8,
		F = 9,
		G = 10,
		H = 11,
		I = 12,
		J = 13,
		K = 14,
		L = 15,
		M = 16,
		N = 17,
		O = 18,
		P = 19,
		Q = 20,
		R = 21,
		S = 22,
		T = 23,
		U = 24,
		V = 25,
		W = 26,
		X = 27,
		Y = 28,
		Z = 29,
		ERemotePlayScancode1 = 30,
		ERemotePlayScancode2 = 31,
		ERemotePlayScancode3 = 32,
		ERemotePlayScancode4 = 33,
		ERemotePlayScancode5 = 34,
		ERemotePlayScancode6 = 35,
		ERemotePlayScancode7 = 36,
		ERemotePlayScancode8 = 37,
		ERemotePlayScancode9 = 38,
		ERemotePlayScancode0 = 39,
		Return = 40,
		Escape = 41,
		Backspace = 42,
		Tab = 43,
		Space = 44,
		Minus = 45,
		Equals = 46,
		LeftBracket = 47,
		RightBracket = 48,
		Backslash = 49,
		Semicolon = 51,
		Apostrophe = 52,
		Grave = 53,
		Comma = 54,
		Period = 55,
		Slash = 56,
		CapsLock = 57,
		F1 = 58,
		F2 = 59,
		F3 = 60,
		F4 = 61,
		F5 = 62,
		F6 = 63,
		F7 = 64,
		F8 = 65,
		F9 = 66,
		F10 = 67,
		F11 = 68,
		F12 = 69,
		Insert = 73,
		Home = 74,
		PageUp = 75,
		Delete = 76,
		End = 77,
		PageDown = 78,
		Right = 79,
		Left = 80,
		Down = 81,
		Up = 82,
		LeftControl = 224,
		LeftShift = 225,
		LeftAlt = 226,
		LeftGUI = 227,
		RightControl = 228,
		RightShift = 229,
		RightALT = 230,
		RightGUI = 231,
	}
	
	///
	/// ERemotePlayKeyModifier
	///
	public enum ERemotePlayKeyModifier : int
	{
		None = 0,
		LeftShift = 1,
		RightShift = 2,
		LeftControl = 64,
		RightControl = 128,
		LeftAlt = 256,
		RightAlt = 512,
		LeftGUI = 1024,
		RightGUI = 2048,
		NumLock = 4096,
		CapsLock = 8192,
		Mask = 65535,
	}
	
	///
	/// ESteamNetworkingAvailability
	///
	public enum ESteamNetworkingAvailability : int
	{
		CannotTry = -102,
		Failed = -101,
		Previously = -100,
		Retrying = -10,
		NeverTried = 1,
		Waiting = 2,
		Attempting = 3,
		Current = 100,
		Unknown = 0,
		Force32bit = 2147483647,
	}
	
	///
	/// ESteamNetworkingIdentityType
	///
	public enum ESteamNetworkingIdentityType : int
	{
		Invalid = 0,
		SteamID = 16,
		XboxPairwiseID = 17,
		SonyPSN = 18,
		IPAddress = 1,
		GenericString = 2,
		GenericBytes = 3,
		UnknownType = 4,
		Force32bit = 2147483647,
	}
	
	///
	/// ESteamNetworkingFakeIPType
	///
	public enum ESteamNetworkingFakeIPType : int
	{
		Invalid = 0,
		NotFake = 1,
		GlobalIPv4 = 2,
		LocalIPv4 = 3,
	}
	
	///
	/// ESteamNetworkingConnectionState
	///
	public enum ESteamNetworkingConnectionState : int
	{
		None = 0,
		Connecting = 1,
		FindingRoute = 2,
		Connected = 3,
		ClosedByPeer = 4,
		ProblemDetectedLocally = 5,
		FinWait = -1,
		Linger = -2,
		Dead = -3,
	}
	
	///
	/// ESteamNetConnectionEnd
	///
	public enum ESteamNetConnectionEnd : int
	{
		Invalid = 0,
		App_Min = 1000,
		App_Generic = 1000,
		App_Max = 1999,
		AppException_Min = 2000,
		AppException_Generic = 2000,
		AppException_Max = 2999,
		Local_Min = 3000,
		Local_OfflineMode = 3001,
		Local_ManyRelayConnectivity = 3002,
		Local_HostedServerPrimaryRelay = 3003,
		Local_NetworkConfig = 3004,
		Local_Rights = 3005,
		Local_P2P_ICE_NoPublicAddresses = 3006,
		Local_Max = 3999,
		Remote_Min = 4000,
		Remote_Timeout = 4001,
		Remote_BadCrypt = 4002,
		Remote_BadCert = 4003,
		Remote_BadProtocolVersion = 4006,
		Remote_P2P_ICE_NoPublicAddresses = 4007,
		Remote_Max = 4999,
		Misc_Min = 5000,
		Misc_Generic = 5001,
		Misc_InternalError = 5002,
		Misc_Timeout = 5003,
		Misc_SteamConnectivity = 5005,
		Misc_NoRelaySessionsToClient = 5006,
		Misc_P2P_Rendezvous = 5008,
		Misc_P2P_NAT_Firewall = 5009,
		Misc_PeerSentNoConnection = 5010,
		Misc_Max = 5999,
	}
	
	///
	/// ESteamNetworkingConfigScope
	///
	public enum ESteamNetworkingConfigScope : int
	{
		Global = 1,
		SocketsInterface = 2,
		ListenSocket = 3,
		Connection = 4,
	}
	
	///
	/// ESteamNetworkingConfigDataType
	///
	public enum ESteamNetworkingConfigDataType : int
	{
		Int32 = 1,
		Int64 = 2,
		Float = 3,
		String = 4,
		Ptr = 5,
	}
	
	///
	/// ESteamNetworkingConfigValue
	///
	public enum ESteamNetworkingConfigValue : int
	{
		Invalid = 0,
		TimeoutInitial = 24,
		TimeoutConnected = 25,
		SendBufferSize = 9,
		RecvBufferSize = 47,
		RecvBufferMessages = 48,
		RecvMaxMessageSize = 49,
		RecvMaxSegmentsPerPacket = 50,
		ConnectionUserData = 40,
		SendRateMin = 10,
		SendRateMax = 11,
		NagleTime = 12,
		IP_AllowWithoutAuth = 23,
		IPLocalHost_AllowWithoutAuth = 52,
		MTU_PacketSize = 32,
		MTU_DataSize = 33,
		Unencrypted = 34,
		SymmetricConnect = 37,
		LocalVirtualPort = 38,
		DualWifi_Enable = 39,
		EnableDiagnosticsUI = 46,
		SendTimeSincePreviousPacket = 59,
		FakePacketLoss_Send = 2,
		FakePacketLoss_Recv = 3,
		FakePacketLag_Send = 4,
		FakePacketLag_Recv = 5,
		FakePacketJitter_Send_Avg = 53,
		FakePacketJitter_Send_Max = 54,
		FakePacketJitter_Send_Pct = 55,
		FakePacketJitter_Recv_Avg = 56,
		FakePacketJitter_Recv_Max = 57,
		FakePacketJitter_Recv_Pct = 58,
		FakePacketReorder_Send = 6,
		FakePacketReorder_Recv = 7,
		FakePacketReorder_Time = 8,
		FakePacketDup_Send = 26,
		FakePacketDup_Recv = 27,
		FakePacketDup_TimeMax = 28,
		PacketTraceMaxBytes = 41,
		FakeRateLimit_Send_Rate = 42,
		FakeRateLimit_Send_Burst = 43,
		FakeRateLimit_Recv_Rate = 44,
		FakeRateLimit_Recv_Burst = 45,
		OutOfOrderCorrectionWindowMicroseconds = 51,
		Callback_ConnectionStatusChanged = 201,
		Callback_AuthStatusChanged = 202,
		Callback_RelayNetworkStatusChanged = 203,
		Callback_MessagesSessionRequest = 204,
		Callback_MessagesSessionFailed = 205,
		Callback_CreateConnectionSignaling = 206,
		Callback_FakeIPResult = 207,
		P2P_STUN_ServerList = 103,
		P2P_Transport_ICE_Enable = 104,
		P2P_Transport_ICE_Penalty = 105,
		P2P_Transport_SDR_Penalty = 106,
		P2P_TURN_ServerList = 107,
		P2P_TURN_UserList = 108,
		P2P_TURN_PassList = 109,
		P2P_Transport_ICE_Implementation = 110,
		SDRClient_ConsecutitivePingTimeoutsFailInitial = 19,
		SDRClient_ConsecutitivePingTimeoutsFail = 20,
		SDRClient_MinPingsBeforePingAccurate = 21,
		SDRClient_SingleSocket = 22,
		SDRClient_ForceRelayCluster = 29,
		SDRClient_DevTicket = 30,
		SDRClient_ForceProxyAddr = 31,
		SDRClient_FakeClusterPing = 36,
		SDRClient_LimitPingProbesToNearestN = 60,
		LogLevel_AckRTT = 13,
		LogLevel_PacketDecode = 14,
		LogLevel_Message = 15,
		LogLevel_PacketGaps = 16,
		LogLevel_P2PRendezvous = 17,
		LogLevel_SDRRelayPings = 18,
		ECN = 999,
		DELETED_EnumerateDevVars = 35,
	}
	
	///
	/// ESteamNetworkingGetConfigValueResult
	///
	public enum ESteamNetworkingGetConfigValueResult : int
	{
		BadValue = -1,
		BadScopeObj = -2,
		BufferTooSmall = -3,
		OK = 1,
		OKInherited = 2,
	}
	
	///
	/// ESteamNetworkingSocketsDebugOutputType
	///
	public enum ESteamNetworkingSocketsDebugOutputType : int
	{
		None = 0,
		Bug = 1,
		Error = 2,
		Important = 3,
		Warning = 4,
		Msg = 5,
		Verbose = 6,
		Debug = 7,
		Everything = 8,
	}
	
	///
	/// ESteamAPIInitResult
	///
	public enum ESteamAPIInitResult : int
	{
		OK = 0,
		FailedGeneric = 1,
		NoSteamClient = 2,
		VersionMismatch = 3,
	}
	
	///
	/// EServerMode
	///
	public enum EServerMode : int
	{
		Invalid = 0,
		NoAuthentication = 1,
		Authentication = 2,
		AuthenticationAndSecure = 3,
	}
	
}
