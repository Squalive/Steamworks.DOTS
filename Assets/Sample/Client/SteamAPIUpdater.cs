using System;
using UnityEngine;

namespace Steamworks.Sample
{
    public class SteamAPIUpdater : MonoBehaviour
    {
        private void Update()
        {
            SteamClientGlobal.Frame();
        }
    }
    
}