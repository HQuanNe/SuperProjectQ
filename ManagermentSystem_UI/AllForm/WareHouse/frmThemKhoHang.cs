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

namespace SuperProjectQ.AllForm.KhoHang
{
    public partial class frmThemKhoHang : Form
    {
        public frmThemKhoHang()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt;
        SqlCommand cmd;
        private void CmbDanhMuc_Load()
        {
            dt = kn.CreateTable("SELECT * FROM DanhMuc WHERE MaDM <> 'MDM09'");
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDM";
            cmbDanhMuc.ValueMember = "MaDM";
        }
        private void frmXuLyKhoHang_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            CmbDanhMuc_Load();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                ofd.Title = "Chọn ảnh sản phẩm";

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    picImageSP.Image = Image.FromFile(ofd.FileName);
                    picImageSP.Tag = ofd.FileName;
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenSP.Text == "" || txtDVT.Text == "" || cmbDanhMuc.SelectedValue == null || txtDonGia.Text == "" || txtTonKho.Text == "")
                {
                    MessageBox.Show("Các trường dữ liệu không được để trống");
                    return;
                }
                string[] txtSo = new string[]
                {
                    txtDonGia.Text, txtTonKho.Text
                };
                if(!Session.XuLySo(txtSo)) { MessageBox.Show("Đơn giá hoặc tồn kho phải là số!!!"); return; }

                string fileName = "";
                #region Xử lý ảnh
                // 1. Kiểm tra xem đã chọn ảnh chưa
                if (string.IsNullOrEmpty(picImageSP.Tag.ToString()))
                {
                    MessageBox.Show("Hãy chọn ảnh");
                    return;
                }

                string oldSourcePath = picImageSP.Tag.ToString(); //Đường dẫn gốc

                //Xác định thư mục đích
                string targetFolder = "";
                switch (cmbDanhMuc.SelectedValue.ToString())
                {
                    case "MDM01":
                    case "MDM03":
                    case "MDM05":
                    case "MDM06":
                        targetFolder = Path.Combine(Application.StartupPath, @"Images\FoodImage\");
                        break;
                    case "MDM02":
                    case "MDM07":
                    case "MDM08":
                        targetFolder = Path.Combine(Application.StartupPath, @"Images\DrinkImage\");
                        break;
                    case "MDM04":
                        targetFolder = Path.Combine(Application.StartupPath, @"Images\OtherImage\");
                        break;
                    default:
                        break;
                }

                fileName = Path.GetFileName(oldSourcePath); //Tên ảnh
                string newSourcePath = Path.Combine(targetFolder, fileName);

                File.Copy(oldSourcePath, newSourcePath, false); //Copy vào \Debug\Images
                #endregion

                string sqlThemSP = "INSERT INTO KhoHang (MaSP_Kho, TenSP, MaDM, DonViTinh, TonKho, NgayCapNhat, DonGiaNhap, TrangThai, HinhAnh, GhiChu) " +
                    "VALUES (@MSPK, @TSP, @MaDM, @DVT, @TK, GETDATE(), @DGN, 1, @HA, @GC)";
                cmd = new SqlCommand(sqlThemSP, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MSPK", Session.AutoCreateID_String("MaSP_Kho", "KhoHang", "SPK"));
                cmd.Parameters.AddWithValue("@TSP", txtTenSP.Text.Trim());
                cmd.Parameters.AddWithValue("@MaDM", cmbDanhMuc.SelectedValue);
                cmd.Parameters.AddWithValue("@DVT", txtDVT.Text.Trim());
                cmd.Parameters.AddWithValue("@TK", Convert.ToDouble(txtTonKho.Text.Trim().Replace(".", "")));
                cmd.Parameters.AddWithValue("@DGN", Convert.ToDecimal(txtDonGia.Text.Trim().Replace(".", "")));
                cmd.Parameters.AddWithValue("@HA", fileName);
                cmd.Parameters.AddWithValue("@GC", txtGhiChu.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm sản phẩm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ảnh đã tổn tại!!! \n{ex.Message}");
                return;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDonGia.Text, out decimal value))
            {
                txtDonGia.Text = value.ToString("#,##0");
                txtDonGia.SelectionStart = txtDonGia.Text.Length;
            }
        }

        private void txtTonKho_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTonKho.Text, out decimal value))
            {
                txtTonKho.Text = value.ToString("#,##0");
                txtTonKho.SelectionStart = txtTonKho.Text.Length;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
