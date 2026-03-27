namespace SuperProjectQ.AllForm.Room
{
    partial class frmRoomOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomOptions));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuyDatTruoc = new System.Windows.Forms.Button();
            this.btnDatTruoc = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(475, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(167, 22);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(204, 30);
            this.txtSDT.TabIndex = 10;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "SĐT khách hàng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(67, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 69);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khách hàng";
            // 
            // btnHuyDatTruoc
            // 
            this.btnHuyDatTruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.btnHuyDatTruoc.FlatAppearance.BorderSize = 0;
            this.btnHuyDatTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDatTruoc.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDatTruoc.ForeColor = System.Drawing.Color.White;
            this.btnHuyDatTruoc.Image = ((System.Drawing.Image)(resources.GetObject("btnHuyDatTruoc.Image")));
            this.btnHuyDatTruoc.Location = new System.Drawing.Point(36, 131);
            this.btnHuyDatTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyDatTruoc.Name = "btnHuyDatTruoc";
            this.btnHuyDatTruoc.Size = new System.Drawing.Size(220, 60);
            this.btnHuyDatTruoc.TabIndex = 33;
            this.btnHuyDatTruoc.Text = "Huỷ đặt trước";
            this.btnHuyDatTruoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyDatTruoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuyDatTruoc.UseVisualStyleBackColor = false;
            this.btnHuyDatTruoc.Click += new System.EventHandler(this.AllBtn_Click);
            // 
            // btnDatTruoc
            // 
            this.btnDatTruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.btnDatTruoc.FlatAppearance.BorderSize = 0;
            this.btnDatTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatTruoc.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatTruoc.ForeColor = System.Drawing.Color.White;
            this.btnDatTruoc.Image = ((System.Drawing.Image)(resources.GetObject("btnDatTruoc.Image")));
            this.btnDatTruoc.Location = new System.Drawing.Point(36, 131);
            this.btnDatTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDatTruoc.Name = "btnDatTruoc";
            this.btnDatTruoc.Size = new System.Drawing.Size(220, 60);
            this.btnDatTruoc.TabIndex = 32;
            this.btnDatTruoc.Text = "Đặt trước";
            this.btnDatTruoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatTruoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatTruoc.UseVisualStyleBackColor = false;
            this.btnDatTruoc.Click += new System.EventHandler(this.AllBtn_Click);
            // 
            // btnActive
            // 
            this.btnActive.BackColor = System.Drawing.Color.Lime;
            this.btnActive.FlatAppearance.BorderSize = 0;
            this.btnActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActive.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.ForeColor = System.Drawing.Color.White;
            this.btnActive.Image = ((System.Drawing.Image)(resources.GetObject("btnActive.Image")));
            this.btnActive.Location = new System.Drawing.Point(262, 131);
            this.btnActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(220, 60);
            this.btnActive.TabIndex = 34;
            this.btnActive.Text = "Mở phòng";
            this.btnActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActive.UseVisualStyleBackColor = false;
            this.btnActive.Click += new System.EventHandler(this.AllBtn_Click);
            // 
            // frmRoomOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(515, 233);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnHuyDatTruoc);
            this.Controls.Add(this.btnDatTruoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRoomOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmRoomOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHuyDatTruoc;
        private System.Windows.Forms.Button btnDatTruoc;
        private System.Windows.Forms.Button btnActive;
    }
}