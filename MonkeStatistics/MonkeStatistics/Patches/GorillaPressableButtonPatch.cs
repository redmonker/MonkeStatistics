using HarmonyLib;
using MonkeStatistics.Core.Behaviors;

namespace MonkeStatistics.Patches
{
    [HarmonyPatch(typeof(GorillaPressableButton), "OnTriggerEnter", MethodType.Normal)]
    internal class GorillaPressableButtonPatch
    {
        [HarmonyPrefix]
        private static void Hook(GorillaPressableButton __instance)
        {
            // get if watchbutton
            bool IsWatch = WatchButton.Instance.gameObject == __instance.gameObject;
            if (IsWatch && !WatchButton.Instance.GetFacingUp())
                throw new System.Exception("Button not facing up!");
        }
    }
}
