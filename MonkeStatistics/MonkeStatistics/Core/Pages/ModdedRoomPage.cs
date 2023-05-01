using MonkeStatistics.API;

namespace MonkeStatistics.Core.Pages
{
    internal class ModdedRoomPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            AddText("This page only works in MODDED ROOMS. Please only use it in modded rooms.");
            AddLine(2);
            AddText("Press the back button to return to the main menu.");
            SetTitle("Modded Gamemode");
            SetAuthor("Invalid room ERROR");

            SetBackButtonOverride(typeof(Pages.MainPage));
            SetLines();
        }
    }
}
