using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.KhoHang
{
    public partial class frmDieuChinhKho : Form
    {
        public frmDieuChinhKho()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string maDM = ""; //mã danh mụcz
        string folderImage = "";//folder ảnh

        string oldPathImage = "";//Đường đãn cũ
        string newPathImage = ""; //đườngn dẫn ảnh mới

        bool hasImage; //Kiểm tra có ảnh k
        private void CmbDanhMuc_Load()
        {
            string sqlMaDM = $"SELECT * FROM DanhMuc";
            cmbDanhMuc.DataSource = kn.CreateTable(sqlMaDM);
            cmbDanhMuc.ValueMember = "MaDM";
            cmbDanhMuc.DisplayMember = "TenDM";

        }
        private void text_Load()
        {
            txtTenSP.Text = Session.WarehouseData.TenSP;
            txtDVT.Text = Session.WarehouseData.DonViTinh;
            txtTonKho.Text = Session.WarehouseData.TonKho;
            dtNgayCapNhat.Value = Session.WarehouseData.NgayCapNhat;
            txtDonGia.Text = Session.WarehouseData.DonGiaNhap.ToString();
            txtGhiChu.Text = Session.WarehouseData.GhiChu;
        }
        private void Picture_Load()
        {
            try
            {
                string sqlMaDM = $"SELECT MaDM FROM DanhMuc WHERE TenDM = N'{Session.WarehouseData.DanhMuc}'";
                cmd = new SqlCommand(sqlMaDM, kn.conn);
                if(cmd.ExecuteScalar()== DBNull.Value || cmd.ExecuteScalar() == null) return;

                maDM = cmd.ExecuteScalar().ToString();
                switch (maDM)
                {
                    case "MDM01":
                    case "MDM03":
                    case "MDM05":
                    case "MDM06":
                        folderImage = "FoodImage\\";
                        break;
                    case "MDM02":
                    case "MDM07":
                    case "MDM08":
                        folderImage = "DrinkImage\\";
                        break;
                    case "MDM04":
                        folderImage = "OtherImage\\";
                        break;
                    default:
                        folderImage = "ComboImage\\";
                        break;
                } //Kiểm tra danh mục sản phẩm để gán file ảnh đúng

                if (string.IsNullOrEmpty(Session.WarehouseData.HinhAnh)) return;

                oldPathImage = Application.StartupPath + $"\\Images\\{folderImage}\\{Session.WarehouseData.HinhAnh}";
                picImageSP.Image = Image.FromFile(oldPathImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmDieuChinhKho - Picture_Load() Lỗi \n" + ex.Message);
                return;
            }
        }
        private void frmDieuChinhKho_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            CmbDanhMuc_Load();
            text_Load();
            Picture_Load();

            cmbTrangThai.Items.Add("Dừng bán");
            cmbTrangThai.Items.Add("Đang bán");
            cmbTrangThai.SelectedIndex = Session.WarehouseData.TrangThai;

            cmbDanhMuc.SelectedValue = maDM;
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbTrangThai.SelectedIndex.ToString());
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Lưu thay đổi ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    string[] txtSo = new string[]
{
                    txtDonGia.Text, txtTonKho.Text
};
                    if (!Session.XuLySo(txtSo)) { MessageBox.Show("Đơn giá hoặc tồn kho phải là số!!!"); return; }

                    string sqlUpdate = "UPDATE KHoHang SET " +
                        "TenSP = @TSP, MaDM = @MDM, DonViTinh = @DVT, TonKho = @TK, NgayCapNhat = @NCN, DonGiaNhap = @DGN, TrangThai = @TT, HinhAnh = @HA, GhiChu = @GC " +
                        "WHERE MaSP_Kho = @MSP";
                    cmd = new SqlCommand(sqlUpdate, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TSP", txtTenSP.Text.Trim());
                    cmd.Parameters.AddWithValue("@MDM", cmbDanhMuc.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DVT", txtDVT.Text.Trim());
                    cmd.Parameters.AddWithValue("@TK", Convert.ToDouble(txtTonKho.Text.Trim()));
                    cmd.Parameters.AddWithValue("@NCN", dtNgayCapNhat.Value);
                    cmd.Parameters.AddWithValue("@DGN", Convert.ToDecimal(txtDonGia.Text.Trim().Replace(".","")));
                    cmd.Parameters.AddWithValue("@TT", Convert.ToBoolean(cmbTrangThai.SelectedIndex));
                    cmd.Parameters.AddWithValue("@HA", string.IsNullOrEmpty(Session.WarehouseData.HinhAnh) ? Path.GetFileName(newPathImage) : Session.WarehouseData.HinhAnh);
                    cmd.Parameters.AddWithValue("@GC", txtGhiChu.Text);
                    cmd.Parameters.AddWithValue("@MSP", Session.WarehouseData.MaSP.ToString().Trim());
                    cmd.ExecuteNonQuery();

                    if(hasImage) File.Copy(newPathImage, oldPathImage, true); //Lưu đè ảnh cũ
                    else if(!hasImage) File.Copy(newPathImage, Application.StartupPath + $"\\Images\\{folderImage}\\{Path.GetFileName(newPathImage)}", false);

                    MessageBox.Show("Cập nhật sản phẩm thành công!!!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return;
                }
            }
        }

        private void btnAdjustImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp"; //định dạng
                    ofd.Title = "Chọn ảnh sản phẩm";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        newPathImage = ofd.FileName;

                        if (picImageSP.Image != null || !string.IsNullOrEmpty(Session.WarehouseData.HinhAnh)) //Nếu có ảnh thì clear
                        {
                            hasImage = true;

                            picImageSP.Image.Dispose();
                            picImageSP.Image = null;
                        }
                        else
                        {
                            hasImage = false;
                        }
                        picImageSP.Image = Image.FromFile(newPathImage);
                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); return;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if(decimal.TryParse(txtDonGia.Text, out decimal value))
            {
                txtDonGia.Text = value.ToString("#,##0");
                txtDonGia.SelectionStart = txtDonGia.Text.Length;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không, không thể khôi phục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frmXacNhan xacNhan = new frmXacNhan();
                xacNhan.FormBorderStyle = FormBorderStyle.None;
                xacNhan.ShowDialog();
                if (Session.isDeleted)
                {
                    string sqlDelete = "DELETE FROM KhoHang WHERE MaSP_Kho = @MaSP";
                    cmd = new SqlCommand(sqlDelete, kn.conn);
                    cmd.Parameters.AddWithValue("@MaSP", Session.WarehouseData.MaSP);
                    cmd.ExecuteNonQuery();

                    if (File.Exists(oldPathImage)) //File.Exists: kiểm tra tệp có tồn tại không
                    {
                        try
                        {
                            picImageSP.Dispose();
                            picImageSP.Image = null;

                            //dọn bộ nhớ
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            File.Delete(oldPathImage); //Xoá ảnh
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
