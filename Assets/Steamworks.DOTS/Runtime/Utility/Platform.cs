#if UNITY_EDITOR_64 || (UNITY_STANDALONE && !UNITY_EDITOR && UNITY_64)
    #define STEAMWORKS_X64
#elif UNITY_EDITOR_32 || (UNITY_STANDALONE && !UNITY_EDITOR && !UNITY_64)
	#define STEAMWORKS_X86
#endif

#if UNITY_EDITOR_WIN
    #define STEAMWORKS_WIN
#elif UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
	#define STEAMWORKS_LIN_OSX
#elif UNITY_STANDALONE_WIN
	#define STEAMWORKS_WIN
#elif UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
	#define STEAMWORKS_LIN_OSX
#endif

#if !STEAMWORKS_WIN && !STEAMWORKS_LIN_OSX
	#error You must define STEAMWORKS_WIN or STEAMWORKS_LIN_OSX if you're not using Unity.
#endif

using System.Runtime.InteropServices;

namespace Steamworks
{
    internal static class Platform
    {
#if STEAMWORKS_WIN && STEAMWORKS_X64
        public const int StructPlatformPackSize = 8;
        public const string LibraryName = "steam_api64";
#elif STEAMWORKS_WIN && STEAMWORKS_X86
        public const int StructPlatformPackSize = 8;
        public const string LibraryName = "steam_api";
#elif STEAMWORKS_LIN_OSX 
        public const int StructPlatformPackSize = 4;
        public const string LibraryName = "libsteam_api";
#endif
        public const CallingConvention CC = CallingConvention.Cdecl;
        public const int StructPackSize = 4;
    }
}