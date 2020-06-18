using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.DeepPink);
            Rectangle rect = new Rectangle(50, 50, 150, 100);

            g.FillRectangle(Brushes.BlueViolet, rect);
            g.DrawRectangle(pen, rect);
        }
    }
}
