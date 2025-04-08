using System;
using System.Net;
using System.Net.Sockets;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks.SourceServerQuery
{
    public struct Request : IComponentData
    {
        public readonly uint IP;
        public readonly ushort QueryPort;
        public Request( in ServerInfo serverInfo )
        {
            IP = serverInfo.IP;
            QueryPort = serverInfo.QueryPort;
        }
    }

    internal class Connection : IComponentData, IDisposable
    {
        public readonly UdpClient Udp;
        public readonly NativeList<byte> ReceiveBuffer;
        public double LastAckTime;

        public Connection( in Request request, double currentTime )
        {
            Udp = new UdpClient();
            Udp.Client.SendTimeout = 3000;
            Udp.Client.ReceiveTimeout = 3000;
            Udp.Connect( new IPEndPoint( Utility.Int32ToIp( request.IP ), request.QueryPort + 1 ) );
            ReceiveBuffer = new NativeList<byte>( 1024, Allocator.Persistent );
            LastAckTime = currentTime;
        }
        
        public Connection() { }
        
        public void Dispose()
        {
            Udp?.Dispose();
            if ( ReceiveBuffer.IsCreated ) ReceiveBuffer.Dispose();
        }

        public void Send( DataStreamWriter writer )
        {
            unsafe { Udp.Client.Send( new ReadOnlySpan<byte>( ( byte* ) writer.AsNativeArray().GetUnsafeReadOnlyPtr(), writer.Length ) ); }
            ReceiveBuffer.Clear();
        }

        public bool Receive( NativeArray<byte> tempBuffer )
        {
            var tryReceiveMore = true;
            var completePacket = false;
            var socket = Udp.Client;
            while ( tryReceiveMore )
            {
                var byteCount = 0;
                try
                {
                    unsafe
                    {
                        if ( socket.Available > 0 && socket.Poll( 500000, SelectMode.SelectRead ) )
                            byteCount = socket.Receive( new Span<byte>( ( byte* ) tempBuffer.GetUnsafeReadOnlyPtr(), tempBuffer.Length ) );
                        else
                            tryReceiveMore = false;
                    }
                }
                catch ( Exception )
                {
                    tryReceiveMore = false;
                }
                                
                if ( byteCount > 0 )
                {
                    UnityEngine.Debug.Log( byteCount );
                    
                }
            }

            return completePacket;
        }
    }

    [ WorldSystemFilter( WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.ClientSimulation ) ]
    [ UpdateInGroup( typeof( SimulationSystemGroup ) ) ]
    public partial class SourceServerQuerySystemGroup : ComponentSystemGroup
    {
        
    }
    
    [ UpdateInGroup( typeof( SourceServerQuerySystemGroup ) ) ]
    internal partial class InitializeConnectionSystem : SystemBase
    {
        private EntityQuery _query;
        
        protected override void OnCreate()
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithPresent<Request>()
                .WithAbsent<Connection>();
            _query = GetEntityQuery( builder );
            RequireForUpdate( _query );
        }

        protected override void OnUpdate()
        {
            var entities = _query.ToEntityArray( Allocator.Temp );
            var requests = _query.ToComponentDataArray<Request>( Allocator.Temp );
            for ( var i = 0; i < entities.Length; ++i )
            {
                if ( requests[ i ].IP == 0 || requests[ i ].QueryPort == 0 )
                {
                    EntityManager.DestroyEntity( entities[ i ] );
                    continue;
                }
                
                EntityManager.AddComponentData( entities[ i ], new Connection( requests[ i ], SystemAPI.Time.ElapsedTime ) );
            }
        }
    }

    internal static class QueryUtility
    {
        public static void WriteHeader( ref DataStreamWriter writer )
        {
            writer.WriteInt( -1 );
        }
    }
}