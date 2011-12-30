using System;
using System.Windows.Forms;

namespace MasterWinformTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBoxTest.Text = "123456789";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
        }
    }
}
