using System.Collections;
using UnityEngine;

namespace MonkeStatistics.Core.Behaviors
{
    internal class WatchButton : GorillaPressableButton
    {
        public override void Start()
        {
            //string TargetWardrobeItemButtonName = "WardrobeItemButton";
            //WardrobeItemButton wardrobeItemButton = GameObject.FindObjectOfType<WardrobeItemButton>();//.Where(x => x.name == TargetWardrobeItemButtonName).FirstOrDefault();

            //buttonRenderer = GetComponent<MeshRenderer>();
            //pressedMaterial = wardrobeItemButton.pressedMaterial;
            //unpressedMaterial = wardrobeItemButton.unpressedMaterial;

            //buttonRenderer.material = unpressedMaterial;
            gameObject.layer = 18;
        }
        public override void ButtonActivation()
        {
            base.ButtonActivation();
            //StartCoroutine(ButtonDelay());
            UIManager.Instance.WatchButtonPressed();
        }
        private void Update()
        {
            float Distance = Vector3.Distance(transform.forward, Vector3.up);
            bool OpenMenu = Distance <= 0.65 ;
            if (!OpenMenu && UIManager.Instance.MenuObj.activeSelf)
                UIManager.Instance.MenuObj.SetActive(false);
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
