namespace SuperProjectQ.AllForm.Productions
{
    partial class frmAddUnitAndLoaiBan
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
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.Unit = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddUnit = new System.Windows.Forms.Button();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LoaiBan = new System.Windows.Forms.TabPage();
            this.btnAddLoaiBan = new System.Windows.Forms.Button();
            this.txtLoaiBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabCtrlMain.SuspendLayout();
            this.Unit.SuspendLayout();
            this.LoaiBan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.Unit);
            this.tabCtrlMain.Controls.Add(this.LoaiBan);
            this.tabCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlMain.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(482, 253);
            this.tabCtrlMain.TabIndex = 0;
            // 
            // Unit
            // 
            this.Unit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Unit.Controls.Add(this.label2);
            this.Unit.Controls.Add(this.btnAddUnit);
            this.Unit.Controls.Add(this.txtDonViTinh);
            this.Unit.Controls.Add(this.label6);
            this.Unit.Location = new System.Drawing.Point(4, 25);
            this.Unit.Name = "Unit";
            this.Unit.Padding = new System.Windows.Forms.Padding(3);
            this.Unit.Size = new System.Drawing.Size(474, 224);
            this.Unit.TabIndex = 0;
            this.Unit.Text = "Đơn vị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(98, 178);
            this.label2.MaximumSize = new System.Drawing.Size(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 32);
            this.label2.TabIndex = 27;
            this.label2.Text = "*Nếu thêm 2 đơn vị trở lên các đơn vị chỉ được cách nhau bằng dấu \',\' không có kh" +
    "oảng trống.";
            // 
            // btnAddUnit
            // 
            this.btnAddUnit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnAddUnit.FlatAppearance.BorderSize = 0;
            this.btnAddUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUnit.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUnit.ForeColor = System.Drawing.Color.White;
            this.btnAddUnit.Location = new System.Drawing.Point(161, 135);
            this.btnAddUnit.Name = "btnAddUnit";
            this.btnAddUnit.Size = new System.Drawing.Size(160, 40);
            this.btnAddUnit.TabIndex = 26;
            this.btnAddUnit.Text = "Thêm";
            this.btnAddUnit.UseVisualStyleBackColor = false;
            this.btnAddUnit.Click += new System.EventHandler(this.btnAddUnit_Click);
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDonViTinh.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonViTinh.Location = new System.Drawing.Point(75, 90);
            this.txtDonViTinh.Multiline = true;
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(329, 35);
            this.txtDonViTinh.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(145, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 34);
            this.label6.TabIndex = 24;
            this.label6.Text = "Thêm đơn vị";
            // 
            // LoaiBan
            // 
            this.LoaiBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LoaiBan.Controls.Add(this.btnAddLoaiBan);
            this.LoaiBan.Controls.Add(this.txtLoaiBan);
            this.LoaiBan.Controls.Add(this.label1);
            this.LoaiBan.Location = new System.Drawing.Point(4, 25);
            this.LoaiBan.Name = "LoaiBan";
            this.LoaiBan.Padding = new System.Windows.Forms.Padding(3);
            this.LoaiBan.Size = new System.Drawing.Size(470, 220);
            this.LoaiBan.TabIndex = 1;
            this.LoaiBan.Text = "Loại bán";
            // 
            // btnAddLoaiBan
            // 
            this.btnAddLoaiBan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddLoaiBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnAddLoaiBan.FlatAppearance.BorderSize = 0;
            this.btnAddLoaiBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLoaiBan.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLoaiBan.ForeColor = System.Drawing.Color.White;
            this.btnAddLoaiBan.Location = new System.Drawing.Point(159, 131);
            this.btnAddLoaiBan.Name = "btnAddLoaiBan";
            this.btnAddLoaiBan.Size = new System.Drawing.Size(160, 40);
            this.btnAddLoaiBan.TabIndex = 28;
            this.btnAddLoaiBan.Text = "Thêm";
            this.btnAddLoaiBan.UseVisualStyleBackColor = false;
            this.btnAddLoaiBan.Click += new System.EventHandler(this.btnAddLoaiBan_Click);
            // 
            // txtLoaiBan
            // 
            this.txtLoaiBan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoaiBan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaiBan.Location = new System.Drawing.Point(75, 90);
            this.txtLoaiBan.Multiline = true;
            this.txtLoaiBan.Name = "txtLoaiBan";
            this.txtLoaiBan.Size = new System.Drawing.Size(329, 35);
            this.txtLoaiBan.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 34);
            this.label1.TabIndex = 26;
            this.label1.Text = "Thêm loại bán";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabCtrlMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 253);
            this.panel1.TabIndex = 1;
            // 
            // frmAddUnitAndLoaiBan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAddUnitAndLoaiBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUnitAndLoaiBan";
            this.Load += new System.EventHandler(this.frmAddUnitAndLoaiBan_Load);
            this.tabCtrlMain.ResumeLayout(false);
            this.Unit.ResumeLayout(false);
            this.Unit.PerformLayout();
            this.LoaiBan.ResumeLayout(false);
            this.LoaiBan.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage Unit;
        private System.Windows.Forms.TabPage LoaiBan;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLoaiBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUnit;
        private System.Windows.Forms.Button btnAddLoaiBan;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TabControl tabCtrlMain;
    }
}