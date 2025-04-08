using Steamworks;
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
            
            if ( Input.GetKeyDown( KeyCode.Space ) )
            {
                foreach ( var responsiveServerInfos in SystemAPI.Query<DynamicBuffer<ServerList.ResponsiveServerInfo>>() )
                {
                    if ( responsiveServerInfos.Length > 0 )
                    {
                        var entity = commandBuffer.CreateEntity();
                        commandBuffer.AddComponent( entity, new SourceServerQuery.Request( responsiveServerInfos[ 0 ].Info ) );
                        commandBuffer.AddComponent( entity, new SourceServerQuery.RequestRules() );
                    }
                }
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