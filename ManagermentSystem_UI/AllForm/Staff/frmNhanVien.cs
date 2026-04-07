using SuperProjectQ.AllForm.Staff;
using SuperProjectQ.Frm_Main_Login_Register;
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

namespace SuperProjectQ.FrmMixed
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        //private void Reset_Text()
        //{
        //    txtMaNV.Clear();
        //    txtTenNV.Clear();
        //    txtDiaChi.Clear();
        //    txtChucVu.Clear();
        //    txtSDT.Clear();
        //    txtSDT.Clear();
        //    txtMaNV.Focus();
        //}
        private void FocusDataByID(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (row.Cells["MaNV"].Value != null && row.Cells["MaNV"].Value.ToString() == id)
                {
                    // Bỏ chọn các dòng cũ
                    dgvNhanVien.ClearSelection();
                    // Chọn dòng hiện tại
                    row.Selected = true;
                    // Đặt ô hiện tại để cái khung hình chữ nhật bao quanh dòng đó
                    dgvNhanVien.CurrentCell = row.Cells[0];

                    // Tự động cuộn tới dòng nếu nằm ở phía dưới
                    dgvNhanVien.FirstDisplayedScrollingRowIndex = row.Index;

                    return;
                }
            }
        }
        private void Staff_Load()
        {
            try
            {
                string sqlNhanVien = "SELECT * FROM NhanVien";
                dgvNhanVien.DataSource = kn.CreateTable(sqlNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL\n\rLỗi: " + ex.Message);
                this.Close();
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();

                Session.StandardDataGridView(dgvNhanVien);
                Staff_Load();

                dgvNhanVien.AutoGenerateColumns = false;
                //Thêm giới tính cho cmb

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL" + ex.Message);
                return;
            }
        }

        //private void btnGhi_Click(object sender, EventArgs e)
        //{

        //}

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = null;
            string sqlSearchByID = $"SELECT * FROM NhanVien WHERE MaNV LIKE '%{txtSearch.Text.Trim()}%' OR " +
                $"TenNV LIKE '%{txtSearch.Text.Trim()}%' OR " +
                $"DiaChi LIKE '%{txtSearch.Text.Trim()}%' OR " +
                $"SoDienThoai LIKE '%{txtSearch.Text.Trim()}%' ";
            dgvNhanVien.DataSource = kn.CreateTable(sqlSearchByID);
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            frmAddStaff addStaff = new frmAddStaff();
            addStaff.FormBorderStyle = FormBorderStyle.None;
            addStaff.ShowDialog();
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Session.StaffData.MaNV = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            Session.StaffData.TenNV = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
            Session.StaffData.GioiTinh = dgvNhanVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
            Session.StaffData.NamSinh = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells["NamSinh"].Value);
            Session.StaffData.DiaChi = dgvNhanVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            Session.StaffData.SoDienThoai = dgvNhanVien.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
            Session.StaffData.Email = dgvNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            Session.StaffData.NgayLamViec = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells["NgayLamViec"].Value);
            Session.StaffData.ChucVu = dgvNhanVien.Rows[e.RowIndex].Cells["ChucVu"].Value.ToString();
            Session.StaffData.LuongCoBan = Convert.ToDecimal(dgvNhanVien.Rows[e.RowIndex].Cells["LuongCoBan"].Value);
            Session.StaffData.HinhAnh = dgvNhanVien.Rows[e.RowIndex].Cells["HinhAnh"].Value.ToString();

            frmAdjustStaff adjustStaff = new frmAdjustStaff();
            adjustStaff.FormBorderStyle = FormBorderStyle.None;
            adjustStaff.ShowDialog();

            Staff_Load();
        }
    }
}
