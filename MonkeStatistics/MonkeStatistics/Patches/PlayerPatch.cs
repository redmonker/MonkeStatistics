using HarmonyLib;

namespace MonkeStatistics.Patches
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player), "Awake", MethodType.Normal)]
    internal class PlayerPatch
    {
        [HarmonyPostfix]
        private static void Patch()
        {
            new Core.CreateWatch();
        }
    }
}
