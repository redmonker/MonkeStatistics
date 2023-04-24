using MonkeStatistics.API;

namespace SpeedBoost.Pages
{
    [DisplayInMainMenu("Speed Boost")]
    internal class SpeedPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            if (Main.RoomValid)
                Build();
            else
            {
                AddLine("Room not valid", null);
                AddLine("Join a modded", null);
                AddLine("gamemode to use", null);
                SetLines();
            }
            SetTitle("speed Boost");
            SetAuthor("By Crafterbot");
        }

        private void Build()
        {
            TextLines = new Line[0]; // reset
            AddLine("Toggle", new ButtonInfo(ToggleSpeedBoost, 0, ButtonInfo.ButtonType.Toggle, Main.Enabled));
            AddLine(1);
            AddLine($"Speed[{Main.SpeedBoost}]", null);
            AddLine(1);
            AddLine("Speed[+]", new ButtonInfo(SpeedBoostChange, -1, ButtonInfo.ButtonType.Press));
            AddLine("Speed[-]", new ButtonInfo(SpeedBoostChange, 1, ButtonInfo.ButtonType.Press));
            SetLines();
            // Recommended 10 lines
        }

        #region Events
        public void ToggleSpeedBoost(object Sender, object[] Args)
        {
            Main.Enabled = (bool)Args[1];
            Build();
        }
        public void SpeedBoostChange(object Sender, object[] Args)
        {
            Main.SpeedBoost += (float)Args[0];
            Build();
        }
        #endregion
    }
}
