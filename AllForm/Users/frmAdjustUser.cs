using SuperProjectQ.AllForm.KhoHang;
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

namespace SuperProjectQ.AllForm.Users
{
    public partial class frmAdjustUser : Form
    {
        public frmAdjustUser()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string maNV, maQH, Email;

        private void User_Load()
        {
            try
            {
                using (dt = new DataTable())
                {
                    dt = kn.CreateTable($"SELECT * FROM Users WHERE IDUser = '{Session.StaffData.IDUser}'");

                    if (dt.Rows.Count < 1) return;

                    txtID.Text = dt.Rows[0]["IDUser"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    maNV = dt.Rows[0]["MaNV"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUser - User_Load Lỗi:\n" + ex.Message);
                return;
            }
        }
        private void QuyenHan_Load()

        {

            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT MaQH FROM PhanQuyen WHERE IDUser = '{txtID.Text.Trim()}'");

                if (dt.Rows.Count < 1) return;
                maQH = dt.Rows[0]["MaQH"].ToString();
            }//Lấy mã QH theo IDU
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT * FROM QuyenHan");

                if (dt.Rows.Count < 1) return;

                cmbQuyenHan.DataSource = dt;
                cmbQuyenHan.DisplayMember = "MoTa";
                cmbQuyenHan.ValueMember = "MaQH";
                cmbQuyenHan.SelectedValue = maQH;
            }
        }
        private void GetEmail()
        {
            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = $"SELECT Email FROM NhanVien WHERE MaNV = '{maNV}'";

                    Email = cmd.ExecuteScalar() != DBNull.Value ? cmd.ExecuteScalar().ToString() : string.Empty;
                }
                Session.StaffData.Email = Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUser - GetEmail Lỗi:\n" + ex.Message);
                return;
            }
        }
        private void Owners_Load()
        {
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT * FROM NhanVien");

                if (dt.Rows.Count < 1) return;

                cmbOwner.DataSource = dt;
                cmbOwner.DisplayMember = "TenNV";
                cmbOwner.ValueMember = "MaNV";
                cmbOwner.SelectedValue = maNV;
            }
        }
        private void frmAdjustUser_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            User_Load();
            Owners_Load();
            GetEmail();
            QuyenHan_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblChangePasswd_MouseHover(object sender, EventArgs e)
        {
            lblChangePasswd.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void lblChangePasswd_MouseLeave(object sender, EventArgs e)
        {
            lblChangePasswd.ForeColor = Color.FromArgb(0, 0, 255);
        }

        private void lblChangePasswd_Click(object sender, EventArgs e)
        {
            using (frmChangePasswd changePw = new frmChangePasswd())
            {
                changePw.FormBorderStyle = FormBorderStyle.None;
                changePw.ShowDialog();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "UPDATE PhanQuyen SET MaQH = @MQH WHERE IDUser = @IDUser";
                    cmd.Parameters.AddWithValue("@MQH", cmbQuyenHan.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDUser", Session.StaffData.IDUser);
                    cmd.ExecuteNonQuery();
                }
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "UPDATE Users SET MaNV = @MaNV WHERE IDUser = @IDUser";
                    cmd.Parameters.AddWithValue("@MaNV", cmbOwner.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDUser", Session.StaffData.IDUser);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đã cập nhật");
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUser - btnConfirm_Click Lỗi:\n" + ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận xoá tài khoản này. Thao tác này không thể hoàn tác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                using (frmXacNhan xn = new frmXacNhan())
                {
                    xn.FormBorderStyle = FormBorderStyle.None;
                    xn.ShowDialog();
                    if (!Session.isDeleted) return;
                }
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "DELETE PhanQuyen WHERE IDUser = @IDUser";
                    cmd.Parameters.AddWithValue("@IDUser", Session.StaffData.IDUser);
                    cmd.ExecuteNonQuery();
                }
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "DELETE Users WHERE IDUser = @IDUser";
                    cmd.Parameters.AddWithValue("@IDUser", Session.StaffData.IDUser);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã xoá tài khoản");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUser - btnDelete_Click Lỗi:\n" + ex.Message);
                return;
            }
        }
    }
}
