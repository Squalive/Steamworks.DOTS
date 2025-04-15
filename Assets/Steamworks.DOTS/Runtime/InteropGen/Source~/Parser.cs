namespace InteropGen;

public static class Parser
{
    public static string ConvertType( string type )
    {
        type = type.Replace( "class ", "" );
        type = type.Replace( "struct ", "" );

        type = type.Replace( "unsigned long long", "ulong" );
        type = type.Replace( "long long", "long" );
        type = type.Replace( "unsigned int", "uint" );
        type = type.Replace( "uint32", "uint" );
        type = type.Replace( "int32_t", "int" );
        type = type.Replace( "int64_t", "long" );
        type = type.Replace( "uint16", "ushort" );

        type = type.Replace( "CSteamID", "SteamId" );
        type = type.Replace( "CGameID", "GameId" );
        type = type.Replace( "SteamNetworkingErrMsg", "NetErrorMessage" );
        type = type.Replace( "FSteamNetworkingSocketsDebugOutput", "NetDebugFunc" );
        type = type.Replace( "ISteamNetworkingMessage", "NetMsg" );
        type = type.Replace( "SteamNetworkingMessage_t", "NetMsg" );
        
        type = type.Replace( "::", "." );
        
        return type;
    }

    public static bool ShouldCreate( string type )
    {
        if ( IsDeprecated( type ) ) return false;
        if ( type.StartsWith( "FnSteam" ) ) return false;
        if ( type == "NetMsg" ) return false;
        if ( type == "NetDebugFunc" ) return false;
        if ( type == "SteamInputActionEventCallbackPointer" ) return false;
        if ( type == "SteamNetworkingErrMsg" ) return false;
        if ( type == "gameserveritem_t" ) return false;
        if ( type == "SteamNetworkingIdentity" ) return false;
        if ( type == "SteamNetworkingIPAddr" ) return false;

        return true;
    }
    
    public static bool IsDeprecated( string name )
    {
        if ( name.StartsWith( "PS3" ) ) return true;

        if ( name == "SocketStatusCallback_t" ) return true;
        if ( name == "SNetSocketConnectionType" ) return true;
        if ( name == "SNetSocketState" ) return true;

		
        if ( name.StartsWith( "ISteamInput." ) )
        {
            if ( name.Contains( "EnableActionEventCallbacks" ) ) return true;
            if ( name.Contains( "DualSense" ) ) return true;
        }

        if ( name.StartsWith( "ISteamRemoteStorage." ) )
        {
            if ( name.Contains( "Publish" ) ) return true;
            if ( name.Contains( "ResetFileRequestState" ) ) return true;
            if ( name.Contains( "EnumerateUserSubscribedFiles" ) ) return true;
            if ( name.Contains( "EnumerateUserSharedWorkshopFile" ) ) return true;
        }

        //
        // In ISteamNetworking everything is deprecated apart from the p2p stuff
        //
        if ( name.StartsWith( "ISteamNetworking." ) )
        {
            if ( !name.Contains( "P2P" ))
                return true;
        }

        if ( name == "ISteamUGC.RequestUGCDetails" ) return true;

        return false;
    }

    public static string Expose( string type )
    {
        return "public";
    }
    
    public static string ToManagedType( string type )
    {
        type = type.Replace( "ISteamHTMLSurface::", "" );
        type = type.Replace( "class ", "" );
        type = type.Replace( "struct ", "" );
        type = type.Replace( "const void", "void" );
        type = type.Replace( "union ", "" );
        type = type.Replace( "enum ", "" );

        type = ConvertType( type );

        switch ( type )
        {
            case "uint64": return "ulong";
            case "uint32": return "uint";
            case "int32": return "int";
            case "int32_t": return "int";
            case "int64": return "long";
            case "int64_t": return "long";
            case "void *": return "IntPtr";
            case "uint8 *": return "IntPtr";
            case "int16": return "short";
            case "uint8": return "byte";
            case "int8": return "char";
            case "unsigned short": return "ushort";
            case "unsigned int": return "uint";
            case "uint16": return "ushort";
            case "const char *": return "IntPtr";
            case "_Bool": return "bool";
            case "SteamId": return "ulong";

            case "SteamAPIWarningMessageHook_t": return "IntPtr";
        }

        //type = type.Trim( '*', ' ' );

        // Enums - skip the 'E'

        if ( type.StartsWith( "ISteamMatchmak" ) && type.Contains( "Response" ) )
            return "IntPtr";

        return type;
    }
    
    public static string CleanMemberName( string m )
    {
        if ( m == "m_pubParam" ) return "ParamPtr";
        if ( m == "m_cubParam" ) return "ParamCount";
        if ( m == "m_itemId" ) return "ItemId";
        if ( m == "m_handle" ) return "Handle";
        if ( m == "m_result" ) return "Result";

        var cleanName = m.Replace( "m_un", "" )
            .Replace( "m_us", "" )
            .Replace( "m_sz", "" )
            .Replace( "m_h", "" )
            .Replace( "m_pp", "" )
            .Replace( "m_e", "" )
            .Replace( "m_un", "" )
            .Replace( "m_ul", "" )
            .Replace( "m_fl", "" )
            .Replace( "m_u", "" )
            .Replace( "m_b", "" )
            .Replace( "m_i", "" )
            .Replace( "m_pub", "" )
            .Replace( "m_cub", "" )
            .Replace( "m_n", "" )
            .Replace( "m_rgch", "" )
            .Replace( "m_r", "" )
            .Replace( "m_", "" );

        return string.Concat( cleanName[ ..1 ].ToUpper(), cleanName.AsSpan( 1 ) );
    }

    public static List<BaseType> ProcessArgs( SteamAPIDefinition def, SteamAPIDefinition.Method method )
    {
        var args = method.Params.Select( x =>
        {
            var bt = BaseType.Parse( def, x.Type, x.Name, bufferSizeName: x.OutStringCount );
            bt.Func = method.Name;
            return bt;
        } ).ToList();

        for ( var i = 0; i < args.Count; i++ )
        {
            if ( args[ i ] is not FetchStringType fetchString ) 
            {
                continue;
            }

            var bufferSizeIdx = -1;
            if ( !string.IsNullOrWhiteSpace( fetchString.BufferSizeParamName ) )
            {
                bufferSizeIdx = args.FindIndex( x => x.VarName == fetchString.BufferSizeParamName );
            }
            else if ( args[ i + 1 ] is IntType || args[ i + 1 ] is UIntType || args[ i + 1 ] is UIntPtrType ) 
            {
                bufferSizeIdx = i + 1;
            }
				
            if ( bufferSizeIdx >= 0 )
            {
                // if ( args[ bufferSizeIdx ] is not LiteralType ) 
                // {
                //     args[ bufferSizeIdx ] = new LiteralType( args[ bufferSizeIdx ], "(1024 * 32)" );
                // }
            }
            else
            {
                throw new System.Exception( $"Couldn't determine buffer size for parameter {args[ i ].VarName} in {method.FlatName}" );
            }
        }

        return args;
    }
}