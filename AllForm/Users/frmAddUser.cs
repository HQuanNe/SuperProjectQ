using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SuperProjectQ.AllForm.Users
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt;
        SqlCommand cmd;

        Random rd = new Random();
        int expiredTime = 0, waitTime = 60, OTP;
        bool isValidOTP = false;
        private void Owners_Load()
        {
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT * FROM NhanVien");

                if (dt.Rows.Count < 1) return;

                cmbOwner.DataSource = dt;
                cmbOwner.DisplayMember = "TenNV";
                cmbOwner.ValueMember = "MaNV";
            }
        }
        private void QuyenHan_Load()
        {
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT * FROM QuyenHan");

                if (dt.Rows.Count < 1) return;

                cmbQuyenHan.DataSource = dt;
                cmbQuyenHan.DisplayMember = "MoTa";
                cmbQuyenHan.ValueMember = "MaQH";
            }
        }
        private bool Inspect_UserName()
        {
            using(dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT UserName FROM Users WHERE UserName = '{txtUserName.Text.Trim()}'");

                return dt.Rows.Count > 0 ? false : true;
            }
        }
        private void frmAddUser_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Owners_Load();
            QuyenHan_Load();
            txtID.Text = Session.AutoCreateID_String("IDUser", "Users", "ID");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsValidPasswordAndUserName(string s)
        {
            // Chỉ cho phép a-z, A-Z, 0-9 và không có dấu cách
            return Regex.IsMatch(s, @"^[a-zA-Z0-9]+$");
        } //Kiểm tra valid passwd
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(!IsValidPasswordAndUserName(txtUserName.Text) || !IsValidPasswordAndUserName(txtPassword.Text) || !IsValidPasswordAndUserName(txtConfirmPasswd.Text))
                {
                    MessageBox.Show("Tên đăng nhập, mật khẩu chỉ được chứa các ký tự (a-z), (A-Z), (0-9)");
                    return;
                }
                //Kiểm tra độ dài mật khẩu
                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải lớn hơn hoặc bằng 6 ký tự!!!");
                    return;
                }
                //Kiểm tra confirm pass với pass
                if (txtConfirmPasswd.Text.Trim() != txtPassword.Text.Trim())
                {
                    MessageBox.Show("Xác nhận mật khẩu phải trùng khớp với mật khẩu!!!");
                    return;
                }
                if (!Inspect_UserName())
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại");
                    return;
                }
                //Kiểm tra mã OTP
                if (txtOTP.Text.Trim() == OTP.ToString()) isValidOTP = true;//Kiểm tra OTP nhập vào
                else { MessageBox.Show("Mã OTP không chính xác!!!"); return; }

                //Lưu tài khoản
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "INSERT INTO Users(IDUser, UserName, Password, MaNV) VALUES " +
                        "(@IDU, @USN, @PASS, @MNV)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IDU", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@USN", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@PASS", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@MNV", cmbOwner.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "INSERT INTO PhanQuyen(MaPQ, MaQH, IDUser) VALUES " +
                        "(@MPQ, @MQH, @IDU)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MPQ", Session.AutoCreateID_String("MaPQ", "PhanQuyen", "PQ"));
                    cmd.Parameters.AddWithValue("@MQH", cmbQuyenHan.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDU", txtID.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                isValidOTP = false;
                MessageBox.Show("Thêm tài khoản mới thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddUser - btnConfirm_Click Lỗi:\n" + ex.Message);
                return;
            }
        }

        private void lblVisiblePasswd_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                lblVisiblePasswd.Image = Image.FromFile(Application.StartupPath + @"\Images\IconUI\visibility_24dp_000000_FILL0_wght400_GRAD0_opsz24.png");
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                lblVisiblePasswd.Image = Image.FromFile(Application.StartupPath + @"\Images\IconUI\visibility_off_24dp_000000_FILL0_wght400_GRAD0_opsz24.png");
                txtPassword.PasswordChar = '*';
            }
        }

        private void cmbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (cmd = new SqlCommand())
            {
                cmd.Connection = kn.conn;
                cmd.CommandText = $"SELECT Email FROM NhanVien WHERE MaNV = '{cmbOwner.SelectedValue}'";

                Session.StaffData.Email = cmd.ExecuteScalar() != DBNull.Value && cmd.ExecuteScalar() != null ? cmd.ExecuteScalar().ToString() : string.Empty;
            }
        }

        private void timerExpired_Tick(object sender, EventArgs e)
        {
            expiredTime++;
            if(expiredTime == 1 * 60)
            {
                timerExpired.Stop();
                OTP = int.MinValue;
                Console.WriteLine("Da het han OTP");
            }
        }

        private void timerWaitTime_Tick(object sender, EventArgs e)
        {
            btnSendBack.Text = waitTime.ToString() + "s";
            waitTime--;

            if(waitTime == 0)
            {
                timerWaitTime.Stop();
                btnSendBack.Text = "Gửi lại";
                btnSendBack.Enabled = true;
                waitTime = 60;
            }
        }

        private void btnSendBack_Click(object sender, EventArgs e)
        {
            OTP = rd.Next(100000, 999999);
            Session.StaffData.SendEmail(Session.StaffData.Email, OTP);
            timerWaitTime.Start();
            timerExpired.Start();
        }
    }
}
