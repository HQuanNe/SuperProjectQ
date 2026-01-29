using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
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
            double laiSuat = SetParameters.laiSuat; //Lãi suất 2%/ngày

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
        public static string IDUser { get; set; }
        public static string MaQH { get; set; }
        public static string MaNV { get; set; }
        public static string TenNV { get; set; }
        public static string ChucVu { get; set; }
        //Khách hàng
        public static string MaKH { get; set; }
        public static int diemTichLuy { get; set; }
        //Vận chuyển tiền, nội dung,...  sang thanh toán
        public static int maHD { get; set; }
        public static string maPhong = "";
        public static DateTime TimeOut { get; set; } // Thời gian đóng phòng

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
    }
}
