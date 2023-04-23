/*
    This script is highly inspired by the ComputerInterface mod.
*/
using MonkeStatistics.Core;
using System;
using System.Collections.Generic;
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
        public Dictionary<string, ButtonInfo> TextLines = new Dictionary<string,  ButtonInfo>();
        public virtual void OnPageOpen()
        {

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

        public void SetLines()
        {
            if (TextLines == null)
                return;
            UIManager.Instance.ClearPage();
            Transform BaseButton = UIManager.Instance.BaseLine;
            for (int i = 0; i < TextLines.Count; i++)
            {
                GameObject NewLine = GameObject.Instantiate(BaseButton.gameObject, BaseButton.parent);
                NewLine.GetComponent<Text>().text = TextLines.ElementAt(i).Key;
                if (TextLines.ElementAt(i).Value != null)
                {
                    GameObject Btn = NewLine.transform.GetChild(0).gameObject;
                    Btn.gameObject.SetActive(true);
                    Btn.layer = 18;
                    Button BtnObj = Btn.AddComponent<Button>();
                    BtnObj.Info = TextLines.ElementAt(i).Value;
                }
                else
                    NewLine.transform.GetChild(0).gameObject.SetActive(false);
                NewLine.SetActive(true);
            }
            Debug.Log("SetLines");
        }
        #endregion
    }
}
