using GorillaScoreboard.Patches;
using MonkeStatistics.API;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    [DisplayInMainMenu("Scoreboard")]
    internal class MyPage : Page
    {
        public static Player SelectedPlayer;
        public bool IsOpen;
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            if (PhotonNetwork.InRoom)
            {
                for (int i = 0; i < GorillaScoreBoardPatch.Lines.Count; i++)
                {
                    Player player = GorillaScoreBoardPatch.Lines[i].linePlayer;
                    bool IsLocal = player.IsLocal;
                    bool IsMuted = PlayerPrefs.GetInt(player.UserId) == 1;
                    ButtonInfo Info = IsLocal ? null : new ButtonInfo(Info_ButtonPressed, i, ButtonInfo.ButtonType.Toggle, IsMuted);
                    AddLine(player.NickName, Info);
                }
            }
            else
                AddLine("You are not currently in a room!", null);
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
