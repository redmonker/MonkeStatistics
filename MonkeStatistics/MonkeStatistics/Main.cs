using BepInEx;
using HarmonyLib;
using MonkeStatistics.Core;
using MonkeStatistics.Util;
using System.Reflection;
using Utilla;

namespace MonkeStatistics
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency("org.legoandmars.gorillatag.utilla")]

    [ModdedGamemode]
    internal class Main : BaseUnityPlugin
    {
        internal const string
            GUID = "Crafterbot.MonkeStatistics",
            NAME = "MonkeStatistics",
            VERSION = "1.0.3";
        internal static bool RoomValid;
        private void Awake()
        {
            ("Init : " + NAME + " Version:" + VERSION).BepInLog();
            new Harmony(GUID).PatchAll(Assembly.GetExecutingAssembly());
            API.Registry.AddAssembly();

            Utilla.Events.RoomLeft += Events_RoomLeft;
        }

        #region Game Events
        [ModdedGamemodeJoin]

        private void OnJoin()
        {
            RoomValid = true;
        }
        private void Events_RoomLeft(object sender, Events.RoomJoinedArgs e)
        {
            RoomValid = false;
            UIManager.Instance.ForceClose();
        }
        #endregion
    }
}
