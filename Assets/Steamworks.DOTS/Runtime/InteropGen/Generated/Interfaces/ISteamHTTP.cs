using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamHTTP
	{
		public const string Version = "STEAMHTTP_INTERFACE_VERSION003";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamHTTP_v003", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamHTTP_v003();
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerHTTP_v003", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamGameServerHTTP_v003();
		/// Construct use accessor to find interface
		public ISteamHTTP( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamHTTP_v003();
			}
			if ( isGameServer )
			{
				Self = SteamAPI_SteamGameServerHTTP_v003();
			}
		}
		public ISteamHTTP( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamHTTP_CreateHTTPRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_CreateHTTPRequest", CallingConvention = Platform.CC ) ]
		internal static extern HTTPRequestHandle _SteamAPI_ISteamHTTP_CreateHTTPRequest( IntPtr self, EHTTPMethod eHTTPRequestMethod, IntPtr pchAbsoluteURL );
		#endregion
		internal HTTPRequestHandle CreateHTTPRequest( EHTTPMethod eHTTPRequestMethod, string pchAbsoluteURL )
		{
			using var str__pchAbsoluteURL = new Utf8StringToNative( pchAbsoluteURL );
			var returnValue = _SteamAPI_ISteamHTTP_CreateHTTPRequest( Self, eHTTPRequestMethod, str__pchAbsoluteURL.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestContextValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestContextValue", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestContextValue( IntPtr self, HTTPRequestHandle hRequest, ulong ulContextValue );
		#endregion
		internal bool SetHTTPRequestContextValue( HTTPRequestHandle hRequest, ulong ulContextValue )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestContextValue( Self, hRequest, ulContextValue );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout( IntPtr self, HTTPRequestHandle hRequest, uint unTimeoutSeconds );
		#endregion
		internal bool SetHTTPRequestNetworkActivityTimeout( HTTPRequestHandle hRequest, uint unTimeoutSeconds )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout( Self, hRequest, unTimeoutSeconds );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue( IntPtr self, HTTPRequestHandle hRequest, IntPtr pchHeaderName, IntPtr pchHeaderValue );
		#endregion
		internal bool SetHTTPRequestHeaderValue( HTTPRequestHandle hRequest, string pchHeaderName, string pchHeaderValue )
		{
			using var str__pchHeaderName = new Utf8StringToNative( pchHeaderName );
			using var str__pchHeaderValue = new Utf8StringToNative( pchHeaderValue );
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue( Self, hRequest, str__pchHeaderName.Pointer, str__pchHeaderValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter( IntPtr self, HTTPRequestHandle hRequest, IntPtr pchParamName, IntPtr pchParamValue );
		#endregion
		internal bool SetHTTPRequestGetOrPostParameter( HTTPRequestHandle hRequest, string pchParamName, string pchParamValue )
		{
			using var str__pchParamName = new Utf8StringToNative( pchParamName );
			using var str__pchParamValue = new Utf8StringToNative( pchParamValue );
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter( Self, hRequest, str__pchParamName.Pointer, str__pchParamValue.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SendHTTPRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SendHTTPRequest( IntPtr self, HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle );
		#endregion
		internal bool SendHTTPRequest( HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SendHTTPRequest( Self, hRequest, ref pCallHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse( IntPtr self, HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle );
		#endregion
		internal bool SendHTTPRequestAndStreamResponse( HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse( Self, hRequest, ref pCallHandle );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_DeferHTTPRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_DeferHTTPRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_DeferHTTPRequest( IntPtr self, HTTPRequestHandle hRequest );
		#endregion
		internal bool DeferHTTPRequest( HTTPRequestHandle hRequest )
		{
			var returnValue = _SteamAPI_ISteamHTTP_DeferHTTPRequest( Self, hRequest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_PrioritizeHTTPRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_PrioritizeHTTPRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_PrioritizeHTTPRequest( IntPtr self, HTTPRequestHandle hRequest );
		#endregion
		internal bool PrioritizeHTTPRequest( HTTPRequestHandle hRequest )
		{
			var returnValue = _SteamAPI_ISteamHTTP_PrioritizeHTTPRequest( Self, hRequest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize( IntPtr self, HTTPRequestHandle hRequest, IntPtr pchHeaderName, ref uint unResponseHeaderSize );
		#endregion
		internal bool GetHTTPResponseHeaderSize( HTTPRequestHandle hRequest, string pchHeaderName, ref uint unResponseHeaderSize )
		{
			using var str__pchHeaderName = new Utf8StringToNative( pchHeaderName );
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize( Self, hRequest, str__pchHeaderName.Pointer, ref unResponseHeaderSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue( IntPtr self, HTTPRequestHandle hRequest, IntPtr pchHeaderName, ref byte pHeaderValueBuffer, uint unBufferSize );
		#endregion
		internal bool GetHTTPResponseHeaderValue( HTTPRequestHandle hRequest, string pchHeaderName, ref byte pHeaderValueBuffer, uint unBufferSize )
		{
			using var str__pchHeaderName = new Utf8StringToNative( pchHeaderName );
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue( Self, hRequest, str__pchHeaderName.Pointer, ref pHeaderValueBuffer, unBufferSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPResponseBodySize
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodySize", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPResponseBodySize( IntPtr self, HTTPRequestHandle hRequest, ref uint unBodySize );
		#endregion
		internal bool GetHTTPResponseBodySize( HTTPRequestHandle hRequest, ref uint unBodySize )
		{
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPResponseBodySize( Self, hRequest, ref unBodySize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPResponseBodyData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodyData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPResponseBodyData( IntPtr self, HTTPRequestHandle hRequest, ref byte pBodyDataBuffer, uint unBufferSize );
		#endregion
		internal bool GetHTTPResponseBodyData( HTTPRequestHandle hRequest, ref byte pBodyDataBuffer, uint unBufferSize )
		{
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPResponseBodyData( Self, hRequest, ref pBodyDataBuffer, unBufferSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData( IntPtr self, HTTPRequestHandle hRequest, uint cOffset, ref byte pBodyDataBuffer, uint unBufferSize );
		#endregion
		internal bool GetHTTPStreamingResponseBodyData( HTTPRequestHandle hRequest, uint cOffset, ref byte pBodyDataBuffer, uint unBufferSize )
		{
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData( Self, hRequest, cOffset, ref pBodyDataBuffer, unBufferSize );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_ReleaseHTTPRequest
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseHTTPRequest", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_ReleaseHTTPRequest( IntPtr self, HTTPRequestHandle hRequest );
		#endregion
		internal bool ReleaseHTTPRequest( HTTPRequestHandle hRequest )
		{
			var returnValue = _SteamAPI_ISteamHTTP_ReleaseHTTPRequest( Self, hRequest );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct( IntPtr self, HTTPRequestHandle hRequest, ref float pflPercentOut );
		#endregion
		internal bool GetHTTPDownloadProgressPct( HTTPRequestHandle hRequest, ref float pflPercentOut )
		{
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct( Self, hRequest, ref pflPercentOut );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody( IntPtr self, HTTPRequestHandle hRequest, IntPtr pchContentType, byte* pubBody, uint unBodyLen );
		#endregion
		internal bool SetHTTPRequestRawPostBody( HTTPRequestHandle hRequest, string pchContentType, byte* pubBody, uint unBodyLen )
		{
			using var str__pchContentType = new Utf8StringToNative( pchContentType );
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody( Self, hRequest, str__pchContentType.Pointer, pubBody, unBodyLen );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_CreateCookieContainer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_CreateCookieContainer", CallingConvention = Platform.CC ) ]
		internal static extern HTTPCookieContainerHandle _SteamAPI_ISteamHTTP_CreateCookieContainer( IntPtr self, [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowResponsesToModify );
		#endregion
		internal HTTPCookieContainerHandle CreateCookieContainer( [ MarshalAs( UnmanagedType.U1 ) ] bool bAllowResponsesToModify )
		{
			var returnValue = _SteamAPI_ISteamHTTP_CreateCookieContainer( Self, bAllowResponsesToModify );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_ReleaseCookieContainer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseCookieContainer", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_ReleaseCookieContainer( IntPtr self, HTTPCookieContainerHandle hCookieContainer );
		#endregion
		internal bool ReleaseCookieContainer( HTTPCookieContainerHandle hCookieContainer )
		{
			var returnValue = _SteamAPI_ISteamHTTP_ReleaseCookieContainer( Self, hCookieContainer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetCookie
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetCookie", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetCookie( IntPtr self, HTTPCookieContainerHandle hCookieContainer, IntPtr pchHost, IntPtr pchUrl, IntPtr pchCookie );
		#endregion
		internal bool SetCookie( HTTPCookieContainerHandle hCookieContainer, string pchHost, string pchUrl, string pchCookie )
		{
			using var str__pchHost = new Utf8StringToNative( pchHost );
			using var str__pchUrl = new Utf8StringToNative( pchUrl );
			using var str__pchCookie = new Utf8StringToNative( pchCookie );
			var returnValue = _SteamAPI_ISteamHTTP_SetCookie( Self, hCookieContainer, str__pchHost.Pointer, str__pchUrl.Pointer, str__pchCookie.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer( IntPtr self, HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer );
		#endregion
		internal bool SetHTTPRequestCookieContainer( HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer( Self, hRequest, hCookieContainer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo( IntPtr self, HTTPRequestHandle hRequest, IntPtr pchUserAgentInfo );
		#endregion
		internal bool SetHTTPRequestUserAgentInfo( HTTPRequestHandle hRequest, string pchUserAgentInfo )
		{
			using var str__pchUserAgentInfo = new Utf8StringToNative( pchUserAgentInfo );
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo( Self, hRequest, str__pchUserAgentInfo.Pointer );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate( IntPtr self, HTTPRequestHandle hRequest, [ MarshalAs( UnmanagedType.U1 ) ] bool bRequireVerifiedCertificate );
		#endregion
		internal bool SetHTTPRequestRequiresVerifiedCertificate( HTTPRequestHandle hRequest, [ MarshalAs( UnmanagedType.U1 ) ] bool bRequireVerifiedCertificate )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate( Self, hRequest, bRequireVerifiedCertificate );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS( IntPtr self, HTTPRequestHandle hRequest, uint unMilliseconds );
		#endregion
		internal bool SetHTTPRequestAbsoluteTimeoutMS( HTTPRequestHandle hRequest, uint unMilliseconds )
		{
			var returnValue = _SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS( Self, hRequest, unMilliseconds );
			return returnValue;
		}
		
		#region SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut( IntPtr self, HTTPRequestHandle hRequest, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbWasTimedOut );
		#endregion
		internal bool GetHTTPRequestWasTimedOut( HTTPRequestHandle hRequest, [ MarshalAs( UnmanagedType.U1 ) ] ref bool pbWasTimedOut )
		{
			var returnValue = _SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut( Self, hRequest, ref pbWasTimedOut );
			return returnValue;
		}
		
	}
}
