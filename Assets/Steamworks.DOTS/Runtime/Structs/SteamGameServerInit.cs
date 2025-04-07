using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
    [ StructLayout( LayoutKind.Sequential ) ]
    internal unsafe struct SteamGameServerInit
    {
        public ref uint IpUint
        {
            get
            {
                fixed ( byte* ptr = &IpAddress0 )
                {
                    return ref UnsafeUtility.AsRef<uint>( ptr );
                }
            }
        }
        
        public byte IpAddress0;
        public byte IpAddress1;
        public byte IpAddress2;
        public byte IpAddress3;

        public ushort GamePort;
        public ushort QueryPort;
        public bool Secure;
        /// <summary>
        /// The version string is usually in the form x.x.x.x, and is used by the master server to detect when the server is out of date.
        /// If you go into the dedicated server tab on steamworks you'll be able to server the latest version. If this version number is
        /// less than that latest version then your server won't show.
        /// </summary>
        public FixedString32Bytes VersionString;

        /// <summary>
        /// This should be the same directory game where gets installed into. Just the folder name, not the whole path. I.e. "Rust", "Garrysmod".
        /// </summary>
        public FixedString128Bytes ModDir;

        /// <summary>
        /// The game description. Setting this to the full name of your game is recommended.
        /// </summary>
        public FixedString512Bytes GameDescription;

        /// <summary>
        /// Is a dedicated server
        /// </summary>
        public bool DedicatedServer;
        
        public SteamGameServerInit( FixedString128Bytes modDir, FixedString512Bytes gameDesc )
        {
            DedicatedServer = true;
            ModDir = modDir;
            GameDescription = gameDesc;
            GamePort = 27015;
            QueryPort = 27016;
            Secure = true;
            VersionString = "1.0.0.0";
            IpAddress0 = IpAddress1 = IpAddress2 = IpAddress3 = 0;
        }

        /// <summary>
        /// If you pass MASTERSERVERUPDATERPORT_USEGAMESOCKETSHARE into usQueryPort, then it causes the game server API to use 
        /// "GameSocketShare" mode, which means that the game is responsible for sending and receiving UDP packets for the master
        /// server updater.
        /// 
        /// More info about this here: https://partner.steamgames.com/doc/api/ISteamGameServer#HandleIncomingPacket
        /// </summary>
        public SteamGameServerInit WithQueryShareGamePort()
        {
            QueryPort = 0xFFFF;
            return this;
        }
    }
}