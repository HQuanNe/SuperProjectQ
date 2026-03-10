using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SuperProjectQ.FrmMixed;

namespace SuperProjectQ.AllForm.Other
{
    public partial class frmVoucherKhachHang : Form
    {
        public frmVoucherKhachHang()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt = null;

        string giaTriGiam = "";
        string giaTriGiamToiDa = "";
        decimal giamVoucher = 0; // Tiền giảm voucher

        Panel selectedPanel = null;
        Panel plInThePast = null;

        frmOrder od = new frmOrder();

        private void TinhTienGiamGia()
        {
            if (selectedPanel != null)
            {
                string sqlLayVoucher = $"SELECT Voucher.GiaTriGiam, Voucher.LoaiGiamGia, Voucher.GiamToiDa FROM VoucherKhachHang \n" +
                    $"INNER JOIN VouCher ON Voucher.MaVoucher = VoucherKhachHang.MaVoucher " +
                    $"WHERE VoucherKhachHang.TrangThai = 0 AND VoucherKhachHang.MaKH = '{Session.MaKH}' AND VoucherKhachHang.STT = {selectedPanel.Name}";
                dt = kn.CreateTable(sqlLayVoucher);

                Console.WriteLine(Session.MaKH + "\n" + selectedPanel.Name);

                if (dt.Rows.Count > 0)
                {

                    decimal giaTriGiam = Convert.ToDecimal(dt.Rows[0]["GiaTriGiam"]);

                    //Nếu là true thì sẽ giảm theo %
                    if (Convert.ToBoolean(dt.Rows[0]["LoaiGiamGia"]))
                    {
                        giamVoucher = Session.TongTien * giaTriGiam;
                        Session.DiscountVoucher = giamVoucher;

                        if (Session.DiscountVoucher > Convert.ToDecimal(dt.Rows[0]["GiamToiDa"]) && Convert.ToDecimal(dt.Rows[0]["GiamToiDa"]) > 0)
                        {
                            Session.DiscountVoucher = Convert.ToDecimal(dt.Rows[0]["GiamToiDa"]);
                        }
                    }
                    //Giảm theo tiền
                    else
                    {
                        giamVoucher = giaTriGiam;
                        Session.DiscountVoucher = giamVoucher;
                    }
                }
                else
                {
                    giamVoucher = 0;
                    Session.DiscountVoucher = giamVoucher;
                }
            }
        } //tính tiền giảm giá của voucher
        private void Voucher_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable( $"SELECT VoucherKhachHang.STT, Voucher.MaVoucher, VoucherKhachHang.MaKH, VoucherKhachHang.NgayHetHan, Voucher.TenVoucher, Voucher.GiaTriGiam, Voucher.LoaiGiamGia, Voucher.GiamToiDa, Voucher.GTDonHangToiThieu, Voucher.HinhAnh " +
                $"FROM Voucher " +
                $"INNER JOIN VoucherKhachHang ON Voucher.MaVoucher = VoucherKhachHang.MaVoucher " +
                $"WHERE VoucherKhachHang.TrangThai = 0 AND VoucherKhachHang.MaKH = '{Session.MaKH}' ");

