namespace SuperProjectQ.FrmMixed
{
    partial class frmHoaDon
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioVao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioRa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoPhut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrietKhauVIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrietKhauVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToResizeColumns = false;
            this.dgvHoaDon.AllowUserToResizeRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaPhong,
            this.MaKH,
            this.MaNV,
            this.GioVao,
            this.GioRa,
            this.TongSoPhut,
            this.TienPhong,
            this.TienDichVu,
            this.TongTien,
            this.TrietKhauVIP,
            this.TrietKhauVoucher,
            this.VAT,
            this.TongThanhToan,
            this.PTTT,
            this.TrangThai,
            this.GhiChu});
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 59);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(1558, 678);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellDoubleClick);
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.FillWeight = 73.14858F;
            this.MaHD.HeaderText = "Mã hoá đơn";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.FillWeight = 102.2937F;
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.FillWeight = 102.2937F;
            this.MaKH.HeaderText = "Mã khách hàng";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.FillWeight = 102.2937F;
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            // 
            // GioVao
            // 
            this.GioVao.DataPropertyName = "GioVao";
            this.GioVao.FillWeight = 102.2937F;
            this.GioVao.HeaderText = "Giờ vào";
            this.GioVao.MinimumWidth = 6;
            this.GioVao.Name = "GioVao";
            // 
            // GioRa
            // 
            this.GioRa.DataPropertyName = "GioRa";
            this.GioRa.FillWeight = 102.2937F;
            this.GioRa.HeaderText = "Giờ ra";
            this.GioRa.MinimumWidth = 6;
            this.GioRa.Name = "GioRa";
            // 
            // TongSoPhut
            // 
            this.TongSoPhut.DataPropertyName = "TongSoPhut";
            this.TongSoPhut.FillWeight = 102.2937F;
            this.TongSoPhut.HeaderText = "Tổng số phút";
            this.TongSoPhut.MinimumWidth = 6;
            this.TongSoPhut.Name = "TongSoPhut";
            // 
            // TienPhong
            // 
            this.TienPhong.DataPropertyName = "TienPhong";
            this.TienPhong.FillWeight = 102.2937F;
            this.TienPhong.HeaderText = "Tiền phòng";
            this.TienPhong.MinimumWidth = 6;
            this.TienPhong.Name = "TienPhong";
            // 
            // TienDichVu
            // 
            this.TienDichVu.DataPropertyName = "TienDichVu";
            this.TienDichVu.FillWeight = 102.2937F;
            this.TienDichVu.HeaderText = "Tiền dịch vụ";
            this.TienDichVu.MinimumWidth = 6;
            this.TienDichVu.Name = "TienDichVu";
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.FillWeight = 102.2937F;
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.MinimumWidth = 6;
            this.TongTien.Name = "TongTien";
            // 
            // TrietKhauVIP
            // 
            this.TrietKhauVIP.DataPropertyName = "TrietKhauVIP";
            this.TrietKhauVIP.FillWeight = 102.2937F;
            this.TrietKhauVIP.HeaderText = "Triết khấu VIP";
            this.TrietKhauVIP.MinimumWidth = 6;
            this.TrietKhauVIP.Name = "TrietKhauVIP";
            // 
            // TrietKhauVoucher
            // 
            this.TrietKhauVoucher.DataPropertyName = "TrietKhauVoucher";
            this.TrietKhauVoucher.FillWeight = 102.2937F;
            this.TrietKhauVoucher.HeaderText = "Triết khấu voucher";
            this.TrietKhauVoucher.MinimumWidth = 6;
            this.TrietKhauVoucher.Name = "TrietKhauVoucher";
            // 
            // VAT
            // 
            this.VAT.DataPropertyName = "VAT";
            this.VAT.FillWeight = 102.2937F;
            this.VAT.HeaderText = "VAT";
            this.VAT.MinimumWidth = 6;
            this.VAT.Name = "VAT";
            // 
            // TongThanhToan
            // 
            this.TongThanhToan.DataPropertyName = "TongThanhToan";
            this.TongThanhToan.FillWeight = 102.2937F;
            this.TongThanhToan.HeaderText = "Tổng thanh toán";
            this.TongThanhToan.MinimumWidth = 6;
            this.TongThanhToan.Name = "TongThanhToan";
            // 
            // PTTT
            // 
            this.PTTT.DataPropertyName = "PTTT";
            this.PTTT.FillWeight = 140.1937F;
            this.PTTT.HeaderText = "PTTT";
            this.PTTT.MinimumWidth = 6;
            this.PTTT.Name = "PTTT";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 54.54546F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.FillWeight = 102.2937F;
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(688, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoá Đơn";
            // 
            // frmHoaDon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioVao;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioRa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoPhut;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrietKhauVIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrietKhauVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}