using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
    [ StructLayout( LayoutKind.Sequential, Pack = 4 ) ]
    public struct SteamId : IEquatable<SteamId>
    {
        public ulong Value;

        public static implicit operator SteamId( ulong value )
        {
            return new SteamId { Value = value };
        }
        
        public static implicit operator ulong( SteamId value )
        {
            return value.Value;
        }

        public override string ToString() => Value.ToString();

        public uint AccountId => ( uint ) ( Value & 0xFFFFFFFFul );

        public bool IsValid => Value != 0;

        public bool Equals( SteamId other )
        {
            return Value == other.Value;
        }

        public override bool Equals( object obj )
        {
            return obj is SteamId other && Equals( other );
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}