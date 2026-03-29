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

namespace SuperProjectQ.AllForm.Productions
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        private void ListProducts_Load()
        {
            string sqlProd = "SELECT * FROM SanPham ";

            dgvProducts.DataSource = kn.CreateTable(sqlProd);
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                kn.ConnOpen();

                Session.StandardDataGridView(dgvProducts);
                ListProducts_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmProduct - formLoad Lỗi:\n"+ex.Message);
                return;
            }
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "LoaiBan")
            {
                if(e.Value is bool loaiBan)
                {
                    e.Value = loaiBan ? "Bán theo định lượng" : "Bán nguyên chiếc";
                }
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Session.ProductData.MaSP_Menu = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();

            using (frmAdjustProducts adjProd = new frmAdjustProducts())
            {
                adjProd.FormBorderStyle = FormBorderStyle.None;
                adjProd.ShowDialog();

                ListProducts_Load();
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            using (frmAddProducts addProd = new frmAddProducts())
            {
                addProd.FormBorderStyle = FormBorderStyle.None;
                addProd.ShowDialog();

                ListProducts_Load();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            lblTitle.Location = new Point((panel1.Width - lblTitle.Width) / 2, lblTitle.Location.Y);
        }
    }
}
