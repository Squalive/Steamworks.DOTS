using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks.Data
{
	public partial struct gameserveritem_t
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_Construct", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Construct( ref gameserveritem_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_GetName", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetName( ref gameserveritem_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_SetName", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetName( ref gameserveritem_t self, IntPtr pName );
		
	}
	
	public partial struct MatchMakingKeyValuePair_t
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_MatchMakingKeyValuePair_t_Construct", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Construct( ref MatchMakingKeyValuePair_t self );
		
	}
	
	public partial struct servernetadr_t
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Construct", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Construct( ref servernetadr_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Init", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Init( ref servernetadr_t self, uint ip, ushort usQueryPort, ushort usConnectionPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetQueryPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern ushort SteamAPI_GetQueryPort( ref servernetadr_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetQueryPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetQueryPort( ref servernetadr_t self, ushort usPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern ushort SteamAPI_GetConnectionPort( ref servernetadr_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetConnectionPort", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetConnectionPort( ref servernetadr_t self, ushort usPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern uint SteamAPI_GetIP( ref servernetadr_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_SetIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIP( ref servernetadr_t self, uint unIP );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionAddressString", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetConnectionAddressString( ref servernetadr_t self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_GetQueryAddressString", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetQueryAddressString( ref servernetadr_t self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_IsLessThan", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsLessThan( ref servernetadr_t self, ref servernetadr_t netadr );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_servernetadr_t_Assign", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Assign( ref servernetadr_t self, ref servernetadr_t that );
		
	}
	
	public partial struct SteamDatagramHostedAddress
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_Clear", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Clear( ref SteamDatagramHostedAddress self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_GetPopID", CallingConvention = Platform.CC ) ]
		public static unsafe extern SteamNetworkingPOPID SteamAPI_GetPopID( ref SteamDatagramHostedAddress self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_SetDevAddress", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetDevAddress( ref SteamDatagramHostedAddress self, uint nIP, ushort nPort, SteamNetworkingPOPID popid );
		
	}
	
	public partial struct SteamIPAddress_t
	{
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamIPAddress_t_IsSet", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsSet( ref SteamIPAddress_t self );
		
	}
	
	public partial struct SteamNetworkingConfigValue_t
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt32", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetInt32( ref SteamNetworkingConfigValue_t self, ESteamNetworkingConfigValue eVal, int data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt64", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetInt64( ref SteamNetworkingConfigValue_t self, ESteamNetworkingConfigValue eVal, long data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetFloat", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetFloat( ref SteamNetworkingConfigValue_t self, ESteamNetworkingConfigValue eVal, float data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetPtr", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetPtr( ref SteamNetworkingConfigValue_t self, ESteamNetworkingConfigValue eVal, IntPtr data );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetString", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetString( ref SteamNetworkingConfigValue_t self, ESteamNetworkingConfigValue eVal, IntPtr data );
		
	}
	
	public partial struct SteamNetworkingIdentity
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_Clear", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Clear( ref SteamNetworkingIdentity self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsInvalid", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsInvalid( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetSteamID( ref SteamNetworkingIdentity self, SteamId steamID );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID", CallingConvention = Platform.CC ) ]
		public static unsafe extern SteamId SteamAPI_GetSteamID( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID64", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetSteamID64( ref SteamNetworkingIdentity self, ulong steamID );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID64", CallingConvention = Platform.CC ) ]
		public static unsafe extern ulong SteamAPI_GetSteamID64( ref SteamNetworkingIdentity self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetXboxPairwiseID", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_SetXboxPairwiseID( ref SteamNetworkingIdentity self, IntPtr pszString );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetXboxPairwiseID", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetXboxPairwiseID( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetPSNID", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetPSNID( ref SteamNetworkingIdentity self, ulong id );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetPSNID", CallingConvention = Platform.CC ) ]
		public static unsafe extern ulong SteamAPI_GetPSNID( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPAddr", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPAddr( ref SteamNetworkingIdentity self, ref SteamNetworkingIPAddr addr );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPAddr", CallingConvention = Platform.CC ) ]
		public static unsafe extern IntPtr SteamAPI_GetIPAddr( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPv4Addr", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv4Addr( ref SteamNetworkingIdentity self, uint nIPv4, ushort nPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern uint SteamAPI_GetIPv4( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetFakeIPType", CallingConvention = Platform.CC ) ]
		public static unsafe extern ESteamNetworkingFakeIPType SteamAPI_GetFakeIPType( ref SteamNetworkingIdentity self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsFakeIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsFakeIP( ref SteamNetworkingIdentity self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetLocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetLocalHost( ref SteamNetworkingIdentity self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsLocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsLocalHost( ref SteamNetworkingIdentity self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericString", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_SetGenericString( ref SteamNetworkingIdentity self, IntPtr pszString );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericString", CallingConvention = Platform.CC ) ]
		public static unsafe extern Utf8StringPtr SteamAPI_GetGenericString( ref SteamNetworkingIdentity self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericBytes", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_SetGenericBytes( ref SteamNetworkingIdentity self, IntPtr data, uint cbLen );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericBytes", CallingConvention = Platform.CC ) ]
		public static unsafe extern byte SteamAPI_GetGenericBytes( ref SteamNetworkingIdentity self, ref int cbLen );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsEqualTo", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsEqualTo( ref SteamNetworkingIdentity self, ref SteamNetworkingIdentity x );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ToString", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_ToString( ref SteamNetworkingIdentity self, IntPtr buf, uint cbBuf );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ParseString", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_ParseString( ref SteamNetworkingIdentity self, IntPtr pszStr );
		
	}
	
	public partial struct SteamNetworkingIPAddr
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_Clear", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Clear( ref SteamNetworkingIPAddr self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv6AllZeros", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsIPv6AllZeros( ref SteamNetworkingIPAddr self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv6( ref SteamNetworkingIPAddr self, ref byte ipv6, ushort nPort );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv4( ref SteamNetworkingIPAddr self, uint nIP, ushort nPort );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsIPv4( ref SteamNetworkingIPAddr self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetIPv4", CallingConvention = Platform.CC ) ]
		public static unsafe extern uint SteamAPI_GetIPv4( ref SteamNetworkingIPAddr self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6LocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_SetIPv6LocalHost( ref SteamNetworkingIPAddr self, ushort nPort );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsLocalHost", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsLocalHost( ref SteamNetworkingIPAddr self );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ToString", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_ToString( ref SteamNetworkingIPAddr self, IntPtr buf, uint cbBuf, [ MarshalAs( UnmanagedType.U1 ) ] bool bWithPort );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ParseString", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_ParseString( ref SteamNetworkingIPAddr self, IntPtr pszStr );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsEqualTo", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsEqualTo( ref SteamNetworkingIPAddr self, ref SteamNetworkingIPAddr x );
		
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetFakeIPType", CallingConvention = Platform.CC ) ]
		public static unsafe extern ESteamNetworkingFakeIPType SteamAPI_GetFakeIPType( ref SteamNetworkingIPAddr self );
		
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsFakeIP", CallingConvention = Platform.CC ) ]
		public static unsafe extern bool SteamAPI_IsFakeIP( ref SteamNetworkingIPAddr self );
		
	}
	
	public partial struct NetMsg
	{
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingMessage_t_Release", CallingConvention = Platform.CC ) ]
		public static unsafe extern void SteamAPI_Release( ref NetMsg self );
		
	}
	
}
