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
using DataAccessLayer;

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
        private void CmbChucVu_Load()
        {
            try
            {
                string sqlChucVu = "SELECT MaCV, TenCV FROM ChucVu";
                dt = kn.CreateTable(sqlChucVu);
                cmbChucVu.DataSource = dt;
                cmbChucVu.DisplayMember = "TenCV";
                cmbChucVu.ValueMember = "MaCV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAdjustStaff - CmbChucVu_Load()\n\rLỗi: " + ex.Message);
                this.Close();
            }
        }
        private void frmAddStaff_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            CmbChucVu_Load();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedItem = "Nam";

            txtMaNV.Text = AutoCreateID();
            txtMaNV.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Ghi của thêm
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || cmbGioiTinh.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
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
                    if (File.Exists(Application.StartupPath + $"\\Images\\StaffImage\\{Path.GetFileName(picImageStaff.Tag.ToString())}"))
                    {
                        MessageBox.Show("Ảnh nhân viên đã được sở hữu bởi nhân viên khác \n" +
                        "Vui lòng chọn ảnh khác hoặc đổi tên ảnh");
                        return;
                    }
                    string[] txt = new string[]
                    {
                        txtBasicSalary.Text,
                        txtSDT.Text,
                    };
                    if (!Session.XuLySo(txt))
                    {MessageBox.Show("SĐT hoặc lương phải là chữ số!!!"); return; }

                    string sqlAdd = "INSERT INTO NhanVien(MaNV, TenNV, GioiTinh, NamSinh, DiaChi, SoDienThoai, NgayLamViec, MaChucVu, LuongCoBan, HinhAnh) values (@MNV, @TNV, @GT, @NS, @DC, @SDT, @NLV, @MCV, @LCB, @HA)";
                    cmd = new SqlCommand(sqlAdd, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MNV", AutoCreateID());
                    cmd.Parameters.AddWithValue("@TNV", txtTenNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@GT", cmbGioiTinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@NS", dtpNamSinh.Value);
                    cmd.Parameters.AddWithValue("@DC", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@NLV", dtpNgayLamViec.Value);
                    cmd.Parameters.AddWithValue("@MCV", cmbChucVu.SelectedValue);
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

        private void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicSalary.Text) && int.TryParse(txtBasicSalary.Text.Replace(".", ""), out int salary)) return;
            txtBasicSalary.Text = Convert.ToDecimal(txtBasicSalary.Text.Replace(".", "")).ToString("#,##0");
            txtBasicSalary.SelectionStart = txtBasicSalary.Text.Length;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
