using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ.AllForm.Other
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }
        private void LoginHistory_Load()
        {
            StringBuilder strB = new StringBuilder();
            string[] loginHistory = File.ReadAllLines($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\login.txt");

            foreach (string line in loginHistory)
            {
                strB.AppendLine(line);
            }
            rtxtLoginHistory.Text = strB.ToString();
        }
        private void PaymentHistory_Load()
        {
            StringBuilder strB = new StringBuilder();
            string[] paymentHistory = File.ReadAllLines($"D:\\Học_Tập\\Programing_language\\ADO-NET\\DataLog\\payment.txt");

            foreach (string line in paymentHistory)
            {
                strB.AppendLine(line);
            }
            rtxtPaymentHistory.Text = strB.ToString();
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            LoginHistory_Load();
            PaymentHistory_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
