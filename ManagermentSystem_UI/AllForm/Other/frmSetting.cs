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
using DataAccessLayer;
using System.Numerics;
using SuperProjectQ.Frm_Main_Login_Register;

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

        Session.FontStandard fontS = new Session.FontStandard();
        Button btn = null; //Biến lưu trữ button đã được click trước đó

        bool thongSoChanged = false; //Biến cờ để theo dõi xem có thay đổi thông số nào hay không
        bool generalChanged = false; //Biến cờ để theo dõi xem có thay đổi bên tab General ko

        bool boolThemDM = false;
        bool boolSuaDM = false;
        bool boolXoaDM = false;

        bool boolThemLP = false;
        bool boolSuaLP = false;
        bool boolXoaLP = false;

        bool CitiesChanged = false; //Biến cờ để theo dõi xem có thay đổi thành phố nào hay không

        List<int> idChanged = new List<int>(); //List id của txt thay đổi

        private void cmbDanhMuc_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable("SELECT * FROM DanhMuc");
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDM";
            cmbDanhMuc.ValueMember = "MaDM";
        }
        private void cmbCities_Load()
        {
            dt = new DataTable();
            dt = kn.CreateTable("SELECT * FROM ThanhPho");
            cmbCities.DataSource = dt;
            cmbCities.DisplayMember = "TenTP";
            cmbCities.ValueMember = "MaTP";
        }
        private void ThongSo_Load()
        {
            Session.SetParameters_Load();

            //Gán id vào textbox tương ứng
            foreach (var key in Session.dictThongSo.Keys)
            {
                if (key == 1) txtVAT.Tag = key;
                else if (key == 2) txtLaiSuat.Tag = key;
                else if (key == 3) txtGiaSau22H.Tag = key;
                else if (key == 4) txtSLTKTT.Tag = key;
                else if (key == 5) txtAmountPerPointVIP.Tag = key;
                else if (key == 8) txtEmail.Tag = key;
                else if (key == 9) txtOTPSendback.Tag = key;
                else if (key == 10) txtOTPDuration.Tag = key;
                else if (key == 11) txtAppPasswd.Tag = key;
                else if (key == 12) cmbCities.Tag = key;
            }

            txtVAT.Text = Session.dictThongSo[1].ToString();
            txtLaiSuat.Text = Session.dictThongSo[2].ToString();
            txtGiaSau22H.Text = Session.dictThongSo[3].ToString();
            txtSLTKTT.Text = Session.dictThongSo[4].ToString();
            txtAmountPerPointVIP.Text = Session.dictThongSo[5].ToString();
            txtOTPDuration.Text = Session.dictThongSo[10].ToString();
            txtOTPSendback.Text = Session.dictThongSo[9].ToString();

            txtEmail.Text = Session.dictThongSo[8].ToString();
            txtAppPasswd.Text = Session.dictThongSo[11].ToString();
            cmbCities.SelectedValue = Session.dictThongSo[12].ToString();
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
                    Font = fontS.timeNew12_Bold,

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
                    Font = fontS.timeNew12_Bold,
                    

                    Location = new Point(tenVIP.Width, (plChiTietVIP.Height - 20) / 2)
                };
                Label trietKhau = new Label()
                {
                    Width = plChiTietVIP.Width / 2 + 40,
                    Height = 20,
                    Enabled = false,

                    Text = "| Giảm: " +  row["TrietKhau"].ToString() + "% tổng HĐ",
                    Font = fontS.timeNew12_Bold,


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

                    txtVIP.Text = plChiTietVIP.Controls[0].Text;
                    txtMinimumPoint.Text = plChiTietVIP.Controls[1].Text;
                    txtTrietKhau.Text = plChiTietVIP.Controls[2].Text.Replace("| Giảm: ", "").Replace("% tổng HĐ", "");


                    plTieuChuan = plClicked;
                };

                plBangVIP.Controls.Add(plChiTietVIP);

            }
        } //Load bangr VIPs 
        private void frmSetting_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            cmbDanhMuc_Load();
            cmbCities_Load();

            //#region //Thiết lập giao diện ban đầu

            //btnGeneral.BackColor = Color.Aqua;
            //plControls.Controls.Clear();
            //plControls.Controls.Add(S);

            //#endregion

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
                plControls.Controls.Add(S);
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
            if (!double.TryParse(txt.Text, out double value) || value >100 && !(txt.Name == txtAmountPerPointVIP.Name) && txt.Name != txtOTPSendback.Name && txt.Name != txtOTPDuration.Name)
            {
                if (txt == txtEmail || txt == txtAppPasswd) 
                { 
                    thongSoChanged = true;
                    idChanged.Add(Convert.ToInt16(txt.Tag));
                    return; 
                }
                txt.Text = "0"; 
            }

            if(txt.Parent.Parent == plThongSo)
            {
                thongSoChanged = true;
                idChanged.Add(Convert.ToInt16(txt.Tag));
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
                    foreach (int i in idChanged)
                    {
                        var value = "";
                        if (i == 1) value = txtVAT.Text;
                        else if (i == 2) value = txtLaiSuat.Text;
                        else if (i == 3) value = txtGiaSau22H.Text;
                        else if (i == 4) value = txtSLTKTT.Text;
                        else if (i == 5) value = txtAmountPerPointVIP.Text;
                        else if (i == 8) value = txtEmail.Text;
                        else if (i == 9) value = txtOTPSendback.Text;
                        else if (i == 10) value = txtOTPDuration.Text;
                        else if (i == 11) value = txtAppPasswd.Text;
                        else if (i == 12)
                        {
                            value = cmbCities.SelectedValue.ToString();
                            CitiesChanged = true;
                        }
                        cmd = new SqlCommand($"UPDATE ThongSo SET GiaTri = @GT WHERE STT = {i}", kn.conn);
                        cmd.Parameters.AddWithValue("@GT", value);
                        cmd.ExecuteNonQuery();
                    }
                    ThongSo_Load();

                    if(CitiesChanged)
                    {
                        MessageBox.Show("Thành phố đã được thay đổi, vui lòng khởi động lại phần mềm để áp dụng thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CitiesChanged = false;
                    }
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
                        generalChanged = false;
                    }
                    else if(boolSuaDM)
                    {
                        cmd = new SqlCommand("UPDATE DanhMuc SET TenDM = @TenDM WHERE MaDM = @MaDM", kn.conn);
                        cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text);
                        cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text);
                        cmd.ExecuteNonQuery();
                        boolSuaDM = false;
                        generalChanged = false;
                    }
                    else if(boolXoaDM)
                    {
                        cmd = new SqlCommand("DELETE DanhMuc WHERE MaDM = @MaDM", kn.conn);
                        cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text);
                        cmd.ExecuteNonQuery();
                        boolXoaDM = false;
                        generalChanged = false;
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
            boolXoaDM = false;
            string MaDM = Session.AutoCreateID_String("MaDM", "DanhMuc", "MDM");
            txtMaDM.Text = MaDM;
            txtTenDM.Text = "";

            generalChanged = true;

        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            boolSuaDM = true;
            boolThemDM = false;
            boolXoaDM = false;

            txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
            txtTenDM.Text = cmbDanhMuc.Text.ToString();

            txtMaDM.Enabled = false;
            generalChanged = true;
        }
        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            boolSuaDM = false;
            boolThemDM = false;
            boolXoaDM = true;

            txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
            txtTenDM.Text = cmbDanhMuc.Text.ToString();
            generalChanged = true;
        }
        #endregion

        #region nút thêm và sửa của loại phòng
        //private void btnThemLP_Click(object sender, EventArgs e)
        //{
        //    boolThemLP = true;
        //    boolSuaLP = false;
        //    boolXoaLP = false;
        //    string MaLP = Session.AutoCreateID_String("MaLoaiPhong", "LoaiPhong", "");
        //    txtMaLoaiPhong.Text = MaLP;
        //    txtTenLoaiPhong.Text = "";

        //    generalChanged = true;

        //}

        //private void btnSuaDM_Click(object sender, EventArgs e)
        //{
        //    boolSuaDM = true;
        //    boolThemDM = false;
        //    boolXoaDM = false;

        //    txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
        //    txtTenDM.Text = cmbDanhMuc.Text.ToString();

        //    txtMaDM.Enabled = false;
        //    generalChanged = true;
        //}
        //private void btnXoaDM_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        //    boolSuaDM = false;
        //    boolThemDM = false;
        //    boolXoaDM = true;

        //    txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
        //    txtTenDM.Text = cmbDanhMuc.Text.ToString();
        //    generalChanged = true;
        //}
        #endregion

        #region Nút thêm, sửa, xoá bảng VIP
        private void Add_And_Edit_Delete_VIP(object sender, EventArgs e)
        {
            try
            {
                Button btnClicked = (Button)sender;

                switch (btnClicked.Name)
                {
                    case "btnAddVIP":
                        if (string.IsNullOrEmpty(txtVIP.Text) || string.IsNullOrEmpty(txtMinimumPoint.Text) || string.IsNullOrEmpty(txtTrietKhau.Text))
                        {
                            MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                            return;
                        }
                        if (MessageBox.Show("Bạn có chắc chắn muốn thêm VIP này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        cmd = new SqlCommand("INSERT INTO BangVIP (VIP, DiemToiThieu, TrietKhau) VALUES (@VIP, @DiemToiThieu, @TrietKhau)", kn.conn);
                        cmd.Parameters.AddWithValue("@VIP", txtVIP.Text);
                        cmd.Parameters.AddWithValue("@DiemToiThieu", int.Parse(txtMinimumPoint.Text));

                        cmd.Parameters.AddWithValue("@TrietKhau", double.Parse(txtTrietKhau.Text));
                        cmd.ExecuteNonQuery();

                        BangVIP_Load();

                        MessageBox.Show("Đã thêm VIP");
                        break;
                    case "btnEditVIP":
                        if (string.IsNullOrEmpty(txtVIP.Text) || string.IsNullOrEmpty(txtMinimumPoint.Text) || string.IsNullOrEmpty(txtTrietKhau.Text))
                        {
                            MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                            return;
                        }
                        if (MessageBox.Show("Bạn có chắc chắn muốn sửa VIP này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                        cmd = new SqlCommand("UPDATE BangVIP SET DiemToiThieu = @DiemToiThieu, TrietKhau = @TrietKhau WHERE VIP = @VIP", kn.conn);
                        cmd.Parameters.AddWithValue("@VIP", txtVIP.Text);
                        cmd.Parameters.AddWithValue("@DiemToiThieu", int.Parse(txtMinimumPoint.Text));
                        cmd.Parameters.AddWithValue("@TrietKhau", double.Parse(txtTrietKhau.Text));
                        cmd.ExecuteNonQuery();

                        BangVIP_Load();

                        MessageBox.Show("Đã sửa VIP");

                        break;
                    case "btnDeleteVIP":
                        if (string.IsNullOrEmpty(txtVIP.Text))
                        {
                            MessageBox.Show("Vui lòng chọn VIP cần xóa!");
                            return;
                        }

                        if (MessageBox.Show("Bạn có chắc chắn xoá VIP này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                        cmd = new SqlCommand("DELETE FROM BangVIP WHERE VIP = @VIP", kn.conn);
                        cmd.Parameters.AddWithValue("@VIP", txtVIP.Text);
                        cmd.ExecuteNonQuery();

                        BangVIP_Load();

                        MessageBox.Show("Đã xoá VIP");

                        break;
                    default:
                        break;
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2628:
                        MessageBox.Show("Lỗi: Tên VIP quá độ dài cho phép (VIP0 - 99)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Lỗi thao tác với VIP:\n" + ex.Number + " - " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return;
            }
        } //Nút thêm, sửa, xoá bảng VIP

        private void TxtBangVIP_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt == txtTrietKhau)
            {
                if (!double.TryParse(txt.Text, out double value) || value < 0 || value > 100)
                {
                    txt.Text = "0";
                }
            }
            else if (txt == txtMinimumPoint)
            {
                if (!int.TryParse(txt.Text, out int value) || value < 0)
                {
                    txt.Text = "0";
                }
            }
            txt.SelectionStart = txt.Text.Length;
        } //Giới hạn nhập liệu cho textbox của bảng VIP
        #endregion

        private void cmbDanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDanhMuc.SelectedValue == null) return;
            txtMaDM.Text = cmbDanhMuc.SelectedValue.ToString();
            txtTenDM.Text = cmbDanhMuc.Text.ToString();
        } // Thay đổi hiển thị textbox khi chọn danh mục trong cmb

        private void cmbCities_SelectedValueChanged(object sender, EventArgs e)
        {
            thongSoChanged = true;
            idChanged.Add(Convert.ToInt16(cmbCities.Tag));
        }
    }
}
