namespace SuperProjectQ.AllForm.WareHouse
{
    partial class frmDSachPhieuKK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSachPhieuKK));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDSPKK = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPhieuKiemKe = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MaKiemKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKiemKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonHeThong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonThucTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChenhLech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguyenNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiXacNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXacNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approve = new System.Windows.Forms.DataGridViewImageColumn();
            this.Denied = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPKK)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSPKK
            // 
            this.dgvDSPKK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSPKK.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.dgvDSPKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSPKK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKiemKe,
            this.NgayKiemKe,
            this.NguoiLap,
            this.TenSP,
            this.TonHeThong,
            this.TonThucTe,
            this.ChenhLech,
            this.NguyenNhan,
            this.TrangThai,
            this.NguoiXacNhan,
            this.NgayXacNhan,
            this.Approve,
            this.Denied});
            this.dgvDSPKK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSPKK.Location = new System.Drawing.Point(2, 72);
            this.dgvDSPKK.Name = "dgvDSPKK";
            this.dgvDSPKK.RowHeadersWidth = 51;
            this.dgvDSPKK.RowTemplate.Height = 24;
            this.dgvDSPKK.Size = new System.Drawing.Size(1328, 579);
            this.dgvDSPKK.TabIndex = 0;
            this.dgvDSPKK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSPKK_CellClick);
            this.dgvDSPKK.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSPKK_CellFormatting);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "ChiTiet";
            this.dataGridViewImageColumn1.HeaderText = "Chi tiết";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPhieuKiemKe);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 70);
            this.panel1.TabIndex = 1;
            // 
            // btnPhieuKiemKe
            // 
            this.btnPhieuKiemKe.BackColor = System.Drawing.Color.Cyan;
            this.btnPhieuKiemKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieuKiemKe.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuKiemKe.ForeColor = System.Drawing.Color.White;
            this.btnPhieuKiemKe.Location = new System.Drawing.Point(32, 20);
            this.btnPhieuKiemKe.Name = "btnPhieuKiemKe";
            this.btnPhieuKiemKe.Size = new System.Drawing.Size(160, 35);
            this.btnPhieuKiemKe.TabIndex = 5;
            this.btnPhieuKiemKe.Text = "Phiếu kiểm kê";
            this.btnPhieuKiemKe.UseVisualStyleBackColor = false;
            this.btnPhieuKiemKe.Click += new System.EventHandler(this.btnPhieuKiemKe_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1288, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 57);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh sách phiếu kiểm kê";
            // 
            // MaKiemKe
            // 
            this.MaKiemKe.DataPropertyName = "MaKiemKe";
            this.MaKiemKe.FillWeight = 43.89114F;
            this.MaKiemKe.HeaderText = "Mã";
            this.MaKiemKe.MinimumWidth = 6;
            this.MaKiemKe.Name = "MaKiemKe";
            // 
            // NgayKiemKe
            // 
            this.NgayKiemKe.DataPropertyName = "NgayKiemKe";
            this.NgayKiemKe.FillWeight = 120.3681F;
            this.NgayKiemKe.HeaderText = "Ngày lập";
            this.NgayKiemKe.MinimumWidth = 6;
            this.NgayKiemKe.Name = "NgayKiemKe";
            // 
            // NguoiLap
            // 
            this.NguoiLap.DataPropertyName = "NguoiLap";
            this.NguoiLap.FillWeight = 120.3681F;
            this.NguoiLap.HeaderText = "Nhân viên";
            this.NguoiLap.MinimumWidth = 6;
            this.NguoiLap.Name = "NguoiLap";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.FillWeight = 120.3681F;
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // TonHeThong
            // 
            this.TonHeThong.DataPropertyName = "TonHeThong";
            this.TonHeThong.FillWeight = 99.42854F;
            this.TonHeThong.HeaderText = "Tồn hệ thống";
            this.TonHeThong.MinimumWidth = 6;
            this.TonHeThong.Name = "TonHeThong";
            // 
            // TonThucTe
            // 
            this.TonThucTe.DataPropertyName = "TonThucTe";
            this.TonThucTe.FillWeight = 97.60241F;
            this.TonThucTe.HeaderText = "Tồn thực tế";
            this.TonThucTe.MinimumWidth = 6;
            this.TonThucTe.Name = "TonThucTe";
            // 
            // ChenhLech
            // 
            this.ChenhLech.DataPropertyName = "ChenhLech";
            this.ChenhLech.FillWeight = 95.61703F;
            this.ChenhLech.HeaderText = "Chênh lệch";
            this.ChenhLech.MinimumWidth = 6;
            this.ChenhLech.Name = "ChenhLech";
            // 
            // NguyenNhan
            // 
            this.NguyenNhan.DataPropertyName = "NguyenNhan";
            this.NguyenNhan.FillWeight = 120.3681F;
            this.NguyenNhan.HeaderText = "Nguyên nhân";
            this.NguyenNhan.MinimumWidth = 6;
            this.NguyenNhan.Name = "NguyenNhan";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 128.3422F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            // 
            // NguoiXacNhan
            // 
            this.NguoiXacNhan.DataPropertyName = "NguoiXacNhan";
            this.NguoiXacNhan.FillWeight = 120.3681F;
            this.NguoiXacNhan.HeaderText = "Xác nhận bởi";
            this.NguoiXacNhan.MinimumWidth = 6;
            this.NguoiXacNhan.Name = "NguoiXacNhan";
            // 
            // NgayXacNhan
            // 
            this.NgayXacNhan.DataPropertyName = "NgayXacNhan";
            this.NgayXacNhan.HeaderText = "Xác nhận ngày";
            this.NgayXacNhan.MinimumWidth = 6;
            this.NgayXacNhan.Name = "NgayXacNhan";
            // 
            // Approve
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Approve.DefaultCellStyle = dataGridViewCellStyle1;
            this.Approve.FillWeight = 65.87237F;
            this.Approve.HeaderText = "Duyệt";
            this.Approve.Image = ((System.Drawing.Image)(resources.GetObject("Approve.Image")));
            this.Approve.MinimumWidth = 6;
            this.Approve.Name = "Approve";
            this.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Denied
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Denied.DefaultCellStyle = dataGridViewCellStyle2;
            this.Denied.FillWeight = 67.40545F;
            this.Denied.HeaderText = "Từ chối";
            this.Denied.Image = ((System.Drawing.Image)(resources.GetObject("Denied.Image")));
            this.Denied.MinimumWidth = 6;
            this.Denied.Name = "Denied";
            // 
            // frmDSachPhieuKK
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1332, 653);
            this.Controls.Add(this.dgvDSPKK);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDSachPhieuKK";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Phiếu Kiểm Kê";
            this.Load += new System.EventHandler(this.frmDSachPhieuKK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPKK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridView dgvDSPKK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPhieuKiemKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKiemKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKiemKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonHeThong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonThucTe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChenhLech;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguyenNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiXacNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXacNhan;
        private System.Windows.Forms.DataGridViewImageColumn Approve;
        private System.Windows.Forms.DataGridViewImageColumn Denied;
    }
}