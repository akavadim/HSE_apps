using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinControllers
{

    public class ColorEventArgs:EventArgs
    {
        public ColorEventArgs(Color color) => Color = color;

        public Color Color { get; set; }
    }

    public delegate void ColorEventHandler(object sender, ColorEventArgs args);

    public partial class ColorBox : UserControl
    {
        public event ColorEventHandler ColorChanged;

        private NumberFormat numberFormat;

        public ColorBox()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color;
        }

        public Color Color
        {
            get => Color.FromArgb(redNumberBox.Value,
                greenNumberBox.Value,
                blueNumberBox.Value);
            set => SetColor(value);
        }

        public NumberFormat NumberFormat { get => numberFormat; set => SetNumberFormat(value); }

        private void SetNumberFormat(NumberFormat format)
        {
            SetNumberBoxesFormat(format);

            switch (format)
            {
                case NumberFormat.Dec:
                    decRadioButton.Checked = true;
                    break;
                case NumberFormat.Hex: 
                    hexRadioButton.Checked = true;
                    break;
            }
        }

        private void SetNumberBoxesFormat(NumberFormat format)
        {
            numberFormat = format;
            redNumberBox.NumberFormat = format;
            greenNumberBox.NumberFormat = format;
            blueNumberBox.NumberFormat = format;
        }

        private void SetColor(Color color)
        {
            this.redNumberBox.Value = color.R;
            this.greenNumberBox.Value = color.G;
            this.blueNumberBox.Value = color.B;
            ColorChanged?.Invoke(this, new ColorEventArgs(color));
        }

        private void decRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetNumberBoxesFormat(NumberFormat.Dec);
        }

        private void hexRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetNumberBoxesFormat(NumberFormat.Hex);
        }

        private void numberBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color;
        }
    }
}
