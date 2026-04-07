using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataAccessLayer;
using E_Menu.Classes;

namespace E_Menu.E_Menu
{
    public partial class frmLoginRoom : Form
    {
        public frmLoginRoom()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        private string GetRoomID()
        {
            try
            {
                string maPhong;
                using (cmd = new SqlCommand($"SELECT MaPhong FROM Phong WHERE MaPhong = '{txtRoomID.Text.Trim().Replace("'", "")}' AND MaPhong = '{txtPassword.Text.Trim().Replace("'", "")}' ", kn.conn))
                {
                    maPhong = cmd.ExecuteScalar() != null && cmd.ExecuteScalar() != DBNull.Value ? cmd.ExecuteScalar().ToString() : null; 
                }
                return maPhong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLoginRoom - GetRoomID Lỗi:\n" + ex.Message);
                return null;
            }
        }
        private bool InspectStatusRoom()
        {
            try
            {
                bool isActive;
                using (cmd = new SqlCommand($"SELECT TrangThai FROM Phong WHERE MaPhong = '{txtRoomID.Text.Trim().Replace("'", "")}'", kn.conn))
                {
                    isActive = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? false : Convert.ToInt16(cmd.ExecuteScalar().ToString()) == 1 ? true : false;
                }
                return isActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLoginRoom - InspectStatusRoom() Lỗi:\n" + ex.Message);
                return false;
            }
        }
        private void frmLoginRoom_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtRoomID.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Các trường không được để trống!!!"); 
                    return;
                }
                else if (GetRoomID() == null)
                {
                    MessageBox.Show("Thông tin đăng nhập chưa chính xác!!!");
                    return;
                }
                else if (!InspectStatusRoom())
                {
                    MessageBox.Show("Phòng chưa vận hành hoặc đã được đặt trước!!!");
                    return;
                }
                using (frmMenu menu = new frmMenu())
                {
                    this.Close();
                    TransData.RoomID = GetRoomID();
                    menu.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLoginRoom - btnLogin_Click Lỗi:\n" + ex.Message);
                return;
            }
        }
    }
}
