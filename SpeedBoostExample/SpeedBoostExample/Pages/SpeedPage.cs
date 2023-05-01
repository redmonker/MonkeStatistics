using MonkeStatistics.API;

namespace SpeedBoost.Pages
{
    [DisplayInMainMenu("Speed Boost")]
    internal class SpeedPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            Build();
            SetTitle("Speed Boost");
            SetAuthor("By Crafterbot");
        }

        private void Build(bool setLines = true)
        {
            TextLines = new Line[0]; // reset
            AddLine("Toggle", new ButtonInfo(ToggleSpeedBoost, 0, ButtonInfo.ButtonType.Toggle, Main.Enabled));
            AddLine(1);
            AddLine($"Speed[{Main.SpeedBoost}]");
            AddLine(1);
            AddLine("Speed[+]", new ButtonInfo(SpeedBoostChange, 2));
            AddLine("Speed[-]", new ButtonInfo(SpeedBoostChange, -2));

            AddLine(7);

            AddLine("Crazy", new ButtonInfo(Crazy, 0));
            AddLine(1);
            AddLine("Reset", new ButtonInfo(Reset, 0, ButtonInfo.ButtonType.Press));

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

        // Crazy

        public void Crazy(object Sender, object[] Args)
        {
            Main.SpeedBoost = 105;
            Build(false);
            UpdateLines();
        }

        // Reset

        public void Reset(object Sender, object[] Args)
        {
            Main.SpeedBoost = 1;
            Build(false);
            UpdateLines();
        }
        #endregion
    }
}
