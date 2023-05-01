using MonkeStatistics.API;
using System;
using System.Linq;

namespace MonkeStatistics.Core.Pages
{
    public class MainPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            int SearchIndex = 0;
            foreach (Type page in UIManager.AllPages)
            {
                var Attribute = page.GetCustomAttributes(typeof(DisplayInMainMenu), false).FirstOrDefault() as DisplayInMainMenu;
                if (Attribute != null)
                    AddLine(Attribute.DisplayName, new ButtonInfo(Info_ButtonPressed, SearchIndex));
                SearchIndex++;
            }
            Behaviors.GoToMainMenuButton.ReturnPage = typeof(MainPage);

            SetLines();
            SetTitle(Main.NAME);
            SetAuthor("By Crafterbot");
        }
        private void Info_ButtonPressed(object Sender, object[] Args)
        {
            int ReturnIndex = (int)Args[0];

            var Attribute = UIManager.AllPages[ReturnIndex].GetCustomAttributes(typeof(DisplayInMainMenu), false).FirstOrDefault() as DisplayInMainMenu;
            if (Attribute != null)
                if (Attribute.CanWorkInNoneModded)
                    ShowPage(UIManager.AllPages[ReturnIndex]);
                else if (Main.RoomValid)
                    ShowPage(UIManager.AllPages[ReturnIndex]);
                else
                    ShowPage<ModdedRoomPage>();
            else
                ShowPage(UIManager.AllPages[ReturnIndex]);
        }
    }
}
