/*
    The name of this class is slightly missleading, 
    it will not look at the player on the y axis, it will 
    look at the player on the x and z axis, and will keep 
    the y axis the same as the object it is attached to. - Github Copilot
*/
using GorillaLocomotion;
using UnityEngine;

namespace MonkeStatistics.Core.Behaviors
{
    internal class LookAt : MonoBehaviour
    {
        public Transform Target;
        private void Update()
        {
            Vector3 TargetPosition = new Vector3(Player.Instance.headCollider.transform.position.x, transform.position.y, Player.Instance.headCollider.transform.position.z);
            transform.LookAt(TargetPosition);
            transform.position = Target.position + Vector3.up * 0.2f;
        }
    }
}
