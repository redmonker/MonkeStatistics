using BepInEx;
using HarmonyLib;
using MonkeStatistics.API;
using System.Reflection;

namespace GorillaScoreboard
{
    [BepInPlugin(GUID, Name, Version)]
    [BepInDependency("Crafterbot.MonkeStatistics")]
    internal class Main : BaseUnityPlugin
    {
        public const string
            GUID = "com.crafterbot.gorillascoreboard",
            Name = "Gorilla Scoreboard",
            Version = "1.0.0";
        public void Awake()
        {
            new Harmony(GUID).PatchAll(Assembly.GetExecutingAssembly()); // add harmony patches
            Registry.AddAssembly(); // register this assembly to the API
        }
    }
}
