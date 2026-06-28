namespace E_Menu
{
    partial class frmEMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMenu));
            this.flowLayoutDSSanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnCombo = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnDrink = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoKho = new System.Windows.Forms.Button();
            this.btnSnack = new System.Windows.Forms.Button();
            this.btnHoaQua = new System.Windows.Forms.Button();
            this.btnRuou = new System.Windows.Forms.Button();
            this.btnNuocNgot = new System.Windows.Forms.Button();
            this.btnNuocKhoang = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitlePhong = new System.Windows.Forms.Label();
            this.btnOrdered = new System.Windows.Forms.Button();
            this.btnAIChatbot = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.flplOrdered = new System.Windows.Forms.FlowLayoutPanel();
            this.plAIChatbot = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.rtxtChatHistory = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.plAIChatbot.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutDSSanPham
            // 
            this.flowLayoutDSSanPham.AutoScroll = true;
            this.flowLayoutDSSanPham.AutoScrollMinSize = new System.Drawing.Size(0, 650);
            this.flowLayoutDSSanPham.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutDSSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutDSSanPham.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutDSSanPham.Location = new System.Drawing.Point(602, 0);
            this.flowLayoutDSSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutDSSanPham.Name = "flowLayoutDSSanPham";
            this.flowLayoutDSSanPham.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutDSSanPham.Size = new System.Drawing.Size(540, 733);
            this.flowLayoutDSSanPham.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(3, 51);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(220, 70);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnCombo
            // 
            this.btnCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnCombo.FlatAppearance.BorderSize = 0;
            this.btnCombo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCombo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCombo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCombo.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCombo.ForeColor = System.Drawing.Color.White;
            this.btnCombo.Location = new System.Drawing.Point(3, 646);
            this.btnCombo.Name = "btnCombo";
            this.btnCombo.Size = new System.Drawing.Size(220, 70);
            this.btnCombo.TabIndex = 4;
            this.btnCombo.Text = "Combo";
            this.btnCombo.UseVisualStyleBackColor = false;
            this.btnCombo.Click += new System.EventHandler(this.btnCombo_Click);
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnOther.FlatAppearance.BorderSize = 0;
            this.btnOther.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOther.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOther.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOther.ForeColor = System.Drawing.Color.White;
            this.btnOther.Location = new System.Drawing.Point(3, 570);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(220, 70);
            this.btnOther.TabIndex = 3;
            this.btnOther.Text = "Khác";
            this.btnOther.UseVisualStyleBackColor = false;
            this.btnOther.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnDrink
            // 
            this.btnDrink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDrink.FlatAppearance.BorderSize = 0;
            this.btnDrink.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDrink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDrink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrink.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrink.ForeColor = System.Drawing.Color.White;
            this.btnDrink.Location = new System.Drawing.Point(3, 347);
            this.btnDrink.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnDrink.Name = "btnDrink";
            this.btnDrink.Size = new System.Drawing.Size(220, 70);
            this.btnDrink.TabIndex = 2;
            this.btnDrink.Text = "Đồ uống ▶";
            this.btnDrink.UseVisualStyleBackColor = false;
            this.btnDrink.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnFood
            // 
            this.btnFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnFood.FlatAppearance.BorderSize = 0;
            this.btnFood.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnFood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFood.ForeColor = System.Drawing.Color.White;
            this.btnFood.Location = new System.Drawing.Point(3, 124);
            this.btnFood.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(220, 70);
            this.btnFood.TabIndex = 1;
            this.btnFood.Text = "Đồ ăn ▶️";
            this.btnFood.UseVisualStyleBackColor = false;
            this.btnFood.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(0, 400);
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.btnAll);
            this.flowLayoutPanel1.Controls.Add(this.btnFood);
            this.flowLayoutPanel1.Controls.Add(this.btnDoKho);
            this.flowLayoutPanel1.Controls.Add(this.btnSnack);
            this.flowLayoutPanel1.Controls.Add(this.btnHoaQua);
            this.flowLayoutPanel1.Controls.Add(this.btnDrink);
            this.flowLayoutPanel1.Controls.Add(this.btnRuou);
            this.flowLayoutPanel1.Controls.Add(this.btnNuocNgot);
            this.flowLayoutPanel1.Controls.Add(this.btnNuocKhoang);
            this.flowLayoutPanel1.Controls.Add(this.btnOther);
            this.flowLayoutPanel1.Controls.Add(this.btnCombo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(264, 491);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.MinimumSize = new System.Drawing.Size(230, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh mục";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDoKho
            // 
            this.btnDoKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnDoKho.FlatAppearance.BorderSize = 0;
            this.btnDoKho.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDoKho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDoKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDoKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoKho.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoKho.ForeColor = System.Drawing.Color.White;
            this.btnDoKho.Location = new System.Drawing.Point(3, 194);
            this.btnDoKho.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDoKho.Name = "btnDoKho";
            this.btnDoKho.Size = new System.Drawing.Size(180, 50);
            this.btnDoKho.TabIndex = 7;
            this.btnDoKho.Text = "Đồ khô";
            this.btnDoKho.UseVisualStyleBackColor = false;
            this.btnDoKho.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnSnack
            // 
            this.btnSnack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnSnack.FlatAppearance.BorderSize = 0;
            this.btnSnack.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSnack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSnack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSnack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnack.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnack.ForeColor = System.Drawing.Color.White;
            this.btnSnack.Location = new System.Drawing.Point(3, 244);
            this.btnSnack.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSnack.Name = "btnSnack";
            this.btnSnack.Size = new System.Drawing.Size(180, 50);
            this.btnSnack.TabIndex = 6;
            this.btnSnack.Text = "Snack";
            this.btnSnack.UseVisualStyleBackColor = false;
            this.btnSnack.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnHoaQua
            // 
            this.btnHoaQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnHoaQua.FlatAppearance.BorderSize = 0;
            this.btnHoaQua.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnHoaQua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHoaQua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHoaQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaQua.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaQua.ForeColor = System.Drawing.Color.White;
            this.btnHoaQua.Location = new System.Drawing.Point(3, 294);
            this.btnHoaQua.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnHoaQua.Name = "btnHoaQua";
            this.btnHoaQua.Size = new System.Drawing.Size(180, 50);
            this.btnHoaQua.TabIndex = 8;
            this.btnHoaQua.Text = "Hoa quả";
            this.btnHoaQua.UseVisualStyleBackColor = false;
            this.btnHoaQua.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnRuou
            // 
            this.btnRuou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnRuou.FlatAppearance.BorderSize = 0;
            this.btnRuou.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRuou.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRuou.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnRuou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuou.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRuou.ForeColor = System.Drawing.Color.White;
            this.btnRuou.Location = new System.Drawing.Point(3, 417);
            this.btnRuou.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRuou.Name = "btnRuou";
            this.btnRuou.Size = new System.Drawing.Size(180, 50);
            this.btnRuou.TabIndex = 10;
            this.btnRuou.Text = "Rượu/Bia";
            this.btnRuou.UseVisualStyleBackColor = false;
            this.btnRuou.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnNuocNgot
            // 
            this.btnNuocNgot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnNuocNgot.FlatAppearance.BorderSize = 0;
            this.btnNuocNgot.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNuocNgot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnNuocNgot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnNuocNgot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuocNgot.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuocNgot.ForeColor = System.Drawing.Color.White;
            this.btnNuocNgot.Location = new System.Drawing.Point(3, 467);
            this.btnNuocNgot.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnNuocNgot.Name = "btnNuocNgot";
            this.btnNuocNgot.Size = new System.Drawing.Size(180, 50);
            this.btnNuocNgot.TabIndex = 9;
            this.btnNuocNgot.Text = "Nước ngọt";
            this.btnNuocNgot.UseVisualStyleBackColor = false;
            this.btnNuocNgot.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // btnNuocKhoang
            // 
            this.btnNuocKhoang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnNuocKhoang.FlatAppearance.BorderSize = 0;
            this.btnNuocKhoang.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNuocKhoang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnNuocKhoang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnNuocKhoang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuocKhoang.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuocKhoang.ForeColor = System.Drawing.Color.White;
            this.btnNuocKhoang.Location = new System.Drawing.Point(3, 517);
            this.btnNuocKhoang.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnNuocKhoang.Name = "btnNuocKhoang";
            this.btnNuocKhoang.Size = new System.Drawing.Size(180, 50);
            this.btnNuocKhoang.TabIndex = 11;
            this.btnNuocKhoang.Text = "Nước khoáng";
            this.btnNuocKhoang.UseVisualStyleBackColor = false;
            this.btnNuocKhoang.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.lblTitlePhong);
            this.flowLayoutPanel2.Controls.Add(this.btnOrdered);
            this.flowLayoutPanel2.Controls.Add(this.btnAIChatbot);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(360, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(242, 733);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lblTitlePhong
            // 
            this.lblTitlePhong.AutoSize = true;
            this.lblTitlePhong.BackColor = System.Drawing.Color.Transparent;
            this.lblTitlePhong.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitlePhong.Location = new System.Drawing.Point(3, 497);
            this.lblTitlePhong.MinimumSize = new System.Drawing.Size(240, 0);
            this.lblTitlePhong.Name = "lblTitlePhong";
            this.lblTitlePhong.Size = new System.Drawing.Size(240, 45);
            this.lblTitlePhong.TabIndex = 12;
            this.lblTitlePhong.Text = "Phòng";
            this.lblTitlePhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrdered
            // 
            this.btnOrdered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(195)))), ((int)(((byte)(165)))));
            this.btnOrdered.FlatAppearance.BorderSize = 0;
            this.btnOrdered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdered.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdered.ForeColor = System.Drawing.Color.White;
            this.btnOrdered.Location = new System.Drawing.Point(3, 592);
            this.btnOrdered.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btnOrdered.Name = "btnOrdered";
            this.btnOrdered.Size = new System.Drawing.Size(236, 58);
            this.btnOrdered.TabIndex = 14;
            this.btnOrdered.Text = "Đã Order";
            this.btnOrdered.UseVisualStyleBackColor = false;
            this.btnOrdered.Click += new System.EventHandler(this.btnOrdered_Click);
            // 
            // btnAIChatbot
            // 
            this.btnAIChatbot.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAIChatbot.BackColor = System.Drawing.Color.Transparent;
            this.btnAIChatbot.FlatAppearance.BorderSize = 0;
            this.btnAIChatbot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(180)))), ((int)(((byte)(243)))));
            this.btnAIChatbot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(237)))), ((int)(((byte)(253)))));
            this.btnAIChatbot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIChatbot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIChatbot.Image = ((System.Drawing.Image)(resources.GetObject("btnAIChatbot.Image")));
            this.btnAIChatbot.Location = new System.Drawing.Point(3, 673);
            this.btnAIChatbot.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnAIChatbot.Name = "btnAIChatbot";
            this.btnAIChatbot.Size = new System.Drawing.Size(236, 50);
            this.btnAIChatbot.TabIndex = 13;
            this.btnAIChatbot.Text = " AI - Trợ lý tư vấn";
            this.btnAIChatbot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAIChatbot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAIChatbot.UseVisualStyleBackColor = false;
            this.btnAIChatbot.Click += new System.EventHandler(this.btnAIChatbot_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 10000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // flplOrdered
            // 
            this.flplOrdered.BackColor = System.Drawing.Color.SeaShell;
            this.flplOrdered.Dock = System.Windows.Forms.DockStyle.Right;
            this.flplOrdered.Location = new System.Drawing.Point(1142, 0);
            this.flplOrdered.Name = "flplOrdered";
            this.flplOrdered.Size = new System.Drawing.Size(340, 733);
            this.flplOrdered.TabIndex = 0;
            this.flplOrdered.Visible = false;
            // 
            // plAIChatbot
            // 
            this.plAIChatbot.Controls.Add(this.label2);
            this.plAIChatbot.Controls.Add(this.panel2);
            this.plAIChatbot.Controls.Add(this.btnSendRequest);
            this.plAIChatbot.Controls.Add(this.txtRequest);
            this.plAIChatbot.Controls.Add(this.rtxtChatHistory);
            this.plAIChatbot.Dock = System.Windows.Forms.DockStyle.Left;
            this.plAIChatbot.Location = new System.Drawing.Point(0, 0);
            this.plAIChatbot.Name = "plAIChatbot";
            this.plAIChatbot.Size = new System.Drawing.Size(360, 733);
            this.plAIChatbot.TabIndex = 1;
            this.plAIChatbot.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.MinimumSize = new System.Drawing.Size(230, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hỏi đáp cùng AI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 563);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 115);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(142, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendRequest.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendRequest.Location = new System.Drawing.Point(269, 684);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(88, 40);
            this.btnSendRequest.TabIndex = 2;
            this.btnSendRequest.Text = "Gửi";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequest.Location = new System.Drawing.Point(3, 684);
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(260, 40);
            this.txtRequest.TabIndex = 1;
            // 
            // rtxtChatHistory
            // 
            this.rtxtChatHistory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtChatHistory.Location = new System.Drawing.Point(3, 70);
            this.rtxtChatHistory.Name = "rtxtChatHistory";
            this.rtxtChatHistory.ReadOnly = true;
            this.rtxtChatHistory.Size = new System.Drawing.Size(354, 486);
            this.rtxtChatHistory.TabIndex = 0;
            this.rtxtChatHistory.Text = "";
            // 
            // frmEMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 700);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(247)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1482, 733);
            this.Controls.Add(this.flowLayoutDSSanPham);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flplOrdered);
            this.Controls.Add(this.plAIChatbot);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.plAIChatbot.ResumeLayout(false);
            this.plAIChatbot.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutDSSanPham;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnCombo;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Button btnDrink;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSnack;
        private System.Windows.Forms.Button btnDoKho;
        private System.Windows.Forms.Button btnHoaQua;
        private System.Windows.Forms.Button btnRuou;
        private System.Windows.Forms.Button btnNuocNgot;
        private System.Windows.Forms.Button btnNuocKhoang;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTitlePhong;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button btnAIChatbot;
        private System.Windows.Forms.Button btnOrdered;
        private System.Windows.Forms.FlowLayoutPanel flplOrdered;
        private System.Windows.Forms.Panel plAIChatbot;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.RichTextBox rtxtChatHistory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}