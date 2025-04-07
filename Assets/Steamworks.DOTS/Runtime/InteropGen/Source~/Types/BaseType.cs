namespace InteropGen;

public class BaseType
{
    public string VarName;
    public string NativeType;
    public virtual string TypeName => $"{NativeType}";

    public virtual string TypeNameFrom
    {
        get
        {
            return TypeName;
        }
    }

    public virtual bool IsVoid => false;

    public string Func;

    public virtual bool ShouldSkipAsArgument => false;
    public virtual string AsNativeArgument() => AsArgument();

    public virtual string AsArgument()
    {
        if ( IsVector )
        {
            return $"{Ref}{TypeName.Trim( '*', ' ', '&' )}* {VarName}";
        }

        return TreatAsPointer
            ? $"{Ref}{TypeName}{new string( '*', NativeType.Count( c => c == '*' ) )} {VarName}"
            : $"{Ref}{TypeName.Trim( '*', ' ', '&' )} {VarName}";
    }
    
    public virtual string AsCallArgument() => $"{Ref}{VarName}";

    public virtual string Return( string varname ) => $"return {varname};";
    public virtual string ReturnAttribute => null;

    public virtual string ReturnType => TypeName;

    public virtual string Ref => !TreatAsPointer && !IsVector && NativeType.EndsWith( "*" ) || NativeType.EndsWith( "**" ) || NativeType.Contains( "&" ) ? "ref " : "";
	
    public virtual bool IsVector
    {
        get
        {
            if ( TreatAsPointer ) return false;

            if ( Func == "ReadP2PPacket" ) return false;
            if ( Func == "SendP2PPacket" ) return false;
            if ( VarName == "pOutMessageNumber" ) return false;
            if ( VarName == "pOptions" ) return true;
            if ( VarName == "pLanes" ) return true;
            if ( VarName == "pLanePriorities" ) return true;
            if ( VarName == "pLaneWeights" ) return true;

            if ( VarName == "pOut" ) return false;
            if ( VarName == "pOutBuffer" ) return false;
            if ( VarName == "pubRGB" ) return false;
            if ( VarName == "pOutResultHandle" ) return false;
            if ( VarName == "pOutDataType" ) return false;

            if ( VarName == "psteamIDClans" ) return true;
            if ( VarName == "pScoreDetails" ) return true;
            if ( VarName == "prgUsers" ) return true;
            if ( VarName == "pBasePrices" ) return true;
            if ( VarName == "pCurrentPrices" ) return true;
            if ( VarName == "pItemDefIDs" ) return true;
            if ( VarName == "handlesOut" ) return true;
            if ( VarName == "pDetails" && Func == "GetDownloadedLeaderboardEntry" ) return true;
            if ( VarName == "pData" && NativeType.EndsWith( "*" ) && Func.StartsWith( "GetGlobalStatHistory" ) ) return true;
            if ( NativeType.EndsWith( "**" ) ) return true;
            if ( VarName.StartsWith( "pArray" ) ) return true;
            if ( VarName.StartsWith( "punArray" ) ) return true;

            if ( NativeType.EndsWith( "*" ) )
            {
                if ( VarName.StartsWith( "pvec" ) ) return true;
                if ( VarName.StartsWith( "pub" ) ) return true;
                if ( VarName.StartsWith( "pOut" ) ) return true;
            }

            return false;
        }
    }

    public virtual bool TreatAsPointer => VarName == "pOutMessageNumberOrResult";

