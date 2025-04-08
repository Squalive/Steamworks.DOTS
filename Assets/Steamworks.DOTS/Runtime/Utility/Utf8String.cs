using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

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
                var mem = UnsafeUtility.Malloc( len + 1, 16, Allocator.Persistent );

                var wlen = Utility.Utf8NoBom.GetBytes( strPtr, value.Length, ( byte* ) mem, len + 1 );

                ( ( byte* ) mem )[ wlen ] = 0;

                Pointer = ( IntPtr ) mem;
            }
        }

        public unsafe Utf8StringToNative( byte* src, int length )
        {
            var mem = UnsafeUtility.Malloc( length + 1, 16, Allocator.Persistent );
            UnsafeUtility.MemCpy( mem, src, length );
            ( ( byte* ) mem )[ length ] = 0;
            Pointer = ( IntPtr ) mem;
        }

        public static unsafe Utf8StringToNative CreateFromUnsafeString<T>( in T str ) where T : unmanaged, IUTF8Bytes, INativeList<byte>
        {
            if ( str.Length == 0 )
            {
                return new Utf8StringToNative { Pointer = IntPtr.Zero };
            }

            var strPtr = str.GetUnsafePtr();
            return new Utf8StringToNative( strPtr, str.Length );
        }

        public unsafe void Dispose()
        {
            if ( Pointer != IntPtr.Zero )
            {
                UnsafeUtility.Free( ( void* ) Pointer, Allocator.Persistent );
                Pointer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr( Utf8StringToNative native )
        {
            return native.Pointer;
        }
    }
    
    public unsafe struct Utf8StringPtr
    {
        internal IntPtr Ptr;

        public Utf8StringPtr( IntPtr ptr )
        {
            Ptr = ptr;
        }

        public Utf8StringPtr( byte* ptr )
        {
            Ptr = ( IntPtr ) ptr;
        }

        public T ToUnsafeString<T>() where T : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            if ( Ptr == IntPtr.Zero ) return default;
            
            var bytes = ( byte* ) Ptr;
            var dataLen = 0;
            while ( dataLen < 1024 * 1024 * 64 )
            {
                if ( bytes[ dataLen ] == 0 ) break;
                dataLen++;
            }

            var t = default( T );
            t.TryResize( dataLen, NativeArrayOptions.UninitializedMemory );
            dataLen = math.min( dataLen, t.Length );
            UnsafeUtility.MemCpy( t.GetUnsafePtr(), bytes, dataLen );
            return t;
        }

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