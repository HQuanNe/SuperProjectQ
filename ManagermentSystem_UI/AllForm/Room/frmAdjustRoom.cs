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
using DataAccessLayer;

namespace SuperProjectQ.AllForm.Room
{
    public partial class frmAdjustRoom : Form
    {
        public frmAdjustRoom()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string maLoaiPhong = "";
        decimal pricePerHour = 0;

        private void Room_Load()
        {
            string sqlRoom = $"SELECT * FROM Phong WHERE MaPhong = '{Session.RoomData.maPhong}'";
            using (dt = new DataTable())
            {
                dt = kn.CreateTable(sqlRoom);
                if (dt.Rows.Count < 1) return;
                txtTenPhong.Text = dt.Rows[0]["TenPhong"].ToString();
                txtFloor.Text = dt.Rows[0]["Tang"].ToString();
                txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();

                maLoaiPhong = dt.Rows[0]["MaLoaiPhong"].ToString();
            }
        }
        private void CmbLoaiPhong_Load()
        {
            string sqlLoaiPhong = "SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong WHERE MaLoaiPhong <> 'LPR02' AND MaLoaiPhong <> 'LPR03' " +
                "AND MaLoaiPhong <> 'LPR04' " +
                "AND MaLoaiPhong <> 'LPR05' " +
                "AND MaLoaiPhong <> 'LPR06' " +
                "AND MaLoaiPhong <> 'LPV02' " +
                "AND MaLoaiPhong <> 'LPV03' " +
                "AND MaLoaiPhong <> 'LPV04' " +
                "AND MaLoaiPhong <> 'LPV05' " +
                "AND MaLoaiPhong <> 'LPV06' ";
            cmbLoaiPhong.DataSource = kn.CreateTable(sqlLoaiPhong);
            cmbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cmbLoaiPhong.ValueMember = "MaLoaiPhong";

            cmbLoaiPhong.SelectedValue = maLoaiPhong;
        }
        private void Price_Load()
        {
            string sqlPrice = $"SELECT GiaTheoGio FROM LoaiPhong WHERE MaLoaiPhong = '{cmbLoaiPhong.SelectedValue}' ";

            cmd = new SqlCommand(sqlPrice, kn.conn);
            pricePerHour = cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDecimal(cmd.ExecuteScalar()) : 0;

            txtGia1Gio.Text = pricePerHour.ToString("#,##0") + "đ";
        }
        private void frmAdjustRoom_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Room_Load();
            CmbLoaiPhong_Load();
            Price_Load();
        }

        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Price_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cmbLoaiPhong.SelectedValue + "\n" + Session.RoomData.maPhong);
            try
            {
                if (MessageBox.Show("Xác sửa phòng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
                if (!(int.TryParse(txtFloor.Text.Trim(), out int value))) { MessageBox.Show("Tầng phải là chữ số"); return; }

                string sqlAddRoom = "UPDATE Phong SET TenPhong = @TP, MaLoaiPhong = @MLP, Tang = @FLOOR, GhiChu = @GC " +
                    "WHERE MaPhong = @MP";
                using (cmd = new SqlCommand(sqlAddRoom, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MP", Session.RoomData.maPhong);
                    cmd.Parameters.AddWithValue("@TP", txtTenPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@MLP", cmbLoaiPhong.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FlOOR", txtFloor.Text.Trim());
                    cmd.Parameters.AddWithValue("GC", txtGhiChu.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã sửa phòng");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddRoom - btnConfirm Lỗi:\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xoá phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                using (frmXacNhan xacNhan = new frmXacNhan())
                {
                    xacNhan.FormBorderStyle = FormBorderStyle.None;
                    xacNhan.ShowDialog();
                }

                if (Session.isDeleted) 
                {
                    string sqlDel = "DELETE Phong Where MaPhong = (@MP)";
                    cmd = new SqlCommand(sqlDel, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MP", Session.RoomData.maPhong);
                    cmd.ExecuteNonQuery();
                }

                Session.isDeleted = false;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAdjustRoom - btnDelete_Click Lỗi:\n" + ex.Message);
                return;
            }
        }
    }
}
