using Mscc.GenerativeAI;
using SuperProjectQ.AllForm.KhoHang;
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
    public partial class frmAdjustStaff : Form
    {
        public frmAdjustStaff()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string rootImagePath = Application.StartupPath + "\\Images\\StaffImage\\";
        bool hasImage = false;
        bool changeImage = false;
        private void frmAdjustStaff_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();

                txtMaNV.Enabled = false;
                cmbGioiTinh.Items.Add("Nam");
                cmbGioiTinh.Items.Add("Nữ");

                txtMaNV.Text = Session.StaffData.MaNV;
                txtTenNV.Text = Session.StaffData.TenNV;
                cmbGioiTinh.SelectedItem = Session.StaffData.GioiTinh;
                dtpNamSinh.Value = Session.StaffData.NamSinh;
                txtDiaChi.Text = Session.StaffData.DiaChi;
                txtSDT.Text = Session.StaffData.SoDienThoai;
                dtpNgayLamViec.Value = Session.StaffData.NgayLamViec;
                txtChucVu.Text = Session.StaffData.ChucVu;
                txtBasicSalary.Text = Session.StaffData.LuongCoBan.ToString("#,##0");

                if (!string.IsNullOrEmpty(Session.StaffData.HinhAnh)) picImageStaff.Image = Image.FromFile(Application.StartupPath + $"\\Images\\StaffImage\\{Session.StaffData.HinhAnh}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAdjustStaff - Lỗi:\n" + ex.Message);
                return;
            }
        }
        private void btnAdjustImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp"; //định dạng
                ofd.Title = "Chọn ảnh nhân viên";

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    if(picImageStaff.Image != null || !string.IsNullOrEmpty(Session.StaffData.HinhAnh))
                    {
                        hasImage = true;
                        changeImage = true;
                        picImageStaff.Image.Dispose();
                        picImageStaff.Image = null;
                    }
                    else hasImage = false;

                    picImageStaff.Image = Image.FromFile(ofd.FileName);
                    picImageStaff.Tag = ofd.FileName;
                }
                else changeImage = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    using (frmXacNhan xacNhan = new frmXacNhan())
                    {
                        xacNhan.FormBorderStyle = FormBorderStyle.None;
                        xacNhan.ShowDialog();
                    }
                    if (Session.isDeleted)
                    {
                        string sqlDel = "DELETE NhanVien Where MaNV = (@MNV)";
                        cmd = new SqlCommand(sqlDel, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MNV", txtMaNV.Text.Trim());
                        cmd.ExecuteNonQuery();

                        if (File.Exists(rootImagePath + Session.StaffData.HinhAnh)) //File.Exists: kiểm tra tệp có tồn tại không
                        {
                            try
                            {
                                picImageStaff.Dispose();
                                picImageStaff.Image = null;

                                //dọn bộ nhớ
                                GC.Collect();
                                GC.WaitForPendingFinalizers();

                                File.Delete(rootImagePath + Session.StaffData.HinhAnh); //Xoá ảnh
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi xoá ảnh: \n" + ex.Message);
                                return;
                            }
                        }
                        Session.isDeleted = false;

                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || cmbGioiTinh.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtChucVu.Text == "")
                {
                    MessageBox.Show("Tất cả các dữ liệu không được để trống!!!");
                }
                else
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có muốn sửa nhân viên này không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (traloi == DialogResult.Yes)
                    {
                        string sqlEdit = "" +
                            "UPDATE  NhanVien SET TenNV = (@TNV), GioiTinh = @GT, NamSinh = (@NS)," +
                            "DiaChi = (@DC), SoDienThoai = (@SDT), NgayLamViec = @NLV, ChucVu = @CV, LuongCoBan = @LCB, HinhAnh = @HA WHERE MaNV = (@MNV)";
                        cmd = new SqlCommand(sqlEdit, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MNV", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@TNV", txtTenNV.Text.Trim());
                        cmd.Parameters.AddWithValue("@GT", cmbGioiTinh.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@NS", dtpNamSinh.Value);
                        cmd.Parameters.AddWithValue("@DC", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@NLV", dtpNgayLamViec.Value); ;
                        cmd.Parameters.AddWithValue("@CV", txtChucVu.Text.Trim());
                        cmd.Parameters.AddWithValue("@LCB", Convert.ToDecimal(txtBasicSalary.Text.Trim().Replace(".", "")));
                        cmd.Parameters.AddWithValue("@HA", !(picImageStaff.Tag == null) ? Path.GetFileName(picImageStaff.Tag.ToString()) : Session.StaffData.HinhAnh);
                        cmd.ExecuteNonQuery();

                        if (hasImage && changeImage)
                        {
                            File.Delete($"{rootImagePath}{Session.StaffData.HinhAnh}");
                            File.Copy(picImageStaff.Tag.ToString(), $"{rootImagePath}{Path.GetFileName(picImageStaff.Tag.ToString())}", false);
                        }
                        else if (!hasImage && changeImage) File.Copy(picImageStaff.Tag.ToString(), $"{rootImagePath}{Path.GetFileName(picImageStaff.Tag.ToString())}", false);

                            MessageBox.Show($"Đã sửa nhân viên mã {txtMaNV.Text} tên: {txtTenNV.Text}");
                    }
                    else
                    {
                        return;
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

        private void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            txtBasicSalary.Text = decimal.TryParse(txtBasicSalary.Text.Replace(".", ""), out decimal value) ? value.ToString("#,##0") 
                : txtBasicSalary.Text.Remove(txtBasicSalary.Text.Length - 1);
            txtBasicSalary.SelectionStart = txtBasicSalary.Text.Length;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 10) txtSDT.Text = txtSDT.Text.Remove(10, 1);

            txtSDT.Text = int.TryParse(txtSDT.Text, out int value) ? value.ToString() :
                txtSDT.Text.Length <= 1 ? "" : txtSDT.Text.Remove(txtSDT.Text.Length - 1, 1);

            txtSDT.SelectionStart = txtSDT.Text.Length;
        }
    }
}
