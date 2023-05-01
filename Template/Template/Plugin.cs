/*
  This is a modified version of Graics Mod Template  
*/
using BepInEx;
using UnityEngine;
using Utilla;

namespace Template
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla")]
    [BepInDependency("Crafterbot.MonkeStatistics")]

    [ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        internal static bool Enabled;

        private void Awake()
        {
            Debug.Log("Init : " + PluginInfo.Name);
            // This will add all pages within this project to the MonkeStatistics
            MonkeStatistics.API.Registry.AddAssembly(); // This MUST be called before the player is initialized. 
        }
    }
}
