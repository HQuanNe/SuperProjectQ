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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SuperProjectQ.AllForm.KhachHang
{
    public partial class frmThemKhachHang : Form
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt;
        SqlCommand cmd;
        string[] textBox;

        private void AddVoucher(string MaKH)
        {
            string sqlAddVoucher = "INSERT INTO VoucherKhachHang(STT, MaKH, MaVoucher, NgayNhan, NgayHetHan, TrangThai) " +
                "VALUES (@STT, @MKH, 'VCH01', GETDATE(), @NHH, 0)";
            cmd = new SqlCommand(sqlAddVoucher, kn.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@STT", Session.AutoCreateID_Interger("STT", "VoucherKhachHang"));
            cmd.Parameters.AddWithValue("@MKH", MaKH);
            cmd.Parameters.AddWithValue("@NHH", DateTime.Now.Date.AddDays(30));
            cmd.ExecuteNonQuery();

        }
        private void Reset_Text()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtDTL.Clear();
            txtSDT.Clear();
            txtDTL.Clear();
            txtMaKH.Focus();
        }//reset về rỗng

        private void CmbVIP_Load()
        {
            cmbVIP.DataSource = kn.CreateTable("SELECT VIP FROM BangVIP");
            cmbVIP.DisplayMember = "VIP";
            cmbVIP.ValueMember = "VIP";
        }
        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            CmbVIP_Load();
            cmbVIP.SelectedValue = "VIP0";
            txtMaKH.Text = Session.AutoCreateID_String("MaKH", "KhachHang", "KH");
            txtMaKH.Enabled = false;
            txtSDT.Text = Session.CustomerData.SoDienThoai;
            txtDTL.Text = "0";
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtDTL.Text == "")
                {
                    MessageBox.Show("Tất cả các dữ liệu không được để trống!!!");
                    return;
                }
                else
                {
                    textBox = new string[]
                    {
                            txtSDT.Text.Trim(),
                            txtDTL.Text
                    };
                    if (!Session.XuLySo(textBox)) { MessageBox.Show("Lỗi định dạng số, vui lòng kiểm tra lại!!!"); return; }

                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có muốn thêm khách hàng không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (traloi == DialogResult.Yes)
                    {
                        if (txtSDT.Text.Trim().Length < 10)
                        {
                            MessageBox.Show("SĐT phải đủ 10 chữ số");
                            return;
                        }
                        string sqlAdd = "INSERT INTO KhachHang(MaKH, TenKH, DiaChi, SoDienThoai, VIP, DiemTichLuy) values (@MaKH, @TenKH, @DiaChi, @SoDienThoai, @VIP, @DiemTichLuy)";
                        cmd = new SqlCommand(sqlAdd, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@VIP", cmbVIP.SelectedValue);
                        cmd.Parameters.AddWithValue("@DiemTichLuy", txtDTL.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Đã thêm khách hàng mã {txtMaKH.Text} tên: {txtTenKH.Text}");

                        Session.CustomerData.MaKH = txtMaKH.Text.Trim();

                        txtMaKH.Text = Session.AutoCreateID_String("MaKH", "KhachHang", "KH");//Load lại mã mới

                        await Task.Delay(2000);
                        AddVoucher(txtMaKH.Text.Trim());

                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmThemKhachHang - Lỗi: \n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (!Session.XuLySDT(txtSDT.Text)) return;

            Session.CustomerData.SoDienThoai = txtSDT.Text;
            txtSDT.SelectionStart = txtSDT.Text.Length;
        }
    }
}
