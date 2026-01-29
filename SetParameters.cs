using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProjectQ
{
    internal class SetParameters
    {
        //Kích thước các panel
        public static int plDanhSachPhong_WIDTH = 173;
        public static int plDanhSachPhong_HEIGHT = 153;

        //Giá VAT, lãi suất hoá đơn, giá sau 22h
        public const double laiSuat = 0.02; //Lãi suất hoá đơn 2%/ngày khi quá hạn thanh toán
        public const decimal VAT = 0.1m;
        public const decimal PriceAfter_22H = 1.2m;
    }
}
