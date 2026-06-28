using DataAccessLayer;
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

namespace SuperProjectQ.AllForm.Voucher
{
    public partial class frmAdjustVoucher : Form
    {
        public frmAdjustVoucher()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string destPath = Application.StartupPath + @"\Images\VoucherImage\";
        string maVoucher = Session.VoucherData.maVoucher;
        string imageFileName = "";

        bool isImageChanged = false;

        private void CmbType_Load()
        {
            try
            {
                DataTable dt = kn.CreateTable("SELECT * FROM LoaiGiamGia");
                cmbLoaiGiamGia.DataSource = dt;
                cmbLoaiGiamGia.DisplayMember = "MoTa";
                cmbLoaiGiamGia.ValueMember = "LoaiGiamGia";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddVoucher - CmbType_Load Lỗi: " + ex.Message);
            }
        }
        private bool ValidateCheck()
        {
            if (double.TryParse(txtGiamToiDa.Text, out double giaTriGiam) ||
                double.TryParse(txtGTDHTT.Text, out double giaTriGiamToiThieu) ||
                int.TryParse(txtSLPhatHanh.Text, out int soLuongPhatHanh))
            {
                return true;
            }
            return false;
        }
        private void Voucher_Load() {             
            try
            {
                dt = new DataTable();
                dt = kn.CreateTable($"SELECT * FROM Voucher WHERE MaVoucher = '{maVoucher}'");
                if (dt.Rows.Count > 0)
                {
                    txtMaVoucher.Text = dt.Rows[0]["MaVoucher"].ToString();
                    txtTenVoucher.Text = dt.Rows[0]["TenVoucher"].ToString();
                    cmbLoaiGiamGia.SelectedValue = dt.Rows[0]["LoaiGiamGia"].ToString();
                    txtGiaTriGiam.Text = dt.Rows[0]["GiaTriGiam"].ToString();
                    txtGiamToiDa.Text = dt.Rows[0]["GiamToiDa"].ToString();
                    txtGTDHTT.Text = dt.Rows[0]["GTDonHangToiThieu"].ToString();
                    txtMaPhatHanh.Text = dt.Rows[0]["MaPhatHanh"].ToString();
                    txtSLPhatHanh.Text = dt.Rows[0]["SoLuongPhatHanh"].ToString();
                    txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                    txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                    imageFileName = dt.Rows[0]["HinhAnh"].ToString();

                    picImageVoucher.Image = Image.FromFile(destPath + imageFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAdjustVoucher - Voucher_Load Lỗi: " + ex.Message);
            }
        }
        private void frmAdjustVoucher_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            Voucher_Load();
            CmbType_Load();
        }

        private void btnAdjustImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn hình ảnh cho voucher";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImageVoucher.Image = Image.FromFile(ofd.FileName);
                picImageVoucher.Tag = ofd.FileName;
                isImageChanged = true;
            }
            else{
                isImageChanged = false;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtTenVoucher.Text == "" || txtGiamToiDa.Text == "" || txtGTDHTT.Text == "" || txtSLPhatHanh.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            if (!ValidateCheck())
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng cho các trường số!");
                return;
            }
            if (txtMaPhatHanh.Text.Length != 10 && ckcPhatHanhMa.Checked)
            {
                MessageBox.Show("Mã phát hành phải có đúng 10 ký tự!"); return;
            }
            if (File.Exists(destPath + imageFileName) && isImageChanged)
            {
                MessageBox.Show("Hình ảnh đã tồn tại! Vui lòng đổi tên hình ảnh hoặc chọn hình khác!"); return;
            }
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT MaPhatHanh FROM Voucher WHERE MaPhatHanh = '{txtMaPhatHanh.Text}' AND MaVoucher <> '{txtMaVoucher.Text.Trim()}'");
                if (dt.Rows.Count > 0 && txtMaPhatHanh.Text.Length == 10)
                {
                    MessageBox.Show("Mã phát hành đã tồn tại! Vui lòng đổi mã phát hành khác!"); return;
                }
            }

            using (cmd = new SqlCommand())
            {
                cmd.Connection = kn.conn;
                cmd.CommandText = "UPDATE Voucher SET TenVoucher = @TenVoucher, LoaiGiamGia = @LoaiGiamGia, GiaTriGiam = @GiaTriGiam, " +
                    "GiamToiDa = @GiamToiDa, GTDonHangToiThieu = @GTDonHangToiThieu, MaPhatHanh = @MaPhatHanh, SoLuongPhatHanh = @SoLuongPhatHanh, " +
                    "MoTa = @MoTa, GhiChu = @GhiChu, HinhAnh = @HinhAnh WHERE MaVoucher = @MaVoucher";
                cmd.Parameters.AddWithValue("@MaVoucher", txtMaVoucher.Text);
                cmd.Parameters.AddWithValue("@TenVoucher", txtTenVoucher.Text);
                cmd.Parameters.AddWithValue("@LoaiGiamGia", cmbLoaiGiamGia.SelectedValue);
                cmd.Parameters.AddWithValue("@GiaTriGiam", double.Parse(txtGiaTriGiam.Text));
                cmd.Parameters.AddWithValue("@GiamToiDa", double.Parse(txtGiamToiDa.Text));
                cmd.Parameters.AddWithValue("@GTDonHangToiThieu", double.Parse(txtGTDHTT.Text));
                cmd.Parameters.AddWithValue("@MaPhatHanh", txtMaPhatHanh.Text);
                cmd.Parameters.AddWithValue("@SoLuongPhatHanh", int.Parse(txtSLPhatHanh.Text));
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                cmd.Parameters.AddWithValue("@HinhAnh", isImageChanged ? Path.GetFileName(picImageVoucher.Tag.ToString()) : imageFileName);
                cmd.ExecuteNonQuery();
                if (isImageChanged)
                {
                    File.Copy(picImageVoucher.Tag.ToString(), destPath + Path.GetFileName(picImageVoucher.Tag.ToString()));
                }
                MessageBox.Show("Cập nhật voucher thành công!");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLoaiGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cmbLoaiGiamGia.SelectedValue.ToString(), out int val);
            if (val == 1)
            {
                lblUnit.Text = "%";
            }
            else
            {
                lblUnit.Text = "VNĐ";
            }
        }

        private void ckcPhatHanhMa_CheckedChanged(object sender, EventArgs e)
        {
            txtMaPhatHanh.Enabled = ckcPhatHanhMa.Checked;
        }

        private void txtMaPhatHanh_TextChanged(object sender, EventArgs e)
        {
            if(txtMaPhatHanh.Text.Length == 10)
            {
                ckcPhatHanhMa.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá dữ liệu này không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (frmXacNhan xacNhan = new frmXacNhan())
                {
                    xacNhan.FormBorderStyle = FormBorderStyle.None;
                    xacNhan.ShowDialog();
                }
                if (Session.isDeleted)
                {
                    string sqlDel = "DELETE Voucher Where MaVoucher = (@MaVoucher)";
                    cmd = new SqlCommand(sqlDel, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MaVoucher", txtMaVoucher.Text.Trim());
                    cmd.ExecuteNonQuery();

                    if (File.Exists(destPath + Session.VoucherData.HinhAnh)) //File.Exists: kiểm tra tệp có tồn tại không
                    {
                        try
                        {
                            picImageVoucher.Dispose();
                            picImageVoucher.Image = null;

                            //dọn bộ nhớ
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            File.Delete(destPath + Session.VoucherData.HinhAnh); //Xoá ảnh
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xoá ảnh: \n" + ex.Message);
                            return;
                        }
                    }
                    Session.isDeleted = false;

                    MessageBox.Show("Xóa voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
