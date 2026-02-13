using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
            kn.ConnOpen();
        }
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
        DataTable dt = null;
        SqlCommand cmd = null;

        Button btnDSPhong = null; // Panel chứa danh sách phòng
        Button btnPassClick = null; // Lưu button phòng đang được click

        Panel plItem = null; // Panel chứa từng sản phẩm
        Button selectedRoomButton = null; // Lưu panel đang được click

        PictureBox pbItem = null; // Khai báo object PictureBox ảnh sản phẩm
        Label lblTenSanPham = null;  // Khai báo object Label tên sản phẩm
        Label lblGiaBan = null; // Khai báo object Label giá bán

        TextBox txtSoLuong = null;
        Button btnPlus = null;
        Button btnMinus = null;
        Button btnOrder = null; // Khai báo object Button mua hàng

        private void ItemPanel_SanPham(string tag_1 = "")
        {

            string sqlSP = "SELECT SanPham.MaSP, SanPham.TenHienThi, SanPham.GiaBan, SanPham.HinhAnh, KhoHang.MaDM " +
                           $"FROM SanPham INNER JOIN KhoHang ON SanPham.MaSP = KhoHang.MaSP  " +
                           $"WHERE KhoHang.MaDM LIKE '%{tag_1}%' AND KhoHang.TonKho >=20 ORDER BY SanPham.TenHienThi";
            dt = kn.CreateTable(sqlSP);

            foreach (DataRow row in dt.Rows)
            {
                string pathImage = "";

                plItem = new Panel() // Tạo panel cho mỗi sản phẩm
                {
                    Width = SetParameters.plOrder_WIDTH,
                    Height = SetParameters.plOrder_HEIGHT,
                    Margin = new Padding(2),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,

                    Tag = row["MaDM"].ToString(), // Lưu mã DM vào Tag


                };

                switch (row["MaDM"].ToString())
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

                if (row["HinhAnh"] != DBNull.Value && row["HinhAnh"].ToString() != "")// Kiểm tra nếu có hình ảnh
                {
                    pbItem = new PictureBox() // Tạo PictureBox cho hình ảnh sản phẩm
                    {
                        Width = SetParameters.pbOrder_WIDTH,
                        Height = SetParameters.pbOrder_HEIGHT,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = Image.FromFile(Application.StartupPath + $"\\Image\\{pathImage = pathImage + row["HinhAnh"]}"),
                        Location = new Point(20, 10),
                        //BackColor = Color.Red,
                    };

                    lblTenSanPham = new Label() // Tạo Label cho tên sản phẩm
                    {
                        Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point),
                        Text = $"{row["TenHienThi"].ToString()}",
                        ForeColor = Color.Black,
                        AutoSize = true,

                        MinimumSize = new Size(SetParameters.pbOrder_WIDTH, 0),
                        MaximumSize = new Size(SetParameters.pbOrder_WIDTH + 10, 0),

                        Location = new Point(20, pbItem.Location.Y + pbItem.Height + 5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        //BackColor = Color.Red,
                    };
                    decimal giaBan = Convert.ToDecimal(row["GiaBan"]); // Lấy giá bán từ cơ sở dữ liệu
                    lblGiaBan = new Label()// Tạo Label cho giá bán
                    {
                        Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point),
                        ForeColor = Color.Red,
                        Text = giaBan.ToString("#,##0") + "đ",
                        AutoSize = true,

                        MinimumSize = new Size(SetParameters.pbOrder_WIDTH, 0),
                        MaximumSize = new Size(SetParameters.pbOrder_WIDTH + 10, 0),
                        TextAlign = ContentAlignment.MiddleCenter,

                        Location = new Point(20, (lblTenSanPham.Location.Y + lblTenSanPham.Height) + 45),
                        //BackColor = Color.Red,
                    };

                    #region Nút tăng, giảm số lượng
                    txtSoLuong = new TextBox()
                    {
                        Width = 80,
                        Height = 30,

                        Name = row["MaSP"].ToString(),

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

                        Name = row["MaSP"].ToString(),

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

                        Name = row["MaSP"].ToString(),

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

                        Name = row["MaSP"].ToString(), // Lưu mã SP vào Name của Button

                        Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point),
                        ForeColor = Color.Black,
                        BackColor = Color.FromArgb(192, 255, 255),
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(45, (lblGiaBan.Location.Y + lblGiaBan.Height) + 75),


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
                flowLayoutDSPhong.Controls.Add(btnDSPhong);

                plItem.Controls.Add(pbItem);
                plItem.Controls.Add(lblTenSanPham);
                plItem.Controls.Add(lblGiaBan);

                plItem.Controls.Add(txtSoLuong);
                plItem.Controls.Add(btnPlus);
                plItem.Controls.Add(btnMinus);

                plItem.Controls.Add(btnOrder);

            }
        }
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            bool isAdded = false;

            double soLuong = Convert.ToDouble(clickedButton.Parent.Controls[3].Text.Trim()); //Số lượng thêm vào hiện tại ở textbox

            if (selectedRoomButton == null)
            {
                MessageBox.Show("Hãy chọn phòng");
                return;
            }
            else
            {
                if (MessageBox.Show($"Thêm sản phẩm này vào phòng {selectedRoomButton.Name}", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dt = new DataTable();
                    dt = kn.CreateTable($"SELECT SanPham.MaSP, SanPham.TenHienThi, KhoHang.DonViTinh, SanPham.GiaBan, SanPham.DinhLuong FROM SanPham INNER JOIN KhoHang ON KhoHang.MaSP = SanPham.MaSP " +
                        $"WHERE SanPham.MaSP = '{clickedButton.Name}'");

                    cmd = new SqlCommand($"SELECT HoaDon.MaHD FROM HoaDon " +
                                        $"INNER JOIN Phong ON Phong.MaPhong = HoaDon.MaPhong " +
                                        $"WHERE HoaDon.MaPhong = '{selectedRoomButton.Name}' AND Phong.TrangThai = 1 AND HoaDon.TrangThai = 0", kn.conn);
                    int intMaHD = Convert.ToInt32(cmd.ExecuteScalar());

                    string maSP = dt.Rows[0][0].ToString();
                    string tenSP = dt.Rows[0][1].ToString();
                    string donViTinh = dt.Rows[0][2].ToString();
                    int donGia = Convert.ToInt32(dt.Rows[0][3].ToString());

                    double dinhLuong = Convert.ToDouble(dt.Rows[0][4].ToString());

                    if(donViTinh == "Kg") dinhLuong = dinhLuong / 1000 * soLuong;
                    else dinhLuong = soLuong;

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
                        string sqlAdd = "INSERT INTO ChiTietHD (MaCTHD, MaHD, MaSP, SoLuong, DonViTinh, DonGia, ThanhTien) VALUES (@MCTHD, @MHD, @MSP, @SL, @DV, @DG, @TT)";
                        cmd = new SqlCommand(sqlAdd, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MCTHD", Session.AutoCreateID("MaCTHD", "ChiTietHD"));
                        cmd.Parameters.AddWithValue("@MHD", intMaHD);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("@SL", dinhLuong);
                        cmd.Parameters.AddWithValue("@DV", donViTinh);
                        cmd.Parameters.AddWithValue("@DG", donGia);
                        cmd.Parameters.AddWithValue("@TT", dinhLuong * donGia);
                        cmd.ExecuteNonQuery();

                        isAdded = true;
                    }
                    //Kiểm tra số lượng thêm vào có vượt tồn kho không
                    //Lấy tồn kho
                    string sqlTonKho = $"SELECT TonKho FROM KhoHang WHERE MaSP = '{maSP}'";
                    cmd = new SqlCommand(sqlTonKho, kn.conn);
                    double tonKho = Convert.ToDouble(cmd.ExecuteScalar());
                    if (soLuong > tonKho)
                    {
                        MessageBox.Show("hết hàng rùi !!!");
                        return;
                    }
                    else
                    {
                        //Nếu có rồi thì cập nhật số lượng lên 1
                        if (!flag)
                        {
                            cmd = new SqlCommand($"SELECT SoLuong FROM ChiTietHD WHERE MaSP = '{maSP}' AND MaHD = {intMaHD} ", kn.conn);

                            double soLuongDaCo = (double)cmd.ExecuteScalar();
                            soLuongDaCo += dinhLuong;
                            if (soLuong <= 0) { MessageBox.Show("Số lượng < 1"); return; }
                            decimal thanhTien = Convert.ToDecimal((soLuongDaCo * 1000) / (dinhLuong*1000)) * donGia;

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
                }
                if (isAdded)
                {
                    Session.CapNhatKho(false, clickedButton.Name, soLuong);

                    cmd = new SqlCommand($"SELECT TenHienThi FROM SanPham WHERE MaSP = '{clickedButton.Name}'", kn.conn);
                    string tenSP = (string)cmd.ExecuteScalar();
                    cmd = new SqlCommand($"SELECT TenPhong FROM Phong WHERE MaPhong = '{selectedRoomButton.Name}'", kn.conn);
                    string tenPhong = (string)cmd.ExecuteScalar();
                    MessageBox.Show($"Đã thêm sản phẩm {tenSP} cho phòng {tenPhong}"); return;
                }
            }
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            ItemPanel_SanPham();

            string sqlPhong = "SELECT * FROM Phong WHERE TrangThai = 1";
            dt = kn.CreateTable(sqlPhong);

            foreach (DataRow row in dt.Rows)
            {
                btnDSPhong = new Button() // Tạo FlowLayoutPanel chứa phòng
                {
                    Width = SetParameters.btnPhong_WIDTH,
                    Height = SetParameters.btnPhong_HEIGHT,

                    Name = row["MaPhong"].ToString(), // Lưu mã phòng vào Name của Button

                    BackColor = Color.FromArgb(192, 255, 255),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point),
                    ForeColor = Color.Black,
                    Text = row["TenPhong"].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    
                    FlatAppearance =
                    {
                        MouseOverBackColor = Color.Cyan,
                        MouseDownBackColor = Color.Blue,
                        BorderSize = 0,
                    }
                };
                flowLayoutDSPhong.Controls.Add(btnDSPhong);
                btnDSPhong.Click += BtnDSPhong_Click;
            }

            //Ẩn các nút con của nút cha ở thanh điều hướng
            HideBtnFoodChildren();
            HideBtnDrinkChildren();
        }
        private void BtnDSPhong_Click(object sender, EventArgs e)
        {

            if (btnPassClick != null) { btnPassClick.BackColor = Color.FromArgb(192, 255, 255); btnPassClick.ForeColor = Color.Black; };

            Button clickedButton = (Button)sender;
            if (clickedButton != null)
            {
                clickedButton.BackColor = Color.Blue;
                clickedButton.ForeColor = Color.White;
                lblTenPhong.Text = clickedButton.Text;
                btnPassClick = clickedButton;

                selectedRoomButton = clickedButton;
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
        private void btnAll_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnAll.Text;
            HideBtnFoodChildren();
            HideBtnDrinkChildren();

            foodFlag = true;
            drinkFlag = true;
            btnFood.Text = "Đồ ăn ▶️";
            btnDrink.Text = "Đồ uống ▶️";

            ShowPanelByTag("");
        }
        #region Nút đồ ăn
        private void btnFood_Click(object sender, EventArgs e)
        {
            if (foodFlag)
            {
                lblDanhMuc.Text = btnFood.Text.Replace("▶", "");
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
                lblDanhMuc.Text = btnFood.Text.Replace("▼", "");
                HideBtnFoodChildren();
                btnFood.Text = "Đồ ăn ▶️";

                foodFlag = true;
            }
        }
        private void btnSnack_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnFood.Text.Replace("▼", "") + " - " + btnSnack.Text;

            ShowPanelByTag("MDM03");
        }
        private void btnDoKho_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnFood.Text.Replace("▼", "") + " - " + btnDoKho.Text;

            ShowPanelByTag("MDM01");
        }

        private void btnHoaQua_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnFood.Text.Replace("▼", "") + " - " + btnHoaQua.Text;

            ShowPanelByTag("MDM06");
        }
        #endregion

        #region Nút đồ uống
        private void btnDrink_Click(object sender, EventArgs e)
        {
            if (drinkFlag)
            {
                lblDanhMuc.Text = btnDrink.Text;
                btnRuou.Visible = true;
                btnNuocNgot.Visible = true;
                btnNuocKhoang.Visible = true;

                btnDrink.Text = "Đồ uống ▼";

                ShowPanelByTag("MDM02,MDM07,MDM08");

                drinkFlag = false;
            }
            else
            {
                lblDanhMuc.Text = btnDrink.Text.Replace("▼", "");
                HideBtnDrinkChildren();

                btnDrink.Text = "Đồ uống ▶";

                drinkFlag = true;
            }
        }
        private void btnRuou_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnDrink.Text.Replace("▼", "") + " - " + btnRuou.Text;
            ShowPanelByTag("MDM02");
        }

        private void btnNuocNgot_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnDrink.Text.Replace("▼", "") + " - " + btnNuocNgot.Text;
            ShowPanelByTag("MDM07");
        }

        private void btnNuocKhoang_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnDrink.Text.Replace("▼", "") + " - " + btnNuocKhoang.Text;
            ShowPanelByTag("MDM08");
        }
        #endregion
        private void btnOther_Click(object sender, EventArgs e)
        {
            lblDanhMuc.Text = btnOther.Text;
            HideBtnFoodChildren();
            HideBtnDrinkChildren();

            foodFlag = true;
            drinkFlag = true;
            btnFood.Text = "Đồ ăn ▶️";
            btnDrink.Text = "Đồ uống ▶️";

            ShowPanelByTag("MDM04");
        }
        private void btnCombo_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
