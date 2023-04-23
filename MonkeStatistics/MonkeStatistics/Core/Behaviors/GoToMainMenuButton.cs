using System.Collections;
using UnityEngine;

namespace MonkeStatistics.Core.Behaviors
{
    internal class GoToMainMenuButton : GorillaPressableButton
    {
        public override void Start()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            gameObject.layer = 18;
            WardrobeItemButton wardrobeItemButton = GameObject.FindObjectOfType<WardrobeItemButton>();//.Where(x => x.name == TargetWardrobeItemButtonName).FirstOrDefault();

            buttonRenderer = GetComponent<MeshRenderer>();
            pressedMaterial = wardrobeItemButton.pressedMaterial;
            unpressedMaterial = wardrobeItemButton.unpressedMaterial;

            buttonRenderer.material = unpressedMaterial;
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
            base.ButtonActivation();
            StartCoroutine(ButtonDelay());
            UIManager.Instance.ShowPage(typeof(Pages.MainPage));
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
