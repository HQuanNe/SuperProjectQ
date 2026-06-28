namespace SuperProjectQ.AllForm.Voucher
{
    partial class frmDSVoucherKH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSVoucherKH));
            this.dgvDSVoucherKH = new System.Windows.Forms.DataGridView();
            this.plInfo = new System.Windows.Forms.Panel();
            this.btnVoucherKH = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHetHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVoucherKH)).BeginInit();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSVoucherKH
            // 
            this.dgvDSVoucherKH.AllowUserToAddRows = false;
            this.dgvDSVoucherKH.AllowUserToDeleteRows = false;
            this.dgvDSVoucherKH.AllowUserToResizeColumns = false;
            this.dgvDSVoucherKH.AllowUserToResizeRows = false;
            this.dgvDSVoucherKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSVoucherKH.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.dgvDSVoucherKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSVoucherKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.TenKH,
            this.TenVoucher,
            this.NgayNhan,
            this.NgayHetHan,
            this.NgaySuDung,
            this.TrangThai,
            this.GhiChu});
            this.dgvDSVoucherKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSVoucherKH.Location = new System.Drawing.Point(2, 80);
            this.dgvDSVoucherKH.Name = "dgvDSVoucherKH";
            this.dgvDSVoucherKH.RowHeadersVisible = false;
            this.dgvDSVoucherKH.RowHeadersWidth = 51;
            this.dgvDSVoucherKH.RowTemplate.Height = 24;
            this.dgvDSVoucherKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSVoucherKH.Size = new System.Drawing.Size(1228, 521);
            this.dgvDSVoucherKH.TabIndex = 24;
            // 
            // plInfo
            // 
            this.plInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plInfo.Controls.Add(this.btnVoucherKH);
            this.plInfo.Controls.Add(this.btnClose);
            this.plInfo.Controls.Add(this.label1);
            this.plInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInfo.Location = new System.Drawing.Point(2, 2);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(1228, 78);
            this.plInfo.TabIndex = 23;
            // 
            // btnVoucherKH
            // 
            this.btnVoucherKH.BackColor = System.Drawing.Color.Goldenrod;
            this.btnVoucherKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherKH.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucherKH.ForeColor = System.Drawing.Color.White;
            this.btnVoucherKH.Image = ((System.Drawing.Image)(resources.GetObject("btnVoucherKH.Image")));
            this.btnVoucherKH.Location = new System.Drawing.Point(12, 14);
            this.btnVoucherKH.Name = "btnVoucherKH";
            this.btnVoucherKH.Size = new System.Drawing.Size(220, 50);
            this.btnVoucherKH.TabIndex = 26;
            this.btnVoucherKH.Text = "Phát Voucher";
            this.btnVoucherKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoucherKH.UseVisualStyleBackColor = false;
            this.btnVoucherKH.Click += new System.EventHandler(this.btnVoucherKH_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1188, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 3);
            this.label1.MinimumSize = new System.Drawing.Size(140, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(643, 72);
            this.label1.TabIndex = 24;
            this.label1.Text = "Voucher khách hàng";
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 34.97781F;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.FillWeight = 150.7377F;
            this.TenKH.HeaderText = "Tên khách hàng";
            this.TenKH.MinimumWidth = 6;
            this.TenKH.Name = "TenKH";
            // 
            // TenVoucher
            // 
            this.TenVoucher.DataPropertyName = "TenVoucher";
            this.TenVoucher.FillWeight = 150.7377F;
            this.TenVoucher.HeaderText = "Tên Voucher";
            this.TenVoucher.MinimumWidth = 6;
            this.TenVoucher.Name = "TenVoucher";
            // 
            // NgayNhan
            // 
            this.NgayNhan.DataPropertyName = "NgayNhan";
            this.NgayNhan.FillWeight = 81.92477F;
            this.NgayNhan.HeaderText = "Ngày nhận";
            this.NgayNhan.MinimumWidth = 6;
            this.NgayNhan.Name = "NgayNhan";
            // 
            // NgayHetHan
            // 
            this.NgayHetHan.DataPropertyName = "NgayHetHan";
            this.NgayHetHan.FillWeight = 75.92364F;
            this.NgayHetHan.HeaderText = "Ngày hết hạn";
            this.NgayHetHan.MinimumWidth = 6;
            this.NgayHetHan.Name = "NgayHetHan";
            // 
            // NgaySuDung
            // 
            this.NgaySuDung.DataPropertyName = "NgaySuDung";
            this.NgaySuDung.FillWeight = 69.39915F;
            this.NgaySuDung.HeaderText = "Ngày sử dụng";
            this.NgaySuDung.MinimumWidth = 6;
            this.NgaySuDung.Name = "NgaySuDung";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 85.5615F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.FillWeight = 150.7377F;
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            // 
            // frmDSVoucherKH
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1232, 603);
            this.Controls.Add(this.dgvDSVoucherKH);
            this.Controls.Add(this.plInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDSVoucherKH";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách Voucher Khách hàng";
            this.Load += new System.EventHandler(this.frmDSVoucherKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVoucherKH)).EndInit();
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSVoucherKH;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVoucherKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHetHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}