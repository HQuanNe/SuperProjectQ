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

namespace SuperProjectQ.AllForm.NhapKho
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        string maPN = Session.AutoCreateID_String("MaPN", "PhieuNhap", "MPN");
        int maCTPN = 1;
        decimal tongThanhToan = 0;

        private void CmbNhaCC_Load()
        {
            string sqlNhaCC = "SELECT MaNCC, TenCongTy FROM NhaCungCap";
            cmbNCC.DataSource = kn.CreateTable(sqlNhaCC);
            cmbNCC.DisplayMember = "TenCongTy";
            cmbNCC.ValueMember = "MaNCC";

        }
        private void CmbSanPham_Load()
        {
            string sqlSP = "SELECT MaSP_Kho, TenSP FROM KhoHang";
            cmbSanPham.DataSource = kn.CreateTable(sqlSP);
            cmbSanPham.DisplayMember = "TenSP";
            cmbSanPham.ValueMember = "MaSP_Kho";

        }
        private void frmCTPhieuNhap_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            Session.StandardDataGridView(dgvCTPN);

            txtMaPN.Enabled = false;
            txtMaPN.Text = maPN;

            CmbNhaCC_Load();
            CmbSanPham_Load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtSoLuong.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Các trường dữ liệu không được để trống");
                return;
            }
            else
            {
                if(MessageBox.Show("Xác nhận thêm sản phẩm này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int index = dgvCTPN.Rows.Add(); //tạo dòng

                    string[] textBox = new string[]
                    {
                txtSoLuong.Text,
                txtDonGia.Text,
                txtThanhTien.Text,
                    };

                    if (!Session.XuLySo(textBox)) { MessageBox.Show("Số lượng, Đơn giá, Thành tiền phải là số"); return; }
                    dgvCTPN.Rows[index].Cells["MaCTPN"].Value = maCTPN;
                    dgvCTPN.Rows[index].Cells["MaPN"].Value = maPN;
                    dgvCTPN.Rows[index].Cells["MaNCC"].Value = cmbNCC.SelectedValue;
                    dgvCTPN.Rows[index].Cells["MaSP_Kho"].Value = cmbSanPham.SelectedValue;
                    dgvCTPN.Rows[index].Cells["SoLuong"].Value = txtSoLuong.Text.Trim();
                    dgvCTPN.Rows[index].Cells["DonGia"].Value = txtDonGia.Text.Trim();
                    dgvCTPN.Rows[index].Cells["ThanhTien"].Value = txtThanhTien.Text.Trim();

                    maCTPN++;
                }
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtDonGia.Text, out double value)) { txtDonGia.Text = "0"; return; }
            txtDonGia.Text = value.ToString("#,##0");
            txtDonGia.SelectionStart = txtDonGia.Text.Length;

            txtThanhTien.Text = "";
            txtThanhTien.Text = (Convert.ToDouble(txtSoLuong.Text.Trim().Replace(".", "")) * Convert.ToDouble(txtDonGia.Text.Trim().Replace(".", ""))).ToString("#,##0");
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtSoLuong.Text, out double value)) { txtSoLuong.Text = "0"; return; }
            txtSoLuong.Text = value.ToString("#,##0");
            txtSoLuong.SelectionStart = txtSoLuong.Text.Length;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Lưu phiếu nhập?, không thể hoàn tác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sqlCTPN = "";

                string sqlPN = "INSERT INTO PhieuNhap(MaPN, MaNV, NgayNhap, TrangThai) VALUES (@MPN, @MNV, GETDATE(), 1)";
                cmd = new SqlCommand(sqlPN, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MPN", maPN);
                cmd.Parameters.AddWithValue("@MNV", "QTV01");
                cmd.ExecuteNonQuery();

                //Lưu CTPN
                for(int i = 0; i < dgvCTPN.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvCTPN.Rows[i];

                    sqlCTPN = "INSERT INTO CTPhieuNhap(MaCTPN, MaPN, MaNCC, MaSP_Kho, SoLuong, DonGia, ThanhTien) " +
                        "VALUES (@MCTPN, @MPN, @MNCC, @MSPK, @SL, @DG, @TT)";
                    cmd = new SqlCommand(sqlCTPN, kn.conn); 
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MCTPN", Convert.ToInt32(row.Cells["MaCTPN"].Value));
                    cmd.Parameters.AddWithValue("@MPN", row.Cells["MaPN"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@MNCC", row.Cells["MaNCC"].Value.ToString());
                    cmd.Parameters.AddWithValue("@MSPK",row.Cells["MaSP_Kho"].Value).ToString();
                    cmd.Parameters.AddWithValue("@SL", Convert.ToDouble(row.Cells["SoLuong"].Value.ToString().Replace(".", "")));
                    cmd.Parameters.AddWithValue("@DG", Convert.ToDecimal(row.Cells["DonGia"].Value.ToString().Replace(".", "")));
                    cmd.Parameters.AddWithValue("@TT", Convert.ToDecimal(row.Cells["ThanhTien"].Value.ToString().Replace(".", "")));
                    cmd.ExecuteNonQuery();

                    tongThanhToan += Convert.ToDecimal(row.Cells["ThanhTien"].Value.ToString().Replace(".", ""));
                }

                //Lưu tổng TT
                sqlPN = $"UPDATE PhieuNhap SET TongThanhToan = @TTT WHERE MaPN = '{maPN}'";
                cmd = new SqlCommand(sqlPN, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TTT", tongThanhToan);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
