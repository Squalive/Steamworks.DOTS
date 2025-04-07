using System;
using Steamworks.Data;
using Unity.Collections;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamScreenshots : IComponentData
    {
        internal ISteamScreenshots Internal;

        internal SteamScreenshots( IntPtr iface )
        {
            Internal = new ISteamScreenshots( iface );
        }

        public void Trigger() => Internal.TriggerScreenshot();

        public bool TagUser( ScreenshotHandle hScreenshot, SteamId userId ) => Internal.TagUser( hScreenshot, userId );

        public bool TagPublishedFile( ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID ) => Internal.TagPublishedFile( hScreenshot, unPublishedFileID );

        /// <summary>
        /// Sets optional metadata about a screenshot's location. For example, the name of the map it was taken on.
        /// </summary>
        /// <param name="hScreenshot">The handle to the screenshot to tag.</param>
        /// <param name="pchLocation">The location in the game where this screenshot was taken. This can not be longer than k_cubUFSTagValueMax.</param>
        /// <typeparam name="TStr"></typeparam>
        /// <returns>true if the location was successfully added to the screenshot. false if hScreenshot was invalid, or pchLocation is invalid or too long.</returns>
        public bool SetLocation<TStr>( ScreenshotHandle hScreenshot, in TStr pchLocation ) where TStr : unmanaged, IUTF8Bytes, INativeList<byte>
        {
            using var memPchLocation = Utf8StringToNative.CreateFromUnsafeString( pchLocation );
            return Internal._SetLocation( hScreenshot, memPchLocation );
        }
    }
}