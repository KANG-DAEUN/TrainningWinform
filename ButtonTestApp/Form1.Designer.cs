namespace ButtonTestApp
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
            this.BtnFlat = new System.Windows.Forms.Button();
            this.BtnPopup = new System.Windows.Forms.Button();
            this.BtnStandard = new System.Windows.Forms.Button();
            this.BtnSystem = new System.Windows.Forms.Button();
            this.LblButtonStyle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnFlat
            // 
            this.BtnFlat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnFlat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFlat.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnFlat.Location = new System.Drawing.Point(147, 76);
            this.BtnFlat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnFlat.Name = "BtnFlat";
            this.BtnFlat.Size = new System.Drawing.Size(183, 141);
            this.BtnFlat.TabIndex = 0;
            this.BtnFlat.Text = "Flat";
            this.BtnFlat.UseVisualStyleBackColor = false;
            this.BtnFlat.Click += new System.EventHandler(this.BtnFlat_Click);
            // 
            // BtnPopup
            // 
            this.BtnPopup.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnPopup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPopup.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnPopup.Location = new System.Drawing.Point(360, 76);
            this.BtnPopup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnPopup.Name = "BtnPopup";
            this.BtnPopup.Size = new System.Drawing.Size(183, 141);
            this.BtnPopup.TabIndex = 1;
            this.BtnPopup.Text = "Popup";
            this.BtnPopup.UseVisualStyleBackColor = false;
            this.BtnPopup.Click += new System.EventHandler(this.BtnPopup_Click);
            // 
            // BtnStandard
            // 
            this.BtnStandard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnStandard.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnStandard.Location = new System.Drawing.Point(147, 258);
            this.BtnStandard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnStandard.Name = "BtnStandard";
            this.BtnStandard.Size = new System.Drawing.Size(183, 141);
            this.BtnStandard.TabIndex = 2;
            this.BtnStandard.Text = "Standard";
            this.BtnStandard.UseVisualStyleBackColor = false;
            this.BtnStandard.Click += new System.EventHandler(this.BtnStandard_Click);
            // 
            // BtnSystem
            // 
            this.BtnSystem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnSystem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnSystem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnSystem.Location = new System.Drawing.Point(360, 258);
            this.BtnSystem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSystem.Name = "BtnSystem";
            this.BtnSystem.Size = new System.Drawing.Size(183, 141);
            this.BtnSystem.TabIndex = 3;
            this.BtnSystem.Text = "System";
            this.BtnSystem.UseVisualStyleBackColor = false;
            this.BtnSystem.Click += new System.EventHandler(this.BtnSystem_Click);
            // 
            // LblButtonStyle
            // 
            this.LblButtonStyle.AutoSize = true;
            this.LblButtonStyle.Location = new System.Drawing.Point(26, 19);
            this.LblButtonStyle.Name = "LblButtonStyle";
            this.LblButtonStyle.Size = new System.Drawing.Size(50, 20);
            this.LblButtonStyle.TabIndex = 4;
            this.LblButtonStyle.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 474);
            this.Controls.Add(this.LblButtonStyle);
            this.Controls.Add(this.BtnSystem);
            this.Controls.Add(this.BtnStandard);
            this.Controls.Add(this.BtnPopup);
            this.Controls.Add(this.BtnFlat);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFlat;
        private System.Windows.Forms.Button BtnPopup;
        private System.Windows.Forms.Button BtnStandard;
        private System.Windows.Forms.Button BtnSystem;
        private System.Windows.Forms.Label LblButtonStyle;
    }
}

