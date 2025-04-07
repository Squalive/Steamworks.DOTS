namespace InteropGen;

public class ConstantGenerator : BaseGenerator
{
    protected override string Namespace => "Steamworks.Data";
    protected override string Name => "SteamConstants.cs";

    protected override void DoGenerate( SteamAPIDefinition def )
    {
        Bracket( "internal static class Defines" );
        WriteLine( $"public const int NumCallbacks = {def.CallbackStructs.Length};" );
        foreach ( var constant in def.Constants )
        {
            var type = Parser.ConvertType( constant.Type );
            var value = constant.Value;
            
            // Don't need to ull in c#
            if ( value.EndsWith( "ull" ) )
                value = value.Replace( "ull", "" );

            if ( value.EndsWith( ".f" ) )
                value = value.Replace( ".f", ".0f" );
            
            value = value.Replace( "uint32", "uint" );
            value = value.Replace( "16U", "16" );
            value = value.Replace( "8U", "8" );
            
            // we're not an actual typedef so can't cast like this
            value = value.Replace( "( SteamItemInstanceID_t ) ~ 0", "~default( ulong )" );

            // This is defined as 0xffffffff - which is too big for an int
            // It seems like the loop around is required, so we just hard code it
            if ( constant.Name == "HSERVERQUERY_INVALID" && value == "0xffffffff" )
                value = "-1";
            
            WriteLine( $"public static readonly {type} {constant.Name} = {value};" );
        }
        EndBracket();
    }
}