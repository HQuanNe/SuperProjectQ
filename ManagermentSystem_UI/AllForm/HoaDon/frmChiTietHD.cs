using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
namespace SuperProjectQ.AllForm.HoaDon
{
    public partial class frmChiTietHD : Form
    {
        public frmChiTietHD()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt;
        private void CTHD_Load()
        {
            dgvCTHD.DataSource = kn.CreateTable($"SELECT ct.MaHD, ct.MaSP, COALESCE(SanPham.TenMatHang, Combo.TenCombo) AS TenSP, " +
                $"ct.LoaiHang, ct.SoLuong, ct.DonGia, ct.ThanhTien, ct.GhiChu " +
                $"FROM ChiTietHD AS ct " +
                $"LEFT JOIN SanPham ON SanPham.MaSP_Menu = ct.MaSP AND LoaiHang = 0 " +
                $"LEFT JOIN  Combo ON Combo.MaCombo = ct.MaSP AND LoaiHang = 1 " +
                $"WHERE ct.MaHD = {Session.RoomData.maHD}");
        }
        private void frmChiTietHD_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();

                lblTitle.Text = $"Chi tiết hoá đơn số {Session.RoomData.maHD}";
                Session.StandardDataGridView(dgvCTHD);
                CTHD_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmChiTietHD - Lỗi: \n" + ex.Message);
                return;
            }
        }

        private void dgvCTHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCTHD.Columns[e.ColumnIndex].Name == "LoaiHang" && e.Value != null)
            {
                if(e.Value is bool)
                {
                    e.Value = Convert.ToBoolean(e.Value) ? "Combo" : "Lẻ";
                    e.FormattingApplied = true;
                }
            }
            if (dgvCTHD.Columns[e.ColumnIndex].Name == "ThanhTien" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            frmPrintBill printBill = new frmPrintBill();
            printBill.ShowDialog();
        }
    }
}
