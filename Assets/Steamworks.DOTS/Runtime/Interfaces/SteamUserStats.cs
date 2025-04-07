using System;
using Steamworks.Data;
using Unity.Entities;

namespace Steamworks
{
    public struct SteamUserStats : IComponentData
    {
        internal ISteamUserStats Internal;
        internal SteamUserStats( IntPtr iface )
        {
            Internal = new ISteamUserStats( iface );
        }

        /// <summary>
        /// <para>Asynchronously downloads stats and achievements for the specified user from the server.</para>
        ///
        /// <para>These stats are not automatically updated; you'll need to call this function again to refresh any data that may have change.</para>
        ///
        /// <para>To keep from using too much memory, an least recently used cache (LRU) is maintained and other user's stats will occasionally be unloaded.
        /// When this happens a UserStatsUnloaded_t callback is sent.
        /// After receiving this callback the user's stats will be unavailable until this function is called again.</para>
        ///
        /// <para>The equivalent function for the local user is <see cref="RequestCurrentStats"/>, the equivalent function for game servers is <see cref="SteamGameServerStats.RequestUserStats"/>.</para>
        /// </summary>
        /// <param name="steamIDUser">The Steam ID of the user to request stats for.</param>
        /// <returns> SteamAPICall_t to be used with a UserStatsReceived_t call result.</returns>
        public CallResult<UserStatsReceived_t> RequestUserStats( SteamId steamIDUser )
        {
            return Internal.RequestUserStats( steamIDUser );
        }
    }
}