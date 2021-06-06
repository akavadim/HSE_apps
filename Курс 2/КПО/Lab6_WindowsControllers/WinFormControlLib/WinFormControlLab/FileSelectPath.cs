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
    public partial class FileSelectPath : UserControl
    {
        public FileSelectPath()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get => pathTextBox.Text;
            set => pathTextBox.Text = value;
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog()
            {
                FileName = pathTextBox.Text
            };

            if (opf.ShowDialog() == DialogResult.OK)
                pathTextBox.Text = opf.FileName;
        }

    }
}
