using System.Text;

namespace InteropGen;

public abstract class BaseGenerator
{
    protected readonly StringBuilder _sb = new();
    private int _indent = 0;
    private bool _skipIndent = false;

    public string Indent
    {
        get
        {
            if ( _skipIndent ) return string.Empty;

            return new string( '\t', _indent );
        }
    }

    protected virtual string Namespace => "Steamworks";
    protected virtual string Name => "SteamUnknown";

    public virtual void Generate( string folder, SteamAPIDefinition def )
    {
        _sb.Clear();
        Header( Namespace );
        DoGenerate( def );
        Footer();
        File.WriteAllText( $"{folder}{Name}", _sb.ToString() );
    }

    protected abstract void DoGenerate( SteamAPIDefinition def );

    public void Header( string namespaceName = "Steamworks" )
    {
        WriteLine( "using System;" );
        WriteLine( "using System.Runtime.InteropServices;" );
        WriteLine( "using System.Linq;" );
        WriteLine( "using Steamworks.Data;" );
        WriteLine( "using System.Threading.Tasks;" );
        WriteLine( "using Unity.Collections.LowLevel.Unsafe;" );
        WriteLine();
        Bracket( $"namespace {namespaceName}" );
    }

    public void Footer()
    {
        EndBracket();
    }
    
    public void WriteLine( string v = "" )
    {
        _sb.AppendLine( $"{Indent}{v}" );
        _skipIndent = false;
    }

    public void Write( string v = "" )
    {
        _sb.Append( v );
        _skipIndent = true;
    }

    public void Bracket( string v )
    {
        WriteLine( v );
        WriteLine( "{" );
        _indent++;
    }

    public void EndBracket( string v = "" )
    {
        _indent--;
        WriteLine( $"}}{v}" );
    }

    public void If( string condition )
    {
        Bracket( $"if ( {condition} )" );
    }

    public void Else()
    {
        EndBracket();
        Bracket( "else" );
    }

    public void ElseIf( string condition )
    {
        EndBracket();
        If( condition );
    }

    public void EndIf()
    {
        EndBracket();
    }

    protected void WriteEnum( SteamAPIDefinition.Enum e, string name, string type = "int" )
    {
        Bracket( $"{Parser.Expose( name )} enum {name} : {type}" );
        {
            //
            // If all the enum values start with the same 
            // string, remove it. This converts
            // "k_EUserHasLicenseResultHasLicense" to "HasLicense" etc
            //
            var iFinished = int.MaxValue;
            for ( var i = 0; i < 4096; i++ )
            {
                var c = e.Values.First().Name[ i ];
                foreach ( var entry in e.Values )
                {
                    if ( entry.Name[ i ] != c ) 
                    {
                        iFinished = i;
                        break;
                    }
                }

                if ( iFinished != int.MaxValue )
                    break;
            }

            foreach ( var pair in e.Values )
            {
                var pairName = pair.Name;
                if ( pairName.Contains( "Force32Bit" ) ) continue;
                if ( iFinished != int.MaxValue ) pairName = pairName[ iFinished.. ];
                
                //
                // Names aren't allowed to start with a number
                // So just stick the enum name on the front
                //
                if ( char.IsNumber( pairName[ 0 ] ) ) 
                {
                    var p = name;

                    if ( p == "HTTPStatusCode" ) p = "Code";
                    if ( p == "SteamIPType" ) p = "Type";

                    pairName = p + pairName;
                }

                if ( pairName.StartsWith( $"k_E{name}" ) )
                    pairName = pairName[ ( name.Length + 3 ).. ];

                WriteLine( $"{pairName.Trim( ' ', '_' )} = {pair.Value}," );
            }
        }
        EndBracket();
    }
}