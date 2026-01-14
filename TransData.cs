using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SuperProjectQ
{
    internal class TransData
    {
    }
    public static class Session
    {
        public static void Datalog(string fileTxtName, string content)
        {
            File.AppendAllText($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\{fileTxtName}", $"\n{DateTime.Now.ToString()}: {content}");
        }
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
        public static string maPhong { get; set; }
        public static DateTime TimeOut { get; set; } // Thời gian đóng phòng

        public static double TongSoPhut { get; set; } //Tổng số phút sử dụng phòng
        public static decimal TongTien { get; set; } //Tiền phòng + dịch vụ
        public static decimal TongTienDV { get; set; } // tiền dịch vụ
        public static decimal TongTienPhong { get; set; }
        public static decimal TienVAT { get; set; } //thuế GTGT 5%, 0.1 - 10% thuế GTGT
        public static decimal Discount { get; set; } //Giảm giá theo VIP
        public static decimal TongThanhToan { get; set; } // Tổng tiền - Ưu đãi + VAT
        public static decimal GhiChu { get; set; } //Ghi chú giảm giá
        public static bool isPay { get; set; } // Nếu true là đã thanh toán và sẽ xuất hoá đơn
        public static string PTTT { get; set; } //Phương thức thanh toán
        public static bool TrangThaiHD { get; set; } // Trạng thái hoá đơn
    }
}
