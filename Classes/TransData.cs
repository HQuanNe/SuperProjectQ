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

        public static class DuLieuKhoHang
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

            public static bool isDeleted = false;


        }

        public static void ConnectOpen()
        {
            kn.ConnOpen();
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

            if (target.Length == 3 && target != "SPK" && target != "MPN")
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
                Console.WriteLine($"Số lượng sau khi * với định lg/1000: {newSoLuong}");

                if ( !isPlus && newSoLuong > soLuongTon)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho!");
                    return;
                }

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
        public static bool InspectStorage()
        {
            ConnectOpen();
            dt = kn.CreateTable("SELECT TonKho FROM KhoHang WHERE TonKho < 1");
            if(dt.Rows.Count > 0) { return false; }

            return true;
        }
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

        #region Giá, VAT, lãi suất hoá đơn, giá sau 22h,... trong frmThanhToan
        //Giá VAT, lãi suất hoá đơn, giá sau 22h
        #region Các thông số
        public static double VAT;
        public static double laiSuat;
        public static double PriceAfter_22H;
        public static double MinTonKho;
        public static double amountPerPointVIP; //Số tiền trên mỗi điểm VIP
        #endregion
        public static void SetParameters_Load()
        {
            ConnectOpen();
            string sqlThongSo = "SELECT * FROM ThongSo";
            dt = new DataTable();
            dt = kn.CreateTable(sqlThongSo);

            VAT = Convert.ToDouble(dt.Rows[0]["GiaTri"]); //Thuế giá trị gia tăng 10%
            laiSuat = Convert.ToDouble(dt.Rows[1]["GiaTri"]); //Lãi suất hoá đơn 2%/ngày khi quá hạn
            PriceAfter_22H = Convert.ToDouble(dt.Rows[2]["GiaTri"]); //Giá sau 22h tăng 20%
            MinTonKho = Convert.ToDouble(dt.Rows[3]["GiaTri"]); //Số lượng tồn kho tối thiểu
            MinTonKho = Convert.ToDouble(dt.Rows[3]["GiaTri"]); //Số lượng tồn kho tối thiểu
            amountPerPointVIP = Convert.ToDouble(dt.Rows[4]["GiaTri"]); //Số tiền trên mỗi điểm VIP
        }
        #endregion

        public static void StandardDataGridView(DataGridView dgv)
        {
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

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Lime;
            //cells
            dgv.DefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowTemplate.Height = 35;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 255, 250);

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 255, 127);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        } //DGV tiêu chuẩn
        public static Nullable<bool> isPlus { get; set; } //Biến tạm để xác định là cộng hay trừ số lượng trong kho, nếu true là cộng, false là trừ, null là chưa xác định

        public static string IDUser { get; set; }
        public static string MaQH { get; set; }
        public static string MaNV { get; set; }
        public static string TenNV { get; set; }
        public static string ChucVu { get; set; }
        public static string Passwd { get; } = "admin";
        //Khách hàng
        public static string MaKH { get; set; }
        public static string SoDienThoai { get; set; }
        public static int diemTichLuy { get; set; }

        //Vận chuyển tiền, nội dung,...  sang thanh toán
        public static int maHD { get; set; }
        public static string maPhong = "";
        public static DateTime TimeOut { get; set; } // Thời gian đóng phòng

        #region Hoá đơn
        public static double TongSoPhut { get; set; } //Tổng số phút sử dụng phòng
        public static decimal TongTien { get; set; } //Tiền phòng + dịch vụ
        public static decimal TongTienDV { get; set; } // tiền dịch vụ
        public static decimal TongTienPhong { get; set; }
        public static decimal TienVAT { get; set; } //thuế GTGT 5%, 0.1 - 10% thuế GTGT
        public static decimal DiscountVIP { get; set; } //Giảm giá theo VIP
        public static decimal DiscountVoucher { get; set; } //Giảm giá theo VIP
        public static decimal TongThanhToan { get; set; } // Tổng tiền - Ưu đãi + VAT
        public static decimal GhiChu { get; set; } //Ghi chú giảm giá
        public static bool isPay { get; set; } // Nếu true là đã thanh toán và sẽ xuất hoá đơn
        public static string PTTT { get; set; } //Phương thức thanh toán
        public static bool TrangThaiHD { get; set; } // Trạng thái hoá đơn
        #endregion
        //Voucher
        public static int STTVoucher { get; set; } //STT voucher được chọn để áp dụng vào hoá đơn
        public static string tenVoucher { get; set; } = "";//Tên voucher được chọn
        public static bool isUsedVoucher { get; set; } //Đã áp dụng voucher vào hoá đơn hay chưa

        public static bool isCombo { get; set; } = false; //Kiểm tra xem sản phẩm thêm vào có phải combo hay không

        //Ảnh QR
        public static PictureBox picQRCode { get; set; }
    }

}
