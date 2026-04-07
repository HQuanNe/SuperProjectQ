using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace DataAccessLayer
{
    public class SetParameters
    {
        private static ConnectData kn = new ConnectData();
        private static DataTable dt = null;

        private static void ConnectOpen()
        {
            kn.ConnOpen();
        }
        #region //Kích thước các panel,... phòng trong frmPhong
        //Kích thước các panel phòng trong frmPhong
        public static int plPhong_WIDTH = 200;
        public static int plPhong_HEIGHT = 153;
        #endregion

        #region //Kích thước các panel, picturebox,... phòng trong frmOrder
        public int plSanPham_WIDTH = 280;
        public int plSanPham_HEIGHT = 300;
        //
        public int pbSanPham_WIDTH = 250;
        public int pbSanPham_HEIGHT = 120;
        //
        public int btnPhong_WIDTH = 60;
        public int btnPhong_HEIGHT = 50;
        #endregion

    }
}
