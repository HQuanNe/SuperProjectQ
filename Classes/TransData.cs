using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SuperProjectQ
{
    internal class TransData
    {
    }
    public static class Session
    {
        static ConnectData kn = new ConnectData();
        static DataTable dt = null;
        static SqlCommand cmd = null;

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
        }
        public static class StaffData
        {
            public static string MaNV;
            public static string TenNV;
            public static string GioiTinh;
            public static DateTime NamSinh;
            public static string DiaChi;
            public static string SoDienThoai;
            public static DateTime NgayLamViec;
            public static string ChucVu;
            public static Decimal LuongCoBan;
            public static string HinhAnh;
        }
        public static class RoomData
        {
            public static int maHD { get; set; }
            public static string maPhong = "";
            public static string tenPhong = "";

            public static int status { get; set; } //0 là đóng, 1 là đang dùng, 2 là đặt trc, 3 là huỷ đặt
            public static DateTime TimeOut { get; set; } // Thời gian đóng phòng
        }
        public static class BillData
        {
            public static double TongSoPhut { get; set; } //Tổng số phút sử dụng phòng
            public static decimal TongTien { get; set; } //Tiền phòng + dịch vụ
            public static decimal TongTienDV { get; set; } // tiền dịch vụ
            public static decimal TongTienPhong { get; set; }
            public static decimal TienVAT { get; set; } //thuế GTGT 5%, 0.1 - 10% thuế GTGT
            public static decimal DiscountVIP { get; set; } //Giảm giá theo VIP
            public static decimal DiscountVoucher { get; set; } //Giảm giá theo VIP
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
        }
        public static class ComboData
        {
            public static string MaCombo { get; set; }
            public static string TenCombo { get; set; }
        }
        public static class PhieuNhapData
        {
            public static string MaPN { get; set; }
        }
        public class FontStandard
        {
            public Font timeNew10_Regular = new Font("Times New Roman", 10F, FontStyle.Regular);
            public Font timeNew10_Bold = new Font("Times New Roman", 10F, FontStyle.Bold);

            public Font timeNew12_Regular = new Font("Times New Roman", 12F, FontStyle.Regular);
            public Font timeNew12_Bold = new Font("Times New Roman", 12F, FontStyle.Bold);

            public Font tahoma9_Bold = new Font("Tahoma", 9, FontStyle.Bold);
            public Font tahoma12_Bold = new Font("Tahoma", 12, FontStyle.Bold);

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

                string sqlUpdate = "UPDATE Phong SET SDT_KhachHang = @SDTKH WHERE MaPhong = @MP";
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
        public static decimal TinhTienPhongSau_22h(DateTime timeIn, decimal PricePerHour)
        {
            //Console.WriteLine(PricePerHour.ToString());
            TimeSpan gioVao = timeIn.TimeOfDay;
            if (gioVao >= new TimeSpan(22, 0, 0) || gioVao <= new TimeSpan(6, 0, 0))
            {
                PricePerHour = PricePerHour + (PricePerHour * (Session.PriceAfter_22H / 100));
                //Console.WriteLine(PricePerHour.ToString());
            }
            return PricePerHour;
        }
        public static void Datalog(string fileTxtName, string content)
        {
            File.AppendAllText($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\{fileTxtName}", $"\n{DateTime.Now.ToString()}: {content}");
        } //Lưu log 
        public static void KiemTraGhiNo()
        {
            ConnectOpen();

            dt = new DataTable();
            DateTime homNay = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            int maHD = 0;
            TimeSpan soNgayQuaHan = TimeSpan.Zero;
            double laiSuat = (Session.laiSuat / 100); //Lãi suất 2%/ngày

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
            if (Session.isCombo)
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

                if (Session.isCombo)
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
                bool isInStock = false;
                string sqlTonKho = $"SELECT KhoHang.TonKho, SanPham.DinhLuong, KhoHang.DonViTinh FROM Khohang " +
                    $"INNER JOIN SanPham ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                    $"WHERE SanPham.MaSP_Menu = '{maSP_MenuOrMaCombo}'";

                if (isCombo)
                {
                    string sqlCTCB = $"SELECT * FROM ChiTietCombo WHERE MaCombo = '{maSP_MenuOrMaCombo}'";
                    using (dt = new DataTable())
                    {
                        dt = kn.CreateTable(sqlCTCB);

                        foreach(DataRow maSP_Menu in dt.Rows)
                        {
                            sqlTonKho = $"SELECT KhoHang.TonKho, SanPham.DinhLuong, KhoHang.DonViTinh FROM Khohang " +
                                $"INNER JOIN SanPham ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                                $"WHERE SanPham.MaSP_Menu = '{maSP_Menu}'";

                            using (cmd = new SqlCommand(sqlTonKho, kn.conn))
                            {
                                double tonKho = cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDouble(cmd.ExecuteScalar()) : 0;

                                isInStock = soLuong > tonKho ? false : true;
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

                        isInStock =
                            soLuong > tonKho ? false : true;
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
        #region Các thông số
        public static double VAT;
        public static double laiSuat;
        public static decimal PriceAfter_22H;
        public static double MinTonKho;
        public static double amountPerPointVIP; //Số tiền trên mỗi điểm VIP
        public static string unit; //Số tiền trên mỗi điểm VIP
        public static string DSLoaiBan; //Số tiền trên mỗi điểm VIP
        #endregion
        public static void SetParameters_Load()
        {
            ConnectOpen();
            string sqlThongSo = "SELECT * FROM ThongSo";
            dt = new DataTable();
            dt = kn.CreateTable(sqlThongSo);

            VAT = Convert.ToDouble(dt.Rows[0]["GiaTri"]); //Thuế giá trị gia tăng 10%
            laiSuat = Convert.ToDouble(dt.Rows[1]["GiaTri"]); //Lãi suất hoá đơn 2%/ngày khi quá hạn
            PriceAfter_22H = Convert.ToDecimal(dt.Rows[2]["GiaTri"]); //Giá sau 22h tăng 20%
            MinTonKho = Convert.ToDouble(dt.Rows[3]["GiaTri"]); //Số lượng tồn kho tối thiểu
            amountPerPointVIP = Convert.ToDouble(dt.Rows[4]["GiaTri"]); //Số tiền trên mỗi điểm VIP
            unit = dt.Rows[5]["GiaTri"].ToString(); //Danh sách đơn vị
            DSLoaiBan = dt.Rows[6]["GiaTri"].ToString(); //Loại bán
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
            dgv.BorderStyle = BorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //header
            dgv.EnableHeadersVisualStyles = false;// 1. Cho phép tùy biến Header
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;
            //dgv.BackgroundColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font = fontS.tahoma9_Bold;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(31, 47, 110);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(137, 199, 218);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(82, 142, 194);
            //cells
            dgv.DefaultCellStyle.Font = fontS.timeNew10_Regular;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowTemplate.Height = 35;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 212);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(224, 255, 255);

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 98, 182);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        } //DGV tiêu chuẩn
        public static Nullable<bool> isPlus { get; set; } //Biến tạm để xác định là cộng hay trừ số lượng trong kho, nếu true là cộng, false là trừ, null là chưa xác định

        public static string IDUser { get; set; }
        public static string MaQH { get; set; }
        public static string Passwd { get; } = "admin";

        //Voucher
        public static int STTVoucher { get; set; } //STT voucher được chọn để áp dụng vào hoá đơn
        public static string tenVoucher { get; set; }//Tên voucher được chọn
        public static bool isUsedVoucher { get; set; } //Đã áp dụng voucher vào hoá đơn hay chưa

        //Combo
        public static bool isCombo { get; set; } = false; //Kiểm tra xem sản phẩm thêm vào có phải combo hay không

        //Ảnh QR
        public static PictureBox picQRCode { get; set; }
    }

}
