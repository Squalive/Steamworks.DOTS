using Steamworks.Data;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamGameServerInitResult : IComponentData
    {
        public ESteamAPIInitResult Result;
        public FixedString512Bytes ErrorMsg;
    }

    public struct SteamGameServerRequestInit : IComponentData
    {
        internal AppId_t AppId;
        internal SteamGameServerInit Params;

        public SteamGameServerRequestInit( AppId_t appId, in FixedString128Bytes modDir, in FixedString512Bytes gameDesc )
        {
            AppId = appId;
            Params = new SteamGameServerInit( modDir, gameDesc );
        }
    }
    
    [ WorldSystemFilter( WorldSystemFilterFlags.ServerSimulation ) ]
    [ UpdateInGroup( typeof( InitializationSystemGroup ) ) ]
    public partial class SteamServerSystem : SystemBase
    {
        private static class Internal
        {
            private static AppId_t _validAppId = 0;
            private static int _initCount = 0;

            public static ESteamAPIInitResult SafeInit( AppId_t appId, SteamGameServerInit init, out string errorMsg )
            {
                errorMsg = string.Empty;
                var result = ESteamAPIInitResult.OK;
                if ( ShouldInitGlobal( appId ) )
                {
                    _validAppId = appId;
                    result = SteamGameServerGlobal.Init( appId, init, out errorMsg );
                }

                _initCount++;
                SharedDispatch.Init();
                return result;
            }

            public static void SafeShutdown()
            {
                if ( --_initCount <= 0 )
                {
                    var steamGameServer = new ISteamGameServer( CSteamGameServerAPIContext.SteamGameServer );
                    if ( steamGameServer.BLoggedOn() ) steamGameServer.LogOff();
                    SteamGameServerGlobal.Shutdown();
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
                .WithAll<SteamGameServerRequestInit>()
                .WithNone<SteamGameServerInitResult>();
            _requestInitQuery = GetEntityQuery( builder );

            builder.Reset()
                .WithNone<SteamGameServer>();
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
            var initArray = _requestInitQuery.ToComponentDataArray<SteamGameServerRequestInit>( Allocator.Temp );
            var commandBuffer = new EntityCommandBuffer( Allocator.Temp );
            for ( var i = 0; i < entities.Length;  )
            {
                var init = initArray[ i ];
                var eResult = Internal.SafeInit( init.AppId, init.Params, out var errorMsg );
                var entity = entities[ i ];
                commandBuffer.RemoveComponent<SteamGameServerRequestInit>( entity );
                commandBuffer.AddComponent( entity, new SteamGameServerInitResult { Result = eResult, ErrorMsg = errorMsg } );
                if ( eResult == ESteamAPIInitResult.OK )
                {
#if !DOTS_DISABLE_DEBUG_NAMES
                    commandBuffer.SetName( entity, "SteamGameServer" );
#endif
                    var steamInternal = new SteamInternal( SteamInternal.SteamGameServer_GetHSteamPipe(), SteamInternal.SteamGameServer_GetHSteamUser(), SteamGameServerDispatch.DispatchImpl );
                    steamInternal.GetDispatchImpl().InstallWorld( World.Unmanaged );
                    commandBuffer.AddComponent( entity, steamInternal );
                    commandBuffer.AddComponent( entity, new SteamGameServer( CSteamGameServerAPIContext.SteamGameServer ) );
                }
                else
                {
#if !DOTS_DISABLE_DEBUG_NAMES
                    commandBuffer.SetName( entity, "SteamGameServer_Failed" );
#endif
                }
                break;
            }

            commandBuffer.Playback( EntityManager );
            EntityManager.DestroyEntity( _requestInitQuery );
        }
    }
}