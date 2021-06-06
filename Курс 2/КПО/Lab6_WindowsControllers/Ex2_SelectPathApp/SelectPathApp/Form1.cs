using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectPathApp
{
    public partial class PathSelectAppp : Form
    {
        public PathSelectAppp()
        {
            InitializeComponent();
            fileSelectPath1.FileName = "Значение задано через свойство";
        }
    }
}
