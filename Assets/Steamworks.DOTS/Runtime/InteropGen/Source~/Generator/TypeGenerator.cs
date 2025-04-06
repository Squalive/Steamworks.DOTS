namespace InteropGen;

public class TypeGenerator : BaseGenerator
{
    //
    // Don't give a fuck about these types
    //
    public static readonly HashSet<string> SkipTypes =
    [
        "ValvePackingSentinel_t",
        "SteamAPIWarningMessageHook_t",
        "Salt_t",
        "SteamAPI_CheckCallbackRegistered_t",
        "compile_time_assert_type",
        "SteamErrMsg",
    ];

    //
    // Native types and function defs
    //
    public static readonly string[] SkipTypesStartingWith =
    [

        "uint",
        "int",
        "ulint",
        "lint",
        "PFN"
    ];
    
    protected override string Namespace => "Steamworks.Data";
    protected override string Name => "SteamTypes.cs";

    protected override void DoGenerate( SteamAPIDefinition def )
    {
        foreach ( var typeDef in def.TypeDefs.Where( x => !x.Name.Contains( "::" ) ) )
        {
            if ( !Parser.ShouldCreate( typeDef.Name ) ) continue;
            var typeName = Parser.ConvertType( typeDef.Name );
            if ( !Parser.ShouldCreate( typeName ) ) continue;
            if ( SkipTypes.Contains( typeName ) ) continue;
            if ( SkipTypesStartingWith.Any( x => typeDef.Name.StartsWith( x ) ) ) continue;

            Bracket( $"{Parser.Expose( typeName )} struct {typeName} : IEquatable<{typeName}>, IComparable<{typeName}>" );
            {
                WriteLine( $"// typedef: {typeDef.Name}, type: {typeDef.Type}" );

                var managedType = Parser.ToManagedType( typeDef.Type );
                if ( typeDef.Type == "char [1024]" )
                {
                    WriteLine( $"public fixed char[1024] Value;" );
                }
                else
                {
                    WriteLine( $"public {managedType} Value;" );
                }
                
                WriteLine();
                WriteLine( $"public static implicit operator {typeName}( {managedType} value ) => new {typeName}(){{ Value = value }};" );
                WriteLine( $"public static implicit operator {managedType}( {typeName} value ) => value.Value;" );
                WriteLine( $"public override string ToString() => Value.ToString();" );
                WriteLine( $"public override int GetHashCode() => Value.GetHashCode();" );
                WriteLine( $"public override bool Equals( object p ) => this.Equals( ( {typeName} ) p );" );
                WriteLine( $"public bool Equals( {typeName} p ) => p.Value == Value;" );
                WriteLine( $"public static bool operator ==( {typeName} a, {typeName} b ) => a.Equals( b );" );
                WriteLine( $"public static bool operator !=( {typeName} a, {typeName} b ) => !a.Equals( b );" );

                if ( managedType == "IntPtr" )
                    WriteLine( $"public int CompareTo( {typeName} other ) => Value.ToInt64().CompareTo( other.Value.ToInt64() );" );
                else
                    WriteLine( $"public int CompareTo( {typeName} other ) => Value.CompareTo( other.Value );" );
            }
            EndBracket();
            WriteLine();
        }
    }
}