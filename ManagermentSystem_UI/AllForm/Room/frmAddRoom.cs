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
    public partial class frmAddRoom : Form
    {
        public frmAddRoom()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        decimal pricePerHour = 0;

        private void LoaiPhong_Load()
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
        }
        private void Price_Load()
        {
            string sqlPrice = $"SELECT GiaTheoGio FROM LoaiPhong WHERE MaLoaiPhong = '{cmbLoaiPhong.SelectedValue}' ";

            cmd = new SqlCommand(sqlPrice, kn.conn);
            pricePerHour = cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDecimal(cmd.ExecuteScalar()) : 0;

            txtGia1Gio.Text = pricePerHour.ToString("#,##0") + "đ";
        }
        private void frmAddRoom_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            txtTenPhong.Text = "P";
            LoaiPhong_Load();
            Price_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận thêm phòng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No) return;
                if(!(int.TryParse(txtFloor.Text.Trim(), out int value))) { MessageBox.Show("Tầng phải là chữ số"); return; }

                string sqlAddRoom = "INSERT INTO Phong (MaPhong, TenPhong, MaLoaiPhong, Tang, TrangThai, GhiChu) " +
                    "VALUES (@MP, @TP, @MLP, @FLOOR, @TT, @GC)";
                using (cmd = new SqlCommand(sqlAddRoom, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MP", Session.AutoCreateID_String("MaPhong", "Phong", "MP"));
                    cmd.Parameters.AddWithValue("@TP", txtTenPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@MLP", cmbLoaiPhong.SelectedValue);
                    cmd.Parameters.AddWithValue("@FlOOR", txtFloor.Text.Trim());
                    cmd.Parameters.AddWithValue("TT", 0);
                    cmd.Parameters.AddWithValue("GC", txtGhiChu.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã thêm phòng mới");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddRoom - btnThem Lỗi:\n" +ex.Message);
            }
        }

        private void txtTenPhong_TextChanged(object sender, EventArgs e)
        {
            if (txtTenPhong.Text.Length < 1) txtTenPhong.Text = "P";
            txtTenPhong.SelectionStart = txtTenPhong.Text.Length;
        }

        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Price_Load();
        }
    }
}
