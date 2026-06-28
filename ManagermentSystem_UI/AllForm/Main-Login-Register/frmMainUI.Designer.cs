namespace SuperProjectQ.Frm_Main_Login_Register
{
    partial class frmMainUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainUI));
            this.btnLogOut = new System.Windows.Forms.Button();
            this.MNNavBar = new System.Windows.Forms.MenuStrip();
            this.MNHome = new System.Windows.Forms.ToolStripMenuItem();
            this.MNRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMenuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.MNBill = new System.Windows.Forms.ToolStripMenuItem();
            this.MNStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.MNCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.MNStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.MNKiemKe = new System.Windows.Forms.ToolStripMenuItem();
            this.MNChart = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMore = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMore_Products = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMore_Voucher = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMore_Account = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMore_NhapKho = new System.Windows.Forms.ToolStripMenuItem();
            this.MNMore_History = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetting = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.plNavBar = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerWeather = new System.Windows.Forms.Timer(this.components);
            this.timerSoundEffect = new System.Windows.Forms.Timer(this.components);
            this.plControls = new System.Windows.Forms.Panel();
            this.lblTitleXinChao = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.btnOpenNavBar = new System.Windows.Forms.Button();
            this.btnAIChatbot = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.plInfo = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.MNNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.plNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogOut.BackColor = System.Drawing.Color.Red;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(14, 642);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(235, 55);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Đăng xuất";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // MNNavBar
            // 
            this.MNNavBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MNNavBar.BackColor = System.Drawing.Color.White;
            this.MNNavBar.Dock = System.Windows.Forms.DockStyle.None;
            this.MNNavBar.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNNavBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MNNavBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNHome,
            this.MNRoom,
            this.MNMenuOrder,
            this.MNBill,
            this.MNStaffs,
            this.MNCustomers,
            this.MNStorage,
            this.MNKiemKe,
            this.MNChart,
            this.MNMore});
            this.MNNavBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MNNavBar.Location = new System.Drawing.Point(14, 88);
            this.MNNavBar.MaximumSize = new System.Drawing.Size(300, 1000);
            this.MNNavBar.MinimumSize = new System.Drawing.Size(240, 0);
            this.MNNavBar.Name = "MNNavBar";
            this.MNNavBar.Size = new System.Drawing.Size(240, 490);
            this.MNNavBar.TabIndex = 10;
            this.MNNavBar.Text = "NavBar";
            // 
            // MNHome
            // 
            this.MNHome.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNHome.ForeColor = System.Drawing.Color.Black;
            this.MNHome.Image = ((System.Drawing.Image)(resources.GetObject("MNHome.Image")));
            this.MNHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNHome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNHome.Name = "MNHome";
            this.MNHome.Padding = new System.Windows.Forms.Padding(5);
            this.MNHome.Size = new System.Drawing.Size(233, 46);
            this.MNHome.Text = "Trang chủ";
            this.MNHome.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNHome.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNRoom
            // 
            this.MNRoom.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNRoom.ForeColor = System.Drawing.Color.Black;
            this.MNRoom.Image = ((System.Drawing.Image)(resources.GetObject("MNRoom.Image")));
            this.MNRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNRoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNRoom.Name = "MNRoom";
            this.MNRoom.Padding = new System.Windows.Forms.Padding(5);
            this.MNRoom.Size = new System.Drawing.Size(233, 46);
            this.MNRoom.Text = "Phòng";
            this.MNRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNRoom.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMenuOrder
            // 
            this.MNMenuOrder.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMenuOrder.ForeColor = System.Drawing.Color.Black;
            this.MNMenuOrder.Image = ((System.Drawing.Image)(resources.GetObject("MNMenuOrder.Image")));
            this.MNMenuOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNMenuOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNMenuOrder.Name = "MNMenuOrder";
            this.MNMenuOrder.Padding = new System.Windows.Forms.Padding(5);
            this.MNMenuOrder.Size = new System.Drawing.Size(233, 46);
            this.MNMenuOrder.Text = "Menu";
            this.MNMenuOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNMenuOrder.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNBill
            // 
            this.MNBill.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNBill.ForeColor = System.Drawing.Color.Black;
            this.MNBill.Image = ((System.Drawing.Image)(resources.GetObject("MNBill.Image")));
            this.MNBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNBill.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNBill.Name = "MNBill";
            this.MNBill.Padding = new System.Windows.Forms.Padding(5);
            this.MNBill.Size = new System.Drawing.Size(233, 46);
            this.MNBill.Text = "Hoá đơn";
            this.MNBill.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNBill.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNStaffs
            // 
            this.MNStaffs.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNStaffs.ForeColor = System.Drawing.Color.Black;
            this.MNStaffs.Image = ((System.Drawing.Image)(resources.GetObject("MNStaffs.Image")));
            this.MNStaffs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNStaffs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNStaffs.Name = "MNStaffs";
            this.MNStaffs.Padding = new System.Windows.Forms.Padding(5);
            this.MNStaffs.Size = new System.Drawing.Size(233, 46);
            this.MNStaffs.Text = "Nhân viên";
            this.MNStaffs.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNStaffs.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNCustomers
            // 
            this.MNCustomers.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNCustomers.ForeColor = System.Drawing.Color.Black;
            this.MNCustomers.Image = ((System.Drawing.Image)(resources.GetObject("MNCustomers.Image")));
            this.MNCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNCustomers.Name = "MNCustomers";
            this.MNCustomers.Padding = new System.Windows.Forms.Padding(5);
            this.MNCustomers.Size = new System.Drawing.Size(233, 46);
            this.MNCustomers.Text = "Khách hàng";
            this.MNCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNCustomers.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNStorage
            // 
            this.MNStorage.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNStorage.ForeColor = System.Drawing.Color.Black;
            this.MNStorage.Image = ((System.Drawing.Image)(resources.GetObject("MNStorage.Image")));
            this.MNStorage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNStorage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNStorage.Name = "MNStorage";
            this.MNStorage.Padding = new System.Windows.Forms.Padding(5);
            this.MNStorage.Size = new System.Drawing.Size(233, 46);
            this.MNStorage.Text = "Kho ";
            this.MNStorage.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNStorage.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNKiemKe
            // 
            this.MNKiemKe.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNKiemKe.Image = ((System.Drawing.Image)(resources.GetObject("MNKiemKe.Image")));
            this.MNKiemKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNKiemKe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNKiemKe.Name = "MNKiemKe";
            this.MNKiemKe.Padding = new System.Windows.Forms.Padding(5);
            this.MNKiemKe.Size = new System.Drawing.Size(233, 46);
            this.MNKiemKe.Text = "Kiểm kê";
            this.MNKiemKe.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNKiemKe.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNChart
            // 
            this.MNChart.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNChart.ForeColor = System.Drawing.Color.Black;
            this.MNChart.Image = ((System.Drawing.Image)(resources.GetObject("MNChart.Image")));
            this.MNChart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNChart.Name = "MNChart";
            this.MNChart.Padding = new System.Windows.Forms.Padding(5);
            this.MNChart.Size = new System.Drawing.Size(233, 46);
            this.MNChart.Text = "Biểu đồ";
            this.MNChart.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNChart.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMore
            // 
            this.MNMore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNMore_Products,
            this.MNMore_Voucher,
            this.MNMore_Account,
            this.MNMore_NhapKho,
            this.MNMore_History});
            this.MNMore.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMore.ForeColor = System.Drawing.Color.Black;
            this.MNMore.Image = ((System.Drawing.Image)(resources.GetObject("MNMore.Image")));
            this.MNMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MNMore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MNMore.Name = "MNMore";
            this.MNMore.Padding = new System.Windows.Forms.Padding(5);
            this.MNMore.Size = new System.Drawing.Size(233, 46);
            this.MNMore.Text = "Thêm";
            this.MNMore.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MNMore.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMore_Products
            // 
            this.MNMore_Products.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMore_Products.Image = ((System.Drawing.Image)(resources.GetObject("MNMore_Products.Image")));
            this.MNMore_Products.Name = "MNMore_Products";
            this.MNMore_Products.Size = new System.Drawing.Size(182, 26);
            this.MNMore_Products.Text = "Sản phẩm";
            this.MNMore_Products.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMore_Voucher
            // 
            this.MNMore_Voucher.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMore_Voucher.Image = ((System.Drawing.Image)(resources.GetObject("MNMore_Voucher.Image")));
            this.MNMore_Voucher.Name = "MNMore_Voucher";
            this.MNMore_Voucher.Size = new System.Drawing.Size(182, 26);
            this.MNMore_Voucher.Text = "Voucher";
            this.MNMore_Voucher.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMore_Account
            // 
            this.MNMore_Account.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMore_Account.Image = ((System.Drawing.Image)(resources.GetObject("MNMore_Account.Image")));
            this.MNMore_Account.Name = "MNMore_Account";
            this.MNMore_Account.Size = new System.Drawing.Size(182, 26);
            this.MNMore_Account.Text = "Tài khoản";
            this.MNMore_Account.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMore_NhapKho
            // 
            this.MNMore_NhapKho.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMore_NhapKho.Image = ((System.Drawing.Image)(resources.GetObject("MNMore_NhapKho.Image")));
            this.MNMore_NhapKho.Name = "MNMore_NhapKho";
            this.MNMore_NhapKho.Size = new System.Drawing.Size(182, 26);
            this.MNMore_NhapKho.Text = "Nhập kho";
            this.MNMore_NhapKho.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // MNMore_History
            // 
            this.MNMore_History.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNMore_History.Image = ((System.Drawing.Image)(resources.GetObject("MNMore_History.Image")));
            this.MNMore_History.Name = "MNMore_History";
            this.MNMore_History.Size = new System.Drawing.Size(224, 26);
            this.MNMore_History.Text = "Lịch sử";
            this.MNMore_History.Click += new System.EventHandler(this.AllMenu_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetting.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(142)))), ((int)(((byte)(252)))));
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.Location = new System.Drawing.Point(14, 568);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(235, 55);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "Cài đặt";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(14, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(235, 70);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // plNavBar
            // 
            this.plNavBar.Controls.Add(this.btnSetting);
            this.plNavBar.Controls.Add(this.btnLogOut);
            this.plNavBar.Controls.Add(this.picLogo);
            this.plNavBar.Controls.Add(this.MNNavBar);
            this.plNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.plNavBar.Location = new System.Drawing.Point(0, 53);
            this.plNavBar.Name = "plNavBar";
            this.plNavBar.Size = new System.Drawing.Size(265, 700);
            this.plNavBar.TabIndex = 8;
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerWeather
            // 
            this.timerWeather.Tick += new System.EventHandler(this.timerWeather_Tick);
            // 
            // timerSoundEffect
            // 
            this.timerSoundEffect.Interval = 2100;
            this.timerSoundEffect.Tick += new System.EventHandler(this.timerSoundEffect_Tick);
            // 
            // plControls
            // 
            this.plControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            this.plControls.Location = new System.Drawing.Point(264, 53);
            this.plControls.MaximumSize = new System.Drawing.Size(2500, 1500);
            this.plControls.MinimumSize = new System.Drawing.Size(1225, 0);
            this.plControls.Name = "plControls";
            this.plControls.Padding = new System.Windows.Forms.Padding(5);
            this.plControls.Size = new System.Drawing.Size(1225, 700);
            this.plControls.TabIndex = 7;
            // 
            // lblTitleXinChao
            // 
            this.lblTitleXinChao.AutoSize = true;
            this.lblTitleXinChao.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleXinChao.Location = new System.Drawing.Point(1035, 18);
            this.lblTitleXinChao.Name = "lblTitleXinChao";
            this.lblTitleXinChao.Size = new System.Drawing.Size(71, 16);
            this.lblTitleXinChao.TabIndex = 1;
            this.lblTitleXinChao.Text = "Xin chào: ";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Location = new System.Drawing.Point(1099, 18);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(19, 16);
            this.lblTenNV.TabIndex = 4;
            this.lblTenNV.Text = "--";
            // 
            // btnOpenNavBar
            // 
            this.btnOpenNavBar.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenNavBar.FlatAppearance.BorderSize = 0;
            this.btnOpenNavBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnOpenNavBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOpenNavBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenNavBar.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenNavBar.Image")));
            this.btnOpenNavBar.Location = new System.Drawing.Point(5, 14);
            this.btnOpenNavBar.Name = "btnOpenNavBar";
            this.btnOpenNavBar.Size = new System.Drawing.Size(33, 25);
            this.btnOpenNavBar.TabIndex = 7;
            this.btnOpenNavBar.UseVisualStyleBackColor = false;
            this.btnOpenNavBar.Click += new System.EventHandler(this.btnOpenNavBar_Click);
            // 
            // btnAIChatbot
            // 
            this.btnAIChatbot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAIChatbot.BackColor = System.Drawing.Color.Transparent;
            this.btnAIChatbot.FlatAppearance.BorderSize = 0;
            this.btnAIChatbot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(180)))), ((int)(((byte)(243)))));
            this.btnAIChatbot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.btnAIChatbot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIChatbot.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIChatbot.Image = ((System.Drawing.Image)(resources.GetObject("btnAIChatbot.Image")));
            this.btnAIChatbot.Location = new System.Drawing.Point(1337, 7);
            this.btnAIChatbot.Name = "btnAIChatbot";
            this.btnAIChatbot.Size = new System.Drawing.Size(131, 38);
            this.btnAIChatbot.TabIndex = 8;
            this.btnAIChatbot.Text = "Trợ lý AI";
            this.btnAIChatbot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAIChatbot.UseVisualStyleBackColor = false;
            this.btnAIChatbot.Click += new System.EventHandler(this.btnAIChatbot_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(75)))), ((int)(((byte)(95)))));
            this.lblClock.Location = new System.Drawing.Point(184, 16);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(26, 22);
            this.lblClock.TabIndex = 9;
            this.lblClock.Text = "--";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeather.Location = new System.Drawing.Point(446, 16);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(26, 22);
            this.lblWeather.TabIndex = 10;
            this.lblWeather.Text = "--";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(147, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 34);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(407, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 34);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.Location = new System.Drawing.Point(993, 11);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(30, 30);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 13;
            this.picUser.TabStop = false;
            // 
            // plInfo
            // 
            this.plInfo.BackColor = System.Drawing.Color.White;
            this.plInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plInfo.Controls.Add(this.lblDate);
            this.plInfo.Controls.Add(this.lblChucVu);
            this.plInfo.Controls.Add(this.picUser);
            this.plInfo.Controls.Add(this.pictureBox2);
            this.plInfo.Controls.Add(this.pictureBox3);
            this.plInfo.Controls.Add(this.lblWeather);
            this.plInfo.Controls.Add(this.lblClock);
            this.plInfo.Controls.Add(this.btnAIChatbot);
            this.plInfo.Controls.Add(this.btnOpenNavBar);
            this.plInfo.Controls.Add(this.lblTenNV);
            this.plInfo.Controls.Add(this.lblTitleXinChao);
            this.plInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInfo.Location = new System.Drawing.Point(0, 0);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(1482, 53);
            this.plInfo.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Gray;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(274, 11);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(4);
            this.lblDate.Size = new System.Drawing.Size(34, 30);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "--";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.BackColor = System.Drawing.Color.Gray;
            this.lblChucVu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucVu.ForeColor = System.Drawing.Color.White;
            this.lblChucVu.Location = new System.Drawing.Point(721, 8);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Padding = new System.Windows.Forms.Padding(8);
            this.lblChucVu.Size = new System.Drawing.Size(40, 37);
            this.lblChucVu.TabIndex = 14;
            this.lblChucVu.Text = "--";
            // 
            // frmMainUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.plControls);
            this.Controls.Add(this.plNavBar);
            this.Controls.Add(this.plInfo);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MNNavBar;
            this.Name = "frmMainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao diện quản lý";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainUI_FormClosed);
            this.Load += new System.EventHandler(this.frmMainUI_Load);
            this.MNNavBar.ResumeLayout(false);
            this.MNNavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.plNavBar.ResumeLayout(false);
            this.plNavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.MenuStrip MNNavBar;
        private System.Windows.Forms.ToolStripMenuItem MNHome;
        private System.Windows.Forms.ToolStripMenuItem MNMore;
        private System.Windows.Forms.ToolStripMenuItem MNRoom;
        private System.Windows.Forms.ToolStripMenuItem MNMenuOrder;
        private System.Windows.Forms.ToolStripMenuItem MNBill;
        private System.Windows.Forms.ToolStripMenuItem MNStaffs;
        private System.Windows.Forms.ToolStripMenuItem MNCustomers;
        private System.Windows.Forms.ToolStripMenuItem MNStorage;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel plNavBar;
        private System.Windows.Forms.ToolStripMenuItem MNChart;
        private System.Windows.Forms.ToolStripMenuItem MNMore_Products;
        private System.Windows.Forms.ToolStripMenuItem MNMore_Voucher;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerWeather;
        private System.Windows.Forms.ToolStripMenuItem MNMore_Account;
        private System.Windows.Forms.ToolStripMenuItem MNKiemKe;
        public System.Windows.Forms.Timer timerSoundEffect;
        private System.Windows.Forms.Panel plControls;
        private System.Windows.Forms.Label lblTitleXinChao;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Button btnOpenNavBar;
        private System.Windows.Forms.Button btnAIChatbot;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ToolStripMenuItem MNMore_NhapKho;
        private System.Windows.Forms.ToolStripMenuItem MNMore_History;
    }
}