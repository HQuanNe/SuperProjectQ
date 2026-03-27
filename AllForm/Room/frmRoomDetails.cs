using SuperProjectQ.AllForm;
using SuperProjectQ.FrmMixed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SuperProjectQ.AllForm.Room
{
    public partial class frmRoomDetails : Form
    {
        public frmRoomDetails()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        Session.FontStandard fontS = new Session.FontStandard();
        SqlCommand cmd;
        DataTable dt;

        Image iconConfirm = Image.FromFile(Application.StartupPath + @"\Images\IconUI\done_outline_22dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png");

        int maHD = Session.RoomData.maHD;
        string folderImage = ""; //Thư mục chứa ảnh theo danh mục
        decimal currTotal = 0; //tổng tiền tính đến thời điểm hiện tại
        DateTime timeIn; //Giờ vào
        decimal pricePerHour = 0;

        class Button_Plus_And_Minus
        {
            public System.Windows.Forms.Button btn = null;

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
        private void Load_Ordered(int MaHD)
        {
            try
            {
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

                            //BackColor = Color.FromName("PaleGreen"),

                            Font = fontS.timeNew10_Regular,
                            Margin = new Padding(2),
                            Tag = row["MaSP"].ToString(),
                        };
                        PictureBox pbProdImage = new PictureBox()
                        {
                            Width = 40,
                            Height = 40,
                            Image = Image.FromFile(Application.StartupPath + $"\\Images\\{folderImage}\\{row["HinhAnh"]}"),
                            SizeMode = PictureBoxSizeMode.Zoom,

                            Location = new Point(5, (plItem.Height - 40)/2),
                        };
                        Label lblTenSP = new Label()
                        {
                            Text = row["TenMatHang"].ToString(),
                            MaximumSize = new Size(250, 50),

                            Location = new Point(50, plItem.Height / 2 - 12),
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
                        #region  Nút tăng giảm số lượng
                        TextBox txtSoLuong = new TextBox()
                        {
                            Text = soLuong.ToString(),
                            TextAlign = HorizontalAlignment.Center,
                            Size = new Size(40, 24),
                            ReadOnly = true,

                            Location = new Point(lblTenSP.Width + lblTenSP.Location.X +200, plItem.Height / 2 - 12),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        Button btnMinus = new Button()
                        {
                            Text = "-",
                            TextAlign = ContentAlignment.MiddleCenter,
                            Size = new Size(20, 24),
                            BackColor = Color.Transparent,
                            FlatStyle = FlatStyle.Flat,

                            Location = new Point(txtSoLuong.Location.X - 20, plItem.Height / 2 - 12),

                            FlatAppearance =
                            {
                                MouseOverBackColor = Color.FromArgb(255, 128, 128),
                                BorderSize = 0
                            }
                        };

                        Button btnPlus = new Button()
                        {
                            Text = "+",
                            TextAlign = ContentAlignment.MiddleCenter,
                            Size = new Size(20, 24),
                            BackColor = Color.Transparent,
                            FlatStyle = FlatStyle.Flat,

                            Location = new Point(txtSoLuong.Location.X + txtSoLuong.Width, plItem.Height / 2 - 12),

                            FlatAppearance =
                            {
                                MouseOverBackColor = Color.FromArgb(192, 255, 192),
                                BorderSize = 0
                            }
                        };
                        #endregion

                        Button btnXacNhan = new Button()
                        {
                            Image = iconConfirm,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Size = new Size(40, 26),
                            BackColor = Color.LimeGreen,
                            ForeColor = Color.White,
                            Location = new Point(btnPlus.Location.X + btnPlus.Width + 5, plItem.Height / 2 - 12),
                            FlatStyle = FlatStyle.Flat,
                            FlatAppearance =
                        {
                            BorderSize = 0
                        }
                        };
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

                        plItem.Controls.Add(pbProdImage);
                        plItem.Controls.Add(btnXacNhan);
                        btnXacNhan.Click += btnXacNhan_click;

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
        private void btnXacNhan_click(object sender, EventArgs e)
        {
            DialogResult? reply = null;
            Button thisBtn = sender as Button;

            if (Session.isPlus == true) reply = MessageBox.Show("Xác nhận thêm đồ vào phòng ?", "Xác nhận", MessageBoxButtons.YesNo);
            else if (Session.isPlus == false) reply = MessageBox.Show("Xác nhận giảm đồ của phòng ?", "Xác nhận", MessageBoxButtons.YesNo);

            if (reply == DialogResult.Yes && Session.isPlus.HasValue)
            {
                dt = new DataTable();
                dt = kn.CreateTable($"SELECT SoLuong, DonGia FROM ChiTietHD WHERE MaHD = {maHD} AND MaSP = '{thisBtn.Parent.Tag}'");

                double soLuongHienTai = Convert.ToDouble(dt.Rows[0]["SoLuong"]);
                double soLuongMoi = Convert.ToDouble(thisBtn.Parent.Controls[1].Text);
                double donGia = Convert.ToDouble(dt.Rows[0]["DonGia"]);

                double soLuongThayDoi = 0;

                if (Session.isPlus == true) soLuongThayDoi = soLuongMoi - soLuongHienTai;
                else if (Session.isPlus == false) soLuongThayDoi = soLuongHienTai - soLuongMoi;

                string sqlUpdateSoLuong = $"UPDATE ChiTietHD SET SoLuong = @SLM, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
                using (cmd = new SqlCommand(sqlUpdateSoLuong, kn.conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@SLM", soLuongMoi);
                    cmd.Parameters.AddWithValue("@TT", soLuongMoi * donGia);
                    cmd.Parameters.AddWithValue("@MHD", maHD);
                    cmd.Parameters.AddWithValue("@MSP", thisBtn.Parent.Tag.ToString());
                    cmd.ExecuteNonQuery();
                }
                ;


                //Xoá sản phẩm khỏi CTHD khi số lượng về 0
                using (cmd = new SqlCommand("DELETE ChiTietHD WHERE SoLuong = 0", kn.conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string maSP = thisBtn.Parent.Tag.ToString();

                if (!(maSP.Contains("SPM"))) Session.isCombo = true;
                else Session.isCombo = false;

                MessageBox.Show("SL thay doi" + soLuongThayDoi.ToString());
                Session.CapNhatKho(!Session.isPlus.Value, maSP, soLuongThayDoi); //Cập nhật kho

                Load_Ordered(maHD);
            }
        }
        private string TimeIn_Load()
        {
            cmd = new SqlCommand($"SELECT GioVao FROM HoaDon WHERE MaHD = {Session.RoomData.maHD}", kn.conn);

            return Convert.ToDateTime(cmd.ExecuteScalar()).ToString("dd/MM/yyyy HH:mm:ss");
        }
        private void LoaiPhong_Load()
        {
            try
            {
                dt = new DataTable();
                dt = kn.CreateTable("SELECT Phong.GioVao, LoaiPhong.TenLoaiPhong, LoaiPhong.GiaTheoGio " +
                    "FROM LoaiPhong " +
                    $"INNER JOIN Phong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong AND Phong.MaPhong = '{Session.RoomData.maPhong}' " +
                    $"WHERE Phong.TrangThai = 1");

                lblLoaiPhong.Text = "Loại phòng: " + dt.Rows[0]["TenLoaiPhong"].ToString();

                timeIn = Convert.ToDateTime(dt.Rows[0]["GioVao"]);
                pricePerHour = (decimal)dt.Rows[0]["GiaTheoGio"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRoomDetails - LoaiPhong_Load()-Function Lỗi:\n" + ex.Message);
            }
        }
        private void CurrentTotal()
        {
            DateTime currTime = DateTime.Now;

            decimal pricePerMinute = Session.TinhTienPhongSau_22h(timeIn, pricePerHour) / 60;
            TimeSpan totalTime = currTime - timeIn;
            decimal roomTotal = Math.Round(Math.Round((decimal)totalTime.TotalMinutes) * pricePerMinute) * 1000 / 1000;

            lblCurrTotal.Text = "Tổng tiền phòng hiện tại: " + roomTotal.ToString("#,##0") + "đ";
            lblTotalAmount.Text = "Tổng: " + (Session.BillData.TongTienDV + roomTotal).ToString("#,##0") + "đ";
            lblPricePerHour.Text = "Giá 1 giờ: " + Session.TinhTienPhongSau_22h(timeIn, pricePerHour).ToString("#,##0") + "đ";


        }
        private void ConfirmPayment(string RoomID) //Xác nhận qua bước tt
        {
            DialogResult reply = MessageBox.Show("Xác nhận qua bước thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                //Gán biến toàn chương trình
                Session.RoomData.maPhong = RoomID;
                frmThanhToan tt = new frmThanhToan();
                tt.ShowDialog();
                if (Session.BillData.isPay) this.Close();
            }
        }
        private void frmRoomDetails_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();

                Load_Ordered(Session.RoomData.maHD);
                LoaiPhong_Load();
                CurrentTotal();

                lblTimeIn.Text = $"Giờ vào: {TimeIn_Load()}";
                lblRoomName.Text = Session.RoomData.tenPhong + $" - Hoá đơn số: {Session.RoomData.maHD}";
                lblSubTotal.Text = "Tổng tiền sản phẩm: " +  Session.BillData.TongTienDV.ToString("#,##0") + "đ";

                txtSDT.Text = Session.CustomerData.SoDienThoai;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRoomDetails - Load-Function Lỗi:\n" + ex.Message);
            }
        }
        private void btnOpenMenu_Click(object sender, EventArgs e)
        {

            frmMenu menu = new frmMenu();
            menu.FormBorderStyle = FormBorderStyle.None;
            menu.flowLayoutDSPhong.Visible = false;
            menu.WindowState = FormWindowState.Maximized;

            menu.ShowDialog();

            flplOrdered.Controls.Clear();
            Load_Ordered(Session.RoomData.maHD);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            DateTime dateTimeOut = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")); // Tính giờ ra
            Session.RoomData.TimeOut = dateTimeOut;

            ConfirmPayment(Session.RoomData.maPhong);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 10) 
            {
                txtSDT.Text = txtSDT.Text.Remove(10, 1);
            }
            txtSDT.SelectionStart = txtSDT.Text.Length;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sửa số điện thoại hiện tại?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel) return;

            if (!(Session.XuLySDT(txtSDT.Text))) return;

            Session.CustomerData.SoDienThoai = txtSDT.Text;
            Session.UpdatePhoneNumberForRoom(txtSDT.Text);
        }
    }
}
