using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinControllers
{
    public enum NumberFormat { Dec,Hex}

    public partial class NumberFormatTextBox : TextBox
    {
        private int minValue = 0;
        private int maxValue = 255;
        private int value;
        private NumberFormat numberFormat;

        public NumberFormatTextBox()
        {
            InitializeComponent();
        }

        public int MinValue
        {
            get => minValue;
            set => SetMinValue(value);
        }

        public int MaxValue
        {
            get => maxValue;
            set => SetMaxValue(value);
        }

        public int Value
        {
            get => value;
            set => SetValue(value);
        }

        public NumberFormat NumberFormat
        {
            get => numberFormat;
            set => SetNumberFormat(value);
        }

        private void SetMaxValue(int value)
        {
            if (value < minValue)
                throw new Exception("Максимальное значение не может быть меньше минимального");
            maxValue = value;

            SetValue(this.value);
        }

        private void SetMinValue(int value)
        {
            if (value > maxValue)
                throw new Exception("Минимальное значение не может быть больше максимального");
            minValue = value;

            SetValue(this.value);
        }

        private void SetValue(int value)
        {
            if (value > maxValue)
                value = maxValue;
            else if (value < minValue)
                value = minValue;
            this.value = value;

            UpdateText();
        }

        private void SetNumberFormat(NumberFormat format)
        {
            numberFormat = format;
            UpdateText();
        }

        private void UpdateText()
        {
            switch (numberFormat)
            {
                case NumberFormat.Dec:
                    Text = value.ToString();
                    break;
                case NumberFormat.Hex:
                    Text = value.ToString("X");
                    break;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
                return;

            int value = 0;

            switch (numberFormat)
            {
                case NumberFormat.Dec:
                    if (!int.TryParse(Text, out value))
                        value = this.value;
                    break;

                case NumberFormat.Hex:
                    try { value = Convert.ToInt32(Text, 16);}
                    catch { value = this.value; }
                    break;
            }

            SetValue(value);
            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (numberFormat)
            {
                case NumberFormat.Dec:
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                        e.Handled = true;
                    break;
                case NumberFormat.Hex:
                    if (!CharExtensions.IsHex(e.KeyChar) && !char.IsControl(e.KeyChar))
                        e.Handled = true;
                    else e.KeyChar = char.ToUpperInvariant(e.KeyChar);
                    break;
            }
            base.OnKeyPress(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
                UpdateText();

            base.OnLostFocus(e);
        }
    }
}
