using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
    [ StructLayout( LayoutKind.Sequential ) ]
    public struct NetMsg
    {
        public IntPtr DataPtr;
        public int DataSize;
        public HSteamNetConnection Connection;
        public SteamNetworkingIdentity Identity;
        public long ConnectionUserData;
        public long RecvTime;
        public long MessageNumber;
        public IntPtr FreeDataPtr;
        public IntPtr ReleasePtr;
        public int Channel;
        public SendType Flags;
        public long UserData;
        public ushort IdxLane;
        public ushort _pad1__;
    }
}