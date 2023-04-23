using MonkeStatistics.API;
using System.Collections.Generic;
using UnityEngine;

namespace GorillaScoreboard.Pages
{
    internal class PlayerInfoPage : Page
    {
        public override void OnPageOpen()
        {
            var player = MyPage.SelectedPlayer;
            bool IsMuted = PlayerPrefs.GetInt(player.UserId, 0) != 0;

            TextLines = new Dictionary<string, ButtonInfo>()
            {
                //{ "Player Name : " + player.NickName, null},
                { "", null }, // place holder
                { "", null }, // place holder
                { "", null }, // place holder

                { "Mute Player", new ButtonInfo(MutePlayer_ButtonPressed, 0, ButtonInfo.ButtonType.Toggle, IsMuted) }
            };
            SetTitle(player.NickName);
            SetAuthor("");
            SetLines();
            SetBackButtonOverride(typeof(MyPage));
        }

        private void MutePlayer_ButtonPressed(object Sender, object[] Args)
        {
            var player = MyPage.SelectedPlayer;
            bool IsMuted = PlayerPrefs.GetInt(player.UserId, 0) != 0;

            if (IsMuted)
                PlayerPrefs.SetInt(player.UserId, 0);
            else
                PlayerPrefs.SetInt(player.UserId, 1);
        }
    }
}
