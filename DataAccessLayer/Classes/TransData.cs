
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
namespace DataAccessLayer
{
    internal class TransData
    {
    }
    public static class Session
    {
        static ConnectData kn = new ConnectData();
        static DataTable dt = null;
        static SqlCommand cmd = null;
        public static Dictionary<int, string> dictThongSo = new Dictionary<int, string>();
        public static class VoucherData
        {
            //Voucher
            public static int STTVoucher { get; set; } //STT voucher được chọn để áp dụng vào hoá đơn
            public static string maVoucher { get; set; } = "";//Mã voucher được chọn
            public static string tenVoucher { get; set; } = "";//Tên voucher được chọn
            public static string HinhAnh { get; set; } = "";
            public static bool isUsedVoucherKH { get; set; } //Đã áp dụng voucher vào hoá đơn hay chưa
            public static string VCHMaPhatHanh { get; set; }
            public static decimal giamVoucher = 0; // Tiền giảm voucher
            public static void TinhTienGiamGia(bool freeVoucher, int stt = -99)
            {
                string sqlLayVoucher = $"SELECT Voucher.GiaTriGiam, Voucher.LoaiGiamGia, Voucher.GiamToiDa FROM Voucher WHERE Voucher.MaPhatHanh = '{VCHMaPhatHanh}'";
                if (CustomerData.isCustomer && !freeVoucher)
                {
                    sqlLayVoucher = $"SELECT Voucher.GiaTriGiam, Voucher.LoaiGiamGia, Voucher.GiamToiDa FROM VoucherKhachHang \n" +
                    $"INNER JOIN VouCher ON Voucher.MaVoucher = VoucherKhachHang.MaVoucher " +
                    $"WHERE VoucherKhachHang.TrangThai = 0 AND VoucherKhachHang.MaKH = '{CustomerData.MaKH}' AND VoucherKhachHang.STT = {stt}";
                }
                dt = kn.CreateTable(sqlLayVoucher);

                if (dt.Rows.Count > 0)
                {

                    decimal giaTriGiam = Convert.ToDecimal(dt.Rows[0]["GiaTriGiam"]);

                    //Nếu là true thì sẽ giảm theo %
                    if (Convert.ToBoolean(dt.Rows[0]["LoaiGiamGia"]))
                    {
                        giamVoucher = BillData.TongTien * giaTriGiam;

                        if (giamVoucher > Convert.ToDecimal(dt.Rows[0]["GiamToiDa"]) && Convert.ToDecimal(dt.Rows[0]["GiamToiDa"]) > 0)
                        {
                            giamVoucher = Convert.ToDecimal(dt.Rows[0]["GiamToiDa"]);
                        }
                    }
                    //Giảm theo tiền
                    else
                    {
                        giamVoucher = giaTriGiam;
                    }
                }
                else
                {
                    giamVoucher = 0;
                }
            } //tính tiền giảm giá của voucher
            public static void KiemTraVoucher()
            {
                ConnectOpen();

                DateTime ngayHetHan = Convert.ToDateTime("01/01/2020");
                DateTime today = DateTime.Today;
                int trangThai = 2; //Trạng thái hết hạn
                int STT = 0;

                string sqlVoucherCheck = "SELECT STT, NgayHetHan FROM VoucherKhachHang";
                dt = new DataTable();
                dt = kn.CreateTable(sqlVoucherCheck);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["NgayHetHan"] != null && row["NgayHetHan"] != DBNull.Value)
                    {
                        ngayHetHan = Convert.ToDateTime(row["NgayHetHan"]);
                        STT = Convert.ToInt32(row["STT"]);
                    }

                    if (DateTime.Now > ngayHetHan)

