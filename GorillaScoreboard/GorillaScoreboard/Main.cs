using BepInEx;
using GorillaScoreboard.Util;
using HarmonyLib;
using System.Reflection;

namespace GorillaScoreboard
{
    [BepInPlugin(GUID, NAME, VERSION)]

    internal class Main : BaseUnityPlugin
    {
        internal const string
            GUID = "crafterbot.gorillascoreboard",
            NAME = "GorillaScoreboard",
            VERSION = "1.0.0";
        private void Awake()
        {
            $"Init : {NAME}".Log();

            new Harmony(GUID).PatchAll(Assembly.GetExecutingAssembly());
            MonkeStatistics.API.Registry.AddAssembly();
        }
    }
}
