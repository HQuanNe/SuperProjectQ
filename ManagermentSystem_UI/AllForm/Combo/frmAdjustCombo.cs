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
using DataAccessLayer;

namespace SuperProjectQ.AllForm.Combo
{
    public partial class frmAdjustCombo : Form
    {
        public frmAdjustCombo()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        class Button_Plus_And_Minus
        {
            public Button btn = null;

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
        private void ChiTietCombo_Load()
        {
            string sqlCTCB = "";
        }
        private void frmAdjustCombo_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
        }
    }
}