                    {
                        string updateTrangThai = $"UPDATE VoucherKhachHang SET TrangThai = {trangThai} WHERE STT = {STT}";
                        cmd = new SqlCommand(updateTrangThai, kn.conn);
                        cmd.ExecuteNonQuery();
                    }
                }
            } // Hàm kiểm tra voucher hết hạn
            public static bool InspectQuantityVoucher(string maVoucher)
            {
                ConnectOpen();
                int soLuong = 0;
                string sqlCheck = $"SELECT SoLuongPhatHanh FROM Voucher WHERE MaVoucher = '{maVoucher}'";
                dt = new DataTable();
                dt = kn.CreateTable(sqlCheck);
                if (dt.Rows.Count > 0)
                {
                    soLuong = Convert.ToInt32(dt.Rows[0]["SoLuongPhatHanh"]);
                    if (soLuong - 1 > 0)
                    { 
                        string sqlUpdate = $"UPDATE Voucher SET SoLuongPhatHanh = SoLuongPhatHanh - 1 WHERE MaVoucher = '{maVoucher}'";
                        cmd = new SqlCommand(sqlUpdate, kn.conn);
                        int c =cmd.ExecuteNonQuery();
                        return c==1;
                    }
                    else
                    {
                        MessageBox.Show("Voucher đã hết số lượng, vui lòng chọn voucher khác!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Voucher không tồn tại, vui lòng chọn voucher khác!");
                    return false;
                }
            } //Hàm kiểm tra voucher còn hàng hay không 
        }
        public static class WarehouseData
        {
            public static string MaSP;
            public static string TenSP;
            public static string DanhMuc;
            public static string DonViTinh;
            public static string TonKho;
            public static DateTime NgayCapNhat;
            public static decimal DonGiaNhap;
            public static int TrangThai;
            public static string GhiChu;
            public static string HinhAnh;
        }
        public static class CustomerData
        {
            public static string MaKH = "KH000";
            public static string TenKH;
            public static string DiaChi;
            public static string SoDienThoai;
            public static string VIP;
            public static double DiemTichLuy;

            public static bool isCustomer { get; set; }
        }
        public static class StaffData
        {
            public static string MaNV;
            public static string TenNV;
            public static string GioiTinh;
            public static DateTime NamSinh;
            public static string DiaChi;
            public static string SoDienThoai;
            public static string Email;
            public static DateTime NgayLamViec;
            public static int ChucVu;
            public static Decimal LuongCoBan;
            public static string HinhAnh;
            public static string QuyenHan;

            public static string IDUser { get; set; }

            public static string GetMaNVFromIDU()
            {
                try
                {
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = kn.conn;
                        cmd.CommandText = "SELECT MaNV FROM Users WHERE IDUser = @IDU";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDU", Session.StaffData.IDUser);
                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : string.Empty;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("frmPhieuKiemKe - GetMaNV() \nLỗi: " + ex.Message);
                    return string.Empty;
                }
            }
            public static void SendEmail(string toEmail, int OTP)
            {
                try
                {
                    var fromAddress = new MailAddress(dictThongSo[8] ?? "KaraokeParadise3008@gmail.com", "Karaoke Paradise"); //email gưie
                    var toAddress = new MailAddress(toEmail); //email nhận
                    string appPassword = "sbgwremfxsupovrg"; //Google App Password
                    string subject = "Mã xác thực đổi mật khẩu"; //Tiêu đề
                    string body = $"Mã OTP của bạn là: {OTP} mã có hiệu lực trong vòng {dictThongSo[10]} phút, tuyệt đối không chia sẽ mã này với bất kì ai.";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, appPassword)
                    }; //Phương thức gửi

