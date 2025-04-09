using System;
using System.IO;
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

        public Request( uint ip, ushort queryPort )
        {
            IP = ip;
            QueryPort = queryPort;
        }

        public Request( IPAddress ip, ushort queryPort )
        {
            IP = ip.IpToInt32();
            QueryPort = queryPort;
        }
    }

    internal class SourceConnection : IComponentData, IDisposable
    {
        private const int SimpleResponse = -1;
        private const int MultiPacketResponse = -2;
        
        public readonly UdpClient Udp;
        public readonly NativeList<byte> ReceiveBuffer;
        public NativeArray<NativeList<byte>> SplitPackets;
        public double LastAckTime;

        public DataStreamReader ReceiveReader => new( ReceiveBuffer.AsArray() );

        public SourceConnection( in Request request, double currentTime )
        {
            Udp = new UdpClient();
            Udp.Client.SendTimeout = 3000;
            Udp.Client.ReceiveTimeout = 3000;
            Udp.Connect( new IPEndPoint( Utility.Int32ToIp( request.IP ), request.QueryPort ) );
            ReceiveBuffer = new NativeList<byte>( 1024, Allocator.Persistent );
            LastAckTime = currentTime;
        }
        
        public SourceConnection() { }
        
        public void Dispose()
        {
            Udp?.Dispose();
            if ( ReceiveBuffer.IsCreated ) ReceiveBuffer.Dispose();
            if ( SplitPackets.IsCreated )
            {
                for ( var i = 0; i < SplitPackets.Length; ++i )
                {
                    SplitPackets[ i ].Dispose();
                }
                SplitPackets.Dispose();
            }
        }

        public void Send( DataStreamWriter writer )
        {
            unsafe { Udp.Client.Send( new ReadOnlySpan<byte>( ( byte* ) writer.AsNativeArray().GetUnsafeReadOnlyPtr(), writer.Length ) ); }
            ReceiveBuffer.Clear();
        }

        public unsafe bool Receive( NativeArray<byte> tempBuffer )
        {
            var tryReceiveMore = true;
            var completePacket = false;
            var socket = Udp.Client;
            while ( tryReceiveMore )
            {
                var byteCount = 0;
                try
                {
                    if ( socket.Available > 0 && socket.Poll( 500000, SelectMode.SelectRead ) )
                        byteCount = socket.Receive( new Span<byte>( ( byte* ) tempBuffer.GetUnsafeReadOnlyPtr(), tempBuffer.Length ) );
                    else
                        tryReceiveMore = false;
                }
                catch ( Exception )
                {
                    tryReceiveMore = false;
                }
                                
                if ( byteCount > 0 )
                {
                    var aliasBuffer = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>( tempBuffer.GetUnsafeReadOnlyPtr(), byteCount, Allocator.Invalid );
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    NativeArrayUnsafeUtility.SetAtomicSafetyHandle( ref aliasBuffer, NativeArrayUnsafeUtility.GetAtomicSafetyHandle( tempBuffer ) );
#endif
                    var reader = new DataStreamReader( aliasBuffer );
                    var header = reader.ReadInt();
                    if ( header == SimpleResponse )
                    {
                        var payloadPtr = ( byte* ) reader.GetUnsafeReadOnlyPtr() + reader.GetBytesRead();
                        var payloadSize = reader.Length - reader.GetBytesRead();
                        ReceiveBuffer.ResizeUninitialized( payloadSize );
                        UnsafeUtility.MemCpy( ReceiveBuffer.GetUnsafePtr(), payloadPtr, payloadSize );
                        return true;
                    }
                    if ( header == MultiPacketResponse )
                    {
                        var copyReader = reader;
                        copyReader.ReadInt();
                        copyReader.ReadInt();
                        copyReader.ReadByte();
                        int packetCount, packetNumber;
                        reader.ReadInt();
                        if ( copyReader.ReadInt() == -1 )
                        {
                            var packetInformation = reader.ReadByte();
                            packetCount = packetInformation & 0b1111; // Reading lower 4 bits;
                            packetNumber = packetInformation >> 4;
                        }
                        else
                        {
                            packetNumber = reader.ReadByte();
                            packetCount = reader.ReadByte();
                            reader.ReadShort();
                        }
                        
                        if ( SplitPackets.IsCreated && SplitPackets.Length != packetCount )
                        {
                            for ( var i = 0; i < SplitPackets.Length; ++i )
                            {
                                if ( SplitPackets[ i ].IsCreated ) SplitPackets[ i ].Dispose();
                            }

                            SplitPackets.Dispose();
                        }
                    
                        SplitPackets = new NativeArray<NativeList<byte>>( packetCount, Allocator.Persistent );
                        var payloadPtr = ( byte* ) reader.GetUnsafeReadOnlyPtr() + reader.GetBytesRead();
                        var payloadSize = reader.Length - reader.GetBytesRead();
                        if ( !SplitPackets[ packetNumber ].IsCreated )
                        {
                            SplitPackets[ packetNumber ] = new NativeList<byte>( payloadSize, Allocator.Persistent );
                        }
                        SplitPackets[ packetNumber ].ResizeUninitialized( payloadSize );
                        UnsafeUtility.MemCpy( SplitPackets[ packetNumber ].GetUnsafePtr(), payloadPtr, payloadSize );

                        completePacket = true;
                        var sumLength = 0;
                        for ( var i = 0; i < SplitPackets.Length; ++i )
                        {
                            if ( !SplitPackets[ i ].IsCreated )
                            {
                                completePacket = false;
                            }
                            else
                            {
                                sumLength += SplitPackets[ i ].Length;
                            }
                        }
                        if ( completePacket )
                        {
                            ReceiveBuffer.ResizeUninitialized( sumLength );
                            var offset = 0;
                            for ( var i = 0; i < SplitPackets.Length; ++i )
                            {
                                UnsafeUtility.MemCpy( ReceiveBuffer.GetUnsafePtr() + offset, SplitPackets[ i ].GetUnsafeReadOnlyPtr(), SplitPackets[ i ].Length );
                                offset += SplitPackets[ i ].Length;
                            }
                        }
                    }
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
                .WithAbsent<SourceConnection>();
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

                try
                {
                    var sourceConnection = new SourceConnection( requests[ i ], SystemAPI.Time.ElapsedTime );
                    EntityManager.AddComponentData( entities[ i ], sourceConnection );
                }
                catch ( SocketException )
                {
                    EntityManager.DestroyEntity( entities[ i ] );
                }
            }
        }
    }

    internal static class QueryUtility
    {
        public static void WriteHeader( ref DataStreamWriter writer )
        {
            writer.WriteInt( -1 );
        }

        public static unsafe void ReadNullTerminatedUnsafeString<T>( ref DataStreamReader reader, ref T pOut ) where T : unmanaged, INativeList<byte>, IUTF8Bytes
        {
            reader.Flush();
            var ptr = ( byte* ) reader.GetUnsafeReadOnlyPtr() + reader.GetBytesRead();
            var dataLen = 0;
            while ( dataLen < reader.Length )
            {
                if ( ptr[ dataLen ] == 0 ) break;
                dataLen++;
            }
            reader.SeekSet( reader.GetBytesRead() + dataLen + 1 );
            pOut.TryResize( dataLen, NativeArrayOptions.UninitializedMemory );
            UnsafeUtility.MemCpy( pOut.GetUnsafePtr(), ptr, dataLen );
        }

        public static unsafe string ReadNullTerminatedString( ref DataStreamReader reader )
        {
            reader.Flush();
            var ptr = ( byte* ) reader.GetUnsafeReadOnlyPtr() + reader.GetBytesRead();
            var dataLen = 0;
            while ( dataLen < reader.Length )
            {
                if ( ptr[ dataLen ] == 0 ) break;
                dataLen++;
            }
            reader.SeekSet( reader.GetBytesRead() + dataLen + 1 );
            return Utility.Utf8NoBom.GetString( ptr, dataLen );
        }
    }
}