using System;
using System.Diagnostics;
using Iot.Device.Button;

namespace DTM.Buttons
{
    public delegate void ButtonEventHandler(object sender, EventArgs e);

    public class ButtonController
    {
        private readonly GpioButton _button;

        public event ButtonEventHandler ButtonPressed;
        public event ButtonEventHandler ButtonDoublePressed;
        public event ButtonEventHandler ButtonHeld;

        public ButtonController(int pin)
        {
            _button = new GpioButton(buttonPin: pin);
            _button.IsDoublePressEnabled = true;
            _button.IsHoldingEnabled = true;

            _button.Press += OnPress;
            _button.DoublePress += OnDoublePress;
            _button.Holding += OnHolding;
        }

        private void OnPress(object sender, EventArgs e)
        {
            ButtonPressed?.Invoke(this, e);
        }

        private void OnDoublePress(object sender, EventArgs e)
        {
            ButtonDoublePressed?.Invoke(this, e);
        }

        private void OnHolding(object sender, EventArgs e)
        {
            ButtonHeld?.Invoke(this, e);
        }
    }
}
