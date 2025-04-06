using Newtonsoft.Json;

namespace InteropGen;

public class SteamAPIDefinition
{
    public class Const
    {
        [ JsonProperty( propertyName: "constname" ) ]
        public string Name { get; set; }
        [ JsonProperty( propertyName: "consttype" ) ]
        public string Type { get; set; }
        [ JsonProperty( propertyName: "constval" ) ]
        public string Value { get; set; }
    }

    public class Enum
    {
        public class Pair
        {
            [ JsonProperty( propertyName: "name" ) ]
            public string Name { get; set; }
            [ JsonProperty( propertyName: "value" ) ]
            public string Value { get; set; }
        }
        
        [ JsonProperty( propertyName: "enumname" ) ]
        public string Name { get; set; }
        
        [ JsonProperty( propertyName: "values" ) ]
        public Pair[] Values { get; set; }
    }
    
    public class Param
    {
        [ JsonProperty( propertyName: "paramname" )  ]
        public string Name { get; set; }
        [ JsonProperty( propertyName: "paramtype" )  ]
        public string Type { get; set; }
            
        [ JsonProperty( PropertyName = "out_string_count" ) ]
        public string OutStringCount { get; set; }
    }
        
    public class Method
    {
        [ JsonProperty( propertyName: "methodname" ) ]
        public string Name { get; set; }
        [ JsonProperty( propertyName: "methodname_flat" ) ]
        public string FlatName { get; set; }
        [ JsonProperty( propertyName: "params" ) ]
        public Param[] Params { get; set; }
        [ JsonProperty( propertyName: "returntype" ) ]
        public string ReturnType { get; set; }
        [ JsonProperty( propertyName: "desc" ) ]
        public string Desc { get; set; }
        [ JsonProperty( propertyName: "callresult" ) ]
        public string CallResult { get; set; }
    }
    
    public class Interface
    {
        public class Accessor
        {
            [ JsonProperty( propertyName: "kind" ) ]
            public string Kind { get; set; }
            [ JsonProperty( propertyName: "name" ) ]
            public string Name { get; set; }
            [ JsonProperty( propertyName: "name_flat" ) ]
            public string FlatName { get; set; }
        }
        
        [ JsonProperty( propertyName: "classname" ) ]
        public string Name { get; set; }

        [ JsonProperty( propertyName: "version_string" ) ]
        public string VersionString { get; set; }
        
        [ JsonProperty( propertyName: "methods" ) ]
        public Method[] Methods { get; set; }
        
        [ JsonProperty( propertyName: "accessors" ) ]
        public Accessor[] Accessors { get; set; }
    }

    public class Struct
    {
        public class Field
        {
            [ JsonProperty( propertyName: "fieldname" ) ]
            public string Name { get; set; }
            [ JsonProperty( propertyName: "fieldtype" ) ]
            public string Type { get; set; }
            [ JsonProperty( propertyName: "private" ) ]
            public bool Private { get; set; }
        }

        [ JsonProperty( propertyName : "struct" ) ]
        public string Name { get; set; }
        [ JsonProperty( propertyName : "fields" ) ]
        public Field[] Fields { get; set; }
        [ JsonProperty( propertyName : "methods" ) ]
        public Method[] Methods { get; set; }

        [ JsonProperty( propertyName : "enums" ) ]
        public Enum[] Enums { get; set; }

        public bool IsPack4OnWindows
        {
            get
            {
                // 4/8 packing is irrevant to these classes
                if ( Name.Contains( "MatchMakingKeyValuePair_t" ) ) return true;

                if ( Fields.Skip( 1 ).Any( x => x.Type.Contains( "CSteamID" ) ) )
                    return true;

                if ( Fields.Skip( 1 ).Any( x => x.Type.Contains( "CGameID" ) ) )
                    return true;

                return false;
            }
        }
    }
    
    public class CallbackStruct : Struct
    {
        [ JsonProperty( propertyName: "callback_id" ) ]
        public int CallbackId { get; set; }
    }

    public class TypeDef
    {
        [ JsonProperty( propertyName: "typedef" ) ]
        public string Name { get; set; }
        [ JsonProperty( propertyName: "type" ) ]
        public string Type { get; set; }
    }
    
    [ JsonProperty( propertyName: "callback_structs" ) ]
    public CallbackStruct[] CallbackStructs { get; set; }

    [ JsonProperty( propertyName: "consts" ) ]
    public Const[] Constants { get; set; }
    
    [ JsonProperty( propertyName: "enums" ) ]
    public Enum[] Enums { get; set; }
    
    [ JsonProperty( propertyName: "interfaces" ) ]
    public Interface[] Interfaces { get; set; }
    
    [ JsonProperty( propertyName: "structs" ) ]
    public Struct[] Structs { get; set; }
    
    [ JsonProperty( propertyName: "typedefs" ) ]
    public TypeDef[] TypeDefs { get; set; }
    
    public bool IsStruct( string name )
    {
        if ( Structs.Any( x => x.Name == name || Parser.ConvertType( x.Name ) == name ) )
            return true;

        return false;
    }

    public bool IsTypeDef( string name )
    {
        if ( TypeDefs.Any( x => x.Name == name || Parser.ConvertType( x.Name ) == name ) )
            return true;

        return false;
    }

    public bool IsCallback( string name )
    {
        if ( CallbackStructs.Any( x => x.Name == name || Parser.ConvertType( x.Name ) == name ) )
            return true;

        return false;
    }

    public bool IsEnum( string name )
    {
        if ( Enums.Any( x => x.Name == name || Parser.ConvertType( x.Name ) == name ) )
            return true;

        return false;
    }
}