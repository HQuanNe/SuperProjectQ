using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SuperProjectQ.AllForm.Other
{
    public partial class frmBieuDoDoanhThu : Form
    {
        public frmBieuDoDoanhThu()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt = null;

        Session.FontStandard fontS = new Session.FontStandard();
        private void BieuDo_Load()
        {
            decimal totalDoanhThu = 0;
            string title = "năm 2026", isQuarter = "NgayLap", note = "Ngày";
            int date = dtKhoangThoiGian.Value.Year;

            string sqlDoanhThu = sqlDoanhThu = $"SELECT CAST(GioRa AS DATE) AS {isQuarter}, SUM(TongThanhToan - VAT) AS DoanhThu " +
                            $"FROM HoaDon WHERE GioRa IS NOT NULL AND YEAR(CAST(GioRa AS DATE)) = {date}" +
                            $"GROUP BY CAST(GioRa AS DATE) ORDER BY {isQuarter} ASC";
            ;
            if (radBtnQuy.Checked)
            {

                if (cmbQuy.SelectedIndex == -1 || cmbQuy.SelectedItem == null) return;
                date = dtKhoangThoiGian.Value.Day;
                title = $"{cmbQuy.SelectedItem.ToString()}/{cmbYear.SelectedValue}";

                isQuarter = "Quy";
                note = "Quý";

                sqlDoanhThu = $"SELECT DATEPART(QUARTER, CAST(GioRa AS DATE)) AS {isQuarter}, SUM(TongThanhToan - VAT) AS DoanhThu " +
                    $"FROM HoaDon WHERE GioRa IS NOT NULL AND DATEPART(QUARTER, CAST(GioRa AS DATE)) = {cmbQuy.SelectedItem.ToString().Replace("Quý ", "")} " +
                    $"AND YEAR(CAST (GioRa AS DATE)) = {cmbYear.SelectedValue}" +
                    $"GROUP BY DATEPART(QUARTER, CAST(GioRa AS DATE)), YEAR(CAST (GioRa AS DATE)) " +
                    $"ORDER BY {isQuarter} ASC";
            }
            if(radBtnMONTH.Checked || radBtnYEAR.Checked)
            {
                if (radBtnMONTH.Checked)
                {
                    date = dtKhoangThoiGian.Value.Month;
                    title = $"tháng {date}/{dtKhoangThoiGian.Value.Year}";

                    sqlDoanhThu = $"SELECT CAST(GioRa AS DATE) AS {isQuarter}, SUM(TongThanhToan - VAT) AS DoanhThu " +
                            $"FROM HoaDon WHERE GioRa IS NOT NULL AND MONTH(CAST(GioRa AS DATE)) = {date} " +
                            $"AND MONTH(CAST(GioRa AS DATE)) = {date} " +
                            $"AND YEAR(CAST(GioRa AS DATE)) = {dtKhoangThoiGian.Value.Year}" +
                            $"GROUP BY CAST(GioRa AS DATE) ORDER BY {isQuarter} ASC";

                }
                else if (radBtnYEAR.Checked)
                {
                    date = dtKhoangThoiGian.Value.Year;
                    title = $"năm {date}";

                    sqlDoanhThu = $"SELECT CAST(GioRa AS DATE) AS {isQuarter}, SUM(TongThanhToan - VAT) AS DoanhThu " +
                            $"FROM HoaDon WHERE GioRa IS NOT NULL AND YEAR(CAST(GioRa AS DATE)) = {date}" +
                            $"GROUP BY CAST(GioRa AS DATE) ORDER BY {isQuarter} ASC";

                }
                isQuarter = "NgayLap";
            }

            dt = new DataTable();
            dt = kn.CreateTable(sqlDoanhThu);
            foreach (DataRow dr in dt.Rows)
            {
                totalDoanhThu += Convert.ToDecimal(dr["DoanhThu"]);
            }

            //Xóa các dữ liệu cũ trên biểu đồ để làm sạch
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();
            chartDoanhThu.ChartAreas.Add(new ChartArea("MainArea"));

            Series series = new Series("Doanh Thu");
            series.XValueMember = $"{isQuarter}";    // Trục X (ngang) là Ngày
            series.YValueMembers = "DoanhThu"; // Trục Y (dọc) là Tiền

            series.IsValueShownAsLabel = true;
            series.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            series.LabelForeColor = Color.DarkBlue;
            series.LabelFormat = "N0"; // Dùng định dạng kiểu 1,000

            //Đổ DataTable vào datasource Chart
            chartDoanhThu.DataSource = dt;
            chartDoanhThu.Series.Add(series);
            //chartDoanhThu.ChartAreas["MainArea"].Area3DStyle.Enable3D = true;

            //Chú thích trục X và Y
            chartDoanhThu.ChartAreas["MainArea"].AxisX.Title = $"{note}";
            chartDoanhThu.ChartAreas["MainArea"].AxisY.Title = "Số tiền (VNĐ)";

            lblTotal.Text = "Tổng doanh thu: " + totalDoanhThu.ToString("#,##0") + "đ";//Tổng doanh thu

            chartDoanhThu.Titles["TitleTenBieuDo"].Text = $"Biểu đồ doanh thu {title}";
        }
        private void SanPhamBanChay_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable("SELECT ct.MaSP, COALESCE(Sanpham.TenMatHang, Combo.TenCombo) AS TenMatHang, " +
                "SUM(ct.SoLuong) AS TongSPDaBan, ct.DonViTinh " +
                "FROM ChiTietHD ct " +
                "LEFT JOIN SanPham ON SanPham.MaSP_Menu = ct.MaSP AND ct.LoaiHang = 0 " +
                "LEFT JOIN Combo ON Combo.MaCombo = ct.MaSP AND ct.LoaiHang = 1 " +
                "GROUP BY ct.MaSP, COALESCE(Sanpham.TenMatHang, Combo.TenCombo) , ct.DonViTinh " +
                "ORDER BY TongSPDaBan ASC");

            //Xóa các dữ liệu cũ trên biểu đồ để làm sạch
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();
            chartDoanhThu.ChartAreas.Add(new ChartArea("PopularProducts"));

            Legend legend = new Legend();
            legend.Font = fontS.tahoma9_Bold;

            Series series = new Series("Sản phẩm bán chạy");

            if (dt.Rows.Count < 1 || dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(row["TenMatHang"], row["TongSPDaBan"]);
            }

            series.IsValueShownAsLabel = true;
            series.Font = fontS.tahoma12_Bold;
            series.LabelForeColor = Color.FromArgb(255, 178, 205);
            series.LabelFormat = "N0"; // Dùng định dạng kiểu 1,000

            //Đổ DataTable vào datasource Chart
            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Legends.Clear();
            chartDoanhThu.Legends.Add(legend);
            chartDoanhThu.Series["Sản phẩm bán chạy"].ChartType = SeriesChartType.Pie;

            chartDoanhThu.Titles["TitleTenBieuDo"].Text = $"Biểu đồ sản phẩm bán chạy";
        }
        private void cmbQuy_LoadData() 
        { 
            cmbQuy.Items.Add("Quý 1");
            cmbQuy.Items.Add("Quý 2");
            cmbQuy.Items.Add("Quý 3");
            cmbQuy.Items.Add("Quý 4");
        }
        private void cmbYear_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable("SELECT DISTINCT YEAR(GioRa) AS Nam FROM HoaDon WHERE GioRa IS NOT NULL ORDER BY Nam ASC");
            cmbYear.DataSource = dt;
            cmbYear.DisplayMember = "Nam";
            cmbYear.ValueMember = "Nam";
        }
        private void frmBieuDoDoanhThu_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            BieuDo_Load();

            cmbQuy_LoadData();
            cmbYear_Load();

            cmbQuy.Visible = false;
            cmbYear.Visible = false;

        }

        private void radBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnQuy.Checked)
            {
                radBtnMONTH.Checked = false;
                radBtnYEAR.Checked = false;

                cmbQuy.Visible = true;
                cmbYear.Visible = true;
                dtKhoangThoiGian.Visible = false;
            }
            else if (radBtnMONTH.Checked)
            {
                radBtnQuy.Checked = false;
                radBtnYEAR.Checked = false;
                cmbQuy.Visible = false;
                cmbYear.Visible = false;
                dtKhoangThoiGian.Visible = true;
            }
            else if (radBtnYEAR.Checked)
            {
                radBtnQuy.Checked = false;
                radBtnMONTH.Checked = false;
                cmbQuy.Visible = false;
                cmbYear.Visible = false;
                dtKhoangThoiGian.Visible = true;
            }
        }

        private void btnLoadBieuDo_Click(object sender, EventArgs e)
        {
            if(!radBtnQuy.Checked && !radBtnMONTH.Checked && !radBtnYEAR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại hiển thị doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BieuDo_Load();
        }

        private void btnPopularProd_Click(object sender, EventArgs e)
        {
            SanPhamBanChay_Load();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
