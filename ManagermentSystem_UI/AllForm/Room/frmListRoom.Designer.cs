namespace SuperProjectQ.AllForm.Room
{
    partial class frmListRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListRoom));
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvListRoom = new System.Windows.Forms.DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioVao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioDatTruoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT_KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoom)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(1238, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvListRoom
            // 
            this.dgvListRoom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.dgvListRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.TenPhong,
            this.TenLoaiPhong,
            this.Tang,
            this.TrangThai,
            this.GioVao,
            this.GioDatTruoc,
            this.SDT_KhachHang,
            this.GhiChu});
            this.dgvListRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListRoom.Location = new System.Drawing.Point(2, 82);
            this.dgvListRoom.Name = "dgvListRoom";
            this.dgvListRoom.RowHeadersWidth = 51;
            this.dgvListRoom.RowTemplate.Height = 24;
            this.dgvListRoom.Size = new System.Drawing.Size(1278, 619);
            this.dgvListRoom.TabIndex = 10;
            this.dgvListRoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRoom_CellDoubleClick);
            this.dgvListRoom.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListRoom_CellFormatting);
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.Width = 125;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên phòng";
            this.TenPhong.MinimumWidth = 6;
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.Width = 125;
            // 
            // TenLoaiPhong
            // 
            this.TenLoaiPhong.DataPropertyName = "TenLoaiPhong";
            this.TenLoaiPhong.HeaderText = "Loại phòng";
            this.TenLoaiPhong.MinimumWidth = 6;
            this.TenLoaiPhong.Name = "TenLoaiPhong";
            this.TenLoaiPhong.Width = 125;
            // 
            // Tang
            // 
            this.Tang.DataPropertyName = "Tang";
            this.Tang.HeaderText = "Tầng";
            this.Tang.MinimumWidth = 6;
            this.Tang.Name = "Tang";
            this.Tang.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 125;
            // 
            // GioVao
            // 
            this.GioVao.DataPropertyName = "GioVao";
            this.GioVao.HeaderText = "Giờ vào";
            this.GioVao.MinimumWidth = 6;
            this.GioVao.Name = "GioVao";
            this.GioVao.Width = 125;
            // 
            // GioDatTruoc
            // 
            this.GioDatTruoc.DataPropertyName = "GioDatTruoc";
            this.GioDatTruoc.HeaderText = "Giờ đặt trước";
            this.GioDatTruoc.MinimumWidth = 6;
            this.GioDatTruoc.Name = "GioDatTruoc";
            this.GioDatTruoc.Width = 125;
            // 
            // SDT_KhachHang
            // 
            this.SDT_KhachHang.DataPropertyName = "SDT_KhachHang";
            this.SDT_KhachHang.HeaderText = "SĐT khách hàng";
            this.SDT_KhachHang.MinimumWidth = 6;
            this.SDT_KhachHang.Name = "SDT_KhachHang";
            this.SDT_KhachHang.Width = 125;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnThemPhong);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 80);
            this.panel1.TabIndex = 11;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.btnThemPhong.FlatAppearance.BorderSize = 0;
            this.btnThemPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPhong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPhong.ForeColor = System.Drawing.Color.White;
            this.btnThemPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPhong.Image")));
            this.btnThemPhong.Location = new System.Drawing.Point(951, 18);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(200, 45);
            this.btnThemPhong.TabIndex = 13;
            this.btnThemPhong.Text = "Thêm phòng";
            this.btnThemPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemPhong.UseVisualStyleBackColor = false;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(455, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(372, 53);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Danh sách phòng";
            // 
            // frmListRoom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1282, 703);
            this.Controls.Add(this.dgvListRoom);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmListRoom";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phòng";
            this.Load += new System.EventHandler(this.frmListRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvListRoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioVao;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioDatTruoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT_KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Button btnThemPhong;
    }
}