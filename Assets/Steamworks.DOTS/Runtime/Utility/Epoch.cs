using System;
using Unity.Burst;
using Unity.Entities;

namespace Steamworks
{
    internal static class Epoch
    {
        private static readonly DateTime _epoch = new ( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );
        
        private struct CurrentContext
        {
            public static readonly SharedStatic<int> Current_Burst = SharedStatic<int>.GetOrCreate<CurrentContext>();
        }
        
        [ WorldSystemFilter( WorldSystemFilterFlags.Default ) ]
        [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
        private partial struct UpdateSystem : ISystem
        {
            public void OnUpdate( ref SystemState state )
            {
                CurrentContext.Current_Burst.Data = ( int ) DateTime.UtcNow.Subtract( _epoch ).TotalSeconds;
            }
        }

        /// <summary>
        /// Returns the current Unix Epoch
        /// </summary>
        public static int Current => CurrentContext.Current_Burst.Data;

        /// <summary>
        /// Convert an epoch to a datetime
        /// </summary>
        public static DateTime ToDateTime( long unixTime ) => _epoch.AddSeconds( unixTime );

        /// <summary>
        /// Convert a DateTime to a unix time
        /// </summary>
        public static uint FromDateTime( DateTime dt ) => ( uint ) dt.Subtract( _epoch ).TotalSeconds;

    }
}