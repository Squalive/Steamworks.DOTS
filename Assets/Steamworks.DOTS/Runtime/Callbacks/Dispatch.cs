using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks
{
    public struct Dispatch : IComponentData
    {
        internal NativeHashMap<int, ComponentType> InstalledEvents;

        public void Install<T>() where T : unmanaged, ISteamCallback
        {
            InstalledEvents.Add( ( int ) default( T ).CallbackType, ComponentType.ReadWrite<SteamCallback<T>>() );
        }

        public void Uninstall<T>() where T : unmanaged, ISteamCallback
        {
            InstalledEvents.Remove( ( int ) default( T ).CallbackType );
        }
    }

    public struct Dispatched : IComponentData { }
    
    internal struct DispatchImpl : IDisposable
    {
        private static class Native
        {
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ManualDispatch_RunFrame", CallingConvention = Platform.CC ) ]
            public static extern void SteamAPI_ManualDispatch_RunFrame( HSteamPipe pipe );
            
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ManualDispatch_GetNextCallback", CallingConvention = Platform.CC ) ]
            [ return: MarshalAs( UnmanagedType.I1 ) ]
            public static extern bool SteamAPI_ManualDispatch_GetNextCallback( HSteamPipe pipe, ref CallbackMsg_t pCallbackMsg );
            
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ManualDispatch_FreeLastCallback", CallingConvention = Platform.CC ) ]
            public static extern void SteamAPI_ManualDispatch_FreeLastCallback( HSteamPipe pipe );

            [ return : MarshalAs( UnmanagedType.I1 ) ]
            [ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ManualDispatch_GetAPICallResult", CallingConvention = Platform.CC ) ]
            public static extern bool SteamAPI_ManualDispatch_GetAPICallResult( 
                HSteamPipe hSteamPipe, 
                SteamAPICall_t hSteamAPICall,
                IntPtr pCallback, 
                int cubCallback, 
                int iCallbackExpected,
                out bool pbFailed );
        }
        
        [ StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize ) ]
        private struct CallbackMsg_t
        {
            public HSteamUser m_hSteamUser; // Specific user to whom this callback applies.
            public CallbackType Type; // Callback identifier.  (Corresponds to the k_iCallback enum in the callback structure.)
            public IntPtr Data; // Points to the callback structure
            public int DataSize; // Size of the data pointed to by m_pubParam
        }
        
        private struct WorldData
        {
            public WorldUnmanaged World;
            public EntityQuery CallResultQuery;
        }

        public bool IsValid => _pipe != 0;
        
        private HSteamPipe _pipe;
        private readonly NativeList<WorldData> _installedWorlds;
        private readonly NativeHashMap<int, ComponentType> _installedEvents;
        private readonly ComponentType _cleanupType;

        public DispatchImpl( HSteamPipe pipe, Allocator allocator )
        {
            _pipe = pipe;
            _installedWorlds = new NativeList<WorldData>( 1, allocator );
            _installedEvents = new NativeHashMap<int, ComponentType>( Defines.NumCallbacks, allocator );
            _cleanupType = ComponentType.ReadWrite<SteamCallbackCleanup>();
        }

        public void Dispose()
        {
            _pipe = 0;
            _installedEvents.Dispose();
            _installedWorlds.Dispose();
        }

        public void Install<T>() where T : unmanaged, ISteamCallback
        {
            Install( ( int ) default( T ).CallbackType, ComponentType.ReadWrite<SteamCallback<T>>() );
        }

        public void Install( int callbackId, ComponentType componentType )
        {
            _installedEvents.TryAdd( callbackId, componentType );
        }

        public void Uninstall<T>() where T : unmanaged, ISteamCallback
        {
            Uninstall( ( int ) default( T ).CallbackType );
        }

        public void Uninstall( int callbackId )
        {
            _installedEvents.Remove( callbackId );
        }

        public void InstallWorld( WorldUnmanaged world )
        {
            var builder = new EntityQueryBuilder( Allocator.Temp ).WithAll<SteamCallResultSingleton>();
            var data = new WorldData
            {
                World = world,
                CallResultQuery = builder.Build( world.EntityManager )
            };
            _installedWorlds.Add( data );
        }

        public void UninstallWorld( WorldUnmanaged world )
        {
            for ( var i = 0; i < _installedWorlds.Length; ++i )
            {
                var data = _installedWorlds[ i ];
                if ( data.World.SequenceNumber == world.SequenceNumber )
                {
                    _installedWorlds.RemoveAt( i );
                    break;
                }
            }
        }

        public void Frame()
        {
            Native.SteamAPI_ManualDispatch_RunFrame( _pipe );
            var msg = default( CallbackMsg_t );
            while ( Native.SteamAPI_ManualDispatch_GetNextCallback( _pipe, ref msg ) )
            {
                try
                {
                    ProcessCallback( msg );
                }
                finally
                {
                    Native.SteamAPI_ManualDispatch_FreeLastCallback( _pipe );
                }
            }
        }

        private void ProcessCallback( in CallbackMsg_t msg )
        {
            if ( msg.Type == CallbackType.SteamAPICallCompleted_t )
            {
                ProcessCallResult( msg );
                return;
            }
            
            if ( !_installedEvents.TryGetValue( ( int ) msg.Type, out var componentType ) ) return;

            for ( var w = 0; w < _installedWorlds.Length; ++w )
            {
                var data = _installedWorlds[ w ];
                var world = data.World;
                var entity = world.EntityManager.CreateEntity();
                var cleanup = new SteamCallbackCleanup
                {
                    Data = SteamCallbackMemory.Alloc( msg.Data, msg.DataSize ),
                    DataSize = msg.DataSize,
                };
                world.EntityManager.AddComponent( entity, componentType );
                world.EntityManager.AddComponentData( entity, new SteamCallbackAge{ Type = msg.Type, Age = 0 } );
                world.EntityManager.AddComponentData( entity, new SteamCallback { Data = cleanup.Data } );
                world.EntityManager.AddComponentData( entity, cleanup );
            }
        }

        private unsafe void ProcessCallResult( in CallbackMsg_t msg )
        {
            var callCompleted = UnsafeUtility.AsRef<SteamAPICallCompleted_t>( ( void* ) msg.Data );

            if ( !_installedEvents.TryGetValue( callCompleted.Callback, out var componentType ) ) return;
            
            var pTmpCallResult = UnsafeUtility.Malloc( callCompleted.ParamCount, 16, Allocator.Temp );
            if ( Native.SteamAPI_ManualDispatch_GetAPICallResult( _pipe, callCompleted.AsyncCall, ( IntPtr ) pTmpCallResult, ( int ) callCompleted.ParamCount, callCompleted.Callback, out var bFailed ) )
            {
                for ( var w = 0; w < _installedWorlds.Length; ++w )
                {
                    var data = _installedWorlds[ w ];
                    var steamCallResult = data.CallResultQuery.GetSingleton<SteamCallResultSingleton>();
                    if ( !steamCallResult.ResultCallbacks.TryGetValue( callCompleted.AsyncCall, out var targetEntity ) ) continue;
                    steamCallResult.ResultCallbacks.Remove( callCompleted.AsyncCall );

                    var world = data.World;
                    var cleanup = new SteamCallbackCleanup
                    {
                        Data = SteamCallbackMemory.Alloc( ( IntPtr ) pTmpCallResult, ( int ) callCompleted.ParamCount ),
                        DataSize = ( int ) callCompleted.ParamCount,
                    };
                    world.EntityManager.AddComponent<SteamCallResult>( targetEntity );
                    world.EntityManager.AddComponent( targetEntity, componentType );
                    world.EntityManager.AddComponentData( targetEntity, new SteamCallbackAge { Type = ( CallbackType ) callCompleted.Callback, Age = 0 } );
                    world.EntityManager.AddComponentData( targetEntity, new SteamCallback { Data = cleanup.Data } );
                    world.EntityManager.AddComponentData( targetEntity, cleanup );
                    break;
                }
            }
            UnsafeUtility.Free( pTmpCallResult, Allocator.Temp );
        }
    }
}