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
namespace SuperProjectQ.FrmMixed
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd = null;
        DataTable dt = null;
        SqlDataAdapter adapter = null;
        bool flag; //Biến cờ
        private void Load_DB()
        {
            string sqlKH = "SELECT * FROM KhachHang";
            dgvKhachHang.DataSource = kn.CreateTable(sqlKH);
        }
        private void Button_Control(bool flag) //Ẩn hiện nút
        {
            if (flag)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnGhi.Visible = true;
                btnKoGhi.Visible = true;
            }
            else
            {
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
                btnGhi.Visible = false;
                btnKoGhi.Visible = false;
            }
        }
        private string AutoCreateID()
        {
            string sqlGetMaxID = "SELECT TOP 1 MaKH FROM KhachHang ORDER BY MaKH DESC";
            dt = new DataTable();
            dt = kn.CreateTable(sqlGetMaxID);
            string id = dt.Rows[0]["MaKH"].ToString(); //Lấy mã lớn nhất
            string target = "KH";  
            id = id.Replace(target, ""); //Xoá phần chữ để lấy phần số
            int tangMa = Convert.ToInt16(id) + 1; //Tăng mã lên 1

            string newID = null;
            //Định dạng lại mã nếu <10 thì thêm 2 số 0, <100 thì thêm 1 số 0
            if (tangMa < 10)
                newID = target + "00" + tangMa.ToString();
            else if (tangMa < 100)
                newID = target + "0" + tangMa.ToString();
            else
                newID = target + tangMa.ToString();
            return newID;
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically; //Chống xoá dữ liệu
            dgvKhachHang.AutoGenerateColumns = false;
            plInfo.Enabled = false;

            kn.ConnOpen();
            Load_DB();
            Button_Control(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radTenKH.Checked)
            {
                string sqlSearch = $"SELECT * FROM KhachHang WHERE TenKH LIKE N'%{txtSearch.Text}%'";
                dgvKhachHang.DataSource = kn.CreateTable(sqlSearch);
            }
            else if (radSDT.Checked)
            {
                string sqlSearch = $"SELECT * FROM KhachHang WHERE SoDienThoai LIKE N'%{txtSearch.Text}%'";
                dgvKhachHang.DataSource = kn.CreateTable(sqlSearch);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Clear();
            }
        }//Tìm kiếm theo options

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtSDT.Text = row.Cells[3].Value.ToString();
                txtVIP.Text = row.Cells[4].Value.ToString();
                txtDTL.Text = row.Cells[5].Value.ToString();
                txtDiscount.Text = (Convert.ToDouble(row.Cells[6].Value) * 100).ToString() + "%";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không, không thể khôi phục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sqlDelete = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                    cmd = new SqlCommand(sqlDelete, kn.conn);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    cmd.ExecuteNonQuery();
                    Load_DB();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = true;
            plInfo.Enabled = true;
            Button_Control(true);

            //Những mục cần nhập khi thêm mới
            txtMaKH.Text = AutoCreateID();
            txtDiscount.Text = "0";
            txtDTL.Text = "0";
            txtVIP.Text = "VIP0";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            plInfo.Enabled = true;
            Button_Control(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

        }

        private void btnKoGhi_Click(object sender, EventArgs e)
        {
            Button_Control(false);
        }
    }
}
