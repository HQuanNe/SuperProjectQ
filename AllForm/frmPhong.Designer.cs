namespace SuperProjectQ.FrmMixed
{
    partial class frmPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhong));
            this.flowLayoutRegular = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCtrlRoom = new System.Windows.Forms.TabControl();
            this.tabPageNormal = new System.Windows.Forms.TabPage();
            this.tabPageVIP = new System.Windows.Forms.TabPage();
            this.flowLayoutVIP = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMenuFood = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVTDinhLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrdered = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.plMenu = new System.Windows.Forms.Panel();
            this.btnCombo = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnBeverage = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.plOrdered = new System.Windows.Forms.Panel();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuyDatTruoc = new System.Windows.Forms.Button();
            this.btnDatTruoc = new System.Windows.Forms.Button();
            this.tabCtrlRoom.SuspendLayout();
            this.tabPageNormal.SuspendLayout();
            this.tabPageVIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdered)).BeginInit();
            this.plMenu.SuspendLayout();
            this.plOrdered.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutRegular
            // 
            this.flowLayoutRegular.AutoScroll = true;
            this.flowLayoutRegular.AutoScrollMinSize = new System.Drawing.Size(0, 600);
            this.flowLayoutRegular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutRegular.Location = new System.Drawing.Point(5, 6);
            this.flowLayoutRegular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutRegular.Name = "flowLayoutRegular";
            this.flowLayoutRegular.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutRegular.Size = new System.Drawing.Size(736, 424);
            this.flowLayoutRegular.TabIndex = 8;
            // 
            // tabCtrlRoom
            // 
            this.tabCtrlRoom.Controls.Add(this.tabPageNormal);
            this.tabCtrlRoom.Controls.Add(this.tabPageVIP);
            this.tabCtrlRoom.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlRoom.Location = new System.Drawing.Point(17, 47);
            this.tabCtrlRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCtrlRoom.Name = "tabCtrlRoom";
            this.tabCtrlRoom.SelectedIndex = 0;
            this.tabCtrlRoom.Size = new System.Drawing.Size(769, 476);
            this.tabCtrlRoom.TabIndex = 8;
            this.tabCtrlRoom.SelectedIndexChanged += new System.EventHandler(this.tabCtrlRoom_SelectedIndexChanged);
            // 
            // tabPageNormal
            // 
            this.tabPageNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPageNormal.Controls.Add(this.flowLayoutRegular);
            this.tabPageNormal.Location = new System.Drawing.Point(4, 28);
            this.tabPageNormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageNormal.Name = "tabPageNormal";
            this.tabPageNormal.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageNormal.Size = new System.Drawing.Size(761, 444);
            this.tabPageNormal.TabIndex = 0;
            this.tabPageNormal.Text = "Phòng thường";
            // 
            // tabPageVIP
            // 
            this.tabPageVIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPageVIP.Controls.Add(this.flowLayoutVIP);
            this.tabPageVIP.Location = new System.Drawing.Point(4, 28);
            this.tabPageVIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageVIP.Name = "tabPageVIP";
            this.tabPageVIP.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageVIP.Size = new System.Drawing.Size(761, 444);
            this.tabPageVIP.TabIndex = 1;
            this.tabPageVIP.Text = "Phòng VIP";
            // 
            // flowLayoutVIP
            // 
            this.flowLayoutVIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutVIP.Location = new System.Drawing.Point(5, 6);
            this.flowLayoutVIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutVIP.Name = "flowLayoutVIP";
            this.flowLayoutVIP.Size = new System.Drawing.Size(731, 476);
            this.flowLayoutVIP.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(457, 4);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(39, 37);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "--";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "Đang chọn: ";
            // 
            // dgvMenuFood
            // 
            this.dgvMenuFood.AllowUserToAddRows = false;
            this.dgvMenuFood.AllowUserToDeleteRows = false;
            this.dgvMenuFood.AllowUserToResizeColumns = false;
            this.dgvMenuFood.AllowUserToResizeRows = false;
            this.dgvMenuFood.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvMenuFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuFood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.DinhLuong,
            this.DVTDinhLuong,
            this.DonViTinh,
            this.GiaBan});
            this.dgvMenuFood.Location = new System.Drawing.Point(3, 68);
            this.dgvMenuFood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMenuFood.Name = "dgvMenuFood";
            this.dgvMenuFood.RowHeadersVisible = false;
            this.dgvMenuFood.RowHeadersWidth = 51;
            this.dgvMenuFood.RowTemplate.Height = 24;
            this.dgvMenuFood.Size = new System.Drawing.Size(667, 357);
            this.dgvMenuFood.TabIndex = 14;
            this.dgvMenuFood.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuFood_CellDoubleClick);
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.Width = 55;
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.Width = 220;
            // 
            // DinhLuong
            // 
            this.DinhLuong.DataPropertyName = "DinhLuong";
            this.DinhLuong.HeaderText = "Định lượng";
            this.DinhLuong.MinimumWidth = 6;
            this.DinhLuong.Name = "DinhLuong";
            this.DinhLuong.Width = 55;
            // 
            // DVTDinhLuong
            // 
            this.DVTDinhLuong.DataPropertyName = "DVTDinhLuong";
            this.DVTDinhLuong.HeaderText = "ĐVT Định lượng";
            this.DVTDinhLuong.MinimumWidth = 6;
            this.DVTDinhLuong.Name = "DVTDinhLuong";
            this.DVTDinhLuong.Width = 80;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.MinimumWidth = 6;
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.Width = 80;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Đơn giá";
            this.GiaBan.MinimumWidth = 6;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 75;
            // 
            // dgvOrdered
            // 
            this.dgvOrdered.AllowUserToAddRows = false;
            this.dgvOrdered.AllowUserToResizeRows = false;
            this.dgvOrdered.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvOrdered.ColumnHeadersHeight = 29;
            this.dgvOrdered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdered.Location = new System.Drawing.Point(3, 1);
            this.dgvOrdered.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrdered.Name = "dgvOrdered";
            this.dgvOrdered.ReadOnly = true;
            this.dgvOrdered.RowHeadersVisible = false;
            this.dgvOrdered.RowHeadersWidth = 51;
            this.dgvOrdered.RowTemplate.Height = 24;
            this.dgvOrdered.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdered.Size = new System.Drawing.Size(756, 250);
            this.dgvOrdered.TabIndex = 15;
            this.dgvOrdered.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdered_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(555, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 42);
            this.label3.TabIndex = 17;
            this.label3.Text = "Menu";
            // 
            // plMenu
            // 
            this.plMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plMenu.Controls.Add(this.btnCombo);
            this.plMenu.Controls.Add(this.btnOther);
            this.plMenu.Controls.Add(this.btnBeverage);
            this.plMenu.Controls.Add(this.btnFood);
            this.plMenu.Controls.Add(this.label3);
            this.plMenu.Controls.Add(this.btnAll);
            this.plMenu.Controls.Add(this.dgvMenuFood);
            this.plMenu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plMenu.Location = new System.Drawing.Point(788, 11);
            this.plMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plMenu.Name = "plMenu";
            this.plMenu.Size = new System.Drawing.Size(673, 427);
            this.plMenu.TabIndex = 18;
            // 
            // btnCombo
            // 
            this.btnCombo.Location = new System.Drawing.Point(393, 2);
            this.btnCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCombo.Name = "btnCombo";
            this.btnCombo.Size = new System.Drawing.Size(91, 32);
            this.btnCombo.TabIndex = 19;
            this.btnCombo.Text = "Combo";
            this.btnCombo.UseVisualStyleBackColor = true;
            // 
            // btnOther
            // 
            this.btnOther.Location = new System.Drawing.Point(272, 2);
            this.btnOther.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(91, 32);
            this.btnOther.TabIndex = 18;
            this.btnOther.Text = "Khác";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.AllButtons_Click);
            // 
            // btnBeverage
            // 
            this.btnBeverage.Location = new System.Drawing.Point(183, 2);
            this.btnBeverage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBeverage.Name = "btnBeverage";
            this.btnBeverage.Size = new System.Drawing.Size(91, 32);
            this.btnBeverage.TabIndex = 17;
            this.btnBeverage.Text = "Đồ uống";
            this.btnBeverage.UseVisualStyleBackColor = true;
            this.btnBeverage.Click += new System.EventHandler(this.AllButtons_Click);
            // 
            // btnFood
            // 
            this.btnFood.Location = new System.Drawing.Point(94, 2);
            this.btnFood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(91, 32);
            this.btnFood.TabIndex = 16;
            this.btnFood.Text = "Đồ ăn";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.AllButtons_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(4, 2);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(91, 32);
            this.btnAll.TabIndex = 15;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.AllButtons_Click);
            // 
            // plOrdered
            // 
            this.plOrdered.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.plOrdered.Controls.Add(this.txtSDT);
            this.plOrdered.Controls.Add(this.label7);
            this.plOrdered.Controls.Add(this.btnConfirm);
            this.plOrdered.Controls.Add(this.lblTenSP);
            this.plOrdered.Controls.Add(this.label6);
            this.plOrdered.Controls.Add(this.lblTongTien);
            this.plOrdered.Controls.Add(this.label4);
            this.plOrdered.Controls.Add(this.numSoLuong);
            this.plOrdered.Controls.Add(this.label2);
            this.plOrdered.Controls.Add(this.dgvOrdered);
            this.plOrdered.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plOrdered.Location = new System.Drawing.Point(21, 527);
            this.plOrdered.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plOrdered.Name = "plOrdered";
            this.plOrdered.Size = new System.Drawing.Size(1440, 265);
            this.plOrdered.TabIndex = 19;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(1003, 164);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(249, 31);
            this.txtSDT.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(763, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 31);
            this.label7.TabIndex = 22;
            this.label7.Text = "SĐT Khách hàng: ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(1337, 14);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(76, 30);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(874, 18);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(24, 23);
            this.lblTenSP.TabIndex = 21;
            this.lblTenSP.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(765, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Sản phẩm: ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(936, 61);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(67, 23);
            this.lblTongTien.TabIndex = 19;
            this.lblTongTien.Text = "0 VND";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(765, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tổng tiền dịch vụ: ";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoLuong.Location = new System.Drawing.Point(1258, 14);
            this.numSoLuong.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(73, 30);
            this.numSoLuong.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1156, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Số lượng: ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(4, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 71);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng phòng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.White;
            this.btnOrder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(562, 2);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(105, 71);
            this.btnOrder.TabIndex = 5;
            this.btnOrder.Text = "VIP Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Lime;
            this.btnOpen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(3, 2);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(178, 71);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Mở phòng";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnHuyDatTruoc);
            this.panel1.Controls.Add(this.btnDatTruoc);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(788, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 76);
            this.panel1.TabIndex = 20;
            // 
            // btnHuyDatTruoc
            // 
            this.btnHuyDatTruoc.BackColor = System.Drawing.Color.Teal;
            this.btnHuyDatTruoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDatTruoc.Location = new System.Drawing.Point(183, 2);
            this.btnHuyDatTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyDatTruoc.Name = "btnHuyDatTruoc";
            this.btnHuyDatTruoc.Size = new System.Drawing.Size(178, 71);
            this.btnHuyDatTruoc.TabIndex = 7;
            this.btnHuyDatTruoc.Text = "Huỷ đặt trước";
            this.btnHuyDatTruoc.UseVisualStyleBackColor = false;
            this.btnHuyDatTruoc.Click += new System.EventHandler(this.btnHuyDatTruoc_Click);
            // 
            // btnDatTruoc
            // 
            this.btnDatTruoc.BackColor = System.Drawing.Color.Aqua;
            this.btnDatTruoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatTruoc.Location = new System.Drawing.Point(183, 2);
            this.btnDatTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDatTruoc.Name = "btnDatTruoc";
            this.btnDatTruoc.Size = new System.Drawing.Size(178, 71);
            this.btnDatTruoc.TabIndex = 6;
            this.btnDatTruoc.Text = "Đặt trước";
            this.btnDatTruoc.UseVisualStyleBackColor = false;
            this.btnDatTruoc.Click += new System.EventHandler(this.btnDatTruoc_Click);
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1473, 803);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plOrdered);
            this.Controls.Add(this.plMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.tabCtrlRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng";
            this.Load += new System.EventHandler(this.frmPhong_Load);
            this.tabCtrlRoom.ResumeLayout(false);
            this.tabPageNormal.ResumeLayout(false);
            this.tabPageVIP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdered)).EndInit();
            this.plMenu.ResumeLayout(false);
            this.plMenu.PerformLayout();
            this.plOrdered.ResumeLayout(false);
            this.plOrdered.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutRegular;
        private System.Windows.Forms.TabControl tabCtrlRoom;
        private System.Windows.Forms.TabPage tabPageNormal;
        private System.Windows.Forms.TabPage tabPageVIP;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutVIP;
        private System.Windows.Forms.DataGridView dgvMenuFood;
        private System.Windows.Forms.DataGridView dgvOrdered;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plMenu;
        private System.Windows.Forms.Panel plOrdered;
        private System.Windows.Forms.Button btnBeverage;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDatTruoc;
        private System.Windows.Forms.Button btnHuyDatTruoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVTDinhLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
    }
}