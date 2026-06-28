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

namespace SuperProjectQ.AllForm.NhapKho
{
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;
        private void PhieuNhap_Load()
        {
            string sqlPN = "SELECT pn.MaPN, NhanVien.TenNV, pn.NgayNhap, pn.TongThanhToan, pn.TrangThai, pn.GhiChu " +
                "FROM PhieuNhap AS pn " +
                "INNER JOIN NhanVien ON NhanVien.MaNV = pn.MaNV";
            dgvPhieuNhap.DataSource = kn.CreateTable(sqlPN);
        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvPhieuNhap);
            PhieuNhap_Load();
        }

        private void btnThemCombo_Click(object sender, EventArgs e)
        {
            using (frmNhapHang nhapHang = new frmNhapHang())
            {
                nhapHang.FormBorderStyle = FormBorderStyle.None;
                nhapHang.ShowDialog();

                PhieuNhap_Load();
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            lblTitle.Location = new Point((panel1.Width - lblTitle.Width)/2, lblTitle.Location.Y);
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (frmCTPhieuNhap ctPhieuNhap = new frmCTPhieuNhap())
            {
                Session.PhieuNhapData.MaPN = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                ctPhieuNhap.FormBorderStyle = FormBorderStyle.None;
                ctPhieuNhap.ShowDialog();

                PhieuNhap_Load();
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPhieuNhap.Columns[e.ColumnIndex].Name == "Confirm" && !Convert.ToBoolean(dgvPhieuNhap.Rows[e.RowIndex].Cells[4].Value))
                {
                    if (MessageBox.Show("Xác nhận phiếu nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int maPN = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells[0].Value);

                        dt = new DataTable();
                        dt = kn.CreateTable($"SELECT * FROM CTPhieuNhap WHERE MaPN = {maPN}");

                        foreach (DataRow row in dt.Rows)
                        {
                            using (cmd = new SqlCommand())
                            {
                                cmd.Connection = kn.conn;
                                cmd.CommandText = $"UPDATE KhoHang SET TonKho = KhoHang.TonKho + @SLN, KhoHang.DonGiaNhap = @DonGiaNhap, KhoHang.NgayCapNhat = GETDATE() " +
                                    $"WHERE KhoHang.MaSP_Kho = '{row["MaSP_Kho"]}' ";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@SLN", row["SoLuong"]);
                                cmd.Parameters.AddWithValue("@DonGiaNhap", row["DonGia"]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        using (cmd = new SqlCommand())
                        {
                            cmd.Connection = kn.conn;
                            cmd.CommandText = $"UPDATE PhieuNhap SET TrangThai = 1 WHERE MaPN = {maPN}";
                            cmd.ExecuteNonQuery();
                        }

                        PhieuNhap_Load();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmPhieuNhap - dgvPhieuNhap_CellClick Lỗi: " + ex.Message);
            }
        }

        private void dgvPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuNhap.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (e.Value is bool tinhTrang)
                {
                    e.Value = tinhTrang ? "Đã xác nhận" : "Chưa xác nhận";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
