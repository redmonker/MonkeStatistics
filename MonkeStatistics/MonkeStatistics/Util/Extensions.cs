using UnityEngine;

namespace MonkeStatistics.Util
{
    public static class Extensions
    {
        // add item to array
        public static T[] Add<T>(this T[] array, T item)
        {
            T[] newArray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            newArray[newArray.Length - 1] = item;
            return newArray;
        }

        public static void BepInLog(this string Message, LogType type = LogType.Info)
        {
#if DEBUG
            string NewMessage = $"[{Main.NAME}]: {Message}";
            if (type == LogType.Info)
                Debug.Log(NewMessage);
            else if (type == LogType.Error)
                Debug.LogError(NewMessage);
            else if (type == LogType.Warning)
                Debug.LogWarning(NewMessage);
#endif
        }
    }
}

public enum LogType
{
    Info,
    Error,
    Warning,
    Critical
}