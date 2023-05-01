/*using GorillaScoreboard.Util;
using MonkeStatistics.API;
using Photon.Realtime;
using System.Linq;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    internal class PlayerInfo : Page
    {
        private Player player;
        public override void OnPageOpen()
        {
            player = PlayerList.player;

            base.OnPageOpen();
            SetTitle(player.NickName);
            SetAuthor("");
            SetBackButtonOverride(typeof(PlayerList));

            DrawPage();
        }

        public void DrawPage()
        {
            "Redrawing lines".Log();

            AddLine(1);
            AddLine("Muted : ", new ButtonInfo(OnMutePress, 0, ButtonInfo.ButtonType.Toggle, GetIsMuted()));
            AddLine(1);
            AddText("Unfortantly the rules for mod creation are to inconspicuous. Thus I will not add more to page as I will probably be yelled at by AHauntedArmy:/");

            SetLines();
        }

        private void OnMutePress(object Sender, object[] Args)
        {
            GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer == player).ToArray();
            Lines[0].PressButton(!GetIsMuted(), GorillaPlayerLineButton.ButtonType.Mute);

            foreach (GorillaPlayerScoreboardLine Line in Lines)
            {
                Line.muteButton.isOn = GetIsMuted();
                Line.muteButton.UpdateColor();
            }
            $"Muted? {PlayerPrefs.GetInt(player.UserId)}".Log();

            DrawPage();
        }

        private bool GetIsMuted()
        {
            return PlayerPrefs.GetInt(player.UserId, 0) != 0;
        }
    }
}
*/