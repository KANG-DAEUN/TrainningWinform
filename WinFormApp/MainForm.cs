using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            // MessageBox.Show($"Hell world!{now}");
            TxtCurrentDate.Text = now.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
