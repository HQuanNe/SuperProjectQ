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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.plControl = new System.Windows.Forms.Panel();
            this.btnHuyDatTruoc = new System.Windows.Forms.Button();
            this.btnOrdered = new System.Windows.Forms.Button();
            this.btnDatTruoc = new System.Windows.Forms.Button();
            this.btnOpenMenu = new System.Windows.Forms.Button();
            this.plPhong = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutOrdered = new System.Windows.Forms.FlowLayoutPanel();
            this.plOrdered = new System.Windows.Forms.Panel();
            this.tabCtrlRoom.SuspendLayout();
            this.tabPageNormal.SuspendLayout();
            this.tabPageVIP.SuspendLayout();
            this.plControl.SuspendLayout();
            this.plPhong.SuspendLayout();
            this.plOrdered.SuspendLayout();
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
            this.flowLayoutRegular.Size = new System.Drawing.Size(973, 588);
            this.flowLayoutRegular.TabIndex = 8;
            // 
            // tabCtrlRoom
            // 
            this.tabCtrlRoom.Controls.Add(this.tabPageNormal);
            this.tabCtrlRoom.Controls.Add(this.tabPageVIP);
            this.tabCtrlRoom.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlRoom.Location = new System.Drawing.Point(3, 47);
            this.tabCtrlRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCtrlRoom.Name = "tabCtrlRoom";
            this.tabCtrlRoom.SelectedIndex = 0;
            this.tabCtrlRoom.Size = new System.Drawing.Size(992, 630);
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
            this.tabPageNormal.Size = new System.Drawing.Size(984, 598);
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
            this.tabPageVIP.Size = new System.Drawing.Size(984, 598);
            this.tabPageVIP.TabIndex = 1;
            this.tabPageVIP.Text = "Phòng VIP";
            // 
            // flowLayoutVIP
            // 
            this.flowLayoutVIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutVIP.Location = new System.Drawing.Point(5, 6);
            this.flowLayoutVIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutVIP.Name = "flowLayoutVIP";
            this.flowLayoutVIP.Size = new System.Drawing.Size(973, 588);
            this.flowLayoutVIP.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(609, 8);
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
            this.label1.Location = new System.Drawing.Point(406, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "Đang chọn: ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Location = new System.Drawing.Point(4, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(300, 96);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng phòng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.White;
            this.btnOrder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(1356, 15);
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
            this.btnOpen.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnOpen.Location = new System.Drawing.Point(4, 2);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(300, 96);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Mở phòng";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // plControl
            // 
            this.plControl.Controls.Add(this.btnHuyDatTruoc);
            this.plControl.Controls.Add(this.btnOrdered);
            this.plControl.Controls.Add(this.btnDatTruoc);
            this.plControl.Controls.Add(this.btnOpen);
            this.plControl.Controls.Add(this.btnOpenMenu);
            this.plControl.Controls.Add(this.btnOrder);
            this.plControl.Controls.Add(this.btnClose);
            this.plControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plControl.Location = new System.Drawing.Point(0, 703);
            this.plControl.Name = "plControl";
            this.plControl.Size = new System.Drawing.Size(1482, 100);
            this.plControl.TabIndex = 20;
            // 
            // btnHuyDatTruoc
            // 
            this.btnHuyDatTruoc.BackColor = System.Drawing.Color.Teal;
            this.btnHuyDatTruoc.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDatTruoc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnHuyDatTruoc.Location = new System.Drawing.Point(310, 2);
            this.btnHuyDatTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyDatTruoc.Name = "btnHuyDatTruoc";
            this.btnHuyDatTruoc.Size = new System.Drawing.Size(300, 96);
            this.btnHuyDatTruoc.TabIndex = 7;
            this.btnHuyDatTruoc.Text = "Huỷ đặt trước";
            this.btnHuyDatTruoc.UseVisualStyleBackColor = false;
            this.btnHuyDatTruoc.Click += new System.EventHandler(this.btnHuyDatTruoc_Click);
            // 
            // btnOrdered
            // 
            this.btnOrdered.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdered.Location = new System.Drawing.Point(897, 13);
            this.btnOrdered.Name = "btnOrdered";
            this.btnOrdered.Size = new System.Drawing.Size(153, 69);
            this.btnOrdered.TabIndex = 22;
            this.btnOrdered.Text = "Đã Order";
            this.btnOrdered.UseVisualStyleBackColor = true;
            this.btnOrdered.Click += new System.EventHandler(this.btnOrdered_Click);
            // 
            // btnDatTruoc
            // 
            this.btnDatTruoc.BackColor = System.Drawing.Color.Aqua;
            this.btnDatTruoc.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatTruoc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDatTruoc.Location = new System.Drawing.Point(310, 2);
            this.btnDatTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDatTruoc.Name = "btnDatTruoc";
            this.btnDatTruoc.Size = new System.Drawing.Size(300, 96);
            this.btnDatTruoc.TabIndex = 6;
            this.btnDatTruoc.Text = "Đặt trước";
            this.btnDatTruoc.UseVisualStyleBackColor = false;
            this.btnDatTruoc.Click += new System.EventHandler(this.btnDatTruoc_Click);
            // 
            // btnOpenMenu
            // 
            this.btnOpenMenu.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenMenu.Location = new System.Drawing.Point(716, 13);
            this.btnOpenMenu.Name = "btnOpenMenu";
            this.btnOpenMenu.Size = new System.Drawing.Size(153, 69);
            this.btnOpenMenu.TabIndex = 21;
            this.btnOpenMenu.Text = "Mở menu";
            this.btnOpenMenu.UseVisualStyleBackColor = true;
            this.btnOpenMenu.Click += new System.EventHandler(this.btnOpenMenu_Click);
            // 
            // plPhong
            // 
            this.plPhong.Controls.Add(this.label1);
            this.plPhong.Controls.Add(this.lblInfo);
            this.plPhong.Controls.Add(this.tabCtrlRoom);
            this.plPhong.Location = new System.Drawing.Point(17, 4);
            this.plPhong.Name = "plPhong";
            this.plPhong.Size = new System.Drawing.Size(1010, 692);
            this.plPhong.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.MinimumSize = new System.Drawing.Size(420, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(420, 80);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đã Order";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutOrdered
            // 
            this.flowLayoutOrdered.AutoScroll = true;
            this.flowLayoutOrdered.AutoScrollMinSize = new System.Drawing.Size(0, 1000);
            this.flowLayoutOrdered.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutOrdered.Location = new System.Drawing.Point(3, 85);
            this.flowLayoutOrdered.Name = "flowLayoutOrdered";
            this.flowLayoutOrdered.Size = new System.Drawing.Size(420, 703);
            this.flowLayoutOrdered.TabIndex = 25;
            // 
            // plOrdered
            // 
            this.plOrdered.Controls.Add(this.flowLayoutOrdered);
            this.plOrdered.Controls.Add(this.label5);
            this.plOrdered.Dock = System.Windows.Forms.DockStyle.Left;
            this.plOrdered.Location = new System.Drawing.Point(0, 0);
            this.plOrdered.Name = "plOrdered";
            this.plOrdered.Size = new System.Drawing.Size(420, 703);
            this.plOrdered.TabIndex = 26;
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1482, 803);
            this.Controls.Add(this.plOrdered);
            this.Controls.Add(this.plPhong);
            this.Controls.Add(this.plControl);
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
            this.plControl.ResumeLayout(false);
            this.plPhong.ResumeLayout(false);
            this.plPhong.PerformLayout();
            this.plOrdered.ResumeLayout(false);
            this.plOrdered.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutRegular;
        private System.Windows.Forms.TabControl tabCtrlRoom;
        private System.Windows.Forms.TabPage tabPageNormal;
        private System.Windows.Forms.TabPage tabPageVIP;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutVIP;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel plControl;
        private System.Windows.Forms.Button btnDatTruoc;
        private System.Windows.Forms.Button btnHuyDatTruoc;
        private System.Windows.Forms.Button btnOpenMenu;
        private System.Windows.Forms.Button btnOrdered;
        private System.Windows.Forms.Panel plPhong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOrdered;
        private System.Windows.Forms.Panel plOrdered;
    }
}