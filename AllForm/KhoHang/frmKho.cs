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

namespace SuperProjectQ.AllForm.Other
{
    public partial class frmKho : Form
    {
        public frmKho()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt = null;
        private void Kho_Load()
        {
            Session.SetParameters_Load(); //Load thông số MinTonKho
            Session.StandardDataGridView(dgvKho);
            dt = kn.CreateTable("SELECT KhoHang.MaSP_Kho, KhoHang.TenSP, DanhMuc.TenDM, KhoHang.DonViTinh, " +
                "KhoHang.TonKho, KhoHang.NgayCapNhat, KhoHang.DonGiaNhap, KhoHang.TrangThai, KhoHang.GhiChu, KhoHang.HinhAnh " +
                "FROM KhoHang " +
                "INNER JOIN DanhMuc ON KhoHang.MaDM = DanhMuc.MaDM " +
                "ORDER BY KhoHang.TenSP ASC");
            dgvKho.DataSource = dt;
            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (Convert.ToDouble(row.Cells["TonKho"].Value) < Session.MinTonKho)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (Convert.ToDouble(row.Cells["TonKho"].Value) ==0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }

                dgvKho.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            }
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            Kho_Load();
        }
        private void dgvKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvKho.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                if (e.Value is bool tinhTrang)
                {
                    e.Value = tinhTrang ? "Đang bán" : "Dừng bán";
                    e.FormattingApplied = true;
                }
            }
        }
        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKho.Columns[e.ColumnIndex].Name == "ChiTiet")
            {
                Session.DuLieuKhoHang.MaSP = dgvKho.Rows[e.RowIndex].Cells[1].Value.ToString();
                Session.DuLieuKhoHang.TenSP = dgvKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                Session.DuLieuKhoHang.DanhMuc = dgvKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                Session.DuLieuKhoHang.DonViTinh = dgvKho.Rows[e.RowIndex].Cells[4].Value.ToString();
                Session.DuLieuKhoHang.TonKho = dgvKho.Rows[e.RowIndex].Cells[5].Value.ToString();
                Session.DuLieuKhoHang.NgayCapNhat = Convert.ToDateTime(dgvKho.Rows[e.RowIndex].Cells[6].Value);
                Session.DuLieuKhoHang.DonGiaNhap = Convert.ToDecimal(dgvKho.Rows[e.RowIndex].Cells[7].Value);
                Session.DuLieuKhoHang.TrangThai = Convert.ToInt16(dgvKho.Rows[e.RowIndex].Cells[8].Value);
                Session.DuLieuKhoHang.GhiChu = dgvKho.Rows[e.RowIndex].Cells[9].Value.ToString();
                Session.DuLieuKhoHang.HinhAnh = dgvKho.Rows[e.RowIndex].Cells[10].Value.ToString();

                frmDieuChinhKho dcKho = new frmDieuChinhKho();
                dcKho.FormBorderStyle = FormBorderStyle.None;
                dcKho.ShowDialog();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmThemKhoHang addSP = new frmThemKhoHang();

            addSP.FormBorderStyle = FormBorderStyle.None;
            addSP.ShowDialog();
        }

        private void dgvKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Session.DuLieuKhoHang.MaSP = dgvKho.Rows[e.RowIndex].Cells[1].Value.ToString();
                Session.DuLieuKhoHang.TenSP = dgvKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                Session.DuLieuKhoHang.DanhMuc = dgvKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                Session.DuLieuKhoHang.DonViTinh = dgvKho.Rows[e.RowIndex].Cells[4].Value.ToString();
                Session.DuLieuKhoHang.TonKho = dgvKho.Rows[e.RowIndex].Cells[5].Value.ToString();
                Session.DuLieuKhoHang.NgayCapNhat = Convert.ToDateTime(dgvKho.Rows[e.RowIndex].Cells[6].Value);
                Session.DuLieuKhoHang.DonGiaNhap = Convert.ToDecimal(dgvKho.Rows[e.RowIndex].Cells[7].Value);
                Session.DuLieuKhoHang.TrangThai = Convert.ToInt16(dgvKho.Rows[e.RowIndex].Cells[8].Value);
                Session.DuLieuKhoHang.GhiChu = dgvKho.Rows[e.RowIndex].Cells[9].Value.ToString();
                Session.DuLieuKhoHang.HinhAnh = dgvKho.Rows[e.RowIndex].Cells[10].Value.ToString();

                frmDieuChinhKho dcKho = new frmDieuChinhKho();
                dcKho.FormBorderStyle = FormBorderStyle.None;
                dcKho.ShowDialog();
            }
        }
    }
}
