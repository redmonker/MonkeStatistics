/*
    I have some major improvements to make for this script.
    I will add overfill handlers later. But I do not think
    enough people will use this to justify the time it would
*/
using MonkeStatistics.API;
using System;
using System.Linq;

namespace MonkeStatistics.Core.Pages
{
    public class MainPage : Page
    {
        //private const int EntriesPerPage = 6;
        //public static int PageIndex = 0;
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            /*if (PageIndex < 0)
                PageIndex = 0;
            else
            if (PageIndex > UIManager.AllPages.Length / EntriesPerPage)
                PageIndex = UIManager.AllPages.Length / EntriesPerPage;*/

            // search through AllPages in UIManager for API.DisplayInMainMenu
            int SearchIndex = 0;
            foreach (Type page in UIManager.AllPages)
            {
                var Attribute = page.GetCustomAttributes(typeof(DisplayInMainMenu), false).FirstOrDefault() as DisplayInMainMenu;
                if (Attribute != null)
                    AddLine(Attribute.DisplayName, new ButtonInfo(Info_ButtonPressed, SearchIndex, ButtonInfo.ButtonType.Press, false));
                SearchIndex++;
            }
            Behaviors.GoToMainMenuButton.ReturnPage = typeof(MainPage);

            SetLines();
            SetTitle(Main.Name);
            SetAuthor("By " + Main.Author);
        }
        private void Info_ButtonPressed(object Sender, object[] Args)
        {
            int ReturnIndex = (int)Args[0];
            UIManager.Instance.ShowPage(UIManager.AllPages[ReturnIndex]);
        }
    }
}
