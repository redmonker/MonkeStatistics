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
            if (Info.buttonType == ButtonInfo.ButtonType.Toggle)
            {
                isOn = !isOn;
                UpdateColor();
                Info.RaiseEvent(isOn);
            }
            else
               StartCoroutine(ButtonActivationDelay());
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
        public ButtonType buttonType;
        /// <summary>
        /// When the button is written this will be the initial state of the button.
        /// </summary>
        public bool InitialIsOn;

        public int ReturnIndex;
        public delegate void EventHandler(object Sender, object[] Args);
        /// <summary>
        /// The buttons press event will return a object, formatting:
        /// (int) ReturnIndex, (bool)IsOn, (bool)Toggle
        /// </summary>
        public event EventHandler ButtonPressed;
        public void RaiseEvent(bool IsOn)
        {
            Debug.Log("Event raised " + ReturnIndex);
            object[] Args = new object[] { ReturnIndex, IsOn, buttonType };
            ButtonPressed?.Invoke(this, Args);
        }

        /// <summary>
        /// Line button info
        /// </summary>
        public ButtonInfo(EventHandler ButtonPressed, int ReturnIndex, ButtonType Type = ButtonType.Press, bool InitialIsOn = false)
        {
            this.ButtonPressed = ButtonPressed;
            this.ReturnIndex = ReturnIndex;
            this.buttonType = Type;
            this.InitialIsOn = InitialIsOn;
        }

        public enum ButtonType
        {
            Toggle,
            Press
        }
    }
}
