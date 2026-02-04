using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperProjectQ
{
    internal class SetParameters
    {
        #region //Kích thước các panel,... phòng trong frmPhong
        //Kích thước các panel phòng trong frmPhong
        public static int plDanhSachPhong_WIDTH = 173;
        public static int plDanhSachPhong_HEIGHT = 153;
        #endregion

        #region //Kích thước các panel, picturebox,... phòng trong frmOrder
        public static int plOrder_WIDTH = 290;
        public static int plOrder_HEIGHT = 300;
        //
        public static int pbOrder_WIDTH = 250;
        public static int pbOrder_HEIGHT = 120;
        //
        public static int btnPhong_WIDTH = 60;
        public static int btnPhong_HEIGHT = 50;
        #endregion

        #region Giá, VAT, lãi suất hoá đơn, giá sau 22h,... trong frmThanhToan
        //Giá VAT, lãi suất hoá đơn, giá sau 22h
        public const double laiSuat = 0.02; //Lãi suất hoá đơn 2%/ngày khi quá hạn thanh toán
        public const decimal VAT = 0.1m;
        public const decimal PriceAfter_22H = 1.2m;
        #endregion
    }
}
