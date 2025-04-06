namespace InteropGen;

public class CompositeGenerator : BaseGenerator
{
    private readonly List<BaseGenerator> _composites = [ ];

    public void Add( BaseGenerator generator )
    {
        _composites.Add( generator );
    }

    public void Add<T>() where T : BaseGenerator, new()
    {
        Add( new T() );
    }

    public override void Generate( string folder, SteamAPIDefinition def )
    {
        foreach ( var generator in _composites )
        {
            generator.Generate( folder, def );
        }
    }

    protected override void DoGenerate( SteamAPIDefinition def )
    {
        
    }
}