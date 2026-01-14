using SuperProjectQ.FrmMixed;
using SuperProjectQ.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.Frm_Main_Login_Register
{
    public partial class frmMainUI : Form
    {
        public frmMainUI()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        string mainIDUser = Session.IDUser, mainTenNV = Session.TenNV, mainChucVu = Session.ChucVu;
        Image lightImg = Properties.Resources.bgMainUI;
        Image darkImg = Properties.Resources.DarkModebgMainUI;
        private void ckcDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcDarkMode.Checked)
            {
                var textColor = Color.WhiteSmoke;
                this.BackgroundImage = darkImg;
                ckcDarkMode.Text = "Light Mode";
                ckcDarkMode.ForeColor = textColor;
                plInfo.BackColor = Color.Gray;
                lblTitleChucVu.ForeColor = textColor;
                lblTitleXinChao.ForeColor = textColor;
                lblTitleQH.ForeColor = textColor;
                lblTenNV.ForeColor = textColor;
                lblChucVu.ForeColor = textColor;
                lblQuyenHan.ForeColor = textColor;
                ckcDarkMode.BackColor = Color.Gray;
                btnBack.BackColor = Color.Gray;
                MNMain.BackColor = Color.Gray;
                MNMain.ForeColor = textColor;
                btnBack.ForeColor = textColor;

            }
            else 
            {
                var textColor = Color.Black;
                this.BackgroundImage = lightImg;
                ckcDarkMode.Text = "Dark Mode";
                ckcDarkMode.ForeColor = textColor;
                plInfo.BackColor = Color.FromArgb(255, 224, 192);
                lblTitleChucVu.ForeColor = textColor;
                lblTitleXinChao.ForeColor = textColor;
                lblTitleQH.ForeColor = textColor;
                lblTenNV.ForeColor = textColor;
                lblChucVu.ForeColor = textColor;
                lblQuyenHan.ForeColor = textColor;
                ckcDarkMode.BackColor = Color.FromArgb(255, 224, 192);
                btnBack.BackColor = Color.FromArgb(255, 192, 192);
                MNMain.BackColor = Color.WhiteSmoke;
                MNMain.ForeColor = textColor;
                btnBack.ForeColor = textColor;

            }
        }
        private void MN_NhanVien_DSNV_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            this.Visible = false;
            frmNhanVien.ShowDialog();
        }

        private void MNQuanLy_Phong_Click(object sender, EventArgs e)
        {
            frmPhong frmPhong = new frmPhong();
            frmPhong.Visible = true;
            this.Visible = false;
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
            lblChucVu.Text = mainChucVu;
            lblQuyenHan.Text = TenQH();
        }
    }
}
