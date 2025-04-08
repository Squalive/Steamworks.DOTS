using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Steamworks.Data
{
    public partial struct MatchMakingKeyValuePair_t
    {
        public unsafe MatchMakingKeyValuePair_t( FixedString128Bytes key, FixedString128Bytes value )
        {
            const int maxSize = 255;
            fixed ( byte* ptr = Key )
            {
                var len = math.min( key.Length, maxSize );
                UnsafeUtility.MemCpy( ptr, key.GetUnsafePtr(), len );
                ptr[ len ] = 0;
            }
            fixed ( byte* ptr = Value )
            {
                var len = math.min( value.Length, maxSize );
                UnsafeUtility.MemCpy( ptr, key.GetUnsafePtr(), len );
                ptr[ len ] = 0;
            }
        }
    }
}