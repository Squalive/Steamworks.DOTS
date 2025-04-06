// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

namespace InteropGen;

public static class Program
{
    public static void Main( string[] args )
    {
        const string parserPath = "steam/steam_api.json";
        var toFolder = "Generated/";

        if ( !File.Exists( parserPath ) )
        {
            Console.WriteLine( $"Parser file doesnt exist at {parserPath}" );
            return;
        }

        var definitions = JsonConvert.DeserializeObject<SteamAPIDefinition>( File.ReadAllText( parserPath ) );
        if ( definitions == null ) return;

        for ( var i = 0; i < args.Length; ++i )
        {
            var arg = args[ i ];
            if ( arg.StartsWith( "--path=" ) )
            {
                toFolder = arg[ 7.. ];
            }
        }

        var composites = new CompositeGenerator();
        composites.Add<ConstantGenerator>();
        composites.Add<TypeGenerator>();
        composites.Add<StructGenerator>();
        composites.Add<EnumGenerator>();
        composites.Add<CustomEnumGenerator>();
        composites.Add<InterfaceGenerator>();

        Directory.CreateDirectory( toFolder );

        composites.Generate( toFolder, definitions );
    }
}