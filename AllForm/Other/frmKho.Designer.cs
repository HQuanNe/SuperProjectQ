namespace SuperProjectQ.AllForm.Other
{
    partial class frmKho
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
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCapNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plTimKiem = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radSDT = new System.Windows.Forms.RadioButton();
            this.radTenSP = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.plButton = new System.Windows.Forms.Panel();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.btnKoGhi = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.plInfo = new System.Windows.Forms.Panel();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.dtNgayCapNhat = new System.Windows.Forms.DateTimePicker();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTonKho = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTenTP = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.plTimKiem.SuspendLayout();
            this.plButton.SuspendLayout();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKho
            // 
            this.dgvKho.AllowUserToAddRows = false;
            this.dgvKho.AllowUserToDeleteRows = false;
            this.dgvKho.AllowUserToResizeColumns = false;
            this.dgvKho.AllowUserToResizeRows = false;
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.MaDM,
            this.DonViTinh,
            this.TonKho,
            this.NgayCapNhat,
            this.DonGiaNhap,
            this.TrangThai,
            this.GhiChu});
            this.dgvKho.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKho.Location = new System.Drawing.Point(12, 214);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowHeadersVisible = false;
            this.dgvKho.RowHeadersWidth = 51;
            this.dgvKho.RowTemplate.Height = 24;
            this.dgvKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKho.Size = new System.Drawing.Size(785, 527);
            this.dgvKho.TabIndex = 22;
            this.dgvKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKho_CellClick);
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.Width = 55;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên SP";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 160;
            // 
            // MaDM
            // 
            this.MaDM.DataPropertyName = "MaDM";
            this.MaDM.HeaderText = "Danh mục";
            this.MaDM.MinimumWidth = 6;
            this.MaDM.Name = "MaDM";
            this.MaDM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaDM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaDM.Width = 90;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "ĐVT";
            this.DonViTinh.MinimumWidth = 6;
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.Width = 40;
            // 
            // TonKho
            // 
            this.TonKho.DataPropertyName = "TonKho";
            this.TonKho.HeaderText = "Tồn kho";
            this.TonKho.MinimumWidth = 6;
            this.TonKho.Name = "TonKho";
            this.TonKho.Width = 55;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.DataPropertyName = "NgayCapNhat";
            this.NgayCapNhat.HeaderText = "Ngày cập nhật";
            this.NgayCapNhat.MinimumWidth = 6;
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Width = 80;
            // 
            // DonGiaNhap
            // 
            this.DonGiaNhap.DataPropertyName = "DonGiaNhap";
            this.DonGiaNhap.HeaderText = "Đơn giá nhập";
            this.DonGiaNhap.MinimumWidth = 6;
            this.DonGiaNhap.Name = "DonGiaNhap";
            this.DonGiaNhap.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái hàng";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 65;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 125;
            // 
            // plTimKiem
            // 
            this.plTimKiem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plTimKiem.Controls.Add(this.label5);
            this.plTimKiem.Controls.Add(this.txtSearch);
            this.plTimKiem.Controls.Add(this.radSDT);
            this.plTimKiem.Controls.Add(this.radTenSP);
            this.plTimKiem.Controls.Add(this.label3);
            this.plTimKiem.Location = new System.Drawing.Point(803, 11);
            this.plTimKiem.Name = "plTimKiem";
            this.plTimKiem.Size = new System.Drawing.Size(181, 197);
            this.plTimKiem.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 34);
            this.label5.TabIndex = 22;
            this.label5.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 137);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 45);
            this.txtSearch.TabIndex = 22;
            // 
            // radSDT
            // 
            this.radSDT.AutoSize = true;
            this.radSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSDT.Location = new System.Drawing.Point(18, 103);
            this.radSDT.Name = "radSDT";
            this.radSDT.Size = new System.Drawing.Size(139, 26);
            this.radSDT.TabIndex = 13;
            this.radSDT.TabStop = true;
            this.radSDT.Text = "Tên sản phẩm";
            this.radSDT.UseVisualStyleBackColor = true;
            // 
            // radTenSP
            // 
            this.radTenSP.AutoSize = true;
            this.radTenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTenSP.Location = new System.Drawing.Point(18, 67);
            this.radTenSP.Name = "radTenSP";
            this.radTenSP.Size = new System.Drawing.Size(135, 26);
            this.radTenSP.TabIndex = 12;
            this.radTenSP.TabStop = true;
            this.radTenSP.Text = "Mã sản phẩm";
            this.radTenSP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 22);
            this.label3.TabIndex = 7;
            // 
            // plButton
            // 
            this.plButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plButton.Controls.Add(this.btnNhapKho);
            this.plButton.Controls.Add(this.btnKoGhi);
            this.plButton.Controls.Add(this.btnGhi);
            this.plButton.Controls.Add(this.btnXoa);
            this.plButton.Controls.Add(this.btnSua);
            this.plButton.Controls.Add(this.btnThem);
            this.plButton.Location = new System.Drawing.Point(803, 214);
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(181, 443);
            this.plButton.TabIndex = 19;
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapKho.Location = new System.Drawing.Point(18, 380);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(146, 60);
            this.btnNhapKho.TabIndex = 14;
            this.btnNhapKho.Text = "Nhập kho";
            this.btnNhapKho.UseVisualStyleBackColor = true;
            // 
            // btnKoGhi
            // 
            this.btnKoGhi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKoGhi.Location = new System.Drawing.Point(18, 80);
            this.btnKoGhi.Name = "btnKoGhi";
            this.btnKoGhi.Size = new System.Drawing.Size(146, 60);
            this.btnKoGhi.TabIndex = 13;
            this.btnKoGhi.Text = "Không";
            this.btnKoGhi.UseVisualStyleBackColor = true;
            this.btnKoGhi.Click += new System.EventHandler(this.btnKoGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Location = new System.Drawing.Point(18, 14);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(146, 60);
            this.btnGhi.TabIndex = 12;
            this.btnGhi.Text = "Xác nhận";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(18, 146);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(146, 60);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(18, 80);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(146, 60);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(18, 14);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(146, 60);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(803, 663);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(181, 78);
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // plInfo
            // 
            this.plInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plInfo.Controls.Add(this.cmbDanhMuc);
            this.plInfo.Controls.Add(this.dtNgayCapNhat);
            this.plInfo.Controls.Add(this.txtTrangThai);
            this.plInfo.Controls.Add(this.label9);
            this.plInfo.Controls.Add(this.txtGhiChu);
            this.plInfo.Controls.Add(this.label7);
            this.plInfo.Controls.Add(this.txtDonGiaNhap);
            this.plInfo.Controls.Add(this.label8);
            this.plInfo.Controls.Add(this.txtTonKho);
            this.plInfo.Controls.Add(this.label6);
            this.plInfo.Controls.Add(this.lblTenTP);
            this.plInfo.Controls.Add(this.txtDVT);
            this.plInfo.Controls.Add(this.label4);
            this.plInfo.Controls.Add(this.txtTenSP);
            this.plInfo.Controls.Add(this.label1);
            this.plInfo.Controls.Add(this.txtMaSP);
            this.plInfo.Controls.Add(this.label2);
            this.plInfo.Controls.Add(this.lblMaKH);
            this.plInfo.Location = new System.Drawing.Point(12, 11);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(785, 197);
            this.plInfo.TabIndex = 18;
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDanhMuc.FormattingEnabled = true;
            this.cmbDanhMuc.Location = new System.Drawing.Point(158, 113);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(203, 30);
            this.cmbDanhMuc.TabIndex = 29;
            // 
            // dtNgayCapNhat
            // 
            this.dtNgayCapNhat.CalendarFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayCapNhat.Location = new System.Drawing.Point(526, 11);
            this.dtNgayCapNhat.MinimumSize = new System.Drawing.Size(4, 30);
            this.dtNgayCapNhat.Name = "dtNgayCapNhat";
            this.dtNgayCapNhat.Size = new System.Drawing.Size(200, 30);
            this.dtNgayCapNhat.TabIndex = 28;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.Location = new System.Drawing.Point(664, 157);
            this.txtTrangThai.Multiline = true;
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(65, 30);
            this.txtTrangThai.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(569, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 22);
            this.label9.TabIndex = 26;
            this.label9.Text = "Trạng thái:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(526, 109);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(203, 30);
            this.txtGhiChu.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(382, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 22);
            this.label7.TabIndex = 24;
            this.label7.Text = "Ghi chú:";
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGiaNhap.Location = new System.Drawing.Point(526, 60);
            this.txtDonGiaNhap.Multiline = true;
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(203, 30);
            this.txtDonGiaNhap.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(382, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 22);
            this.label8.TabIndex = 22;
            this.label8.Text = "Đơn giá nhập:";
            // 
            // txtTonKho
            // 
            this.txtTonKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTonKho.Location = new System.Drawing.Point(462, 157);
            this.txtTonKho.Multiline = true;
            this.txtTonKho.Name = "txtTonKho";
            this.txtTonKho.Size = new System.Drawing.Size(65, 30);
            this.txtTonKho.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(382, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tồn kho:";
            // 
            // lblTenTP
            // 
            this.lblTenTP.AutoSize = true;
            this.lblTenTP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTP.Location = new System.Drawing.Point(382, 19);
            this.lblTenTP.Name = "lblTenTP";
            this.lblTenTP.Size = new System.Drawing.Size(127, 22);
            this.lblTenTP.TabIndex = 16;
            this.lblTenTP.Text = "Ngày cập nhật:";
            // 
            // txtDVT
            // 
            this.txtDVT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(158, 157);
            this.txtDVT.Multiline = true;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(203, 30);
            this.txtDVT.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Đơn vị tính:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(158, 57);
            this.txtTenSP.Multiline = true;
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(203, 45);
            this.txtTenSP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh mục:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(158, 11);
            this.txtMaSP.Multiline = true;
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(203, 30);
            this.txtMaSP.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(14, 19);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(114, 22);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã sản phẩm";
            // 
            // frmKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 753);
            this.Controls.Add(this.dgvKho);
            this.Controls.Add(this.plTimKiem);
            this.Controls.Add(this.plButton);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.plInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKho";
            this.Load += new System.EventHandler(this.frmKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.plTimKiem.ResumeLayout(false);
            this.plTimKiem.PerformLayout();
            this.plButton.ResumeLayout(false);
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Panel plTimKiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton radSDT;
        private System.Windows.Forms.RadioButton radTenSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plButton;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnKoGhi;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.TextBox txtTonKho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTenTP;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtNgayCapNhat;
        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}