    public static BaseType Parse( SteamAPIDefinition def, string type, string varname = null, string callresult = null, string bufferSizeName = null )
    {
        type = Parser.ConvertType( type );
        
        var typeNoSpaces = type.Replace( " ", "" );
        if ( varname == "ppOutMessages" ) return new IntPtrType { NativeType = "void *", VarName = varname };
        if ( type == "SteamAPIWarningMessageHook_t" ) return new IntPtrType { NativeType = type, VarName = varname };
        if ( typeNoSpaces == "MatchMakingKeyValuePair**") return new IntPtrType { NativeType = "MatchMakingKeyValuePair_t", VarName = varname };
        
        if ( type == "SteamAPICall_t" ) return new SteamAPICallType { NativeType = type, VarName = varname, CallResult = callresult };
        
        if ( type == "void" ) return new VoidType { NativeType = type, VarName = varname };
        if ( type.Replace( " ", "" ).StartsWith( "constchar*" ) ) return new ConstCharType { NativeType = type, VarName = varname };
        if ( type == "char *" ) return new FetchStringType { NativeType = type, VarName = varname, BufferSizeParamName = bufferSizeName };
        
        var basicType = type.Replace( "const ", "" ).Trim( ' ', '*', '&' );
        
        if ( basicType == "void" ) return new IntPtrType { NativeType = type, VarName = varname };
        if ( basicType.StartsWith( "ISteam" ) ) return new IntPtrType { NativeType = type, VarName = varname };
        if ( basicType == "const void" ) return new IntPtrType { NativeType = type, VarName = varname };
        if ( basicType == "int32" || basicType == "int" ) return new IntType { NativeType = type, VarName = varname };
        if ( basicType == "uint" ) return new UIntType { NativeType = type, VarName = varname };
        if ( basicType == "uint8" ) return new UInt8Type { NativeType = type, VarName = varname };
        if ( basicType == "uint16" ) return new UInt16Type { NativeType = type, VarName = varname };
        if ( basicType == "unsigned short" ) return new UInt16Type { NativeType = type, VarName = varname };
		
        // DANGER DANGER Danger
        if ( basicType == "intptr_t" ) return new IntPtrType { NativeType = type, VarName = varname };
        if ( basicType == "size_t" ) return new UIntPtrType { NativeType = type, VarName = varname };

        if ( basicType == "uint64" ) return new ULongType { NativeType = type, VarName = varname };
        if ( basicType == "int64" ) return new LongType { NativeType = type, VarName = varname };
        if ( basicType == "bool" ) return new BoolType { NativeType = type, VarName = varname };

        //
        // Structs are generally sent as plain old data, but need marshalling if they're expected as a pointer
        //
        if ( def.IsStruct( basicType ) )
        {
            return new StructType { NativeType = type, VarName = varname, StructName = basicType };
        }

        //
        // c# doesn't really have typerdefs, so we convert things like HSteamUser into structs
        // which from a memory point of view behave in the same way.
        //
        if ( def.IsTypeDef( basicType ) )
        {
            return new StructType { NativeType = type, VarName = varname, StructName = basicType };
        }
        
        return new BaseType { NativeType = type, VarName = varname };
    }
}

public class BoolType : BaseType
{
    public override string TypeName => $"bool";
    public override string AsArgument() => $"[ MarshalAs( UnmanagedType.U1 ) ] {Ref}{TypeName} {VarName}";
    public override string ReturnAttribute => "[ return: MarshalAs( UnmanagedType.I1 ) ]";
}

public class IntType : BaseType
{
    public override string TypeName => "int";
}

public class UIntType : BaseType
{
    public override string TypeName => "uint";
}

public class UInt8Type : BaseType
{
    public override string TypeName => "byte";
}

public class UInt16Type : BaseType
{
    public override string TypeName => "ushort";
}

public class UIntPtrType : BaseType
{
    public override string TypeName => "UIntPtr";
}

public class IntPtrType : BaseType
{
    public override string TypeName => "IntPtr";
    public override string Ref => "";
}

public class ULongType : BaseType
{
    public override string TypeName => "ulong";
}

public class LongType : BaseType
{
    public override string TypeName => "long";
}


/// <summary>
/// Nothing - just priny void
/// </summary>
public class VoidType : BaseType
{
    public override string TypeName => $"void";
    public override string TypeNameFrom => $"void";
    public override string Return( string varname ) => "";
    public override bool IsVoid => true;
}

public class ConstCharType : BaseType
{
    public override string TypeName => $"string";
    public override string TypeNameFrom => $"Utf8StringPtr";
    public override string AsArgument() => $"{Ref}string {VarName}";
    public override string AsNativeArgument() => $"{Ref}IntPtr {VarName}";
    public override string AsCallArgument() => $"str__{VarName}.Pointer";
    public override string Ref => "";
}

internal class FetchStringType : BaseType
{
    public string BufferSizeParamName; // optional, use next parameter if not set
    public override string TypeName => $"string";
    public override string AsArgument() => $"out string {VarName}";

    public override string AsNativeArgument() => $"IntPtr {VarName}";

    public override string AsCallArgument() => $"mem__{VarName}.Ptr";
    public override string Ref => "";
}