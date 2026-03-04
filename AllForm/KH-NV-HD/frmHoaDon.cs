using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.FrmMixed
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt = null;
        private void Load_DB()
        {
            string sqlHD = "SELECT * FROM HoaDon";
            dgvHoaDon.DataSource = kn.CreateTable(sqlHD);
            dgvHoaDon.Columns["GioVao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvHoaDon.Columns["GioRa"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                //dgvHoaDon.AutoGenerateColumns = false;
                kn.ConnOpen();
                Load_DB();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL\nLỗi: " + ex.Message);
                return;
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int maHD = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value);

            dt = new DataTable();
            dt = kn.CreateTable($"SELECT ChiTietHD.MaCTHD, ChiTietHD.MaHD, ChiTietHD.MaSP, SanPham.TenHienThi, " +
                $"ChiTietHD.SoLuong, ChiTietHD.DonViTinh, ChiTietHD.DonGia, ChiTietHD.ThanhTien " +
                $"FROM ChiTietHD " +
                $"INNER JOIN SanPham ON SanPham.MaSP = ChiTietHD.MaSP " +
                $"INNER JOIN HoaDon ON HoaDon.MaHD = ChiTietHD.MaHD " +
                $"WHERE ChiTietHD.MaHD = {maHD} AND HoaDon.TrangThai = 1 ");
            dgvCTHD.DataSource = null;
            dgvCTHD.DataSource = dt;
        }
    }
}
