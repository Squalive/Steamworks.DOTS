namespace InteropGen;

public class EnumGenerator : BaseGenerator
{
    protected override string Name => "SteamEnums.cs";

    protected override void DoGenerate( SteamAPIDefinition def )
    {
        foreach ( var e in def.Enums )
        {
            WriteLine( "///" );
            WriteLine( $"/// {e.Name}" );
            WriteLine( "///" );
            var name = e.Name;
            // We're not interested in namespacing
            if ( name.Contains( "::" ) ) name = e.Name[ ( e.Name.LastIndexOf( ':' ) + 1 ).. ];
            name = Parser.ConvertType( name );
            if ( !Parser.ShouldCreate( name ) ) continue;
            
            var highest = e.Values.Max( x => long.Parse( x.Value ) );

            var type = "int";
            if ( highest > int.MaxValue ) type = "uint";

            WriteEnum( e, name, type );
            WriteLine();
        }
    }
}