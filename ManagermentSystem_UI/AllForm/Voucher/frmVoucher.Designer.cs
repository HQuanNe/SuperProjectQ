namespace SuperProjectQ.AllForm.Other
{
    partial class frmVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoucher));
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.MaVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTriGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiamToiDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTDonHangToiThieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plInfo = new System.Windows.Forms.Panel();
            this.btnAddVoucher = new System.Windows.Forms.Button();
            this.btnVoucherKH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.AllowUserToAddRows = false;
            this.dgvVoucher.AllowUserToDeleteRows = false;
            this.dgvVoucher.AllowUserToResizeColumns = false;
            this.dgvVoucher.AllowUserToResizeRows = false;
            this.dgvVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVoucher.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVoucher,
            this.TenVoucher,
            this.GiaTriGiam,
            this.LoaiGiamGia,
            this.GiamToiDa,
            this.GTDonHangToiThieu,
            this.MaPhatHanh,
            this.SoLuongPhatHanh,
            this.MoTa,
            this.HinhAnh,
            this.GhiChu});
            this.dgvVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVoucher.Location = new System.Drawing.Point(2, 103);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.RowHeadersVisible = false;
            this.dgvVoucher.RowHeadersWidth = 51;
            this.dgvVoucher.RowTemplate.Height = 24;
            this.dgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoucher.Size = new System.Drawing.Size(1303, 555);
            this.dgvVoucher.TabIndex = 22;
            this.dgvVoucher.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucher_CellDoubleClick);
            // 
            // MaVoucher
            // 
            this.MaVoucher.DataPropertyName = "MaVoucher";
            this.MaVoucher.HeaderText = "Mã";
            this.MaVoucher.MinimumWidth = 6;
            this.MaVoucher.Name = "MaVoucher";
            // 
            // TenVoucher
            // 
            this.TenVoucher.DataPropertyName = "TenVoucher";
            this.TenVoucher.HeaderText = "Tên";
            this.TenVoucher.MinimumWidth = 6;
            this.TenVoucher.Name = "TenVoucher";
            // 
            // GiaTriGiam
            // 
            this.GiaTriGiam.DataPropertyName = "GiaTriGiam";
            this.GiaTriGiam.HeaderText = "Giá trị giảm";
            this.GiaTriGiam.MinimumWidth = 6;
            this.GiaTriGiam.Name = "GiaTriGiam";
            // 
            // LoaiGiamGia
            // 
            this.LoaiGiamGia.DataPropertyName = "LoaiGiamGia";
            this.LoaiGiamGia.HeaderText = "Loại giảm giá";
            this.LoaiGiamGia.MinimumWidth = 6;
            this.LoaiGiamGia.Name = "LoaiGiamGia";
            // 
            // GiamToiDa
            // 
            this.GiamToiDa.DataPropertyName = "GiamToiDa";
            this.GiamToiDa.HeaderText = "Giảm tối đa";
            this.GiamToiDa.MinimumWidth = 6;
            this.GiamToiDa.Name = "GiamToiDa";
            // 
            // GTDonHangToiThieu
            // 
            this.GTDonHangToiThieu.DataPropertyName = "GTDonHangToiThieu";
            this.GTDonHangToiThieu.HeaderText = "Đơn hàng tối thiểu";
            this.GTDonHangToiThieu.MinimumWidth = 6;
            this.GTDonHangToiThieu.Name = "GTDonHangToiThieu";
            // 
            // MaPhatHanh
            // 
            this.MaPhatHanh.DataPropertyName = "MaPhatHanh";
            this.MaPhatHanh.HeaderText = "Mã phát hành";
            this.MaPhatHanh.MinimumWidth = 6;
            this.MaPhatHanh.Name = "MaPhatHanh";
            // 
            // SoLuongPhatHanh
            // 
            this.SoLuongPhatHanh.DataPropertyName = "SoLuongPhatHanh";
            this.SoLuongPhatHanh.HeaderText = "Số lượng";
            this.SoLuongPhatHanh.MinimumWidth = 6;
            this.SoLuongPhatHanh.Name = "SoLuongPhatHanh";
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            // 
            // HinhAnh
            // 
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.HeaderText = "Tên ảnh";
            this.HinhAnh.MinimumWidth = 6;
            this.HinhAnh.Name = "HinhAnh";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            // 
            // plInfo
            // 
            this.plInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plInfo.Controls.Add(this.btnAddVoucher);
            this.plInfo.Controls.Add(this.btnVoucherKH);
            this.plInfo.Controls.Add(this.label1);
            this.plInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInfo.Location = new System.Drawing.Point(2, 2);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(1303, 101);
            this.plInfo.TabIndex = 18;
            // 
            // btnAddVoucher
            // 
            this.btnAddVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnAddVoucher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddVoucher.FlatAppearance.BorderSize = 2;
            this.btnAddVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVoucher.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVoucher.ForeColor = System.Drawing.Color.White;
            this.btnAddVoucher.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVoucher.Image")));
            this.btnAddVoucher.Location = new System.Drawing.Point(1037, 25);
            this.btnAddVoucher.Name = "btnAddVoucher";
            this.btnAddVoucher.Size = new System.Drawing.Size(220, 50);
            this.btnAddVoucher.TabIndex = 26;
            this.btnAddVoucher.Text = "Thêm Voucher";
            this.btnAddVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddVoucher.UseVisualStyleBackColor = false;
            this.btnAddVoucher.Click += new System.EventHandler(this.btnAddVoucher_Click);
            // 
            // btnVoucherKH
            // 
            this.btnVoucherKH.BackColor = System.Drawing.Color.Goldenrod;
            this.btnVoucherKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherKH.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucherKH.ForeColor = System.Drawing.Color.White;
            this.btnVoucherKH.Image = ((System.Drawing.Image)(resources.GetObject("btnVoucherKH.Image")));
            this.btnVoucherKH.Location = new System.Drawing.Point(10, 20);
            this.btnVoucherKH.Name = "btnVoucherKH";
            this.btnVoucherKH.Size = new System.Drawing.Size(300, 60);
            this.btnVoucherKH.TabIndex = 25;
            this.btnVoucherKH.Text = "Voucher khách hàng";
            this.btnVoucherKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoucherKH.UseVisualStyleBackColor = false;
            this.btnVoucherKH.Click += new System.EventHandler(this.btnVoucherKH_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(515, 14);
            this.label1.MinimumSize = new System.Drawing.Size(140, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 72);
            this.label1.TabIndex = 24;
            this.label1.Text = "Voucher";
            // 
            // frmVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1307, 660);
            this.Controls.Add(this.dgvVoucher);
            this.Controls.Add(this.plInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVoucher";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu giảm giá";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTriGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamToiDa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTDonHangToiThieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhatHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongPhatHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Button btnVoucherKH;
        private System.Windows.Forms.Button btnAddVoucher;
    }
}