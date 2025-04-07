namespace InteropGen;

public class RegisterCallbackTypeGenerator : BaseGenerator
{
    protected override string Name => "SteamCallbacks.cs";

    public override void Generate( string folder, SteamAPIDefinition def )
    {
        _sb.Clear();
        WriteLine( "using Steamworks;" );
        WriteLine( "using Steamworks.Data;" );
        WriteLine( "using Unity.Entities;" );
        foreach ( var callback in def.CallbackStructs )
        {
            if ( Parser.IsDeprecated( callback.Name ) )
                Write( "// " );
            
            WriteLine( $"[ assembly: RegisterGenericComponentType( typeof( SteamCallback<{callback.Name}> ) ) ]" );
        }
        File.WriteAllText( $"{folder}{Name}", _sb.ToString() );
    }

    protected override void DoGenerate( SteamAPIDefinition def ) { }
}