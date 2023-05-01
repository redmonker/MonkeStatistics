using GorillaScoreboard.Pages;
using HarmonyLib;
using MonkeStatistics.Core;

namespace GorillaScoreboard.Patches
{
    [HarmonyPatch(typeof(GorillaPlayerScoreboardLine), "PressButton", MethodType.Normal)]
    internal class GorillaPlayerScoreboardLinePatch
    {
        [HarmonyPostfix]
        private static void Hook()
        {
            if (UIManager.CurrentPage.GetType() == typeof(PlayerList))
            {
                PlayerList playerList = UIManager.CurrentPage as PlayerList;
                playerList.DrawPage();
            }
        }
    }
}
