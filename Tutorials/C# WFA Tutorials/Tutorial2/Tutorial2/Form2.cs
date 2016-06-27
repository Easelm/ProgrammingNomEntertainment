using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial2
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2(Form1 f)
        {
            InitializeComponent();

            form1 = f;
            textBox1.Text = form1.testString;
        }
    }
}
