using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.Room
{
    public partial class frmRoomOptions : Form
    {
        public frmRoomOptions()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        bool hasCustomer = false;
        private void AllBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            //Session.RoomData.status = btn.Name == "btnDatTruoc" ? 2 : 
            //    btn.Name == "btnHuyDatTruoc" ? 3 : btn.Name == "btnActive" ? 1 : -1;
            switch (btn.Name)
            {
                case "btnDatTruoc":
                    if (MessageBox.Show("Xác nhận đặt trước?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                    Session.RoomData.status = 2;
                    hasCustomer = true;
                    break;
                case "btnHuyDatTruoc":
                    if (MessageBox.Show("Xác huỷ đặt trước?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                    Session.RoomData.status = 3;
                    hasCustomer = false;
                    break;
                case "btnActive":
                    if (MessageBox.Show("Xác nhận mở phòng?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                    Session.RoomData.status = 1;
                    hasCustomer = true;
                    break;
                default:
                    break;
            }
            
            if (hasCustomer)
            {
                if (!(Session.XuLySDT(txtSDT.Text))) return;
                Session.UpdatePhoneNumberForRoom(txtSDT.Text);
                Session.CustomerData.SoDienThoai = txtSDT.Text;
            }
            else
            {
                Session.UpdatePhoneNumberForRoom("NULL");
            }
            this.Close();

        }
        private string GetPhoneNumber()
        {
            kn.ConnOpen();

            string sql = "SELECT SDT_KhachHang FROM Phong WHERE MaPhong = @MP";
            using (cmd = new SqlCommand(sql, kn.conn))
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MP", Session.RoomData.maPhong);
                return cmd.ExecuteScalar().ToString();
            }
        }
        private void frmRoomOptions_Load(object sender, EventArgs e)
        {
            switch (Session.RoomData.status)
            {
                case 0:
                    btnHuyDatTruoc.Visible = false;
                    break;
                case 2:
                    btnHuyDatTruoc.Visible = true;
                    break;
                default:
                    break;
            }

            txtSDT.Text = GetPhoneNumber();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 10)
            {
                txtSDT.Text = txtSDT.Text.Remove(10, 1);
            }
            txtSDT.SelectionStart = txtSDT.Text.Length;
        }
    }
}
