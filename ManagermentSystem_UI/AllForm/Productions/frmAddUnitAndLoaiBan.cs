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

namespace SuperProjectQ.AllForm.Productions
{
    public partial class frmAddUnitAndLoaiBan : Form
    {
        public frmAddUnitAndLoaiBan()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;
        private void frmAddUnitAndLoaiBan_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn thêm đơn vị mới không?\n" +
                    "Lưu ý hã kiểm tra kỹ trước khi thêm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;

                string sqlTSo = "SELECT GiaTri FROM ThongSo WHERE STT = 6";
                string unit = "";
                using (cmd = new SqlCommand(sqlTSo, kn.conn))
                {
                    unit = cmd.ExecuteScalar() != DBNull.Value ? cmd.ExecuteScalar().ToString() : "";
                }

                string sqlUpdateTS = "UPDATE ThongSo SET GiaTri = @GT WHERE STT = 6";
                using (cmd = new SqlCommand(sqlUpdateTS, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GT", $"{unit},{txtDonViTinh.Text.Trim()}");
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã thêm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddUnitAndLoaiBan - btnAddUnit_Click() Lỗi: \n" + ex.Message);
                return;
            }
        }

        private void btnAddLoaiBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn thêm loại bán mới không?\n" +
                    "Lưu ý hã kiểm tra kỹ trước khi thêm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;

                string sqlTSo = "SELECT GiaTri FROM ThongSo WHERE STT = 7";
                string loaiBan = "";
                using (cmd = new SqlCommand(sqlTSo, kn.conn))
                {
                    loaiBan = cmd.ExecuteScalar() != DBNull.Value ? cmd.ExecuteScalar().ToString() : "";
                }

                string sqlUpdateTS = "UPDATE ThongSo SET GiaTri = @GT WHERE STT = 7";
                using (cmd = new SqlCommand(sqlUpdateTS, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GT", $"{loaiBan},{txtLoaiBan.Text.Trim()}");
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã thêm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddUnitAndLoaiBan - btnAddLoaiBan_Click() Lỗi: \n" + ex.Message);
                return;
            }
        }
    }
}
