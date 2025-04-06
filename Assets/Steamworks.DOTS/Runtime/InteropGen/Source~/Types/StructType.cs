namespace InteropGen;

internal class StructType : BaseType
{
    public string StructName;

    public override string TypeName => IsPointer && TreatAsPointer ? StructName + PointerSuffix : StructName;

    public override string TypeNameFrom => IsPointer && !TreatAsPointer ? "IntPtr" : TypeName;

    public override string AsArgument() => IsPointer && TreatAsPointer ? $"{TypeName} {VarName}" : base.AsArgument();

    public override string AsCallArgument() => IsPointer && TreatAsPointer ? VarName : base.AsCallArgument();

    public override bool TreatAsPointer => StructName == "NetMsg";

    public bool IsPointer => NativeType.EndsWith( "*" );

    public override string Return( string varname )
    {
        if ( IsPointer && !TreatAsPointer )
        {
            return $"return UnsafeUtility.AsRef<{TypeName}>( ( void* ) {varname} );";
        }

        return base.Return( varname );
    }

    private string PointerSuffix => new string( '*', NativeType.Count( c => c == '*' ) );
}