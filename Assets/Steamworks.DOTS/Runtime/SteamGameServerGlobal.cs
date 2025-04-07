using System;
using System.Runtime.InteropServices;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
    public static unsafe class SteamGameServerGlobal
    {
        private static class Native
        {
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamInternal_GameServer_Init_V2", CallingConvention = Platform.CC ) ]
            public static extern ESteamAPIInitResult SteamInternal_GameServer_Init_V2( 
                uint unIP, 
                ushort usGamePort,
                ushort usQueryPort, 
                EServerMode eServerMode,
                Utf8StringToNative pchVersionString,
                Utf8StringToNative pszInternalCheckInterfaceVersions,
                IntPtr pOutErrMsg );
            
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_Shutdown", CallingConvention = Platform.CC ) ]
            public static extern void SteamGameServer_Shutdown();
            
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_ReleaseCurrentThreadMemory", CallingConvention = Platform.CC ) ]
            public static extern void SteamGameServer_ReleaseCurrentThreadMemory();
            
            [ return: MarshalAs( UnmanagedType.I1 ) ]
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_BSecure", CallingConvention = Platform.CC ) ]
            public static extern bool SteamGameServer_BSecure();
            
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_GetSteamID", CallingConvention = Platform.CC ) ]
            public static extern ulong SteamGameServer_GetSteamID();
        }

        /// <para>Initialize SteamGameServer client and interface objects, and set server properties which may not be changed.</para>
        ///
        /// <para>After calling this function, you should set any additional server parameters, and then
        /// call ISteamGameServer::LogOnAnonymous() or ISteamGameServer::LogOn()</para>
        ///
        /// <para>- unIP will usually be zero.  If you are on a machine with multiple IP addresses, you can pass a non-zero
        ///   value here and the relevant sockets will be bound to that IP.  This can be used to ensure that
        ///   the IP you desire is the one used in the server browser.</para>
        /// <para>- usGamePort is the port that clients will connect to for gameplay.  You will usually open up your
        ///   own socket bound to this port.</para>
        /// <para>- usQueryPort is the port that will manage server browser related duties and info
        ///		pings from clients.  If you pass STEAMGAMESERVER_QUERY_PORT_SHARED for usQueryPort, then it
        ///		will use "GameSocketShare" mode, which means that the game is responsible for sending and receiving
        ///		UDP packets for the master  server updater.  (See ISteamGameServer::HandleIncomingPacket and
        ///		ISteamGameServer::GetNextOutgoingPacket.)</para>
        /// <para>- The version string should be in the form x.x.x.x, and is used by the master server to detect when the
        ///		server is out of date.  (Only servers with the latest version will be listed.)</para>
        ///
        /// <para>On success k_ESteamAPIInitResult_OK is returned.  Otherwise, if pOutErrMsg is non-NULL,
        /// it will receive a non-localized message that explains the reason for the failure</para>
        internal static ESteamAPIInitResult Init( AppId_t appId, SteamGameServerInit init, out string outSteamErrMsg )
        {
            uint ipaddress = 0; // Any Port

            if ( init.IpUint != 0 )
                ipaddress = init.IpUint;

            Environment.SetEnvironmentVariable( "SteamAppId", appId.ToString() );
            Environment.SetEnvironmentVariable( "SteamGameId", appId.ToString() );
            
            using var hPszInternalCheckInterfaceVersions = new Utf8StringToNative( Utility.BuildVersionString(
                ISteamUtils.Version,
                ISteamNetworkingUtils.Version,
                ISteamGameServer.Version,
                ISteamGameServerStats.Version,
                ISteamHTTP.Version,
                ISteamInventory.Version,
                ISteamNetworking.Version,
                ISteamNetworkingMessages.Version,
                ISteamNetworkingSockets.Version,
                ISteamUGC.Version
            ) );
            using var hPchVersionString = Utf8StringToNative.CreateFromUnsafeString( init.VersionString );
            var secure = init.Secure ? EServerMode.AuthenticationAndSecure : EServerMode.Authentication;
            var errorMsgPtr = UnsafeUtility.Malloc( Defines.k_cchMaxSteamErrMsg, 16, Allocator.Temp );
            var result = Native.SteamInternal_GameServer_Init_V2( ipaddress, init.GamePort, init.QueryPort, secure, hPchVersionString, hPszInternalCheckInterfaceVersions, ( IntPtr ) errorMsgPtr );
            outSteamErrMsg = new Utf8StringPtr { Ptr = ( IntPtr ) errorMsgPtr };
            UnsafeUtility.Free( errorMsgPtr, Allocator.Temp );

            if ( result == ESteamAPIInitResult.OK )
            {
                if ( CSteamGameServerAPIContext.Init() )
                {
                    SteamGameServerDispatch.Init();
                    var steamServer = CSteamGameServerAPIContext.SteamGameServer;
                    using var modDir = Utf8StringToNative.CreateFromUnsafeString( init.ModDir );
                    ISteamGameServer._SteamAPI_ISteamGameServer_SetModDir( steamServer, modDir );
                    using var gameDesc = Utf8StringToNative.CreateFromUnsafeString( init.GameDescription );
                    ISteamGameServer._SteamAPI_ISteamGameServer_SetGameDescription( steamServer, gameDesc );
                    ISteamGameServer._SteamAPI_ISteamGameServer_SetDedicatedServer( steamServer, init.DedicatedServer );
                }
                else
                {
                    result = ESteamAPIInitResult.FailedGeneric;
                    outSteamErrMsg = "[Steamworks] Failed to initialize CSteamAPIContext";
                }
            }
            
            return result;
        }

        internal static void Shutdown()
        {
            SteamGameServerDispatch.Shutdown();
            CSteamGameServerAPIContext.Shutdown();
            Native.SteamGameServer_Shutdown();
        }

        public static void Frame()
        {
            SteamGameServerDispatch.Frame();
        }
    }
}