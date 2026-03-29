using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms; 
namespace SuperProjectQ.AllForm.Room
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        public class data
        {
            public int maHD { get; set; }
            public string phoneNumber { get; set; }
        }

        DataTable dt = null;
        SqlCommand cmd = null;
        ConnectData kn = new ConnectData();
        Session.FontStandard fontS = new Session.FontStandard();

        Form frmDetailTemporary, frmOptionsTemporary;
        string phong_MaNV = "QTV01"; //Session.MaNV;
        Panel selectedPanel = null; // Lưu trữ panel đang được chọn
        string maPhong = ""; //Mã phòng gán vào name của panel phòng
        int maHD = 0; //Mã hoá đơn gán vào tag của panel phòng
        bool isActive = false;

        string strStatusOpen = "Trạng thái: Đang vận hành";
        string strStatusClose = "Trạng thái: Trống";
        string strStatusBooking = "Trạng thái: Đã đặt trước";
        Color clrText = Color.Black;
        Color clrStatusOpen = Color.FromArgb(255, 180, 180);
        Color clrStatusClose = Color.FromArgb(180, 240, 180);
        Color clrStatusBooking = Color.FromArgb(180, 220, 255);

        double dinhMucKho = 0; //Định mức tồn kho
        private void LoadPhong()
        {
            Session.FreeUpMemoryPanel(flpRoom);

            string sqlMaxRoom = "SELECT MAX(Tang) FROM Phong";
            using (cmd = new SqlCommand())
            {
                cmd = new SqlCommand(sqlMaxRoom, kn.conn);
                int maxRoom = cmd.ExecuteScalar() != null && cmd.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(cmd.ExecuteScalar()) : 0;

                if (maxRoom < 1) return;

                for (int i = 1; i <= maxRoom; i++)
                {
                    GroupBox grFloor = new GroupBox()
                    {
                        Width = flpRoom.Width,
                        Height = 200,
                        Font = fontS.tahoma12_Bold,

                        Name = $"{i}",
                        Text = $"Tầng {i}:",
                    };
                    FlowLayoutPanel flpFloor = new FlowLayoutPanel()
                    {
                        Dock = DockStyle.Fill,
                        AutoScrollMinSize = new Size(0, 100),
                    };
                    grFloor.Controls.Add(flpFloor);
                    flpRoom.Controls.Add(grFloor);
                }
            }
            string sqlPhong = "SELECT * FROM Phong";
            dt = new DataTable();
            dt = kn.CreateTable(sqlPhong);
            //duyệt tất cả các phòng
            foreach (DataRow row in dt.Rows)
            {
                Panel plPhongTam = new Panel() { Width = 0, Height = 0 }; //Panel tạm để lấy vị trí
                Panel plPhong = new Panel()
                {
                    Padding = new Padding(0),
                    Margin = new Padding(5, 10, 5, 0),

                    BorderStyle = BorderStyle.FixedSingle,
                    Width = SetParameters.plPhong_WIDTH,
                    Height = SetParameters.plPhong_HEIGHT,
                    Cursor = Cursors.Hand,
                    //Lấy vị trí X phòng tạm cộng với chiều rộng phòng tạm để làm vị trí cho phòng tiếp theo
                    Location = new Point(plPhongTam.Location.X + plPhongTam.Width, plPhongTam.Location.Y),
                    AutoSize = false,
                    AutoSizeMode = AutoSizeMode.GrowOnly,

                    Name = row["MaPhong"].ToString(), //Gán Name theo mã phòng
                    Tag = row["Tang"].ToString()
                };
                Label lblTenPhong = new Label()
                {
                    Enabled = false,

                    Name = row["MaPhong"].ToString(), //Gán Name theo mã phòng

                    Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point),
                    Text = $"Phòng {row["TenPhong"].ToString()}",
                    Location = new Point(plPhong.Width / 2 - 55, 4),
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
                    plPhong.BackColor = clrStatusClose;
                    lblTrangThai.Text = strStatusClose;
                }
                else if (row["TrangThai"].ToString() == "1")
                {
                    plPhong.BackColor = clrStatusOpen;
                    lblTrangThai.Text = strStatusOpen;
                }
                else if (row["TrangThai"].ToString() == "2")
                {
                    plPhong.BackColor = clrStatusBooking;
                    lblTrangThai.Text = strStatusBooking;

                }

                if (row["MaLoaiPhong"].ToString().Contains("LPV"))
                {
                    lblTenPhong.Text += " (VIP)";
                    lblTenPhong.Location = new Point(plPhong.Width / 2 - 80, 4);
                }

                foreach(Control floor in flpRoom.Controls)
                {
                    if (plPhong.Tag.ToString().ToString() == floor.Name)
                    {
                        floor.Controls[0].Controls.Add(plPhong);
                    }
                }


                plPhong.Controls.Add(lblTenPhong); //Thêm tên phòng vào flow panel
                plPhong.Controls.Add(lblTrangThai);//Thêm trạng thái vào panel

                plPhong.Click += AllPanels_Click; //Gán sự kiện click cho panel
                plPhong.DoubleClick += AllPanelPhong_DoubleClick;

                plPhongTam = plPhong;//Cập nhật panel tạm bằng panel vừa tạo xong

                //Gán hoá dơn cho phòng tương ứng
                string sqlCTHD = "SELECT HoaDon.MaPhong, HoaDon.MaHD " +
                    "FROM HoaDon " +
                    "INNER JOIN Phong ON HoaDon.MaPhong = Phong.MaPhong WHERE Phong.TrangThai = 1 AND HoaDon.TrangThai = 0";
                dt = new DataTable();
                dt = kn.CreateTable(sqlCTHD);
                data data = new data();
                foreach (DataRow dr in dt.Rows)
                {
                    if (plPhong.Name == dr["MaPhong"].ToString()) 
                    {
                        data.maHD = Convert.ToInt32(dr["MaHD"]);
                        break; 
                    }
                }
                data.phoneNumber = row["SDT_KhachHang"].ToString();
                plPhong.Tag = data;
            }
        } //Hiển thị phòng
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
                    $"VALUES ({Session.AutoCreateID_Interger("MaCTHD", "ChiTietHD")}, '{maHD}', '{maSP}', {soLuong}, '{donViTinh}', {donGia}, {soLuong*donGia})";
                cmd = new SqlCommand(sqlThemDo, kn.conn);
                cmd.ExecuteNonQuery();
                TongTienDV(maHD);
            }
        } //Thêm đồ đã setup khi mở phòng
        private void Update_Status_Room(int statusInt, string RoomID)
        {
            string sqlUpdateStatus = null, timeIn = null, timeBooking = null, cusPhoneNumber = Session.CustomerData.SoDienThoai;
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
            else if (statusInt == 2 || statusInt == 0) sqlUpdateStatus = $"UPDATE Phong SET TrangThai = {statusInt}, " +
                    $"GioVao = {timeIn}, GioDatTruoc = {timeBooking}, SDT_KhachHang = '{cusPhoneNumber}' WHERE MaPhong = '{RoomID}'";
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
            if (Session.BillData.isPay)
            {
                //Update hoá đơn
                string sqlHD = $"UPDATE HoaDon SET MaKH = @MKH," +
                    $"GioRa = @GR, TongSoPhut = @TSP, TienPhong = @TP, TienDichVu = @TDV, TongTien = @TT, TrietKhauVIP = @TKVIP, TrietKhauVoucher = @TKV, VAT = @VAT, TongThanhToan = @TTT, PTTT = @PTTT, TrangThai = @TTHD, GhiChu = @GC WHERE MaHD = {billID}";
                using (cmd = new SqlCommand(sqlHD, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MKH", Session.CustomerData.MaKH);
                    cmd.Parameters.AddWithValue("@GR", Session.RoomData.TimeOut);
                    cmd.Parameters.AddWithValue("@TSP", Session.BillData.TongSoPhut);
                    cmd.Parameters.AddWithValue("@TP", Session.BillData.TongTienPhong);
                    cmd.Parameters.AddWithValue("@TDV", Session.BillData.TongTienDV);
                    cmd.Parameters.AddWithValue("@TT", Session.BillData.TongTien);
                    cmd.Parameters.AddWithValue("@TKVIP", Session.BillData.DiscountVIP);
                    cmd.Parameters.AddWithValue("@TKV", Session.BillData.DiscountVoucher);
                    cmd.Parameters.AddWithValue("@VAT", Session.BillData.TienVAT);
                    cmd.Parameters.AddWithValue("@TTT", Session.BillData.TongThanhToan);
                    cmd.Parameters.AddWithValue("@PTTT", Session.BillData.PTTT);
                    cmd.Parameters.AddWithValue("@TTHD", Session.BillData.TrangThaiHD);
                    cmd.Parameters.AddWithValue("@GC", "test");
                    cmd.ExecuteNonQuery();
                }
            }
        } //Cập nhật bill khi đã TT xong

        private void TongTienDV(int MaHD)
        {
            try
            {
                //Tính tổng tiền
                string sqlCTHDTam = $"SELECT SUM(ThanhTien) AS TongTienSP FROM ChiTietHD WHERE MaHD = {MaHD}";
                cmd = new SqlCommand(sqlCTHDTam, kn.conn);
                decimal tongTienDV = cmd.ExecuteScalar() != null && cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDecimal(cmd.ExecuteScalar()) : 0;

                Session.BillData.TongTienDV = tongTienDV; // Gán biết dùng chung
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"frmPhong - TongTienDV -> Function Lỗi: \n" + ex.Message);
                return;
            }
        } //Tính tiền DV
        private void AllPanels_Click(object sender, EventArgs e)
        {
            maPhong = ""; //Mã phòng gán vào name của panel phòng
            maHD = 0; //Mã hoá đơn gán vào tag của panel phòng
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
                        isActive = false;
                        Session.RoomData.status = 0;
                        break;
                    }
                    else if(dr["TrangThai"].ToString() == "1")
                    {
                        isActive = true;
                        Session.RoomData.status = 1;
                        break;
                    }
                    else if (dr["TrangThai"].ToString() == "2")
                    {
                        isActive = false;
                        Session.RoomData.status = 2;
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            data data = (data)selectedPanel.Tag;

            Session.CustomerData.SoDienThoai = data.phoneNumber;
            maPhong = selectedPanel.Name;
            Session.RoomData.maPhong = maPhong;
            Console.WriteLine($"frmPhong - MaPhong: \n{maPhong} MaHD Phong: {maHD}");
            Session.RoomData.tenPhong = clickedPanel.Controls[0].Text.ToString();

            if (isActive)
            {
                maHD = Convert.ToInt32(data.maHD);
                Session.RoomData.maHD = maHD;

                TongTienDV(maHD);

                Console.WriteLine($"MaPhong: \"{maPhong} MaHD Phong: {maHD}");
            }
        }
        private void AllPanelPhong_DoubleClick(object sender, EventArgs e)
        {
            if (isActive)
            {
                if (frmDetailTemporary != null) Session.FreeUpMemoryForm(frmDetailTemporary);
                frmRoomDetails details = new frmRoomDetails();
                details.FormBorderStyle = FormBorderStyle.None;

                details.FormClosed += (s, e) =>
                {
                    if (Session.BillData.isPay)
                    {
                        //Đổi màu, thời gian, chữ 

                        selectedPanel.BackColor = clrStatusClose;
                        selectedPanel.Controls[1].Text = strStatusClose;

                        //Cập nhật hoá đơn bill
                        Update_Bill(maHD, maPhong);
                        Update_Status_Room(0, maPhong);
                    }
                };
                details.ShowDialog();

                LoadPhong();
            }

            if (!isActive)
            {
                try
                {
                    if(frmOptionsTemporary != null) { Session.FreeUpMemoryForm(frmOptionsTemporary); }

                    frmRoomOptions options = new frmRoomOptions();

                    options.FormBorderStyle = FormBorderStyle.None;
                    frmOptionsTemporary = options;
                    options.ShowDialog();

                    switch (Session.RoomData.status)
                    {
                        case 1:
                            //Đổi màu, thời gian, chữ
                            selectedPanel.BackColor = clrStatusOpen;
                            selectedPanel.Controls[1].Text = strStatusOpen;

                            int initMaHD = Session.AutoCreateID_Interger("MaHD", "HoaDon");

                            Console.WriteLine("Mã hoá đơn khởi tạo: " + initMaHD);

                            selectedPanel.Tag = initMaHD;
                            maHD = initMaHD;

                            StatusCheck(maPhong);
                            Update_Status_Room(1, maPhong);
                            Add_Bill(initMaHD, maPhong);
                            //DoCoSan(billID);

                            isActive = true;
                            break;
                        case 2:
                            //Đổi màu, thời gian,
                            selectedPanel.BackColor = clrStatusBooking;
                            selectedPanel.Controls[1].Text = strStatusBooking;

                            Update_Status_Room(2, maPhong);
                            UpdatePrice(true, maPhong);
                            break;
                        case 3:
                            //Đổi màu, thời gian,
                            selectedPanel.BackColor = clrStatusClose;
                            selectedPanel.Controls[1].Text = strStatusClose;

                            Update_Status_Room(0, maPhong);
                            UpdatePrice(false, maPhong);
                            break;
                        default:
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("frmPhong - Lỗi: \n" + ex.Message);
                    return;
                }
            }
            Info_Load();
        }
        private void Info_Load()
        {
            try
            {
                int status = 0, free = 0, active = 0, booking = 0;
                foreach (GroupBox gr in flpRoom.Controls)
                {
                    foreach (Panel pl in gr.Controls[0].Controls)
                    {
                        string sqlPhong = $"SELECT TrangThai FROM Phong WHERE MaPhong = '{pl.Name}' ";
                        using (cmd = new SqlCommand(sqlPhong, kn.conn))
                        {
                            status = Convert.ToInt32(cmd.ExecuteScalar());
                            switch (status)
                            {
                                case 0:
                                    free++;
                                    break;
                                case 1:
                                    active++;
                                    break;
                                case 2:
                                    booking++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                lblEmptyRoom.Text = $"Phòng trống: {free}";
                lblActiveRoom.Text = $"phòng đang vận hành: {active}";
                lblBookingRoom.Text = $"phòng đã đặt trước: {booking}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmPhong - Infor_Load - Function Lỗi: \n" + ex.Message);
                return;
            }
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();

                LoadPhong();
                Info_Load();

                maPhong = null; //null để khi chưa chọn phòng nào sẽ không thao tác được
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL \nLỗi: " + ex.Message);
            }
        } //Load dữ liệu 
        private void tabCtrlRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        } //Thay đổi tab phòng thường và VIP

        private void flpRoom_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpRoom.Controls)
            {
                ctrl.Width = flpRoom.Width - 30;
            }
        }

        private void btnListRoom_Click(object sender, EventArgs e)
        {
            using (frmListRoom listRoom = new frmListRoom())
            {
                listRoom.FormBorderStyle = FormBorderStyle.None;
                listRoom.ShowDialog();
                LoadPhong();
            }
        }

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            using (frmMenu order = new frmMenu())
            {
                order.ShowDialog();
            }
        }
    }
}
