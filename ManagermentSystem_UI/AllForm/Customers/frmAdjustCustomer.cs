using SuperProjectQ.AllForm.KhoHang;
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
using DataAccessLayer;

namespace SuperProjectQ.AllForm.KhachHang
{
    public partial class frmAdjustCustomer : Form
    {
        public frmAdjustCustomer()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt;
        SqlCommand cmd;
        string[] textBox;

        private void CmbVIP_Load()
        {
            cmbVIP.DataSource = kn.CreateTable("SELECT VIP FROM BangVIP");
            cmbVIP.DisplayMember = "VIP";
            cmbVIP.ValueMember = "VIP";
        }
        private void frmAdjustCustomer_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            CmbVIP_Load();
            txtMaKH.Text = Session.CustomerData.MaKH;
            txtTenKH.Text = Session.CustomerData.TenKH;
            txtDiaChi.Text = Session.CustomerData.DiaChi;
            txtSDT.Text = Session.CustomerData.SoDienThoai;
            txtDTL.Text = Session.CustomerData.DiemTichLuy.ToString();
            cmbVIP.SelectedValue = Session.CustomerData.VIP;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không, không thể khôi phục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmXacNhan confirm = new frmXacNhan();
                    confirm.FormBorderStyle = FormBorderStyle.None;
                    confirm.ShowDialog();
                    if (!Session.isDeleted) return;


                    string sqlDeleteVoucher = "DELETE VoucherKhachHang WHERE MaKH = @MKH";
                    cmd = new SqlCommand(sqlDeleteVoucher, kn.conn);
                    cmd.Parameters.AddWithValue("@MKH", txtMaKH.Text);
                    cmd.ExecuteNonQuery();

                    string sqlDelete = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                    cmd = new SqlCommand(sqlDelete, kn.conn);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Session.isDeleted = false;

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có muốn sửa DL không???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (traloi == DialogResult.Yes)
                    {
                        if (txtSDT.Text.Trim().Length < 10)
                        {
                            MessageBox.Show("SĐT phải đủ 10 chữ số");
                            return;
                        }
                        string sqlEdit = "" +
                            "UPDATE  KhachHang SET TenKH = (@TenKH), DiaChi = (@DiaChi), SoDienThoai = (@SoDienThoai), VIP = (@VIP), DiemTichLuy = (@DiemTichLuy)  WHERE MaKH = (@MaKH)";
                        cmd = new SqlCommand(sqlEdit, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@VIP", cmbVIP.SelectedValue);
                        cmd.Parameters.AddWithValue("@DiemTichLuy", txtDTL.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Đã sửa khách hàng mã {txtMaKH.Text} tên: {txtTenKH.Text}");
                    }
                    else return;
                }

            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Mã nhân viên bị trùng, vui lòng điền lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 2628:
                        MessageBox.Show("Dữ liệu nhập vào quá lớn, vui lòng kiểm tra lại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
                MessageBox.Show("Lỗi: " + ex.Number + " " + ex.Message);
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (!Session.XuLySDT(txtSDT.Text)) return;

            Session.CustomerData.SoDienThoai = txtSDT.Text;
            txtSDT.SelectionStart = txtSDT.Text.Length;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
