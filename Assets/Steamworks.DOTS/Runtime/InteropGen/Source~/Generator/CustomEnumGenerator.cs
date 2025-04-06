namespace InteropGen;

public class CustomEnumGenerator : BaseGenerator
{
    protected override string Name => "SteamCustomEnums.cs";

    protected override void DoGenerate( SteamAPIDefinition def )
    {
        Bracket( "public enum CallbackType" );
        foreach ( var callBackStruct in def.CallbackStructs.OrderBy( x => x.CallbackId ) )
        {
            if ( Parser.IsDeprecated( callBackStruct.Name ) )
                Write( "// " );

            WriteLine( $"{callBackStruct.Name} = {callBackStruct.CallbackId}," );
        }
        EndBracket(  );
    }
}