using Mscc.GenerativeAI; //Thư viện Google AI
using Mscc.GenerativeAI.Types;
using Newtonsoft.Json.Linq;
using SuperProjectQ.AllForm;
using SuperProjectQ.AllForm.NhapKho;
using SuperProjectQ.AllForm.Other;
using SuperProjectQ.AllForm.Productions;
using SuperProjectQ.AllForm.Room;
using SuperProjectQ.Classes;
using SuperProjectQ.FrmMixed;
using SuperProjectQ.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http; //Thư viện thời tiết
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SuperProjectQ.Frm_Main_Login_Register
{
    public partial class frmMainUI : Form
    {
        public frmMainUI()
        {
            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; //Hỗ trợ chạy AI cho phiên bản .NET Framework dươi 4.8
            InitializeComponent();
            Session.SetParameters_Load();
            var root = new Content(AIRepo.GetDataFromSQL() + "Tên mày là ParaD"); //Gán CSDL cho AI

            model = AIchatBot.GenerativeModel(Model.Gemini25Flash, systemInstruction: root); //Lấy Model (Phiên bản Gemini 2.5Flash)
        }
        private GoogleAI AIchatBot = new GoogleAI(ConfigurationManager.AppSettings["GeminiAPIKey"]); // Tạo đôi tượng kết nối với Google AI bằng API Key
        private GenerativeModel model; //Khởi tạo Model

        ConnectData kn = new ConnectData();
        DataTable dt = null;
        AIChatbotRepository AIRepo = new AIChatbotRepository(); //Kho CSDL
        private ChatSession chatSession; //Phiên làm việc với AI

        Session.FontStandard fontS = new Session.FontStandard();
        ToolStripMenuItem MNItemClicked = null; //MenuItem click trước đó

        string mainIDUser = Session.IDUser, mainTenNV = Session.StaffData.TenNV;

        private void AddForm(Form form)
        {
            Session.FreeUpMemoryPanel(plControls);
            plControls.Visible = true;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();

            plControls.Controls.Add(form);
        } // Thêm form vào panel
        private async void GetWeather()
        {
            string apiKey = ConfigurationManager.AppSettings["WheatherAPIKey"];
            string cityName = "Hanoi";
            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric&lang=vi";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string respond = await client.GetStringAsync(weatherURL);

                    JObject jsonData = JObject.Parse(respond);

                    cityName = jsonData["name"].ToString();
                    string temp = jsonData["main"]["temp"].ToString();
                    string description = jsonData["weather"][0]["description"].ToString();
                    string iconCode = jsonData["weather"][0]["icon"].ToString();

                    lblWeather.Text = $"{cityName}: {temp}°C {description}";
                }
                catch (Exception)
                {
                    Console.WriteLine("Lỗi load thời tiết");
                }
            };
        } //Lấy thời tiết
        private void AllMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem MNItemClick = sender as ToolStripMenuItem;

            if (MNItemClicked != null) { MNItemClicked.BackColor = Color.White; MNItemClicked.ForeColor = Color.Black; }
            ;
            MNItemClick.BackColor = Color.FromArgb(239, 246, 255);
            MNItemClick.ForeColor = Color.FromArgb(37, 99, 235);
            MNItemClicked = MNItemClick;

            switch (MNItemClick.Name)
            {
                case "MNHome":
                    plControls.Visible = false;
                    break;
                case "MNRoom":
                    frmPhong phong = new frmPhong();
                    AddForm(phong);
                    break;
                case "MNMenuOrder":
                    frmMenu menu = new frmMenu();
                    menu.plTop.Visible = false;
                    AddForm(menu);
                    break;
                case "MNBill":
                    frmHoaDon hoaDon = new frmHoaDon();
                    AddForm(hoaDon);
                    break;
                case "MNStaffs":
                    frmNhanVien nhanVien = new frmNhanVien();
                    AddForm(nhanVien);
                    break;
                case "MNCustomers":
                    frmKhachHang khachHang = new frmKhachHang();
                    AddForm(khachHang);
                    break;
                case "MNStorage":
                    frmKho khoHang = new frmKho();
                    AddForm(khoHang);
                    break;
                case "MNNhapKho":
                    frmPhieuNhap pn = new frmPhieuNhap();
                    AddForm(pn);
                    break;
                case "MNChart":
                    frmBieuDoDoanhThu chart = new frmBieuDoDoanhThu();
                    AddForm(chart);
                    break;
                case "MNMore_Voucher":
                    frmVoucher voucher = new frmVoucher();
                    AddForm(voucher);
                    break;
                case "MNMore_Products":
                    frmProducts prod = new frmProducts();
                    AddForm(prod);
                    break;
                default:
                    return;
            }
        } //Các nút điều hướng

        private string MaQH()
        {
            string mainTenQH = null;
            string sqlQH = $"SELECT QuyenHan.MaQH, QuyenHan.TenQH, Users.IDUser " +
                $"FROM PhanQuyen " +
                $"INNER JOIN QuyenHan ON QuyenHan.MaQH = PhanQuyen.MaQH " +
                $"INNER JOIN Users ON Users.IDUser = PhanQuyen.IDUser " +
                $"WHERE PhanQuyen.IDUser = '{mainIDUser}'";
            DataTable dtQH = new DataTable();
            dtQH = kn.CreateTable(sqlQH);
            foreach (DataRow rQH in dtQH.Rows)
            {
                mainTenQH = rQH["MaQH"].ToString();
            }
            return mainTenQH;
        } //Lấy mã quyền hạn 

        private void ImageUser_Load()
        {
            try
            {
                picUser.Image = System.Drawing.Image.FromFile(Application.StartupPath + $"\\Images\\StaffImage\\{Session.StaffData.HinhAnh}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load ảnh nhân viên\n" + ex.Message);
            }
        }
        private void frmMainUI_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            while (plControls.Controls.Count > 0)
            {
                Control ctrl = plControls.Controls[0];
                plControls.Controls.RemoveAt(0);
                ctrl.Dispose();
            }
            switch (MaQH())
            {
                case "QH001":
                    break;
                case "QH002":
                    MNStaffs.Visible = false;
                    MNStorage.Visible = false;
                    MNMore.Visible = false;
                    MNChart.Visible = false;
                    btnSetting.Visible = false;
                    break;
                case "QH004":
                    MNStaffs.Visible = false;
                    MNStorage.Visible = false;
                    MNMore.Visible = false;
                    MNChart.Visible = false;
                    btnSetting.Visible = false;
                    break;
                case "QH005":
                    MNStaffs.Visible = false;
                    MNStorage.Visible = false;
                    MNMore.Visible = false;
                    MNChart.Visible = false;
                    btnSetting.Visible = false;
                    break;
                default:
                    break;
            }

            lblTenNV.Text = mainTenNV;

            plControls.Visible = false;
            timerClock.Start();

            GetWeather();
            ImageUser_Load();

            var oldHistory = AIRepo.GetHistory(); //Lấy dữ liệu cũ đã lưu trong SQL
            chatSession = model.StartChat(oldHistory); //Gán data đó làm giá trị khởi đầu


            Session.KiemTraGhiNo(); // Kiểm tra ghi nợ khi mở form Main
            Session.KiemTraVoucher(); //Kiểm tra voucher khi mở form Main
        }

        #region AI Chatbot
        Panel plAIChatbot = null;
        private void btnAIChatbot_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(plAIChatbot)) //nếu đã tạo thì chỉ ẩn hiện
            {
                plAIChatbot.Visible = !plAIChatbot.Visible;
                return;
            }
            plAIChatbot = new Panel()
            {
                Width = 800,
                Height = 600,
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
                Font = fontS.timeNew26_Bold,

                Location = new Point((plAIChatbot.Width - 200) / 2, 5)
            };
            RichTextBox rtxtChatHistory = new RichTextBox()
            {
                Width = 760,
                Height = 550,

                ReadOnly = true,
                HideSelection = true,
                ForeColor = Color.Green,
                Font = fontS.timeNew12_Regular,

                Location = new Point((plAIChatbot.Width - 760) / 2, 60),
            };
            TextBox txtRequest = new TextBox()
            {
                Width = rtxtChatHistory.Width - 60,
                Height = 80,

                MinimumSize = new Size(0, 80),
                Margin = new Padding(5),
                Font = fontS.timeNew12_Regular,

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
                Font = fontS.timeNew12_Regular,

                Location = new Point(txtRequest.Width + 20, rtxtChatHistory.Height + 70)
            };
            Button btnChatHistory = new Button()
            {
                Width = 100,
                Height = 30,
                Text = "Lịch sử chat",

                FlatStyle = FlatStyle.Flat,
                Font = fontS.timeNew12_Regular,

                Location = new Point(rtxtChatHistory.Width - 100, 10)
            };

            plAIChatbot.Controls.Add(btnSendRequest);
            plAIChatbot.Controls.Add(txtRequest);
            plAIChatbot.Controls.Add(rtxtChatHistory);
            plAIChatbot.Controls.Add(lblTitle);
            plAIChatbot.Controls.Add(btnChatHistory);
            this.Controls.Add(plAIChatbot);
            plAIChatbot.BringToFront();
            this.AcceptButton = btnSendRequest;


            btnSendRequest.Click += async (sender, e) =>
            {

                //async là hàm bất đồng bộ tránh việc Not Responding khi AI trả lời
                string requestMessage = txtRequest.Text;  //Gửi đi câu hỏi
                AIRepo.SaveNewMessage("User", txtRequest.Text);

                if (string.IsNullOrEmpty(requestMessage)) return; //nếu Request rỗng

                rtxtChatHistory.AppendText($"User: {requestMessage}\n\n");
                txtRequest.Clear();
                try
                {
                    //model.GenerateContent(requestMessage); //Gửi câu hỏi cho AI chờ phản hồi
                    var respond = await chatSession.SendMessage(requestMessage); //Dùng ChatSession để AI nhớ được ngữ cảnh
                    
                    if (respond == null || respond.Text == null)
                    {
                        MessageBox.Show("Lỗi");
                        return;
                    }//nếu null sẽ báo lỗi

                    AIRepo.SaveNewMessage("AI", respond.Text); //Lưu cầu trả lời của AI

                    rtxtChatHistory.AppendText($"Trợ lý ParaD: {respond.Text}\n\n"); //Thêm câu trả lời
                }
                catch (GeminiApiException ex)
                {
                    MessageBox.Show("Lỗi kết nối AI Chatbot \n" + ex.Message);
                    return;
                }
            }; //Request - Respond

            btnChatHistory.Click += (s, e) =>
            {
                string sqlAIChatbotHistory = "SELECT Ten, NoiDung FROM AIChatbotHistory";
                dt = new DataTable();
                dt = kn.CreateTable(sqlAIChatbotHistory);

                rtxtChatHistory.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    rtxtChatHistory.AppendText($"\n{row["Ten"].ToString()}: {row["NoiDung"].ToString()}\n");
                }
                btnChatHistory.Enabled = false;
            };
        }
        #endregion
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Session.FreeUpMemoryPanel(plControls);
            frmSetting setting = new frmSetting();

            setting.TopLevel = false;
            setting.FormBorderStyle = FormBorderStyle.None;
            setting.Location = new Point((plControls.Width-setting.Width)/2);

            plControls.Visible = true;
            plControls.Controls.Add(setting);

            setting.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            DateTime currDatetime = DateTime.Now;
            lblClock.Text = currDatetime.ToString("HH:mm");


            if (!Session.InspectStorage()) MNStorage.BackColor = Color.Red;

            if(lblClock.ForeColor == Color.FromArgb(17, 75, 95)) lblClock.ForeColor = Color.FromArgb(2, 128, 144);
            else lblClock.ForeColor = Color.FromArgb(17, 75, 95);

            //Cụm câu lệnh giải phóng tài nguyên
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            plControls.Visible = false;
        }

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
