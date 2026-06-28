using System;
using System.Data;
using System.Data.SqlClient;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using E_Menu.Classes;
using System.Configuration;
namespace E_Menu
{
    public partial class frmEMenu : Form
    {
        public frmEMenu()
        {
            InitializeComponent();
            Session.SetParameters_Load();
            //AI
            var root = new Content(AIRepo.GetProdFromSQL() +
                "Ở đây là mày đang giao tiếp với khách hàng, " +
                "hãy tỏ thái độ lịch sự trả lời chi tiết những yêu cầu của khách hàng. Xưng em với họ" +
                "và tên mày là ParaD. " +
                "Khi mày tư vấn sản phầm thì không được nêu giá ra chỉ tư vấn hợp lý theo nhu cầu.");
            model = chatbotAI.GenerativeModel(Model.Gemini25Flash, systemInstruction: root);

            chatSession = model.StartChat(); //Bắt đầu phiên chát
        }

        private GoogleAI chatbotAI = new GoogleAI(ConfigurationManager.AppSettings["GeminiAPIKey"]);
        private GenerativeModel model;
        private ChatSession chatSession;

        AIChatbotRepository AIRepo = new AIChatbotRepository();

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
        bool isActive = true; //Kiểm tra phòng đang hoạt động ko
        string roomID, roomName, maSP, folderImage;

        Panel plItem = null; // Panel chứa từng sản phẩm
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
                           $"WHERE KhoHang.MaDM LIKE '%{tag_1}%' AND KhoHang.TonKho >= {Session.dictThongSo[4]} AND KhoHang.TrangThai = 1 ORDER BY SanPham.TenMatHang";

