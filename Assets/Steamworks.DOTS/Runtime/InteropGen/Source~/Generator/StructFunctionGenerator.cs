namespace InteropGen;

public class StructFunctionGenerator : BaseGenerator
{
    protected override string Namespace => "Steamworks.Data";
    protected override string Name => "SteamStructFunctions.cs";
    protected override void DoGenerate( SteamAPIDefinition def )
    {
        foreach ( var s in def.Structs.Union( def.CallbackStructs.Select( SteamAPIDefinition.Struct ( x ) => x ) ).OrderBy( x => x.Name ) )
        {
            var name = Parser.ConvertType( s.Name );
            if ( name.Contains( "::" ) ) continue;
            if ( s.Methods == null || s.Methods.Length == 0 ) continue;

            Bracket( $"{Parser.Expose( name )} partial struct {name}" );
            GenerateFunctions( def, name, s.Methods );
            EndBracket();
            WriteLine();
        }
    }

    private void GenerateFunctions( SteamAPIDefinition def, string name, SteamAPIDefinition.Method[] methods )
    {
        foreach ( var method in methods )
        {
            if ( method.Name.Contains( "operator" ) )
                method.Name = method.FlatName[ ( method.FlatName.LastIndexOf( '_' ) + 1 ).. ];
            
            var returnType = BaseType.Parse( def, method.ReturnType, null, method.CallResult );
            returnType.Func = method.Name;

            var args = Parser.ProcessArgs( def, method );
            var delegateargstr = string.Join( ", ", args.Select( x => x.AsNativeArgument() ) );
            
            if ( !string.IsNullOrEmpty( method.Desc ) )
            {
                WriteLine( "/// <summary>" );
                WriteLine( $"/// {method.Desc}" );
                WriteLine( "/// </summary>" );
            }

            if ( returnType.ReturnAttribute != null )
                WriteLine( returnType.ReturnAttribute );
            
            var firstArg = $"ref {name} self";

            WriteLine( $"[ DllImport( Platform.LibraryName, EntryPoint = \"{method.FlatName}\", CallingConvention = Platform.CC ) ]" );
            WriteLine( $"public static unsafe extern {returnType.TypeNameFrom} SteamAPI_{method.Name}( {firstArg}, {delegateargstr} );".Replace( $"( {firstArg},  )", $"( {firstArg} )" ) );
            WriteLine();
        }
    }
}