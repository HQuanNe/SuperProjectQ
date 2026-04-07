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
    public partial class frmListRoom : Form
    {
        public frmListRoom()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        private void ListRoom_Load()
        {
            string sqlRoom = "SELECT p.MaPhong, p.TenPhong, LoaiPhong.TenLoaiPhong, p.Tang, p.TrangThai, " +
                "p.GioVao, p.GioDatTruoc, p.SDT_KhachHang, p.GhiChu FROM Phong as p " +
                "INNER JOIN LoaiPhong ON LoaiPhong.MaLoaiPhong = p.MaLoaiPhong " +
                "WHERE p.TrangThai = 0 ORDER BY p.TenPhong ASC";

            dgvListRoom.DataSource = kn.CreateTable(sqlRoom);
        }
        private void frmListRoom_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvListRoom);
            ListRoom_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListRoom_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvListRoom.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                switch (Convert.ToInt32(e.Value))
                {
                    case 0:
                        e.Value = "Trống";
                        break;
                    case 1:
                        e.Value = "Đang vận hành";
                        break;
                    case 2:
                        e.Value = "Đã đặt trước";
                        break;
                    default:
                        break;
                }
                e.FormattingApplied = true;
            }
            if (dgvListRoom.Columns[e.ColumnIndex].Name == "GioVao")
            {
                e.Value = string.IsNullOrEmpty(e.Value.ToString()) ? "" : (Convert.ToDateTime(e.Value)).ToString("dd/MM/yyyy HH:mm:ss");
                e.FormattingApplied = true;
            }
        }
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            using (frmAddRoom addRoom = new frmAddRoom())
            {
                addRoom.FormBorderStyle = FormBorderStyle.None;
                addRoom.ShowDialog();

                ListRoom_Load();
            }
        }

        private void dgvListRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (frmAdjustRoom adjustRoom = new frmAdjustRoom())
            {
                Session.RoomData.maPhong = dgvListRoom.Rows[e.RowIndex].Cells[0].Value.ToString();
                adjustRoom.FormBorderStyle = FormBorderStyle.None;
                adjustRoom.ShowDialog();

                ListRoom_Load();
            }
        }
    }
}
