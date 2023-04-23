using System.Collections;
using UnityEngine;

namespace MonkeStatistics.API
{
    internal class Button : GorillaPressableButton
    {
        public ButtonInfo Info;
        public override void Start()
        {
            WardrobeItemButton wardrobeItemButton = UnityEngine.Object.FindObjectOfType<WardrobeItemButton>();

            buttonRenderer = GetComponent<MeshRenderer>();
            pressedMaterial = wardrobeItemButton.pressedMaterial;
            unpressedMaterial = wardrobeItemButton.unpressedMaterial;

            isOn = Info.InitialIsOn;
            UpdateColor();
        }

        public override void ButtonActivation()
        {
            base.ButtonActivation();
            if (Info.Toggle)
            {
                isOn = !isOn;
                UpdateColor();
                Info.RaiseEvent(isOn);
            }
            else
                ButtonActivationDelay();
        }

        private IEnumerator ButtonActivationDelay()
        {
            isOn = true;
            UpdateColor();

            // execute button activation
            Info.RaiseEvent(true);

            yield return new WaitForSeconds(0.20f);
            isOn = false;
            UpdateColor();
        }
    }

    public class ButtonInfo
    {
        public bool Toggle;
        /// <summary>
        /// When the button is written this will be the initial state of the button.
        /// </summary>
        public bool InitialIsOn;

        public int ReturnIndex;
        public delegate void EventHandler(object Sender, object[] Args);
        public event EventHandler ButtonPressed;
        public void RaiseEvent(bool IsOn)
        {
            object[] Args = new object[] { ReturnIndex, IsOn, Toggle };
            ButtonPressed?.Invoke(this, Args);
        }
    }
}
