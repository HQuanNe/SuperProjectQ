using SuperProjectQ.AllForm;
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
        string strStatusBooking = "Trạng thái: Đã đặt trước";
        Color clrText = Color.Black;
        Color clrStatusOpen = Color.FromArgb(255, 128, 128);
        Color clrStatusClose = Color.FromArgb(192, 255, 192);
        Color clrStatusBooking = Color.FromArgb(192, 255, 255);

        decimal gloDonGia = 0; //Đơn giá khi click chọn sản phẩm trong bảng đã order
        string gloMaSP = null;
        double dinhMucKho = 0; //Định mức tồn kho

        private void LoadPhong()
        {
            string sqlPhong = "SELECT * FROM Phong";
            dt = new DataTable();
            dt = kn.CreateTable(sqlPhong);
            //duyệt tất cả các phòng
            foreach (DataRow row in dt.Rows)
            {
                Panel plPhongTam = new Panel() { Width = 0, Height = 0 }; //Panel tạm để lấy vị trí
                Panel plDanhSanhPhong = new Panel()
                {
                    Padding = new Padding(0),
                    Margin = new Padding(2),
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = SetParameters.plDanhSachPhong_WIDTH,
                    Height = SetParameters.plDanhSachPhong_HEIGHT,
                    Cursor = Cursors.Hand,
                    //Lấy vị trí X phòng tạm cộng với chiều rộng phòng tạm để làm vị trí cho phòng tiếp theo
                    Location = new Point(plPhongTam.Location.X + plPhongTam.Width, plPhongTam.Location.Y),
                    AutoSize = false,
                    AutoSizeMode = AutoSizeMode.GrowOnly,

                    Name = row["MaPhong"].ToString(), //Gán Name theo mã phòng
                };
                Label lblTenPhong = new Label()
                {
                    Enabled = false,

                    Name = row["MaPhong"].ToString(), //Gán Name theo mã phòng
                    Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point),
                    Text = $"Phòng {row["TenPhong"].ToString()}",
                    Location = new Point(plDanhSanhPhong.Width / 2 - 50, 4),
                    ForeColor = Color.Black,
                    AutoSize = true,
                };
                Label lblTrangThai = new Label()
                {
                    Enabled = false,

                    Name = row["MaPhong"].ToString(), //Gán Name theo mã phòng
                    Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point),
                    Location = new Point(0, 100),
                    ForeColor = clrText,
                    AutoSize = true
                };
                if (row["TrangThai"].ToString() == "0")
                {
                    plDanhSanhPhong.BackColor = clrStatusClose;
                    lblTrangThai.Text = strStatusClose;
                }
                else if (row["TrangThai"].ToString() == "1")
                {
                    plDanhSanhPhong.BackColor = clrStatusOpen;
                    lblTrangThai.Text = strStatusOpen;
                }
                else if (row["TrangThai"].ToString() == "2")
                {
                    plDanhSanhPhong.BackColor = clrStatusBooking;
                    lblTrangThai.Text = strStatusBooking;

                }

                if (row["MaLoaiPhong"].ToString().Contains("LPR")) flowLayoutRegular.Controls.Add(plDanhSanhPhong);
                else if (row["MaLoaiPhong"].ToString().Contains("LPV"))
                {
                    flowLayoutVIP.Controls.Add(plDanhSanhPhong); lblTenPhong.Text += " (VIP)";
                    lblTenPhong.Location = new Point(plDanhSanhPhong.Width / 2 - 80, 4);
                }
                ;
                plDanhSanhPhong.Controls.Add(lblTenPhong); //Thêm tên phòng vào flow panel
                plDanhSanhPhong.Controls.Add(lblTrangThai);//Thêm trạng thái vào panel
                plDanhSanhPhong.Click += AllPanels_Click; //Gán sự kiện click cho panel

                plPhongTam = plDanhSanhPhong;//Cập nhật panel tạm bằng panel vừa tạo xong

                //Gán hoá dơn cho phòng tương ứng
                string sqlCTHD = "SELECT HoaDon.MaPhong, HoaDon.MaHD " +
                    "FROM HoaDon " +
                    "INNER JOIN Phong ON HoaDon.MaPhong = Phong.MaPhong WHERE Phong.TrangThai = 1 AND HoaDon.TrangThai = 0";
                dt = new DataTable();
                dt = kn.CreateTable(sqlCTHD);
                foreach (DataRow dr in dt.Rows) 
                {
                    if (plDanhSanhPhong.Name == dr["MaPhong"].ToString()) { plDanhSanhPhong.Tag = Convert.ToInt32(dr["MaHD"]); break; }
                }
            }
        } //Hiển thị phòng
        private void Load_Ordered(int MaHD)
        {
            flowLayoutOrdered.Controls.Clear();

            DataTable dt = new DataTable();
            dt = kn.CreateTable($"SELECT ChiTietHD.MaCTHD, ChiTietHD.MaHD, ChiTietHD.MaSP, SanPham.TenHienThi, ChiTietHD.SoLuong, ChiTietHD.DonViTinh " +
                $"FROM ChiTietHD INNER JOIN SanPham ON ChiTietHD.MaSP = SanPham.MaSP " +
                $"WHERE ChiTietHD.MaHD = {MaHD} ");

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Panel plItem = new Panel()
                    {
                        Width = 290,
                        Height = 40,

                        BackColor = Color.FromName("PaleGreen"),

                        Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point),
                        Margin = new Padding(2),
                    };
                    Label lblTenSP = new Label()
                    {
                        Text = row["TenHienThi"].ToString(),

                        MaximumSize = new Size(150, 50),

                        Location = new Point(5, plItem.Height / 2 - 12),
                        AutoSize = true,
                    };
                    TextBox txtSoLuong = new TextBox()
                    {
                        Text = row["SoLuong"].ToString(),
                        TextAlign = HorizontalAlignment.Center,
                        Size = new Size(25, 24),
                        ReadOnly = true,

                        Location = new Point(lblTenSP.Width + lblTenSP.Location.X + 80, plItem.Height / 2 - 12),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    flowLayoutOrdered.Controls.Add(plItem);
                    plItem.Controls.Add(lblTenSP);
                    plItem.Controls.Add(txtSoLuong);
                }
            }
        }
        private void DoCoSan(int maHD)
        {
            int soLuong = 3;
            string sqlSP = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.GiaBan FROM SanPham \n" +
                "INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP " +
                $"WHERE KhoHang.TonKho >= {dinhMucKho} AND KhoHang.MaSP = 'SP001' OR KhoHang.MaSP = 'SP002' OR KhoHang.MaSP = 'SP011' OR KhoHang.MaSP = 'SP013' OR KhoHang.MaSP = 'SP015'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlSP);
            foreach (DataRow dr in dt.Rows)
            {
                string maSP = dr["MaSP"].ToString();
                string tenSP = dr["TenSP"].ToString();
                string donViTinh = dr["DonViTinh"].ToString();
                decimal donGia = Convert.ToDecimal(dr["GiaBan"]);
                string sqlThemDo = $"INSERT INTO ChiTietHD  (MaCTHD, MaHD, MaSP, SoLuong, DonVi, DonGia, ThanhTien)" +
                    $"VALUES ({Session.AutoCreateID("MaCTHD", "ChiTietHD")}, '{maHD}', '{maSP}', {soLuong}, '{donViTinh}', {donGia}, {soLuong*donGia})";
                cmd = new SqlCommand(sqlThemDo, kn.conn);
                cmd.ExecuteNonQuery();
                TongTienDV(maHD);
            }
        } //Thêm đồ đã setup khi mở phòng
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
                { "25/12", "Giáng sinh" },
                {"21/01", "Ngày thử nghiệm" }
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
            //Điều kiện giá không đặt trước
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
                    string sqlHD = $"INSERT INTO HoaDon(MaHD, MaPhong, MaNV, GioVao, TrangThai) " +
                                    $"VALUES (@MHD, @MP, @MNV, @GV, @TT)";
                    cmd = new SqlCommand(sqlHD, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MHD", billID);
                    cmd.Parameters.AddWithValue("@MP", RoomID);
                    cmd.Parameters.AddWithValue("@MNV", phong_MaNV);
                    cmd.Parameters.AddWithValue("@GV", DateTimIn);
                    cmd.Parameters.AddWithValue("@TT", 0);
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
                    $"GioRa = @GR, TongSoPhut = @TSP, TienPhong = @TP, TienDichVu = @TDV, TongTien = @TT, TrietKhauVIP = @TKVIP, TrietKhauVoucher = @TKV, VAT = @VAT, TongThanhToan = @TTT, PTTT = @PTTT, TrangThai = @TTHD, GhiChu = @GC WHERE MaHD = {billID}";
                cmd = new SqlCommand(sqlHD, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MKH", Session.MaKH);
                cmd.Parameters.AddWithValue("@GR", Session.TimeOut);
                cmd.Parameters.AddWithValue("@TSP", Session.TongSoPhut);
                cmd.Parameters.AddWithValue("@TP", Session.TongTienPhong);
                cmd.Parameters.AddWithValue("@TDV", Session.TongTienDV);
                cmd.Parameters.AddWithValue("@TT", Session.TongTien);
                cmd.Parameters.AddWithValue("@TKVIP", Session.DiscountVIP);
                cmd.Parameters.AddWithValue("@TKV", Session.DiscountVoucher);
                cmd.Parameters.AddWithValue("@VAT", Session.TienVAT);
                cmd.Parameters.AddWithValue("@TTT", Session.TongThanhToan);
                cmd.Parameters.AddWithValue("@PTTT", Session.PTTT);
                cmd.Parameters.AddWithValue("@TTHD", Session.TrangThaiHD);
                cmd.Parameters.AddWithValue("@GC", "test");
                cmd.ExecuteNonQuery();
            }
        } //Cập nhật bill khi đã TT xong
        private void UpdateTonKho(int billID)
        {
            double soLuong = 0;
            string maSP = null, sqlUpdateTonKho = null ;
            double tonKho = 0;
            //Lấy mã sp ở CTHD, số lượng
            string sqlGetCTHD = $"SELECT MaSP, SoLuong FROM ChiTietHD WHERE MaHD = '{billID}'";
            dt = new DataTable();
            dt = kn.CreateTable(sqlGetCTHD);
            foreach (DataRow dr in dt.Rows)
            {
                soLuong = Convert.ToDouble(dr["SoLuong"]);
                maSP = dr["MaSP"].ToString();

                //từ mã sp trên lấy ra đơn vị tính, 
                string sqlDVT = $"SELECT SanPham.MaSP, SanPham.DinhLuong, KhoHang.DonViTinh, KhoHang.TonKho FROM SanPham INNER JOIN KhoHang ON KhoHang.MaSP = SanPham.MaSP WHERE SanPham.MaSP = '{maSP}'";
                dt = new DataTable();
                dt = kn.CreateTable(sqlDVT);
                //lấy tồn kho
                tonKho = Convert.ToDouble(dt.Rows[0]["TonKho"]) - soLuong;
                //nếu đơn vị là kg sẽ tính định lượng sang kg và trừ
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
            decimal tongTienDV = 0;
            string sqlCTHDTam = $"SELECT ThanhTien FROM ChiTietHD WHERE MaHD = {MaHD}";
            dt = new DataTable();
            dt = kn.CreateTable(sqlCTHDTam);
            foreach (DataRow dr in dt.Rows)
            {
                tongTienDV += Convert.ToDecimal(dr["ThanhTien"]);
            }
            //lblTongTien.Text = tongTienDV.ToString("#,##0 VND");
            Session.TongTienDV = tongTienDV; // Gán biết dùng chung
            return tongTienDV;
        } //Tính tiền DV
        private void GetData_From_CTHD(int maHD) //Load lại dữ liệu đã order khi mở lại chương trình
        {
            string sqlCTHD = $"SELECT ChiTietHD.MaSP, SanPham.TenHienThi, ChiTietHD.SoLuong, ChiTietHD.DonViTinh, ChiTietHD.DonGia, ChiTietHD.ThanhTien " +
            $"FROM ChiTietHD \n" +
            $"INNER JOIN SanPham ON ChiTietHD.MaSP = SanPham.MaSP WHERE MaHD = {maHD}";
        }
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
            lblInfo.Text = selectedPanel.Controls[0].Text;// Hiển thị panel này đang chọn

            //Ản hiện nút theo trạng thái
            string sqlPhong = "SELECT * FROM Phong";
            dt = new DataTable();
            dt = kn.CreateTable(sqlPhong);
            foreach (DataRow dr in dt.Rows)
            {
                if (selectedPanel.Name == dr["MaPhong"].ToString())
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
            int maHD = Convert.ToInt32(selectedPanel.Tag);
            string maPhong = selectedPanel.Name;

            Load_Ordered(maHD);
            TongTienDV(maHD);
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
            plOrdered.Visible = false;
            try
            {
                kn.ConnOpen();
                LoadPhong();

                //Ẩn nút Order
                btnOrder.Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL \nLỗi: " + ex.Message);
            }
        } //Load dữ liệu 
        #region Nút mở, đóng, đặt trướcc
        private void btnDatTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (TakeNamePanel == null){ MessageBox.Show("Hãy chọn một phòng"); return;}
                if (MessageBox.Show("Xác nhận đặt trước?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel;

                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = false;
                    btnHuyDatTruoc.Visible = true;

                    selectedPanel.BackColor = clrStatusBooking;
                    selectedPanel.Controls[1].Text = strStatusBooking;

                    Update_Status_Room(2, maPhong);
                    UpdatePrice(true, maPhong);
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
                if (TakeNamePanel == null) {MessageBox.Show("Hãy chọn một phòng"); return;}

                    //Đổi màu, thời gian, chữ
                    string maPhong = TakeNamePanel;
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;

                    selectedPanel.BackColor = clrStatusClose;
                    selectedPanel.Controls[1].Text = strStatusClose;

                    Update_Status_Room(0, maPhong);
                    UpdatePrice(false, maPhong);
            }
            catch (SqlException ex)
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
                //Đổi màu, thời gian, chữ
                string maPhong = TakeNamePanel;
                btnOpen.Visible = false;
                btnClose.Visible = true;
                btnDatTruoc.Visible = false;
                btnHuyDatTruoc.Visible = false;
                flowLayoutOrdered.Enabled = true;

                selectedPanel.BackColor = clrStatusOpen;
                selectedPanel.Controls[1].Text = strStatusOpen;

                int billID = Session.AutoCreateID("MaHD", "HoaDon");

                selectedPanel.Tag = billID;

                StatusCheck(maPhong);
                Update_Status_Room(1, maPhong);
                Add_Bill(billID, maPhong);
                //DoCoSan(billID);
                GetData_From_CTHD(billID);
                TongTienDV(billID);
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
                int billID = Convert.ToInt32(selectedPanel.Tag.ToString());
                string maPhong = TakeNamePanel;
                Session.maHD = billID;

                TongTienDV(billID);

                if (XacNhanTT(billID, maPhong))
                {
                    //Đổi màu, thời gian, chữ
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    flowLayoutOrdered.Enabled = false;

                    selectedPanel.BackColor = clrStatusClose;
                    selectedPanel.Controls[1].Text = strStatusClose;

                    //Them bill
                    Update_Bill(billID, maPhong);
                    Update_Status_Room(0, maPhong);
                    UpdateTonKho(billID);
                }
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

        //private void dgvMenuFood_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (TakeNamePanel !=null)
        //        {
        //            int r = e.RowIndex;
        //            string maSP = dgvMenuFood.Rows[r].Cells[0].Value?.ToString();
        //            string tenSP = dgvMenuFood.Rows[r].Cells[1].Value?.ToString();
        //            string donVi = dgvMenuFood.Rows[r].Cells[4].Value?.ToString();
        //            int donGia = Convert.ToInt32(dgvMenuFood.Rows[r].Cells[5].Value?.ToString());
        //            int soLuong = 1;
        //            bool flag = true;
        //            int index = 1;
        //            //kiểm tra xem sản phẩm có trong bảng đã order chưa
        //            for (int i = 0; i < dgvOrdered.Rows.Count; i++)
        //            {
        //                if (dgvOrdered.Rows[i].Cells[0].Value != null && dgvOrdered.Rows[i].Cells[0].Value?.ToString() == maSP)
        //                {
        //                    flag = false;
        //                    index = i;
        //                    break;
        //                }
        //            }
        //            string maPhong = TakeNamePanel.Replace("pl", "");
        //            string sqlCTHDTam = $"SELECT MaPhong FROM ChiTietHD WHERE MaSP = '{maSP}'";
        //            //Nếu chaưa có thì thêm mới
        //            if (flag) 
        //            {
        //                string strPanelTag = null;
        //                strPanelTag = selectedPanel.Tag.ToString();

        //                int intPanelTag = Convert.ToInt16(strPanelTag);
        //                string sqlAdd = "INSERT INTO ChiTietHD (MaCTHD, MaHD, MaSP, SoLuong, DonVi, DonGia, ThanhTien) VALUES (@MCTHD, @MHD, @MSP, @SL, @DV, @DG, @TT)";
        //                cmd = new SqlCommand(sqlAdd, kn.conn);
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.AddWithValue("@MCTHD", Session.AutoCreateID("MaCTHD", "ChiTietHD"));
        //                cmd.Parameters.AddWithValue("@MHD", intPanelTag);
        //                cmd.Parameters.AddWithValue("@MSP", maSP);
        //                cmd.Parameters.AddWithValue("@SL", 1);
        //                cmd.Parameters.AddWithValue("@DV", donVi);
        //                cmd.Parameters.AddWithValue("@DG", donGia);
        //                cmd.Parameters.AddWithValue("@TT", donGia);
        //                cmd.ExecuteNonQuery();
        //                GetData_From_CTHD(intPanelTag);
        //                TongTienDV(intPanelTag);
        //            }
        //            //Kiểm tra số lượng thêm vào có vượt tồn kho không
        //            int SumAdded = 1 + Convert.ToInt16(dgvOrdered.Rows[index].Cells[2].Value);
        //            //Lấy tồn kho
        //            string sqlTonKho = $"SELECT TonKho FROM KhoHang WHERE MaSP = '{maSP}'";
        //            cmd = new SqlCommand(sqlTonKho, kn.conn);
        //            double tonKho = Convert.ToDouble(cmd.ExecuteScalar());
        //            if (SumAdded > tonKho)
        //            {
        //                MessageBox.Show("hết hàng rùi !!!");
        //                return;
        //            }
        //            else
        //            {
        //                //Nếu có rồi thì cập nhật số lượng lên 1
        //                if (!flag)
        //                {
        //                    soLuong = Convert.ToInt16(dgvOrdered.Rows[index].Cells[2].Value);
        //                    soLuong++;

        //                    int intPanelTag = (int)selectedPanel.Tag;
        //                    string sqlUpdate = "UPDATE ChiTietHD SET SoLuong = @SL, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
        //                    cmd = new SqlCommand(sqlUpdate, kn.conn);
        //                    cmd.Parameters.Clear();
        //                    cmd.Parameters.AddWithValue("@MHD", intPanelTag);
        //                    cmd.Parameters.AddWithValue("@MSP", maSP);
        //                    cmd.Parameters.AddWithValue("@SL", soLuong);
        //                    cmd.Parameters.AddWithValue("@TT", soLuong * donGia);
        //                    cmd.ExecuteNonQuery();
        //                    GetData_From_CTHD(intPanelTag);
        //                    TongTienDV(intPanelTag);
        //                }
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("Hãy chọn một phòng");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: "+ex.Message);
        //    }
        //}
        //private void AllButtons_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    if (btn == null) return;
        //    if (btn.Name == "btnAll")
        //    {
        //        dgvMenuFood.DataSource = null;
        //        string sqlAllProd = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP " +
        //                            $"WHERE KhoHang.TonKho >= {dinhMucKho} " + " ORDER BY TenSP ASC";
        //        dgvMenuFood.DataSource = kn.CreateTable(sqlAllProd);
        //    }
        //    else if(btn.Name == "btnFood")
        //    {
        //        dgvMenuFood.DataSource = null;
        //        string sqlFood = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan \n" +
        //                         $"FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP WHERE KhoHang.TonKho >= {dinhMucKho} AND KhoHang.MaDM = 'MDM01' OR KhoHang.MaDM = 'MDM03' ORDER BY TenSP ASC";
        //        dgvMenuFood.DataSource = kn.CreateTable(sqlFood);
        //    }
        //    else if (btn.Name == "btnBeverage")
        //    {
        //        //Load đồ uống
        //        dgvMenuFood.DataSource = null;
        //        string sqlBeverage = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan \n" +
        //                            $"FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP WHERE KhoHang.TonKho >= {dinhMucKho} AND KhoHang.MaDM = 'MDM02' ORDER BY TenSP ASC";
        //        dgvMenuFood.DataSource = kn.CreateTable(sqlBeverage);
        //    }
        //    else if (btn.Name == "btnOther")
        //    {
        //        //Load khác
        //        dgvMenuFood.DataSource = null;
        //        string sqlOther = "SELECT SanPham.MaSP, KhoHang.TenSP, KhoHang.DonViTinh, SanPham.DinhLuong, SanPham.DVTDinhLuong, SanPham.GiaBan \n" +
        //                          $"FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP WHERE KhoHang.TonKho >= {dinhMucKho} AND KhoHang.MaDM = 'MDM04' ORDER BY TenSP ASC";
        //        dgvMenuFood.DataSource = kn.CreateTable(sqlOther);
        //    }
        //}

        //private void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    DialogResult reply = MessageBox.Show("Xác nhận thay đổi số lượng?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        //    if (reply == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            decimal soLuong = numSoLuong.Value;
        //            string maPhong = TakeNamePanel.Replace("pl", "");

        //            int intPanelTag = (int)selectedPanel.Tag;
        //            if (soLuong == 0)
        //            {
        //                string sqlUpdate = "DELETE ChiTietHD WHERE MaHD = @MHD AND MaSP = @MSP";
        //                cmd = new SqlCommand(sqlUpdate, kn.conn);
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.AddWithValue("@MHD", intPanelTag);
        //                cmd.Parameters.AddWithValue("@MSP", gloMaSP);
        //                cmd.ExecuteNonQuery();
        //                GetData_From_CTHD(intPanelTag);
        //                TongTienDV(intPanelTag);
        //            }
        //            else
        //            {
        //                string sqlUpdate = "UPDATE ChiTietHD SET SoLuong = @SL, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
        //                cmd = new SqlCommand(sqlUpdate, kn.conn);
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.AddWithValue("@MHD", intPanelTag);
        //                cmd.Parameters.AddWithValue("@MSP", gloMaSP);
        //                cmd.Parameters.AddWithValue("@SL", soLuong);
        //                cmd.Parameters.AddWithValue("@TT", soLuong * gloDonGia);
        //                cmd.ExecuteNonQuery();
        //                GetData_From_CTHD(intPanelTag);
        //                TongTienDV(intPanelTag);
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            switch (ex.Number)
        //            {
        //                case 8178:
        //                    MessageBox.Show("Hãy chọn một sản phẩm");
        //                    break;
        //                default:
        //                    MessageBox.Show(ex.Message + " " + ex.Number);
        //                    break;
        //            }
        //            //MessageBox.Show(ex.Number.ToString());
        //        }
        //    }
        //}

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            order.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int baseLocationX = 17;
            int newLocationY = 4;

            if (!plOrdered.Visible)
            {
                plPhong.Location = new Point(plOrdered.Width + 5, newLocationY);

            }
            else
            {
                plPhong.Location = new Point(baseLocationX, newLocationY);
            }
            plOrdered.Visible = !plOrdered.Visible;
        }
    }
}
