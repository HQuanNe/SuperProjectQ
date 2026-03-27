namespace SuperProjectQ.AllForm.Room
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
            this.plControl = new System.Windows.Forms.Panel();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBookingRoom = new System.Windows.Forms.Label();
            this.lblActiveRoom = new System.Windows.Forms.Label();
            this.lblEmptyRoom = new System.Windows.Forms.Label();
            this.flpRoom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnListRoom = new System.Windows.Forms.Button();
            this.plControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plControl
            // 
            this.plControl.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plControl.Controls.Add(this.btnListRoom);
            this.plControl.Controls.Add(this.btnThemPhong);
            this.plControl.Controls.Add(this.groupBox1);
            this.plControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.plControl.Location = new System.Drawing.Point(30, 0);
            this.plControl.Name = "plControl";
            this.plControl.Size = new System.Drawing.Size(1422, 80);
            this.plControl.TabIndex = 20;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemPhong.BackColor = System.Drawing.Color.Lime;
            this.btnThemPhong.FlatAppearance.BorderSize = 0;
            this.btnThemPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemPhong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPhong.ForeColor = System.Drawing.Color.White;
            this.btnThemPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPhong.Image")));
            this.btnThemPhong.Location = new System.Drawing.Point(1199, 15);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(201, 50);
            this.btnThemPhong.TabIndex = 1;
            this.btnThemPhong.Text = "Thêm phòng";
            this.btnThemPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemPhong.UseVisualStyleBackColor = false;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBookingRoom);
            this.groupBox1.Controls.Add(this.lblActiveRoom);
            this.groupBox1.Controls.Add(this.lblEmptyRoom);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // lblBookingRoom
            // 
            this.lblBookingRoom.AutoSize = true;
            this.lblBookingRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.lblBookingRoom.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingRoom.ForeColor = System.Drawing.Color.White;
            this.lblBookingRoom.Location = new System.Drawing.Point(420, 22);
            this.lblBookingRoom.Name = "lblBookingRoom";
            this.lblBookingRoom.Padding = new System.Windows.Forms.Padding(10);
            this.lblBookingRoom.Size = new System.Drawing.Size(158, 36);
            this.lblBookingRoom.TabIndex = 26;
            this.lblBookingRoom.Text = "phòng đã đặt trước:";
            // 
            // lblActiveRoom
            // 
            this.lblActiveRoom.AutoSize = true;
            this.lblActiveRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblActiveRoom.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveRoom.ForeColor = System.Drawing.Color.White;
            this.lblActiveRoom.Location = new System.Drawing.Point(183, 22);
            this.lblActiveRoom.Name = "lblActiveRoom";
            this.lblActiveRoom.Padding = new System.Windows.Forms.Padding(10);
            this.lblActiveRoom.Size = new System.Drawing.Size(176, 36);
            this.lblActiveRoom.TabIndex = 25;
            this.lblActiveRoom.Text = "phòng đang vận hành: ";
            // 
            // lblEmptyRoom
            // 
            this.lblEmptyRoom.AutoSize = true;
            this.lblEmptyRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.lblEmptyRoom.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmptyRoom.ForeColor = System.Drawing.Color.White;
            this.lblEmptyRoom.Location = new System.Drawing.Point(6, 22);
            this.lblEmptyRoom.Name = "lblEmptyRoom";
            this.lblEmptyRoom.Padding = new System.Windows.Forms.Padding(10);
            this.lblEmptyRoom.Size = new System.Drawing.Size(116, 36);
            this.lblEmptyRoom.TabIndex = 0;
            this.lblEmptyRoom.Text = "phòng trống: ";
            // 
            // flpRoom
            // 
            this.flpRoom.AutoScroll = true;
            this.flpRoom.AutoScrollMinSize = new System.Drawing.Size(0, 600);
            this.flpRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.flpRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRoom.Location = new System.Drawing.Point(30, 80);
            this.flpRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpRoom.Name = "flpRoom";
            this.flpRoom.Padding = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.flpRoom.Size = new System.Drawing.Size(1422, 640);
            this.flpRoom.TabIndex = 8;
            this.flpRoom.SizeChanged += new System.EventHandler(this.flpRoom_SizeChanged);
            // 
            // btnListRoom
            // 
            this.btnListRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListRoom.BackColor = System.Drawing.Color.Turquoise;
            this.btnListRoom.FlatAppearance.BorderSize = 0;
            this.btnListRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListRoom.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListRoom.ForeColor = System.Drawing.Color.White;
            this.btnListRoom.Location = new System.Drawing.Point(992, 15);
            this.btnListRoom.Name = "btnListRoom";
            this.btnListRoom.Size = new System.Drawing.Size(201, 50);
            this.btnListRoom.TabIndex = 2;
            this.btnListRoom.Text = "Danh sách phòng";
            this.btnListRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListRoom.UseVisualStyleBackColor = false;
            this.btnListRoom.Click += new System.EventHandler(this.btnListRoom_Click);
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1482, 720);
            this.Controls.Add(this.flpRoom);
            this.Controls.Add(this.plControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPhong";
            this.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng";
            this.Load += new System.EventHandler(this.frmPhong_Load);
            this.plControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel plControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEmptyRoom;
        private System.Windows.Forms.Label lblBookingRoom;
        private System.Windows.Forms.Label lblActiveRoom;
        private System.Windows.Forms.FlowLayoutPanel flpRoom;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnListRoom;
    }
}