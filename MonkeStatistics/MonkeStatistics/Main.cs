using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace MonkeStatistics
{
    [BepInPlugin(GUID, Name, Version)]
    internal class Main : BaseUnityPlugin
    {
        public const string
            Name = "MonkeStatistics",
            Author = "Crafterbot",
            Version = "1.0.0",
            GUID = Author + "." + Name;

        private void Awake()
        {
            Logger.LogInfo("Init : " + Name);
            new Util.AssetLoader();
            new Harmony(GUID).PatchAll(Assembly.GetExecutingAssembly()); 
            API.Registry.AddAssembly();
        }
    }
}
