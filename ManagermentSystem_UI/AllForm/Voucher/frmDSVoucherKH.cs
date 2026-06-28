using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.Voucher
{
    public partial class frmDSVoucherKH : Form
    {
        public frmDSVoucherKH()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        private void VoucherKH_Load()
        {
            dgvDSVoucherKH.DataSource = null;
            dgvDSVoucherKH.DataSource = kn.CreateTable("SELECT vkh.STT, KhachHang.TenKH, Voucher.TenVoucher, vkh.NgayNhan, vkh.NgayHetHan, " +
                "vkh.NgaySuDung, vkh.TrangThai, vkh.GhiChu " +
                "FROM VoucherKhachHang AS vkh " +
                "INNER JOIN KhachHang ON KhachHang.MaKH = vkh.MaKH " +
                "INNER JOIN Voucher ON Voucher.MaVoucher = vkh.MaVoucher");
        }
        private void frmDSVoucherKH_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            Session.StandardDataGridView(dgvDSVoucherKH);
            VoucherKH_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoucherKH_Click(object sender, EventArgs e)
        {
            using (frmRandomVoucher frm = new frmRandomVoucher())
            {
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                VoucherKH_Load();
            }
        }
    }
}
