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

        class Button_Plus_And_Minus
        {
            public Button btn = null;

            public void BtnPlus_ClickChange()
            {
                var parent = btn.Parent; // Panel chứa button và textbox
                var maSP = parent.Controls[1];
                int soLuong = 0;
                if (maSP.Name == btn.Name)
                {
                    soLuong = Math.Abs(Convert.ToInt32(parent.Controls[1].Text)) + 1;
                    parent.Controls[1].Text = soLuong.ToString();
                }
            }

            public void BtnMinus_ClickChange()
            {
                var parent = btn.Parent; // Panel chứa button và textbox
                var maSP = parent.Controls[1];
                int soLuong = 0;
                if (maSP.Name == btn.Name)
                {
                    soLuong = Math.Abs(Convert.ToInt32(parent.Controls[1].Text)) - 1;
                    parent.Controls[1].Text = soLuong.ToString();
                }
            }
        }
        DataTable dt = null;
        SqlCommand cmd = null;
        ConnectData kn = new ConnectData();
        string phong_MaNV = "QTV01"; //Session.MaNV;
        Panel selectedPanel = null; // Lưu trữ panel đang được chọn
        string maPhong = ""; //Mã phòng gán vào name của panel phòng
        int maHD = 0; //Mã hoá đơn gán vào tag của panel phòng

        string strStatusOpen = "Trạng thái: Đang chạy";
        string strStatusClose = "Trạng thái: Trống";
        string strStatusBooking = "Trạng thái: Đã đặt trước";
        Color clrText = Color.Black;
        Color clrStatusOpen = Color.FromArgb(255, 128, 128);
        Color clrStatusClose = Color.FromArgb(192, 255, 192);
        Color clrStatusBooking = Color.FromArgb(192, 255, 255);

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
            dt = kn.CreateTable($"SELECT ChiTietHD.MaCTHD, ChiTietHD.MaHD, ChiTietHD.MaSP, SanPham.TenHienThi, ChiTietHD.SoLuong, ChiTietHD.DonViTinh, SanPham.DinhLuong " +
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
                        Tag = row["MaSP"].ToString(),
                    };
                    Label lblTenSP = new Label()
                    {
                        Text = row["TenHienThi"].ToString(),

                        MaximumSize = new Size(150, 50),

                        Location = new Point(5, plItem.Height / 2 - 12),
                        AutoSize = true,
                    };

                    //Tính số lượng nếu loại sản phẩm là Kg
                    int soLuong = 0;
                    if(row["DonViTinh"].ToString() == "Kg")
                    {
                        double dinhLuong = Convert.ToDouble(row["DinhLuong"]);
                        soLuong = Convert.ToInt32(Convert.ToDouble(row["SoLuong"]) * 1000 / dinhLuong);
                    }
                    else
                    {
                        soLuong = Convert.ToInt32(row["SoLuong"]);
                    }
                    #region  Nút tăng giảm số lượng
                    TextBox txtSoLuong = new TextBox()
                    {
                        Text = soLuong.ToString(),
                        TextAlign = HorizontalAlignment.Center,
                        Size = new Size(40, 24),
                        ReadOnly = true,

                        Location = new Point(lblTenSP.Width + lblTenSP.Location.X + 80, plItem.Height / 2 - 12),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Button btnMinus = new Button()
                    {
                        Text = "-",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(20, 24),
                        BackColor = Color.White,

                        Location = new Point(txtSoLuong.Location.X-20, plItem.Height / 2 - 12),

                        FlatAppearance =
                        {
                            BorderSize = 0
                        }
                    };

                    Button btnPlus = new Button()
                    {
                        Text = "+",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(20, 24),
                        BackColor = Color.White,

                        Location = new Point(txtSoLuong.Location.X + txtSoLuong.Width, plItem.Height / 2 - 12),

                        FlatAppearance =
                        {
                            BorderSize = 0
                        }
                    };
                    #endregion

                    Button btnXacNhan = new Button()
                    {
                        Text = "OK",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(40, 24),
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        Location = new Point(btnPlus.Location.X + btnPlus.Width, plItem.Height / 2 - 12),
                        FlatAppearance =
                        {
                            BorderSize = 0
                        }
                    };  

                    flowLayoutOrdered.Controls.Add(plItem);
                    plItem.Controls.Add(lblTenSP);

                    plItem.Controls.Add(txtSoLuong);
                    txtSoLuong.TextChanged += (s, e) =>
                    {
                        var txt = (TextBox)s;
                        if (Convert.ToInt32(txt.Text) < 0)
                        {
                            txt.Text = "1";
                        }
                    };

                    plItem.Controls.Add(btnMinus);
                    btnMinus.Click += (s, e) =>
                    {
                        var btn = (Button)s;
                        Button_Plus_And_Minus minus = new Button_Plus_And_Minus();
                        minus.btn = btn;
                        minus.BtnMinus_ClickChange();

                        Session.isPlus = false;
                    };

                    plItem.Controls.Add(btnPlus);
                    btnPlus.Click += (s, e) =>
                    {
                        var btn = (Button)s;
                        Button_Plus_And_Minus plus = new Button_Plus_And_Minus();
                        plus.btn = btn;
                        plus.BtnPlus_ClickChange();

                        Session.isPlus = true;
                    };

                    plItem.Controls.Add(btnXacNhan);
                    btnXacNhan.Click += btnXacNhan_click;

                    Session.isPlus = null;
                }
            }
        } //Load sản phẩm đã order của phòng
        private void btnXacNhan_click(object sender, EventArgs e)
        {
            DialogResult? reply = null;
            Button thisBtn = sender as Button;

            if (Session.isPlus == true) reply = MessageBox.Show("Xác nhận thêm đồ vào phòng ?", "Xác nhận", MessageBoxButtons.YesNo);
            else if (Session.isPlus == false) reply = MessageBox.Show("Xác nhận giảm đồ của phòng ?", "Xác nhận", MessageBoxButtons.YesNo);

            if(reply == DialogResult.Yes && Session.isPlus.HasValue)
            {
                dt = new DataTable();
                dt = kn.CreateTable($"SELECT SoLuong FROM ChiTietHD WHERE MaHD = {maHD} AND MaSP = '{thisBtn.Parent.Tag}'");

                double soLuongHienTai = Convert.ToDouble(dt.Rows[0]["SoLuong"]);
                double soLuongMoi = Convert.ToDouble(thisBtn.Parent.Controls[1].Text);

                if (Session.isPlus == true) soLuongMoi = soLuongMoi - soLuongHienTai;
                else if (Session.isPlus == false) soLuongMoi = soLuongHienTai - soLuongMoi;

                string sqlUpdateSoLuong = $"UPDATE ChiTietHD SET SoLuong = @SLM WHERE MaHD = @MHD AND MaSP = @MSP";
                cmd = new SqlCommand(sqlUpdateSoLuong, kn.conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@SLM", Convert.ToDouble(thisBtn.Parent.Controls[1].Text));
                cmd.Parameters.AddWithValue("@MHD", maHD);
                cmd.Parameters.AddWithValue("@MSP", thisBtn.Parent.Tag.ToString());
                cmd.ExecuteNonQuery();

                //Xoá sản phẩm khỏi CTHD khi số lượng về 0
                cmd = new SqlCommand("DELETE ChiTietHD WHERE SoLuong = 0", kn.conn);
                cmd.ExecuteNonQuery();

                Session.CapNhatKho(!Session.isPlus.Value, thisBtn.Parent.Tag.ToString(), soLuongMoi);

                Load_Ordered(maHD);
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
                Load_Ordered((int)selectedPanel.Tag);

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
            Session.TongTienDV = tongTienDV; // Gán biết dùng chung
            return tongTienDV;
        } //Tính tiền DV
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
            maPhong = selectedPanel.Name;
            maHD = Convert.ToInt32(selectedPanel.Tag);

            Load_Ordered(maHD);
            TongTienDV(maHD);
        }
        private bool XacNhanTT(string RoomID) //Xác nhận qua bước tt
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
                btnDatTruoc.Visible = false;
                btnHuyDatTruoc.Visible = false;

                //Ẩn nút Order
                btnOrder.Visible = false;
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
                if (maPhong == ""){ MessageBox.Show("Hãy chọn một phòng"); return;}
                if (MessageBox.Show("Xác nhận đặt trước?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Đổi màu, thời gian, chữ
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
                if (maPhong == null) {MessageBox.Show("Hãy chọn một phòng"); return;}

                    //Đổi màu, thời gian, chữ
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
                if (maPhong == null)
                {
                    MessageBox.Show("Hãy chọn một phòng"); return;
                }
                //Đổi màu, thời gian, chữ
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
                TongTienDV(Session.maHD); //Tính tiền dịch vụ

                DateTime dateTimeOut = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")); // Tính giờ ra

                if (XacNhanTT(maPhong))
                {
                    //Đổi màu, thời gian, chữ
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnDatTruoc.Visible = true;
                    btnHuyDatTruoc.Visible = false;
                    flowLayoutOrdered.Enabled = false;

                    selectedPanel.BackColor = clrStatusClose;
                    selectedPanel.Controls[1].Text = strStatusClose;

                    //Cập nhật hoá đơn bill
                    Update_Bill(maHD, maPhong);
                    Update_Status_Room(0, maPhong);
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

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            order.ShowDialog();
        }

        private void btnOrdered_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null) return;
            Load_Ordered(maHD);

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
