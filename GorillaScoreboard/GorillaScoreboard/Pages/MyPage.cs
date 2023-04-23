using GorillaScoreboard.Patches;
using MonkeStatistics.API;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    [DisplayInMainMenu("Scoreboard")]
    internal class MyPage : Page
    {
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
                    ButtonInfo Info = IsLocal ? null : new ButtonInfo(Info_ButtonPressed, i, true, IsMuted);
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
        }

        private void Info_ButtonPressed(object Sender, object[] Args)
        {
            // I will finish this part in a minute
            /*string MuteUserId = PhotonNetwork.PlayerList[(int)Args[0]].UserId; // since the list will be redrawn ever time a scoreboard is redrawn, there should be no issues with invalid indexs
            bool IsMuted = PlayerPrefs.GetInt(MuteUserId) != 0;
            PlayerPrefs.SetInt(MuteUserId, IsMuted == false ? 1 : 0);*/
        }
    }
}
