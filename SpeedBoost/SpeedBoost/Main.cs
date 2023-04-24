using BepInEx;
using HarmonyLib;
using System.Reflection;
using Utilla;

namespace SpeedBoost
{
    [BepInPlugin(GUID, Name, Version)]
    [BepInDependency("Crafterbot.MonkeStatistics")]

    [ModdedGamemode]
    internal class Main : BaseUnityPlugin
    {
        public const string
            GUID = "crafterbot.speedboost",
            Name = "SpeedBoost",
            Version = "1.0.0";
        public static bool RoomValid;
        public static bool Enabled;

        public static float SpeedBoost = 1.0f;

        private void Awake()
        {
            new Harmony(GUID).PatchAll(Assembly.GetExecutingAssembly());
            MonkeStatistics.API.Registry.AddAssembly();
        }

        [ModdedGamemodeJoin]
        private void Join() =>
            RoomValid = true;
        [ModdedGamemodeLeave]
        private void Leave() =>
            RoomValid = false;
    }
}
