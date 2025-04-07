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
var initEntity = state.EntityManager.CreateEntity();
state.EntityManager.AddComponentData( initEntity, new SteamAPIRequestInit( 480 ) );
```

For GameServer
```csharp
var initEntity = state.EntityManager.CreateEntity();
state.EntityManager.AddComponentData( initEntity, new SteamGameServerRequestInit( 480, "SpaceWar", "Yippe" ) );
```