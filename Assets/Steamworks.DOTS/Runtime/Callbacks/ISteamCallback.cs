#if UNITY_EDITOR && !STEAMWORKS_DEBUG
#define STEAMWORKS_DEBUG
#endif
using System;
using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks
{
    public interface ISteamCallback 
    {
        /// <summary>
        /// Gives us a generic way to get the CallbackId of structs
        /// </summary>
        CallbackType CallbackType { get; }
        int DataSize { get; }
    }

    internal static unsafe class SteamCallbackMemory
    {
        public static IntPtr Alloc( IntPtr data, int dataSize )
        {
            var copy = UnsafeUtility.Malloc( dataSize, 16, Allocator.Persistent );
            UnsafeUtility.MemCpy( copy, ( void* ) data, dataSize );
            return ( IntPtr ) copy;
        }

        public static void Free( IntPtr data )
        {
            UnsafeUtility.Free( ( void* ) data, Allocator.Persistent );
        }
    }

    internal struct SteamCallbackCleanup : ICleanupComponentData
    {
        [ NativeDisableUnsafePtrRestriction ] internal IntPtr Data;
        internal int DataSize;
    }

    internal struct SteamCallbackAge : IComponentData
    {
        public CallbackType Type;
        public int Age;
    }

    public struct SteamCallback : IComponentData
    {
        [ NativeDisableUnsafePtrRestriction ] internal IntPtr Data;
        
        public unsafe ref readonly T Value<T>() where T : unmanaged, ISteamCallback
        {
            return ref UnsafeUtility.AsRef<T>( Data.ToPointer() );
        }
    }

    public struct SteamCallback<T> : IComponentData where T : unmanaged, ISteamCallback { }
    
    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.Default | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    [ RequireMatchingQueriesForUpdate ]
    public partial struct SteamCallbacksSystem : ISystem
    {
        private NativeHashMap<int, ComponentType> _installedEvents;
        private EntityQuery _requireCleanupQuery;
        private EntityQuery _undispatchedQuery;
        private EntityQuery _consumeAgeQuery;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            _installedEvents = new NativeHashMap<int, ComponentType>( Defines.NumCallbacks, Allocator.Persistent );
            
            var components = new NativeArray<ComponentType>( 1, Allocator.Temp );
            components[ 0 ] = ComponentType.ReadWrite<Dispatch>();
            var dispatchEntity = state.EntityManager.CreateEntity( components );
#if !DOTS_DISABLE_DEBUG_NAMES
            state.EntityManager.SetName( dispatchEntity, "SteamDispatch" );
#endif
            state.EntityManager.SetComponentData( dispatchEntity, new Dispatch { InstalledEvents = _installedEvents } );
            
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithAllRW<SteamCallbackCleanup>()
                .WithNone<SteamCallback>();
            _requireCleanupQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithAll<Dispatch>()
                .WithNone<Dispatched>();
            _undispatchedQuery = state.GetEntityQuery( builder );

            builder.Reset()
                .WithAll<SteamCallbackAge>();
            _consumeAgeQuery = state.GetEntityQuery( builder );
            
            state.RequireForUpdate<SteamInternal>();
        }

        [ BurstCompile ]
        public void OnDestroy( ref SystemState state )
        {
            _installedEvents.Dispose();
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var commandBuffer = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer( state.WorldUnmanaged );
            var parallelWriter = commandBuffer.AsParallelWriter();
            if ( !_requireCleanupQuery.IsEmptyIgnoreFilter )
            {
                state.Dependency = new CleanupJob
                {
                    CommandBuffer = parallelWriter,
                }.ScheduleParallel( _requireCleanupQuery, state.Dependency );
            }

            if ( !_undispatchedQuery.IsEmptyIgnoreFilter )
            {
                var steamInternal = SystemAPI.GetSingleton<SteamInternal>();
                ref var dispatchImpl = ref steamInternal.GetDispatchImpl();
                foreach ( var pair in _installedEvents )
                {
                    dispatchImpl.Install( pair.Key, pair.Value );
                }
                state.EntityManager.AddComponent<Dispatched>( _undispatchedQuery );
            }

            if ( !_consumeAgeQuery.IsEmptyIgnoreFilter )
            {
                state.Dependency = new ConsumeAgeJob
                {
                    CommandBuffer = parallelWriter
                }.ScheduleParallel( _consumeAgeQuery, state.Dependency );
            }
        }

        [ BurstCompile ]
        private partial struct CleanupJob : IJobEntity
        {
            public EntityCommandBuffer.ParallelWriter CommandBuffer;
            
            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, ref SteamCallbackCleanup cleanup )
            {
                CommandBuffer.RemoveComponent<SteamCallbackCleanup>( chunkIndex, entity );

                SteamCallbackMemory.Free( cleanup.Data );
            }
        }
        
        [ BurstCompile ]
        private partial struct ConsumeAgeJob : IJobEntity
        {
            public EntityCommandBuffer.ParallelWriter CommandBuffer;
            
            private void Execute( in Entity entity, [ ChunkIndexInQuery ] int chunkIndex, ref SteamCallbackAge callbackAge )
            {
                if ( ++callbackAge.Age >= SteamInternalConstants.MaxCallbackAges )
                {
                    CommandBuffer.DestroyEntity( chunkIndex, entity );
#if STEAMWORKS_DEBUG
                    UnityEngine.Debug.LogError( $"Unhandled callback type {callbackAge.Type}! (If you call Dispatch.Install then you must be handling its receiving logic, otherwise its a waste)" );
#endif
                }
            }
        }
    }
}