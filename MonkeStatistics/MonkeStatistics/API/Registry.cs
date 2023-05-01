using MonkeStatistics.Util;
using System.Reflection;

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
            assemblies = assemblies.Add(Assembly.GetCallingAssembly());
            Assembly.GetCallingAssembly().FullName.BepInLog();
        }
    }
}
