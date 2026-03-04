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

namespace SuperProjectQ.AllForm.Other
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        DataTable dt = null;
        SqlCommand cmd = null;

        Button btn = null; //Biến lưu trữ button đã được click trước đó

        bool thongSoChanged = false; //Biến cờ để theo dõi xem có thay đổi thông số nào hay không
        bool generalChanged = false; //Biến cờ để theo dõi xem có thay đổi bên tab General ko

        bool boolThemDM = false;
        bool boolSuaDM = false;

        private void cmbDanhMuc_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable("SELECT * FROM DanhMuc");
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDM";
            cmbDanhMuc.ValueMember = "MaDM";
        }
        private void ThongSo_Load()
        {
            Session.SetParameters_Load();

            txtVAT.Text = Session.VAT.ToString();
            txtLaiSuat.Text = Session.laiSuat.ToString();
            txtGiaSau22H.Text = Session.PriceAfter_22H.ToString();
            txtSLTKTT.Text = Session.MinTonKho.ToString();
            txtAmountPerPointVIP.Text = Session.amountPerPointVIP.ToString();

            thongSoChanged = false;
        } //Load thông số của tab thông số
        private void BangVIP_Load()
        {
            plBangVIP.Controls.Clear();

            dt = new DataTable();
            dt = kn.CreateTable("SELECT * FROM BangVIP");

            if (dt == null || dt.Rows.Count == 0) return;

            Panel plTieuChuan = new Panel() { Width = 0, Height = 0 };
            foreach (DataRow row in dt.Rows)
            {
                Panel plChiTietVIP = new Panel()
                {
                    Width = plBangVIP.Width - 10,
                    Height = 40,

                    BorderStyle = BorderStyle.FixedSingle,
                    //BackColor = Color.Red,

                    Location = new Point((plBangVIP.Width - (plBangVIP.Width-10))/2, plTieuChuan.Location.Y + plTieuChuan.Height + 5),
                };
                Label tenVIP = new Label()
                {
                    Width = 45, Height = 20,

                    Text = row["VIP"].ToString(),
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),

                    Enabled = false,
                    Location = new Point(0, (plChiTietVIP.Height - 20)/2)
                };
                Label diemToiThieu = new Label()
                {
                    Width = 50,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleCenter,

                    Enabled = false,
                    Text = row["DiemToiThieu"].ToString(),
                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                    

                    Location = new Point(tenVIP.Width, (plChiTietVIP.Height - 20) / 2)
                };
                Label trietKhau = new Label()
                {
                    Width = plChiTietVIP.Width / 2 + 40,
                    Height = 20,
                    Enabled = false,

                    Text = "| Giảm: " +  row["TrietKhau"].ToString() + "% tổng HĐ",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),


                    Location = new Point(tenVIP.Width + diemToiThieu.Width, (plChiTietVIP.Height - 20) / 2)
                };
                plTieuChuan = plChiTietVIP;


                plChiTietVIP.Controls.Add(tenVIP);
                plChiTietVIP.Controls.Add(diemToiThieu);
                plChiTietVIP.Controls.Add(trietKhau);


                plChiTietVIP.Click += (s, e) =>
                {
                    Panel plClicked = s as Panel;
                    if(plTieuChuan != plClicked) plTieuChuan.BorderStyle = BorderStyle.FixedSingle;
                    
                    plClicked.BorderStyle = BorderStyle.Fixed3D;
                    plTieuChuan = plClicked;
                };

                plBangVIP.Controls.Add(plChiTietVIP);

            }
        } //Load bangr VIPs 
        private void frmSetting_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            cmbDanhMuc_Load();

            #region //Thiết lập giao diện ban đầu

            btnGeneral.BackColor = Color.Aqua;
            plControls.Controls.Clear();
            plControls.Controls.Add(plGeneral);

            #endregion

        }

        private void Allbtn_Click(object sender, EventArgs e)
        {
            btnGeneral.BackColor = Color.FromArgb(192, 255, 255);

            if (btn != null) btn.BackColor = Color.FromArgb(192, 255, 255);

            Button btnClicked = (Button)sender;
            btnClicked.BackColor = Color.Aqua;

            if (btnClicked.Name == btnGeneral.Name)
            {
                plControls.Controls.Clear();
                plControls.Controls.Add(plGeneral);
            }
            else if (btnClicked.Name == btnThongSo.Name)
            {
                plControls.Controls.Clear();
                plControls.Controls.Add(plThongSo);
                ThongSo_Load();
            }
            else if (btnClicked.Name == btnVIP.Name)
            {
                plControls.Controls.Clear();
                plControls.Controls.Add(plVIP);
                BangVIP_Load();
            }

            btn = btnClicked;
        } //Chuyển tab khi ấn nút chỉ định

        private void AllTextBoxThongSo_TextChanged(object sender, EventArgs e)
         {
            TextBox txt = (TextBox)sender;
            if (!double.TryParse(txt.Text, out double value) || value >100 && !(txt.Name == txtAmountPerPointVIP.Name))
            {
                txt.Text = "0"; 
            }

            if(txt.Parent.Parent == plThongSo) thongSoChanged = true;
        }
        private void TxtDanhMuc_Changed(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if(txt.Parent.Parent.Parent ==  plGeneral)
            {
                generalChanged = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (thongSoChanged || generalChanged)
            {
                MessageBox.Show("Lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                dt =new DataTable();
                dt = kn.CreateTable("SELECT STT FROM ThongSo");

                if (dt.Rows.Count < 1) return;

                if (thongSoChanged)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        cmd = new SqlCommand($"UPDATE ThongSo SET GiaTri = @GT WHERE STT = {i}", kn.conn);
                        cmd.Parameters.AddWithValue("@GT",
                        i == 1 ? double.Parse(txtVAT.Text) : i == 2 ? double.Parse(txtLaiSuat.Text) : i == 3 ? double.Parse(txtGiaSau22H.Text) : 
                        i == 4 ? double.Parse(txtSLTKTT.Text) : double.Parse(txtAmountPerPointVIP.Text));
                    cmd.ExecuteNonQuery();
                    }
                    ThongSo_Load();
                }
                if (generalChanged)
                {
                    if(boolThemDM)
                    {
                        cmd = new SqlCommand("INSERT INTO DanhMuc (MaDM, TenDM) VALUES (@MaDM, @TenDM)", kn.conn);
                        cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text);
                        cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text);
                        cmd.ExecuteNonQuery();
                        boolThemDM = false;
                    }
                    else if(boolSuaDM)
                    {
                        cmd = new SqlCommand("UPDATE DanhMuc SET TenDM = @TenDM WHERE MaDM = @MaDM", kn.conn);
                        cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text);
                        cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text);
                        cmd.ExecuteNonQuery();
                        boolSuaDM = false;
                    }
                    cmbDanhMuc_Load();
                }
            }
        }
        #region nút thêm và sửa của danh mục
        private void btnThemDM_Click(object sender, EventArgs e)
        {
            boolThemDM = true;
            boolSuaDM = false;
            string MaDM = Session.AutoCreateID_String("MaDM", "DanhMuc", "MDM");
            txtMaDM.Text = MaDM;
            txtTenDM.Text = "";

        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            boolSuaDM = true;
            boolThemDM = false;

            txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
            txtTenDM.Text = cmbDanhMuc.Text.ToString();

            txtMaDM.Enabled = false;
        }
        #endregion

        private void cmbDanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDanhMuc.SelectedValue == null) return;
            txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
            txtTenDM.Text = cmbDanhMuc.Text.ToString();
        }

    }
}
