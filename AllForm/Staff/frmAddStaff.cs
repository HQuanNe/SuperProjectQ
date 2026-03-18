using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.Staff
{
    public partial class frmAddStaff : Form
    {
        public frmAddStaff()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;
        private string AutoCreateID()
        {
            string sqlGetMaxID = "SELECT TOP 1 MaNV FROM NhanVien WHERE MaNV NOT LIKE '%QTV%' ORDER BY MaNV DESC";
            dt = new DataTable();
            dt = kn.CreateTable(sqlGetMaxID);

            string target = "NV";
            string id = dt.Rows[0]["MaNV"].ToString().Replace(target, "");
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
        private void frmAddStaff_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");

            txtMaNV.Text = AutoCreateID();
            txtMaNV.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Ghi của thêm
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || cmbGioiTinh.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtChucVu.Text == "")
                {
                    MessageBox.Show("Tất cả các dữ liệu không được để trống!!!");
                    return;
                }
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn thêm DL không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    if (picImageStaff.Tag == null ||string.IsNullOrEmpty(picImageStaff.Tag.ToString()))
                    {
                        MessageBox.Show("Hãy chọn ảnh!!!");
                        return;
                    }

                    string sqlAdd = "INSERT INTO NhanVien(MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SoDienThoai, NgayLamViec, ChucVu, LuongCoBan, HinhAnh) values (@MNV, @TNV, @GT, @NS, @DC, @SDT, @NLV, @CV, @LCB, @HA)";
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
                    cmd.Parameters.AddWithValue("@LCB", txtBasicSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@HA", Path.GetFileName(picImageStaff.Tag.ToString()));
                    cmd.ExecuteNonQuery();

                    string oldFilePath = picImageStaff.Tag.ToString();
                    string newFilePath = Application.StartupPath + $"\\Images\\StaffImage\\{Path.GetFileName(picImageStaff.Tag.ToString())}";
                    File.Copy(oldFilePath, newFilePath, false);

                    MessageBox.Show($"Đã thêm nhân viên mã {txtMaNV.Text} tên: {txtTenNV.Text}");
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddStaff - Lỗi: \n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp"; //định dạng
                    ofd.Title = "Chọn ảnh nhân viên";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        picImageStaff.Image = Image.FromFile(ofd.FileName);                 
                        picImageStaff.Tag = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddStaff - Lỗi: \n" + ex.Message);
                return;
            }
        }
    }
}
