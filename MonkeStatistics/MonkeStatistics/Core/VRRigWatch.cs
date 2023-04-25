/*using UnityEngine;

namespace MonkeStatistics.Core
{
    internal class VRRigWatch
    {
        public VRRigWatch(VRRig Rig)
        {
            try
            {
                GameObject WatchObj = UnityEngine.Object.Instantiate((GameObject)Util.AssetLoader.GetAsset("Watch"));
                Transform WatchTransform = WatchObj.transform;

                WatchTransform.SetParent(Rig.transform.Find("rig").Find("body").Find("shoulder.L").Find("upper_arm.L").Find("forearm.L.").Find("hand.L").transform);
                WatchTransform.localPosition = new Vector3(0.0288f, 0.0267f, -0.004f);
                WatchTransform.localRotation = Quaternion.Euler(-26.97f, 94.478f, -93.21101f);

                GameObject Trigger = WatchTransform.Find("Trigger").gameObject;
                Trigger.layer = 18;
            }
            catch (System.Exception ex) 
            { 
                Debug.LogException(ex);
            } 
        }
    }
}
*/