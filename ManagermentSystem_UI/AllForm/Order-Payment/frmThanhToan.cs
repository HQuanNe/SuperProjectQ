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
using System.Runtime.Remoting.Contexts;
using SuperProjectQ.AllForm.Other;
using DataAccessLayer;

namespace SuperProjectQ.FrmMixed
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt = null;
        SqlCommand cmd = null;

        string PTTT = ""; //Phương thức TT
        bool isCustomer = false; //Kiểm tra xem phải khách hàng quen ko
        decimal trietKhauVIP = 0; // Tiền đc giảm theo VIP
        bool isGhiNo = false; // True nếu ghi nợ

        private int TienNhan()
        {
            int takeNum = 0;
            if (txtTienNhan.Text != "")
            {
                takeNum = Convert.ToInt32(txtTienNhan.Text.Replace(".", ""));
            }
            return takeNum;
        }//Tiền nhận khi tttm (bỏ dấu chấm để tính toán)
        private void TichDiemKH()
        {
            TongThanhToan();
            int diemTichLuy = 0;
            string VIP = null, sqlUpdateDiem = null;
            double discount = 0;
            double ti_le_quy_doi = Session.amountPerPointVIP; //10k đc 1 điểm
            Dictionary<string, int> dsVIP = new Dictionary<string, int>()
            {
                {"VIP1", 1000},
                {"VIP2", 3000},
                {"VIP3", 6000},
                {"VIP4", 8000},
                {"VIP5", 12000}
            };
            //Lấy cột điểm tích luỹ
            string sqlPointKH = $"SELECT DiemTichLuy, VIP FROM KhachHang WHERE MaKH = '{Session.CustomerData.MaKH}'";

            dt = new DataTable();
            dt = kn.CreateTable(sqlPointKH);
            diemTichLuy = Convert.ToInt32(dt.Rows[0]["DiemTichLuy"]);
            VIP = dt.Rows[0]["VIP"].ToString();

            diemTichLuy += Convert.ToInt32(Math.Round(Session.BillData.TongTien / (decimal)ti_le_quy_doi));

            int flag = 0; //Cờ hiệu nếu if trên không thoả mãn 1 trong 5 phần tử của dict thì chạy cái if == 5
            if(Session.CustomerData.MaKH != "KH000" && Session.CustomerData.MaKH != "")
            {
                foreach (string key in dsVIP.Keys)
                {
                    //nếu vượt mức sẽ lên VIP tương ứng
                    if (diemTichLuy >= dsVIP[key])
                    {
                        if(Convert.ToInt16(VIP.Replace("VIP", "")) < Convert.ToInt16(key.Replace("VIP", ""))) VIP = key; //Nếu VIP hiện tại nhỏ hơn thì cập nhật lớn hơn thì bỏ

                        sqlUpdateDiem = $"UPDATE KhachHang SET VIP = '{VIP}', DiemTichLuy = {diemTichLuy} WHERE MaKH = @MKH";
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
                cmd.Parameters.AddWithValue("@MKH", Session.CustomerData.MaKH);
                cmd.ExecuteNonQuery();
            }
        }//Tích điểm cho khách
        private void LoadQRCode()
        {
            TongThanhToan();
            //Tạo mã QR
            const string nganHang = "MB";
            const string stk = "0382294559";
            const string tenTK = "NGUYEN DUC HONG QUAN";
            string noiDung = $"PHONG {Session.RoomData.maPhong} THANH TOAN";
            double tienTT = Convert.ToDouble(Session.BillData.TongThanhToan);
            // Tạo đường dẫn API
            try
            {
                string url = $"https://img.vietqr.io/image/{nganHang}-{stk}-compact2.png?amount={tienTT}&addInfo={noiDung}&accountName={tenTK}";

                // Hiển thị lên PictureBox
                picQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
                picQRCode.Load(url);
                Session.picQRCode = picQRCode;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi load QR code");
                return;
            }
        }//Load mã QR
        private void LoadLabel()//Hiển thị lên giao diện
        {
            lblTienPhong.Text = Session.BillData.TongTienPhong.ToString("#,##0 VND");
            lblTienDV.Text = Session.BillData.TongTienDV.ToString("#,##0 VND");

            if (isCustomer)
            {
                lblTrietKhau.Text = Session.BillData.DiscountVIP.ToString("#,##0 VND");
                lblTKVoucher.Text = Session.BillData.DiscountVoucher.ToString("#,##0 VND");
            }
            else lblTrietKhau.Text = "";

            lblTienThue.Text = Session.BillData.TienVAT.ToString("#,##0 VND");
            lblTienThanhToan.Text = Session.BillData.TongThanhToan.ToString("#,##0 VND");
        }
        public void TongThanhToan()
        {
            try
            {
                kn.ConnOpen();
                string sqlPhong = "SELECT Phong.MaPhong, Phong.TenPhong, LoaiPhong.GiaTheoGio, Phong.TrangThai, Phong.GioVao, Phong.GhiChu " +
                    "FROM Phong " +
                    $"INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong WHERE MaPhong = '{Session.RoomData.maPhong}' AND Phong.TrangThai = 1";
                dt = new DataTable();
                dt = kn.CreateTable(sqlPhong);
                if (dt.Rows.Count > 0)
                {
                    decimal pricePerHour = Convert.ToDecimal(dt.Rows[0]["GiaTheoGio"]);
                    DateTime dateTimeIn = Convert.ToDateTime(dt.Rows[0]["GioVao"]); //Lấy giờ vào
                    TimeSpan totalTime = Session.RoomData.TimeOut - dateTimeIn; //Tổng thời gian sử dụng

                    decimal giaMoiPhut =  Session.TinhTienPhongSau_22h(dateTimeIn, pricePerHour) / 60; //Tính giá mỗi phút

                    double tongSoPhut = Math.Round(totalTime.TotalMinutes); //Làm tròn thời gian sử dụng (phút)
                    decimal tongTienPhong = Math.Round((decimal)tongSoPhut * giaMoiPhut / 1000) * 1000; //Tính tổng tiền phòng có làm tròn
                    decimal tienDV = Session.BillData.TongTienDV; //Lấy tiền dịch vụ


                    decimal tongTien = tongTienPhong + tienDV;
                    decimal tienVAT = tongTien * ((decimal)Session.VAT / 100);
                    
                    //Gán biến chung
                    Session.BillData.TongSoPhut = tongSoPhut;
                    Session.BillData.TongTienPhong = tongTienPhong;
                    Session.BillData.TongTien = tongTien;
                    Session.BillData.DiscountVIP = trietKhauVIP;
                    Session.BillData.TienVAT = tienVAT;

                    if (isCustomer)
                    {
                        Session.BillData.TongThanhToan = tongTien - trietKhauVIP - Session.BillData.DiscountVoucher + tienVAT; 
                    }
                    else Session.BillData.TongThanhToan = tongTien + tienVAT;
                }
                LoadLabel();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("frmThanhToan - Lỗi:\n" + ex.Message);
            }
        }//Tính tổng số tiền thanh toán
        private void Update_Voucher(bool isUsed, int STTVoucher, string maKH) 
        {
            //nếu đã dùng thì cập TT sử dụng và thời gian SD
            if (isUsed)
            {
                string sqlUpdateVoucher = $"UPDATE VoucherKhachHang SET TrangThai = 1, NgaySuDung = GETDATE() WHERE STT = @STT AND MaKH = @MaKH";
                using (cmd = new SqlCommand(sqlUpdateVoucher, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@STT", STTVoucher);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private bool UpdateGhiNo()
        {
            if (isGhiNo)
            {
                string number = "0123456789";

                if (txtCCCD.Text.Trim() == "" || txtCCCD.Text.Trim().Length != 12 || txtCCCD.Text.Any(c => !number.Contains(c)) || txtTSTC.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập số CCCD và tài sản thế chấp hợp lệ!!!");
                    return false;
                }
                DateTime ngayGhiNo = DateTime.Now;
                DateTime hanThanhToan = ngayGhiNo.AddDays(10); //Ngày thanh toán nợ là 10 ngày kể từ ngày ghi nợ
                bool trangThai = true; 
                int soNgayQuaHan = 0;
                double phanTramLaiSuat = 0; //Mặc định lãi suất 0%

                try
                {
                    //Thêm vào danh sách ghi nợ
                    string sqlUpdateGhiNo = $"INSERT INTO GhiNo(CCCD, MAHD, TaiSanTheChap, NgayGhiNo, HanThanhToan, SoNgayQuaHan, [TienQuaHan(2%/HD)], TrangThai) VALUES (@CCCD, @MHD, @TSTC, @NGN, @HTT, @SNQH, @LS, @TT)";
                    cmd = new SqlCommand(sqlUpdateGhiNo, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                    cmd.Parameters.AddWithValue("@MHD", Session.RoomData.maHD);
                    cmd.Parameters.AddWithValue("@TSTC", txtTSTC.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGN", ngayGhiNo);
                    cmd.Parameters.AddWithValue("@HTT", hanThanhToan);
                    cmd.Parameters.AddWithValue("@SNQH", soNgayQuaHan);
                    cmd.Parameters.AddWithValue("@LS", phanTramLaiSuat);
                    cmd.Parameters.AddWithValue("@TT", trangThai);
                    cmd.ExecuteNonQuery();

                    //Cập nhật trạng thái hoá đơn
                    Session.BillData.TrangThaiHD = false;
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 2627: // Vi phạm khoá chính
                            MessageBox.Show("Đối tượng này đang ghi nợ chưa trả!!!");
                            return false;
                        default:
                            MessageBox.Show("Lỗi: " + ex.Message);
                            return false;
                    }
                }
            }
            return true;
        } //Cập nhật ghi nợ
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSDT.Text.Length > 10)
                {
                    int sdtTieuChuan = 10;
                    //MessageBox.Show("Số điện thoại <= 10");
                    string newTxtSDT = txtSDT.Text.Remove(sdtTieuChuan, txtSDT.Text.Length - sdtTieuChuan);
                    txtSDT.Text = newTxtSDT;
                    txtSDT.SelectionStart = txtSDT.Text.Length;
                    return;
                }
                string noData = "--";

                string sqlKH = $"SELECT TOP 1 KhachHang.MaKH, KhachHang.TenKH, KhachHang.DiaChi, KhachHang.SoDienThoai, KhachHang.VIP, " +
                    $"KhachHang.DiemTichLuy, BangVIP.TrietKhau FROM KhachHang " +
                    $"LEFT JOIN BangVIP ON BangVIP.VIP = KhachHang.VIP " +
                    $"WHERE KhachHang.SoDienThoai = '{txtSDT.Text}' " +
                    $"ORDER BY MaKH ASC";
                dt = kn.CreateTable(sqlKH);

                if (dt.Rows.Count > 0 && txtSDT.Text.Length == 10)
                {
                    isCustomer = true;
                    btnVoucher.Visible = isCustomer;
                    //Gán dữ liệu
                    Session.CustomerData.MaKH = dt.Rows[0]["MaKH"].ToString();
                    lblTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                    lblDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    lblVIP.Text = dt.Rows[0]["VIP"].ToString();
                    lblDiemTichLuy.Text = dt.Rows[0]["DiemTichLuy"].ToString();
                    lblDiscount.Text = $"Triết khấu VIP ({(Convert.ToDouble(dt.Rows[0]["TrietKhau"])).ToString()}%):";

                    //Xử lý giảm giá
                    trietKhauVIP = Session.BillData.TongTien * (Convert.ToDecimal(dt.Rows[0]["TrietKhau"]) / 100);

                    //Gọi hàm
                    if (isCustomer)
                    {
                        LoadQRCode(); //Trong hàm này đã load hàm TongThanhToan()
                    }
                }
                else
                {
                    isCustomer = false; //Khách hàng mới

                    Session.CustomerData.SoDienThoai = txtSDT.Text;
                    lblTenKH.Text = noData;
                    lblDiaChi.Text = noData;
                    lblVIP.Text = noData;
                    lblDiemTichLuy.Text = noData;
                    lblDiscount.Text = noData;
                    lblTrietKhau.Text = noData;

                    btnVoucher.Visible = isCustomer;
                    picQRCode.Image = null;
                }
                if (txtSDT.Text.Length == 10 && !isCustomer) 
                {
                    if (MessageBox.Show("Khách hàng mới, thêm khách hàng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        frmKhachHang kh = new frmKhachHang();

                        kh.ShowDialog();
                    }
                }; //Load khách hàng chưa tồn tại

                lblTienThanhToan.Text = Session.BillData.TongThanhToan.ToString("#,##0 VND");

                if (PTTT == "Tiền mặt")
                {
                    if(txtTienNhan.Text != "")
                    {
                        int tienNhan = Convert.ToInt32(txtTienNhan.Text.Replace(".", ""));
                        txtTraLai.Text = (tienNhan - Session.BillData.TongThanhToan).ToString("#,##0");
                    }
                }
                TongThanhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void btnQRCode_Click(object sender, EventArgs e)
        {
            plQRCode.Show();
            plGhiNo.Hide();
            plCash.Hide();
            plTTKH.Visible = true;
            //Đặt tên theo PTTT
            PTTT = "QR Code";
            lblPTTT.Text = "PTTT: " + PTTT;

            LoadLabel();

            LoadQRCode(); //Trong hàm này đã load hàm TongThanhToan()
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Xuất hoá đơn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                Session.BillData.isPay = true;
                Session.BillData.PTTT = PTTT;
                Session.BillData.TrangThaiHD = true;

                //Khách hàng
                TichDiemKH();
                Update_Voucher(Session.isUsedVoucher, Session.STTVoucher, Session.CustomerData.MaKH);
                //cập nhật ghi nợ nếu có
                if (!UpdateGhiNo()) return;

                //Ghi log vào file
                Session.Datalog("payment.txt", $"Mã NV: {Session.StaffData.MaNV} Đã thực hiện thanh toán hoá đơn >> {Session.RoomData.maHD} <<");

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
                Session.BillData.DiscountVoucher = 0;

                plQRCode.Hide();
                plCash.Hide();
                plGhiNo.Hide();
                plTTKH.Visible = false;
                btnVoucher.Visible = isCustomer;

                lblTienThanhToan.Text = Session.BillData.TongThanhToan.ToString("#,##0 VND");
                txtSDT.Text = Session.CustomerData.SoDienThoai;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            TongThanhToan();

            plQRCode.Hide();
            plGhiNo.Hide();
            plCash.Show();
            plTTKH.Visible = true;
            txtTraLai.Text = "0";
            //Đặt tên theo PTTT
            PTTT = "Tiền mặt";
            lblPTTT.Text = "PTTT: " + PTTT;
        }
        #region Nút ấn tiền mặt
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
                txtTraLai.Text = (tienNhan - Session.BillData.TongThanhToan).ToString("#,##0");
            }
            else
            {
                txtTraLai.Text = "0";
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }

        private void btnGhiNo_Click(object sender, EventArgs e)
        {
            plGhiNo.Show();
            plQRCode.Hide();
            plCash.Hide();
            plTTKH.Visible = true;

            //Đặt tên theo PTTT
            PTTT = "Ghi nợ";
            lblPTTT.Text = "PTTT: " + PTTT;
            isGhiNo = true;
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            frmVoucherKhachHang frmVoucher = new frmVoucherKhachHang();
            frmVoucher.FormBorderStyle = FormBorderStyle.None;

            frmVoucher.FormClosed += (s, args) =>
            {
                TongThanhToan();
                txtVoucher.Text = Session.tenVoucher.ToString();
            };

            frmVoucher.ShowDialog();
        }
    }
}
