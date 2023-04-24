using System.Collections;
using MonkeStatistics.Core.Pages;
using UnityEngine;

namespace MonkeStatistics.Core.Behaviors
{
    internal class CustomMainButton : GorillaPressableButton
    {
        private float _Time;
        public bool IsLeft;
        public override void Start()
        {
            WardrobeItemButton wardrobeItemButton = FindObjectOfType<WardrobeItemButton>();

            buttonRenderer = GetComponent<MeshRenderer>();
            pressedMaterial = wardrobeItemButton.pressedMaterial;
            unpressedMaterial = wardrobeItemButton.unpressedMaterial;

            UpdateColor();
        }

        public override void ButtonActivation()
        {
            if (_Time + 0.5 > Time.realtimeSinceStartup)
                return;
            _Time = Time.realtimeSinceStartup;
            StartCoroutine(ButtonActivationDelay());
        }

        private IEnumerator ButtonActivationDelay()
        {
            isOn = true;
            UpdateColor();

            //MainPage.PageIndex += IsLeft ? -1 : 1;
            //UIManager.Instance.ShowPage(typeof(UIManager));

            yield return new WaitForSeconds(0.20f);
            isOn = false;
            UpdateColor();
        }
    }
}

//PageIndex