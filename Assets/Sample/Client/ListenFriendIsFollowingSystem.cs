using Steamworks.Data;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks.Sample
{
    [ BurstCompile ]
    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    [ RequireMatchingQueriesForUpdate ]
    [ CreateAfter( typeof( SteamCallbacksSystem ) ) ]
    public partial struct ListenFriendIsFollowingSystem : ISystem
    {
        private CallbackQuery<FriendsIsFollowing_t> _friendIsFollowingQuery;
        
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var dispatch = SystemAPI.GetSingleton<Dispatch>();
            dispatch.Install<FriendsIsFollowing_t>();

            _friendIsFollowingQuery = new CallbackQuery<FriendsIsFollowing_t>( ref state, isCallResult: true );
            state.RequireForUpdate( _friendIsFollowingQuery );
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var commandBuffer = new EntityCommandBuffer( Allocator.Temp );
            var entities = _friendIsFollowingQuery.ToEntityArray( Allocator.Temp );
            var callbacks = _friendIsFollowingQuery.ToCallbackArray( Allocator.Temp );
            for ( var i = 0; i < entities.Length; ++i )
            {
                var callback = callbacks[ i ].Callback;
                UnityEngine.Debug.Log($"{callback.Result} {callback.IsFollowing} {callback.SteamID}");
                commandBuffer.DestroyEntity( entities[ i ] );
            }

            commandBuffer.Playback( state.EntityManager );
        }
    }
}