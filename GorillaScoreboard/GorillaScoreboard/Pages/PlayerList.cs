using GorillaScoreboard.Util;
using MonkeStatistics.API;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    [DisplayInMainMenu("Scoreboard", CanWorkInNoneModded = true)]
    internal class PlayerList : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            if (PhotonNetwork.InRoom)
                DrawPage();
            else
            {
                SetLines();
                AddText("You must be in a room to use this.");
            }
            SetBackButtonOverride(typeof(MonkeStatistics.Core.Pages.MainPage));
            SetTitle("Scoreboard");
        }

        public void DrawPage()
        {
            Player[] players = PhotonNetwork.PlayerList;
            TextLines = new Line[0];
            for (int i = 0; i < players.Length; i++)
            {
                string UserId = players[i].UserId;
                bool IsMuted = PlayerPrefs.GetInt(UserId, 0) != 0;
                ButtonInfo buttonInfo = players[i].IsLocal ? null : new ButtonInfo(OnMutePress, i, ButtonInfo.ButtonType.Toggle, GetIsMuted(players[i]));

                AddLine(players[i].NickName, buttonInfo);
            }
            SetAuthor($"User Count:{players.Length}");
            SetLines();
        }

        private void OnMutePress(object Sender, object[] Args)
        {
            Player player = PhotonNetwork.PlayerList[(int)Args[0]];
            GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer == player).ToArray();
            Lines[0].PressButton(!GetIsMuted(player), GorillaPlayerLineButton.ButtonType.Mute);

            foreach (GorillaPlayerScoreboardLine Line in Lines)
            {
                Line.muteButton.isOn = GetIsMuted(player);
                Line.muteButton.UpdateColor();
            }
            $"Muted? {PlayerPrefs.GetInt(player.UserId)}".Log();
        }

        private bool GetIsMuted(Player player)
        {
            return PlayerPrefs.GetInt(player.UserId, 0) != 0;
        }
    }
}
