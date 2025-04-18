
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Steamworks.Sample
{
    [ RequireMatchingQueriesForUpdate ]
    public partial class RefreshServerQuerySystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var commandBuffer = new EntityCommandBuffer( Allocator.Temp );
            if ( Input.GetKeyDown( KeyCode.R ) )
            {
                var query = SystemAPI.QueryBuilder().WithAll<ServerList.ResolvedRequest>().Build();
                EntityManager.AddComponent<ServerList.RefreshRequest>( query );
            }

            if ( Input.GetKeyDown( KeyCode.G ) )
            {
                foreach ( var responsiveServerInfos in SystemAPI.Query<DynamicBuffer<ServerList.ResponsiveServerInfo>>()
                             .WithAll<ServerList.Lan>() )
                {
                    foreach ( var serverInfo in responsiveServerInfos )
                    {
                        UnityEngine.Debug.Log(serverInfo.Info.ServerName);
                    }
                    
                }
            }
            
            if ( Input.GetKeyDown( KeyCode.Space ) )
            {
                foreach ( var responsiveServerInfos in SystemAPI.Query<DynamicBuffer<ServerList.ResponsiveServerInfo>>() )
                {
                    if ( responsiveServerInfos.Length > 0 )
                    {
                        var index = UnityEngine.Random.Range( 0, responsiveServerInfos.Length - 1 );
                        var entity = commandBuffer.CreateEntity();
                        commandBuffer.AddComponent( entity, new SourceServerQuery.Request( responsiveServerInfos[ index ].Info ) );
                        commandBuffer.AddComponent( entity, new SourceServerQuery.RequestRules() );
                        UnityEngine.Debug.Log($"{responsiveServerInfos[index].Info.IPString}:{responsiveServerInfos[index].Info.QueryPort}");
                    }
                }
                // var entity = commandBuffer.CreateEntity();
                // commandBuffer.AddComponent( entity, new SourceServerQuery.Request( IPAddress.Parse( "43.241.18.191" ), 22222 ) );
                // // commandBuffer.AddComponent( entity, new SourceServerQuery.Request( IPAddress.Parse( "192.168.31.230" ), 27016 ) );
                // commandBuffer.AddComponent( entity, new SourceServerQuery.RequestRules() );

                // 
            }

            if ( Input.GetKeyDown( KeyCode.D ) )
            {
                foreach ( var ( request, entity ) in SystemAPI.Query<RefRO<SourceServerQuery.Request>>().WithEntityAccess() )
                {
                    commandBuffer.DestroyEntity( entity );
                }
            }

            commandBuffer.Playback( EntityManager );
            // if ( Input.GetKeyDown( KeyCode.Space ) )
            // {
            //     
            // }
        }
    }
    
}