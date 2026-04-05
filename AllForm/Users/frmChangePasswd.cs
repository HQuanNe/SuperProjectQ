using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.Users
{
    public partial class frmChangePasswd : Form
    {
        public frmChangePasswd()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;

        Random rd = new Random();
        bool isValidOTP = false;
        string oldPasswd;
        int waitTime = 60, cdTime, OTP;

        private void LoadPasswd()
        {
            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "SELECT Password FROM Users WHERE IDUser = @IDUser";
                    cmd.Parameters.AddWithValue("@IDUser", Session.StaffData.IDUser);
                }
                    oldPasswd = cmd.ExecuteScalar() != DBNull.Value ? cmd.ExecuteScalar().ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmChangePasswd - LoadPasswd Lỗi:\n" + ex.Message);
            }
        } //Hàm lấy password
        public bool IsValidPassword(string password)
        {
            // Chỉ cho phép a-z, A-Z, 0-9 và không có dấu cách
            return Regex.IsMatch(password, @"^[a-zA-Z0-9]+$");
        } //Kiểm tra valid passwd
        private void frmChangePasswd_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            LoadPasswd();
        }
        private void lblVisiblePasswd_Click(object sender, EventArgs e)
        {
            if (txtNewPasswd.PasswordChar == '*')
            {
                lblVisiblePasswd.Image = Image.FromFile(Application.StartupPath + @"\Images\IconUI\visibility_24dp_000000_FILL0_wght400_GRAD0_opsz24.png");
                txtNewPasswd.PasswordChar = '\0';
            }
            else
            {
                lblVisiblePasswd.Image = Image.FromFile(Application.StartupPath + @"\Images\IconUI\visibility_off_24dp_000000_FILL0_wght400_GRAD0_opsz24.png");
                txtNewPasswd.PasswordChar = '*';
            }
        } //Ẩn hiện mật khẩu

        private void btnSendBack_Click(object sender, EventArgs e)
        {
            OTP = rd.Next(100000, 999999);

            Session.StaffData.SendEmail(Session.StaffData.Email, OTP);
            timerSendBack.Start();
            timerCookieOTP.Start();
            btnSendBack.Enabled = false;
        } //Click để nhận email

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPasswd.Text.Trim() == oldPasswd && IsValidPassword(txtNewPasswd.Text.Trim()) && txtConfirmNewPasswd.Text.Trim()  == txtNewPasswd.Text.Trim() && txtOTP.Text.Trim() != string.Empty)
                {
                    //Kiểm tra độ dài mật khẩu
                    if(txtNewPasswd.Text.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu phải lớn hơn hoặc bằng 6 ký tự");
                        return;
                    }
                    //Kiểm tra mã OTP
                    if (txtOTP.Text.Trim() == OTP.ToString()) isValidOTP = true;//Kiểm tra OTP nhập vào
                    else { MessageBox.Show("Mã OTP không chính xác!!!"); return; }

                    if (isValidOTP)
                    {
                        using (cmd = new SqlCommand())
                        {
                            cmd.Connection = kn.conn;
                            cmd.CommandText = "UPDATE Users SET Password = @Password WHERE IDUser = @IDUser";
                            cmd.Parameters.AddWithValue("@Password", txtNewPasswd.Text.Trim());
                            cmd.Parameters.AddWithValue("@IDUser", Session.StaffData.IDUser);
                            cmd.ExecuteNonQuery();

                            isValidOTP = false;
                            MessageBox.Show("Đổi mật khẩu thành công!!!");
                            this.Close();
                        }
                    }
                }
                else if (txtOldPasswd.Text.Trim() != oldPasswd)
                {
                    MessageBox.Show("Mật cũ không chính xác!!!");
                    return;
                }
                else if(!IsValidPassword(txtNewPasswd.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu mới không hợp lệ!!!");
                    return;
                }
                else if (txtConfirmNewPasswd.Text.Trim() != txtNewPasswd.Text.Trim())
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!!!");
                    return;
                }
                else if (txtOTP.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Mã OTP không được để trống!!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmChangePasswd - btnConfirm_Click Lỗi:\n" + ex.Message);
            }
        }

        private void timerCookieOTP_Tick(object sender, EventArgs e)
        {
            cdTime++;
            if(cdTime == 1 * 60)
            {
                OTP = int.MinValue;
                timerCookieOTP.Stop();
                Console.WriteLine("Mã OTP đã hết hạn");
            }
        }

        private void timerSendBack_Tick(object sender, EventArgs e)
        {
            btnSendBack.Text = waitTime.ToString() + "s";
            waitTime--;
            if (waitTime < 0)
            {
                timerSendBack.Stop();
                btnSendBack.Text = "Gửi lại";
                btnSendBack.Enabled = true;
                waitTime = 60;
            }
        }
    }
}
