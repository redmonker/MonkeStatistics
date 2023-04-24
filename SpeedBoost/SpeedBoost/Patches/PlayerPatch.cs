using GorillaLocomotion;
using HarmonyLib;

namespace SpeedBoost.Patches
{
    [HarmonyPatch(typeof(Player), "FixedUpdate", MethodType.Normal)]
    internal class PlayerPatch
    {
        [HarmonyPostfix]
        private static void Postfix()
        {
            if (Main.RoomValid && Main.Enabled)
                Player.Instance.jumpMultiplier = Main.SpeedBoost;
        }
    }
}
