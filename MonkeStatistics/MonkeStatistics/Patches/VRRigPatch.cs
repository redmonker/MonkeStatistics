/*using HarmonyLib;
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
            if (PhotonNetwork.InRoom && !__instance.isMyPlayer)
            {
                Player player = __instance.GetComponent<PhotonView>().Owner;
                //if (player.CustomProperties.ToString().Contains(Main.GUID))
                new Core.VRRigWatch(__instance);
            }
        }
    }
}
*/