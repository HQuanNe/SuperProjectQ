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

        bool isLoad = false; //
        int count = 0; //tránh việc load luôn dữ liệu danh mục khi mở form (load 3 lần)
        private void Kho_Load()
        {
            Session.SetParameters_Load(); //Load thông số MinTonKho
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
        private void CmbSoLuongSP_Load()
        {
            cmbSoLuongSP.Items.Add($"Số lượng dưới {Session.MinTonKho}");
            cmbSoLuongSP.Items.Add("Đã hết");
        }
        private void CmbDanhMuc_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable("SELECT DISTINCT DanhMuc.MaDM, DanhMuc.TenDM FROM DanhMuc " +
                "INNER JOIN KhoHang ON KhoHang.MaDM = DanhMuc.MaDM");

            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDM";
            cmbDanhMuc.ValueMember = "MaDM";
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvKho);
            Kho_Load();
            CmbSoLuongSP_Load();
            CmbDanhMuc_Load();  
        }
        private void dgvKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKho.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
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
                Session.WarehouseData.MaSP = dgvKho.Rows[e.RowIndex].Cells[0].Value.ToString();
                Session.WarehouseData.TenSP = dgvKho.Rows[e.RowIndex].Cells[1].Value.ToString();
                Session.WarehouseData.DanhMuc = dgvKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                Session.WarehouseData.DonViTinh = dgvKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                Session.WarehouseData.TonKho = dgvKho.Rows[e.RowIndex].Cells[4].Value.ToString();
                Session.WarehouseData.NgayCapNhat = Convert.ToDateTime(dgvKho.Rows[e.RowIndex].Cells[5].Value);
                Session.WarehouseData.DonGiaNhap = Convert.ToDecimal(dgvKho.Rows[e.RowIndex].Cells[6].Value);
                Session.WarehouseData.TrangThai = Convert.ToInt16(dgvKho.Rows[e.RowIndex].Cells[7].Value);
                Session.WarehouseData.HinhAnh = dgvKho.Rows[e.RowIndex].Cells[8].Value.ToString();
                Session.WarehouseData.GhiChu = dgvKho.Rows[e.RowIndex].Cells[9].Value.ToString();


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
                Session.WarehouseData.MaSP = dgvKho.Rows[e.RowIndex].Cells[0].Value.ToString();
                Session.WarehouseData.TenSP = dgvKho.Rows[e.RowIndex].Cells[1].Value.ToString();
                Session.WarehouseData.DanhMuc = dgvKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                Session.WarehouseData.DonViTinh = dgvKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                Session.WarehouseData.TonKho = dgvKho.Rows[e.RowIndex].Cells[4].Value.ToString();
                Session.WarehouseData.NgayCapNhat = Convert.ToDateTime(dgvKho.Rows[e.RowIndex].Cells[5].Value);
                Session.WarehouseData.DonGiaNhap = Convert.ToDecimal(dgvKho.Rows[e.RowIndex].Cells[6].Value);
                Session.WarehouseData.TrangThai = Convert.ToInt16(dgvKho.Rows[e.RowIndex].Cells[7].Value);
                Session.WarehouseData.HinhAnh = dgvKho.Rows[e.RowIndex].Cells[8].Value.ToString();
                Session.WarehouseData.GhiChu = dgvKho.Rows[e.RowIndex].Cells[9].Value.ToString();

                frmDieuChinhKho dcKho = new frmDieuChinhKho();
                dcKho.FormBorderStyle = FormBorderStyle.None;
                dcKho.ShowDialog();
            }
        }

        private void txtTimSP_Leave(object sender, EventArgs e)
        {
            if(txtTimSP.Text.Length == 0)
            {
                lblTimKiem.Visible = true;
                picSearch.Visible = true;
            }
        }

        private void txtTimSP_Click(object sender, EventArgs e)
        {
            lblTimKiem.Visible = false;
            picSearch.Visible = false;
        }

        private void txtTimSP_TextChanged(object sender, EventArgs e)
        {
            string[] textBox = new string[]
            {
                txtTimSP.Text,
            };
            if (!Session.xuLyChuoi(textBox)) return;
            string sqlSearchProd = $"SELECT KhoHang.MaSP_Kho, KhoHang.TenSP, DanhMuc.TenDM, KhoHang.DonViTinh," +
                $"KhoHang.TonKho, KhoHang.NgayCapNhat, KhoHang.DonGiaNhap, KhoHang.TrangThai, KhoHang.GhiChu, KhoHang.HinhAnh " +
                $"FROM KhoHang " +
                $"INNER JOIN DanhMuc ON KhoHang.MaDM = DanhMuc.MaDM " +
                $"WHERE TenSP LIKE N'%{txtTimSP.Text}%'" +
                $"ORDER BY KhoHang.TenSP ASC ";

            dgvKho.DataSource = kn.CreateTable(sqlSearchProd);
        }

        private void cmbSoLuongSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            double quantity = 0;
            switch (cmbSoLuongSP.SelectedIndex)
            {
                case 0:
                    quantity = 100;
                    break;
                case 1:
                    quantity = 0; 
                    break;
                default:
                    break;
            }
            string sqlSearchProd = $"SELECT KhoHang.MaSP_Kho, KhoHang.TenSP, DanhMuc.TenDM, KhoHang.DonViTinh," +
                $"KhoHang.TonKho, KhoHang.NgayCapNhat, KhoHang.DonGiaNhap, KhoHang.TrangThai, KhoHang.GhiChu, KhoHang.HinhAnh " +
                $"FROM KhoHang " +
                $"INNER JOIN DanhMuc ON KhoHang.MaDM = DanhMuc.MaDM " +
                $"WHERE KhoHang.TonKho <= {quantity}" +
                $"ORDER BY KhoHang.TenSP ASC ";


            dgvKho.DataSource = kn.CreateTable(sqlSearchProd);
        }

        private void cmbDanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (count == 3) isLoad = true;
            if (isLoad)
            {
                Console.WriteLine(cmbDanhMuc.SelectedValue);
                string sqlSearchProd = $"SELECT KhoHang.MaSP_Kho, KhoHang.TenSP, DanhMuc.TenDM, KhoHang.DonViTinh," +
                    $"KhoHang.TonKho, KhoHang.NgayCapNhat, KhoHang.DonGiaNhap, KhoHang.TrangThai, KhoHang.GhiChu, KhoHang.HinhAnh " +
                    $"FROM KhoHang " +
                    $"INNER JOIN DanhMuc ON KhoHang.MaDM = DanhMuc.MaDM " +
                    $"WHERE KhoHang.MaDM = '{cmbDanhMuc.SelectedValue}' " +
                    $"ORDER BY KhoHang.TenSP ASC ";


                dgvKho.DataSource = kn.CreateTable(sqlSearchProd);

                count = 3;
            }
            count++;
        }
    }
}
