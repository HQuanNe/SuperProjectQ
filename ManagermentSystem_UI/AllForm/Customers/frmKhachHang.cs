using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SuperProjectQ.AllForm.KhachHang;
namespace SuperProjectQ.FrmMixed
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd = null;
        DataTable dt = null;
        SqlDataAdapter adapter = null;

        private void Customers_Load()
        {
            string sqlKH = "SELECT KhachHang.MaKH, KhachHang.TenKH, KhachHang.DiaChi, KhachHang.SoDienThoai, KhachHang.VIP, " +
                "KhachHang.DiemTichLuy, BangVIP.TrietKhau FROM KhachHang " +
                "LEFT JOIN BangVIP ON BangVIP.VIP = KhachHang.VIP";
            dgvKhachHang.DataSource = kn.CreateTable(sqlKH);
        }
        private void AddVoucher(string MaKH)
        {
            string sqlAddVoucher = "INSERT INTO VoucherKhachHang(STT, MaKH, MaVoucher, NgayNhan, NgayHetHan, TrangThai) " +
                "VALUES (@STT, @MKH, 'VCH01', GETDATE(), @NHH, 0)";
            cmd = new SqlCommand(sqlAddVoucher, kn.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@STT", Session.AutoCreateID_Interger("STT", "VoucherKhachHang"));
            cmd.Parameters.AddWithValue("@MKH", MaKH);
            cmd.Parameters.AddWithValue("@NHH", DateTime.Now.Date.AddDays(30));
            cmd.ExecuteNonQuery();

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

            kn.ConnOpen();
            Session.StandardDataGridView(dgvKhachHang);
            Customers_Load();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sqlSearch = $"SELECT * FROM KhachHang " +
                    $"WHERE MaKH LIKE N'%{txtSearch.Text}%' OR TenKH LIKE N'%{txtSearch.Text}%' " +
                    $"OR DiaChi LIKE N'%{txtSearch.Text}%' OR SoDienThoai LIKE N'%{txtSearch.Text}%' OR VIP LIKE N'%{txtSearch.Text}%'";
                dgvKhachHang.DataSource = kn.CreateTable(sqlSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmKhachHang - Lỗi: \n" + ex.Message);
                throw;
            }
        }//Tìm kiếm theo options

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Session.CustomerData.MaKH = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            Session.CustomerData.TenKH = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            Session.CustomerData.DiaChi = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
            Session.CustomerData.SoDienThoai = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
            Session.CustomerData.VIP = dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString();
            Session.CustomerData.DiemTichLuy = double.TryParse(dgvKhachHang.Rows[e.RowIndex].Cells[5].Value.ToString(), out double value) ? value : 0;

            frmAdjustCustomer adjustCustomer = new frmAdjustCustomer();
            adjustCustomer.FormBorderStyle = FormBorderStyle.None;
            adjustCustomer.ShowDialog();

            Customers_Load();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmThemKhachHang addCus = new frmThemKhachHang();
            addCus.FormBorderStyle = FormBorderStyle.None;
            addCus.ShowDialog();

            Customers_Load();
        }
    }
}
