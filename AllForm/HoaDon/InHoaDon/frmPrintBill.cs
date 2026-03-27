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
        int maHD = Session.RoomData.maHD;
        private void PrintBill_Load(object sender, EventArgs e)
        {
            PaperSize k80Size = new PaperSize("K80", 315, 800);

            PageSettings pSetting = new PageSettings();
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
            Console.WriteLine("Session Mã HD: " + maHD);

            this.rpInHoaDon.LocalReport.DataSources.Clear();
            string sqlHD = $"SELECT HoaDon.MaHD, Phong.TenPhong, LoaiPhong.TenLoaiPhong, HoaDon.MaKH, HoaDon.MaNV, HoaDon.GioVao, HoaDon.GioRa, HoaDon.TongSoPhut, " +
                $"HoaDon.TienPhong, HoaDon.TienDichVu, HoaDon.TongTien, HoaDon.TrietKhauVIP, HoaDon.TrietKhauVoucher, HoaDon.VAT, HoaDon.TongThanhToan, HoaDon.PTTT, HoaDon.TrangThai " +
                $"FROM HoaDon " +
                $"INNER JOIN Phong ON Phong.MaPhong = HoaDon.MaPhong " +
                $"INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong WHERE MaHD = {maHD}";
            
            string sqlCTHD = $"SELECT ct.MaHD, " +
                $"COALESCE(Sanpham.TenMatHang, Combo.TenCombo) AS TenMatHang, " +
                $"ct.SoLuong, ct.DonViTinh, ct.DonGia, ct.ThanhTien " +
                $"FROM ChiTietHD ct " +
                $"LEFT JOIN SanPham ON SanPham.MaSP_Menu = ct.MaSP AND ct.LoaiHang = 0 " +
                $"LEFT JOIN Combo ON Combo.MaCombo = ct.MaSP AND ct.LoaiHang = 1" +
                $"WHERE MaHD = {maHD}";
            
            string sqlTrietKhau = $"SELECT kh.TenKH, BangVIP.TrietKhau FROM KhachHang AS kh " +
                $"INNER JOIN BangVIP ON BangVIP.VIP = kh.VIP" +
                $" WHERE MaKH = '{Session.MaKH}'";

            adapterHD = new SqlDataAdapter(sqlHD, kn.conn);
            adapterCTHD = new SqlDataAdapter(sqlCTHD, kn.conn);
            adapterTrietKhau = new SqlDataAdapter(sqlTrietKhau, kn.conn);

            DataSet ds = new DataSet();
            adapterHD.Fill(ds, "HoaDon");
            adapterCTHD.Fill(ds, "ChitTietHD");
            adapterTrietKhau.Fill(ds, "TrietKhauKH");
            rpInHoaDon.LocalReport.ReportEmbeddedResource = "SuperProjectQ.AllForm.HoaDon.InHoaDon.RpInHoaDon.rdlc";

            //Đưa DL lên bảng báo cáo
            ReportDataSource rdsCTHD = new ReportDataSource("DataSetCTHD", ds.Tables["ChitTietHD"]);
            ReportDataSource rdsHoaDon = new ReportDataSource("DataSetHD", ds.Tables["HoaDon"]);
            ReportDataSource rdsTKKH = new ReportDataSource("DataSetKH", ds.Tables["TrietKhauKH"]);
            rpInHoaDon.LocalReport.DataSources.Add(rdsHoaDon);

            rpInHoaDon.LocalReport.DataSources.Add(rdsCTHD);
            rpInHoaDon.LocalReport.DataSources.Add(rdsTKKH);

            //Set tham so
            ReportParameter[] SetPara = new ReportParameter[]
            {
                new ReportParameter("VAT", (Session.VAT).ToString()),
            };
            rpInHoaDon.LocalReport.SetParameters(SetPara);

            this.rpInHoaDon.RefreshReport();
        }
    }
}
