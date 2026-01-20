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

namespace SuperProjectQ.FrmMixed
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd = null;
        DataTable dt = null;
        bool flag = true;
        private void Lock_Control()
        {
            btnGhi.Visible = false;
            btnKoGhi.Visible = false;

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnBack.Visible = true;
        }
        private void UnLock_Control()
        {
            btnGhi.Visible = true;
            btnKoGhi.Visible = true;

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnBack.Visible = false;
        }
        private void ReadOnly_On()
        {
            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            dtpNamSinh.Enabled = false;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            dtpNgayLamViec.Enabled = false;
            txtChucVu.ReadOnly = true;
            txtSDT.ReadOnly = true;

            cmbGioiTinh.Enabled = false;
        }
        private void ReadOnly_Off()
        {
            txtMaNV.ReadOnly = false;
            txtTenNV.ReadOnly = false;
            dtpNamSinh.Enabled = true;
            txtDiaChi.ReadOnly = false;
            txtSDT.ReadOnly = false;
            dtpNgayLamViec.Enabled = true;
            txtChucVu.ReadOnly = false;
            txtSDT.ReadOnly = false;

            cmbGioiTinh.Enabled = true;
        }
        private void Reset_Text()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtSDT.Clear();
            txtSDT.Clear();
            txtMaNV.Focus();
        }
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
        private string AutoCreateID()
        {
            string sqlGetMaxID = "SELECT TOP 1 MaNV FROM NhanVien WHERE MaNV NOT LIKE '%QTV%' ORDER BY MaNV DESC";
            dt = new DataTable();
            dt = kn.CreateTable(sqlGetMaxID);
            string id = null;
            foreach (DataRow dr in dt.Rows)
            {
                id = dr["MaNV"].ToString();
            }
            string target = "NV";
            id = id.Replace(target, "");
            int tangMa = Convert.ToInt16(id) + 1;
            string newID = null;
            //Định dạng lại mã nếu <10 thì thêm 2 số 0, <100 thì thêm 1 số 0
            if (tangMa < 10)
                newID = target + "00" + tangMa.ToString();
            else if (tangMa < 100)
                newID = target + "0" + tangMa.ToString();
            else
                newID = target + tangMa.ToString();
            return newID;
        }
        private void Load_DB()
        {
            try
            {
                string sqlNhanVien = "SELECT *FROM NhanVien WHERE MaNV NOT LIKE '%QTV%'";
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
                Load_DB();
                ReadOnly_On();
                Lock_Control();
                dgvNhanVien.AutoGenerateColumns = false;
                //Thêm giới tính cho cmb
                cmbGioiTinh.Items.Add("Nam");
                cmbGioiTinh.Items.Add("Nữ");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL" + ex.Message);
                return;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                //Ghi của thêm
                if (flag == true)
                {
                    if (txtMaNV.Text == "" || txtTenNV.Text == "" || cmbGioiTinh.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtChucVu.Text == "")
                    {
                        MessageBox.Show("Tất cả các dữ liệu không được để trống!!!");
                        return;
                    }
                    else
                    {
                        DialogResult traloi;
                        traloi = MessageBox.Show("Bạn có muốn thêm DL không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traloi == DialogResult.Yes)
                        {
                            string sqlAdd = "INSERT INTO NhanVien(MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SoDienThoai, NgayLamViec, ChucVu) values (@MNV, @TNV, @GT, @NS, @DC, @SDT, @NLV, @CV)";
                            cmd = new SqlCommand(sqlAdd, kn.conn);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MNV", AutoCreateID());
                            cmd.Parameters.AddWithValue("@TNV", txtTenNV.Text.Trim());
                            cmd.Parameters.AddWithValue("@GT", cmbGioiTinh.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@NS", dtpNamSinh.Value);
                            cmd.Parameters.AddWithValue("@DC", txtDiaChi.Text.Trim());
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                            cmd.Parameters.AddWithValue("@NLV", dtpNgayLamViec.Value);
                            cmd.Parameters.AddWithValue("@CV", txtChucVu.Text.Trim());
                            cmd.ExecuteNonQuery();
                            Load_DB();
                            FocusDataByID(txtMaNV.Text.Trim());
                            MessageBox.Show($"Đã thêm nhân viên mã {txtMaNV.Text} tên: {txtTenNV.Text}");
                            Reset_Text();
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                //Ghi của sửa
                else if (flag == false)
                {
                    if (txtMaNV.Text == "" || txtTenNV.Text == "" || cmbGioiTinh.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtChucVu.Text == "")
                    {
                        MessageBox.Show("Tất cả các dữ liệu không được để trống!!!");
                    }
                    else
                    {
                        DialogResult traloi;
                        traloi = MessageBox.Show("Bạn có muốn sửa DL không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traloi == DialogResult.Yes)
                        {
                            string sqlEdit = "" +
                                "UPDATE  NhanVien SET MaNV = (@MNV), TenNV = (@TNV), GioiTinh = @GT, NamSinh = (@NS)," +
                                "DiaChi = (@DC), SoDienThoai = (@SDT), NgayLamViec = @NLV, ChucVu = @CV  WHERE MaNV = (@MNV)";
                            cmd = new SqlCommand(sqlEdit, kn.conn);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MNV", AutoCreateID());
                            cmd.Parameters.AddWithValue("@TNV", txtTenNV.Text.Trim());
                            cmd.Parameters.AddWithValue("@GT", cmbGioiTinh.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@NS", dtpNamSinh.Value);
                            cmd.Parameters.AddWithValue("@DC", txtDiaChi.Text.Trim());
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                            cmd.Parameters.AddWithValue("@NLV", dtpNgayLamViec.Value);
                            cmd.Parameters.AddWithValue("@CV", txtChucVu.Text.Trim());
                            cmd.ExecuteNonQuery();
                            Load_DB();
                            FocusDataByID(txtMaNV.Text.Trim());
                            MessageBox.Show($"Đã sửa nhân viên mã {txtMaNV.Text} tên: {txtTenNV.Text}");
                            Reset_Text();
                        }
                        else
                        {
                            return;
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Mã nhân viên bị trùng, vui lòng điền lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
                MessageBox.Show("Lỗi: " + ex.Number + " " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLock_Control();
            ReadOnly_Off();
            txtMaNV.Text = AutoCreateID();
            flag = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnLock_Control();
            ReadOnly_Off();
            flag = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Không có thông tin để xoá!!!");
                return;
            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xoá dữ liệu này không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    string sqlDel = "DELETE NhanVien Where MaNV = (@MNV)";
                    cmd = new SqlCommand(sqlDel, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MNV", txtMaNV.Text.Trim());
                    cmd.ExecuteNonQuery();
                    Load_DB();
                    MessageBox.Show($"Đã xoá mã NV: {txtMaNV.Text} tên: {txtTenNV.Text}");
                }
                else
                {
                    return;
                }
            }
        }

        private void btnKoGhi_Click(object sender, EventArgs e)
        {
            Lock_Control();
            ReadOnly_On();
            flag = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainUI mainUI = new frmMainUI();
            mainUI.Visible = true;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value?.ToString();
                txtTenNV.Text = row.Cells[1].Value?.ToString();
                cmbGioiTinh.Text = row.Cells[2].Value?.ToString();
                if (row.Cells[3].Value?.ToString() != null && row.Cells[3].Value != DBNull.Value) dtpNamSinh.Value = DateTime.Parse(row.Cells[3].Value?.ToString());
                txtDiaChi.Text = row.Cells[4].Value?.ToString();
                txtSDT.Text = row.Cells[5].Value?.ToString();
                if (row.Cells[6].Value?.ToString() != null && row.Cells[6].Value != DBNull.Value) dtpNgayLamViec.Value = DateTime.Parse(row.Cells[6].Value?.ToString());
                txtChucVu.Text = row.Cells[7].Value?.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radSearchByID.Checked)
            {
                dgvNhanVien.DataSource = null;
                string sqlSearchByID = $"SELECT *FROM NhanVien WHERE MaNV LIKE '%{txtSearch.Text.Trim()}%' AND MaNV NOT LIKE '%QTV%'";
                dgvNhanVien.DataSource = kn.CreateTable(sqlSearchByID);
            }
            if (radSearchByName.Checked)
            {
                dgvNhanVien.DataSource = null;
                string sqlSearchByID = $"SELECT *FROM NhanVien WHERE TenNV LIKE '%{txtSearch.Text.Trim()}%' AND MaNV NOT LIKE '%QTV%'";
                dgvNhanVien.DataSource = kn.CreateTable(sqlSearchByID);
            }
        }
    }
}
