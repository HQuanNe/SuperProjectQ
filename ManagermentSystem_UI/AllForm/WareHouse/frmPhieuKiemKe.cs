using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.WareHouse
{
    public partial class frmPhieuKiemKe : Form
    {
        public frmPhieuKiemKe()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        DataTable dt;
        ConnectData kn = new ConnectData();

        bool validate = false;
        string nguyenNhan = string.Empty;
        private void CmbTenSP_Load()
        {
            try
            {
                cmbSanPhamKho.DataSource = kn.CreateTable("SELECT MaSP_Kho, TenSP FROM KhoHang ORDER BY TenSP ASC");
                cmbSanPhamKho.DisplayMember = "TenSP";
                cmbSanPhamKho.ValueMember = "MaSP_Kho";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("frmPhieuKiemKe - CmbTenSP_Load() \nLỗi: " + ex.Message);
            }
        }
        private void InspectTonKho()
        {
            if (double.TryParse(txtTonThucTe.Text, out double tonThucTe) && double.TryParse(txtTonHeThong.Text, out double tonHeThong))
            {
                double chenhLech = Math.Round(tonThucTe - tonHeThong, 2);
                if (chenhLech > 0)
                {
                    nguyenNhan = $"Tồn thực tế lớn hơn {chenhLech} đơn vị so với tồn hệ thống!";
                }
                else
                {
                    nguyenNhan = $"Tồn thực tế nhỏ hơn {Math.Abs(chenhLech)} đơn vị so với tồn hệ thống!";
                }
                txtChenhLech.Text = chenhLech.ToString();
                validate = true;
            }
            else
            {
                validate = false;
                txtChenhLech.Text = string.Empty;
                txtChenhLech.SelectionStart = txtChenhLech.Text.Length;
            }
        }
        private bool InspectPhieuKiemKe()
        {
            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = $"SELECT MaKiemKe FROM KiemKe WHERE MaSP_Kho = '{cmbSanPhamKho.SelectedValue}' AND TrangThai = 0";
                    return cmd.ExecuteScalar() == null ? true : false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmPhieuKiemKe - InspectPhieuKiemKe() \nLỗi: " + ex.Message);
                return false;
            }
        }
        private void frmPhieuKiemKe_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            CmbTenSP_Load();

            rtxtNguyenNhan.Text = "Lý do: \n";
        }

        private void cmbSanPhamKho_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbSanPhamKho.SelectedValue == null) return;
            using (dt = new DataTable())
            {
                dt = kn.CreateTable($"SELECT TonKho, DonViTinh FROM KhoHang WHERE MaSP_Kho = '{cmbSanPhamKho.SelectedValue}'");
                try
                {
                    if(dt.Rows.Count > 0)
                    {
                        txtTonHeThong.Text = dt.Rows[0]["TonKho"].ToString();
                        lblUnit_1.Text = dt.Rows[0]["DonViTinh"].ToString();
                        lblUnit_2.Text = dt.Rows[0]["DonViTinh"].ToString();
                        lblUnit_3.Text = dt.Rows[0]["DonViTinh"].ToString();
                    }
                    InspectTonKho();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("frmPhieuKiemKe - cmbSanPhamKho_SelectedValueChanged \nLỗi: " + ex.Message);
                }
            }
        }

        private void txtTonThucTe_TextChanged(object sender, EventArgs e)
        {
            InspectTonKho();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if(!validate)
                {
                    MessageBox.Show("Vui lòng nhập số lượng tồn thực tế hợp lệ!");
                    return;
                }
                if(!InspectPhieuKiemKe())
                {
                    MessageBox.Show("Đã tồn tại phiếu kiểm kê cho sản phẩm này, \n" +
                        "Vui lòng hãy chờ Quản lý duyệt yêu cầu trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(MessageBox.Show("Bạn có chắc chắn muốn thêm phiếu kiểm kê này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                using (cmd = new SqlCommand())
                {
                    int maKK = Session.AutoCreateID_Interger("MaKiemKe", "KiemKe");
                    string maNV = Session.StaffData.GetMaNVFromIDU();
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "INSERT INTO KiemKe (MaKiemKe, NgayKiemKe, MaNV, MaSP_Kho, TonHeThong, TonThucTe, ChenhLech, NguyenNhan, TrangThai) " +
                        "VALUES (@MKK, GETDATE(), @MNV, @MSPK, @THT, @TTT, @CL, @NN, 0)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MKK", maKK);
                    cmd.Parameters.AddWithValue("@MNV", maNV);
                    cmd.Parameters.AddWithValue("@MSPK", cmbSanPhamKho.SelectedValue);
                    cmd.Parameters.AddWithValue("@THT", Convert.ToDouble(txtTonHeThong.Text));
                    cmd.Parameters.AddWithValue("@TTT", Convert.ToDouble(txtTonThucTe.Text));
                    cmd.Parameters.AddWithValue("@CL", Math.Abs(Convert.ToDouble(txtChenhLech.Text)));
                    cmd.Parameters.AddWithValue("@NN", nguyenNhan + " \n" +  rtxtNguyenNhan.Text.Trim());
                    int isSuccess = cmd.ExecuteNonQuery();

                    if (isSuccess > 0)
                    {
                        MessageBox.Show("Phiếu kiểm kê đã được thêm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu thất bại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmPhieuKiemKe - btnThemPhieu_Click \nLỗi: " + ex.Message);
            }
        }
    }
}
