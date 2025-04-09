using System.Runtime.InteropServices;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks.Sample
{
    public struct ClientLogged : IComponentData {}
    
    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    [ UpdateBefore( typeof( SteamClientSystem ) ) ]
    [ CreateAfter( typeof( SteamCallbacksSystem ) ) ]
    public partial struct SteamClientRequestInitSystem : ISystem
    {
        public void OnCreate( ref SystemState state )
        {
            var dispatch = SystemAPI.GetSingleton<Dispatch>();
        }

        public void OnUpdate( ref SystemState state )
        {
            if ( SystemAPI.HasSingleton<ClientLogged>() )
            {
                return;
            }
            
            if ( SystemAPI.TryGetSingletonEntity<SteamAPIInitResult>( out var steamEntity ) )
            {
                // state.EntityManager.RemoveComponent<SteamAPIInitResult>( steamEntity );
                var result = state.EntityManager.GetComponentData<SteamAPIInitResult>( steamEntity );
                if ( result.Result == SteamInitResult.Ok )
                {
                    var steamFriends = SystemAPI.GetComponent<SteamFriends>( steamEntity );
                    var localId = SystemAPI.GetSingleton<SteamLocal>().Id;
                    var callResult = steamFriends.IsFollowing( localId );
                    var targetEntity = state.EntityManager.CreateEntity();
                    callResult.Set( SystemAPI.GetSingleton<SteamCallResultSingleton>(), targetEntity );

                    var serverListRequest = state.EntityManager.CreateEntity();
                    state.EntityManager.AddComponentData( serverListRequest, new ServerList.Request( 730 ) );
                    state.EntityManager.AddComponent<ServerList.Internet>( serverListRequest );

                    // state.EntityManager.AddBuffer<ServerList.IP>( serverListRequest ).Add( new ServerList.IP( "3640287629" ) );

                    // foreach ( var friend in steamFriends.GetFriends() )
                    // {
                    //     UnityEngine.Debug.Log( $"{friend.Id} {friend.Name<FixedString128Bytes>( steamFriends )}" );
                    // }
                }
                else
                {
                    UnityEngine.Debug.LogError( result.ErrorMsg );
                }
                state.EntityManager.AddComponent<ClientLogged>( steamEntity );
            }
            else if ( !SystemAPI.HasSingleton<SteamInternal>() )
            {
                var initEntity = state.EntityManager.CreateEntity();
                state.EntityManager.AddComponentData( initEntity, new SteamAPIRequestInit( 252490 ) );
            }
        }
    }
}