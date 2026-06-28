using System;
using DataAccessLayer.Classes;
using System.Windows.Forms;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;
using SuperProjectQ.AllForm.Voucher;

namespace SuperProjectQ.AllForm.Other
{
    public partial class frmVoucher : Form
    {
        public frmVoucher()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        private void LoadVoucher()
        {
            try
            {
                dgvVoucher.DataSource = kn.CreateTable("SELECT * FROM Voucher");
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmVoucher - LoadVoucher Lỗi: "+ ex.Message);
            }
        }
        private void frmVoucher_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            Session.StandardDataGridView(dgvVoucher);
            LoadVoucher();
        }

        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            using (frmAddVoucher addVoucher = new frmAddVoucher())
            {
                addVoucher.FormBorderStyle = FormBorderStyle.None;
                addVoucher.ShowDialog();
                LoadVoucher();
            }
        }

        private void dgvVoucher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Session.VoucherData.maVoucher = dgvVoucher.Rows[e.RowIndex].Cells["MaVoucher"].Value.ToString();
            using (frmAdjustVoucher editVoucher = new frmAdjustVoucher())
            {
                editVoucher.FormBorderStyle = FormBorderStyle.None;
                editVoucher.ShowDialog();
                LoadVoucher();
            }
        }

        private void btnVoucherKH_Click(object sender, EventArgs e)
        {
            using (frmDSVoucherKH frm = new frmDSVoucherKH())
            {
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                LoadVoucher();
            }
        }
    }
}
