using System;
using System.Net;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
    internal static unsafe class Utility
    {
        public struct Memory : IDisposable
        {
            public IntPtr Ptr;

            public Memory( int bufferSize )
            {
                Ptr = ( IntPtr ) UnsafeUtility.Malloc( bufferSize, 16, Allocator.Temp );
            }

            public void Dispose()
            {
                UnsafeUtility.Free( Ptr.ToPointer(), Allocator.Temp );
            }

            public static implicit operator IntPtr( Memory mem )
            {
                return mem.Ptr;
            }
        }

        public static readonly Encoding Utf8NoBom = new UTF8Encoding( false, false );
        
        public const int MemoryBufferSize = 1024 * 32;

        public static string MemoryToString( IntPtr ptr )
        {
            var len = 0;

            for( len = 0; len < MemoryBufferSize; len++ )
            {
                if ( ( ( byte* ) ptr )[ len ] == 0 )
                    break;
            }

            if ( len == 0 )
                return string.Empty;

            return Utf8NoBom.GetString( ( byte* ) ptr, len );
        }
		
        internal static string BuildVersionString( params string[] interfaceVersions )
        {
            var sb = new StringBuilder();
            foreach ( var version in interfaceVersions )
            {
                sb.Append( version ).Append( '\0' );
            }

            sb.Append( '\0' );
            return sb.ToString();
        }

        internal static uint Swap( uint x )
        {
            return ( ( x & 0x000000ff ) << 24 ) +
                   ( ( x & 0x0000ff00 ) << 8 ) +
                   ( ( x & 0x00ff0000 ) >> 8 ) +
                   ( ( x & 0xff000000 ) >> 24 );
        }

        public static uint IpToInt32( this IPAddress ipAddress )
        {
            var bytes = ipAddress.GetAddressBytes();
            if ( bytes.Length != 4 )
                throw new ArgumentException( "IPv4 address required." );

            if ( BitConverter.IsLittleEndian )
                Array.Reverse( bytes ); // Convert to network byte order (big-endian)

            return BitConverter.ToUInt32( bytes, 0 );
        }

        public static IPAddress Int32ToIp( uint ipAddress )
        {
            return new IPAddress( Swap( ipAddress ) );
        }
    }
}