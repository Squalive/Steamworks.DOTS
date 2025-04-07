using System.Runtime.InteropServices;

namespace Steamworks
{
    internal static class SharedDispatch
    {
        private static class Native
        {
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ManualDispatch_Init", CallingConvention = Platform.CC ) ]
            public static extern void SteamAPI_ManualDispatch_Init();
        }

        private static bool _initialized = false;

        public static void Init()
        {
            if ( _initialized ) return;
            _initialized = true;
            Native.SteamAPI_ManualDispatch_Init();
        }
    }
}