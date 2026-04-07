using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace SuperProjectQ.AllForm.KhoHang
{
    public partial class frmXacNhan : Form
    {
        public frmXacNhan()
        {
            InitializeComponent();
        }
        private void frmXacNhan_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtConfirm.Text.Trim() == Session.Passwd)
            {
                Session.isDeleted = true;
                this.Close();   
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