            if (isCombo)
            {
                sqlSP = "SELECT DISTINCT Combo.MaCombo, Combo.TenCombo, Combo.MaDM, Combo.DonGia, Combo.HinhAnh " +
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
                    Margin = new Padding(4),
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
                        Image = System.Drawing.Image.FromFile(Application.StartupPath + $"\\Images\\{pathImage = pathImage + row[hinhAnh]}"),
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
                        Font = fontS.timeNew14_Bold,
                        ForeColor = Color.FromArgb(235, 153, 42),
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

                        Text = "Order",

                        Name = row[maSP].ToString(), // Lưu mã SP vào Name của Button

                        Font = fontS.timeNew18_Bold,
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(122, 111, 99),
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point((plItem.Width - 200) /2, (lblGiaBan.Location.Y + lblGiaBan.Height) + 75),


                        FlatAppearance =
                        {
                            MouseOverBackColor = Color.FromArgb(62,58,52),
                            MouseDownBackColor = Color.FromArgb(62,58,52),
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
        private void GetRoomNameForRoomID()
        {
            try
            {
                string tenPhong;
                using (cmd = new SqlCommand($"SELECT TenPhong FROM Phong WHERE MaPhong = '{roomID}'", kn.conn))
                {
                    tenPhong = cmd.ExecuteScalar() != null && cmd.ExecuteScalar() != DBNull.Value ? cmd.ExecuteScalar().ToString() : null;
                }
                lblTitlePhong.Text += " " + tenPhong;
                roomName = tenPhong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLoginRoom - GetRoomID Lỗi:\n" + ex.Message);
                return;
            }
        }
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if(!isActive) 
                {
                    MessageBox.Show("Phòng chưa được kích hoạt, vui lòng liên hệ nhân viên để được hỗ trợ");
                    return;
                }
                if (MessageBox.Show("Thêm sản phẩm này?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                Button clickedButtonMaSP = (Button)sender;
                Console.WriteLine("Mã SP đang trỏ: " + clickedButtonMaSP.Name);
                bool isAdded = false;

                double soLuongOrder = Convert.ToDouble(clickedButtonMaSP.Parent.Controls[3].Text.Trim()); //Số lượng thêm vào hiện tại ở textbox

                if (!(clickedButtonMaSP.Name.Contains("SPM"))) //Nếu là phải combo set = true
                {
                    Session.ComboData.isCombo = true;
                }

                maSP = clickedButtonMaSP.Name;

                bool flag = true;

                if (!Session.InspectInStock(maSP, soLuongOrder))
                {
                    MessageBox.Show("Số lượng order vượt quá số lượng tồn kho");
                    return;
                }

                //Lấy danh sách order của phòng
                DataTable dt2 = new DataTable();
                dt2 = kn.CreateTable($"SELECT MaSP FROM Orders WHERE MaPhong = '{roomID}'");

                //kiểm tra xem sản phẩm có trong bảng đã order chưa
                foreach (DataRow row in dt2.Rows)
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
                    string sqlAdd = "INSERT INTO Orders (STT, MaPhong, MaSP, SoLuong, OrderAt) " +
                        "VALUES (@STT, @MP, @MSP, @SL, GETDATE())";
                    cmd = new SqlCommand(sqlAdd, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@STT", Session.AutoCreateID_Interger("STT", "Orders"));
                    cmd.Parameters.AddWithValue("@MP", roomID);
                    cmd.Parameters.AddWithValue("@MSP", maSP);
                    cmd.Parameters.AddWithValue("@SL", soLuongOrder);
                    cmd.ExecuteNonQuery();

                    isAdded = true;
                }
                //Nếu có rồi thì cập nhật số lượng lên 1
                if (!flag)
                {
                    cmd = new SqlCommand($"SELECT SoLuong FROM Orders WHERE MaSP = '{maSP}' AND MaPhong = '{roomID}' ", kn.conn);
                    double soLuongMoi = soLuongOrder + Convert.ToDouble(cmd.ExecuteScalar());

                    string sqlUpdate = "UPDATE Orders SET SoLuong = @SL WHERE MaPhong = @MP AND MaSP = @MSP";
                    cmd = new SqlCommand(sqlUpdate, kn.conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MP", roomID);
                    cmd.Parameters.AddWithValue("@MSP", maSP);
                    cmd.Parameters.AddWithValue("@SL", soLuongMoi);
                    cmd.ExecuteNonQuery();

                    isAdded = true;
                }
                if (isAdded)
                {
                    Console.WriteLine(soLuongOrder.ToString());
                    Session.ComboData.isCombo = false;

                    MessageBox.Show($"Đã thêm sản phẩm"); return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMenu - BtnOrder_Click Lỗi:\n" +ex.Message);
                return;
            }
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            ItemPanel_SanPham_Load();
            roomID = TransData.RoomID;

            //Ẩn các nút con của nút cha ở thanh điều hướng
            HideBtnFoodChildren();
            HideBtnDrinkChildren();

            Console.WriteLine(roomID);

            timerRefresh.Start();

            //Hiển thị phòng theo mã
            GetRoomNameForRoomID();

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

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if(GetBillID() <=0) isActive = false;
            else isActive = true;

            Load_Ordered(GetBillID());
        }

        private void btnAIChatbot_Click(object sender, EventArgs e)
        {
            plAIChatbot.Visible = !plAIChatbot.Visible;
        }

        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                string request = txtRequest.Text.Trim();
                if (string.IsNullOrEmpty(request)) return; //nếu Request rỗng

                AIRepo.SaveNewMessage("AIChatbotHistory_Customers", roomID, txtRequest.Text); //Lưu câu hỏi
                rtxtChatHistory.AppendText($"{roomID}: {request}\n\n");
                txtRequest.Clear();

                var respond = await chatSession.SendMessage(request); //Gửi câu hỏi và nhận phản hồi từ AI

                if (respond == null || respond.Text == null)
                {
                    MessageBox.Show("Lỗi");
                    return;
                }//nếu null sẽ báo lỗi

                AIRepo.SaveNewMessage("AIChatbotHistory_Customers", "AI", respond.Text); //Lưu cầu trả lời của AI

                rtxtChatHistory.AppendText($"Trợ lý ParaD: {respond.Text}\n\n"); //Thêm câu trả lời
            }
            catch (GeminiApiException ex)
            {
                MessageBox.Show("frmEMenu - btnSendRequest_Click Lỗi:\n" + ex.Message);
                return;
            }
        }

        private int GetBillID()
        {
            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = kn.conn;
                    cmd.CommandText = $"SELECT MaHD FROM HoaDon " +
                        "INNER JOIN Phong ON Phong.MaPhong = HoaDon.MaPhong " +
                        $"WHERE HoaDon.MaPhong = '{roomID}' AND Phong.TrangThai = 1 AND HoaDon.TrangThai = 0";

                }
                return cmd.ExecuteScalar() != null && cmd.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(cmd.ExecuteScalar().ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmEMenu - GetBillID() Lỗi:\n" +ex.Message);
                return 0;
            }
        }
        private void Load_Ordered(int MaHD)
        {
            try
            {
                Session.FreeUpMemoryFlowPanel(flplOrdered);//Clear trước khi load lại

                DataTable dt = new DataTable();
                dt = kn.CreateTable($"SELECT ChiTietHD.MaHD, ChiTietHD.MaSP, " +
                    $"COALESCE(SanPham.TenMatHang, Combo.TenCombo) AS TenMatHang, " +
                    $"ChiTietHD.SoLuong, ChiTietHD.DonViTinh, SanPham.DinhLuong, " +
                    $"COALESCE(KhoHang.HinhAnh, Combo.HinhAnh) AS HinhAnh, KhoHang.MaDM " +
                    $"FROM ChiTietHD " +
                    $"LEFT JOIN SanPham ON ChiTietHD.MaSP = SanPham.MaSP_Menu AND ChiTietHD.LoaiHang = 0 " +
                    $"LEFT JOIN Combo ON ChiTietHD.MaSP = Combo.MaCombo AND ChiTietHD.LoaiHang =  1 " +
                    $"INNER JOIN KhoHang ON SanPham.MaSP_Kho = KhoHang.MaSP_Kho " +
                    $"WHERE ChiTietHD.MaHD = {MaHD} ");

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        switch (row["MaDM"])
                        {
                            case "MDM01":
                            case "MDM03":
                            case "MDM05":
                            case "MDM06":
                                folderImage = "FoodImage\\";
                                break;
                            case "MDM02":
                            case "MDM07":
                            case "MDM08":
                                folderImage = "DrinkImage\\";
                                break;
                            case "MDM04":
                                folderImage = "OtherImage\\";
                                break;
                            default:
                                folderImage = "ComboImage\\";
                                break;
                        } //Kiểm tra danh mục sản phẩm để gán file ảnh đúng

                        Panel plItem = new Panel()
                        {
                            Width = flplOrdered.Width - 20,
                            Height = 60,

                            BackColor = Color.FromArgb(244, 233, 216),

                            Font = fontS.timeNew10_Regular,
                            Margin = new Padding(2),
                            Tag = row["MaSP"].ToString(),
                        };
                        PictureBox pbProdImage = new PictureBox()
                        {
                            Width = 40,
                            Height = 40,
                            Image = System.Drawing.Image.FromFile(Application.StartupPath + $"\\Images\\{folderImage}\\{row["HinhAnh"]}"),
                            SizeMode = PictureBoxSizeMode.Zoom,

                            Location = new Point(5, (plItem.Height - 40) / 2),
                        };
                        Label lblTenSP = new Label()
                        {
                            Text = row["TenMatHang"].ToString(),
                            MaximumSize = new Size(200, 0),
                            Height = 80,

                            Location = new Point(50, (plItem.Height) / 2 - 14),
                            AutoSize = true,
                        };

                        //Tính số lượng nếu loại sản phẩm là Kg
                        int soLuong = 0;
                        if (row["DonViTinh"].ToString() == "Kg")
                        {
                            double dinhLuong = Convert.ToDouble(row["DinhLuong"]);
                            soLuong = Convert.ToInt32(Convert.ToDouble(row["SoLuong"]) * 1000 / dinhLuong);
                        }
                        else
                        {
                            soLuong = Convert.ToInt32(row["SoLuong"]);
                        }
                        txtSoLuong = new TextBox()
                        {
                            Text = soLuong.ToString(),
                            Width = 30,
                            Height = 30,

                            ReadOnly = true,
                            TextAlign = HorizontalAlignment.Center,
                            Location = new Point(lblTenSanPham.Width + 20, plItem.Height / 2 - 12),
                            AutoSize = true,
                        };

                        plItem.Controls.Add(lblTenSP);
                        plItem.Controls.Add(txtSoLuong);
                        plItem.Controls.Add(pbProdImage);
                        flplOrdered.Controls.Add(plItem);

                        Session.isPlus = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmDetails - LoadOrdered Lỗi:\n" + ex.Message);
            }
        } //Load sản phẩm đã order của phòng
        private void btnOrdered_Click(object sender, EventArgs e)
        {
            flplOrdered.Visible = !flplOrdered.Visible;
            Load_Ordered(GetBillID());

            flplOrdered.BringToFront();
            this.Controls.Add(flplOrdered);
        }
    }
}
