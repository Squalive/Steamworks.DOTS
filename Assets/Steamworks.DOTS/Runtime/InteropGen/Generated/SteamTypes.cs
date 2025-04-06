using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks.Data
{
	public struct AppId_t : IEquatable<AppId_t>, IComparable<AppId_t>
	{
		// typedef: AppId_t, type: unsigned int
		public uint Value;
		
		public static implicit operator AppId_t( uint value ) => new AppId_t(){ Value = value };
		public static implicit operator uint( AppId_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( AppId_t ) p );
		public bool Equals( AppId_t p ) => p.Value == Value;
		public static bool operator ==( AppId_t a, AppId_t b ) => a.Equals( b );
		public static bool operator !=( AppId_t a, AppId_t b ) => !a.Equals( b );
		public int CompareTo( AppId_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct DepotId_t : IEquatable<DepotId_t>, IComparable<DepotId_t>
	{
		// typedef: DepotId_t, type: unsigned int
		public uint Value;
		
		public static implicit operator DepotId_t( uint value ) => new DepotId_t(){ Value = value };
		public static implicit operator uint( DepotId_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( DepotId_t ) p );
		public bool Equals( DepotId_t p ) => p.Value == Value;
		public static bool operator ==( DepotId_t a, DepotId_t b ) => a.Equals( b );
		public static bool operator !=( DepotId_t a, DepotId_t b ) => !a.Equals( b );
		public int CompareTo( DepotId_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct RTime32 : IEquatable<RTime32>, IComparable<RTime32>
	{
		// typedef: RTime32, type: unsigned int
		public uint Value;
		
		public static implicit operator RTime32( uint value ) => new RTime32(){ Value = value };
		public static implicit operator uint( RTime32 value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( RTime32 ) p );
		public bool Equals( RTime32 p ) => p.Value == Value;
		public static bool operator ==( RTime32 a, RTime32 b ) => a.Equals( b );
		public static bool operator !=( RTime32 a, RTime32 b ) => !a.Equals( b );
		public int CompareTo( RTime32 other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamAPICall_t : IEquatable<SteamAPICall_t>, IComparable<SteamAPICall_t>
	{
		// typedef: SteamAPICall_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator SteamAPICall_t( ulong value ) => new SteamAPICall_t(){ Value = value };
		public static implicit operator ulong( SteamAPICall_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamAPICall_t ) p );
		public bool Equals( SteamAPICall_t p ) => p.Value == Value;
		public static bool operator ==( SteamAPICall_t a, SteamAPICall_t b ) => a.Equals( b );
		public static bool operator !=( SteamAPICall_t a, SteamAPICall_t b ) => !a.Equals( b );
		public int CompareTo( SteamAPICall_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct AccountID_t : IEquatable<AccountID_t>, IComparable<AccountID_t>
	{
		// typedef: AccountID_t, type: unsigned int
		public uint Value;
		
		public static implicit operator AccountID_t( uint value ) => new AccountID_t(){ Value = value };
		public static implicit operator uint( AccountID_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( AccountID_t ) p );
		public bool Equals( AccountID_t p ) => p.Value == Value;
		public static bool operator ==( AccountID_t a, AccountID_t b ) => a.Equals( b );
		public static bool operator !=( AccountID_t a, AccountID_t b ) => !a.Equals( b );
		public int CompareTo( AccountID_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct PartyBeaconID_t : IEquatable<PartyBeaconID_t>, IComparable<PartyBeaconID_t>
	{
		// typedef: PartyBeaconID_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator PartyBeaconID_t( ulong value ) => new PartyBeaconID_t(){ Value = value };
		public static implicit operator ulong( PartyBeaconID_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( PartyBeaconID_t ) p );
		public bool Equals( PartyBeaconID_t p ) => p.Value == Value;
		public static bool operator ==( PartyBeaconID_t a, PartyBeaconID_t b ) => a.Equals( b );
		public static bool operator !=( PartyBeaconID_t a, PartyBeaconID_t b ) => !a.Equals( b );
		public int CompareTo( PartyBeaconID_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct HAuthTicket : IEquatable<HAuthTicket>, IComparable<HAuthTicket>
	{
		// typedef: HAuthTicket, type: unsigned int
		public uint Value;
		
		public static implicit operator HAuthTicket( uint value ) => new HAuthTicket(){ Value = value };
		public static implicit operator uint( HAuthTicket value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HAuthTicket ) p );
		public bool Equals( HAuthTicket p ) => p.Value == Value;
		public static bool operator ==( HAuthTicket a, HAuthTicket b ) => a.Equals( b );
		public static bool operator !=( HAuthTicket a, HAuthTicket b ) => !a.Equals( b );
		public int CompareTo( HAuthTicket other ) => Value.CompareTo( other.Value );
	}
	
	public struct HSteamPipe : IEquatable<HSteamPipe>, IComparable<HSteamPipe>
	{
		// typedef: HSteamPipe, type: int
		public int Value;
		
		public static implicit operator HSteamPipe( int value ) => new HSteamPipe(){ Value = value };
		public static implicit operator int( HSteamPipe value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HSteamPipe ) p );
		public bool Equals( HSteamPipe p ) => p.Value == Value;
		public static bool operator ==( HSteamPipe a, HSteamPipe b ) => a.Equals( b );
		public static bool operator !=( HSteamPipe a, HSteamPipe b ) => !a.Equals( b );
		public int CompareTo( HSteamPipe other ) => Value.CompareTo( other.Value );
	}
	
	public struct HSteamUser : IEquatable<HSteamUser>, IComparable<HSteamUser>
	{
		// typedef: HSteamUser, type: int
		public int Value;
		
		public static implicit operator HSteamUser( int value ) => new HSteamUser(){ Value = value };
		public static implicit operator int( HSteamUser value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HSteamUser ) p );
		public bool Equals( HSteamUser p ) => p.Value == Value;
		public static bool operator ==( HSteamUser a, HSteamUser b ) => a.Equals( b );
		public static bool operator !=( HSteamUser a, HSteamUser b ) => !a.Equals( b );
		public int CompareTo( HSteamUser other ) => Value.CompareTo( other.Value );
	}
	
	public struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t>
	{
		// typedef: FriendsGroupID_t, type: short
		public short Value;
		
		public static implicit operator FriendsGroupID_t( short value ) => new FriendsGroupID_t(){ Value = value };
		public static implicit operator short( FriendsGroupID_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( FriendsGroupID_t ) p );
		public bool Equals( FriendsGroupID_t p ) => p.Value == Value;
		public static bool operator ==( FriendsGroupID_t a, FriendsGroupID_t b ) => a.Equals( b );
		public static bool operator !=( FriendsGroupID_t a, FriendsGroupID_t b ) => !a.Equals( b );
		public int CompareTo( FriendsGroupID_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct HServerListRequest : IEquatable<HServerListRequest>, IComparable<HServerListRequest>
	{
		// typedef: HServerListRequest, type: void *
		public IntPtr Value;
		
		public static implicit operator HServerListRequest( IntPtr value ) => new HServerListRequest(){ Value = value };
		public static implicit operator IntPtr( HServerListRequest value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HServerListRequest ) p );
		public bool Equals( HServerListRequest p ) => p.Value == Value;
		public static bool operator ==( HServerListRequest a, HServerListRequest b ) => a.Equals( b );
		public static bool operator !=( HServerListRequest a, HServerListRequest b ) => !a.Equals( b );
		public int CompareTo( HServerListRequest other ) => Value.ToInt64().CompareTo( other.Value.ToInt64() );
	}
	
	public struct HServerQuery : IEquatable<HServerQuery>, IComparable<HServerQuery>
	{
		// typedef: HServerQuery, type: int
		public int Value;
		
		public static implicit operator HServerQuery( int value ) => new HServerQuery(){ Value = value };
		public static implicit operator int( HServerQuery value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HServerQuery ) p );
		public bool Equals( HServerQuery p ) => p.Value == Value;
		public static bool operator ==( HServerQuery a, HServerQuery b ) => a.Equals( b );
		public static bool operator !=( HServerQuery a, HServerQuery b ) => !a.Equals( b );
		public int CompareTo( HServerQuery other ) => Value.CompareTo( other.Value );
	}
	
	public struct UGCHandle_t : IEquatable<UGCHandle_t>, IComparable<UGCHandle_t>
	{
		// typedef: UGCHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator UGCHandle_t( ulong value ) => new UGCHandle_t(){ Value = value };
		public static implicit operator ulong( UGCHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( UGCHandle_t ) p );
		public bool Equals( UGCHandle_t p ) => p.Value == Value;
		public static bool operator ==( UGCHandle_t a, UGCHandle_t b ) => a.Equals( b );
		public static bool operator !=( UGCHandle_t a, UGCHandle_t b ) => !a.Equals( b );
		public int CompareTo( UGCHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t>
	{
		// typedef: PublishedFileUpdateHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator PublishedFileUpdateHandle_t( ulong value ) => new PublishedFileUpdateHandle_t(){ Value = value };
		public static implicit operator ulong( PublishedFileUpdateHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( PublishedFileUpdateHandle_t ) p );
		public bool Equals( PublishedFileUpdateHandle_t p ) => p.Value == Value;
		public static bool operator ==( PublishedFileUpdateHandle_t a, PublishedFileUpdateHandle_t b ) => a.Equals( b );
		public static bool operator !=( PublishedFileUpdateHandle_t a, PublishedFileUpdateHandle_t b ) => !a.Equals( b );
		public int CompareTo( PublishedFileUpdateHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct PublishedFileId_t : IEquatable<PublishedFileId_t>, IComparable<PublishedFileId_t>
	{
		// typedef: PublishedFileId_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator PublishedFileId_t( ulong value ) => new PublishedFileId_t(){ Value = value };
		public static implicit operator ulong( PublishedFileId_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( PublishedFileId_t ) p );
		public bool Equals( PublishedFileId_t p ) => p.Value == Value;
		public static bool operator ==( PublishedFileId_t a, PublishedFileId_t b ) => a.Equals( b );
		public static bool operator !=( PublishedFileId_t a, PublishedFileId_t b ) => !a.Equals( b );
		public int CompareTo( PublishedFileId_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct UGCFileWriteStreamHandle_t : IEquatable<UGCFileWriteStreamHandle_t>, IComparable<UGCFileWriteStreamHandle_t>
	{
		// typedef: UGCFileWriteStreamHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator UGCFileWriteStreamHandle_t( ulong value ) => new UGCFileWriteStreamHandle_t(){ Value = value };
		public static implicit operator ulong( UGCFileWriteStreamHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( UGCFileWriteStreamHandle_t ) p );
		public bool Equals( UGCFileWriteStreamHandle_t p ) => p.Value == Value;
		public static bool operator ==( UGCFileWriteStreamHandle_t a, UGCFileWriteStreamHandle_t b ) => a.Equals( b );
		public static bool operator !=( UGCFileWriteStreamHandle_t a, UGCFileWriteStreamHandle_t b ) => !a.Equals( b );
		public int CompareTo( UGCFileWriteStreamHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamLeaderboard_t : IEquatable<SteamLeaderboard_t>, IComparable<SteamLeaderboard_t>
	{
		// typedef: SteamLeaderboard_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator SteamLeaderboard_t( ulong value ) => new SteamLeaderboard_t(){ Value = value };
		public static implicit operator ulong( SteamLeaderboard_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamLeaderboard_t ) p );
		public bool Equals( SteamLeaderboard_t p ) => p.Value == Value;
		public static bool operator ==( SteamLeaderboard_t a, SteamLeaderboard_t b ) => a.Equals( b );
		public static bool operator !=( SteamLeaderboard_t a, SteamLeaderboard_t b ) => !a.Equals( b );
		public int CompareTo( SteamLeaderboard_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t>
	{
		// typedef: SteamLeaderboardEntries_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator SteamLeaderboardEntries_t( ulong value ) => new SteamLeaderboardEntries_t(){ Value = value };
		public static implicit operator ulong( SteamLeaderboardEntries_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamLeaderboardEntries_t ) p );
		public bool Equals( SteamLeaderboardEntries_t p ) => p.Value == Value;
		public static bool operator ==( SteamLeaderboardEntries_t a, SteamLeaderboardEntries_t b ) => a.Equals( b );
		public static bool operator !=( SteamLeaderboardEntries_t a, SteamLeaderboardEntries_t b ) => !a.Equals( b );
		public int CompareTo( SteamLeaderboardEntries_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SNetSocket_t : IEquatable<SNetSocket_t>, IComparable<SNetSocket_t>
	{
		// typedef: SNetSocket_t, type: unsigned int
		public uint Value;
		
		public static implicit operator SNetSocket_t( uint value ) => new SNetSocket_t(){ Value = value };
		public static implicit operator uint( SNetSocket_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SNetSocket_t ) p );
		public bool Equals( SNetSocket_t p ) => p.Value == Value;
		public static bool operator ==( SNetSocket_t a, SNetSocket_t b ) => a.Equals( b );
		public static bool operator !=( SNetSocket_t a, SNetSocket_t b ) => !a.Equals( b );
		public int CompareTo( SNetSocket_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SNetListenSocket_t : IEquatable<SNetListenSocket_t>, IComparable<SNetListenSocket_t>
	{
		// typedef: SNetListenSocket_t, type: unsigned int
		public uint Value;
		
		public static implicit operator SNetListenSocket_t( uint value ) => new SNetListenSocket_t(){ Value = value };
		public static implicit operator uint( SNetListenSocket_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SNetListenSocket_t ) p );
		public bool Equals( SNetListenSocket_t p ) => p.Value == Value;
		public static bool operator ==( SNetListenSocket_t a, SNetListenSocket_t b ) => a.Equals( b );
		public static bool operator !=( SNetListenSocket_t a, SNetListenSocket_t b ) => !a.Equals( b );
		public int CompareTo( SNetListenSocket_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct ScreenshotHandle : IEquatable<ScreenshotHandle>, IComparable<ScreenshotHandle>
	{
		// typedef: ScreenshotHandle, type: unsigned int
		public uint Value;
		
		public static implicit operator ScreenshotHandle( uint value ) => new ScreenshotHandle(){ Value = value };
		public static implicit operator uint( ScreenshotHandle value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( ScreenshotHandle ) p );
		public bool Equals( ScreenshotHandle p ) => p.Value == Value;
		public static bool operator ==( ScreenshotHandle a, ScreenshotHandle b ) => a.Equals( b );
		public static bool operator !=( ScreenshotHandle a, ScreenshotHandle b ) => !a.Equals( b );
		public int CompareTo( ScreenshotHandle other ) => Value.CompareTo( other.Value );
	}
	
	public struct HTTPRequestHandle : IEquatable<HTTPRequestHandle>, IComparable<HTTPRequestHandle>
	{
		// typedef: HTTPRequestHandle, type: unsigned int
		public uint Value;
		
		public static implicit operator HTTPRequestHandle( uint value ) => new HTTPRequestHandle(){ Value = value };
		public static implicit operator uint( HTTPRequestHandle value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HTTPRequestHandle ) p );
		public bool Equals( HTTPRequestHandle p ) => p.Value == Value;
		public static bool operator ==( HTTPRequestHandle a, HTTPRequestHandle b ) => a.Equals( b );
		public static bool operator !=( HTTPRequestHandle a, HTTPRequestHandle b ) => !a.Equals( b );
		public int CompareTo( HTTPRequestHandle other ) => Value.CompareTo( other.Value );
	}
	
	public struct HTTPCookieContainerHandle : IEquatable<HTTPCookieContainerHandle>, IComparable<HTTPCookieContainerHandle>
	{
		// typedef: HTTPCookieContainerHandle, type: unsigned int
		public uint Value;
		
		public static implicit operator HTTPCookieContainerHandle( uint value ) => new HTTPCookieContainerHandle(){ Value = value };
		public static implicit operator uint( HTTPCookieContainerHandle value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HTTPCookieContainerHandle ) p );
		public bool Equals( HTTPCookieContainerHandle p ) => p.Value == Value;
		public static bool operator ==( HTTPCookieContainerHandle a, HTTPCookieContainerHandle b ) => a.Equals( b );
		public static bool operator !=( HTTPCookieContainerHandle a, HTTPCookieContainerHandle b ) => !a.Equals( b );
		public int CompareTo( HTTPCookieContainerHandle other ) => Value.CompareTo( other.Value );
	}
	
	public struct InputHandle_t : IEquatable<InputHandle_t>, IComparable<InputHandle_t>
	{
		// typedef: InputHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator InputHandle_t( ulong value ) => new InputHandle_t(){ Value = value };
		public static implicit operator ulong( InputHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( InputHandle_t ) p );
		public bool Equals( InputHandle_t p ) => p.Value == Value;
		public static bool operator ==( InputHandle_t a, InputHandle_t b ) => a.Equals( b );
		public static bool operator !=( InputHandle_t a, InputHandle_t b ) => !a.Equals( b );
		public int CompareTo( InputHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct InputActionSetHandle_t : IEquatable<InputActionSetHandle_t>, IComparable<InputActionSetHandle_t>
	{
		// typedef: InputActionSetHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator InputActionSetHandle_t( ulong value ) => new InputActionSetHandle_t(){ Value = value };
		public static implicit operator ulong( InputActionSetHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( InputActionSetHandle_t ) p );
		public bool Equals( InputActionSetHandle_t p ) => p.Value == Value;
		public static bool operator ==( InputActionSetHandle_t a, InputActionSetHandle_t b ) => a.Equals( b );
		public static bool operator !=( InputActionSetHandle_t a, InputActionSetHandle_t b ) => !a.Equals( b );
		public int CompareTo( InputActionSetHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct InputDigitalActionHandle_t : IEquatable<InputDigitalActionHandle_t>, IComparable<InputDigitalActionHandle_t>
	{
		// typedef: InputDigitalActionHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator InputDigitalActionHandle_t( ulong value ) => new InputDigitalActionHandle_t(){ Value = value };
		public static implicit operator ulong( InputDigitalActionHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( InputDigitalActionHandle_t ) p );
		public bool Equals( InputDigitalActionHandle_t p ) => p.Value == Value;
		public static bool operator ==( InputDigitalActionHandle_t a, InputDigitalActionHandle_t b ) => a.Equals( b );
		public static bool operator !=( InputDigitalActionHandle_t a, InputDigitalActionHandle_t b ) => !a.Equals( b );
		public int CompareTo( InputDigitalActionHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct InputAnalogActionHandle_t : IEquatable<InputAnalogActionHandle_t>, IComparable<InputAnalogActionHandle_t>
	{
		// typedef: InputAnalogActionHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator InputAnalogActionHandle_t( ulong value ) => new InputAnalogActionHandle_t(){ Value = value };
		public static implicit operator ulong( InputAnalogActionHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( InputAnalogActionHandle_t ) p );
		public bool Equals( InputAnalogActionHandle_t p ) => p.Value == Value;
		public static bool operator ==( InputAnalogActionHandle_t a, InputAnalogActionHandle_t b ) => a.Equals( b );
		public static bool operator !=( InputAnalogActionHandle_t a, InputAnalogActionHandle_t b ) => !a.Equals( b );
		public int CompareTo( InputAnalogActionHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct ControllerHandle_t : IEquatable<ControllerHandle_t>, IComparable<ControllerHandle_t>
	{
		// typedef: ControllerHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator ControllerHandle_t( ulong value ) => new ControllerHandle_t(){ Value = value };
		public static implicit operator ulong( ControllerHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( ControllerHandle_t ) p );
		public bool Equals( ControllerHandle_t p ) => p.Value == Value;
		public static bool operator ==( ControllerHandle_t a, ControllerHandle_t b ) => a.Equals( b );
		public static bool operator !=( ControllerHandle_t a, ControllerHandle_t b ) => !a.Equals( b );
		public int CompareTo( ControllerHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct ControllerActionSetHandle_t : IEquatable<ControllerActionSetHandle_t>, IComparable<ControllerActionSetHandle_t>
	{
		// typedef: ControllerActionSetHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator ControllerActionSetHandle_t( ulong value ) => new ControllerActionSetHandle_t(){ Value = value };
		public static implicit operator ulong( ControllerActionSetHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( ControllerActionSetHandle_t ) p );
		public bool Equals( ControllerActionSetHandle_t p ) => p.Value == Value;
		public static bool operator ==( ControllerActionSetHandle_t a, ControllerActionSetHandle_t b ) => a.Equals( b );
		public static bool operator !=( ControllerActionSetHandle_t a, ControllerActionSetHandle_t b ) => !a.Equals( b );
		public int CompareTo( ControllerActionSetHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct ControllerDigitalActionHandle_t : IEquatable<ControllerDigitalActionHandle_t>, IComparable<ControllerDigitalActionHandle_t>
	{
		// typedef: ControllerDigitalActionHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator ControllerDigitalActionHandle_t( ulong value ) => new ControllerDigitalActionHandle_t(){ Value = value };
		public static implicit operator ulong( ControllerDigitalActionHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( ControllerDigitalActionHandle_t ) p );
		public bool Equals( ControllerDigitalActionHandle_t p ) => p.Value == Value;
		public static bool operator ==( ControllerDigitalActionHandle_t a, ControllerDigitalActionHandle_t b ) => a.Equals( b );
		public static bool operator !=( ControllerDigitalActionHandle_t a, ControllerDigitalActionHandle_t b ) => !a.Equals( b );
		public int CompareTo( ControllerDigitalActionHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct ControllerAnalogActionHandle_t : IEquatable<ControllerAnalogActionHandle_t>, IComparable<ControllerAnalogActionHandle_t>
	{
		// typedef: ControllerAnalogActionHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator ControllerAnalogActionHandle_t( ulong value ) => new ControllerAnalogActionHandle_t(){ Value = value };
		public static implicit operator ulong( ControllerAnalogActionHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( ControllerAnalogActionHandle_t ) p );
		public bool Equals( ControllerAnalogActionHandle_t p ) => p.Value == Value;
		public static bool operator ==( ControllerAnalogActionHandle_t a, ControllerAnalogActionHandle_t b ) => a.Equals( b );
		public static bool operator !=( ControllerAnalogActionHandle_t a, ControllerAnalogActionHandle_t b ) => !a.Equals( b );
		public int CompareTo( ControllerAnalogActionHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct UGCQueryHandle_t : IEquatable<UGCQueryHandle_t>, IComparable<UGCQueryHandle_t>
	{
		// typedef: UGCQueryHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator UGCQueryHandle_t( ulong value ) => new UGCQueryHandle_t(){ Value = value };
		public static implicit operator ulong( UGCQueryHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( UGCQueryHandle_t ) p );
		public bool Equals( UGCQueryHandle_t p ) => p.Value == Value;
		public static bool operator ==( UGCQueryHandle_t a, UGCQueryHandle_t b ) => a.Equals( b );
		public static bool operator !=( UGCQueryHandle_t a, UGCQueryHandle_t b ) => !a.Equals( b );
		public int CompareTo( UGCQueryHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct UGCUpdateHandle_t : IEquatable<UGCUpdateHandle_t>, IComparable<UGCUpdateHandle_t>
	{
		// typedef: UGCUpdateHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator UGCUpdateHandle_t( ulong value ) => new UGCUpdateHandle_t(){ Value = value };
		public static implicit operator ulong( UGCUpdateHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( UGCUpdateHandle_t ) p );
		public bool Equals( UGCUpdateHandle_t p ) => p.Value == Value;
		public static bool operator ==( UGCUpdateHandle_t a, UGCUpdateHandle_t b ) => a.Equals( b );
		public static bool operator !=( UGCUpdateHandle_t a, UGCUpdateHandle_t b ) => !a.Equals( b );
		public int CompareTo( UGCUpdateHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct HHTMLBrowser : IEquatable<HHTMLBrowser>, IComparable<HHTMLBrowser>
	{
		// typedef: HHTMLBrowser, type: unsigned int
		public uint Value;
		
		public static implicit operator HHTMLBrowser( uint value ) => new HHTMLBrowser(){ Value = value };
		public static implicit operator uint( HHTMLBrowser value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HHTMLBrowser ) p );
		public bool Equals( HHTMLBrowser p ) => p.Value == Value;
		public static bool operator ==( HHTMLBrowser a, HHTMLBrowser b ) => a.Equals( b );
		public static bool operator !=( HHTMLBrowser a, HHTMLBrowser b ) => !a.Equals( b );
		public int CompareTo( HHTMLBrowser other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamItemInstanceID_t : IEquatable<SteamItemInstanceID_t>, IComparable<SteamItemInstanceID_t>
	{
		// typedef: SteamItemInstanceID_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator SteamItemInstanceID_t( ulong value ) => new SteamItemInstanceID_t(){ Value = value };
		public static implicit operator ulong( SteamItemInstanceID_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamItemInstanceID_t ) p );
		public bool Equals( SteamItemInstanceID_t p ) => p.Value == Value;
		public static bool operator ==( SteamItemInstanceID_t a, SteamItemInstanceID_t b ) => a.Equals( b );
		public static bool operator !=( SteamItemInstanceID_t a, SteamItemInstanceID_t b ) => !a.Equals( b );
		public int CompareTo( SteamItemInstanceID_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamItemDef_t : IEquatable<SteamItemDef_t>, IComparable<SteamItemDef_t>
	{
		// typedef: SteamItemDef_t, type: int
		public int Value;
		
		public static implicit operator SteamItemDef_t( int value ) => new SteamItemDef_t(){ Value = value };
		public static implicit operator int( SteamItemDef_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamItemDef_t ) p );
		public bool Equals( SteamItemDef_t p ) => p.Value == Value;
		public static bool operator ==( SteamItemDef_t a, SteamItemDef_t b ) => a.Equals( b );
		public static bool operator !=( SteamItemDef_t a, SteamItemDef_t b ) => !a.Equals( b );
		public int CompareTo( SteamItemDef_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamInventoryResult_t : IEquatable<SteamInventoryResult_t>, IComparable<SteamInventoryResult_t>
	{
		// typedef: SteamInventoryResult_t, type: int
		public int Value;
		
		public static implicit operator SteamInventoryResult_t( int value ) => new SteamInventoryResult_t(){ Value = value };
		public static implicit operator int( SteamInventoryResult_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamInventoryResult_t ) p );
		public bool Equals( SteamInventoryResult_t p ) => p.Value == Value;
		public static bool operator ==( SteamInventoryResult_t a, SteamInventoryResult_t b ) => a.Equals( b );
		public static bool operator !=( SteamInventoryResult_t a, SteamInventoryResult_t b ) => !a.Equals( b );
		public int CompareTo( SteamInventoryResult_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamInventoryUpdateHandle_t : IEquatable<SteamInventoryUpdateHandle_t>, IComparable<SteamInventoryUpdateHandle_t>
	{
		// typedef: SteamInventoryUpdateHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator SteamInventoryUpdateHandle_t( ulong value ) => new SteamInventoryUpdateHandle_t(){ Value = value };
		public static implicit operator ulong( SteamInventoryUpdateHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamInventoryUpdateHandle_t ) p );
		public bool Equals( SteamInventoryUpdateHandle_t p ) => p.Value == Value;
		public static bool operator ==( SteamInventoryUpdateHandle_t a, SteamInventoryUpdateHandle_t b ) => a.Equals( b );
		public static bool operator !=( SteamInventoryUpdateHandle_t a, SteamInventoryUpdateHandle_t b ) => !a.Equals( b );
		public int CompareTo( SteamInventoryUpdateHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct TimelineEventHandle_t : IEquatable<TimelineEventHandle_t>, IComparable<TimelineEventHandle_t>
	{
		// typedef: TimelineEventHandle_t, type: unsigned long long
		public ulong Value;
		
		public static implicit operator TimelineEventHandle_t( ulong value ) => new TimelineEventHandle_t(){ Value = value };
		public static implicit operator ulong( TimelineEventHandle_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( TimelineEventHandle_t ) p );
		public bool Equals( TimelineEventHandle_t p ) => p.Value == Value;
		public static bool operator ==( TimelineEventHandle_t a, TimelineEventHandle_t b ) => a.Equals( b );
		public static bool operator !=( TimelineEventHandle_t a, TimelineEventHandle_t b ) => !a.Equals( b );
		public int CompareTo( TimelineEventHandle_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct RemotePlaySessionID_t : IEquatable<RemotePlaySessionID_t>, IComparable<RemotePlaySessionID_t>
	{
		// typedef: RemotePlaySessionID_t, type: unsigned int
		public uint Value;
		
		public static implicit operator RemotePlaySessionID_t( uint value ) => new RemotePlaySessionID_t(){ Value = value };
		public static implicit operator uint( RemotePlaySessionID_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( RemotePlaySessionID_t ) p );
		public bool Equals( RemotePlaySessionID_t p ) => p.Value == Value;
		public static bool operator ==( RemotePlaySessionID_t a, RemotePlaySessionID_t b ) => a.Equals( b );
		public static bool operator !=( RemotePlaySessionID_t a, RemotePlaySessionID_t b ) => !a.Equals( b );
		public int CompareTo( RemotePlaySessionID_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct RemotePlayCursorID_t : IEquatable<RemotePlayCursorID_t>, IComparable<RemotePlayCursorID_t>
	{
		// typedef: RemotePlayCursorID_t, type: unsigned int
		public uint Value;
		
		public static implicit operator RemotePlayCursorID_t( uint value ) => new RemotePlayCursorID_t(){ Value = value };
		public static implicit operator uint( RemotePlayCursorID_t value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( RemotePlayCursorID_t ) p );
		public bool Equals( RemotePlayCursorID_t p ) => p.Value == Value;
		public static bool operator ==( RemotePlayCursorID_t a, RemotePlayCursorID_t b ) => a.Equals( b );
		public static bool operator !=( RemotePlayCursorID_t a, RemotePlayCursorID_t b ) => !a.Equals( b );
		public int CompareTo( RemotePlayCursorID_t other ) => Value.CompareTo( other.Value );
	}
	
	public struct HSteamNetConnection : IEquatable<HSteamNetConnection>, IComparable<HSteamNetConnection>
	{
		// typedef: HSteamNetConnection, type: unsigned int
		public uint Value;
		
		public static implicit operator HSteamNetConnection( uint value ) => new HSteamNetConnection(){ Value = value };
		public static implicit operator uint( HSteamNetConnection value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HSteamNetConnection ) p );
		public bool Equals( HSteamNetConnection p ) => p.Value == Value;
		public static bool operator ==( HSteamNetConnection a, HSteamNetConnection b ) => a.Equals( b );
		public static bool operator !=( HSteamNetConnection a, HSteamNetConnection b ) => !a.Equals( b );
		public int CompareTo( HSteamNetConnection other ) => Value.CompareTo( other.Value );
	}
	
	public struct HSteamListenSocket : IEquatable<HSteamListenSocket>, IComparable<HSteamListenSocket>
	{
		// typedef: HSteamListenSocket, type: unsigned int
		public uint Value;
		
		public static implicit operator HSteamListenSocket( uint value ) => new HSteamListenSocket(){ Value = value };
		public static implicit operator uint( HSteamListenSocket value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HSteamListenSocket ) p );
		public bool Equals( HSteamListenSocket p ) => p.Value == Value;
		public static bool operator ==( HSteamListenSocket a, HSteamListenSocket b ) => a.Equals( b );
		public static bool operator !=( HSteamListenSocket a, HSteamListenSocket b ) => !a.Equals( b );
		public int CompareTo( HSteamListenSocket other ) => Value.CompareTo( other.Value );
	}
	
	public struct HSteamNetPollGroup : IEquatable<HSteamNetPollGroup>, IComparable<HSteamNetPollGroup>
	{
		// typedef: HSteamNetPollGroup, type: unsigned int
		public uint Value;
		
		public static implicit operator HSteamNetPollGroup( uint value ) => new HSteamNetPollGroup(){ Value = value };
		public static implicit operator uint( HSteamNetPollGroup value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( HSteamNetPollGroup ) p );
		public bool Equals( HSteamNetPollGroup p ) => p.Value == Value;
		public static bool operator ==( HSteamNetPollGroup a, HSteamNetPollGroup b ) => a.Equals( b );
		public static bool operator !=( HSteamNetPollGroup a, HSteamNetPollGroup b ) => !a.Equals( b );
		public int CompareTo( HSteamNetPollGroup other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamNetworkingPOPID : IEquatable<SteamNetworkingPOPID>, IComparable<SteamNetworkingPOPID>
	{
		// typedef: SteamNetworkingPOPID, type: unsigned int
		public uint Value;
		
		public static implicit operator SteamNetworkingPOPID( uint value ) => new SteamNetworkingPOPID(){ Value = value };
		public static implicit operator uint( SteamNetworkingPOPID value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamNetworkingPOPID ) p );
		public bool Equals( SteamNetworkingPOPID p ) => p.Value == Value;
		public static bool operator ==( SteamNetworkingPOPID a, SteamNetworkingPOPID b ) => a.Equals( b );
		public static bool operator !=( SteamNetworkingPOPID a, SteamNetworkingPOPID b ) => !a.Equals( b );
		public int CompareTo( SteamNetworkingPOPID other ) => Value.CompareTo( other.Value );
	}
	
	public struct SteamNetworkingMicroseconds : IEquatable<SteamNetworkingMicroseconds>, IComparable<SteamNetworkingMicroseconds>
	{
		// typedef: SteamNetworkingMicroseconds, type: long long
		public long Value;
		
		public static implicit operator SteamNetworkingMicroseconds( long value ) => new SteamNetworkingMicroseconds(){ Value = value };
		public static implicit operator long( SteamNetworkingMicroseconds value ) => value.Value;
		public override string ToString() => Value.ToString();
		public override int GetHashCode() => Value.GetHashCode();
		public override bool Equals( object p ) => this.Equals( ( SteamNetworkingMicroseconds ) p );
		public bool Equals( SteamNetworkingMicroseconds p ) => p.Value == Value;
		public static bool operator ==( SteamNetworkingMicroseconds a, SteamNetworkingMicroseconds b ) => a.Equals( b );
		public static bool operator !=( SteamNetworkingMicroseconds a, SteamNetworkingMicroseconds b ) => !a.Equals( b );
		public int CompareTo( SteamNetworkingMicroseconds other ) => Value.CompareTo( other.Value );
	}
	
}
