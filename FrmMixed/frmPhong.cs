using SuperProjectQ.Frm_Main_Login_Register;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SuperProjectQ.FrmMixed
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        DataTable dt = null;
        SqlCommand cmd = null;
        ConnectData kn = new ConnectData();
        string phong_MaNV = "QTV01"; //Session.MaNV;
        Panel selectedPanel = null; // Lưu trữ panel đang được chọn
        string TakeNamePanel = null; //Xử lý khi click vào panel

        string strStatusOpen = "Trạng thái: Đang chạy";
        string strStatusClose = "Trạng thái: Trống";
        string strStatusBooking = "Đã đặt trước";
        Color clrStatusOpen = Color.FromArgb(255, 192, 192);
        Color clrStatusClose = Color.FromArgb(192, 255, 192);
        Color clrStatusBooking = Color.FromArgb(192, 255, 255);

        decimal gloDonGia = 0; //Đơn giá khi click chọn sản phẩm trong bảng đã order
        string gloMaSP = null;
        decimal gloTienPhong = 0;

        private void DoCoSan(int maHD)
        {
            int soLuong = 3;
            string sqlSP = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.GiaBan FROM SanPham \n" +
                "INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP " +
                "WHERE KhoHang.MaSP = 'SP001' OR KhoHang.MaSP = 'SP002' OR KhoHang.MaSP = 'SP011' OR KhoHang.MaSP = 'SP013' OR KhoHang.MaSP = 'SP015'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlSP);
            foreach (DataRow dr in dt.Rows)
            {
                string maSP = dr["MaSP"].ToString();
                string tenSP = dr["TenSP"].ToString();
                string donViTinh = dr["DonViTinh"].ToString();
                decimal donGia = Convert.ToDecimal(dr["GiaBan"]);
                string sqlThemDo = $"INSERT INTO ChiTietHD  (MaCTHD, MaHD, MaSP, SoLuong, DonVi, DonGia, ThanhTien)" +
                    $"VALUES ({AutoCreateID("MaCTHD", "ChiTietHD")}, '{maHD}', '{maSP}', {soLuong}, '{donViTinh}', {donGia}, {soLuong*donGia})";
                cmd = new SqlCommand(sqlThemDo, kn.conn);
                cmd.ExecuteNonQuery();
                TongTienDV(maHD);
            }
        } //Thêm đồ đã setup khi mở phòng
        private int AutoCreateID(string colName, string tableName) //tạo mã tự động
        {
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
        private void Update_Status_Room(int statusInt, string RoomID)
        {
            string sqlUpdateStatus = null, timeIn = null, timeBooking = null;
            switch (statusInt)
            {
                case 0:
                    timeIn = "NULL";
                    timeBooking = "NULL";
                    break;
                case 1:
                    timeIn = "GETDATE()";
                    break;
                case 2:
                    timeIn = "NULL";
                    timeBooking = "GETDATE()";
                    break;
                default:
                    break;
            }
            if (statusInt == 1) sqlUpdateStatus = $"UPDATE Phong SET TrangThai = {statusInt}, GioVao = {timeIn} WHERE MaPhong = '{RoomID}'";
            else if (statusInt == 2 || statusInt == 0) sqlUpdateStatus = $"UPDATE Phong SET TrangThai = {statusInt}, GioVao = {timeIn}, GioDatTruoc = {timeBooking} WHERE MaPhong = '{RoomID}'";
            cmd = new SqlCommand(sqlUpdateStatus, kn.conn);
            cmd.ExecuteNonQuery();
        } //Cập nhật trạng thái phòng
        
        private void UpdatePrice(bool OnBooking, string RoomID) // Cập nhật giá theo ngày đặc biệt
        {
            string phongThuong = null, phongVIP = null, sqlUpdatePrice = null;
            string ngayLe = DateTime.Now.ToString("dd/MM");
            Dictionary<string, string> danhSachNgayLe = new Dictionary<string, string>()
            {
                { "01/01", "Tết Dương Lịch" },
                { "8/03", "Quốc tế phụ nữ" },
                { "30/04", "Giải phóng miền Nam" },
                { "01/05", "Quốc tế Lao động" },
                { "02/09", "Quốc khánh" },
                { "20/10", "Phụ nữ VN" },
                { "20/11", "Nhà Giáo VN" },
                { "25/12", "Giáng sinh" }
            };
            List<string> arrRegular = new List<string>();
            List<string> arrVIP = new List<string>();
            string sqlMaPhong = $"SELECT MaPhong, MaLoaiPhong FROM Phong WHERE MaPhong = '{RoomID}'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlMaPhong);
            //Phân phòng vào mảng theo loại Regular và VIP
            foreach (DataRow dr in dt.Rows )
            {
                string maLoaiPhong = dr["MaLoaiPhong"].ToString();
                string maPhong = dr["MaPhong"].ToString();
                if (maLoaiPhong.Contains("LPR"))
                {
                    arrRegular.Add(maPhong);
                }
                else if (maLoaiPhong.Contains("LPV"))
                {
                    arrVIP.Add(maPhong);
                }
            }
            //Điều kiện khi đặt trước
            if (OnBooking)
            {
                if (danhSachNgayLe.ContainsKey(ngayLe))
                {
                    phongThuong = "LPR05";
                    phongVIP = "LPV05";
                }
                else
                {
                    phongThuong = "LPR04";
                    phongVIP = "LPV04";
                }
                if (arrRegular.Contains(RoomID))
                {
                    sqlUpdatePrice = $"UPDATE Phong SET MaLoaiPhong = '{phongThuong}' WHERE NOT MaPhong = 'MP004' AND NOT MaPhong = 'MP008' AND MaPhong = '{RoomID}'";
                }
                else
                {
                    sqlUpdatePrice = $"UPDATE Phong SET MaLoaiPhong = '{phongVIP}' WHERE  MaPhong = 'MP004' OR MaPhong = 'MP008' AND MaPhong = '{RoomID}'";
                }
            }
            //Điều kiện giá ngày thường
            else
            {
                if (danhSachNgayLe.ContainsKey(ngayLe))
                {
                    phongThuong = "LPR02";
                    phongVIP = "LPV02";
                }
                else
                {
                    phongThuong = "LPR01";
                    phongVIP = "LPV01";
                }
                if (arrRegular.Contains(RoomID))
                {
                    sqlUpdatePrice = $"UPDATE Phong SET MaLoaiPhong = '{phongThuong}' WHERE NOT MaPhong = 'MP004' AND NOT MaPhong = 'MP008' AND MaPhong = '{RoomID}'";
                }
                else
                {
                    sqlUpdatePrice = $"UPDATE Phong SET MaLoaiPhong = '{phongVIP}' WHERE  MaPhong = 'MP004' OR MaPhong = 'MP008' AND MaPhong = '{RoomID}'";
                }
            }
            cmd = new SqlCommand(sqlUpdatePrice, kn.conn); 
            cmd.ExecuteNonQuery();
        }
        private void StatusCheck(string RoomID)
        {
            string sqlStatus = $"SELECT TrangThai FROM Phong WHERE MaPhong = '{RoomID}' ";
            cmd = new SqlCommand(sqlStatus, kn.conn);
            int trangThai = Convert.ToInt16(cmd.ExecuteScalar());

            //Cập nhật giá phòng nếu không đặt trước
            if(trangThai == 0)
            {
                UpdatePrice(false, RoomID);
            }
        }
        private void Add_Bill(int billID, string RoomID)
        {
            try
            {
                string sqlPhong = $"SELECT GioVao FROM Phong WHERE MaPhong = '{RoomID}'";
                dt = new DataTable();
                dt = kn.CreateTable(sqlPhong);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime DateTimIn = Convert.ToDateTime(dr["GioVao"].ToString());

                    //Thêm hoá đơn
                    string sqlHD = $"INSERT INTO HoaDon(MaHD, MaPhong, MaNV, GioVao) " +
                                    $"VALUES ({billID}, '{RoomID}', '{phong_MaNV}', @GV)";
                    cmd = new SqlCommand(sqlHD, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GV", DateTimIn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        } //Thêm bill khi mở phòng
        private void Update_Bill(int billID, string RoomID)
        {
            if (Session.isPay)
            {
                //Update hoá đơn
                string sqlHD = $"UPDATE HoaDon SET MaKH = @MKH," +
                    $"GioRa = @GR, TongSoPhut = @TSP, TienPhong = @TP, TienDichVu = @TDV, TongTien = @TT, GiamGia = @GG, VAT = @VAT, TongThanhToan = @TTT, PTTT = @PTTT, TrangThai = @TTHD, GhiChu = @GC WHERE MaHD = {billID}";
                cmd = new SqlCommand(sqlHD, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MKH", Session.MaKH);
                cmd.Parameters.AddWithValue("@GR", Session.TimeOut);
                cmd.Parameters.AddWithValue("@TSP", Session.TongSoPhut);
                cmd.Parameters.AddWithValue("@TP", Session.TongTienPhong);
                cmd.Parameters.AddWithValue("@TDV", Session.TongTienDV);
                cmd.Parameters.AddWithValue("@TT", Session.TongTien);
                cmd.Parameters.AddWithValue("@GG", Session.Discount);
                cmd.Parameters.AddWithValue("@VAT", Session.TienVAT);
                cmd.Parameters.AddWithValue("@TTT", Session.TongThanhToan);
                cmd.Parameters.AddWithValue("@PTTT", Session.PTTT);
                cmd.Parameters.AddWithValue("@TTHD", Session.TrangThaiHD);
                cmd.Parameters.AddWithValue("@GC", "hi");
                cmd.ExecuteNonQuery();
            }
        } //Cập nhật bill khi đã TT xong
        private void UpdateTonKho(int billID)
        {
            int soLuong = 0;
            string maSP = null, sqlUpdateTonKho = null ;
            double tonKho = 0;
            //Lấy mã sp ở CTHD, số lượng
            string sqlGetCTHD = $"SELECT MaSP, SoLuong FROM ChiTietHD WHERE MaHD = '{billID}'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlGetCTHD);
            foreach (DataRow dr in dt.Rows)
            {
                soLuong = Convert.ToInt32(dr["SoLuong"]);
                maSP = dr["MaSP"].ToString();

                //từ mã sp trên lấy ra đơn vị tính, 
                string sqlDVT = $"SELECT SanPham.MaSP, SanPham.DinhLuong, KhoHang.DonViTinh, KhoHang.TonKho FROM SanPham INNER JOIN KhoHang ON KhoHang.MaSP = SanPham.MaSP WHERE SanPham.MaSP = '{maSP}'";
                dt = new DataTable();
                dt = kn.CreateTable(sqlDVT);
                //lấy tồn kho
                tonKho = Convert.ToDouble(dt.Rows[0]["TonKho"]);
                //nếu đơn vị là kg sẽ tính định lượng sang kg và trừ
                if (dt.Rows[0]["DonViTinh"].ToString() == "Kg")
                {
                    tonKho -= Convert.ToDouble(dt.Rows[0]["DinhLuong"]) * soLuong / 1000;
                    
                }
                //Còn lại chỉ trừ số lượng
                else
                {
                    tonKho -= Convert.ToDouble(soLuong);
                }
                sqlUpdateTonKho = $"UPDATE KhoHang SET TonKho = @TK WHERE MaSP = '{maSP}'";
                cmd = new SqlCommand(sqlUpdateTonKho, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TK", tonKho);
                cmd.ExecuteNonQuery();
            }
        }//Cập nhật tồn kho
        private decimal TongTienDV(int MaHD)
        {
            //Tính tổng tiền
            int tongTienDV = 0;
            string sqlCTHDTam = $"SELECT ThanhTien FROM ChiTietHD WHERE MaHD = {MaHD}";
            dt = new DataTable();
            dt = kn.CreateTable(sqlCTHDTam);
            foreach (DataRow dr in dt.Rows)
            {
                tongTienDV += Convert.ToInt32(dr["ThanhTien"]);
            }
            lblTongTien.Text = tongTienDV.ToString("#,##0 VND");
            Session.TongTienDV = tongTienDV; // Gán biết dùng chung
            return tongTienDV;
        } //Tính tiền DV
        private void GetData_From_CTHD(int maHD) //Load lại dữ liệu đã order khi mở lại chương trình
        {
            string sqlCTHD = $"SELECT ChiTietHD.MaSP, KhoHang.TenSP, ChiTietHD.SoLuong, ChiTietHD.DonVi, ChiTietHD.DonGia, ChiTietHD.ThanhTien " +
            $"FROM ChiTietHD \n" +
            $"INNER JOIN KhoHang ON ChiTietHD.MaSP = KhoHang.MaSP WHERE MaHD = {maHD}";
            dgvOrdered.DataSource = kn.CreateTable(sqlCTHD);
        }
        private void LoadDataCTHD_ByTarget(string maPhong, int panelTag) 
        {
            //Load lại dữ liệu đã order khi mở lại chương trình cụ thể theo phòng
            string sqlRoomStatus = $"SELECT TrangThai FROM Phong WHERE MaPhong = '{maPhong}'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlRoomStatus);

            if (dt.Rows[0]["TrangThai"].ToString() == "1")
            {
                plMenu.Enabled = true;
                plOdered.Enabled = true;

                GetData_From_CTHD(panelTag);
            }
            else if (dt.Rows[0]["TrangThai"].ToString() == "0")
            {
                plMenu.Enabled = false;
                plOdered.Enabled = false;
            }
        } // Load DV đã dùng khi click vào phòng đang mở
        private void AllPanels_Click(object sender, EventArgs e)
        {
            //Xử lý panel đã click trong quá khứ
            if (selectedPanel != null) selectedPanel.BorderStyle = BorderStyle.FixedSingle;

            //Ép kiểu sender về Panel và đổi style sang Fixed3D
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                clickedPanel.BorderStyle = BorderStyle.Fixed3D;

                // Lưu panel đang click để xử lý khi click sang 1 panel khác
                selectedPanel = clickedPanel;
            }
            //selectedPanel = (Panel)sender;
            // Hiển thị  panel này đang chọn
            if (selectedPanel.Name == "plMP001")      {lblInfo.Text = lblP101.Text;}
            else if (selectedPanel.Name == "plMP002") {lblInfo.Text = lblP102.Text;}
            else if (selectedPanel.Name == "plMP003") {lblInfo.Text = lblP103.Text;}
            else if (selectedPanel.Name == "plMP004") {lblInfo.Text = lblP104.Text;}
            else if (selectedPanel.Name == "plMP005") {lblInfo.Text = lblP201.Text;}
            else if (selectedPanel.Name == "plMP006") {lblInfo.Text = lblP202.Text;}
            else if (selectedPanel.Name == "plMP007") {lblInfo.Text = lblP203.Text;}
            else if (selectedPanel.Name == "plMP008") {lblInfo.Text = lblP204.Text;}
            
            //Ản hiện nút theo trạng thái
            string sqlPhong = "SELECT * FROM Phong";
            dt = new DataTable();
            dt = kn.CreateTable(sqlPhong);
            string newSelected = selectedPanel.Name.Replace("pl", "");
            foreach (DataRow dr in dt.Rows)
            {
                if (newSelected == dr["MaPhong"].ToString())
                {
                    if (dr["TrangThai"].ToString() == "0")
                    {
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        break;
                    }
                    else if(dr["TrangThai"].ToString() == "1")
                    {
                        btnOpen.Visible = false;
                        btnClose.Visible = true;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = false;
                        break;
                    }
                    else if (dr["TrangThai"].ToString() == "2")
                    {
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            TakeNamePanel = selectedPanel.Name;
            dgvOrdered.DataSource = null;
            lblTenSP.Text = "--";
            numSoLuong.Value = 0;
            int plTag = Convert.ToInt32(selectedPanel.Tag);
            string maPhong = selectedPanel.Name.Replace("pl", "");
            LoadDataCTHD_ByTarget(maPhong, plTag);
            TongTienDV(plTag);
        }
        private bool XacNhanTT(int billID, string RoomID) //Xác nhận qua bước tt
        {
            bool xacNhanTT = false;
            DialogResult reply = MessageBox.Show("Xác nhận đóng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                //Gán biến toàn chương trình
                Session.maPhong = RoomID;
                frmThanhToan tt = new frmThanhToan();
                tt.ShowDialog();
                if (Session.isPay)
                {
                    xacNhanTT = true;
                }
            }
            return xacNhanTT;
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();
                plMenu.Enabled = false;
                plOdered.Enabled = false;

                string sqlPhong = "SELECT * FROM Phong";
                dt = new DataTable();
                dt = kn.CreateTable(sqlPhong);
                //duyệt tất cả các phòng
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["MaPhong"].ToString() == "MP001")
                    {
                        if(dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP001.BackColor = clrStatusBooking;
                            lblStatus_P101.Text = strStatusBooking;
                        }
                        else if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P101.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP001.BackColor = clrStatusOpen;
                            lblStatus_P101.Text = strStatusOpen;
                        }
                        else if(dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P101.Text = $"Giờ vào: --";
                            plMP001.BackColor = clrStatusClose;
                            lblStatus_P101.Text = strStatusClose;
                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP002")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP002.BackColor = clrStatusBooking;
                            lblStatus_P102.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P102.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP002.BackColor = clrStatusOpen;
                            lblStatus_P102.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P102.Text = $"Giờ vào: --";
                            plMP002.BackColor = clrStatusClose;
                            lblStatus_P102.Text = strStatusClose;
                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP003")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP003.BackColor = clrStatusBooking;
                            lblStatus_P103.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P103.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP003.BackColor = clrStatusOpen;
                            lblStatus_P103.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P103.Text = $"Giờ vào: --";
                            plMP003.BackColor = clrStatusClose;
                            lblStatus_P103.Text = strStatusClose;
                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP004")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP004.BackColor = clrStatusBooking;
                            lblStatus_P104.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P104.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP004.BackColor = clrStatusOpen;
                            lblStatus_P104.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P104.Text = $"Giờ vào: --";
                            plMP004.BackColor = clrStatusClose;
                            lblStatus_P104.Text = strStatusClose;
                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP005")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP005.BackColor = clrStatusBooking;
                            lblStatus_P201.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P201.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP005.BackColor = clrStatusOpen;
                            lblStatus_P201.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P201.Text = $"Giờ vào: --";
                            plMP005.BackColor = clrStatusClose;
                            lblStatus_P201.Text = strStatusClose;
                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP006")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP006.BackColor = clrStatusBooking;
                            lblStatus_P202.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P202.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP006.BackColor = clrStatusOpen;
                            lblStatus_P202.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P202.Text = $"Giờ vào: --";
                            plMP006.BackColor = clrStatusClose;
                            lblStatus_P202.Text = strStatusClose;


                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP007")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP007.BackColor = clrStatusBooking;
                            lblStatus_P203.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P203.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP007.BackColor = clrStatusOpen;
                            lblStatus_P203.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P203.Text = $"Giờ vào: --";
                            plMP007.BackColor = clrStatusClose;
                            lblStatus_P203.Text = strStatusClose;


                        }
                    }
                    else if (dr["MaPhong"].ToString() == "MP008")
                    {
                        if (dr["TrangThai"].ToString() == "2")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = true;
                            plMP008.BackColor = clrStatusBooking;
                            lblStatus_P204.Text = strStatusBooking;
                        }
                        if (dr["TrangThai"].ToString() == "1")
                        {
                            DateTime timeIn = Convert.ToDateTime(dr["GioVao"]);
                            btnOpen.Visible = false;
                            btnClose.Visible = true;
                            btnDatTruoc.Visible = false;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P204.Text = $"Giờ vào: {timeIn.ToString("dd/MM/yyyy HH:mm:ss")}";
                            plMP008.BackColor = clrStatusOpen;
                            lblStatus_P204.Text = strStatusOpen;
                        }
                        else if (dr["TrangThai"].ToString() == "0")
                        {
                            btnOpen.Visible = true;
                            btnClose.Visible = false;
                            btnDatTruoc.Visible = true;
                            btnHuyDatTruoc.Visible = false;
                            lblTimeIN_P204.Text = $"Giờ vào: --";
                            plMP008.BackColor = clrStatusClose;
                            lblStatus_P204.Text = strStatusClose;


                        }
                    }
                    else
                    {
                        continue;
                    }
                    dgvMenuFood.EditMode = DataGridViewEditMode.EditProgrammatically; //Chống xoá dữ liệu
                    dgvMenuFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//Chọn tất cả dữ liệu ở dòng
                    dgvMenuFood.AutoGenerateColumns = false;
                    //Load menu đồ ăn
                    string sqlAllProd = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP " +
                                        "ORDER BY TenSP ASC";
                    dgvMenuFood.DataSource = kn.CreateTable(sqlAllProd);

                    //Load đồ đã order
                    string sqlCTHD = "SELECT HoaDon.MaPhong, HoaDon.MaHD " +
                        "FROM HoaDon " +
                        "INNER JOIN Phong ON HoaDon.MaPhong = Phong.MaPhong WHERE Phong.TrangThai = 1";
                    dt = new DataTable();
                    dt = kn.CreateTable(sqlCTHD);
                    foreach(DataRow dr2 in dt.Rows)
                    {
                        if (dr2["MaPhong"].ToString() == "MP001") plMP001.Tag = Convert.ToInt32(dr2["MaHD"]);
                        else if (dr2["MaPhong"].ToString() == "MP002") plMP002.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                        else if (dr2["MaPhong"].ToString() == "MP003") plMP003.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                        else if (dr2["MaPhong"].ToString() == "MP004") plMP004.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                        else if (dr2["MaPhong"].ToString() == "MP005") plMP005.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                        else if (dr2["MaPhong"].ToString() == "MP006") plMP006.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                        else if (dr2["MaPhong"].ToString() == "MP007") plMP007.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                        else if (dr2["MaPhong"].ToString() == "MP008") plMP008.Tag = Convert.ToInt32(dr2["MaHD"].ToString());
                    }
                    //Ẩn nút Order
                    btnOrder.Visible = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL \nLỗi: " + ex.Message);
            }
        } //Load dữ liệu 
        #region Nút mở, đóng, đặt trước
        private void btnDatTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (TakeNamePanel == null)
                {
                    MessageBox.Show("Hãy chọn một phòng"); return;
                }
                if (MessageBox.Show("Xác nhận đặt trước?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TakeNamePanel == "plMP001")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        lblTimeIN_P101.Text = $"Giờ vào: --";
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeOUT_P101.Text = "Giờ ra: --";
                        plMP001.BackColor = clrStatusBooking;
                        lblStatus_P101.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP002")
                    {
                        //Đổi màu, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P102.Text = $"Giờ vào: --";
                        lblTimeOUT_P102.Text = "Giờ ra: --";
                        plMP002.BackColor = clrStatusBooking;
                        lblStatus_P102.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP003")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P103.Text = $"Giờ vào: --";
                        lblTimeOUT_P103.Text = "Giờ ra: --";
                        plMP003.BackColor = clrStatusBooking;
                        lblStatus_P103.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP004")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P104.Text = $"Giờ vào: --";
                        lblTimeOUT_P104.Text = "Giờ ra: --";
                        plMP004.BackColor = clrStatusBooking;
                        lblStatus_P104.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP005")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P201.Text = $"Giờ vào: --";
                        lblTimeOUT_P201.Text = "Giờ ra: --";
                        plMP005.BackColor = clrStatusBooking;
                        lblStatus_P201.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP006")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P202.Text = $"Giờ vào: --";
                        lblTimeOUT_P202.Text = "Giờ ra: --";
                        plMP006.BackColor = clrStatusBooking;
                        lblStatus_P202.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP007")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P203.Text = $"Giờ vào: --";
                        lblTimeOUT_P203.Text = "Giờ ra: --";
                        plMP007.BackColor = clrStatusBooking;
                        lblStatus_P203.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                    else if (TakeNamePanel == "plMP008")
                    {
                        //Đổi màu, thời gian, chữ
                        string maPhong = TakeNamePanel.Replace("pl", "");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = false;
                        btnHuyDatTruoc.Visible = true;
                        lblTimeIN_P204.Text = $"Giờ vào: --";
                        lblTimeOUT_P204.Text = "Giờ ra: --";
                        plMP008.BackColor = clrStatusBooking;
                        lblStatus_P204.Text = strStatusBooking;

                        Update_Status_Room(2, maPhong);
                        UpdatePrice(true, maPhong);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnHuyDatTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (TakeNamePanel == null)
                {
                    MessageBox.Show("Hãy chọn một phòng"); return;
                }
                else if (TakeNamePanel == "plMP001")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    lblTimeIN_P101.Text = $"Giờ vào: --";
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeOUT_P101.Text = "Giờ ra: --";
                    plMP001.BackColor = clrStatusClose;
                    lblStatus_P101.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP002")
                {
                    //Đổi màu, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P102.Text = $"Giờ vào: --";
                    lblTimeOUT_P102.Text = "Giờ ra: --";
                    plMP002.BackColor = clrStatusClose;
                    lblStatus_P102.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP003")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P103.Text = $"Giờ vào: --";
                    lblTimeOUT_P103.Text = "Giờ ra: --";
                    plMP003.BackColor = clrStatusClose;
                    lblStatus_P103.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP004")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P104.Text = $"Giờ vào: --";
                    lblTimeOUT_P104.Text = "Giờ ra: --";
                    plMP004.BackColor = clrStatusClose;
                    lblStatus_P104.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP005")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P201.Text = $"Giờ vào: --";
                    lblTimeOUT_P201.Text = "Giờ ra: --";
                    plMP005.BackColor = clrStatusClose;
                    lblStatus_P201.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP006")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P202.Text = $"Giờ vào: --";
                    lblTimeOUT_P202.Text = "Giờ ra: --";
                    plMP006.BackColor = clrStatusClose;
                    lblStatus_P202.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP007")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P203.Text = $"Giờ vào: --";
                    lblTimeOUT_P203.Text = "Giờ ra: --";
                    plMP007.BackColor = clrStatusClose;
                    lblStatus_P203.Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
                else if (TakeNamePanel == "plMP008")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P204.Text = $"Giờ vào: --";
                    lblTimeOUT_P204.Text = "Giờ ra: --";
                    plMP008.BackColor = clrStatusClose;
                    lblStatus_P204.Text = strStatusBooking;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (TakeNamePanel == null)
                {
                    MessageBox.Show("Hãy chọn một phòng"); return;
                }
                else if (TakeNamePanel == "plMP001")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    lblTimeIN_P101.Text = $"Giờ vào: {timeIn}";
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeOUT_P101.Text = "Giờ ra: --";
                    plMP001.BackColor = clrStatusOpen;
                    lblStatus_P101.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP001.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    //DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP002")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P102.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P102.Text = "Giờ ra: --";
                    plMP002.BackColor = clrStatusOpen;
                    lblStatus_P102.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP002.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP003")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P103.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P103.Text = "Giờ ra: --";
                    plMP003.BackColor = clrStatusOpen;
                    lblStatus_P103.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP003.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP004")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P104.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P104.Text = "Giờ ra: --";
                    plMP004.BackColor = clrStatusOpen;
                    lblStatus_P104.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP004.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP005")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P201.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P201.Text = "Giờ ra: --";
                    plMP005.BackColor = clrStatusOpen;
                    lblStatus_P201.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP005.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP006")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P202.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P202.Text = "Giờ ra: --";
                    plMP006.BackColor = clrStatusOpen;
                    lblStatus_P202.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP006.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP007")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P203.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P203.Text = "Giờ ra: --";
                    plMP007.BackColor = clrStatusOpen;
                    lblStatus_P203.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP007.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
                else if (TakeNamePanel == "plMP008")
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string timeIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = false;
                    lblTimeIN_P204.Text = $"Giờ vào: {timeIn}";
                    lblTimeOUT_P204.Text = "Giờ ra: --";
                    plMP008.BackColor = clrStatusOpen;
                    lblStatus_P204.Text = strStatusOpen;
                    plMenu.Enabled = true;
                    plOdered.Enabled = true;

                    int billID = AutoCreateID("MaHD", "HoaDon");
                    plMP008.Tag = billID;
                    StatusCheck(maPhong);
                    Update_Status_Room(1, maPhong);
                    Add_Bill(billID, maPhong);
                    DoCoSan(billID);
                    GetData_From_CTHD(billID);
                    TongTienDV(billID);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                dgvOrdered.DataSource = null;
                if (TakeNamePanel == "plMP001")
                {
                    int billID = Convert.ToInt32(selectedPanel.Tag.ToString());
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        lblTimeOUT_P101.Text = $"Giờ ra: {timeOut}";
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        plMP001.BackColor = clrStatusClose;
                        lblStatus_P101.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Them bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                else if (TakeNamePanel == "plMP002")
                {
                    int billID = Convert.ToInt32(plMP002.Tag.ToString());
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    Session.maHD = billID;

                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P102.Text = $"Giờ ra: {timeOut}";
                        plMP002.BackColor = clrStatusClose;
                        lblStatus_P102.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }

                }
                else if (TakeNamePanel == "plMP003")
                {
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    int billID = Convert.ToInt32(plMP003.Tag.ToString());
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P103.Text = $"Giờ ra: {timeOut}";
                        plMP003.BackColor = clrStatusClose;
                        lblStatus_P103.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                else if (TakeNamePanel == "plMP004")
                {
                    int billID = Convert.ToInt32(plMP004.Tag.ToString());
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P104.Text = $"Giờ ra: {timeOut}";
                        plMP004.BackColor = clrStatusClose;
                        lblStatus_P104.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                else if (TakeNamePanel == "plMP005")
                {
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    int billID = Convert.ToInt32(plMP005.Tag.ToString());
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P201.Text = $"Giờ ra: {timeOut}";
                        plMP005.BackColor = clrStatusClose;
                        lblStatus_P201.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                else if (TakeNamePanel == "plMP006")
                {
                    int billID = Convert.ToInt32(plMP006.Tag.ToString());
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P202.Text = $"Giờ ra: {timeOut}";
                        plMP006.BackColor = clrStatusClose;
                        lblStatus_P202.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                else if (TakeNamePanel == "plMP007")
                {
                    int billID = Convert.ToInt32(plMP007.Tag.ToString());
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P203.Text = $"Giờ ra: {timeOut}";
                        plMP007.BackColor = clrStatusClose;
                        lblStatus_P203.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;

                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                else if (TakeNamePanel == "plMP008")
                {
                    int billID = Convert.ToInt32(plMP008.Tag.ToString());
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    Session.maHD = billID;
                    if (XacNhanTT(billID, maPhong))
                    {
                        //Đổi màu, thời gian, chữ
                        string timeOut = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        btnOpen.Visible = true;
                        btnClose.Visible = false;
                        btnDatTruoc.Visible = true;
                        btnHuyDatTruoc.Visible = false;
                        lblTimeOUT_P204.Text = $"Giờ ra: {timeOut}";
                        plMP008.BackColor = clrStatusClose;
                        lblStatus_P204.Text = strStatusClose;
                        plMenu.Enabled = false;
                        plOdered.Enabled = false;
                        //Thêm bill
                        Update_Bill(billID, maPhong);
                        Update_Status_Room(0, maPhong);
                        UpdateTonKho(billID);
                    }
                }
                lblTongTien.Text = "--";
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return;
            }
        }
        #endregion
        private void tabCtrlRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCtrlRoom.SelectedIndex == 0)
            {
                btnOrder.Visible = false;
            }
            else if (tabCtrlRoom.SelectedIndex == 1)
            {
                btnOrder.Visible = true;
            }
        } //Thay đổi tab phòng thường và VIP

        private void dgvMenuFood_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TakeNamePanel !=null)
                {
                    int r = e.RowIndex;
                    string maSP = dgvMenuFood.Rows[r].Cells[0].Value?.ToString();
                    string tenSP = dgvMenuFood.Rows[r].Cells[1].Value?.ToString();
                    string donVi = dgvMenuFood.Rows[r].Cells[2].Value?.ToString();
                    int donGia = Convert.ToInt32(dgvMenuFood.Rows[r].Cells[4].Value?.ToString());
                    decimal thanhTien = 0;
                    int soLuong = 1;
                    bool flag = true;
                    int index = 1;
                    //kiểm tra xem có trong bảng HD tạm chưa
                    for (int i = 0; i <= dgvOrdered.Rows.Count - 1; i++)
                    {
                        if (dgvOrdered.Rows[i].Cells[0].Value != null && dgvOrdered.Rows[i].Cells[0].Value?.ToString() == maSP)
                        {
                            flag = false;
                            index = i;
                            break;
                        }
                    }
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string sqlCTHDTam = $"SELECT MaPhong FROM ChiTietHD WHERE MaSP = '{maSP}'";
                    if (flag) 
                    {
                        string strPanelTag = null;
                        if (maPhong == "MP001") strPanelTag = plMP001.Tag.ToString();
                        else if (maPhong == "MP002") strPanelTag = plMP002.Tag.ToString();
                        else if (maPhong == "MP003") strPanelTag = plMP003.Tag.ToString();
                        else if (maPhong == "MP004") strPanelTag = plMP004.Tag.ToString();
                        else if (maPhong == "MP005") strPanelTag = plMP005.Tag.ToString();
                        else if (maPhong == "MP006") strPanelTag = plMP006.Tag.ToString();
                        else if (maPhong == "MP007") strPanelTag = plMP007.Tag.ToString();
                        else if (maPhong == "MP008") strPanelTag = plMP008.Tag.ToString();

                        int intPanelTag = Convert.ToInt16(strPanelTag);
                        string sqlAdd = "INSERT INTO ChiTietHD (MaCTHD, MaHD, MaSP, SoLuong, DonVi, DonGia, ThanhTien) VALUES (@MCTHD, @MHD, @MSP, @SL, @DV, @DG, @TT)";
                        cmd = new SqlCommand(sqlAdd, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MCTHD", AutoCreateID("MaCTHD", "ChiTietHD"));
                        cmd.Parameters.AddWithValue("@MHD", intPanelTag);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("@SL", 1);
                        cmd.Parameters.AddWithValue("@DV", donVi);
                        cmd.Parameters.AddWithValue("@DG", donGia);
                        cmd.Parameters.AddWithValue("@TT", donGia);
                        cmd.ExecuteNonQuery();
                        GetData_From_CTHD(intPanelTag);
                        TongTienDV(intPanelTag);
                    } 
                    //int SumAdded = 1 + Convert.ToInt16(dgvOrdered.Rows[index].Cells[2].Value);
                    //if (SumAdded > tonKho)
                    //{
                    //    MessageBox.Show("hết");
                    //    return;
                    //}
                    //else
                    //{
                    if (!flag)
                    {
                        soLuong = Convert.ToInt16(dgvOrdered.Rows[index].Cells[2].Value);
                        soLuong++;

                        string strPanelTag = null;
                        if (maPhong == "MP001") strPanelTag = plMP001.Tag.ToString();
                        else if (maPhong == "MP002") strPanelTag = plMP002.Tag.ToString();
                        else if (maPhong == "MP003") strPanelTag = plMP003.Tag.ToString();
                        else if (maPhong == "MP004") strPanelTag = plMP004.Tag.ToString();
                        else if (maPhong == "MP005") strPanelTag = plMP005.Tag.ToString();
                        else if (maPhong == "MP006") strPanelTag = plMP006.Tag.ToString();
                        else if (maPhong == "MP007") strPanelTag = plMP007.Tag.ToString();
                        else if (maPhong == "MP008") strPanelTag = plMP008.Tag.ToString();

                        int intPanelTag = Convert.ToInt16(strPanelTag);
                        string sqlUpdate = "UPDATE ChiTietHD SET SoLuong = @SL, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
                        cmd = new SqlCommand(sqlUpdate, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MHD", intPanelTag);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("@SL", soLuong);
                        cmd.Parameters.AddWithValue("@TT", soLuong * donGia);
                        cmd.ExecuteNonQuery();
                        GetData_From_CTHD(intPanelTag);
                        TongTienDV(intPanelTag);
                    }

                }
                else
                {
                    MessageBox.Show("Hãy chọn một phòng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
        }
        private void AllButtons_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == null) return;
            if (btn.Name == "btnAll")
            {
                dgvMenuFood.DataSource = null;
                string sqlAllProd = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP " +
                                    "ORDER BY TenSP ASC";
                dgvMenuFood.DataSource = kn.CreateTable(sqlAllProd);
            }
            else if(btn.Name == "btnFood")
            {
                dgvMenuFood.DataSource = null;
                string sqlFood = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan \n" +
                                 "FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP WHERE KhoHang.MaDM = 'MDM01' OR KhoHang.MaDM = 'MDM03' ORDER BY TenSP ASC";
                dgvMenuFood.DataSource = kn.CreateTable(sqlFood);
            }
            else if (btn.Name == "btnBeverage")
            {
                //Load đồ uống
                dgvMenuFood.DataSource = null;
                string sqlBeverage = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan \n" +
                                    "FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP WHERE KhoHang.MaDM = 'MDM02' ORDER BY TenSP ASC";
                dgvMenuFood.DataSource = kn.CreateTable(sqlBeverage);
            }
            else if (btn.Name == "btnOther")
            {
                //Load khác
                dgvMenuFood.DataSource = null;
                string sqlOther = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan \n" +
                                  "FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP WHERE KhoHang.MaDM = 'MDM04' ORDER BY TenSP ASC";
                dgvMenuFood.DataSource = kn.CreateTable(sqlOther);
            }
        }

        private void dgvOrdered_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int r = e.RowIndex;
                gloMaSP = dgvOrdered.Rows[r].Cells[0].Value?.ToString();
                lblTenSP.Text = dgvOrdered.Rows[r].Cells[1].Value?.ToString();
                numSoLuong.Value = Convert.ToDecimal(dgvOrdered.Rows[r].Cells[2].Value);
                gloDonGia = Convert.ToInt32(dgvOrdered.Rows[r].Cells[4].Value);
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Xác nhận thay đổi số lượng?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                try
                {
                    decimal soLuong = numSoLuong.Value;
                    string maPhong = TakeNamePanel.Replace("pl", "");
                    string strPanelTag = null;
                    if (maPhong == "MP001") strPanelTag = plMP001.Tag.ToString();
                    else if (maPhong == "MP002") strPanelTag = plMP002.Tag.ToString();
                    else if (maPhong == "MP003") strPanelTag = plMP003.Tag.ToString();
                    else if (maPhong == "MP004") strPanelTag = plMP004.Tag.ToString();
                    else if (maPhong == "MP005") strPanelTag = plMP005.Tag.ToString();
                    else if (maPhong == "MP006") strPanelTag = plMP006.Tag.ToString();
                    else if (maPhong == "MP007") strPanelTag = plMP007.Tag.ToString();
                    else if (maPhong == "MP008") strPanelTag = plMP008.Tag.ToString();

                    int intPanelTag = Convert.ToInt16(strPanelTag);
                    if (soLuong == 0)
                    {
                        string sqlUpdate = "DELETE ChiTietHD WHERE MaHD = @MHD AND MaSP = @MSP";
                        cmd = new SqlCommand(sqlUpdate, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MHD", intPanelTag);
                        cmd.Parameters.AddWithValue("@MSP", gloMaSP);
                        cmd.ExecuteNonQuery();
                        GetData_From_CTHD(intPanelTag);
                        TongTienDV(intPanelTag);
                    }
                    else
                    {
                        string sqlUpdate = "UPDATE ChiTietHD SET SoLuong = @SL, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
                        cmd = new SqlCommand(sqlUpdate, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MHD", intPanelTag);
                        cmd.Parameters.AddWithValue("@MSP", gloMaSP);
                        cmd.Parameters.AddWithValue("@SL", soLuong);
                        cmd.Parameters.AddWithValue("@TT", soLuong * gloDonGia);
                        cmd.ExecuteNonQuery();
                        GetData_From_CTHD(intPanelTag);
                        TongTienDV(intPanelTag);
                    }
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 8178:
                            MessageBox.Show("Hãy chọn một sản phẩm");
                            break;
                        default:
                            MessageBox.Show(ex.Message + " " + ex.Number);
                            break;
                    }
                    //MessageBox.Show(ex.Number.ToString());
                }
            }
        }
    }
}
