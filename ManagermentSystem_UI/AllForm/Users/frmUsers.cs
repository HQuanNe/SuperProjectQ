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

namespace SuperProjectQ.AllForm.Users
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();

        private void User_Load()
        {
            dgvUser.DataSource = kn.CreateTable("SELECT us.IDUser, us.UserName, NhanVien.TenNV, QuyenHan.TenQH FROM Users AS us " +
                "LEFT JOIN NhanVien ON NhanVien.MaNV = us.MaNV " +
                "LEFT JOIN PhanQuyen ON PhanQuyen.IDUser = us.IDUser " +
                "LEFT JOIN QuyenHan ON QuyenHan.MaQH = PhanQuyen.MaQH");
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();

            Session.StandardDataGridView(dgvUser);
            User_Load();
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Session.StaffData.IDUser = dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString();

            using (frmAdjustUser adjUser = new frmAdjustUser())
            {
                adjUser.FormBorderStyle = FormBorderStyle.None;
                adjUser.ShowDialog();

                User_Load();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            using (frmAddUser addUser = new frmAddUser())
            {
                addUser.FormBorderStyle = FormBorderStyle.None;
                addUser.ShowDialog();

                User_Load();
            }
        }
    }
}
