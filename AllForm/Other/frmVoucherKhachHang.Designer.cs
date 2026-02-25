namespace SuperProjectQ.AllForm.Other
{
    partial class frmVoucherKhachHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPNVoucher = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, -1);
            this.label1.MinimumSize = new System.Drawing.Size(140, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voucher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(535, 19);
            this.label2.MinimumSize = new System.Drawing.Size(120, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "--";
            // 
            // flowLayoutPNVoucher
            // 
            this.flowLayoutPNVoucher.AutoScroll = true;
            this.flowLayoutPNVoucher.AutoScrollMinSize = new System.Drawing.Size(0, 600);
            this.flowLayoutPNVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flowLayoutPNVoucher.Location = new System.Drawing.Point(12, 62);
            this.flowLayoutPNVoucher.Name = "flowLayoutPNVoucher";
            this.flowLayoutPNVoucher.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPNVoucher.Size = new System.Drawing.Size(778, 424);
            this.flowLayoutPNVoucher.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(663, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(127, 54);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Chọn";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 492);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 63);
            this.panel1.TabIndex = 4;
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPNVoucher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVoucher";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPNVoucher;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel1;
    }
}