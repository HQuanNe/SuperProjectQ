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

namespace SuperProjectQ.AllForm.NhapKho
{
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;
        private void PhieuNhap_Load()
        {
            string sqlPN = "SELECT pn.MaPN, NhanVien.TenNV, pn.NgayNhap, pn.TongThanhToan, pn.TrangThai, pn.GhiChu " +
                "FROM PhieuNhap AS pn " +
                "INNER JOIN NhanVien ON NhanVien.MaNV = pn.MaNV";
            dgvPhieuNhap.DataSource = kn.CreateTable(sqlPN);
        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvPhieuNhap);
            PhieuNhap_Load();
        }

        private void btnThemCombo_Click(object sender, EventArgs e)
        {
            using (frmNhapHang nhapHang = new frmNhapHang())
            {
                nhapHang.FormBorderStyle = FormBorderStyle.None;
                nhapHang.ShowDialog();

                PhieuNhap_Load();
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            lblTitle.Location = new Point((panel1.Width - lblTitle.Width)/2, lblTitle.Location.Y);
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (frmCTPhieuNhap ctPhieuNhap = new frmCTPhieuNhap())
            {
                Session.PhieuNhapData.MaPN = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                ctPhieuNhap.FormBorderStyle = FormBorderStyle.None;
                ctPhieuNhap.ShowDialog();

                PhieuNhap_Load();
            }
        }
    }
}
