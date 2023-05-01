/*
    This script was inspired by the ComputerInterface mod.
*/
using MonkeStatistics.API;
using MonkeStatistics.Core.Pages;
using MonkeStatistics.Util;
using System;
using System.Linq;
using UnityEngine;

namespace MonkeStatistics.Core
{
    /// <summary>
    /// Please do not touch this class unless you know what you are doing.
    /// </summary>
    public class UIManager
    {
        public static UIManager Instance;
        public static Page CurrentPage;

        private GameObject WatchObj;
        public GameObject MenuObj;

        public Transform BaseLine;
        public Transform ButtonGrouping;

        public GameObject ScrollUp;
        public GameObject ScrollDown;

        public UIManager(GameObject Watch)
        {
            Instance = this;
            WatchObj = Watch;
            #region Load Menu
            MenuObj = GameObject.Instantiate(Util.AssetLoader.GetAsset("MenuObj") as GameObject);
            Transform MenuTransform = MenuObj.transform;
            MenuTransform.SetParent(GorillaLocomotion.Player.Instance.leftHandFollower);
            MenuTransform.localPosition = Vector3.zero;

            ButtonGrouping = MenuTransform.GetChild(0).Find("Lines");

            MenuObj.AddComponent<Behaviors.LookAt>().Target = WatchObj.transform;
            #endregion

            BaseLine = ButtonGrouping.GetChild(0);
            BaseLine.gameObject.SetActive(false);

            #region Additional buttons
            Transform Panel = MenuTransform.GetChild(0);
            ScrollUp = Panel.Find("Up").gameObject;
            ScrollDown = Panel.Find("Down").gameObject;

            ScrollUp.AddComponent<Behaviors.ScrollButton>().IsUp = true;
            ScrollDown.AddComponent<Behaviors.ScrollButton>();
            Panel.Find("ReturnMain").gameObject.AddComponent<Behaviors.GoToMainMenuButton>();
            #endregion

            RegisterPages();
            ShowPage(typeof(MainPage));
            MenuObj.SetActive(false);
        }
        public void WatchButtonPressed() =>
            MenuObj.SetActive(!MenuObj.activeSelf);

        #region Page Management
        public static Type[] AllPages;
        public void ShowPage(Type type)
        {
            ClearPage();
            if (AllPages.Contains(type))
            {
                Page page = (Page)Activator.CreateInstance(type);
                page.OnPageOpen();
                CurrentPage = page;
                ("Page opened : " + type.Name).BepInLog();
            }
            else
                ("Page not found : " + type.FullName).BepInLog(LogType.Error);
        }
        public void ClearPage()
        {
            if (ButtonGrouping.childCount == 1)
                return;
            for (int i = 1; i < ButtonGrouping.childCount; i++)
                GameObject.Destroy(ButtonGrouping.GetChild(i).gameObject);
        }
        private void RegisterPages()
        {
            AllPages = API.Registry.assemblies.SelectMany(x => x.GetTypes()).Where(x => x.IsSubclassOf(typeof(Page))).ToArray();
            "Registered All Pages".BepInLog();
        }

        internal void ForceClose()
        {
            ClearPage();
            ShowPage(typeof(Pages.MainPage));
            "Force Closed".BepInLog(LogType.Warning);
        }
        #endregion
    }
}