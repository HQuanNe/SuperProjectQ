using SuperProjectQ.AllForm;
using SuperProjectQ.AllForm.Combo;
using SuperProjectQ.AllForm.HoaDon;
using SuperProjectQ.AllForm.KhoHang;
using SuperProjectQ.AllForm.NhapKho;
using SuperProjectQ.AllForm.Other;
using SuperProjectQ.AllForm.Users;
using SuperProjectQ.Frm_Main_Login_Register;
using SuperProjectQ.FrmMixed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProjectQ
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainUI());
        }
    }
}
