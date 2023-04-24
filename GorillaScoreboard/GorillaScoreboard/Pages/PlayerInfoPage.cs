using HarmonyLib;
using MonkeStatistics.API;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    internal class PlayerInfoPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();

            var player = MyPage.SelectedPlayer;
            bool IsMuted = PlayerPrefs.GetInt(player.UserId, 0) != 0;

            AddLines(3);
            AddLine(IsMuted ? "Unmute" : "Mute", new ButtonInfo(MutePlayer_ButtonPressed, 0, ButtonInfo.ButtonType.Toggle, IsMuted));

            SetTitle(player.NickName);
            SetAuthor("");
            SetLines();
            SetBackButtonOverride(typeof(MyPage));
        }

        private void MutePlayer_ButtonPressed(object Sender, object[] Args)
        {
            var player = MyPage.SelectedPlayer;
            bool IsMuted = PlayerPrefs.GetInt(player.UserId) == 1;

            if (IsMuted)
                PlayerPrefs.SetInt(player.UserId, 0);
            else
                PlayerPrefs.SetInt(player.UserId, 1);

            foreach (GorillaScoreBoard scoreboard in GameObject.FindObjectsOfType<GorillaScoreBoard>())
                Traverse.Create(scoreboard).Method("InfrequentUpdate");
            // redraw
            OnPageOpen();
        }
    }
}
