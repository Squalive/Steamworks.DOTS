using Steamworks.Data;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamGameServerInitResult : IComponentData
    {
        public SteamInitResult Result;
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

        public SteamGameServerRequestInit( 
            AppId_t appId, uint ip, ushort connectionPort, ushort queryPort, bool secure, bool dedicatedServer, 
            in FixedString32Bytes versionStr, in FixedString128Bytes modDir, in FixedString512Bytes gameDesc )
        {
            AppId = appId;
            Params = new SteamGameServerInit
            {
                IpUint = ip,
                GamePort = connectionPort,
                QueryPort = queryPort,
                Secure = secure,
                DedicatedServer = dedicatedServer,
                VersionString = versionStr,
                ModDir = modDir,
                GameDescription = gameDesc
            };
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

            public static SteamInitResult SafeInit( AppId_t appId, SteamGameServerInit init, out string errorMsg )
            {
                errorMsg = string.Empty;
                var result = SteamInitResult.Ok;
                if ( ShouldInitGlobal( appId ) )
                {
                    result = SteamGameServerGlobal.Init( appId, init, out errorMsg );
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
                if ( eResult == SteamInitResult.Ok )
                {
#if !DOTS_DISABLE_DEBUG_NAMES
                    commandBuffer.SetName( entity, "SteamGameServer" );
#endif
                    var steamInternal = new SteamInternal( SteamInternal.SteamGameServer_GetHSteamPipe(), SteamInternal.SteamGameServer_GetHSteamUser(), SteamGameServerDispatch.DispatchImpl );
                    steamInternal.GetDispatchImpl().InstallWorld( World.Unmanaged );
                    commandBuffer.AddComponent( entity, steamInternal );
                    commandBuffer.AddComponent( entity, new SteamLocal
                    {
                        Id = ISteamGameServer._SteamAPI_ISteamGameServer_GetSteamID( CSteamGameServerAPIContext.SteamGameServer )
                    } );
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