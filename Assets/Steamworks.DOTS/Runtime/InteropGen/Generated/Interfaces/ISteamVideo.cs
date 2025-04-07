using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Steamworks
{
	internal unsafe partial struct ISteamVideo
	{
		public const string Version = "STEAMVIDEO_INTERFACE_V007";
		
		[ NativeDisableUnsafePtrRestriction ] public IntPtr Self;
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamVideo_v007", CallingConvention = Platform.CC ) ]
		public static extern IntPtr SteamAPI_SteamVideo_v007();
		/// Construct use accessor to find interface
		public ISteamVideo( bool isGameServer )
		{
			Self = IntPtr.Zero;
			if ( !isGameServer )
			{
				Self = SteamAPI_SteamVideo_v007();
			}
		}
		public ISteamVideo( IntPtr iface )
		{
			Self = iface;
		}
		#region SteamAPI_ISteamVideo_GetVideoURL
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamVideo_GetVideoURL", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamVideo_GetVideoURL( IntPtr self, AppId_t unVideoAppID );
		#endregion
		internal void GetVideoURL( AppId_t unVideoAppID )
		{
			_SteamAPI_ISteamVideo_GetVideoURL( Self, unVideoAppID );
		}
		
		#region SteamAPI_ISteamVideo_IsBroadcasting
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamVideo_IsBroadcasting", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamVideo_IsBroadcasting( IntPtr self, ref int pnNumViewers );
		#endregion
		internal bool IsBroadcasting( ref int pnNumViewers )
		{
			var returnValue = _SteamAPI_ISteamVideo_IsBroadcasting( Self, ref pnNumViewers );
			return returnValue;
		}
		
		#region SteamAPI_ISteamVideo_GetOPFSettings
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamVideo_GetOPFSettings", CallingConvention = Platform.CC ) ]
		internal static extern void _SteamAPI_ISteamVideo_GetOPFSettings( IntPtr self, AppId_t unVideoAppID );
		#endregion
		internal void GetOPFSettings( AppId_t unVideoAppID )
		{
			_SteamAPI_ISteamVideo_GetOPFSettings( Self, unVideoAppID );
		}
		
		#region SteamAPI_ISteamVideo_GetOPFStringForApp
		[ DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamVideo_GetOPFStringForApp", CallingConvention = Platform.CC ) ]
		[ return: MarshalAs( UnmanagedType.I1 ) ]
		internal static extern bool _SteamAPI_ISteamVideo_GetOPFStringForApp( IntPtr self, AppId_t unVideoAppID, IntPtr pchBuffer, ref int pnBufferSize );
		#endregion
		internal bool GetOPFStringForApp( AppId_t unVideoAppID, out string pchBuffer, ref int pnBufferSize )
		{
			using var mem__pchBuffer = new Utility.Memory( Utility.MemoryBufferSize );
			var returnValue = _SteamAPI_ISteamVideo_GetOPFStringForApp( Self, unVideoAppID, mem__pchBuffer.Ptr, ref pnBufferSize );
			pchBuffer = Utility.MemoryToString( mem__pchBuffer );
			return returnValue;
		}
		
	}
}
