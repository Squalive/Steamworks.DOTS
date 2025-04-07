using System;
using UnityEngine;

namespace Steamworks.Sample
{
    public class SteamGameServerUpdater : MonoBehaviour
    {
        private void Update()
        {
            SteamGameServerGlobal.Frame();
        }
    }
}