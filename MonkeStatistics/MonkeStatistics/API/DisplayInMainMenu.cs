using System;

namespace MonkeStatistics.API
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DisplayInMainMenu : Attribute
    {
        public string DisplayName;
        public DisplayInMainMenu(string DisplayName)
        {
            this.DisplayName = DisplayName;
        }
    }
}
