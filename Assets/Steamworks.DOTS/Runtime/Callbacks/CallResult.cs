using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamCallResultSingleton : IComponentData
    {
        internal NativeParallelHashMap<SteamAPICall_t, Entity> ResultCallbacks;
    }
    
    public struct SteamCallResult : IComponentData { }

    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.Default | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    public partial struct SteamCallResultSystem : ISystem
    {
        private NativeParallelHashMap<SteamAPICall_t, Entity> _resultCallbacks;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            _resultCallbacks = new NativeParallelHashMap<SteamAPICall_t, Entity>( 32, Allocator.Persistent );

            var singleton = state.EntityManager.CreateEntity();
#if !DOTS_DISABLE_DEBUG_NAMES
            state.EntityManager.SetName( singleton, "SteamCallResult" );
#endif
            state.EntityManager.AddComponentData( singleton, new SteamCallResultSingleton { ResultCallbacks = _resultCallbacks } );
        }

        [ BurstCompile ]
        public void OnDestroy( ref SystemState state )
        {
            _resultCallbacks.Dispose();
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            
        }
    }
    
    public readonly struct CallResult<T> where T : unmanaged, ISteamCallback
    {
        private readonly SteamAPICall_t _apiCall;

        public CallResult( SteamAPICall_t apiCall )
        {
            _apiCall = apiCall;
        }

        public void Set( SteamCallResultSingleton steamCallResultSingleton, Entity entity )
        {
            steamCallResultSingleton.ResultCallbacks.TryAdd( _apiCall, entity );
        }

        public override string ToString()
        {
            return _apiCall.Value.ToString();
        }
    }
}