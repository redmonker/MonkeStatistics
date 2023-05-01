using System;

namespace MonkeStatistics.API
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DisplayInMainMenu : Attribute
    {
        public string DisplayName;
        /// <summary>
        /// If true, this button will work in all lobbies. 
        /// If false, it will only work in modded lobbies.
        /// </summary>
        public bool CanWorkInNoneModded;
        public DisplayInMainMenu(string DisplayName, bool CanWorkInNoneModded = false)
        {
            this.DisplayName = DisplayName;
            this.CanWorkInNoneModded = CanWorkInNoneModded;
        }
    }
}
