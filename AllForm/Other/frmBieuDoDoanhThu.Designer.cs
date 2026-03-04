namespace SuperProjectQ.AllForm.Other
{
    partial class frmBieuDoDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPopularProd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbQuy = new System.Windows.Forms.ComboBox();
            this.dtKhoangThoiGian = new System.Windows.Forms.DateTimePicker();
            this.btnLoadBieuDo = new System.Windows.Forms.Button();
            this.radBtnQuy = new System.Windows.Forms.RadioButton();
            this.radBtnYEAR = new System.Windows.Forms.RadioButton();
            this.radBtnMONTH = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chartDoanhThu.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            this.chartDoanhThu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartDoanhThu.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.chartDoanhThu.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            this.chartDoanhThu.BorderSkin.BorderWidth = 0;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.PointDepth = 80;
            chartArea1.Area3DStyle.PointGapDepth = 80;
            chartArea1.Area3DStyle.Rotation = 20;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 8F);
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(12, 111);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(979, 600);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            title1.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "TitleTenBieuDo";
            title1.Text = "Bảng doanh thu";
            this.chartDoanhThu.Titles.Add(title1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPopularProd);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 105);
            this.panel1.TabIndex = 1;
            // 
            // btnPopularProd
            // 
            this.btnPopularProd.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopularProd.Location = new System.Drawing.Point(836, 27);
            this.btnPopularProd.Name = "btnPopularProd";
            this.btnPopularProd.Size = new System.Drawing.Size(155, 60);
            this.btnPopularProd.TabIndex = 4;
            this.btnPopularProd.Text = "Sản phẩm bán chạy";
            this.btnPopularProd.UseVisualStyleBackColor = true;
            this.btnPopularProd.Click += new System.EventHandler(this.btnPopularProd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.cmbQuy);
            this.groupBox1.Controls.Add(this.dtKhoangThoiGian);
            this.groupBox1.Controls.Add(this.btnLoadBieuDo);
            this.groupBox1.Controls.Add(this.radBtnQuy);
            this.groupBox1.Controls.Add(this.radBtnYEAR);
            this.groupBox1.Controls.Add(this.radBtnMONTH);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu theo";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(137, 51);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 30);
            this.cmbYear.TabIndex = 5;
            // 
            // cmbQuy
            // 
            this.cmbQuy.FormattingEnabled = true;
            this.cmbQuy.Location = new System.Drawing.Point(10, 51);
            this.cmbQuy.Name = "cmbQuy";
            this.cmbQuy.Size = new System.Drawing.Size(121, 30);
            this.cmbQuy.TabIndex = 4;
            // 
            // dtKhoangThoiGian
            // 
            this.dtKhoangThoiGian.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtKhoangThoiGian.Location = new System.Drawing.Point(10, 51);
            this.dtKhoangThoiGian.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtKhoangThoiGian.Name = "dtKhoangThoiGian";
            this.dtKhoangThoiGian.Size = new System.Drawing.Size(231, 30);
            this.dtKhoangThoiGian.TabIndex = 3;
            // 
            // btnLoadBieuDo
            // 
            this.btnLoadBieuDo.Location = new System.Drawing.Point(278, 24);
            this.btnLoadBieuDo.Name = "btnLoadBieuDo";
            this.btnLoadBieuDo.Size = new System.Drawing.Size(134, 60);
            this.btnLoadBieuDo.TabIndex = 1;
            this.btnLoadBieuDo.Text = "Xem";
            this.btnLoadBieuDo.UseVisualStyleBackColor = true;
            this.btnLoadBieuDo.Click += new System.EventHandler(this.btnLoadBieuDo_Click);
            // 
            // radBtnQuy
            // 
            this.radBtnQuy.AutoSize = true;
            this.radBtnQuy.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnQuy.Location = new System.Drawing.Point(9, 24);
            this.radBtnQuy.Name = "radBtnQuy";
            this.radBtnQuy.Size = new System.Drawing.Size(58, 23);
            this.radBtnQuy.TabIndex = 0;
            this.radBtnQuy.TabStop = true;
            this.radBtnQuy.Text = "Quý";
            this.radBtnQuy.UseVisualStyleBackColor = true;
            this.radBtnQuy.CheckedChanged += new System.EventHandler(this.radBtn_CheckedChanged);
            // 
            // radBtnYEAR
            // 
            this.radBtnYEAR.AutoSize = true;
            this.radBtnYEAR.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnYEAR.Location = new System.Drawing.Point(156, 24);
            this.radBtnYEAR.Name = "radBtnYEAR";
            this.radBtnYEAR.Size = new System.Drawing.Size(62, 23);
            this.radBtnYEAR.TabIndex = 2;
            this.radBtnYEAR.TabStop = true;
            this.radBtnYEAR.Text = "Năm";
            this.radBtnYEAR.UseVisualStyleBackColor = true;
            this.radBtnYEAR.CheckedChanged += new System.EventHandler(this.radBtn_CheckedChanged);
            // 
            // radBtnMONTH
            // 
            this.radBtnMONTH.AutoSize = true;
            this.radBtnMONTH.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnMONTH.Location = new System.Drawing.Point(80, 24);
            this.radBtnMONTH.Name = "radBtnMONTH";
            this.radBtnMONTH.Size = new System.Drawing.Size(70, 23);
            this.radBtnMONTH.TabIndex = 1;
            this.radBtnMONTH.TabStop = true;
            this.radBtnMONTH.Text = "Tháng";
            this.radBtnMONTH.UseVisualStyleBackColor = true;
            this.radBtnMONTH.CheckedChanged += new System.EventHandler(this.radBtn_CheckedChanged);
            // 
            // frmBieuDoDoanhThu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1003, 723);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartDoanhThu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBieuDoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biểu đồ";
            this.Load += new System.EventHandler(this.frmBieuDoDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadBieuDo;
        private System.Windows.Forms.RadioButton radBtnQuy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radBtnYEAR;
        private System.Windows.Forms.RadioButton radBtnMONTH;
        private System.Windows.Forms.DateTimePicker dtKhoangThoiGian;
        private System.Windows.Forms.ComboBox cmbQuy;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnPopularProd;
    }
}