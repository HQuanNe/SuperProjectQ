using SuperProjectQ.AllForm.KhoHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataAccessLayer;

namespace SuperProjectQ.AllForm.Productions
{
    public partial class frmAdjustProducts : Form
    {
        public frmAdjustProducts()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        private void CmbProdInStorage()
        {
            string sqlStorage = "SELECT MaSP_Kho, TenSP FROM KhoHang ORDER BY TenSP ASC";
            cmbProdInStorage.DataSource = kn.CreateTable(sqlStorage);
            cmbProdInStorage.DisplayMember = "TenSP";
            cmbProdInStorage.ValueMember = "MaSP_Kho";
        }//Load sản phẩm đang ở trong kho
        private void Products_Load()
        {
            try
            { 
                string sqlProd = $"SELECT * FROM SanPham WHERE MaSP_Menu = '{Session.ProductData.MaSP_Menu}'";
                using (dt = new DataTable())
                {
                    dt = kn.CreateTable(sqlProd);

                    cmbProdInStorage.SelectedValue = dt.Rows[0]["MaSP_Kho"].ToString();
                    txtTenMatHang.Text = dt.Rows[0]["TenMatHang"].ToString();
                    cmbLoaiBan.SelectedIndex = Convert.ToInt32(dt.Rows[0]["LoaiBan"]);
                    txtDinhLuongOrSoLuong.Text = dt.Rows[0]["DinhLuong"].ToString();
                    cmbUnit.SelectedItem = dt.Rows[0]["DonViTinh"].ToString();
                    txtGiaBan.Text = dt.Rows[0]["GiaBan"].ToString();
                    txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAdjustproducts - Products_Load() Lỗi: \n" + ex.Message);
                return;
            }
        }
        private void CmbLoaiBan_Load()
        {
            string[] arrLoaiBan = Session.DSLoaiBan.Split(',');
            foreach(string loaiBan in arrLoaiBan)
            {
                cmbLoaiBan.Items.Add(loaiBan);
            }
            cmbLoaiBan.SelectedIndex = 0;
        }
        private void CmbUnit_Load()
        {
            string[] arrUnit = Session.unit.Split(',');
            foreach (string unit in arrUnit)
            {
                cmbUnit.Items.Add(unit);
            }
            cmbUnit.SelectedIndex = 0;
        }
        private void frmAdjustProducts_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            CmbProdInStorage();
            CmbLoaiBan_Load();
            CmbUnit_Load();
            Products_Load(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn sửa sản phẩm này không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlEdit = 
                        "UPDATE  SanPham SET MaSP_Kho = @MSPK, TenMatHang = @TMH, LoaiBan = @LB, DinhLuong = @DL," +
                        "DonViTinh = @DVT, GiaBan = @GB, GhiChu = @GC WHERE MaSP_Menu = @MSPM";
                    using (cmd = new SqlCommand(sqlEdit, kn.conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MSPM", Session.ProductData.MaSP_Menu);
                        cmd.Parameters.AddWithValue("@MSPK", cmbProdInStorage.SelectedValue);
                        cmd.Parameters.AddWithValue("@TMH", txtTenMatHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@LB", cmbLoaiBan.SelectedIndex);
                        cmd.Parameters.AddWithValue("@DL", txtDinhLuongOrSoLuong.Text.Trim());
                        cmd.Parameters.AddWithValue("@DVT", cmbUnit.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@GB", txtGiaBan.Text.Trim().Replace(".", ""));
                        cmd.Parameters.AddWithValue("@GC", txtGhiChu.Text.Trim());
                        cmd.ExecuteNonQuery();
                    };

                    MessageBox.Show($"Đã sửa");
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Mã bị trùng, vui lòng điền lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
                MessageBox.Show("frmAdjustProducts - btnConfirm_Click() Lỗi: " + ex.Number + " " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa sản phẩm này không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                using (frmXacNhan xacNhan = new frmXacNhan())
                {
                    xacNhan.FormBorderStyle = FormBorderStyle.None;
                    xacNhan.ShowDialog();
                }
                if (Session.isDeleted)
                {
                    string sqlDel = "DELETE SanPham WHERE MaSP_Menu = @MSPM";
                    using (cmd = new SqlCommand(sqlDel, kn.conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MSPM", Session.ProductData.MaSP_Menu);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Đã xoá");
                    }
                    ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAdjustProducts - btnDelete_Click() Lỗi: " + ex.Message);
                return;
            }
        }
    }
}
