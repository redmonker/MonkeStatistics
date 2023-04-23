using MonkeStatistics.API;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MonkeStatistics.Core.Pages
{
    internal class MainPage : Page
    {
        public override void OnPageOpen()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type[] types = assemblies.SelectMany(x => x.GetTypes()).Where(x => x.GetCustomAttributes(typeof(DisplayInMainMenu), false).Length > 0).ToArray();

            for (int i = 0; i < types.Length; i++)
            {
                Debug.Log("Added to MainPage : " + types[i].Name);
                ButtonInfo info = new ButtonInfo();
                info.ReturnIndex = i;
                info.ButtonPressed += Info_ButtonPressed;
                string DisplayName = types[i].GetCustomAttributes(typeof(DisplayInMainMenu), false).Cast<DisplayInMainMenu>().First().DisplayName;
                TextLines.Add(DisplayName, info);
            }

            SetLines();
            SetTitle(Main.Name);
            SetAuthor("By " + Main.Author);
        }
        private void Info_ButtonPressed(object Sender, object[] Args)
        {
            int ReturnIndex = (int)Args[0];
            Type[] types = UIManager.AllPages.SelectMany(x => x.GetCustomAttributes(typeof(MainPage), false).ToArray()).Select(x => x.GetType()).ToArray();
            UIManager.Instance.ShowPage(types[ReturnIndex]);
        }
    }
}
