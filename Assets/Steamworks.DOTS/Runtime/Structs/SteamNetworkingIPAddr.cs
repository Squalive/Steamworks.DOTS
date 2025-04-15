using System.Net;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
    [ StructLayout( LayoutKind.Explicit, Size = 18, Pack = 1 ) ]
    public partial struct SteamNetworkingIPAddr
    {
        [ FieldOffset( 0 ) ] internal IPV4 Ip;

        [ FieldOffset( 16 ) ] internal ushort port;

        internal struct IPV4
        {
            internal ulong m_8zeros;
            internal ushort m_0000;
            internal ushort m_ffff;
            internal byte ip0;
            internal byte ip1;
            internal byte ip2;
            internal byte ip3;
        }

        /// <summary>
        /// The Port. This is redundant documentation.
        /// </summary>
        public ushort Port => port;
        
        /// <summary>
		/// Any IP, specific port
		/// </summary>
		public static SteamNetworkingIPAddr AnyIp( ushort port )
		{
			var addr = Cleared;
			addr.port = port;
			return addr;
		}

		/// <summary>
		/// Localhost IP, specific port
		/// </summary>
		public static SteamNetworkingIPAddr LocalHost( ushort port )
		{
			var local = Cleared;
			SteamAPI_SetIPv6LocalHost( ref local, port );
			return local;
		}

		/// <summary>
		/// Specific IP, specific port
		/// </summary>
		public static SteamNetworkingIPAddr From( string addrStr, ushort port )
		{
			return From( IPAddress.Parse( addrStr ), port );
		}

		/// <summary>
		/// Specific IP, specific port
		/// </summary>
		public static SteamNetworkingIPAddr From( IPAddress address, ushort port )
		{
			var addr = address.GetAddressBytes();

			if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
			{
				var local = Cleared;
				SteamAPI_SetIPv4( ref local, Utility.IpToInt32( address ), port );
				return local;
			}

			throw new System.NotImplementedException( "Oops - no IPV6 support yet?" );
		}

		/// <summary>
		/// Set everything to zero
		/// </summary>
		public static SteamNetworkingIPAddr Cleared
		{
			get
			{
				SteamNetworkingIPAddr self = default;
				SteamAPI_Clear( ref self );
				return self;
			}
		}

		/// <summary>
		/// Return true if the IP is ::0.  (Doesn't check port.)
		/// </summary>
		public bool IsIPv6AllZeros
		{
			get
			{
				var self = this;
				return SteamAPI_IsIPv6AllZeros( ref self );
			}
		}

		/// <summary>
		/// Return true if IP is mapped IPv4
		/// </summary>
		public bool IsIPv4
		{
			get
			{
				var self = this;
				return SteamAPI_IsIPv4( ref self );
			}
		}

		// /// <summary>
		// /// Return true if IP is a fake IPv4 for Steam Datagram Relay
		// /// </summary>
		// public bool IsFakeIPv4
		// {
		// 	get
		// 	{
		// 		SteamNetworkingIPAddr self = this;
		// 		return SteamNetworkingUtils.Internal.IsFakeIPv4( InternalGetIPv4( ref self ) );
		// 	}
		// }

		/// <summary>
		/// Return true if this identity is localhost.  (Either IPv6 ::1, or IPv4 127.0.0.1)
		/// </summary>
		public bool IsLocalHost
		{
			get
			{
				var self = this;
				return SteamAPI_IsLocalHost( ref self );
			}
		}

		/// <summary>
		/// Get the Address section
		/// </summary>
		public IPAddress Address
		{
			get
			{
				if ( IsIPv4 )
				{
					SteamNetworkingIPAddr self = this;
					var ip = SteamAPI_GetIPv4( ref self  );
					return Utility.Int32ToIp( ip );
				}

				if ( IsIPv6AllZeros )
				{
					return IPAddress.IPv6Loopback;
				}

				throw new System.NotImplementedException( "Oops - no IPV6 support yet?" );
			}
		}

		// public override string ToString()
		// {
		// 	using var ptr = Helpers.TakeMemory();
		// 	var self = this;
		// 	InternalToString( ref self, ptr, Helpers.MemoryBufferSize, true );
		// 	return Helpers.MemoryToString( ptr );
		// }
    }
}