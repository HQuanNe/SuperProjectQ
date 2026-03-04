using Mscc.GenerativeAI.Types;
using SuperProjectQ.AllForm;
using SuperProjectQ.AllForm.Other;
using SuperProjectQ.FrmMixed;
using SuperProjectQ.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using Mscc.GenerativeAI; //Thư viện Google AI

namespace SuperProjectQ.Frm_Main_Login_Register
{
    public partial class frmMainUI : Form
    {
        public frmMainUI()
        {
            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; //Hỗ trợ chạy AI cho phiên bản .NET Framework 
            InitializeComponent();
            model = AIchatBot.GenerativeModel(Model.Gemini25Flash); //Lấy Model (Phiên bản Gemini 2.5Flash)
        }
        GoogleAI AIchatBot = new GoogleAI(ConfigurationManager.AppSettings["GeminiAPIKey"]); // Tạo đôi tượng kết nối với Google AI bằng API Key
        GenerativeModel model; //Khởi tạo Model

        ConnectData kn = new ConnectData();
        string mainIDUser = Session.IDUser, mainTenNV = Session.TenNV;

        private void AddForm(Form form)
        {
            plControls.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;
            form.Show();

            plControls.Controls.Add(form);
        }

        private void AllMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem MNItemClicked = sender as ToolStripMenuItem;

            plControls.Visible = true;

            switch (MNItemClicked.Name)
            {
                case "MNHome":
                    plControls.Visible = false;
                    break;
                case "MNRoom":
                    frmPhong phong = new frmPhong();
                    AddForm(phong);
                    break;
                case "MNMenuOrder":
                    frmOrder menu = new frmOrder();
                    AddForm(menu);
                    break;
                case "btnNhanVien":
                    frmNhanVien nhanVien = new frmNhanVien();
                    AddForm(nhanVien);
                    break;
                case "btnKhachHang":
                    frmKhachHang khachHang = new frmKhachHang();
                    AddForm(khachHang);
                    break;
                case "btnKhoHang":
                    frmKho khoHang = new frmKho();
                    AddForm(khoHang);
                    break;
                case "btnHoaDon":
                    frmHoaDon hoaDon = new frmHoaDon();
                    AddForm(hoaDon);
                    break;
                case "btnChart":
                    frmBieuDoDoanhThu chart = new frmBieuDoDoanhThu();
                    AddForm(chart);
                    break;
                case "btnSetting":
                    frmSetting setting = new frmSetting();
                    AddForm(setting);
                    break;
                default:
                    return;
            }
        }

        private string TenQH()
        {
            string mainTenQH = null;
            string sqlQH = $"SELECT QuyenHan.MaQH, QuyenHan.TenQH, Users.IDUser\r\nFROM PhanQuyen\r\nINNER JOIN QuyenHan ON QuyenHan.MaQH = PhanQuyen.MaQH\r\nINNER JOIN Users ON Users.IDUser = PhanQuyen.IDUser\r\nWHERE PhanQuyen.IDUser = '{mainIDUser}'";
            DataTable dtQH = new DataTable();
            dtQH = kn.CreateTable(sqlQH);
            foreach (DataRow rQH in dtQH.Rows)
            {
                mainTenQH = rQH["TenQH"].ToString();
            }
            return mainTenQH;
        }

        private void frmMainUI_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            lblTenNV.Text = mainTenNV;

            plControls.Visible = false;

            Session.KiemTraGhiNo(); // Kiểm tra ghi nợ khi mở form Main
            Session.KiemTraVoucher(); //Kiểm tra voucher khi mở form Main
        }

        #region AI Chatbot
        Panel plAIChatbot = null;
        private void btnAIChatbot_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(plAIChatbot))
            {
                plAIChatbot.Visible = !plAIChatbot.Visible;
                return;
            }
            plAIChatbot = new Panel()
            {
                Width = 500,
                Height = 700,
                MinimumSize = new Size(500, 700),

                BackColor = Color.FromArgb(255, 228, 181),
                Anchor = AnchorStyles.Right,
                Dock = DockStyle.Right,
                //BackColor = Color.Red,
            };
            Label lblTitle = new Label()
            {
                MinimumSize = new Size(200, 60),

                Text = "Trợ lý ảo AI",
                Font = new Font("Times New Roman", 26, FontStyle.Bold),

                Location = new Point((plAIChatbot.Width - 200) / 2, 5)
            };
            RichTextBox rtxtChatHistory = new RichTextBox()
            {
                Width = 460,
                Height = 580,

                ReadOnly = true,
                HideSelection = true,
                ForeColor = Color.Green,
                Font = new Font("Times New Roman", 12, FontStyle.Regular),

                Location = new Point((plAIChatbot.Width - 460) / 2, 60),
            };
            TextBox txtRequest = new TextBox()
            {
                Width = rtxtChatHistory.Width - 60,
                Height = 80,

                MinimumSize = new Size(0, 80),
                Margin = new Padding(5),
                Font = new Font("Times New Roman", 12, FontStyle.Regular),

                Location = new Point((plAIChatbot.Width - rtxtChatHistory.Width) / 2, rtxtChatHistory.Height + 70)
            };
            Button btnSendRequest = new Button()
            {
                Width = rtxtChatHistory.Width - txtRequest.Width,
                Height = 80,

                FlatAppearance =
                {
                },

                BackColor = Color.FromArgb(240, 230, 140),
                FlatStyle = FlatStyle.Flat,
                MinimumSize = new Size(0, 80),
                Margin = new Padding(5),
                Text = "Gửi",
                Font = new Font("Times New Roman", 12, FontStyle.Regular),

                Location = new Point(txtRequest.Width + 20, rtxtChatHistory.Height + 70)
            };

            plAIChatbot.Controls.Add(btnSendRequest);
            plAIChatbot.Controls.Add(txtRequest);
            plAIChatbot.Controls.Add(rtxtChatHistory);
            plAIChatbot.Controls.Add(lblTitle);
            this.Controls.Add(plAIChatbot);
            this.AcceptButton = btnSendRequest;

            btnSendRequest.Click += async (sender, e) =>
            {
                //async là hàm bất đồng bộ tránh việc Not Responding khi AI trả lời
                string requestMessage = txtRequest.Text;  //Gửi đi câu hỏi

                if (string.IsNullOrEmpty(requestMessage)) return;

                rtxtChatHistory.AppendText($"Tôi: {requestMessage}\n\n");
                txtRequest.Clear();
                try
                {
                    var responding = await model.GenerateContent(requestMessage); //Gửi câu hỏi cho AI chờ phản hồi
                    if (responding == null || responding.Text == null)
                    {
                        MessageBox.Show("Lỗi");
                        return;
                    }//nếu null sẽ báo lỗi
                    rtxtChatHistory.AppendText($"Trợ lý Para: {responding.Text}\n\n"); //Thêm câu trả lời
                }
                catch (GeminiApiException ex)
                {
                    MessageBox.Show("Lỗi kết nối AI Chatbot " + ex.Message);
                    return;
                }
            };
        }
        #endregion
        private void btnOpenNavBar_Click(object sender, EventArgs e)
        {
            plNavBar.Visible = !plNavBar.Visible;

            if (!plNavBar.Visible)
            {
                plControls.Location = new Point(0, plControls.Location.Y);
                plControls.Width += plNavBar.Width;
            }
            else
            {
                plControls.Location = new Point(plNavBar.Width, plControls.Location.Y);
                plControls.Width -= plNavBar.Width;
            }
        }

    }
}
