/*
 - will add this later, but first I will need permission from somebody:/
Note this script is untested, and unused.
 
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;

namespace MonkeStatistics.Patches
{
    [HarmonyPatch(typeof(VRRig), "Awake", MethodType.Normal)]
    internal class VRRigPatch
    {
        [HarmonyPostfix]
        private static void Patch(VRRig __instance)
        {
            Player player = __instance.GetComponent<PhotonView>().Owner;
            if (player.IsLocal)
                return;
            if (player.CustomProperties.ToString().Contains(Main.GUID))
                new Core.VRRigWatch(__instance);
        }
    }
}
*/