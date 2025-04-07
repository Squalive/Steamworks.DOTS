using System;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamUser : IComponentData
    {
        internal ISteamUser Internal;
        internal SteamUser( IntPtr iface )
        {
            Internal = new ISteamUser( iface );
        }

        public bool IsLoggedOn => Internal.BLoggedOn();

        /// <summary>
        /// <para>Authenticate the ticket from the entity Steam ID to be sure it is valid and isn't reused. Note that identity is not confirmed until the callback
        /// ValidateAuthTicketResponse_t is received and the return value in that callback is checked for success.</para>
        ///
        /// <para>The ticket is created on the entity with GetAuthSessionTicket or ISteamGameServer::GetAuthSessionTicket and then needs to be provided over the network for the other end to validate.</para>
        ///
        /// <para>This registers for additional ValidateAuthTicketResponse_t callbacks if the entity goes offline or cancels the ticket. See EAuthSessionResponse for more information.</para>
        ///
        /// <para>When the multiplayer session terminates you must call <see cref="EndAuthSession"/>.</para>
        /// </summary>
        /// <param name="pAuthTicket">The auth ticket to validate.</param>
        /// <param name="steamId">The entity's Steam ID that sent this ticket.</param>
        /// <returns>Triggers a ValidateAuthTicketResponse_t callback.</returns>
        public unsafe EBeginAuthSessionResult BeginAuthSession( in NativeArray<byte> pAuthTicket, SteamId steamId )
        {
            return Internal.BeginAuthSession( ( IntPtr ) pAuthTicket.GetUnsafeReadOnlyPtr(), pAuthTicket.Length, steamId );
        }

        /// <summary>
        /// <para>Ends an auth session that was started with <see cref="BeginAuthSession"/>. This should be called when no longer playing with the specified entity.</para>
        /// </summary>
        /// <param name="steamId"></param>
        public void EndAuthSession( SteamId steamId )
        {
            Internal.EndAuthSession( steamId );
        }

        /// <summary>
        /// <para>Retrieve an authentication ticket to be sent to the entity who wishes to authenticate you.</para>
        ///
        /// <para>After calling this you can send the ticket to the entity where they can then call BeginAuthSession/ISteamGameServer::BeginAuthSession to verify this entity's integrity.</para>
        /// </summary>
        /// <param name="pTicket">The buffer where the new auth ticket will be copied into if the call was successful.</param>
        /// <param name="pcbTicket">	Returns the length of the actual ticket.</param>
        /// <param name="pIdentityRemote">The identity of the remote system that will authenticate the ticket. If it is peer-to-peer then the user steam ID. If it is a game server, then the game server steam ID may be used if it was obtained from a trusted 3rd party, otherwise use the IP address. If it is a service, a string identifier of that service if one if provided.</param>
        /// <returns>Triggers a GetAuthSessionTicketResponse_t callback.
        /// A handle to the auth ticket. When you're done interacting with the entity you must call <see cref="CancelAuthTicket"/> on the handle.</returns>
        public unsafe HAuthTicket GetAuthSessionTicket( ref NativeArray<byte> pTicket, out uint pcbTicket, ref SteamNetworkingIdentity pIdentityRemote )
        {
            pcbTicket = 0;
            return Internal.GetAuthSessionTicket( ( IntPtr ) pTicket.GetUnsafePtr(), pTicket.Length, ref pcbTicket, ref pIdentityRemote );
        }

        /// <summary>
        /// <para>Cancels an auth ticket received from GetAuthSessionTicket. This should be called when no longer playing with the specified entity.</para>
        /// </summary>
        /// <param name="hAuthTicket">The active auth ticket to cancel.</param>
        public void CancelAuthTicket( HAuthTicket hAuthTicket )
        {
            Internal.CancelAuthTicket( hAuthTicket );
        }

        /// <summary>
        /// <para>Starts voice recording.</para>
        ///
        /// <para>Once started, use <see cref="GetAvailableVoice"/> and <see cref="GetVoice"/> to get the data, and then call <see cref="StopVoiceRecording"/> when the user has released their push-to-talk hotkey or the game session has completed.</para>
        /// </summary>
        public void StartVoiceRecording() => Internal.StartVoiceRecording();
        
        /// <summary>
        /// <para>Stops voice recording.</para>
        ///
        /// <para>Because people often release push-to-talk keys early, the system will keep recording for a little bit after this function is called. As such, <see cref="GetVoice"/> should continue to be called until it returns k_EVoiceResultNotRecording, only then will voice recording be stopped.</para>
        /// </summary>
        public void StopVoiceRecording() => Internal.StopVoiceRecording();

        /// <summary>
        /// <para>Checks to see if there is captured audio data available from GetVoice, and gets the size of the data.</para>
        ///
        /// <para>Most applications will only use compressed data and should ignore the other parameters, which exist primarily for backwards compatibility. See <see cref="GetVoice"/> for further explanation of "uncompressed" data.</para>
        /// </summary>
        /// <param name="pcbCompressed">Returns the size of the available voice data in bytes.</param>
        /// <returns></returns>
        public EVoiceResult GetAvailableVoice( out uint pcbCompressed )
        {
            pcbCompressed = 0;
            uint pcbUncompressed_Deprecated = 0;
            return Internal.GetAvailableVoice( ref pcbCompressed, ref pcbUncompressed_Deprecated, 0u );
        }

        /// <summary>
        /// <para>Read captured audio data from the microphone buffer.</para>
        ///
        /// <para>The compressed data can be transmitted by your application and decoded back into raw audio data using DecompressVoice on the other side.
        /// The compressed data provided is in an arbitrary format and is not meant to be played directly.</para>
        ///
        /// <para>This should be called once per frame, and at worst no more than four times a second to keep the microphone input delay as low as possible.
        /// Calling this any less may result in gaps in the returned stream.</para>
        ///
        /// <para>It is recommended that you pass in an 8 kilobytes or larger destination buffer for compressed audio. Static buffers are recommended for performance reasons.
        /// However, if you would like to allocate precisely the right amount of space for a buffer before each call you may use GetAvailableVoice to find out how much data is available to be read.</para>
        ///
        /// </summary>
        /// <param name="pDestBuffer">The buffer where the audio data will be copied into.</param>
        /// <param name="nBytesWritten">Returns the number of bytes written into pDestBuffer. This should always be the size returned by <see cref="GetAvailableVoice"/>.</param>
        /// <returns></returns>
        public unsafe EVoiceResult GetVoice( ref NativeArray<byte> pDestBuffer, out uint nBytesWritten )
        {
            nBytesWritten = 0;
            uint nUncompressBytesWritten_Deprecated = 0;
            return Internal.GetVoice( true, ( IntPtr ) pDestBuffer.GetUnsafePtr(), ( uint ) pDestBuffer.Length, ref nBytesWritten,
                false, IntPtr.Zero, 0, ref nUncompressBytesWritten_Deprecated, 0 );
        }

        /// <summary>
        /// <para>Gets the native sample rate of the Steam voice decoder.</para>
        ///
        /// <para>Using this sample rate for DecompressVoice will perform the least CPU processing.
        /// However, the final audio quality will depend on how well the audio device (and/or your application's audio output SDK) deals with lower sample rates.
        /// You may find that you get the best audio output quality when you ignore this function and use the native sample rate of your audio output device, which is usually 48000 or 44100.</para>
        /// </summary>
        /// <returns></returns>
        public uint GetVoiceOptimalSampleRate() => Internal.GetVoiceOptimalSampleRate();

        /// <summary>
        /// Decodes the compressed voice data returned by GetVoice.
        ///
        /// <para>The output data is raw single-channel 16-bit PCM audio. The decoder supports any sample rate from 11025 to 48000.
        /// See GetVoiceOptimalSampleRate for more information.</para>
        ///
        /// It is recommended that you start with a 20KiB buffer and then reallocate as necessary.
        /// </summary>
        /// <param name="pCompressed"></param>
        /// <param name="pDestBuffer"></param>
        /// <param name="nBytesWritten"></param>
        /// <param name="nDesiredSampleRate"></param>
        /// <returns>The internal sample rate of the Steam Voice decoder.</returns>
        public unsafe EVoiceResult DecompressVoice( in NativeArray<byte> pCompressed, ref NativeArray<byte> pDestBuffer, out uint nBytesWritten, uint nDesiredSampleRate  )
        {
            nBytesWritten = 0;
            return Internal.DecompressVoice( 
                ( IntPtr ) pCompressed.GetUnsafeReadOnlyPtr(), 
                ( uint ) pCompressed.Length,
                ( IntPtr ) pDestBuffer.GetUnsafePtr(), 
                ( uint ) pDestBuffer.Length,
                ref nBytesWritten, nDesiredSampleRate );
        }

        /// <summary>
        /// Checks if the user owns a specific piece of Downloadable Content (DLC).
        ///
        /// This can only be called after sending the users auth ticket to ISteamGameServer::BeginAuthSession
        /// </summary>
        /// <param name="steamID">The Steam ID of the user that sent the auth ticket.</param>
        /// <param name="appID">The DLC App ID to check if the user owns it.</param>
        /// <returns></returns>
        public EUserHasLicenseForAppResult UserHasLicenseForApp( SteamId steamID, AppId_t appID )
        {
            return Internal.UserHasLicenseForApp( steamID, appID );
        }
    }
}