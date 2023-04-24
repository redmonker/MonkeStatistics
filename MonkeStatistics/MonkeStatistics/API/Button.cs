using MonkeStatistics.Core.Behaviors;
using System.Collections;
using UnityEngine;

namespace MonkeStatistics.API
{
    internal class Button : PreConfiguredButton
    {
        public ButtonInfo Info;
        public override void Start()
        {
            base.Start(); 
            isOn = Info.InitialIsOn;
            UpdateColor();
        }

        public override void ButtonActivation()
        {
            if (Info.buttonType == ButtonInfo.ButtonType.Toggle)
            {
                StartCoroutine(ToggleDelay(Info));
            }
            else
            {
                StartCoroutine(ButtonDelay());
                Info.RaiseEvent(true);
            }
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
            buttonType = Type;
            this.InitialIsOn = InitialIsOn;
        }

        public enum ButtonType
        {
            Toggle,
            Press
        }
    }
}
