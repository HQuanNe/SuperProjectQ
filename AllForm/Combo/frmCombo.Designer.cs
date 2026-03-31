namespace SuperProjectQ.AllForm.Combo
{
    partial class frmCombo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCombo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvListRoom = new System.Windows.Forms.DataGridView();
            this.MaCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThemCombo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnThemCombo);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 80);
            this.panel1.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(405, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 53);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Danh sách combo";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1142, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvListRoom
            // 
            this.dgvListRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListRoom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.dgvListRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCombo,
            this.TenCombo,
            this.TenDanhMuc,
            this.DonGia,
            this.HinhAnh,
            this.GhiChu});
            this.dgvListRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListRoom.Location = new System.Drawing.Point(0, 80);
            this.dgvListRoom.Name = "dgvListRoom";
            this.dgvListRoom.RowHeadersWidth = 51;
            this.dgvListRoom.RowTemplate.Height = 24;
            this.dgvListRoom.Size = new System.Drawing.Size(1182, 573);
            this.dgvListRoom.TabIndex = 13;
            // 
            // MaCombo
            // 
            this.MaCombo.DataPropertyName = "MaCombo";
            this.MaCombo.FillWeight = 85.47237F;
            this.MaCombo.HeaderText = "Mã combo";
            this.MaCombo.MinimumWidth = 6;
            this.MaCombo.Name = "MaCombo";
            // 
            // TenCombo
            // 
            this.TenCombo.DataPropertyName = "TenCombo";
            this.TenCombo.FillWeight = 187.1658F;
            this.TenCombo.HeaderText = "Tên combo";
            this.TenCombo.MinimumWidth = 6;
            this.TenCombo.Name = "TenCombo";
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.TenDanhMuc.FillWeight = 85.47237F;
            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.MinimumWidth = 6;
            this.TenDanhMuc.Name = "TenDanhMuc";
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.FillWeight = 85.47237F;
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            // 
            // HinhAnh
            // 
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.FillWeight = 85.47237F;
            this.HinhAnh.HeaderText = "Hình ảnh";
            this.HinhAnh.MinimumWidth = 6;
            this.HinhAnh.Name = "HinhAnh";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.FillWeight = 85.47237F;
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            // 
            // btnThemCombo
            // 
            this.btnThemCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnThemCombo.FlatAppearance.BorderSize = 0;
            this.btnThemCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCombo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCombo.ForeColor = System.Drawing.Color.White;
            this.btnThemCombo.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCombo.Image")));
            this.btnThemCombo.Location = new System.Drawing.Point(855, 18);
            this.btnThemCombo.Name = "btnThemCombo";
            this.btnThemCombo.Size = new System.Drawing.Size(200, 45);
            this.btnThemCombo.TabIndex = 13;
            this.btnThemCombo.Text = "Thêm combo";
            this.btnThemCombo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemCombo.UseVisualStyleBackColor = false;
            // 
            // frmCombo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.dgvListRoom);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCombo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCombo";
            this.Load += new System.EventHandler(this.frmCombo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThemCombo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvListRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}