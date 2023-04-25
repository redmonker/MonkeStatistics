using System.Collections;
using UnityEngine;

namespace MonkeStatistics.Core.Behaviors
{
    internal class WatchButton : GorillaPressableButton
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }
        public override void ButtonActivation()
        {
            base.ButtonActivation(); // not sure if anything is running on this, and to lazy to check O-o
            UIManager.Instance.WatchButtonPressed();
        }
        private void Update()
        {
            float Distance = Vector3.Distance(transform.forward, Vector3.up);
            bool OpenMenu = Distance <= 0.65 ;
            if (!OpenMenu && UIManager.Instance.MenuObj.activeSelf)
            {
                UIManager.Instance.ShowPage(typeof(Pages.MainPage));
                UIManager.Instance.MenuObj.SetActive(false);
            }
        }

        private IEnumerator ButtonDelay()
        {
            isOn = true;
            UpdateColor();
            yield return new WaitForSeconds(0.35f);
            isOn = false;
            UpdateColor();
        }
    }
}
