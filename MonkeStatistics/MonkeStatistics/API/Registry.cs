using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace MonkeStatistics.API
{
    public class Registry
    {
        internal static Assembly[] assemblies = new Assembly[0];
        /// <summary>
        /// This method is used to add an assembly to the list of assemblies that will be searched for pages.
        /// This must be executed before the player is initialized.
        /// </summary>
        public static void AddAssembly()
        {
            Debug.Log("Added assembly : " + Assembly.GetCallingAssembly().FullName);
            Assembly[] newAssemblies = new Assembly[assemblies.Length + 1];
            for (int i = 0; i < assemblies.Length; i++)
                newAssemblies[i] = assemblies[i];
            newAssemblies[newAssemblies.Length - 1] = Assembly.GetCallingAssembly();
            assemblies = newAssemblies;
        }
    }
}
