/*
    This script was inspired by the ComputerInterface mod.
*/
using MonkeStatistics.API;
using MonkeStatistics.Core.Behaviors;
using MonkeStatistics.Core.Pages;
using System;
using System.Linq;
using UnityEngine;

namespace MonkeStatistics.Core
{
    internal class UIManager
    {
        public static UIManager Instance;

        private GameObject WatchObj;
        public GameObject MenuObj;

        public Transform BaseLine;
        public Transform ButtonGrouping;

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

            MenuTransform.GetChild(0).Find("Left").gameObject.AddComponent<CustomMainButton>().IsLeft = true;
            MenuTransform.GetChild(0).Find("Right").gameObject.AddComponent<CustomMainButton>();

            MenuObj.transform.GetChild(0).Find("ReturnMain").gameObject.AddComponent<Behaviors.GoToMainMenuButton>();

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
                Debug.Log("Page opened : " + type.Name);
            }
            else
                Debug.LogError("Page not found : " + type.FullName);
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
            foreach (Type type in AllPages)
                Debug.Log("Registered page : " + type.Name);
        }
        #endregion
    }
}