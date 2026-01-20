using SuperProjectQ.Frm_Main_Login_Register;
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
using System.IO;
using static System.Collections.Specialized.BitVector32;

namespace SuperProjectQ
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }
        ConnectData kn = new ConnectData();
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL\n Lỗi: " + ex.Message);
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không được để trống");
                    return;
                }
                else
                {
                    string loginIDUser = null, loginMaNV = null, loginTenNV = null, loginChucVu = null ;
                    string sqlLogin = $"SELECT * FROM Users WHERE UserName = '{txtUserName.Text.Trim()}' AND Password = '{txtPassword.Text.Trim()}'";
                    DataTable dt = new DataTable();
                    dt = kn.CreateTable(sqlLogin);
                    foreach (DataRow rowIDUser in dt.Rows)
                    {
                        loginIDUser = rowIDUser["IDUser"].ToString();
                        loginMaNV = rowIDUser["MaNV"].ToString();
                        //Lấy mã NV
                        string sqlTenNV = $"SELECT * FROM NhanVien WHERE MaNV = '{loginMaNV}'";
                        DataTable dtTenNV = new DataTable();
                        dtTenNV = kn.CreateTable(sqlTenNV);
                        foreach (DataRow rowTenNV in dtTenNV.Rows)
                        {
                            loginTenNV = rowTenNV["TenNV"].ToString();
                            loginChucVu = rowTenNV["ChucVu"].ToString();
                        }
                    }
                    if (loginIDUser != null)
                    {
                        Session.IDUser = loginIDUser;
                        Session.MaNV = loginMaNV;
                        Session.TenNV = loginTenNV;
                        Session.ChucVu = loginChucVu;
                        //Lưu log 
                        Session.Datalog("login.txt", $"ID: {loginIDUser} - MãNV: {loginMaNV} đã đăng nhập");
                        frmMainUI MainUI = new frmMainUI();
                        MainUI.ShowDialog();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
                        return;
                    }
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 207:
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            var redColor = Color.Red;
            var greenColor = Color.Green;
            var blueColor = Color.Blue;
            btnExit.BackColor = redColor;
            btnExit.ForeColor = Color.White;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
            btnExit.ForeColor = Color.Black;
        }
    }
}
