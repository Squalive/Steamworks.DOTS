using System.Runtime.InteropServices;

namespace Steamworks
{
    [ StructLayout( LayoutKind.Sequential, Pack = 4 ) ]
    public struct SteamId
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
    }
}