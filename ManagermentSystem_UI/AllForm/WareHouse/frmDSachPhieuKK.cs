using DataAccessLayer;
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

namespace SuperProjectQ.AllForm.WareHouse
{
    public partial class frmDSachPhieuKK : Form
    {
        public frmDSachPhieuKK()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPhieuKiemKe_Click(object sender, EventArgs e)
        {
            using (frmPhieuKiemKe pkk = new frmPhieuKiemKe()) 
            {
                pkk.FormBorderStyle = FormBorderStyle.None;
                pkk.ShowDialog();
            }
            DSPKK_Load();
        }
        private bool InspectStatus(DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvDSPKK.Rows[e.RowIndex].Cells[8].Value) == 1 || Convert.ToInt32(dgvDSPKK.Rows[e.RowIndex].Cells[8].Value) == 2)
            {
                return false;
            }
            return true;
        }
        private void DSPKK_Load()
        {
            try
            {
                dgvDSPKK.DataSource = kn.CreateTable("SELECT pkk.MaKiemKe, pkk.NgayKiemKe, NguoiLap.TenNV AS NguoiLap, KhoHang.TenSP, pkk.TonHeThong, pkk.TonThucTe, " +
                    "pkk.ChenhLech, pkk.NguyenNhan, pkk.TrangThai, NguoiXN.TenNV AS NguoiXacNhan, xn.NgayXacNhan " +
                    "FROM KiemKe AS pkk " +
                    "INNER JOIN NhanVien NguoiLap ON NguoiLap.MaNV = pkk.MaNV " +
                    "INNER JOIN KhoHang ON KhoHang.MaSP_Kho = pkk.MaSP_Kho " +
                    "LEFT JOIN XacNhanPhieuKK AS xn ON xn.MaKiemKe = pkk.MaKiemKe " +
                    "LEFT JOIN NhanVien NguoiXN ON NguoiXN.MaNV = xn.NguoiXacNhan");
                dgvDSPKK.Columns["NgayKiemKe"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dgvDSPKK.Columns["NgayXacNhan"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("frmDSachPhieuKK - DSPKK_Load() \nLỗi: " + ex.Message);
            }
        }
        private void frmDSachPhieuKK_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvDSPKK);
            DSPKK_Load();
        }

        private void dgvDSPKK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSPKK.Columns[e.ColumnIndex].Name == "Approve")
            {
                if (!InspectStatus(e))
                {
                    MessageBox.Show("Yêu cầu này đã được xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Duyệt yêu cầu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int isSuccess = 0;
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = kn.conn;
                        cmd.CommandText = $"UPDATE KiemKe SET TrangThai = 1 WHERE MaKiemKe = {dgvDSPKK.Rows[e.RowIndex].Cells[0].Value}";
                        isSuccess += cmd.ExecuteNonQuery();
                    }
                    using (cmd = new SqlCommand())
                    {
                        int stt = Session.AutoCreateID_Interger("STT", "XacNhanPhieuKK");
                        string maNV = Session.StaffData.GetMaNVFromIDU();
                        cmd.Connection = kn.conn;
                        cmd.CommandText = $"INSERT INTO XacNhanPhieuKK (STT, MaKiemKe, NgayXacNhan, NguoiXacNhan) VALUES (@STT,  @MKK,  GETDATE(), @NXN)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@STT", stt);
                        cmd.Parameters.AddWithValue("MKK", dgvDSPKK.Rows[e.RowIndex].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@NXN", maNV);
                        isSuccess += cmd.ExecuteNonQuery();
                    }
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = kn.conn;
                        cmd.CommandText = $"UPDATE KhoHang SET TonKho = {Convert.ToDouble(dgvDSPKK.Rows[e.RowIndex].Cells[5].Value)} " +
                            $"WHERE MaSP_Kho = (SELECT MaSP_Kho FROM KiemKe WHERE MaKiemKe = {dgvDSPKK.Rows[e.RowIndex].Cells[0].Value})";
                        isSuccess += cmd.ExecuteNonQuery();
                    }//cập nhật kho
                    if (isSuccess == 3)
                    {
                        MessageBox.Show("Duyệt yêu cầu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DSPKK_Load();
                    }
                    else
                    {
                        MessageBox.Show("Duyệt yêu cầu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (dgvDSPKK.Columns[e.ColumnIndex].Name == "Denied")
            {
                if (!InspectStatus(e))
                {
                    MessageBox.Show("Yêu cầu này đã được xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Huỷ yêu cầu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int isSuccess = 0;
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = kn.conn;
                        cmd.CommandText = $"UPDATE KiemKe SET TrangThai = 2 WHERE MaKiemKe = '{dgvDSPKK.Rows[e.RowIndex].Cells[0].Value}'";
                        isSuccess += cmd.ExecuteNonQuery();
                    }
                    using (cmd = new SqlCommand())
                    {
                        int stt = Session.AutoCreateID_Interger("STT", "XacNhanPhieuKK");
                        string maNV = Session.StaffData.GetMaNVFromIDU();
                        cmd.Connection = kn.conn;
                        cmd.CommandText = $"INSERT INTO XacNhanPhieuKK (STT, MaKiemKe, NgayXacNhan, NguoiXacNhan) VALUES (@STT,  @MKK,  GETDATE(), @NXN)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@STT", stt);
                        cmd.Parameters.AddWithValue("MKK", dgvDSPKK.Rows[e.RowIndex].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@NXN", maNV);
                        isSuccess += cmd.ExecuteNonQuery();
                    }
                    if (isSuccess == 2)
                    {
                        MessageBox.Show("Huỷ yêu cầu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DSPKK_Load();
                    }
                    else
                    {
                        MessageBox.Show("Huỷ yêu cầu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvDSPKK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSPKK.Columns[e.ColumnIndex].Name == "Approve")
            {
                e.CellStyle.BackColor = Color.FromArgb(0, 192, 0);
                e.CellStyle.SelectionBackColor = Color.FromArgb(0, 192, 0);
            }
            else if (dgvDSPKK.Columns[e.ColumnIndex].Name == "Denied")
            {
                e.CellStyle.BackColor = Color.FromArgb(192, 0, 0);
                e.CellStyle.SelectionBackColor = Color.FromArgb(192, 0, 0);
            }

            if (dgvDSPKK.Columns[e.ColumnIndex].Name == "TrangThai" && dgvDSPKK.Rows[e.RowIndex].Cells["TrangThai"].Value != null)
            {
                int trangThai = Convert.ToInt32(dgvDSPKK.Rows[e.RowIndex].Cells["TrangThai"].Value);
                if (trangThai == 0)
                {
                    e.Value = "Chờ xác nhận";
                    e.FormattingApplied = true;
                }
                else if (trangThai == 1)
                {
                    e.Value = "Đã duyệt";
                    e.FormattingApplied = true;
                }
                else if (trangThai == 2)
                {
                    e.Value = "Đã từ chối";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
