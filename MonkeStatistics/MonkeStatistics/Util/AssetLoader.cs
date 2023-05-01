using System.IO;
using System.Reflection;
using UnityEngine;

namespace MonkeStatistics.Util
{
    internal class AssetLoader
    {
        internal static Object GetAsset(string Name)
        {
            if (assetBundle == null)
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MonkeStatistics.Resources.watch");
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                assetBundle = AssetBundle.LoadFromMemory(buffer);
            }

            return assetBundle.LoadAsset(Name);
        }
        private static AssetBundle assetBundle;
    }
}
