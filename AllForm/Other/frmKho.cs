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
        SqlCommand cmd = null;

        bool flag = false; //Biến cờ True: Thêm DL, False: Sửa

        private void Button_Control(bool flag) //Ẩn hiện nút
        {
            if (flag)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnGhi.Visible = true;
                btnKoGhi.Visible = true;
            }
            else
            {
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
                btnGhi.Visible = false;
                btnKoGhi.Visible = false;
            }
        }
        private void Reset_Text()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDVT.Clear();
            txtTonKho.Clear();
            txtDonGiaNhap.Clear();
            txtTrangThai.Clear();
            txtGhiChu.Clear();

            txtMaSP.Focus();
        }//reset về rỗng
        private void CmbDanhMuc_Load()
        {
            dt = kn.CreateTable("SELECT * FROM DanhMuc");
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDM";
            cmbDanhMuc.ValueMember = "MaDM";
        }
        private void Kho_Load()
        {
            Session.SetParameters_Load(); //Load thông số MinTonKho

            dt = kn.CreateTable("SELECT * FROM KhoHang ORDER BY KhoHang.TenSP ASC");
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
            }

            string sqlDM = "SELECT * FROM DanhMuc";
            (dgvKho.Columns["MaDM"] as DataGridViewComboBoxColumn).DataSource = kn.CreateTable(sqlDM);
            (dgvKho.Columns["MaDM"] as DataGridViewComboBoxColumn).DisplayMember = "TenDM";
            (dgvKho.Columns["MaDM"] as DataGridViewComboBoxColumn).ValueMember = "MaDM";
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            CmbDanhMuc_Load();
            Kho_Load();
            Button_Control(false);

            plInfo.Enabled = false;
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKho.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells[0].Value.ToString();
                txtTenSP.Text = row.Cells[1].Value.ToString();
                cmbDanhMuc.SelectedValue = row.Cells[2].Value.ToString();
                txtDVT.Text = row.Cells[3].Value.ToString();
                txtTonKho.Text = row.Cells[4].Value.ToString();
                dtNgayCapNhat.Text = row.Cells[5].Value.ToString();
                txtDonGiaNhap.Text = row.Cells[6].Value.ToString();
                txtTrangThai.Text = row.Cells[7].Value.ToString();
                txtGhiChu.Text = row.Cells[8].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không, không thể khôi phục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sqlDelete = "DELETE FROM KhoHang WHERE MaSP = @MaSP";
                    cmd = new SqlCommand(sqlDelete, kn.conn);
                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
                    cmd.ExecuteNonQuery();
                    Kho_Load();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (txtMaSP.Text == "" || txtTenSP.Text == "" || txtDVT.Text == "" || txtTonKho.Text == "" || dtNgayCapNhat.Text == "" || txtDonGiaNhap.Text == "" || txtTrangThai.Text == "")
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
                            string sqlAdd = "INSERT INTO KhoHang(MaSP, TenSP, MaDM, DonViTinh, TonKho, NgayCapNhat, DonGiaNhap, TrangThai, GhiChu) " +
                                "values (@MaSP, @TenSP, @MDM, @DVT, @TonKho, @NgayCapNhat, @DonGiaNhap, @TrangThai, @GhiChu)";
                            cmd = new SqlCommand(sqlAdd, kn.conn);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@MaDM", cmbDanhMuc.SelectedValue);
                            cmd.Parameters.AddWithValue("@DVT", txtDVT.Text.Trim());
                            cmd.Parameters.AddWithValue("@TonKho", Convert.ToDouble(txtTonKho.Text.Trim()));
                            cmd.Parameters.AddWithValue("@NgayCapNhat", Convert.ToDateTime(dtNgayCapNhat.Text.Trim()));
                            cmd.Parameters.AddWithValue("@DonGiaNhap", Convert.ToDecimal(txtDonGiaNhap.Text.Trim()));
                            cmd.Parameters.AddWithValue("@TrangThai", Convert.ToBoolean(txtTrangThai.Text.Trim()));
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                            cmd.ExecuteNonQuery();
                            //FocusDataByID(txtMaSP.Text.Trim());
                            MessageBox.Show($"Đã thêm sản phẩm mã {txtMaSP.Text} tên: {txtTenSP.Text}");
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
                    if (txtMaSP.Text == "" || txtTenSP.Text == "" || txtDVT.Text == "" || txtTonKho.Text == "" || dtNgayCapNhat.Text == "" || txtDonGiaNhap.Text == "" || txtTrangThai.Text == "")
                    {
                        MessageBox.Show("Tất cả các dữ liệu không được để trống!!!");
                        return;
                    }
                    else
                    {
                        DialogResult traloi;
                        traloi = MessageBox.Show("Bạn có muốn sửa DL không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traloi == DialogResult.Yes)
                        {
                            string sqlEdit = "" +
                                "UPDATE  KhoHang SET MaSP = (@MaSP), TenSP = (@TenSP), MaDM = (@MaDM), DonViTinh = (@DVT), TonKho = (@TonKho), " +
                                "NgayCapNhat = (@NgayCapNhat), DonGiaNhap = (@DonGiaNhap), TrangThai = (@TrangThai), GhiChu = (@GhiChu)  WHERE MaSP = (@MaSP)";
                            cmd = new SqlCommand(sqlEdit, kn.conn);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@MaDM", cmbDanhMuc.SelectedValue);
                            cmd.Parameters.AddWithValue("@DVT", txtDVT.Text.Trim());
                            cmd.Parameters.AddWithValue("@TonKho", Convert.ToDouble(txtTonKho.Text.Trim()));
                            cmd.Parameters.AddWithValue("@NgayCapNhat", Convert.ToDateTime(dtNgayCapNhat.Text.Trim()));
                            cmd.Parameters.AddWithValue("@DonGiaNhap", Convert.ToDecimal(txtDonGiaNhap.Text.Trim()));
                            cmd.Parameters.AddWithValue("@TrangThai", Convert.ToBoolean(txtTrangThai.Text.Trim()));
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                            cmd.ExecuteNonQuery();
                            //FocusDataByID(txtMaSP.Text.Trim());
                            MessageBox.Show($"Đã sửa sản phẩm mã {txtMaSP.Text} tên: {txtTenSP.Text}");
                            Reset_Text();
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                Kho_Load();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng điền lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 2628:
                        MessageBox.Show("Dữ liệu nhập vào quá lớn, vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
                MessageBox.Show("Lỗi: " + ex.Number + " " + ex.Message);
            }
        }

        private void btnKoGhi_Click(object sender, EventArgs e)
        {
            Button_Control(false);
            Reset_Text();

            plInfo.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = true;
            plInfo.Enabled = true;
            txtTrangThai.Text = "True";
            txtMaSP.Enabled = false;
            txtMaSP.Text = Session.AutoCreateID_String("MaSP", "KhoHang", "SP");

            Button_Control(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            plInfo.Enabled = true;

            Button_Control(true);
        }
    }
}
