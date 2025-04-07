using System;
using System.Runtime.InteropServices;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
    public static unsafe class SteamClientGlobal
    {
        internal static class Native
        {
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamInternal_SteamAPI_Init", CallingConvention = Platform.CC ) ]
            public static extern ESteamAPIInitResult SteamInternal_SteamAPI_Init( Utf8StringToNative pszInternalCheckInterfaceVersions, IntPtr pOutErrMsg );
            
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_Shutdown", CallingConvention = Platform.CC ) ]
            public static extern void SteamAPI_Shutdown();

            [ return: MarshalAs( UnmanagedType.I1 ) ]
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_RestartAppIfNecessary", CallingConvention = Platform.CC ) ]
            public static extern bool SteamAPI_RestartAppIfNecessary( uint unOwnAppID );

            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ReleaseCurrentThreadMemory", CallingConvention = Platform.CC ) ]
            public static extern void SteamAPI_ReleaseCurrentThreadMemory();

            [ return: MarshalAs( UnmanagedType.I1 ) ]
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_IsSteamRunning", CallingConvention = Platform.CC ) ]
            public static extern bool SteamAPI_IsSteamRunning();
        }
        
        private static bool _initialized = false;

        /// <summary>
        /// <para>Internal implementation of SteamAPI_InitEx.  This is done in a way that checks
        /// all of the versions of interfaces from headers being compiled into this code.</para>
        /// </summary>
        internal static SteamInitResult Init( AppId_t appid, out string errorMsg )
        {
            if ( _initialized ) throw new Exception( "Calling SteamClient.Init twice" );

            Environment.SetEnvironmentVariable( "SteamAppId", appid.ToString() );
            Environment.SetEnvironmentVariable( "SteamGameId", appid.ToString() );
            
            var interfaceVersions = Utility.BuildVersionString(
                ISteamApps.Version,
                ISteamFriends.Version,
                ISteamInput.Version,
                ISteamInventory.Version,
                ISteamMatchmaking.Version,
                ISteamMatchmakingServers.Version,
                ISteamMusic.Version,
                ISteamNetworking.Version,
                ISteamNetworkingSockets.Version,
                ISteamNetworkingUtils.Version,
                ISteamParentalSettings.Version,
                ISteamParties.Version,
                ISteamRemoteStorage.Version,
                ISteamScreenshots.Version,
                ISteamUGC.Version,
                ISteamUser.Version,
                ISteamUserStats.Version,
                ISteamUtils.Version,
                ISteamVideo.Version,
                ISteamRemotePlay.Version,
                ISteamTimeline.Version );
            
            using var hInterfaceVersions = new Utf8StringToNative( interfaceVersions );
            var errorMsgPtr = UnsafeUtility.Malloc( Defines.k_cchMaxSteamErrMsg, 16, Allocator.Temp );
            var initResult = ( SteamInitResult ) Native.SteamInternal_SteamAPI_Init( hInterfaceVersions, ( IntPtr ) errorMsgPtr );
            errorMsg = new Utf8StringPtr { Ptr = ( IntPtr ) errorMsgPtr };
            UnsafeUtility.Free( errorMsgPtr, Allocator.Temp );
            if ( initResult == SteamInitResult.Ok )
            {
                if ( CSteamAPIContext.Init() )
                {
                    SteamClientDispatch.Init();
                    _initialized = true;
                }
                else
                {
                    initResult = SteamInitResult.ContextFailed;
                    errorMsg = "[Steamworks] Failed to initialize CSteamAPIContext";
                    CSteamAPIContext.Shutdown();
                    Native.SteamAPI_Shutdown();
                }
            }
            return initResult;
        }

        internal static void Shutdown()
        {
            if ( !_initialized ) throw new Exception( "Calling shutdown when no initialization" );
            
            SteamClientDispatch.Shutdown();
            CSteamAPIContext.Shutdown();
            Native.SteamAPI_Shutdown();
            _initialized = false;
        }

        public static void Frame()
        {
            SteamClientDispatch.Frame();
        }

        /// <summary>
        /// <para>SteamAPI_RestartAppIfNecessary ensures that your executable was launched through Steam.</para>
        ///
        /// <para>Returns true if the current process should terminate. Steam is now re-launching your application.</para>
        ///
        /// <para>Returns false if no action needs to be taken. This means that your executable was started through
        /// the Steam client, or a steam_appid.txt file is present in your game's directory (for development).
        /// Your current process should continue if false is returned.</para>
        ///
        /// <para>NOTE: If you use the Steam DRM wrapper on your primary executable file, this check is unnecessary
        /// since the DRM wrapper will ensure that your application was launched properly through Steam.</para>
        /// </summary>
        public static bool RestartAppIfNecessary( uint unOwnAppID )
        {
            return Native.SteamAPI_RestartAppIfNecessary( unOwnAppID );
        }
    }
}