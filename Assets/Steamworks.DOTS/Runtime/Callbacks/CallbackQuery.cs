using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;

namespace Steamworks
{
    [ StructLayout( LayoutKind.Sequential ) ]
    public struct SteamCallbackData<T> where T : unmanaged, ISteamCallback
    {
        private IntPtr _callback;
        public unsafe ref T Callback => ref UnsafeUtility.AsRef<T>( ( void* ) _callback );
    }
    
    public struct CallbackQuery<T> : IDisposable where T : unmanaged, ISteamCallback
    {
        private EntityQuery _query;

        public CallbackQuery( ref SystemState state, bool isCallResult = false, bool includeFake = true )
        {
            var builder = new EntityQueryBuilder( Allocator.Temp ).WithAll<SteamCallback, SteamCallback<T>>();
            if ( !includeFake ) builder.WithNone<Fake>();
            if ( !isCallResult ) builder.WithNone<SteamCallResult>();
            _query = state.GetEntityQuery( builder );

            using var dispatchQuery = builder.Reset().WithAll<Dispatch>().Build( state.EntityManager );
            dispatchQuery.GetSingleton<Dispatch>().Install<T>();
        }
        
        public void Dispose()
        {
            _query.Dispose();
        }

        public bool IsEmptyIgnoreFilter => _query.IsEmptyIgnoreFilter;
        public bool IsEmpty => _query.IsEmpty;

        public NativeArray<Entity> ToEntityArray( Allocator allocator ) => _query.ToEntityArray( allocator );

        public NativeList<Entity> ToEntityListAsync( Allocator allocator, JobHandle additionalInputDep, out JobHandle outJobHandle ) =>
            _query.ToEntityListAsync( allocator, additionalInputDep, out outJobHandle );

        public NativeList<Entity> ToEntityListAsync( Allocator allocator, out JobHandle outJobHandle ) =>
            _query.ToEntityListAsync( allocator, out outJobHandle );

        public NativeArray<SteamCallbackData<T>> ToCallbackArray( Allocator allocator )
        {
            var array = _query.ToComponentDataArray<SteamCallback>( allocator );
            return array.Reinterpret<SteamCallbackData<T>>();
        }

        public NativeList<SteamCallbackData<T>> ToCallbackListAsync( Allocator allocator, JobHandle additionalInputDep, out JobHandle outJobHandle )
        {
            var list = _query.ToComponentDataListAsync<SteamCallback>( allocator, additionalInputDep, out outJobHandle );
            return UnsafeUtility.As<NativeList<SteamCallback>, NativeList<SteamCallbackData<T>>>( ref list );
        }

        public NativeList<SteamCallbackData<T>> ToCallbackListAsync( Allocator allocator, out JobHandle outJobHandle )
        {
            var list = _query.ToComponentDataListAsync<SteamCallback>( allocator, out outJobHandle );
            return UnsafeUtility.As<NativeList<SteamCallback>, NativeList<SteamCallbackData<T>>>( ref list );
        }

        public static implicit operator EntityQuery( CallbackQuery<T> callbackQuery )
        {
            return callbackQuery._query;
        }
    }
}