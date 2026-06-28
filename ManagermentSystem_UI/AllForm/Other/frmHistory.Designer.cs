namespace SuperProjectQ.AllForm.Other
{
    partial class frmHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCtrlHistory = new System.Windows.Forms.TabControl();
            this.tabPageLoginHistory = new System.Windows.Forms.TabPage();
            this.tabPagePaymentHistory = new System.Windows.Forms.TabPage();
            this.rtxtLoginHistory = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.rtxtPaymentHistory = new System.Windows.Forms.RichTextBox();
            this.tabCtrlHistory.SuspendLayout();
            this.tabPageLoginHistory.SuspendLayout();
            this.tabPagePaymentHistory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlHistory
            // 
            this.tabCtrlHistory.Controls.Add(this.tabPageLoginHistory);
            this.tabCtrlHistory.Controls.Add(this.tabPagePaymentHistory);
            this.tabCtrlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlHistory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlHistory.Location = new System.Drawing.Point(4, 72);
            this.tabCtrlHistory.Name = "tabCtrlHistory";
            this.tabCtrlHistory.SelectedIndex = 0;
            this.tabCtrlHistory.Size = new System.Drawing.Size(674, 577);
            this.tabCtrlHistory.TabIndex = 0;
            // 
            // tabPageLoginHistory
            // 
            this.tabPageLoginHistory.Controls.Add(this.rtxtLoginHistory);
            this.tabPageLoginHistory.Location = new System.Drawing.Point(4, 30);
            this.tabPageLoginHistory.Name = "tabPageLoginHistory";
            this.tabPageLoginHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageLoginHistory.Size = new System.Drawing.Size(674, 551);
            this.tabPageLoginHistory.TabIndex = 0;
            this.tabPageLoginHistory.Text = "Lịch sử đăng nhập";
            this.tabPageLoginHistory.UseVisualStyleBackColor = true;
            // 
            // tabPagePaymentHistory
            // 
            this.tabPagePaymentHistory.Controls.Add(this.rtxtPaymentHistory);
            this.tabPagePaymentHistory.Location = new System.Drawing.Point(4, 30);
            this.tabPagePaymentHistory.Name = "tabPagePaymentHistory";
            this.tabPagePaymentHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabPagePaymentHistory.Size = new System.Drawing.Size(666, 543);
            this.tabPagePaymentHistory.TabIndex = 1;
            this.tabPagePaymentHistory.Text = "Lịch sử thanh toán";
            this.tabPagePaymentHistory.UseVisualStyleBackColor = true;
            // 
            // rtxtLoginHistory
            // 
            this.rtxtLoginHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLoginHistory.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLoginHistory.Location = new System.Drawing.Point(10, 10);
            this.rtxtLoginHistory.Name = "rtxtLoginHistory";
            this.rtxtLoginHistory.ReadOnly = true;
            this.rtxtLoginHistory.Size = new System.Drawing.Size(654, 531);
            this.rtxtLoginHistory.TabIndex = 0;
            this.rtxtLoginHistory.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 68);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lịch sử";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(634, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rtxtPaymentHistory
            // 
            this.rtxtPaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtPaymentHistory.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPaymentHistory.Location = new System.Drawing.Point(10, 10);
            this.rtxtPaymentHistory.Name = "rtxtPaymentHistory";
            this.rtxtPaymentHistory.ReadOnly = true;
            this.rtxtPaymentHistory.Size = new System.Drawing.Size(646, 523);
            this.rtxtPaymentHistory.TabIndex = 1;
            this.rtxtPaymentHistory.Text = "";
            // 
            // frmHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(682, 653);
            this.Controls.Add(this.tabCtrlHistory);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHistory";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.tabCtrlHistory.ResumeLayout(false);
            this.tabPageLoginHistory.ResumeLayout(false);
            this.tabPagePaymentHistory.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlHistory;
        private System.Windows.Forms.TabPage tabPageLoginHistory;
        private System.Windows.Forms.TabPage tabPagePaymentHistory;
        private System.Windows.Forms.RichTextBox rtxtLoginHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox rtxtPaymentHistory;
    }
}