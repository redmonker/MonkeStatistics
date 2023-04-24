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

        private void Build(bool setLines = true)
        {
            TextLines = new Line[0]; // reset
            AddLine("Toggle", new ButtonInfo(ToggleSpeedBoost, 0, ButtonInfo.ButtonType.Toggle, Main.Enabled));
            AddLine(1);
            AddLine($"Speed[{Main.SpeedBoost}]");
            AddLine(1);
            AddLine("Speed[+]", new ButtonInfo(SpeedBoostChange, 1, ButtonInfo.ButtonType.Press));
            AddLine("Speed[-]", new ButtonInfo(SpeedBoostChange, -1, ButtonInfo.ButtonType.Press));
            AddLine(10);
            AddLine("By");
            AddLine("Crafterbot");
            if (setLines)
                SetLines();
        }

        #region Events
        public void ToggleSpeedBoost(object Sender, object[] Args)
        {
            Main.Enabled = (bool)Args[1];
        }
        public void SpeedBoostChange(object Sender, object[] Args)
        {
            Main.SpeedBoost += (int)Args[0];
            Build(false);
            UpdateLines();
        }
        #endregion
    }
}
