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
        [ BurstCompile ]
        public void OnCreate( ref SystemState state )
        {
            var dispatch = SystemAPI.GetSingleton<Dispatch>();
            dispatch.Install<FriendsIsFollowing_t>();
        }

        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            var commandBuffer = new EntityCommandBuffer( Allocator.Temp );
            foreach ( var ( callback, entity ) in SystemAPI.Query<RefRO<SteamCallback>>().
                         WithAll<SteamCallback<FriendsIsFollowing_t>, SteamCallResult>().WithEntityAccess() )
            {
                var result = callback.ValueRO.Value<FriendsIsFollowing_t>();
                UnityEngine.Debug.Log($"{result.Result} {result.IsFollowing} {result.SteamID}");
                commandBuffer.DestroyEntity( entity );
            }

            commandBuffer.Playback( state.EntityManager );
        }
    }
}