using GorillaScoreboard.Patches;
using MonkeStatistics.API;
using Photon.Pun;
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
            for (int i = 0; i < GorillaScoreBoardPatch.Lines.Count; i++)
            {
                ButtonInfo Info = new ButtonInfo();
                Info.ReturnIndex = i;
                Info.ButtonPressed += Info_ButtonPressed;
                Info.Toggle = true;
                Info.InitialIsOn = PlayerPrefs.HasKey(GorillaScoreBoardPatch.Lines[i].linePlayer.UserId);
                TextLines.Add(GorillaScoreBoardPatch.Lines[i].playerName.text, Info);
            }
            SetTitle("Gorilla Scoreboard");
            SetAuthor("");
            SetLines();
        }

        private void Info_ButtonPressed(object Sender, object[] Args)
        {
            base.OnPageOpen();
            string MuteUserId = PhotonNetwork.PlayerList[(int)Args[0]].UserId;
            bool IsMuted = false;
            if (PlayerPrefs.HasKey(MuteUserId))
                IsMuted = true;
            PlayerPrefs.SetInt(MuteUserId, IsMuted == false ? 1 : 0);
        }
    }
}
