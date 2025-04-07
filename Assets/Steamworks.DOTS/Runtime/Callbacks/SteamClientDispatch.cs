using System;
using Unity.Burst;
using Unity.Collections;

namespace Steamworks
{
    [ BurstCompile ]
    public static class SteamClientDispatch
    {
        private struct Index
        {
            public static readonly SharedStatic<DispatchImpl> Value = SharedStatic<DispatchImpl>.GetOrCreate<Index>();
        }

        internal static unsafe IntPtr DispatchImpl => ( IntPtr ) Index.Value.UnsafeDataPointer;
        private static ref DispatchImpl GetDispatchImpl() => ref Index.Value.Data;

        internal static void Init()
        {
            GetDispatchImpl() = new DispatchImpl( SteamInternal.SteamAPI_GetHSteamPipe(), Allocator.Persistent );
        }

        internal static void Shutdown()
        {
            if ( GetDispatchImpl().IsValid )
                GetDispatchImpl().Dispose();
        }

        public static void Frame()
        {
            if ( GetDispatchImpl().IsValid )
                Frame_Burst();
        }

        [ BurstCompile ]
        private static void Frame_Burst()
        {
            GetDispatchImpl().Frame();
        }
    }
}