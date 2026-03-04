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
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTichLuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plButton = new System.Windows.Forms.Panel();
            this.btnVouchers = new System.Windows.Forms.Button();
            this.btnKoGhi = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.plInfo = new System.Windows.Forms.Panel();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDTL = new System.Windows.Forms.TextBox();
            this.lblTenTP = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenVoucher = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaVoucher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.plButton.SuspendLayout();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.AllowUserToResizeColumns = false;
            this.dgvKhachHang.AllowUserToResizeRows = false;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKH,
            this.TenKH,
            this.DiaChi,
            this.SoDienThoai,
            this.VIP,
            this.DiemTichLuy,
            this.Discount});
            this.dgvKhachHang.Location = new System.Drawing.Point(12, 193);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.RowTemplate.Height = 24;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(785, 452);
            this.dgvKhachHang.TabIndex = 22;
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã KH";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            this.MaKH.Width = 55;
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên KH";
            this.TenKH.MinimumWidth = 6;
            this.TenKH.Name = "TenKH";
            this.TenKH.Width = 110;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 120;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.DataPropertyName = "SoDienThoai";
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.MinimumWidth = 6;
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.Width = 90;
            // 
            // VIP
            // 
            this.VIP.DataPropertyName = "VIP";
            this.VIP.HeaderText = "VIP";
            this.VIP.MinimumWidth = 6;
            this.VIP.Name = "VIP";
            this.VIP.Width = 55;
            // 
            // DiemTichLuy
            // 
            this.DiemTichLuy.DataPropertyName = "DiemTichLuy";
            this.DiemTichLuy.HeaderText = "Điểm tích luỹ";
            this.DiemTichLuy.MinimumWidth = 6;
            this.DiemTichLuy.Name = "DiemTichLuy";
            this.DiemTichLuy.Width = 125;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Triết khấu";
            this.Discount.MinimumWidth = 6;
            this.Discount.Name = "Discount";
            this.Discount.Width = 60;
            // 
            // plButton
            // 
            this.plButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plButton.Controls.Add(this.btnVouchers);
            this.plButton.Controls.Add(this.btnKoGhi);
            this.plButton.Controls.Add(this.btnGhi);
            this.plButton.Controls.Add(this.btnXoa);
            this.plButton.Controls.Add(this.btnSua);
            this.plButton.Controls.Add(this.btnThem);
            this.plButton.Location = new System.Drawing.Point(803, 193);
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(181, 361);
            this.plButton.TabIndex = 19;
            // 
            // btnVouchers
            // 
            this.btnVouchers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVouchers.Location = new System.Drawing.Point(18, 293);
            this.btnVouchers.Name = "btnVouchers";
            this.btnVouchers.Size = new System.Drawing.Size(146, 60);
            this.btnVouchers.TabIndex = 14;
            this.btnVouchers.Text = "Vouchers";
            this.btnVouchers.UseVisualStyleBackColor = true;
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
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(803, 567);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(181, 78);
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // plInfo
            // 
            this.plInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plInfo.Controls.Add(this.txtDiscount);
            this.plInfo.Controls.Add(this.label7);
            this.plInfo.Controls.Add(this.txtVIP);
            this.plInfo.Controls.Add(this.label6);
            this.plInfo.Controls.Add(this.txtDTL);
            this.plInfo.Controls.Add(this.lblTenTP);
            this.plInfo.Controls.Add(this.txtSDT);
            this.plInfo.Controls.Add(this.label4);
            this.plInfo.Controls.Add(this.txtDiaChi);
            this.plInfo.Controls.Add(this.txtTenVoucher);
            this.plInfo.Controls.Add(this.label1);
            this.plInfo.Controls.Add(this.txtMaVoucher);
            this.plInfo.Controls.Add(this.label2);
            this.plInfo.Controls.Add(this.lblMaKH);
            this.plInfo.Location = new System.Drawing.Point(12, 12);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(972, 175);
            this.plInfo.TabIndex = 18;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(628, 111);
            this.txtDiscount.Multiline = true;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(101, 30);
            this.txtDiscount.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(522, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 20;
            this.label7.Text = "Triết khấu: ";
            // 
            // txtVIP
            // 
            this.txtVIP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVIP.Location = new System.Drawing.Point(439, 111);
            this.txtVIP.Multiline = true;
            this.txtVIP.Name = "txtVIP";
            this.txtVIP.Size = new System.Drawing.Size(65, 30);
            this.txtVIP.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(382, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "VIP: ";
            // 
            // txtDTL
            // 
            this.txtDTL.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDTL.Location = new System.Drawing.Point(526, 61);
            this.txtDTL.Multiline = true;
            this.txtDTL.Name = "txtDTL";
            this.txtDTL.Size = new System.Drawing.Size(203, 30);
            this.txtDTL.TabIndex = 17;
            // 
            // lblTenTP
            // 
            this.lblTenTP.AutoSize = true;
            this.lblTenTP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTP.Location = new System.Drawing.Point(382, 69);
            this.lblTenTP.Name = "lblTenTP";
            this.lblTenTP.Size = new System.Drawing.Size(122, 22);
            this.lblTenTP.TabIndex = 16;
            this.lblTenTP.Text = "Điểm tích luỹ:";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(526, 11);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(203, 30);
            this.txtSDT.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(382, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Điện thoại: ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(158, 111);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(203, 30);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txtTenVoucher
            // 
            this.txtTenVoucher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVoucher.Location = new System.Drawing.Point(158, 61);
            this.txtTenVoucher.Multiline = true;
            this.txtTenVoucher.Name = "txtTenVoucher";
            this.txtTenVoucher.Size = new System.Drawing.Size(203, 30);
            this.txtTenVoucher.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Địa chỉ: ";
            // 
            // txtMaVoucher
            // 
            this.txtMaVoucher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVoucher.Location = new System.Drawing.Point(158, 11);
            this.txtMaVoucher.Multiline = true;
            this.txtMaVoucher.Name = "txtMaVoucher";
            this.txtMaVoucher.Size = new System.Drawing.Size(203, 30);
            this.txtMaVoucher.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Voucher";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(14, 19);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(110, 22);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã Voucher:";
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 660);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.plButton);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.plInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVoucher";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.plButton.ResumeLayout(false);
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTichLuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.Panel plButton;
        private System.Windows.Forms.Button btnVouchers;
        private System.Windows.Forms.Button btnKoGhi;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDTL;
        private System.Windows.Forms.Label lblTenTP;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenVoucher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaVoucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaKH;
    }
}