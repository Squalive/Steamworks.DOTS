using System;
using System.Runtime.InteropServices;
using Steamworks.Data;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamInternal : IComponentData
    {
        public readonly HSteamPipe Pipe;
        public readonly HSteamUser User;
        internal readonly IntPtr DispatchImpl;

        public SteamInternal( HSteamPipe pipe, HSteamUser user, IntPtr dispatchImpl )
        {
            Pipe = pipe;
            User = user;
            DispatchImpl = dispatchImpl;
        }

        internal unsafe ref DispatchImpl GetDispatchImpl() => ref UnsafeUtility.AsRef<DispatchImpl>( ( void* ) DispatchImpl );
        
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_GetHSteamPipe", CallingConvention = Platform.CC ) ]
        internal static extern HSteamPipe SteamAPI_GetHSteamPipe();
        
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_GetHSteamUser", CallingConvention = Platform.CC ) ]
        internal static extern HSteamUser SteamAPI_GetHSteamUser();
        
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_GetHSteamPipe", CallingConvention = Platform.CC ) ]
        internal static extern HSteamPipe SteamGameServer_GetHSteamPipe();
        
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_GetHSteamUser", CallingConvention = Platform.CC ) ]
        internal static extern HSteamUser SteamGameServer_GetHSteamUser();
        
        [ DllImport( Platform.LibraryName, EntryPoint = "SteamInternal_CreateInterface", CallingConvention = Platform.CC ) ]
        internal static extern IntPtr SteamInternal_CreateInterface( Utf8StringToNative ver );

        [ DllImport( Platform.LibraryName, EntryPoint = "SteamInternal_FindOrCreateUserInterface", CallingConvention = Platform.CC ) ]
        internal static extern IntPtr SteamInternal_FindOrCreateUserInterface( HSteamUser hSteamUser, Utf8StringToNative pszVersion );

        [ DllImport( Platform.LibraryName, EntryPoint = "SteamInternal_FindOrCreateGameServerInterface", CallingConvention = Platform.CC ) ]
        internal static extern IntPtr SteamInternal_FindOrCreateGameServerInterface( HSteamUser hSteamUser, Utf8StringToNative pszVersion );

        internal static IntPtr FindOrCreateUserInterface( HSteamUser hSteamUser, string pszVersion )
        {
            using var mem__pszVersion = new Utf8StringToNative( pszVersion );
            return SteamInternal_FindOrCreateUserInterface( hSteamUser, mem__pszVersion );
        }

        internal static IntPtr FindOrCreateGameServerInterface( HSteamUser hSteamUser, string pszVersion )
        {
            using var mem__pszVersion = new Utf8StringToNative( pszVersion );
            return SteamInternal_FindOrCreateGameServerInterface( hSteamUser, mem__pszVersion );
        }
    }

    internal static class CSteamAPIContext
    {
        public static IntPtr SteamClient;
        public static IntPtr SteamUser;
        public static IntPtr SteamFriends;
        public static IntPtr SteamUtils;
        public static IntPtr SteamMatchmaking;
        public static IntPtr SteamUserStats;
        public static IntPtr SteamApps;
        public static IntPtr SteamMatchmakingServers;
        public static IntPtr SteamNetworking;
        public static IntPtr SteamRemoteStorage;
        public static IntPtr SteamScreenshots;
        public static IntPtr SteamGameSearch;
        public static IntPtr SteamHTTP;
        public static IntPtr SteamController;
        public static IntPtr SteamUGC;
        public static IntPtr SteamMusic;
        public static IntPtr SteamMusicRemote;
        public static IntPtr SteamHTMLSurface;
        public static IntPtr SteamInventory;
        public static IntPtr SteamVideo;
        public static IntPtr SteamParentalSettings;
        public static IntPtr SteamInput;
        public static IntPtr SteamParties;
        public static IntPtr SteamRemotePlay;
        public static IntPtr SteamNetworkingUtils;
        public static IntPtr SteamNetworkingSockets;
        public static IntPtr SteamNetworkingMessages;
        public static IntPtr SteamTimeline;

        public static bool Init()
        {
            var hSteamUser = SteamInternal.SteamAPI_GetHSteamUser();
            var hSteamPipe = SteamInternal.SteamAPI_GetHSteamPipe();
            if ( hSteamPipe == 0 ) return false;

            using ( var ver = new Utf8StringToNative( ISteamClient.Version ) ) { SteamClient = SteamInternal.SteamInternal_CreateInterface( ver ); }
            if ( SteamClient == IntPtr.Zero ) return false;

            var iSteamClient = new ISteamClient( SteamClient );
            if ( ( SteamUser = iSteamClient.GetISteamUser( hSteamUser, hSteamPipe, ISteamUser.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamFriends = iSteamClient.GetISteamFriends( hSteamUser, hSteamPipe, ISteamFriends.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamUtils = iSteamClient.GetISteamUtils( hSteamPipe, ISteamUtils.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamMatchmaking = iSteamClient.GetISteamMatchmaking( hSteamUser, hSteamPipe, ISteamMatchmaking.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamUserStats = iSteamClient.GetISteamUserStats( hSteamUser, hSteamPipe, ISteamUserStats.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamApps = iSteamClient.GetISteamApps( hSteamUser, hSteamPipe, ISteamApps.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamMatchmakingServers = iSteamClient.GetISteamMatchmakingServers( hSteamUser, hSteamPipe, ISteamMatchmakingServers.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamNetworking = iSteamClient.GetISteamNetworking( hSteamUser, hSteamPipe, ISteamNetworking.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamRemoteStorage = iSteamClient.GetISteamRemoteStorage( hSteamUser, hSteamPipe, ISteamRemoteStorage.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamScreenshots = iSteamClient.GetISteamScreenshots( hSteamUser, hSteamPipe, ISteamScreenshots.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamGameSearch = iSteamClient.GetISteamGameSearch( hSteamUser, hSteamPipe, ISteamGameSearch.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamHTTP = iSteamClient.GetISteamHTTP( hSteamUser, hSteamPipe, ISteamHTTP.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamController = iSteamClient.GetISteamController( hSteamUser, hSteamPipe, ISteamController.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamUGC = iSteamClient.GetISteamUGC( hSteamUser, hSteamPipe, ISteamUGC.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamMusic = iSteamClient.GetISteamMusic( hSteamUser, hSteamPipe, ISteamMusic.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamMusicRemote = iSteamClient.GetISteamMusicRemote( hSteamUser, hSteamPipe, ISteamMusicRemote.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamHTMLSurface = iSteamClient.GetISteamHTMLSurface( hSteamUser, hSteamPipe, ISteamHTMLSurface.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamInventory = iSteamClient.GetISteamInventory( hSteamUser, hSteamPipe, ISteamInventory.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamVideo = iSteamClient.GetISteamVideo( hSteamUser, hSteamPipe, ISteamVideo.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamParentalSettings = iSteamClient.GetISteamParentalSettings( hSteamUser, hSteamPipe, ISteamParentalSettings.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamInput = iSteamClient.GetISteamInput( hSteamUser, hSteamPipe, ISteamInput.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamParties = iSteamClient.GetISteamParties( hSteamUser, hSteamPipe, ISteamParties.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamRemotePlay = iSteamClient.GetISteamRemotePlay( hSteamUser, hSteamPipe, ISteamRemotePlay.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamNetworkingUtils = ISteamNetworkingUtils.SteamAPI_SteamNetworkingUtils_SteamAPI_v004() ) == IntPtr.Zero ) return false;
            if ( ( SteamNetworkingSockets = ISteamNetworkingSockets.SteamAPI_SteamNetworkingSockets_SteamAPI_v012() ) == IntPtr.Zero )
            {
                using ( var versionStr = new Utf8StringToNative( ISteamNetworkingSockets.Version ) )
                {
                    SteamNetworkingSockets = SteamInternal.SteamInternal_FindOrCreateUserInterface( hSteamUser, versionStr );
                }
                if ( SteamNetworkingSockets == IntPtr.Zero ) return false;
            }
            if ( ( SteamNetworkingMessages = ISteamNetworkingMessages.SteamAPI_SteamNetworkingMessages_SteamAPI_v002() ) == IntPtr.Zero )
            {
                using ( var versionStr = new Utf8StringToNative( ISteamNetworkingMessages.Version ) )
                {
                    SteamNetworkingMessages = SteamInternal.SteamInternal_FindOrCreateUserInterface( hSteamUser, versionStr );
                }
                if ( SteamNetworkingMessages == IntPtr.Zero ) return false;
            }

            return true;
        }
        
        public static void Shutdown()
        {
            SteamClient = IntPtr.Zero;
            SteamUser = IntPtr.Zero;
            SteamFriends = IntPtr.Zero;
            SteamUtils = IntPtr.Zero;
            SteamMatchmaking = IntPtr.Zero;
            SteamUserStats = IntPtr.Zero;
            SteamApps = IntPtr.Zero;
            SteamMatchmakingServers = IntPtr.Zero;
            SteamNetworking = IntPtr.Zero;
            SteamRemoteStorage = IntPtr.Zero;
            SteamScreenshots = IntPtr.Zero;
            SteamGameSearch = IntPtr.Zero;
            SteamHTTP = IntPtr.Zero;
            SteamController = IntPtr.Zero;
            SteamUGC = IntPtr.Zero;
            SteamMusic = IntPtr.Zero;
            SteamMusicRemote = IntPtr.Zero;
            SteamHTMLSurface = IntPtr.Zero;
            SteamInventory = IntPtr.Zero;
            SteamVideo = IntPtr.Zero;
            SteamParentalSettings = IntPtr.Zero;
            SteamInput = IntPtr.Zero;
            SteamParties = IntPtr.Zero;
            SteamRemotePlay = IntPtr.Zero;
            SteamNetworkingUtils = IntPtr.Zero;
            SteamNetworkingSockets = IntPtr.Zero;
            SteamNetworkingMessages = IntPtr.Zero;
        }
    }

    internal static class CSteamGameServerAPIContext
    {
        public static IntPtr SteamClient;
        public static IntPtr SteamGameServer;
        public static IntPtr SteamUtils;
        public static IntPtr SteamNetworking;
        public static IntPtr SteamGameServerStats;
        public static IntPtr SteamHTTP;
        public static IntPtr SteamUGC;
        public static IntPtr SteamInventory;
        public static IntPtr SteamNetworkingUtils;
        public static IntPtr SteamNetworkingSockets;
        public static IntPtr SteamNetworkingMessages;

        public static bool Init()
        {
            var hSteamUser = SteamInternal.SteamGameServer_GetHSteamUser();
            var hSteamPipe = SteamInternal.SteamGameServer_GetHSteamPipe();
            if ( hSteamPipe == 0 ) return false;

            using ( var ver = new Utf8StringToNative( ISteamClient.Version ) ) { SteamClient = SteamInternal.SteamInternal_CreateInterface( ver ); }
            if ( SteamClient == IntPtr.Zero ) return false;
            
            var iSteamClient = new ISteamClient( SteamClient );
            if ( ( SteamGameServer = iSteamClient.GetISteamGameServer( hSteamUser, hSteamPipe, ISteamGameServer.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamGameServerStats = iSteamClient.GetISteamGameServerStats( hSteamUser, hSteamPipe, ISteamGameServerStats.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamUtils = iSteamClient.GetISteamUtils( hSteamPipe, ISteamUtils.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamNetworking = iSteamClient.GetISteamNetworking( hSteamUser, hSteamPipe, ISteamNetworking.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamHTTP = iSteamClient.GetISteamHTTP( hSteamUser, hSteamPipe, ISteamHTTP.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamUGC = iSteamClient.GetISteamUGC( hSteamUser, hSteamPipe, ISteamUGC.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamInventory = iSteamClient.GetISteamInventory( hSteamUser, hSteamPipe, ISteamInventory.Version ) ) == IntPtr.Zero ) return false;
            if ( ( SteamNetworkingUtils = ISteamNetworkingUtils.SteamAPI_SteamNetworkingUtils_SteamAPI_v004() ) == IntPtr.Zero ) return false;
            if ( ( SteamNetworkingSockets = ISteamNetworkingSockets.SteamAPI_SteamNetworkingSockets_SteamAPI_v012() ) == IntPtr.Zero )
            {
                using ( var versionStr = new Utf8StringToNative( ISteamNetworkingSockets.Version ) )
                {
                    SteamNetworkingSockets = SteamInternal.SteamInternal_FindOrCreateGameServerInterface( hSteamUser, versionStr );
                }
                if ( SteamNetworkingSockets == IntPtr.Zero ) return false;
            }

            if ( ( SteamNetworkingMessages = ISteamNetworkingMessages.SteamAPI_SteamNetworkingMessages_SteamAPI_v002() ) == IntPtr.Zero )
            {
                using ( var versionStr = new Utf8StringToNative( ISteamNetworkingMessages.Version ) )
                {
                    SteamNetworkingMessages = SteamInternal.SteamInternal_FindOrCreateGameServerInterface( hSteamUser, versionStr );
                }
                if ( SteamNetworkingMessages == IntPtr.Zero ) return false;
            }
            return true;
        }
        
        public static void Shutdown()
        {
            SteamClient = IntPtr.Zero;
            SteamGameServer = IntPtr.Zero;
            SteamGameServerStats = IntPtr.Zero;
            SteamUtils = IntPtr.Zero;
            SteamNetworking = IntPtr.Zero;
            SteamHTTP = IntPtr.Zero;
            SteamUGC = IntPtr.Zero;
            SteamInventory = IntPtr.Zero;
            SteamNetworkingUtils = IntPtr.Zero;
            SteamNetworkingSockets = IntPtr.Zero;
            SteamNetworkingMessages = IntPtr.Zero;
        }
    }
}