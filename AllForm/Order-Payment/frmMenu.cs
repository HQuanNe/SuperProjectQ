using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            kn.ConnOpen();
        }
        SetParameters parameters = new SetParameters();
        class Button_Plus_And_Minus
        {
            public Button btn = null;
            
            public void BtnPlus_ClickChange()
            {
                var parent = btn.Parent; // Panel chứa button và textbox
                var maSP = parent.Controls[3];
                int soLuong = 0;
                if (maSP.Name == btn.Name)
                {
                    soLuong = Math.Abs(Convert.ToInt32(parent.Controls[3].Text)) + 1;
                    parent.Controls[3].Text = soLuong.ToString();
                }
            }

            public void BtnMinus_ClickChange()
            {
                var parent = btn.Parent; // Panel chứa button và textbox
                var maSP = parent.Controls[3];
                int soLuong = 0;
                if (maSP.Name == btn.Name)
                {
                    soLuong = Math.Abs(Convert.ToInt32(parent.Controls[3].Text)) - 1;
                    parent.Controls[3].Text = soLuong.ToString();
                }
            }
        }

        ConnectData kn = new ConnectData();
        Session.FontStandard fontS = new Session.FontStandard();
        DataTable dt = null;
        SqlCommand cmd = null;

        bool ComboInit = true; //Kiểm tra xem đã khởi tạo combo chưa

        public Button btnDSPhong = null; // Panel chứa danh sách phòng
        Button btnClicked = null; // Lưu button phòng đang được click

        Panel plItem = null; // Panel chứa từng sản phẩm
        string RoomID = Session.RoomData.maPhong; // Lưu mã phòng đang được click

        PictureBox pbItem = null; // Khai báo object PictureBox ảnh sản phẩm
        Label lblTenSanPham = null;  // Khai báo object Label tên sản phẩm
        Label lblGiaBan = null; // Khai báo object Label giá bán

        TextBox txtSoLuong = null;
        Button btnPlus = null;
        Button btnMinus = null;
        Button btnOrder = null; // Khai báo object Button mua hàng

        private void ItemPanel_SanPham_Load(string tag_1 = "", bool isCombo = false)
        {

            string maSP = "MaSP_Menu", maDM = "MaDM", tenHienThi = "TenMatHang", giaBan = "GiaBan", hinhAnh = "HinhAnh";

            string sqlSP = "SELECT SanPham.MaSP_Menu, SanPham.TenMatHang, SanPham.GiaBan, KhoHang.HinhAnh, KhoHang.MaDM " +
                           $"FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP_Kho = KhoHang.MaSP_Kho " +
                           $"WHERE KhoHang.MaDM LIKE '%{tag_1}%' AND KhoHang.TonKho >= {Session.MinTonKho} ORDER BY SanPham.TenMatHang";

            if (isCombo)
            {
                sqlSP = "SELECT DISTINCT Combo.MaCombo, Combo.TenCombo, Combo.MaDM, Combo.DonGia, combo.HinhAnh " +
                    "FROM Combo " +
                    "INNER JOIN ChiTietCombo ON Combo.MaCombo = ChiTietCombo.MaComBo " +
                    "INNER JOIN SanPham ON SanPham.MaSP_Menu = SanPham.MaSP_Menu";

                maSP = "MaCombo"; tenHienThi = "TenCombo"; maDM = "MaDM"; giaBan = "DonGia"; hinhAnh = "HinhAnh";

            }

            dt = kn.CreateTable(sqlSP);

            if (dt == null || dt.Rows.Count < 1) return;
            foreach (DataRow row in dt.Rows)
            {
                string pathImage = "";

                plItem = new Panel() // Tạo panel cho mỗi sản phẩm
                {
                    Width = parameters.plSanPham_WIDTH,
                    Height = parameters.plSanPham_HEIGHT,
                    Margin = new Padding(8),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,

                    Name = row[maSP].ToString(), // Lưu mã SP vào Name của Panel
                    Tag = row[maDM].ToString(), // Lưu mã DM vào Tag


                };

                switch (row[maDM].ToString())
                {
                    case "MDM01":
                    case "MDM03":
                    case "MDM05":
                    case "MDM06":
                        pathImage = "FoodImage\\";
                        break;
                    case "MDM02":
                    case "MDM07":
                    case "MDM08":
                        pathImage = "DrinkImage\\";
                        break;
                    case "MDM04":
                        pathImage = "OtherImage\\";
                        break;
                    default:
                        pathImage = "ComboImage\\";
                        break;
                } //Kiểm tra danh mục sản phẩm để gán file ảnh đúng

                if (row[hinhAnh] != DBNull.Value && row[hinhAnh].ToString() != "")// Kiểm tra nếu có hình ảnh
                {
                    pbItem = new PictureBox() // Tạo PictureBox cho hình ảnh sản phẩm
                    {
                        Width = parameters.pbSanPham_WIDTH,
                        Height = parameters.pbSanPham_HEIGHT,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = Image.FromFile(Application.StartupPath + $"\\Images\\{pathImage = pathImage + row[hinhAnh]}"),
                        Location = new Point(20, 10),
                        //BackColor = Color.Red,
                    };

                    lblTenSanPham = new Label() // Tạo Label cho tên sản phẩm
                    {
                        Font = fontS.timeNew12_Bold,
                        Text = $"{row[tenHienThi].ToString()}",
                        ForeColor = Color.Black,
                        AutoSize = true,

                        MinimumSize = new Size(parameters.pbSanPham_WIDTH, 0),
                        MaximumSize = new Size(parameters.pbSanPham_WIDTH + 10, 0),

                        Location = new Point(20, pbItem.Location.Y + pbItem.Height + 5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        //BackColor = Color.Red,
                    };
                    decimal decGiaBan = Convert.ToDecimal(row[giaBan]); // Lấy giá bán từ cơ sở dữ liệu
                    lblGiaBan = new Label()// Tạo Label cho giá bán
                    {
                        Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point),
                        ForeColor = Color.Red,
                        Text = decGiaBan.ToString("#,##0") + "đ",
                        AutoSize = true,

                        MinimumSize = new Size(parameters.pbSanPham_WIDTH, 0),
                        MaximumSize = new Size(parameters.pbSanPham_WIDTH + 10, 0),
                        TextAlign = ContentAlignment.MiddleCenter,

                        Location = new Point(20, (lblTenSanPham.Location.Y + lblTenSanPham.Height) + 45),
                        //BackColor = Color.Red,
                    };

                    #region Nút tăng, giảm số lượng
                    txtSoLuong = new TextBox()
                    {
                        Width = 80,
                        Height = 30,

                        Name = row[maSP].ToString(),

                        Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point),
                        Text = $"1",
                        ForeColor = Color.Black,
                        TextAlign = HorizontalAlignment.Center,

                        Location = new Point(105, lblGiaBan.Location.Y + lblGiaBan.Height + 30),
                        AutoSize = true,
                    };
                    btnPlus = new Button()
                    {
                        Width = 30,
                        Height = 20,

                        Name = row[maSP].ToString(),

                        Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point),
                        Text = $"+",
                        ForeColor = Color.Black,
                        TextAlign = ContentAlignment.MiddleCenter,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            MouseOverBackColor = Color.Cyan,
                            MouseDownBackColor = Color.Blue,
                            BorderSize = 0,
                        },

                        Location = new Point(txtSoLuong.Location.X + txtSoLuong.Width, lblGiaBan.Location.Y + lblGiaBan.Height + 30),
                        AutoSize = true,
                    };
                    btnMinus = new Button()
                    {
                        Width = 30,
                        Height = 20,

                        Name = row[maSP].ToString(),

                        Font = new Font("Times New Roman", 10F, FontStyle.Bold, GraphicsUnit.Point),
                        Text = $"-",
                        ForeColor = Color.Black,
                        TextAlign = ContentAlignment.MiddleCenter,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            MouseOverBackColor = Color.Cyan,
                            MouseDownBackColor = Color.Blue,
                            BorderSize = 0,
                        },

                        Location = new Point(txtSoLuong.Location.X - 30, lblGiaBan.Location.Y + lblGiaBan.Height + 30),
                        AutoSize = true,
                    };
                    #endregion

                    btnOrder = new Button()// Tạo Button để gọi món
                    {
                        Width = 200,
                        Height = 40,

                        Text = "Gọi đồ",

                        Name = row[maSP].ToString(), // Lưu mã SP vào Name của Button

                        Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point),
                        ForeColor = Color.Black,
                        BackColor = Color.FromArgb(192, 255, 255),
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point((plItem.Width - 200) /2, (lblGiaBan.Location.Y + lblGiaBan.Height) + 75),


                        FlatAppearance =
                        {
                            MouseOverBackColor = Color.Cyan,
                            MouseDownBackColor = Color.Blue,
                            BorderSize = 0,
                        },

                        
                    };

                }
                btnOrder.Click += BtnOrder_Click;

                btnPlus.Click += BtnPlus_Click;
                btnMinus.Click += BtnMinus_Click;

                txtSoLuong.TextChanged += txtSoLuong_Textchanged;

                flowLayoutDSSanPham.Controls.Add(plItem);

                plItem.Controls.Add(pbItem);
                plItem.Controls.Add(lblTenSanPham);
                plItem.Controls.Add(lblGiaBan);

                plItem.Controls.Add(txtSoLuong);
                plItem.Controls.Add(btnPlus);
                plItem.Controls.Add(btnMinus);

                plItem.Controls.Add(btnOrder);

            }
        }
        private void Phong_Load()
        {
            string sqlPhong = "SELECT * FROM Phong WHERE TrangThai = 1";
            dt = new DataTable();
            dt = kn.CreateTable(sqlPhong);

            foreach (DataRow row in dt.Rows)
            {
                btnDSPhong = new Button() // Tạo FlowLayoutPanel chứa phòng
                {
                    Width = parameters.btnPhong_WIDTH,
                    Height = parameters.btnPhong_HEIGHT,

                    Name = row["MaPhong"].ToString(), // Lưu mã phòng vào Name của Button

                    BackColor = Color.FromArgb(95, 76, 76),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.White,
                    Text = row["TenPhong"].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,

                    FlatAppearance =
                    {
                        MouseOverBackColor = Color.FromArgb(197,170,106),
                        MouseDownBackColor = Color.FromArgb(76, 60, 60),
                        BorderSize = 1,
                    }
                };
                flowLayoutDSPhong.Controls.Add(btnDSPhong);
                btnDSPhong.Click += BtnDSPhong_Click;
            }
        }
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Console.WriteLine( "Mã SP đang trỏ: " + clickedButton.Name);
            bool isAdded = false;

            double soLuongOrder = Convert.ToDouble(clickedButton.Parent.Controls[3].Text.Trim()); //Số lượng thêm vào hiện tại ở textbox

            if (string.IsNullOrEmpty(RoomID))
            {
                MessageBox.Show("Hãy chọn phòng");
                return;
            }
            else
            {
                if (MessageBox.Show($"Thêm sản phẩm này vào phòng {RoomID}", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlSanPham = $"SELECT SanPham.MaSP_Menu, SanPham.TenMatHang, KhoHang.DonViTinh, SanPham.GiaBan, SanPham.DinhLuong " +
                        $"FROM SanPham " +
                        $"INNER JOIN KhoHang ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                        $"WHERE SanPham.MaSP_Menu = '{clickedButton.Name}'";

                    if (!(clickedButton.Name.Contains("SPM"))) //Nếu là phải combo set = true
                    {
                        sqlSanPham = $"SELECT Combo.MaCombo, Combo.TenCombo, Combo.DonViTinh, Combo.DonGia " +
                        $"FROM Combo " +
                        $"WHERE Combo.MaCombo = '{clickedButton.Name}'";

                        Session.isCombo = true;
                    }

                    dt = new DataTable();
                    dt = kn.CreateTable(sqlSanPham);
                    #region Lấy mã HĐ
                    cmd = new SqlCommand($"SELECT HoaDon.MaHD FROM HoaDon " +
                                        $"INNER JOIN Phong ON Phong.MaPhong = HoaDon.MaPhong " +
                                        $"WHERE HoaDon.MaPhong = '{RoomID}' AND Phong.TrangThai = 1 AND HoaDon.TrangThai = 0", kn.conn);
                    int intMaHD = Convert.ToInt32(cmd.ExecuteScalar());
                    #endregion

                    string maSP = dt.Rows[0][0].ToString();
                    string tenSP = dt.Rows[0][1].ToString();

                    string donViTinh = dt.Rows[0][2].ToString();
                    int donGia = Convert.ToInt32(dt.Rows[0][3].ToString());

                    double dinhLuong = !Session.isCombo ? Convert.ToDouble(dt.Rows[0][4].ToString()) : 0;

                    if (donViTinh == "Kg") donViTinh = "Đĩa";

                    bool flag = true;

                    //Lấy danh sách sản phẩm đã order trong phòng
                    DataTable dt2 = new DataTable();
                    dt2 = kn.CreateTable($"SELECT MaSP FROM ChiTietHD WHERE MaHD = '{intMaHD}'");

                    //kiểm tra xem sản phẩm có trong bảng đã order chưa
                    foreach(DataRow row in dt2.Rows)
                    {
                        if (dt2.Rows.Count > 0 && row["MaSP"].ToString() != null && row["MaSP"].ToString() == maSP)
                        {
                            flag = false;
                            break;
                        }
                    }
                    //Nếu chaưa có thì thêm mới
                    if (flag)
                    {
                        string sqlAdd = "INSERT INTO ChiTietHD (MaCTHD, MaHD, MaSP, LoaiHang, SoLuong, DonViTinh, DonGia, ThanhTien) " +
                            "VALUES (@MCTHD, @MHD, @MSP, @LH, @SL, @DV, @DG, @TT)";
                        cmd = new SqlCommand(sqlAdd, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MCTHD", Session.AutoCreateID_Interger("MaCTHD", "ChiTietHD"));
                        cmd.Parameters.AddWithValue("@MHD", intMaHD);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("LH", Session.isCombo);
                        cmd.Parameters.AddWithValue("@SL", soLuongOrder);
                        cmd.Parameters.AddWithValue("@DV", donViTinh);
                        cmd.Parameters.AddWithValue("@DG", donGia);
                        cmd.Parameters.AddWithValue("@TT", soLuongOrder * donGia);
                        cmd.ExecuteNonQuery();

                        isAdded = true;
                    }
                    //Nếu có rồi thì cập nhật số lượng lên 1
                    if (!flag)
                    {
                        cmd = new SqlCommand($"SELECT SoLuong FROM ChiTietHD WHERE MaSP = '{maSP}' AND MaHD = {intMaHD} ", kn.conn);

                        double soLuongDaCo = soLuongOrder + Convert.ToDouble(cmd.ExecuteScalar());
                        decimal thanhTien = Convert.ToDecimal(soLuongDaCo * donGia);

                        string sqlUpdate = "UPDATE ChiTietHD SET SoLuong = @SL, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
                        cmd = new SqlCommand(sqlUpdate, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MHD", intMaHD);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("@SL", soLuongDaCo);
                        cmd.Parameters.AddWithValue("@TT", thanhTien);
                        cmd.ExecuteNonQuery();

                        isAdded = true; 
                    }
                }
                if (isAdded)
                {
                    Console.WriteLine(soLuongOrder.ToString());
                    Session.CapNhatKho(false, clickedButton.Name, soLuongOrder);

                    cmd = new SqlCommand($"SELECT TenMatHang FROM SanPham WHERE MaSP_Menu = '{clickedButton.Name}'", kn.conn);
                    string tenSP = (string)cmd.ExecuteScalar();
                    cmd = new SqlCommand($"SELECT TenPhong FROM Phong WHERE MaPhong = '{RoomID}'", kn.conn);
                    string tenPhong = (string)cmd.ExecuteScalar();

                    Session.isCombo = false;
                    MessageBox.Show($"Đã thêm sản phẩm {tenSP} cho phòng {tenPhong}"); return;
                }
            }
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            ItemPanel_SanPham_Load();
            Phong_Load();

            //Ẩn các nút con của nút cha ở thanh điều hướng
            HideBtnFoodChildren();
            HideBtnDrinkChildren();
        }
        private void BtnDSPhong_Click(object sender, EventArgs e)
        {

            if (btnClicked != null) { btnClicked.BackColor = Color.FromArgb(95, 76, 76); };

            Button clickButton = (Button)sender;
            if (clickButton != null)
            {
                clickButton.BackColor = Color.FromArgb(197, 170, 106);
                clickButton.ForeColor = Color.White;
                btnClicked = clickButton;

                RoomID = clickButton.Name;
            }
        }
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            Button_Plus_And_Minus plus = new Button_Plus_And_Minus();
            plus.btn = btn;
            plus.BtnPlus_ClickChange();
        }
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            Button_Plus_And_Minus minus = new Button_Plus_And_Minus();
            minus.btn = btn;
            minus.BtnMinus_ClickChange();
        }
        private void txtSoLuong_Textchanged(object sender, EventArgs e)
        {
            var thisTxt = (TextBox)sender;
            int.TryParse(thisTxt.Text, out int soLuong);
            if (soLuong <= 0) 
            {
                thisTxt.Text = "1";
                thisTxt.SelectionStart = thisTxt.Text.Length;
                return;
            }
        }
        //////////////////////////////////////////////////////////////////
        #region Các nút điều hướng

        bool foodFlag = true;
        bool drinkFlag = true;

        #region Các hàm ẩn các nút con của các nút điều hướng cha
        private void HideBtnFoodChildren()
        {
            btnSnack.Visible = false;
            btnDoKho.Visible = false;
            btnHoaQua.Visible = false;
        }
        private void HideBtnDrinkChildren()
        {
            btnRuou.Visible = false;
            btnNuocNgot.Visible = false;
            btnNuocKhoang.Visible = false;
        }
        #endregion

        private void ShowPanelByTag(string tag)
        {
            string[] item = tag.Split(',');

            foreach (Control panelByTag in flowLayoutDSSanPham.Controls)
            {
                panelByTag.Visible = tag == "" || panelByTag.Tag != null && item.Contains(panelByTag.Tag.ToString());

            } 
        } //Hiển thị panel sản phẩm theo tag
        private void AllButton_Click(object sender, EventArgs e)
        {
            Button btnclicked = (Button)sender;

            //flowLayoutDSSanPham.Controls.Clear();
            //ItemPanel_SanPham_Load();
            switch (btnclicked.Name)
            {
                case "btnAll":
                    HideBtnFoodChildren();
                    HideBtnDrinkChildren();

                    foodFlag = true;
                    drinkFlag = true;
                    btnFood.Text = "Đồ ăn ▶️";
                    btnDrink.Text = "Đồ uống ▶️";

                    ShowPanelByTag("");
                    break;
                case "btnFood":
                    if (foodFlag)
                    {
                        btnSnack.Visible = true;
                        btnDoKho.Visible = true;
                        btnHoaQua.Visible = true;

                        btnFood.Text = "Đồ ăn ▼";

                        ShowPanelByTag("MDM01,MDM03,MDM05,MDM06");
                        HideBtnDrinkChildren();

                        foodFlag = false;
                    }
                    else
                    {
                        HideBtnFoodChildren();
                        btnFood.Text = "Đồ ăn ▶️";

                        foodFlag = true;
                    }
                    break;
                case "btnSnack":
                    ShowPanelByTag("MDM03");
                    break;
                case "btnDoKho":
                    ShowPanelByTag("MDM01");
                    break;
                case "btnHoaQua":
                    ShowPanelByTag("MDM06");
                    break;
                case "btnDrink":
                    if (drinkFlag)
                    {
                        btnRuou.Visible = true;
                        btnNuocNgot.Visible = true;
                        btnNuocKhoang.Visible = true;

                        btnDrink.Text = "Đồ uống ▼";

                        ShowPanelByTag("MDM02,MDM07,MDM08");

                        drinkFlag = false;
                    }
                    else
                    {
                        HideBtnDrinkChildren();

                        btnDrink.Text = "Đồ uống ▶";

                        drinkFlag = true;
                    }
                    break;
                case "btnRuou":
                    ShowPanelByTag("MDM02");
                    break;
                case "btnNuocNgot":
                    ShowPanelByTag("MDM07");
                    break;
                case "btnNuocKhoang":
                    ShowPanelByTag("MDM07");
                    break;
                case "btnOther":
                    HideBtnFoodChildren();
                    HideBtnDrinkChildren();

                    foodFlag = true;
                    drinkFlag = true;
                    btnFood.Text = "Đồ ăn ▶️";
                    btnDrink.Text = "Đồ uống ▶️";

                    ShowPanelByTag("MDM04");
                    break;
                default:
                    break;
            }
        }
        private void btnCombo_Click(object sender, EventArgs e)
        {
            if (ComboInit)
            {
                ItemPanel_SanPham_Load("MDM09", ComboInit);
                ComboInit = false;
            }
            ShowPanelByTag("MDM09");
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
