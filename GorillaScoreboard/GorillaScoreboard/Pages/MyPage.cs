using GorillaScoreboard.Patches;
using MonkeStatistics.API;
using Oculus.Platform;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    [DisplayInMainMenu("Scoreboard")]
    internal class MyPage : Page
    {
        public static Player SelectedPlayer;
        public override void OnPageOpen()
        {
            TextLines = new Dictionary<string, ButtonInfo>();
            if (PhotonNetwork.InRoom)
            {
                for (int i = 0; i < GorillaScoreBoardPatch.Lines.Count; i++)
                {
                    Player player = GorillaScoreBoardPatch.Lines[i].linePlayer;
                    bool IsLocal = player.IsLocal;
                    bool IsMuted = PlayerPrefs.GetInt(player.UserId, 0) != 0;
                    ButtonInfo Info = IsLocal ? null : new ButtonInfo(Info_ButtonPressed, i, ButtonInfo.ButtonType.Toggle, IsMuted);
                    TextLines.Add(GorillaScoreBoardPatch.Lines[i].playerName.text, Info);
                }
            }
            else
            {
                TextLines.Add("\n\nYou are not \ncurrently in a room!", null);
            }
            SetTitle("Gorilla Scoreboard");
            SetAuthor("");
            SetLines();
            SetBackButtonOverride(typeof(MonkeStatistics.Core.Pages.MainPage));
        }

        private void Info_ButtonPressed(object Sender, object[] Args)
        {
            SelectedPlayer = GorillaScoreBoardPatch.Lines[(int)Args[0]].linePlayer;
            ShowPage(typeof(PlayerInfoPage));
        }
    }
}