            if (dt.Rows.Count < 0 && dt.Rows != null) return;
            foreach (DataRow row in dt.Rows)
            {
                // Tạo panel chứa thông tin voucher
                Panel plVoucher = new Panel()
                {
                    Width = 500,
                    Height = 120,

                    BackColor = Color.FromArgb(255, 224, 192),

                    Name = row["STT"].ToString(),

                    //Enabled = false,

                };
                // Tạo PictureBox để hiển thị hình ảnh voucher
                PictureBox picboxVoucher = new PictureBox()
                {
                    Width = 180,
                    Height = 86,

                    BackColor = Color.Blue,

                    Enabled = false,

                    Location = new Point(10, 15),

                    Image = Image.FromFile(Application.StartupPath + $"\\Images\\VoucherImage\\{row["HinhAnh"]}"),

                };
                // Tạo Label để hiển thị tên voucher
                Label lblTenVoucher = new Label()
                {
                    Width = plVoucher.Width / 2 +20,
                    Height = picboxVoucher.Height / 3,

                    MinimumSize = new Size(plVoucher.Width / 2, 50),

                    Enabled = false,

                    Text = row["TenVoucher"].ToString(),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Times New Roman", 14, FontStyle.Bold),
                    ForeColor = Color.OrangeRed,

                    //BackColor = Color.FromArgb(255, 255, 192),

                    Location = new Point(picboxVoucher.Width + 20, 5),
                };
                #region Chi tiết mô tả

                if (Convert.ToDecimal(row["GiamToiDa"]) > 0)
                {
                    giaTriGiamToiDa = $"(Tối đa: {Convert.ToDecimal(row["GiamToiDa"]).ToString("#,##0đ")})";
                }
                else                {
                    giaTriGiamToiDa = "";
                }
                // Tạo panel mô tả voucher
                Panel plMoTaVoucher = new Panel()
                {
                    Width = plVoucher.Width / 2 + 40,
                    Height = 60,

                    //BackColor = Color.Yellow,

                    Enabled = false,

                    Margin = new Padding(0),
                    Padding = new Padding(0),

                    Location = new Point(picboxVoucher.Width + 20, lblTenVoucher.Height + 5),
                };

                if (Convert.ToBoolean(row["LoaiGiamGia"])) { giaTriGiam = $"Giảm: {Convert.ToDouble(row["GiaTriGiam"]) * 100}% tổng hoá đơn"; } // Nếu là giảm theo %
                else { giaTriGiam = $"Giảm: {Convert.ToDouble(row["GiaTriGiam"]):N0} VNĐ"; } // Nếu là giảm theo số tiền

                Label GiaTriGiam = new Label()
                {
                    Width = plMoTaVoucher.Width + 40,
                    Height = plMoTaVoucher.Height / 2 - 10,

                    //BackColor = Color.DarkRed,

                    Enabled = false,

                    Text = $"{giaTriGiam} {giaTriGiamToiDa}",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Times New Roman", 12, FontStyle.Regular),
                    ForeColor = Color.Red,
                };
                Label GTDonHangToiThieu = new Label()
                {
                    Width = plMoTaVoucher.Width - 10,
                    Height = plMoTaVoucher.Height / 2 - 10,

                    //BackColor = Color.DarkRed,

                    Enabled = false,

                    Text = $"Hoá đơn tối thiểu: {Convert.ToDouble(row["GTDonHangToiThieu"]):N0}đ",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Times New Roman", 12, FontStyle.Regular),
                    ForeColor = Color.Blue,

                    Location = new Point(0, GiaTriGiam.Height),
                };
                Label HanSuDung = new Label()
                {
                    Width = plMoTaVoucher.Width - 10,
                    Height = plMoTaVoucher.Height / 2 - 5,

                    //BackColor = Color.DarkRed,

                    Enabled = false,

                    Text = $"HSD: {Convert.ToDateTime(row["NgayHetHan"]).ToString("dd/MM/yyyy")}",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Times New Roman", 12, FontStyle.Regular),
                    ForeColor = Color.Blue,

                    //BackColor = Color.Red,

                    Location = new Point(0, GiaTriGiam.Height + GTDonHangToiThieu.Height),
                };
                #endregion

                flowLayoutPNVoucher.Controls.Add(plVoucher);

                plVoucher.Controls.Add(picboxVoucher);
                plVoucher.Controls.Add(lblTenVoucher);
                plVoucher.Controls.Add(plMoTaVoucher);
                plVoucher.Click += (sender, e) =>
                {
                    if (plInThePast != null) plInThePast.BorderStyle = BorderStyle.None;

                    Panel plClicked = sender as Panel;

                    plClicked.BorderStyle = BorderStyle.FixedSingle;

                    selectedPanel = plClicked;

                    Console.WriteLine(Session.DiscountVoucher);
                    plInThePast = plClicked;
                };

                plMoTaVoucher.Controls.Add(GiaTriGiam);
                plMoTaVoucher.Controls.Add(GTDonHangToiThieu);
                plMoTaVoucher.Controls.Add(HanSuDung);

                if (Session.TongTien < Convert.ToDecimal(row["GTDonHangToiThieu"]))
                {
                    plVoucher.BackColor = Color.Gray;
                    plVoucher.Enabled = false;
                }
            }

        }
        private void frmVoucher_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Voucher_Load();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Chọn voucher này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && selectedPanel != null)
            {
                TinhTienGiamGia();
                Session.STTVoucher = Convert.ToInt32(selectedPanel.Name); // Lưu STT voucher được chọn
                Session.isUsedVoucher = true; // Đánh dấu đã sử dụng voucher
                Session.tenVoucher = selectedPanel.Controls[1].Text;
                this.Close();
            }
        }
    }
}
