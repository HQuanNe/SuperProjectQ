namespace SuperProjectQ.AllForm.Users
{
    partial class frmChangePasswd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePasswd));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVisiblePasswd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmNewPasswd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPasswd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOldPasswd = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolRegularPasswd = new System.Windows.Forms.ToolTip(this.components);
            this.timerSendBack = new System.Windows.Forms.Timer(this.components);
            this.timerCookieOTP = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.btnSendBack);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtOTP);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblVisiblePasswd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtConfirmNewPasswd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNewPasswd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtOldPasswd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 367);
            this.panel1.TabIndex = 14;
            // 
            // btnSendBack
            // 
            this.btnSendBack.BackColor = System.Drawing.Color.White;
            this.btnSendBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendBack.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendBack.Location = new System.Drawing.Point(343, 303);
            this.btnSendBack.Name = "btnSendBack";
            this.btnSendBack.Size = new System.Drawing.Size(107, 31);
            this.btnSendBack.TabIndex = 31;
            this.btnSendBack.Text = "Nhận OTP";
            this.btnSendBack.UseVisualStyleBackColor = false;
            this.btnSendBack.Click += new System.EventHandler(this.btnSendBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "Nhập mã OTP:";
            // 
            // txtOTP
            // 
            this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOTP.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP.Location = new System.Drawing.Point(170, 301);
            this.txtOTP.Multiline = true;
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(167, 35);
            this.txtOTP.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(205, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "quy định về mật khẩu";
            this.toolRegularPasswd.SetToolTip(this.label3, "Mật khẩu chỉ được chứa các ký tự (a-z), (A-Z), (0-9)");
            // 
            // lblVisiblePasswd
            // 
            this.lblVisiblePasswd.AutoSize = true;
            this.lblVisiblePasswd.BackColor = System.Drawing.Color.White;
            this.lblVisiblePasswd.Image = ((System.Drawing.Image)(resources.GetObject("lblVisiblePasswd.Image")));
            this.lblVisiblePasswd.Location = new System.Drawing.Point(307, 141);
            this.lblVisiblePasswd.MinimumSize = new System.Drawing.Size(30, 30);
            this.lblVisiblePasswd.Name = "lblVisiblePasswd";
            this.lblVisiblePasswd.Size = new System.Drawing.Size(30, 30);
            this.lblVisiblePasswd.TabIndex = 27;
            this.lblVisiblePasswd.Text = "  ";
            this.lblVisiblePasswd.Click += new System.EventHandler(this.lblVisiblePasswd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 26);
            this.label2.TabIndex = 26;
            this.label2.Text = "Xác nhận mật khẩu mới:";
            // 
            // txtConfirmNewPasswd
            // 
            this.txtConfirmNewPasswd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmNewPasswd.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmNewPasswd.Location = new System.Drawing.Point(17, 235);
            this.txtConfirmNewPasswd.Multiline = true;
            this.txtConfirmNewPasswd.Name = "txtConfirmNewPasswd";
            this.txtConfirmNewPasswd.PasswordChar = '*';
            this.txtConfirmNewPasswd.Size = new System.Drawing.Size(320, 35);
            this.txtConfirmNewPasswd.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mật khẩu mới:";
            // 
            // txtNewPasswd
            // 
            this.txtNewPasswd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPasswd.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPasswd.Location = new System.Drawing.Point(17, 139);
            this.txtNewPasswd.Multiline = true;
            this.txtNewPasswd.Name = "txtNewPasswd";
            this.txtNewPasswd.PasswordChar = '*';
            this.txtNewPasswd.Size = new System.Drawing.Size(320, 35);
            this.txtNewPasswd.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mật khẩu cũ:";
            // 
            // txtOldPasswd
            // 
            this.txtOldPasswd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOldPasswd.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPasswd.Location = new System.Drawing.Point(17, 43);
            this.txtOldPasswd.Multiline = true;
            this.txtOldPasswd.Name = "txtOldPasswd";
            this.txtOldPasswd.PasswordChar = '*';
            this.txtOldPasswd.Size = new System.Drawing.Size(320, 35);
            this.txtOldPasswd.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 429);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(528, 79);
            this.panel3.TabIndex = 16;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(166, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(200, 60);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 60);
            this.panel2.TabIndex = 15;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(116, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 53);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Đổi mật khẩu";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(488, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolRegularPasswd
            // 
            this.toolRegularPasswd.AutoPopDelay = 5000;
            this.toolRegularPasswd.InitialDelay = 100;
            this.toolRegularPasswd.IsBalloon = true;
            this.toolRegularPasswd.ReshowDelay = 100;
            // 
            // timerSendBack
            // 
            this.timerSendBack.Interval = 1000;
            this.timerSendBack.Tick += new System.EventHandler(this.timerSendBack_Tick);
            // 
            // timerCookieOTP
            // 
            this.timerCookieOTP.Interval = 1000;
            this.timerCookieOTP.Tick += new System.EventHandler(this.timerCookieOTP_Tick);
            // 
            // frmChangePasswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(532, 510);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChangePasswd";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmChangePasswd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOldPasswd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPasswd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmNewPasswd;
        private System.Windows.Forms.Label lblVisiblePasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolRegularPasswd;
        private System.Windows.Forms.Button btnSendBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Timer timerSendBack;
        private System.Windows.Forms.Timer timerCookieOTP;
    }
}