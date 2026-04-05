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
    public partial class frmCTPhieuNhap : Form
    {
        public frmCTPhieuNhap()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;
        private void CTPhieuNhap_Load()
        {
            string sqlCTPN = "SELECT ctpn.MaCTPN, NhaCungCap.TenCongTy, KhoHang.TenSP, ctpn.SoLuong, ctpn.DonGia, ctpn.ThanhTien " +
                "FROM CTPhieuNhap AS ctpn " +
                "INNER JOIN NhaCungCap ON NhaCungCap.MaNCC = ctpn.MaNCC " +
                "INNER JOIN KhoHang ON KhoHang.MaSP_Kho = ctpn.MaSP_Kho " +
                $"WHERE ctpn.MaPN = '{Session.PhieuNhapData.MaPN}'";
            dgvCTPN.DataSource = kn.CreateTable(sqlCTPN);
        }
        private void frmCTPhieuNhap_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvCTPN);
            CTPhieuNhap_Load();
            lblTitle.Text += $" {Session.PhieuNhapData.MaPN}";
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            lblTitle.Location = new Point((panel1.Width - lblTitle.Width) / 2, lblTitle.Location.Y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
