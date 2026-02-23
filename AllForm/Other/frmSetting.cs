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

        SqlCommand cmd = null;

        Button btn = null; //Biến lưu trữ button đã được click trước đó

        bool thongSoChanged = false; //Biến cờ để theo dõi xem có thay đổi thông số nào hay không

        private void ThongSo_Load()
        {
            Session.SetParameters_Load();

            txtVAT.Text = Session.VAT.ToString();
            txtLaiSuat.Text = Session.laiSuat.ToString();
            txtGiaSau22H.Text = Session.PriceAfter_22H.ToString();

            thongSoChanged = false;
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

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
            }

            btn = btnClicked;
            ThongSo_Load();
        }

        private void AllTextBox_TextChanged(object sender, EventArgs e)
         {
            TextBox txt = (TextBox)sender;
            if (!double.TryParse(txt.Text, out double value) || value >100)
            {
                txt.Text = "0"; 
            }

            if(txt.Parent.Parent == plThongSo) thongSoChanged = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (thongSoChanged)
            {
                MessageBox.Show("Lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (thongSoChanged)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        cmd = new SqlCommand($"UPDATE ThongSo SET GiaTri = @GT WHERE STT = {i}", kn.conn);
                        cmd.Parameters.AddWithValue("@GT", i == 1 ? double.Parse(txtVAT.Text) : i == 2 ? double.Parse(txtLaiSuat.Text) : double.Parse(txtGiaSau22H.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
