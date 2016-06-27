using System;
using System.IO;
using System.Windows.Forms;

namespace Tutorial4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Apache24");
            if (directoryInfo != null)
            {
                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    try
                    {
                        listBox1.Items.Add(fileInfo.FullName);
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
