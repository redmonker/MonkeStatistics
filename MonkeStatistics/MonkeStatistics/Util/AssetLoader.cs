using System.IO;
using System.Reflection;
using UnityEngine;

namespace MonkeStatistics.Util
{
    internal class AssetLoader
    {
        public static Object GetAsset(string Name)
        {
            return assetBundle.LoadAsset(Name);
        }

        // Load asset bundle

        private static AssetBundle assetBundle;
        public AssetLoader() =>
            assetBundle = GetAssetBundle();

        private AssetBundle GetAssetBundle()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MonkeStatistics.Resources.watch");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            return AssetBundle.LoadFromMemory(buffer);
        }
    }
}
