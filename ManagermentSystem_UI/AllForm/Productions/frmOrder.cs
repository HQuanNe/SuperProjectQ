using DataAccessLayer;
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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        ConnectData kn = new ConnectData();
        Session.FontStandard fontS = new Session.FontStandard();
        DataTable dt = null;
        SqlCommand cmd = null;

        bool isAdded = false;
        string RoomID, maSP;
        double soLuongOrder;
        private void Ordered_Load()
        {
            try
            {
                dgvOrder.DataSource = kn.CreateTable("SELECT Ord.STT, Phong.TenPhong, COALESCE(SanPham.TenMatHang, Combo.TenCombo) AS TenSP, " +
                    "Ord.SoLuong, Ord.OrderAt " +
                    "FROM Orders AS Ord " +
                    "LEFT JOIN Phong ON Phong.MaPhong = Ord.MaPhong " +
                    "LEFT JOIN SanPham ON SanPham.MaSP_Menu = Ord.MaSP " +
                    "LEFT JOIN Combo ON Combo.MaCombo = Ord.MaSP");
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmOrder - Ordered_Load Lỗi:\n" +ex.Message);
            }
        }
        private void RemoveOrder(int STT)
        {
            try
            {
                cmd = new SqlCommand($"DELETE FROM Orders WHERE STT = {STT}", kn.conn);
                cmd.ExecuteNonQuery();
                Ordered_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmOrder  - RemoveOrder Lỗi:\n" + ex.Message);
            }
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            Session.StandardDataGridView(dgvOrder);
            dgvOrder.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            Ordered_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrder.Columns[e.ColumnIndex].Name == "Confirm")
            {
                if (MessageBox.Show("Xác nhận Order?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                try
                {
                    using (dt = new DataTable())
                    {
                        dt = kn.CreateTable($"SELECT * FROM Orders WHERE STT = {dgvOrder.Rows[e.RowIndex].Cells["STT"].Value}");
                        if(dt.Rows.Count > 0)
                        {
                            RoomID = dt.Rows[0]["MaPhong"].ToString();
                            maSP = dt.Rows[0]["MaSP"].ToString();
                            soLuongOrder = Convert.ToDouble(dt.Rows[0]["SoLuong"]);
                        }
                    }
                    string sqlSanPham = $"SELECT SanPham.TenMatHang, KhoHang.DonViTinh, SanPham.GiaBan, SanPham.DinhLuong " +
                        $"FROM SanPham " +
                        $"INNER JOIN KhoHang ON KhoHang.MaSP_Kho = SanPham.MaSP_Kho " +
                        $"WHERE SanPham.MaSP_Menu = '{maSP}'";

                    if (!(maSP.Contains("SPM"))) //Nếu là combo set = true
                    {
                        sqlSanPham = $"SELECT Combo.TenCombo, Combo.DonViTinh, Combo.DonGia " +
                        $"FROM Combo " +
                        $"WHERE Combo.MaCombo = '{maSP}'";
                        Session.ComboData.isCombo = true;
                    }

                    dt = new DataTable();
                    dt = kn.CreateTable(sqlSanPham);
                    #region Lấy mã HĐ
                    cmd = new SqlCommand($"SELECT HoaDon.MaHD FROM HoaDon " +
                                        $"INNER JOIN Phong ON Phong.MaPhong = HoaDon.MaPhong " +
                                        $"WHERE HoaDon.MaPhong = '{RoomID}' AND Phong.TrangThai = 1 AND HoaDon.TrangThai = 0", kn.conn);
                    int intMaHD = Convert.ToInt32(cmd.ExecuteScalar());
                    #endregion

                    string tenSP = dt.Rows[0][0].ToString();

                    string donViTinh = dt.Rows[0][1].ToString();
                    int donGia = Convert.ToInt32(dt.Rows[0][2].ToString());

                    double dinhLuong = !Session.ComboData.isCombo ? Convert.ToDouble(dt.Rows[0][3].ToString()) : 0;

                    if (donViTinh == "Kg") donViTinh = "Đĩa";

                    bool flag = true;

                    //Lấy danh sách sản phẩm đã order trong phòng
                    DataTable dt2 = new DataTable();
                    dt2 = kn.CreateTable($"SELECT MaSP FROM ChiTietHD WHERE MaHD = '{intMaHD}'");

                    //kiểm tra xem sản phẩm có trong bảng đã order chưa
                    foreach (DataRow row in dt2.Rows)
                    {
                        if (dt2.Rows.Count > 0 && row["MaSP"].ToString() != null && row["MaSP"].ToString() == maSP)
                        {
                            flag = false;
                            break;
                        }
                    }
                    //Nếu chaưa có thì thêm mới
                    if (flag)
                    {
                        string sqlAdd = "INSERT INTO ChiTietHD (MaCTHD, MaHD, MaSP, LoaiHang, SoLuong, DonViTinh, DonGia, ThanhTien) " +
                            "VALUES (@MCTHD, @MHD, @MSP, @LH, @SL, @DV, @DG, @TT)";
                        cmd = new SqlCommand(sqlAdd, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MCTHD", Session.AutoCreateID_Interger("MaCTHD", "ChiTietHD"));
                        cmd.Parameters.AddWithValue("@MHD", intMaHD);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("LH", Session.ComboData.isCombo);
                        cmd.Parameters.AddWithValue("@SL", soLuongOrder);
                        cmd.Parameters.AddWithValue("@DV", donViTinh);
                        cmd.Parameters.AddWithValue("@DG", donGia);
                        cmd.Parameters.AddWithValue("@TT", soLuongOrder * donGia);
                        cmd.ExecuteNonQuery();

                        isAdded = true;
                    }
                    //Nếu có rồi thì cập nhật số lượng lên 1
                    if (!flag)
                    {
                        cmd = new SqlCommand($"SELECT SoLuong FROM ChiTietHD WHERE MaSP = '{maSP}' AND MaHD = {intMaHD} ", kn.conn);

                        double soLuongDaCo = soLuongOrder + Convert.ToDouble(cmd.ExecuteScalar());
                        decimal thanhTien = Convert.ToDecimal(soLuongDaCo * donGia);

                        string sqlUpdate = "UPDATE ChiTietHD SET SoLuong = @SL, ThanhTien = @TT WHERE MaHD = @MHD AND MaSP = @MSP";
                        cmd = new SqlCommand(sqlUpdate, kn.conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MHD", intMaHD);
                        cmd.Parameters.AddWithValue("@MSP", maSP);
                        cmd.Parameters.AddWithValue("@SL", soLuongDaCo);
                        cmd.Parameters.AddWithValue("@TT", thanhTien);
                        cmd.ExecuteNonQuery();

                        isAdded = true;
                    }
                    if (isAdded)
                    {
                        Console.WriteLine(soLuongOrder.ToString());
                        Session.CapNhatKho(false, maSP, soLuongOrder);
                        Session.ComboData.isCombo = false;
                        RemoveOrder((int)dgvOrder.Rows[e.RowIndex].Cells["STT"].Value);
                        MessageBox.Show("Đã thêm");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmOrder - dgvOrder_CellClick Lỗi:\n" + ex.Message);
                    return;
                }
            }
        }
    }
}
