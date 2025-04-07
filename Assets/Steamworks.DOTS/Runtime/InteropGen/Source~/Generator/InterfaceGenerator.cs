namespace InteropGen;

public class InterfaceGenerator : BaseGenerator
{
    protected override void DoGenerate( SteamAPIDefinition def ) { }
    public override void Generate( string folder, SteamAPIDefinition def )
    {
        folder = $"{folder}Interfaces/";
        Directory.CreateDirectory( folder );
        foreach ( var i in def.Interfaces )
        {
            _sb.Clear();
            Header();
            GenerateInterface( def, i );
            Footer();
            File.WriteAllText( $"{folder}{i.Name}.cs", _sb.ToString() );
        }
    }

    private void GenerateInterface( SteamAPIDefinition def, SteamAPIDefinition.Interface i )
    {
        Bracket( $"internal unsafe partial struct {i.Name}" );
        {
            var versionStr = i.VersionString;
            if ( i.Name == "ISteamClient" ) versionStr = "SteamClient021";
            if ( !string.IsNullOrWhiteSpace( versionStr ) )
            {
                WriteLine( $"public const string Version = \"{versionStr}\";" );
                WriteLine();
            }

            WriteLine( "[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;" );

            var userAccessor = string.Empty;
            var gameServerAccessor = string.Empty;
            var globalAccessor = string.Empty;
            if ( i.Accessors != null )
            {
                foreach ( var accessor in i.Accessors )
                {
                    WriteLine( $"[ DllImport( Platform.LibraryName, EntryPoint = \"{accessor.FlatName}\", CallingConvention = Platform.CC ) ]" );
                    WriteLine( $"public static extern IntPtr {accessor.FlatName}();" );

                    if ( accessor.Kind == "user" )
                    {
                        userAccessor = accessor.FlatName;
                    }
                    else if ( accessor.Kind == "gameserver" )
                    {
                        gameServerAccessor = accessor.FlatName;
                    }
                    else if ( accessor.Kind == "global" )
                    {
                        globalAccessor = accessor.FlatName;
                    }
                    else
                    {
                        throw new Exception( $"unknown Kind {accessor.Kind}" );
                    }
                }
            }

            // Constructor
            WriteLine( "/// Construct use accessor to find interface" );
            Bracket( $"public {i.Name}( bool isGameServer )" );
            {
                WriteLine( "Self = IntPtr.Zero;" );
                if ( !string.IsNullOrEmpty( globalAccessor ) )
                {
                    WriteLine( $"Self = {globalAccessor}();" );
                }
                else
                {
                    if ( !string.IsNullOrEmpty( userAccessor ) )
                    {
                        If( "!isGameServer" );
                        WriteLine( $"Self = {userAccessor}();" );
                        EndIf();
                    }

                    if ( !string.IsNullOrEmpty( gameServerAccessor ) )
                    {
                        If( "isGameServer" );
                        WriteLine( $"Self = {gameServerAccessor}();" );
                        EndIf();
                    }
                }
            }
            EndBracket();

            Bracket( $"public {i.Name}( IntPtr iface )" );
            WriteLine( "Self = iface;" );
            EndBracket();

            foreach ( var method in i.Methods )
            {
                if ( Parser.IsDeprecated( $"{i.Name}.{method.Name}" ) ) continue;

                WriteFunction( def, i, method );
                WriteLine();
            }
        }
        EndBracket();
    }

    private void WriteFunction( SteamAPIDefinition def, SteamAPIDefinition.Interface i, SteamAPIDefinition.Method method )
    {
        var returnType = BaseType.Parse( def, method.ReturnType, null, method.CallResult );
        returnType.Func = method.Name;
        if ( method.Params == null ) method.Params = [ ];

        var args = Parser.ProcessArgs( def, method );
        var argstr = string.Join( ", ", args.Where( x => !x.ShouldSkipAsArgument ).Select( x => x.AsArgument() ) ); ;
        var delegateargstr = string.Join( ", ", args.Select( x => x.AsNativeArgument() ) );
        
        WriteLine( $"#region {method.FlatName}" );
        WriteLine( $"[ DllImport( Platform.LibraryName, EntryPoint = \"{method.FlatName}\", CallingConvention = Platform.CC ) ]" );
        if ( returnType.ReturnAttribute != null )
            WriteLine( returnType.ReturnAttribute );
        WriteLine( $"internal static extern {returnType.TypeNameFrom} _{method.FlatName}( IntPtr self, {delegateargstr} );".Replace( "( IntPtr self,  )", "( IntPtr self )" ) );
        var nativeCallargs = string.Join( ", ", args.Select( x => x.AsNativeCallArgument() ) );
        WriteLine( $"internal {returnType.TypeNameFrom} _{method.Name}( {delegateargstr} ) => _{method.FlatName}( Self, {nativeCallargs} );".Replace( "( Self,  )", "( Self )" ) );
        WriteLine( $"#endregion" );
        
        if ( !string.IsNullOrEmpty( method.Desc ) )
        {
            WriteLine( "/// <summary>" );
            WriteLine( $"/// {method.Desc}" );
            WriteLine( "/// </summary>" );
        }

        Bracket( $"internal {returnType.ReturnType} {method.Name}( {argstr} )".Replace( "(  )", "()" ) );
        {
            var callargs = string.Join( ", ", args.Select( x => x.AsCallArgument() ) );
            
            //
            // Code before any calls
            //
            foreach ( var arg in args )
            {
                if ( arg is ConstCharType str )
                {
                    WriteLine( $"using var str__{str.VarName} = new Utf8StringToNative( {str.VarName} );" );
                }
                else if ( arg is FetchStringType sb )
                {
                    WriteLine( $"using var mem__{sb.VarName} = new Utility.Memory( Utility.MemoryBufferSize );" );
                }
            }
            
            if ( returnType.IsVoid )
            {
                WriteLine( $"_{method.FlatName}( Self, {callargs} );".Replace( "( Self,  )", "( Self )" ) );
            }
            else
            {
                WriteLine( $"var returnValue = _{method.FlatName}( Self, {callargs} );".Replace( "( Self,  )", "( Self )" ) );
            }

            //
            // Code after the call
            //
            foreach ( var arg in args )
            {
                if ( arg is FetchStringType sb )
                {
                    WriteLine( $"{sb.VarName} = Utility.MemoryToString( mem__{sb.VarName} );" );
                }
            }
            
            //
            // Return
            //
            if ( !returnType.IsVoid )
            {
                WriteLine( returnType.Return( "returnValue" ) );
            }
        }
        EndBracket();
    }
}