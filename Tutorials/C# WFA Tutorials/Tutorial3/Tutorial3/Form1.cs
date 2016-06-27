using System;
using System.IO;
using System.Windows.Forms;

namespace Tutorial3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Apache24");
            if (directoryInfo != null)
            {
                foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
                {
                    try
                    {
                        listBox1.Items.Add(dirInfo.FullName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
