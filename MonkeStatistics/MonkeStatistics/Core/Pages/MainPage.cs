/*
    I have some major improvements to make for this script
*/
using MonkeStatistics.API;
using System.Linq;
using UnityEngine;

namespace MonkeStatistics.Core.Pages
{
    public class MainPage : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();

            // search through AllPages in UIManager for API.DisplayInMainMenu
            int SearchIndex = 0;
            foreach (var page in UIManager.AllPages)
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
            Debug.Log("ReturnIndex : " + ReturnIndex);
            UIManager.Instance.ShowPage(UIManager.AllPages[ReturnIndex]);
        }
    }
}
