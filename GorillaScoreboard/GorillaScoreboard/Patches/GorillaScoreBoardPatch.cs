using HarmonyLib;
using System.Collections.Generic;

namespace GorillaScoreboard.Patches
{
    [HarmonyPatch(typeof(GorillaScoreBoard), "InfrequentUpdate", MethodType.Normal)]
    internal class GorillaScoreBoardPatch
    {
        public static List<GorillaPlayerScoreboardLine> Lines;
        [HarmonyPostfix]
        private static void Patch(GorillaScoreBoard __instance)
        {
            Lines = __instance.lines;
        }
    }
}
