using GorillaLocomotion;
using HarmonyLib;

namespace SpeedBoost.Patches
{
    [HarmonyPatch(typeof(Player), "FixedUpdate", MethodType.Normal)]
    internal class PlayerPatch
    {
        [HarmonyPrefix]
        private static void Patcj()
        {
            if (Main.RoomValid && Main.Enabled)
            {
                Player.Instance.jumpMultiplier = Main.SpeedBoost;
                Player.Instance.maxJumpSpeed = Main.SpeedBoost;
            }
            else
                if (Player.Instance.maxJumpSpeed = Main.SpeedBoost)
        }

        // Not a patch, but.... uuu where else do I put it o-o
        private static void Reset()
        {
            Player.Instance.maxJumpSpeed = 6.5f;
        }
    }
}
