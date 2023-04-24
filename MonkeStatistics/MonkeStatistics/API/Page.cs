/*
    This script is highly inspired by the ComputerInterface mod.
*/
using MonkeStatistics.Core;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MonkeStatistics.API
{
    public class Page
    {
        /// <summary>
        /// The Key is the id of the line, 
        /// the value is whether or not the line 
        /// it will be a toggle.
        /// </summary>
        public Line[] TextLines;
        public virtual void OnPageOpen()
        {
            TextLines = new Line[0];
        }
        /// <summary>
        /// If you change this value you MUST reset it to the Core.Pages.MainMenu
        /// </summary>
        /// <param name="type">Page to return to.</param>
        public void SetBackButtonOverride(Type type)
        {
            Core.Behaviors.GoToMainMenuButton.ReturnPage = type;
        }
        /// <summary>
        /// A shortcut to the UIManager's ShowPage method.
        /// </summary>
        /// <param name="type">The pages class, that you wish to open.</param>
        public void ShowPage(Type type) =>
            UIManager.Instance.ShowPage(type);
        /// <summary>
        /// Opens the main page.
        /// </summary>
        public void GoToMainPage() =>
            UIManager.Instance.ShowPage(typeof(Core.Pages.MainPage));


        #region Text
        public void SetTitle(string text) =>
            UIManager.Instance.MenuObj.transform.GetChild(0).Find("Title").GetComponent<Text>().text = text;
        public void SetAuthor(string text) =>
            UIManager.Instance.MenuObj.transform.GetChild(0).Find("Author").GetComponent<Text>().text = text;
        public void AddLine(string Text, ButtonInfo Info) =>
            TextLines = TextLines.Append(new Line(Text, Info)).ToArray();
        public void AddLines(int Amount, string Text = "", ButtonInfo buttonInfo = null)
        {
            for (int i = 0; i < Amount; i++)
                AddLine(Text, buttonInfo);
        }

        public void SetLines()
        {
            if (TextLines == null)
                return;
            UIManager.Instance.ClearPage();
            Transform BaseButton = UIManager.Instance.BaseLine;
            for (int i = 0; i < TextLines.Length; i++)
            {
                GameObject NewLine = GameObject.Instantiate(BaseButton.gameObject, BaseButton.parent);
                NewLine.GetComponent<Text>().text = TextLines.ElementAt(i).Text;
                if (TextLines.ElementAt(i).Info != null)
                {
                    GameObject Btn = NewLine.transform.GetChild(0).gameObject;
                    Btn.gameObject.SetActive(true);
                    Btn.layer = 18;
                    Button BtnObj = Btn.AddComponent<Button>();
                    BtnObj.Info = TextLines.ElementAt(i).Info;
                }
                else
                    NewLine.transform.GetChild(0).gameObject.SetActive(false);
                NewLine.SetActive(true);
            }
            Debug.Log("SetLines");
        }
        #endregion
    }

    public class Line
    {
        public string Text;
        public ButtonInfo Info;
        public Line(string text, ButtonInfo info)
        {
            Text = text;
            Info = info;
        }
    }
}
