using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SuperProjectQ
{
    internal class SetParameters
    {
        private static ConnectData kn = new ConnectData();
        private static DataTable dt = null;

        private static void ConnectOpen()
        {
            kn.ConnOpen();
        }
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

    }
}
