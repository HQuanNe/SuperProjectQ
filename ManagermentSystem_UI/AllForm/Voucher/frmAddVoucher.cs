using DataAccessLayer;
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
    public partial class frmAddVoucher : Form
    {
        public frmAddVoucher()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string destPath = Application.StartupPath + @"\Images\VoucherImage\";
        string maVoucher = Session.AutoCreateID_String("MaVoucher", "Voucher", "VCH");

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
            if(double.TryParse(txtGiamToiDa.Text, out double giaTriGiam) || 
                double.TryParse(txtGTDHTT.Text, out double giaTriGiamToiThieu) ||
                int.TryParse(txtSLPhatHanh.Text, out int soLuongPhatHanh))
            {
                return true;
            }
            return false;
        }
        private void frmAddVoucher_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            CmbType_Load();
            txtMaVoucher.Text = maVoucher;
            txtGiaTriGiam.Text = "0";
            txtGiamToiDa.Text = "0";
            txtGTDHTT.Text = "0";
            txtSLPhatHanh.Text = "0";

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTenVoucher.Text == "" || txtGiamToiDa.Text == "" || txtGTDHTT.Text == "" || txtSLPhatHanh.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            if(picImageVoucher.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh cho voucher!");
                return;
            }
            if(!ValidateCheck())
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng cho các trường số!");
                return;
            }
            if(txtMaPhatHanh.Text.Length != 10 && ckcPhatHanhMa.Checked)
            {
                MessageBox.Show("Mã phát hành phải có đúng 10 ký tự!"); return;
            }
            if(File.Exists(destPath + Path.GetFileName(picImageVoucher.Tag.ToString())))
            {
                MessageBox.Show("Hình ảnh đã tồn tại! Vui lòng đổi tên hình ảnh hoặc chọn hình khác!"); return;
            }
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT MaPhatHanh FROM Voucher WHERE MaPhatHanh = '{txtMaPhatHanh.Text}'");
                if (dt.Rows.Count > 0 && txtMaPhatHanh.Text.Length == 10)
                {
                    MessageBox.Show("Mã phát hành đã tồn tại! Vui lòng đổi mã phát hành khác!"); return;
                }
            }

            using (cmd = new SqlCommand())
            {
                double giaTriGiam = Convert.ToInt16(cmbLoaiGiamGia.SelectedValue) == 1 ? double.Parse(txtGiaTriGiam.Text) / 100 : double.Parse(txtGiaTriGiam.Text);
                cmd.Connection = kn.conn;
                cmd.CommandText = "INSERT INTO Voucher (MaVoucher, TenVoucher, GiaTriGiam, LoaiGiamGia, GiamToiDa, GTDonHangToiThieu, " +
                    "MaPhatHanh, SoLuongPhatHanh, MoTa, HinhAnh, GhiChu) " +
                    "VALUES (@MVC, @TVC, @GTG, @LGG, @GTD, @GTDHTT, @MPH, @SLPH, @MT, @HA, @GC)";
                cmd.Parameters.AddWithValue("@MVC", maVoucher);
                cmd.Parameters.AddWithValue("@TVC", txtTenVoucher.Text);
                cmd.Parameters.AddWithValue("@GTG", giaTriGiam);
                cmd.Parameters.AddWithValue("@LGG", Convert.ToInt16(cmbLoaiGiamGia.SelectedValue));
                cmd.Parameters.AddWithValue("@GTD", double.Parse(txtGiamToiDa.Text));
                cmd.Parameters.AddWithValue("@GTDHTT", double.Parse(txtGTDHTT.Text));
                cmd.Parameters.AddWithValue("@MPH", txtMaPhatHanh.Text);
                cmd.Parameters.AddWithValue("@SLPH", int.Parse(txtSLPhatHanh.Text));
                cmd.Parameters.AddWithValue("@MT", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@HA", Path.GetFileName(picImageVoucher.Tag.ToString()));
                cmd.Parameters.AddWithValue("@GC", txtGhiChu.Text);
                cmd.ExecuteNonQuery();
                try
                {
                    File.Copy(picImageVoucher.Tag.ToString(), destPath + Path.GetFileName(picImageVoucher.Tag.ToString()));
                    MessageBox.Show("Thêm voucher thành công!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm voucher: " + ex.Message);
                }
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn hình ảnh cho voucher";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImageVoucher.Image = Image.FromFile(ofd.FileName);
                picImageVoucher.Tag = ofd.FileName;
            }
        }

        private void cmbLoaiGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cmbLoaiGiamGia.SelectedValue.ToString(), out int val);
            if ( val == 1)
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
    }
}
