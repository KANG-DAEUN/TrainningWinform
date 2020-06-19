namespace BoopRentalShop
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메인관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.구분코드관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메인관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(890, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메인관리ToolStripMenuItem
            // 
            this.메인관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.구분코드관리ToolStripMenuItem});
            this.메인관리ToolStripMenuItem.Name = "메인관리ToolStripMenuItem";
            this.메인관리ToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.메인관리ToolStripMenuItem.Text = "메인관리(M)";
            this.메인관리ToolStripMenuItem.Click += new System.EventHandler(this.메인관리ToolStripMenuItem_Click);
            // 
            // 구분코드관리ToolStripMenuItem
            // 
            this.구분코드관리ToolStripMenuItem.Name = "구분코드관리ToolStripMenuItem";
            this.구분코드관리ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.구분코드관리ToolStripMenuItem.Text = "구분코드 관리";
            this.구분코드관리ToolStripMenuItem.Click += new System.EventHandler(this.구분코드관리ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 631);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Book Rental Shop ver 1.0";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메인관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 구분코드관리ToolStripMenuItem;
    }
}

