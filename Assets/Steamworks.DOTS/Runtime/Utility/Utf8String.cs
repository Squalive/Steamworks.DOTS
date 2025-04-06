using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
    internal struct Utf8StringToNative : IDisposable
    {
        public IntPtr Pointer { get; private set; }

        public unsafe Utf8StringToNative( string value )
        {
            if ( value == null )
            {
                Pointer = IntPtr.Zero;
                return;
            }

            fixed ( char* strPtr = value )
            {
                var len = Utility.Utf8NoBom.GetByteCount( value );
                var mem = Marshal.AllocHGlobal( len + 1 );

                var wlen = Utility.Utf8NoBom.GetBytes( strPtr, value.Length, ( byte* ) mem, len + 1 );

                ( ( byte* ) mem )[ wlen ] = 0;

                Pointer = mem;
            }
        }

        public void Dispose()
        {
            if ( Pointer != IntPtr.Zero )
            {
                Marshal.FreeHGlobal( Pointer );
                Pointer = IntPtr.Zero;
            }
        }
    }
    
    public unsafe struct Utf8StringPtr
    {
        internal IntPtr Ptr;

        public static implicit operator string( Utf8StringPtr p )
        {
            if ( p.Ptr == IntPtr.Zero )
                return null;

            var bytes = ( byte* ) p.Ptr;
            var dataLen = 0;
            while ( dataLen < 1024 * 1024 * 64 )
            {
                if ( bytes[ dataLen ] == 0 ) break;
                dataLen++;
            }
            return Utility.Utf8NoBom.GetString( bytes, dataLen );
        }
    }
}