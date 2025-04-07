using Steamworks.Data;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamAPIInitResult : IComponentData
    {
        public SteamInitResult Result;
        public FixedString512Bytes ErrorMsg;
    }

    public struct SteamAPIRequestInit : IComponentData
    {
        internal AppId_t AppId;

        public SteamAPIRequestInit( AppId_t appId )
        {
            AppId = appId;
        }
    }
    
    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    public partial class SteamClientSystem : SystemBase
    {
        private static class Internal
        {
            private static AppId_t _validAppId = 0;
            private static int _initCount = 0;

            public static SteamInitResult SafeInit( AppId_t appId, out string errorMsg )
            {
                errorMsg = string.Empty;
                var result = SteamInitResult.Ok;
                if ( ShouldInitGlobal( appId ) )
                {
                    result = SteamClientGlobal.Init( appId, out errorMsg );
                }

                if ( result == SteamInitResult.Ok )
                {
                    _validAppId = appId;
                    _initCount++;
                    SharedDispatch.Init();
                }
                
                return result;
            }

            public static void SafeShutdown()
            {
                if ( --_initCount <= 0 )
                {
                    SteamClientGlobal.Shutdown();
                    _initCount = 0;
                    _validAppId = 0;
                }
            }

            private static bool ShouldInitGlobal( AppId_t appId )
            {
                return _validAppId != appId && _initCount == 0;
            }
        }
        
        private EntityQuery _requestInitQuery;

        protected override void OnCreate()
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithAll<SteamAPIRequestInit>()
                .WithNone<SteamAPIInitResult>();
            _requestInitQuery = GetEntityQuery( builder );

            builder.Reset()
                .WithNone<SteamInternal>();
            var excludeDuplicateInitQuery = GetEntityQuery( builder );
            RequireForUpdate( excludeDuplicateInitQuery );
            RequireForUpdate( _requestInitQuery );
        }

        protected override void OnDestroy()
        {
            if ( SystemAPI.TryGetSingleton<SteamInternal>( out var steamInternal ) )
            {
                steamInternal.GetDispatchImpl().UninstallWorld( World.Unmanaged );
                Internal.SafeShutdown();
            }
        }

        protected override void OnUpdate()
        {
            var entities = _requestInitQuery.ToEntityArray( Allocator.Temp );
            var initArray = _requestInitQuery.ToComponentDataArray<SteamAPIRequestInit>( Allocator.Temp );
            var commandBuffer = new EntityCommandBuffer( Allocator.Temp );
            for ( var i = 0; i < entities.Length;  )
            {
                var init = initArray[ i ];
                var eResult = Internal.SafeInit( init.AppId, out var errorMsg );
                var entity = entities[ i ];
                commandBuffer.RemoveComponent<SteamAPIRequestInit>( entity );
                commandBuffer.AddComponent( entity, new SteamAPIInitResult { Result = eResult, ErrorMsg = errorMsg } );
                if ( eResult == SteamInitResult.Ok )
                {
#if !DOTS_DISABLE_DEBUG_NAMES
                    commandBuffer.SetName( entity, "SteamAPI" );
#endif
                    var steamInternal = new SteamInternal( SteamInternal.SteamAPI_GetHSteamPipe(), SteamInternal.SteamAPI_GetHSteamUser(), SteamClientDispatch.DispatchImpl );
                    steamInternal.GetDispatchImpl().InstallWorld( World.Unmanaged );
                    commandBuffer.AddComponent( entity, steamInternal );
                    commandBuffer.AddComponent( entity, new SteamLocal
                    {
                        Id = ISteamUser._SteamAPI_ISteamUser_GetSteamID( CSteamAPIContext.SteamUser )
                    } );
                    commandBuffer.AddComponent( entity, new SteamFriends( CSteamAPIContext.SteamFriends ) );
                    commandBuffer.AddComponent( entity, new SteamMatchmakingServers( CSteamAPIContext.SteamMatchmakingServers ) );
                    commandBuffer.AddComponent( entity, new SteamUser( CSteamAPIContext.SteamUser ) );
                    commandBuffer.AddComponent( entity, new SteamUserStats( CSteamAPIContext.SteamUserStats ) );
                    commandBuffer.AddComponent( entity, new SteamScreenshots( CSteamAPIContext.SteamScreenshots ) );
                }
#if !DOTS_DISABLE_DEBUG_NAMES
                else
                {
                    commandBuffer.SetName( entity, "SteamAPI_Failed" );
                }
#endif
                break;
            }

            commandBuffer.Playback( EntityManager );
            EntityManager.DestroyEntity( _requestInitQuery );
        }
    }
}