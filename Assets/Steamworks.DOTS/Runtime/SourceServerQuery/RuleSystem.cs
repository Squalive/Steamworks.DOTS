using Unity.Collections;
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
        RequestedRules,
        ReceivedRules
    }
    
    internal struct RulesCurrentState : IComponentData
    {
        public RuleState Value;
    }

    public struct Rules : IBufferElementData
    {
        public FixedString128Bytes Name;
        public FixedString512Bytes Value;
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
                .WithAll<Request, RequestRules, RulesCurrentState, SourceConnection>();
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
                    var connection = EntityManager.GetComponentData<SourceConnection>( entity );
                    if ( SystemAPI.Time.ElapsedTime - connection.LastAckTime >= 30.0 )
                    {
                        corrupted = true;
                    }
                    
                    switch ( state.Value )
                    {
                        case RuleState.RequestingChallenge :
                        {
                            var writer = new DataStreamWriter( _buffer );
                            QueryUtility.WriteHeader( ref writer );
                            writer.WriteByte( 0x55 );
                            writer.WriteInt( -1 );
                            connection.Send( writer );
                            state.Value = RuleState.RequestedChallenge;
                            connection.LastAckTime = SystemAPI.Time.ElapsedTime;    
                            break;
                        }
                        case RuleState.RequestedChallenge :
                        {
                            if ( connection.Receive( _buffer ) )
                            {
                                var reader = connection.ReceiveReader;
                                var header = reader.ReadByte();
                                if ( header != 0x41 )
                                {
                                    corrupted = true;
                                    break;
                                }
                                var challenge = reader.ReadInt();
                                var writer = new DataStreamWriter( _buffer );
                                QueryUtility.WriteHeader( ref writer );
                                writer.WriteByte( 0x56 );
                                writer.WriteInt( challenge );
                                connection.Send( writer );
                                state.Value = RuleState.RequestedRules;
                                connection.LastAckTime = SystemAPI.Time.ElapsedTime;    
                            }
                            break;
                        }
                        case RuleState.RequestedRules :
                        {
                            if ( connection.Receive( _buffer ) )
                            {
                                var reader = connection.ReceiveReader;
                                var header = reader.ReadByte();
                                if ( header != 0x45 )
                                {
                                    corrupted = true;
                                    break;
                                }

                                var rules = EntityManager.AddBuffer<Rules>( entity );
                                var numRules = reader.ReadShort();
                                for ( var ruleIdx = 0; ruleIdx < numRules; ++ruleIdx )
                                {
                                    rules.Add( new Rules() );
                                    QueryUtility.ReadNullTerminatedUnsafeString( ref reader, ref rules.ElementAt( ruleIdx ).Name );
                                    QueryUtility.ReadNullTerminatedUnsafeString( ref reader, ref rules.ElementAt( ruleIdx ).Value );
                                }
                                state.Value = RuleState.ReceivedRules;
                            }
                            break;
                        }
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