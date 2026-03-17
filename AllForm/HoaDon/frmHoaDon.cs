using SuperProjectQ.AllForm.HoaDon;
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
            string sqlHD = "SELECT * FROM HoaDon WHERE TrangThai = 1";
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

                Session.StandardDataGridView(dgvHoaDon);
                Load_DB();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL\nLỗi: " + ex.Message);
                return;
            }
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Session.maHD = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells[0].Value);
            Console.WriteLine(Session.maHD.ToString());

            frmChiTietHD cthd = new frmChiTietHD();
            cthd.FormBorderStyle = FormBorderStyle.None;

            cthd.ShowDialog();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                if(e.Value is bool)
                {
                    e.Value = (bool)e.Value ? "Đã thanh toán" : "Chưa thanh toán";
                }
            }
        }
    }
}
