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
            this.GiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCTHD = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToResizeColumns = false;
            this.dgvHoaDon.AllowUserToResizeRows = false;
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
            this.GiamGia,
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
            this.dgvHoaDon.Size = new System.Drawing.Size(1174, 352);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã hoá đơn";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.Width = 40;
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.Width = 60;
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã khách hàng";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            this.MaKH.Width = 60;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 60;
            // 
            // GioVao
            // 
            this.GioVao.DataPropertyName = "GioVao";
            this.GioVao.HeaderText = "Giờ vào";
            this.GioVao.MinimumWidth = 6;
            this.GioVao.Name = "GioVao";
            this.GioVao.Width = 125;
            // 
            // GioRa
            // 
            this.GioRa.DataPropertyName = "GioRa";
            this.GioRa.HeaderText = "Giờ ra";
            this.GioRa.MinimumWidth = 6;
            this.GioRa.Name = "GioRa";
            this.GioRa.Width = 125;
            // 
            // TongSoPhut
            // 
            this.TongSoPhut.DataPropertyName = "TongSoPhut";
            this.TongSoPhut.HeaderText = "Tổng số phút";
            this.TongSoPhut.MinimumWidth = 6;
            this.TongSoPhut.Name = "TongSoPhut";
            this.TongSoPhut.Width = 60;
            // 
            // TienPhong
            // 
            this.TienPhong.DataPropertyName = "TienPhong";
            this.TienPhong.HeaderText = "Tiền phòng";
            this.TienPhong.MinimumWidth = 6;
            this.TienPhong.Name = "TienPhong";
            this.TienPhong.Width = 90;
            // 
            // TienDichVu
            // 
            this.TienDichVu.DataPropertyName = "TienDichVu";
            this.TienDichVu.HeaderText = "Tiền dịch vụ";
            this.TienDichVu.MinimumWidth = 6;
            this.TienDichVu.Name = "TienDichVu";
            this.TienDichVu.Width = 90;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.MinimumWidth = 6;
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 90;
            // 
            // GiamGia
            // 
            this.GiamGia.DataPropertyName = "GiamGia";
            this.GiamGia.HeaderText = "Triết khấu";
            this.GiamGia.MinimumWidth = 6;
            this.GiamGia.Name = "GiamGia";
            this.GiamGia.Width = 90;
            // 
            // VAT
            // 
            this.VAT.DataPropertyName = "VAT";
            this.VAT.HeaderText = "VAT";
            this.VAT.MinimumWidth = 6;
            this.VAT.Name = "VAT";
            this.VAT.Width = 90;
            // 
            // TongThanhToan
            // 
            this.TongThanhToan.DataPropertyName = "TongThanhToan";
            this.TongThanhToan.HeaderText = "Tổng thanh toán";
            this.TongThanhToan.MinimumWidth = 6;
            this.TongThanhToan.Name = "TongThanhToan";
            this.TongThanhToan.Width = 90;
            // 
            // PTTT
            // 
            this.PTTT.DataPropertyName = "PTTT";
            this.PTTT.HeaderText = "PTTT";
            this.PTTT.MinimumWidth = 6;
            this.PTTT.Name = "PTTT";
            this.PTTT.Width = 80;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrangThai.Width = 90;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(496, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoá Đơn";
            // 
            // dgvCTHD
            // 
            this.dgvCTHD.AllowUserToAddRows = false;
            this.dgvCTHD.AllowUserToResizeRows = false;
            this.dgvCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgvCTHD.Location = new System.Drawing.Point(12, 417);
            this.dgvCTHD.Name = "dgvCTHD";
            this.dgvCTHD.RowHeadersVisible = false;
            this.dgvCTHD.RowHeadersWidth = 51;
            this.dgvCTHD.RowTemplate.Height = 24;
            this.dgvCTHD.Size = new System.Drawing.Size(1174, 424);
            this.dgvCTHD.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaCTHD";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã CTHD";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaHD";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã HD";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MaSP";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mã SP";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TenHienThi";
            this.dataGridViewTextBoxColumn4.HeaderText = "TênSP";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DonViTinh";
            this.dataGridViewTextBoxColumn6.HeaderText = "Đơn vị tính";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn7.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ThanhTien";
            this.dataGridViewTextBoxColumn8.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // frmHoaDon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1198, 853);
            this.Controls.Add(this.dgvCTHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHD)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridView dgvCTHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}