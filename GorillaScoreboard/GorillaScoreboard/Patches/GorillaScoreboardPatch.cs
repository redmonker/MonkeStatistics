using GorillaScoreboard.Pages;
using HarmonyLib;
using MonkeStatistics.Core;

namespace GorillaScoreboard.Patches
{
    [HarmonyPatch(typeof(GorillaScoreBoard), "RedrawPlayerLines", MethodType.Normal)]
    internal class GorillaScoreboardPatch
    {
        [HarmonyPostfix]
        private static void Hook()
        {
            // redraw page
            if (UIManager.CurrentPage.GetType() == typeof(PlayerList))
            {
                PlayerList playerList = UIManager.CurrentPage as PlayerList;
                playerList.DrawPage();
            }
        }
    }
}