                    using (var message = new MailMessage(fromAddress, toAddress))
                    {
                        message.Subject = subject;
                        message.Body = body;
                        smtp.Send(message);
                    }//Gửi email
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmChangePasswd - SendEmail - Lỗi:\n" + ex.Message);
                    return;
                }
            } //Hàm gửi mã OTP về Email
        }
        public static class RoomData
        {
            public static int maHD { get; set; }
            public static string maPhong = "";
            public static string tenPhong = "";

            public static int status { get; set; } //0 là đóng, 1 là đang dùng, 2 là đặt trc, 3 là huỷ đặt
            public static DateTime TimeOut { get; set; } // Thời gian đóng phòng
            public static string GetPhoneNumber(string maPhong)
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "SELECT SDT_KhachHang FROM Booking WHERE MaPhong = @MaPhong AND TrangThai = 1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
            public static void UpdateBookingStatus(string maPhong)
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = "UPDATE Booking SET TrangThai = 3 WHERE MaPhong = @MaPhong AND TrangThai = 1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static class BillData
        {
            public static int maHD { get; set; }
            public static double TongSoPhut { get; set; } //Tổng số phút sử dụng phòng
            public static decimal TongTien { get; set; } //Tiền phòng + dịch vụ
            public static decimal TongTienDV { get; set; } // tiền dịch vụ
            public static decimal TongTienPhong { get; set; }
            public static decimal TienVAT { get; set; } //thuế GTGT 5%, 0.1 - 10% thuế GTGT
            public static decimal DiscountVIP { get; set; } //Giảm giá theo VIP
            public static decimal TongThanhToan { get; set; } // Tổng tiền - Ưu đãi + VAT
            //public static decimal GhiChu { get; set; } //Ghi chú giảm giá
            public static bool isPay { get; set; } // Nếu true là đã thanh toán và sẽ xuất hoá đơn
            public static string PTTT { get; set; } //Phương thức thanh toán
            public static bool TrangThaiHD { get; set; } // Trạng thái hoá đơn
        }
        public static class ProductData
        {
            public static string MaSP_Menu { get; set; }
            public static string MaSP_Kho { get; set; }

            public static bool isChecked { get; set; }
        }
        public static class ComboData
        {
            public static string MaCombo { get; set; }
            public static string TenCombo { get; set; }
            public static bool isCombo { get; set; } = false; //Kiểm tra xem sản phẩm thêm vào có phải combo hay không
        }
        public static class PhieuNhapData
        {
            public static string MaPN { get; set; }
        }
        public class FontStandard
        {
            //times new
            public Font timeNew10_Regular = new Font("Times New Roman", 10F, FontStyle.Regular);
            public Font timeNew10_Bold = new Font("Times New Roman", 10F, FontStyle.Bold);

            public Font timeNew12_Regular = new Font("Times New Roman", 12F, FontStyle.Regular);
            public Font timeNew12_Bold = new Font("Times New Roman", 12F, FontStyle.Bold);

            //tahoma
            public Font tahoma9_Regular = new Font("Tahoma", 9, FontStyle.Regular);

            public Font tahoma9_Bold = new Font("Tahoma", 9, FontStyle.Bold);
            public Font tahoma12_Bold = new Font("Tahoma", 12, FontStyle.Bold);
            public Font tahoma16_Bold = new Font("Tahoma", 16, FontStyle.Bold);

            public Font timeNew14_Bold = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);

            public Font timeNew18_Bold = new Font("Times New Roman", 18F, FontStyle.Bold);

            public Font timeNew26_Bold = new Font("Times New Roman", 26, FontStyle.Bold);
        }

        public static bool isDeleted = false; //Biến kiểm tra khi xoá sản phẩm, khách hàng, nhân viên,...
        public static void ConnectOpen()
        {
            kn.ConnOpen();
        }
        public static void FreeUpMemoryForm(Form frm)
        {
            while (frm.Controls.Count > 0)
            {
                Control ctrl = frm.Controls[0];
                frm.Controls.RemoveAt(0);
                ctrl.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public static void UpdatePhoneNumberForRoom(string phoneNumber)
        {
            try
            {
                ConnectOpen();

                string sqlUpdate = "UPDATE Booking SET SDT_KhachHang = @SDTKH WHERE MaPhong = @MP AND TrangThai = 0";
                using (cmd = new SqlCommand(sqlUpdate, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@SDTKH", phoneNumber);
                    cmd.Parameters.AddWithValue("@MP", RoomData.maPhong);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Session - UpdatePhoneNumberForRoom Lỗi: \n" + ex.Message);
            }
        }
        public static void FreeUpMemoryPanel(Panel pl)
        {
            while (pl.Controls.Count > 0)
            {
                Control ctrl = pl.Controls[0];
                pl.Controls.RemoveAt(0);
                ctrl.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public static void FreeUpMemoryFlowPanel(FlowLayoutPanel pl)
        {
            while (pl.Controls.Count > 0)
            {
                Control ctrl = pl.Controls[0];
                pl.Controls.RemoveAt(0);
                ctrl.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public static decimal TinhTienPhongSau_22h(DateTime timeIn, decimal PricePerHour)
        {
            //Console.WriteLine(PricePerHour.ToString());
            TimeSpan gioVao = timeIn.TimeOfDay;
            if (gioVao >= new TimeSpan(22, 0, 0) || gioVao <= new TimeSpan(6, 0, 0))
            {
                PricePerHour = PricePerHour + (PricePerHour * (Convert.ToDecimal(dictThongSo[3]) / 100));
                //Console.WriteLine(PricePerHour.ToString());
            }
            return PricePerHour;
        }
        
        public static void Datalog(string fileTxtName, string content)
        {
            if(!System.IO.File.Exists($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\{fileTxtName}"))
            {
                System.IO.File.Create($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\{fileTxtName}").Dispose(); //tạo mới
            }//Nếu chưa có file
            System.IO.File.AppendAllText($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\{fileTxtName}", $"\n{DateTime.Now.ToString()}: {content}");
        } //Lưu log 
        public static void KiemTraGhiNo()
        {
            ConnectOpen();

            dt = new DataTable();
            DateTime homNay = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            int maHD = 0;
            TimeSpan soNgayQuaHan = TimeSpan.Zero;
            double laiSuat = (Convert.ToDouble(dictThongSo[2]) / 100); //Lãi suất 2%/ngày

            string sqlGhiNo = "SELECT * FROM GhiNo";
            dt = kn.CreateTable(sqlGhiNo);
            foreach (DataRow row in dt.Rows)
            {
                DateTime hanThanhToan = Convert.ToDateTime(row["HanThanhToan"].ToString());
                if (homNay > hanThanhToan)
                {
                    maHD = Convert.ToInt32(row["MaHD"].ToString());
                    soNgayQuaHan = homNay - hanThanhToan;
                }
                string sqlUpdateGhiNo = "UPDATE GhiNo SET SoNgayQuaHan = @SNQH, [TienQuaHan(2%/HD)] = @TQH WHERE MaHD = @MaHD";
                cmd = new SqlCommand(sqlUpdateGhiNo, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@SNQH", soNgayQuaHan.Days);
                cmd.Parameters.AddWithValue("@TQH", laiSuat * soNgayQuaHan.Days);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.ExecuteNonQuery();
            }


        }//Hàm kiểm tra ghi nợ quá hạn trả

        public static int AutoCreateID_Interger(string colName, string tableName) //tạo mã số tự động
        {
            ConnectOpen();

            string sqlGetMaxID = $"SELECT TOP 1 {colName} FROM {tableName} ORDER BY {colName} DESC";
            dt = new DataTable();
            dt = kn.CreateTable(sqlGetMaxID);
            int MaHD = 0;
            foreach (DataRow dr in dt.Rows)
            {
                MaHD = Convert.ToInt16(dr[colName]);
            }
            return MaHD += 1;
        }
        public static string AutoCreateID_String(string colName, string tableName, string target)
        {
            ConnectOpen();

            string sqlGetMaxID = $"SELECT TOP 1 {colName} FROM {tableName} ORDER BY {colName} DESC";
            cmd = new SqlCommand(sqlGetMaxID, kn.conn);

            string id = cmd.ExecuteScalar() != null ? cmd.ExecuteScalar().ToString().Replace(target, "") : "0";
            int tangMa = Convert.ToInt16(id) + 1;
            string newID = null;

            if (target.Length == 3 && target != "SPK" && target != "SPM")
            {
                //Định dạng lại mã nếu <10 thì thêm 2 số 0, <100 thì thêm 1 số 0
                if (tangMa < 10)
                    newID = target + "0" + tangMa.ToString();
                else
                    newID = target + tangMa.ToString();
                return newID;
            }
            else
            {
                //Định dạng lại mã nếu <10 thì thêm 2 số 0, <100 thì thêm 1 số 0
                if (tangMa < 10)
                    newID = target + "00" + tangMa.ToString();
                else if (tangMa < 100)
                    newID = target + "0" + tangMa.ToString();
                else
                    newID = target + tangMa.ToString();
                return newID;
            }
        } //Tạo mã có chuỗi
        public static void CapNhatKho(bool isPlus, string maSP, double soLuong)
        {
            ConnectOpen();

            string sqlSanPham = $"SELECT KhoHang.TonKho, KhoHang.DonViTinh, SanPham.DinhLuong FROM Khohang " +
                $"INNER JOIN SanPham ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                $"WHERE SanPham.MaSP_Menu = '{maSP}'";
            if (ComboData.isCombo)
            {
                sqlSanPham = "SELECT SanPham.MaSP_Menu, KhoHang.TonKho, KhoHang.DonViTinh, SanPham.DinhLuong, ChiTietCombo.SoLuong " +
                    "FROM KhoHang " +
                    "INNER JOIN SanPham ON SanPham.MaSP_Kho = KhoHang.MaSP_Kho " +
                    "INNER JOIN ChiTietCombo ON ChiTietCombo.MaSP = SanPham.MaSP_Menu " +
                    $"WHERE ChiTietCombo.MaComBo = '{maSP}'";
            }

            dt = kn.CreateTable(sqlSanPham);
            foreach (DataRow row in dt.Rows)
            {
                double newSoLuong = soLuong;

                double soLuongTon = row["TonKho"] != DBNull.Value ? Convert.ToDouble(row["TonKho"]) : 0;
                bool DonViTinh = row["DonViTinh"] != DBNull.Value && row["DonViTinh"].ToString() == "Kg" ? true : false;

                if (ComboData.isCombo)
                {
                    newSoLuong = soLuong * Convert.ToDouble(row["SoLuong"]);
                    Console.WriteLine("SL da thay doi " + newSoLuong);

                    maSP = dt.Rows.Count > 0 ? row["MaSP_Menu"].ToString() : "";
                } // Nếu là combo set lại tham số 

                Console.WriteLine($"Số lượng tồn kho trước khi cập nhật: {soLuongTon}");

                double dinhLuong = row["DinhLuong"] != DBNull.Value ? Convert.ToDouble(row["DinhLuong"]) : 0;

                if (DonViTinh) newSoLuong = newSoLuong * dinhLuong / 1000; //Nếu đơn vị tính là Kg
                else newSoLuong = newSoLuong * dinhLuong;
                Console.WriteLine($"Số lượng sau khi * với định lg/1000: {newSoLuong}");

                if (isPlus) { soLuongTon += newSoLuong; } //Nếu trả lại đồ thì cộng số lượng vào kho
                else { soLuongTon -= newSoLuong; } //Nếu order đồ thì trừ số lượng trong kho

                Console.WriteLine($"Số lượng tồn kho sau khi cập nhật: {soLuongTon}");

                string sqlCapNhatKho = "UPDATE KhoHang SET TonKho = @TonKho " +
                    "FROM KhoHang " +
                    "INNER JOIN SanPham ON SanPham.MaSP_Kho = KhoHang.MaSP_Kho " +
                    "WHERE MaSP_Menu = @MaSP";
                cmd = new SqlCommand(sqlCapNhatKho, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TonKho", soLuongTon);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.ExecuteNonQuery();

                Session.isPlus = null; //Reset lại giá trị isPlus sau khi cập nhật kho
            }
        }
        public static bool InspectInStock(string maSP_MenuOrMaCombo, double soLuong)
        {
            try
            {
                ConnectOpen();
                bool isInStock = false;
                string sqlTonKho = $"SELECT KhoHang.TonKho, SanPham.DinhLuong, KhoHang.DonViTinh FROM Khohang " +
                    $"INNER JOIN SanPham ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                    $"WHERE SanPham.MaSP_Menu = '{maSP_MenuOrMaCombo}'";

                if (ComboData.isCombo)
                {
                    Console.WriteLine($"ma san pham: {maSP_MenuOrMaCombo}");
                    string sqlCTCB = $"SELECT * FROM ChiTietCombo WHERE MaCombo = '{maSP_MenuOrMaCombo}'";
                    using (dt = new DataTable())
                    {
                        dt = kn.CreateTable(sqlCTCB);

                        foreach(DataRow row in dt.Rows)
                        {
                            sqlTonKho = $"SELECT KhoHang.TonKho, SanPham.DinhLuong, KhoHang.DonViTinh FROM Khohang " +
                                $"INNER JOIN SanPham ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                                $"WHERE SanPham.MaSP_Menu = '{row["MaSP"]}'";

                            using (cmd = new SqlCommand(sqlTonKho, kn.conn))
                            {
                                double tonKho = cmd.ExecuteScalar() != DBNull.Value && cmd.ExecuteScalar() != null ? Convert.ToDouble(cmd.ExecuteScalar().ToString()) : 0;

                                isInStock = Convert.ToDouble(dictThongSo[4]) > tonKho ? false : true;
                                Console.WriteLine($"ton kho: {tonKho}, so luong: {soLuong}, isInStock: {isInStock}");

                                if (isInStock) continue;
                                else return isInStock; //Nếu một món không đủ thì return
                            }
                        }
                    }
                } // Nếu là combo thì kiểm tra từng món
                else
                {
                    using (dt = new DataTable())
                    {
                        dt = kn.CreateTable(sqlTonKho);
                        double tonKho = Convert.ToDouble(dt.Rows[0]["TonKho"].ToString());

                        if (dt.Rows[0]["DonViTinh"].ToString() == "Kg") soLuong = soLuong * Convert.ToDouble(dt.Rows[0]["DinhLuong"]) / 1000;
                        else soLuong = soLuong * Convert.ToDouble(dt.Rows[0]["DinhLuong"]);

                        isInStock = soLuong > tonKho ? false : true;
                    }
                }
                return isInStock;
            }
            catch (Exception ex)
            {
                MessageBox.Show("TransData - InspectInStock Lỗi:\n " + ex.Message);
                return false;
            }
        }
        public static bool InspectStorage()
        {
            ConnectOpen();
            dt = new DataTable();
            dt = kn.CreateTable("SELECT TonKho FROM KhoHang WHERE TonKho < 1");
            if(dt.Rows.Count > 0) { return false; }

            return true;
        }//Kiểm tra tồn kho về 0 thì báo đỏ
        public static bool xuLyChuoi(string[] textBoxArray)
        {
            foreach (string textBox in textBoxArray)
            {
                if (textBox.Contains("'")) return false;
            }
            return true;
        }
        public static bool XuLySo(string[] textBoxArray)
        {
            foreach (string textBox in textBoxArray)
            {
                if (!decimal.TryParse(textBox.Replace(".", ""), out decimal value) || value < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool XuLySDT(string phoneNumber)
        {
            if (phoneNumber.Length > 10)
            {
                MessageBox.Show("Số điện thoại phải bằng 10 chữ số");
                return false;
            }
            if (phoneNumber.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải bằng 10 chữ số");
                return false;
            }
            if (!(int.TryParse(phoneNumber, out int value)))
            {
                MessageBox.Show("Số điện thoại phải là chữ số");
                return false;
            }
            return true;
        }
        //public static void FocusDataByID(string id)
        //{
        //    if (string.IsNullOrEmpty(id)) return;

        //    foreach (DataGridViewRow row in dgvKhachHang.Rows)
        //    {
        //        if (row.Cells["MaKH"].Value != null && row.Cells["MaKH"].Value.ToString() == id)
        //        {
        //            // Bỏ chọn các dòng cũ
        //            dgvKhachHang.ClearSelection();
        //            // Chọn dòng hiện tại
        //            row.Selected = true;
        //            // Đặt ô hiện tại để cái khung hình chữ nhật bao quanh dòng đó
        //            dgvKhachHang.CurrentCell = row.Cells[0];
        //            // Tự động cuộn tới dòng nếu nằm ở phía dưới
        //            dgvKhachHang.FirstDisplayedScrollingRowIndex = row.Index;

        //            return;
        //        }
        //    }
        //}//Focus khi thêm hoặc sửa dữ liệu
        #region Giá, VAT, lãi suất hoá đơn, giá sau 22h,... trong frmThanhToan
        //Giá VAT, lãi suất hoá đơn, giá sau 22h
        public static void SetParameters_Load()
        {
            ConnectOpen();
            string sqlThongSo = "SELECT * FROM ThongSo ORDER BY STT ASC";
            dt = new DataTable();
            dt = kn.CreateTable(sqlThongSo);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dictThongSo[Convert.ToInt16(dt.Rows[i]["STT"])] = dt.Rows[i]["GiaTri"].ToString();
            }
        }
        #endregion

        public static void StandardDataGridView(DataGridView dgv)
        {
            FontStandard fontS = new FontStandard();

            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            //dgv.BorderStyle = BorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgv.GridColor = Color.FromArgb(62, 58, 52);

            //header
            dgv.EnableHeadersVisualStyles = false;// 1. Cho phép tùy biến Header
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 60;
            //dgv.BackgroundColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font = fontS.tahoma9_Bold;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(62, 58, 52);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(222, 208, 182);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 208, 182);
            //dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            //cells
            dgv.DefaultCellStyle.Font = fontS.tahoma9_Regular;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowTemplate.Height = 35;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(253, 247, 228);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(253, 247, 228);

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(122, 111, 99);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        } //DGV tiêu chuẩn
        public static Nullable<bool> isPlus { get; set; } //Biến tạm để xác định là cộng hay trừ số lượng trong kho, nếu true là cộng, false là trừ, null là chưa xác định
        public static string MaQH { get; set; }
        public static string Passwd { get; } = "admin";

        //Ảnh QR
        public static PictureBox picQRCode { get; set; }
    }

}
