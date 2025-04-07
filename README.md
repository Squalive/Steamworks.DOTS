# Steamworks.DOTS

A steamworks wrapper specifically designed for unity dots (ecs, jobs, burst).

## Why
This exist solely because the existing c# steamworks api doesnt compatible with dots at all
    1. Steamworks.NET is low level but since it uses static and not readonly so it is not burstable, and function with string is not burstable as well.
    2. Facepunch.Steamworks is a c# friendly api but its so c# that its impossible to use it with jobs burst at all.

## Disclaimer
Although this wrapper is designed for dots, but its still a high level wrapper which internal everything and expose limited amount of function you can use

## How to use

### Initialization
For Client
```csharp
var initEntity = EntityManager.CreateEntity();
EntityManager.AddComponentData( initEntity, new SteamAPIRequestInit( 480 ) );
```

For GameServer
```csharp
var initEntity = EntityManager.CreateEntity();
EntityManager.AddComponentData( initEntity, new SteamGameServerRequestInit( 480, "SpaceWar", "Yippe" ) );
```

Shutdown is handled automatically, every world can only initialize once, so the interfaces are released when the world is destroyed

### Handle unsuccessfully Init
Since initialization is never to be sure success, so handling the result is important, but it is not strictly required
Keep in mind that the internal system doesnt log "Failed Init" so if you want more debugging infos, you have to do this result handling

For Client
```csharp
if ( SystemAPI.TryGetSingletonEntity<SteamAPIInitResult>( out var steamEntity ) ) 
{
    var result = EntityManager.GetComponentData<SteamAPIInitResult>( steamEntity );
    if ( result.Result == SteamInitResult.Ok )
    {
        // Do your success initialization here
        // For example. Log("SteamAPI Init Success");
    }
    else
    {
        UnityEngine.Debug.LogError( result.ErrorMsg );
    }
    // This step isnt necessary but if you dont remove this component, this block of code will keep executing
    EntityManager.RemoveComponent<SteamAPIInitResult>( steamEntity );
}
```

For Server
```csharp
if ( SystemAPI.TryGetSingletonEntity<SteamGameServerInitResult>( out var steamEntity ) ) 
{
    var result = EntityManager.GetComponentData<SteamGameServerInitResult>( steamEntity );
    if ( result.Result == SteamInitResult.Ok )
    {
        // Do your success initialization here
        // For example. Log("SteamGameServer Init Success");
    }
    else
    {
        UnityEngine.Debug.LogError( result.ErrorMsg );
    }
    // This step isnt necessary but if you dont remove this component, this block of code will keep executing
    EntityManager.RemoveComponent<SteamGameServerInitResult>( steamEntity );
}
```

