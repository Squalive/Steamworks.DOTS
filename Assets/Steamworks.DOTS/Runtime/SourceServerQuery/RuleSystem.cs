using System;
using System.Net.Sockets;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks.SourceServerQuery
{
    public struct RequestRules : IComponentData
    {
        
    }
    
    internal enum RuleState : int
    {
        RequestingChallenge = 0,
        RequestedChallenge,
        RequestingRules,
        RequestedRules,
        ReceivedRules
    }
    
    internal struct RulesCurrentState : IComponentData
    {
        public RuleState Value;
    }
    
    [ UpdateInGroup( typeof( SourceServerQuerySystemGroup ) ) ]
    [ RequireMatchingQueriesForUpdate ]
    internal partial class RuleSystem : SystemBase
    {
        private EntityQuery _activeQuery;
        private EntityQuery _unfinalizedQuery;

        private ComponentTypeSet _finalizedTypeSet;

        private NativeArray<byte> _buffer;
        
        protected override void OnCreate()
        {
            var builder = new EntityQueryBuilder( Allocator.Temp )
                .WithAll<Request, RequestRules, RulesCurrentState, Connection>();
            _activeQuery = GetEntityQuery( builder );

            builder.Reset()
                .WithAll<Request, RequestRules>()
                .WithNone<RulesCurrentState>();
            _unfinalizedQuery = GetEntityQuery( builder );

            _finalizedTypeSet = new ComponentTypeSet( ComponentType.ReadWrite<RulesCurrentState>() );

            _buffer = new NativeArray<byte>( 1024 * 10, Allocator.Persistent );
        }

        protected override void OnDestroy()
        {
            _buffer.Dispose();
        }

        protected override void OnUpdate()
        {
            if ( !_unfinalizedQuery.IsEmptyIgnoreFilter )
            {
                EntityManager.AddComponent( _unfinalizedQuery, _finalizedTypeSet );
            }

            if ( !_activeQuery.IsEmptyIgnoreFilter )
            {
                var entities = _activeQuery.ToEntityArray( Allocator.Temp );
                var currentStates = _activeQuery.ToComponentDataArray<RulesCurrentState>( Allocator.Temp );
                for ( var i = 0; i < entities.Length; ++i )
                {
                    var corrupted = false;
                    var entity = entities[ i ];
                    var state = currentStates[ i ];
                    var connection = EntityManager.GetComponentData<Connection>( entity );
                    if ( SystemAPI.Time.ElapsedTime - connection.LastAckTime >= 15.0 )
                    {
                        corrupted = true;
                    }
                    
                    switch ( state.Value )
                    {
                        case RuleState.RequestingChallenge:
                            var writer = new DataStreamWriter( _buffer );
                            QueryUtility.WriteHeader( ref writer );
                            writer.WriteByte( 0x56 );
                            writer.WriteInt( -1 );
                            connection.Send( writer );
                            state.Value = RuleState.RequestedChallenge;
                            connection.LastAckTime = SystemAPI.Time.ElapsedTime;    
                            break;
                        case RuleState.RequestedChallenge:
                            if ( connection.Receive( _buffer ) )
                            {
                                
                            }
                            
                            break;
                    }

                    if ( corrupted )
                    {
                        EntityManager.DestroyEntity( entity );
                        continue;
                    }
                    
                    if ( currentStates[ i ].Value != state.Value ) EntityManager.SetComponentData( entity, state );
                }
            }
        }
    }
}