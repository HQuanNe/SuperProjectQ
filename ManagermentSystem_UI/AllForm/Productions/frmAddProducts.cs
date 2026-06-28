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

namespace SuperProjectQ.AllForm.Productions
{
    public partial class frmAddProducts : Form
    {
        public frmAddProducts()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;

        private void CmbProdInStorage()
        {
            string sqlStorage = "SELECT MaSP_Kho, TenSP FROM KhoHang ORDER BY TenSP ASC";
            cmbProdInStorage.DataSource = kn.CreateTable(sqlStorage);
            cmbProdInStorage.DisplayMember = "TenSP";
            cmbProdInStorage.ValueMember = "MaSP_Kho";
        }//Load sản phẩm đang ở trong kho
        private void CmbLoaiBan_Load()
        {
            cmbLoaiBan.DataSource = kn.CreateTable("SELECT MaLoaiBan, TenLoai FROM LoaiBan");
            cmbLoaiBan.DisplayMember = "TenLoai";
            cmbLoaiBan.ValueMember = "MaLoaiBan";
        }
        private void CmbUnit_Load()
        {
            cmbUnit.DataSource = kn.CreateTable("SELECT MaDVT, TenDVT FROM DVTSanPham");
            cmbUnit.DisplayMember = "TenDVT";
            cmbUnit.ValueMember = "MaDVT";
        }
        private void frmAddProducts_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            CmbProdInStorage();
            CmbUnit_Load();
            CmbLoaiBan_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận thêm sản phẩm mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No) return;

                string sqlAddRoom = "INSERT INTO SanPham (MaSP_Menu, MaSP_Kho, TenMatHang, LoaiBan, DinhLuong, DonViTinh, GiaBan, GhiChu) " +
                    "VALUES (@MSPM, @MSPK, @TMH, @LB, @DL, @DVT, @GB, @GC)";
                using (cmd = new SqlCommand(sqlAddRoom, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MSPM", Session.AutoCreateID_String("MaSP_Menu", "SanPham", "SPM"));
                    cmd.Parameters.AddWithValue("@MSPK", cmbProdInStorage.SelectedValue);
                    cmd.Parameters.AddWithValue("@TMH", txtTenMatHang.Text.Trim());
                    cmd.Parameters.AddWithValue("@LB", cmbLoaiBan.SelectedValue);
                    cmd.Parameters.AddWithValue("DL", Convert.ToInt32(txtDinhLuongOrSoLuong.Text.Trim()));
                    cmd.Parameters.AddWithValue("DVT", cmbUnit.SelectedValue);
                    cmd.Parameters.AddWithValue("GB", Convert.ToDecimal(txtGiaBan.Text.Trim().Replace(".", "")));
                    cmd.Parameters.AddWithValue("GC", txtGhiChu.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã thêm sản phẩm mới");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddproducts - btnThem_Click() Lỗi: \n" + ex.Message);
                return;
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cmbUnit.SelectedItem.ToString());
        }
    }
}
