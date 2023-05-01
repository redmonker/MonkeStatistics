using UnityEngine;

namespace GorillaScoreboard.Util
{
    internal static class Extensions
    {
        public static void Log(this string message, LogType logType = LogType.Info)
        {
            string NewMessage = "[GorillaScoreboard] : " + message;
            if (logType == LogType.Info)
                Debug.Log(NewMessage);
            else if (logType == LogType.Warning)
                Debug.LogWarning(NewMessage);
            else if (logType == LogType.Error)
                Debug.LogError(NewMessage);
        }
    }

    internal enum LogType
    {
        Info,
        Warning,
        Error
    }
}
