using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks.Data
{
    [ StructLayout( LayoutKind.Explicit, Size = 136, Pack = 1 ) ]
    public partial struct SteamNetworkingIdentity
    {
        [ FieldOffset( 0 ) ] internal ESteamNetworkingIdentityType Type;
        [ FieldOffset( 4 ) ] internal int Size;
        [ FieldOffset( 8 ) ] internal ulong SteamIdField;
        [ FieldOffset( 8 ) ] internal SteamNetworkingIPAddr NetAddress;
        
        /// <summary>
        /// Return a NetIdentity that represents LocalHost
        /// </summary>
        public static SteamNetworkingIdentity LocalHost
        {
            get
            {
                SteamNetworkingIdentity id = default;
                SteamAPI_SetLocalHost( ref id );
                return id;
            }
        }


        public bool IsSteamId => Type == ESteamNetworkingIdentityType.SteamID;
        public bool IsIpAddress => Type == ESteamNetworkingIdentityType.IPAddress;

        /// <summary>
        /// Return true if this identity is localhost
        /// </summary>
        public bool IsLocalHost
        {
            get
            {
                SteamNetworkingIdentity id = default;
                return SteamAPI_IsLocalHost( ref id );
            }
        }
        
        /// <summary>
        /// Convert to a SteamId
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator SteamNetworkingIdentity( SteamId value )
        {
            SteamNetworkingIdentity id = default;
            SteamAPI_SetSteamID( ref id, value );
            return id;
        }

        /// <summary>
        /// Set the specified Address
        /// </summary>
        public static implicit operator SteamNetworkingIdentity( SteamNetworkingIPAddr address )
        {
            SteamNetworkingIdentity id = default;
            SteamAPI_SetIPAddr( ref id, ref address );
            return id;
        }

        /// <summary>
        /// Automatically convert to a SteamId
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator SteamId( SteamNetworkingIdentity value )
        {
            return value.SteamId;
        }

        /// <summary>
        /// Returns NULL if we're not a SteamId
        /// </summary>
        public SteamId SteamId
        {
            get
            {
                if ( Type != ESteamNetworkingIdentityType.SteamID ) return default;
                var id = this;
                return SteamAPI_GetSteamID( ref id );
            }
        }

        /// <summary>
        /// Returns NULL if we're not a NetAddress
        /// </summary>
        public unsafe SteamNetworkingIPAddr Address
        {
            get
            {
                if ( Type != ESteamNetworkingIdentityType.IPAddress ) return default;
                var id = this;

                var addrptr = SteamAPI_GetIPAddr( ref id );
                return UnsafeUtility.AsRef<SteamNetworkingIPAddr>( addrptr.ToPointer() );
            }
        }
    }
}