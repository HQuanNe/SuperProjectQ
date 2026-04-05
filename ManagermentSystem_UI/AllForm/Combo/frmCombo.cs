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

namespace SuperProjectQ.AllForm.Combo
{
    public partial class frmCombo : Form
    {
        public frmCombo()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        private void Combo_Load()
        {
            string sqlCombo = "SELECT cb.MaCombo, cb.TenCombo, DanhMuc.TenDM, cb.DonGia, cb.HinhAnh, cb.GhiChu FROM Combo AS cb " +
                "INNER JOIN DanhMuc ON DanhMuc.MaDM = cb.MaDM";
            dgvListRoom.DataSource = kn.CreateTable(sqlCombo);
        }
        private void frmCombo_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvListRoom);
            Combo_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
