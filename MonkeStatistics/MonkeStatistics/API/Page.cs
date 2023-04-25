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
        public int EntriesPerScene = 10;
        public int CurrentScene;
        /// <summary>
        /// The Key is the id of the line, 
        /// the value is whether or not the line 
        /// it will be a toggle.
        /// </summary>
        public Line[] TextLines;
        /// <summary>
        /// This will be called every time the page is refreshed by another script.
        /// </summary>
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
        // Thanks to Dev & Kyle for suggesting overloading the AddLine method.
        public void AddLine(int Amount, string Text = "", ButtonInfo Info = null)
        {
            for (int i = 0; i < Amount; i++)
                AddLine(Text, Info);
        }
        public void AddLine(string Text, ButtonInfo Info = null) =>
            TextLines = TextLines.Append(new Line(Text, Info)).ToArray();
        [Obsolete("This method is obsole, use the Addline method instead.")]
        public void AddLines(int Amount, string Text = "", ButtonInfo buttonInfo = null)
        {
            for (int i = 0; i < Amount; i++)
                AddLine(Text, buttonInfo);
        }

        /// <summary>
        /// Updates all currently displayed lines, to the TextLines text.
        /// </summary>
        public void UpdateLines()
        {
            VerifyScene();
            for (int i = CurrentScene * EntriesPerScene; i < GetLinesToDisplay(); i++)
            {
                Transform Line = UIManager.Instance.ButtonGrouping.GetChild(i - CurrentScene * EntriesPerScene + 1);
                Line.GetComponent<Text>().text = TextLines.ElementAt(i).Text;
            }
        }
        public void SetLines()
        {
            if (TextLines == null)
                return;
            AddLine(1);
            UIManager.Instance.ClearPage();
            Transform BaseButton = UIManager.Instance.BaseLine;
            VerifyScene();
            for (int i = CurrentScene * EntriesPerScene; i < GetLinesToDisplay(); i++)
            {
                GameObject NewLine = GameObject.Instantiate(BaseButton.gameObject, BaseButton.parent);
                NewLine.GetComponent<Text>().text = TextLines.ElementAt(i).Text;
                if (TextLines.ElementAt(i).Info != null)
                {
                    GameObject Btn = NewLine.transform.GetChild(0).gameObject;
                    Btn.gameObject.SetActive(true);
                    Btn.layer = 18;
                    Btn.AddComponent<Button>().Info = TextLines.ElementAt(i).Info;
                }
                else
                    NewLine.transform.GetChild(0).gameObject.SetActive(false);
                NewLine.SetActive(true);
            }
        }
        public int GetLinesToDisplay()
        {
            // index of ending line
            int EndLine = CurrentScene * EntriesPerScene + EntriesPerScene;
            return EndLine > TextLines.Length ? TextLines.Length : EndLine;
        }
        #endregion
        public void VerifyScene()
        {
            if (CurrentScene < 0)
                CurrentScene = 0;

            // If the scene is too low, disable the scroll up button.
            if (CurrentScene <= 0)
                GetButtonUp(false);
            else
                GetButtonUp(true);
            // If the scene is too high, disable the scroll down button.
            if (CurrentScene >= TextLines.Length / EntriesPerScene - 1)
                GetButtonDown(false);
            else
                GetButtonDown(true);

            GameObject GetButtonDown(bool Active)
            {
                UIManager.Instance.ScrollDown.SetActive(Active);
                return UIManager.Instance.ScrollDown;
            }
            GameObject GetButtonUp(bool Active)
            {
                UIManager.Instance.ScrollUp.SetActive(Active);
                return UIManager.Instance.ScrollUp;
            }
        }
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
