namespace InteropGen;

public class StructGenerator : BaseGenerator
{
    public class TypeDef
    {
        public string Name;
        public string NativeType;
        public string ManagedType;
    }
    
    public class TypeSize
    {
        public int PrimitiveSize;
        public int NestedTypeSize;
    }
    
    protected override string Namespace => "Steamworks.Data";
    protected override string Name => "SteamStructs.cs";

    private readonly Dictionary<string, TypeDef> _typeDefs = new();

    protected override void DoGenerate( SteamAPIDefinition def )
    {
        WorkoutTypes( def );
        
        foreach ( var s in def.Structs )
        {
            var name = Parser.ConvertType( s.Name );
            if ( !Parser.ShouldCreate( name ) ) continue;
            if ( name.Contains( "::" ) ) continue;

            var partial = string.Empty;
            var hasMethods = s.Methods != null && s.Methods.Length > 0;
            if ( hasMethods ) partial = " partial";

            WriteLine( $"[ StructLayout( LayoutKind.Sequential, Pack = Platform.{( s.IsPack4OnWindows ? "StructPackSize" : "StructPlatformPackSize" )} ) ] " );
            Bracket( $"{Parser.Expose( name )} unsafe{partial} struct {name}" );
            {
                GenerateFields( s.Fields );
                WriteLine();
                if ( hasMethods )
                    GenerateFunctions( def, name, s.Methods );

                if ( s.Enums != null )
                {
                    foreach ( var e in s.Enums )
                    {
                        WriteEnum( e, e.Name );
                    }
                }
            }
            EndBracket();
            WriteLine();
        }
        
        foreach ( var callback in def.CallbackStructs )
        {
            var name = Parser.ConvertType( callback.Name );
            if ( !Parser.ShouldCreate( name ) ) continue;
            if ( name.Contains( "::" ) ) continue;

            var partial = string.Empty;
            if ( callback.Methods != null ) partial = " partial";
            var isCallback = true;
            var iface = string.Empty;
            if ( isCallback )
                iface = " : ISteamCallback";

            if ( callback.Fields == null || callback.Fields.Length == 0 )
            {
                WriteLine( $"[ StructLayout( LayoutKind.Sequential, Size = 1, Pack = Platform.{( callback.IsPack4OnWindows ? "StructPackSize" : "StructPlatformPackSize" )} ) ]" );
            }
            else
            {
                WriteLine( $"[ StructLayout( LayoutKind.Sequential, Pack = Platform.{( callback.IsPack4OnWindows ? "StructPackSize" : "StructPlatformPackSize" )} ) ]" );
            }
            Bracket( $"{Parser.Expose( name )} unsafe{partial} struct {name}{iface}" );
            {
                GenerateFields( callback.Fields );
                WriteLine();

                if ( isCallback )
                {
                    WriteLine( "#region SteamCallback" );
                    {
                        WriteLine( $"public static readonly int _datasize = UnsafeUtility.SizeOf<{name}>();" );
                        WriteLine( "public int DataSize => _datasize;" );
                        WriteLine( $"public CallbackType CallbackType => CallbackType.{name};" );
                    }
                    WriteLine( "#endregion" );
                }

                if ( callback.Enums != null )
                {
                    foreach ( var e in callback.Enums )
                    {
                        WriteEnum( e, e.Name );
                    }
                }
            }
            EndBracket();
            WriteLine();
        }
    }

    private void WorkoutTypes( SteamAPIDefinition def )
    {
        foreach ( var typeDef in def.TypeDefs )
        {
            if ( typeDef.Name.StartsWith( "uint" ) || typeDef.Name.StartsWith( "int" ) || typeDef.Name.StartsWith( "lint" ) || typeDef.Name.StartsWith( "luint" ) || typeDef.Name.StartsWith( "ulint" ) )
                continue;

            // Unused, messers
            if ( typeDef.Name == "Salt_t" || typeDef.Name == "compile_time_assert_type" || typeDef.Name == "ValvePackingSentinel_t" || typeDef.Name.Contains( "::" ) || typeDef.Type.Contains( "(*)" ) )
                continue;

            var type = typeDef.Type;

            type = Parser.ToManagedType( type );

            _typeDefs.Add( typeDef.Name, new TypeDef
            {
                Name = typeDef.Name,
                NativeType = typeDef.Type,
                ManagedType = type,
            } );
        }
    }
    
    private void GenerateFields( SteamAPIDefinition.Struct.Field[] fields )
    {
        foreach ( var f in fields )
        {
            var type = Parser.ConvertType( Parser.ToManagedType( f.Type ) );
            if ( _typeDefs.TryGetValue( type, out var def ) )
            {
                type = def.ManagedType;
            }

            if ( type == "bool" )
            {
                WriteLine( "[ MarshalAs( UnmanagedType.I1 ) ]" );
            }

            var postfix = string.Empty;
            if ( type.StartsWith( "char " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "char", "" ).Trim( '[', ']', ' ' );
                type = "fixed byte";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "uint8 " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "uint8", "" ).Trim( '[', ']', ' ' );
                type = "fixed byte";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "ushort " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "ushort", "" ).Trim( '[', ']', ' ' );
                type = "fixed ushort";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "uint32 " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "uint32", "" ).Trim( '[', ']', ' ' );
                type = "fixed uint";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "uint " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "uint", "" ).Trim( '[', ']', ' ' );
                type = "fixed uint";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "float " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "float", "" ).Trim( '[', ']', ' ' );
                type = "fixed float";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "SteamId " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "SteamId", "" ).Trim( '[', ']', ' ' );
                type = "fixed ulong";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "PublishedFileId_t " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "PublishedFileId_t", "" ).Trim( '[', ']', ' ' );
                type = "fixed ulong";
                postfix = $"[ {num} ]";
            }

            if ( type.StartsWith( "AppId_t " ) && type.Contains( "[" ) )
            {
                var num = type.Replace( "AppId_t", "" ).Trim( '[', ']', ' ' );
                type = "fixed uint";
                postfix = $"[ {num} ]";
            }

            if ( type == "const char **" )
            {
                type = "IntPtr";
            }

            if ( type == "SteamInputActionEvent_t.AnalogAction_t" )
            {
                Write( "// " );
            }
            
            WriteLine( $"public {type} {Parser.CleanMemberName( f.Name )}{postfix}; // {f.Name} {f.Type}" );
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
            
            var firstArg = $"{name}* self";

            WriteLine( $"[ DllImport( Platform.LibraryName, EntryPoint = \"{method.FlatName}\", CallingConvention = Platform.CC ) ]" );
            WriteLine( $"public static unsafe extern {returnType.TypeNameFrom} SteamAPI_{method.Name}( {firstArg}, {delegateargstr} );".Replace( $"( {firstArg},  )", $"( {firstArg} )" ) );
            WriteLine();
        }
    }
}