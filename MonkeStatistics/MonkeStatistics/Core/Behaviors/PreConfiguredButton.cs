using MonkeStatistics.API;
using System.Collections;
using UnityEngine;

namespace MonkeStatistics.Core.Behaviors
{
    internal class PreConfiguredButton : GorillaPressableButton
    {
        private bool _Toggling;
        public override void Start()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            gameObject.layer = 18;
            WardrobeItemButton wardrobeItemButton = GameObject.FindObjectOfType<WardrobeItemButton>();

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
        }

        public IEnumerator ToggleDelay(ButtonInfo Info = null)
        {
            if (!_Toggling)
            {
                _Toggling = true;
                isOn = !isOn;
                UpdateColor();
                if (Info != null)
                    Info.RaiseEvent(isOn);
                yield return new WaitForSeconds(0.15f); // buffer
                _Toggling = false;
            }
        }
        public IEnumerator ButtonDelay()
        {
            if (!isOn)
            {
                isOn = true;
                UpdateColor();
                yield return new WaitForSeconds(0.25f);
                isOn = false;
                UpdateColor();
            }
        }

        #region Disabling button
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
        private void OnDisable()
        {
            StopAllCoroutines();
            GetComponent<MeshRenderer>().material = unpressedMaterial;
        }
        #endregion
    }
}
