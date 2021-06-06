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
    public partial class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            double number;
            if (!double.TryParse(Text, out number))
                ForeColor = Color.Red;
            else ForeColor = Color.Black;
            base.OnTextChanged(e);
        }
    }
}
