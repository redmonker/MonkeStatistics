using MonkeStatistics.Core.Behaviors;
using UnityEngine;

namespace MonkeStatistics.API
{
    internal class Button : PreConfiguredButton
    {
        public float InitializationTime;
        public ButtonInfo Info;

        private void Awake() =>
            InitializationTime = Time.time;

        public override void Start()
        {
            base.Start();
            if (Info.buttonType == ButtonInfo.ButtonType.Toggle)
                isOn = Info.InitialIsOn;
            UpdateColor();
        }

        public override void ButtonActivation()
        {
            if (GetOnInitDelay())
                return;

            if (Info.buttonType == ButtonInfo.ButtonType.Toggle)
                StartCoroutine(ToggleDelay(Info));
            else
            {
                StartCoroutine(ButtonDelay());
                Info.RaiseEvent(true);
            }
        }

        public bool GetOnInitDelay()
        {
            return InitializationTime + Info.InitialDelay > Time.time;
        }
    }

    public class ButtonInfo
    {
        public ButtonType buttonType;
        /// <summary>
        /// When the button is written this will be the initial state of the button.
        /// </summary>
        public bool InitialIsOn;

        /// <summary>
        /// This field will determin how long before the button can be pressed after its drawn.
        /// </summary>
        public float InitialDelay;

        public int ReturnIndex;
        public delegate void EventHandler(object Sender, object[] Args);
        /// <summary>
        /// The buttons press event will return a object, formatting:
        /// (int) ReturnIndex, (bool)IsOn, (bool)Toggle
        /// </summary>
        public event EventHandler ButtonPressed;
        public void RaiseEvent(bool IsOn)
        {
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
            InitialDelay = 0.1f;
        }

        public enum ButtonType
        {
            Toggle,
            Press
        }
    }
}
