using System;

namespace Steamworks
{
    internal struct ISteamInterface
    {
        public IntPtr Self;

        public ISteamInterface( IntPtr self )
        {
            Self = self;
        }
    }
}