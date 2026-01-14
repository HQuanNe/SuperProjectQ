using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace SuperProjectQ.FrmMixed
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlCommand cmd = null;

        decimal tongTien = Session.TongTien;
        string PTTT = ""; //Phương thức TT
        bool isCustomer = false; //Kiểm tra xem phải khách hàng quen ko
        decimal tienGiamGia = 0; // Tiền đc giảm

        decimal VAT = 0.05m; //Mức thuế
        private int TienNhan()
        {
            int takeNum = 0;
            if (txtTienNhan.Text != "")
            {
                takeNum = Convert.ToInt32(txtTienNhan.Text.Replace(".", ""));
            }
            return takeNum;
        }
        private void TichDiemKH()
        {
            TongThanhToan();
            int diemTichLuy = 0;
            string VIP = null, sqlUpdateDiem = null;
            double discount = 0;
            const int ti_le_quy_doi = 10000; //10k đc 1 điểm
            Dictionary<string, int> dsVIP = new Dictionary<string, int>()
            {
                {"VIP1", 1000},
                {"VIP2", 3000},
                {"VIP3", 6000},
                {"VIP4", 8000},
                {"VIP5", 12000}
            };
            Dictionary<string, double> dsDiscount = new Dictionary<string, double>()
            {
                {"VIP1", 0.02},
                {"VIP2", 0.03},
                {"VIP3", 0.04},
                {"VIP4", 0.05},
                {"VIP5", 0.06}
            };
            //Lấy cột điểm tích luỹ
            string sqlKH = $"SELECT DiemTichLuy FROM KhachHang WHERE MaKH = '{Session.MaKH}'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlKH);
            diemTichLuy = Convert.ToInt32(dt.Rows[0]["DiemTichLuy"]);
            diemTichLuy += Convert.ToInt32(Math.Round(Session.TongTien / ti_le_quy_doi));

            int flag = 0; //Cờ hiệu nếu if trên không thoả mãn 1 trong 5 phần tử của dict thì chạy cái if == 5
            foreach (string key in dsVIP.Keys)
            {
                //nếu vượt mức sẽ lên VIP tương ứng
                if (diemTichLuy >= dsVIP[key])
                {
                    VIP = key;
                    discount = dsDiscount[key];
                    sqlUpdateDiem = $"UPDATE KhachHang SET VIP = '{VIP}', DiemTichLuy = {diemTichLuy}, Discount = @DC WHERE MaKH = @MKH";
                    cmd = new SqlCommand(sqlUpdateDiem, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DC", discount);
                    continue;
                }
                //không thì chỉ cập nhật điểm
                else
                {
                    flag++;
                }
                if (flag == 5)
                {
                    sqlUpdateDiem = $"UPDATE KhachHang SET DiemTichLuy = {diemTichLuy} WHERE MaKH = @MKH";
                    cmd = new SqlCommand(sqlUpdateDiem, kn.conn);
                    cmd.Parameters.Clear();
                }
            }
            cmd.Parameters.AddWithValue("@MKH", Session.MaKH);
            cmd.ExecuteNonQuery();
        }
        private void LoadQRCode()
        {
            TongThanhToan();
            LoadLabel();
            //Tạo mã QR
            string nganHang = "MB";
            string stk = "0382294559";
            string tenTK = "NGUYEN DUC HONG QUAN";
            string noiDung = $"PHONG {Session.maPhong} THANH TOAN";
            double tienTT = Convert.ToDouble(Session.TongThanhToan);
            // Tạo đường dẫn API
            string url = $"https://img.vietqr.io/image/{nganHang}-{stk}-compact2.png?amount={tienTT}&addInfo={noiDung}&accountName={tenTK}";

            // Hiển thị lên PictureBox
            picQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            picQRCode.Load(url);
        }
        private void LoadLabel()
        {
            lblTienPhong.Text = Session.TongTienPhong.ToString("#,##0 VND");
            lblTienDV.Text = Session.TongTienDV.ToString("#,##0");

            if (isCustomer) lblTienGiamGia.Text = Session.Discount.ToString("#,##0");
            else lblTienGiamGia.Text = "";

            lblTienThue.Text = Session.TienVAT.ToString("#,##0");
            lblTienThanhToan.Text = Session.TongThanhToan.ToString("#,##0");
        }
        private void TongThanhToan()
        {
            try
            {
                string sqlPhong = "SELECT Phong.MaPhong, Phong.TenPhong, LoaiPhong.GiaTheoGio, Phong.TrangThai, Phong.GioVao, Phong.MoTa " +
                    "FROM Phong " +
                    $"INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong WHERE MaPhong = '{Session.maPhong}'";
                dt = new DataTable();
                dt = kn.CreateTable(sqlPhong);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime dateTimeIn = Convert.ToDateTime(dr["GioVao"]);
                    DateTime dateTimeOut = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    TimeSpan tongThoiGian = dateTimeOut - dateTimeIn;
                    double giaMoiPhut = Convert.ToDouble(dr["GiaTheoGio"].ToString()) / 60;
                    double tongSoPhut = Math.Round(tongThoiGian.TotalMinutes);
                    decimal tongTienPhong = Convert.ToDecimal(Math.Round(tongSoPhut * giaMoiPhut / 1000) * 1000);
                    decimal tienDV = Session.TongTienDV;

                    decimal tongTien = tongTienPhong + tienDV;
                    decimal tienVAT = (tongTien-tienGiamGia) * VAT;
                    
                    //Gán biến chung
                    Session.TimeOut = dateTimeOut;
                    Session.TongSoPhut = tongSoPhut;
                    Session.TongTienPhong = tongTienPhong;
                    Session.TongTien = tongTien;
                    Session.Discount = tienGiamGia;
                    Session.TienVAT = tienVAT;
                    if(isCustomer) Session.TongThanhToan = tongTien - tienGiamGia + tienVAT;
                    else Session.TongThanhToan = tongTien + tienVAT;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại <= 10");
                string newTxtSDT = txtSDT.Text.Remove(txtSDT.Text.Length - 1, 1);
                txtSDT.Text = newTxtSDT;
                return;
            }
            string noData = "--";

            string sqlKH = $"SELECT * FROM KhachHang WHERE SoDienThoai = '{txtSDT.Text}'";
            da = new SqlDataAdapter(sqlKH, kn.conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0 && txtSDT.Text.Length == 10)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    isCustomer = true;
                    //Gán dữ liệu
                    Session.MaKH = dr["MaKH"].ToString();
                    lblTenKH.Text = dr["TenKH"].ToString();
                    lblDiaChi.Text = dr["DiaChi"].ToString();
                    lblVIP.Text = dr["VIP"].ToString();
                    lblDiemTichLuy.Text = dr["DiemTichLuy"].ToString();
                    lblDiscount.Text = (Convert.ToDouble(dr["Discount"]) * 100).ToString() + "%";

                    //Xử lý giảm giá
                    tienGiamGia = Session.TongTien * Convert.ToDecimal(dr["Discount"]);
                    break;
                }
                TongThanhToan();
                LoadLabel();
                LoadQRCode();
            }
            else
            {
                isCustomer = false;

                lblTenKH.Text = noData;
                lblDiaChi.Text = noData;
                lblVIP.Text = noData;
                lblDiemTichLuy.Text = noData;
                lblDiscount.Text = noData;
                lblTienGiamGia.Text = noData;
            }
            if(txtSDT.Text.Length == 10 || txtSDT.Text.Length == 9  && !isCustomer)
            {
                TongThanhToan();
                LoadLabel();
                LoadQRCode();
            }

            if (isCustomer) lblTienThanhToan.Text = Session.TongThanhToan.ToString("#,##0 VND");
            else lblTienThanhToan.Text = Session.TongThanhToan.ToString("#,##0 VND");

            if (PTTT == "Tiền mặt")
            {
                int tienNhan = Convert.ToInt32(txtTienNhan.Text.Replace(".", ""));
                txtTraLai.Text = (tienNhan - Session.TongThanhToan).ToString("#,##0");
            }
        }
        private void btnQRCode_Click(object sender, EventArgs e)
        {
            plQRCode.Show();
            plCash.Hide();
            plTTKH.Visible = true;
            //Đặt tên theo PTTT
            PTTT = "QR Code";
            lblPTTT.Text = "PTTT: " + PTTT;

            LoadQRCode();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Xuất hoá đơn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                Session.isPay = true;
                Session.PTTT = PTTT;
                Session.TrangThaiHD = true;
                TichDiemKH();
                Session.Datalog("payment.txt", $"Mã NV: {Session.MaNV} Đã thực hiện thanh toán hoá đơn >> {Session.maHD} <<");
                this.Close();
                await Task.Delay(100);
                frmPrintBill printBill = new frmPrintBill();
                printBill.ShowDialog();
            }
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();
                TongThanhToan();
                LoadLabel();
                Session.MaKH = "KH000";

                plQRCode.Hide();
                plCash.Hide();
                plTTKH.Visible = false;

                if (isCustomer) lblTienThanhToan.Text = Session.TongThanhToan.ToString("#,##0 VND");
                else lblTienThanhToan.Text = Session.TongTien.ToString("#,##0 VND");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region TT tiền mặt

        private void btnCash_Click(object sender, EventArgs e)
        {
            TongThanhToan();
            LoadLabel();

            plQRCode.Hide();
            plCash.Show();
            plTTKH.Visible = true;
            txtTienNhan.Text = "0";
            txtTraLai.Text = "0";
            //Đặt tên theo PTTT
            PTTT = "Tiền mặt";
            lblPTTT.Text = "PTTT: " + PTTT;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTienNhan.Text = "0";
        }


        private void btn1K_Click(object sender, EventArgs e)
        {
            int num = 1000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn2K_Click(object sender, EventArgs e)
        {
            int num = 2000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn5K_Click(object sender, EventArgs e)
        {
            int num = 5000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn10K_Click(object sender, EventArgs e)
        {
            int num = 10000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn20K_Click(object sender, EventArgs e)
        {
            int num = 20000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn50K_Click(object sender, EventArgs e)
        {
            int num = 50000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn100K_Click(object sender, EventArgs e)
        {
            int num = 100000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }
        private void btn200K_Click(object sender, EventArgs e)
        {
            int num = 200000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn500K_Click(object sender, EventArgs e)
        {
            int num = 500000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }
        private void btn1000K_Click(object sender, EventArgs e)
        {
            int num = 1000000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }

        private void btn2000K_Click(object sender, EventArgs e)
        {
            int num = 2000000;
            txtTienNhan.Text = (num + TienNhan()).ToString("#,##0");
        }
        #endregion

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNhan.Text.Contains(".")){
                int tienNhan = Convert.ToInt32(txtTienNhan.Text.Replace(".", ""));
                txtTraLai.Text = (tienNhan - Session.TongThanhToan).ToString("#,##0");
            }
            else
            {
                txtTraLai.Text = "0";
            }
        }
    }
}
