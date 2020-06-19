using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace BoopRentalShop
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "정말 종료하시겠습니까?", "종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 메인관리ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void 구분코드관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DivForm form = new DivForm();
            form.Text = "구분코드 관리";
            form.Dock = DockStyle.Fill;
            form.MdiParent = this; // 여기까지 초기화
            form.Show(); // 실행
            form.WindowState = FormWindowState.Maximized;// 얘가 마지막으로 와야함
        }
    }
}