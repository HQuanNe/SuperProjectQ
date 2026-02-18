using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SuperProjectQ
{
    public partial class frmPrintBill : Form
    {
        public frmPrintBill()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlDataAdapter adapterHD = null;
        SqlDataAdapter adapterCTHD = null;
        SqlDataAdapter adapterTrietKhau = null;
        int maHD = Session.maHD;
        private void PrintBill_Load(object sender, EventArgs e)
        {
            PageSettings pSetting = new PageSettings();
            PaperSize k80Size = new PaperSize("K80", 315, 800);
            pSetting.Margins = new Margins(5, 5, 5, 5);
            pSetting.PaperSize = k80Size;
            this.rpInHoaDon.SetPageSettings(pSetting);
            try
            {
                kn.ConnOpen();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }


            this.rpInHoaDon.LocalReport.DataSources.Clear();
            string sqlHD = $"SELECT HoaDon.MaHD, Phong.TenPhong, LoaiPhong.TenLoaiPhong, HoaDon.MaKH, HoaDon.MaNV, HoaDon.GioVao, HoaDon.GioRa, HoaDon.TongSoPhut, " +
                $"HoaDon.TienPhong, HoaDon.TienDichVu, HoaDon.TongTien, HoaDon.TrietKhauVIP, HoaDon.TrietKhauVoucher, HoaDon.VAT, HoaDon.TongThanhToan, " +
                $"HoaDon.PTTT, HoaDon.TrangThai FROM HoaDon INNER JOIN Phong ON Phong.MaPhong = HoaDon.MaPhong INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong WHERE MaHD = {maHD}";
            
            string sqlCTHD = $"SELECT ChiTietHD.MaHD, SanPham.TenHienThi, ChiTietHD.SoLuong, ChiTietHD.DonViTinh, ChiTietHD.DonGia, ChiTietHD.ThanhTien FROM ChiTietHD " +
                             $"INNER JOIN SanPham ON SanPham.MaSP = ChiTietHD.MaSP WHERE MaHD = {maHD}";
            
            string sqlTrietKhau = $"SELECT Discount FROM KhachHang WHERE MaKH = '{Session.MaKH}'";

            adapterHD = new SqlDataAdapter(sqlHD, kn.conn);
            adapterCTHD = new SqlDataAdapter(sqlCTHD, kn.conn);
            adapterTrietKhau = new SqlDataAdapter(sqlTrietKhau, kn.conn);

            DataSet ds = new DataSet();
            adapterHD.Fill(ds, "HoaDon");
            adapterCTHD.Fill(ds, "ChitTietHD");
            adapterTrietKhau.Fill(ds, "KhachHang");
            rpInHoaDon.LocalReport.ReportEmbeddedResource = "SuperProjectQ.AllForm.InHoaDon.RpInHoaDon.rdlc";

            //Đưa DL lên bảng báo cáo
            ReportDataSource rdsCTHD = new ReportDataSource("DataSetCTHD", ds.Tables["ChitTietHD"]);
            ReportDataSource rdsHoaDon = new ReportDataSource("DataSetHD", ds.Tables["HoaDon"]);
            ReportDataSource rdsKH = new ReportDataSource("DataSetKH", ds.Tables["KhachHang"]);
            rpInHoaDon.LocalReport.DataSources.Add(rdsHoaDon);
            rpInHoaDon.LocalReport.DataSources.Add(rdsCTHD);
            rpInHoaDon.LocalReport.DataSources.Add(rdsKH);
            rpInHoaDon.RefreshReport();

            //Set tham so
            ReportParameter[] SetPara = new ReportParameter[]
            {
                new ReportParameter("VAT", (SetParameters.VAT * 100).ToString()),
            };
            rpInHoaDon.LocalReport.SetParameters(SetPara);

            this.rpInHoaDon.RefreshReport();
        }
    }
}
