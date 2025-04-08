using System;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks.ServerList
{
    internal unsafe struct ServerFilterMarshaler  : IDisposable
    {
        private NativeArray<IntPtr> _array;
        private NativeArray<MatchMakingKeyValuePair_t> _items;

        public int Count => _array.IsCreated ? _array.Length : 0;
        public IntPtr Pointer => _array.IsCreated ? ( IntPtr ) _array.GetUnsafeReadOnlyPtr() : IntPtr.Zero;

        public ServerFilterMarshaler( DynamicBuffer<MatchMakingKeyValuePair> pairs, Allocator allocator ) :
            this( ( MatchMakingKeyValuePair* ) pairs.GetUnsafeReadOnlyPtr(), pairs.Length, allocator )
        {
        }

        public ServerFilterMarshaler( NativeArray<MatchMakingKeyValuePair> pairs, Allocator allocator ) :
            this( ( MatchMakingKeyValuePair* ) pairs.GetUnsafeReadOnlyPtr(), pairs.Length, allocator )
        {
        }

        public ServerFilterMarshaler( MatchMakingKeyValuePair* pairs, int count, Allocator allocator )
        {
            if ( count == 0 )
            {
                _array = default;
                _items = default;
                return;
            }

            _array = new NativeArray<IntPtr>( count, allocator );
            _items = new NativeArray<MatchMakingKeyValuePair_t>( count, allocator );
            for ( var i = 0; i < count; ++i )
            {
                _array[ i ] = ( IntPtr ) ( MatchMakingKeyValuePair_t* ) _items.GetUnsafeReadOnlyPtr() + i;
                _items[ i ] = new MatchMakingKeyValuePair_t( pairs[ i ].Key, pairs[ i ].Value );
            }
        }

        public void Dispose()
        {
            if ( _array.IsCreated ) _array.Dispose();
            if ( _items.IsCreated ) _items.Dispose();
        }
    }
}