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
using System.Xml;

namespace SuperProjectQ.AllForm.Voucher
{
    public partial class frmRandomVoucher : Form
    {
        public frmRandomVoucher()
        {
            InitializeComponent();
        }
        ConnectData kn = new ConnectData();
        SqlCommand cmd;
        DataTable dt;

        int quantityCustomers, currQuantity;
        int expDate = 30;
        bool isChangedQuantily = false;
        private void CmbVoucher_Load()
        {
            cmbVoucher.DataSource = kn.CreateTable("SELECT MaVoucher, TenVoucher FROM Voucher WHERE MaVoucher <> 'VCH01'");
            cmbVoucher.DisplayMember = "TenVoucher";
            cmbVoucher.ValueMember = "MaVoucher";
        }//Load DS voucher
        private void QuantityCustomers_Load()
        {
            using (cmd = new SqlCommand())
            {
                cmd.Connection = kn.conn;
                cmd.CommandText = $"SELECT COUNT(*) FROM KhachHang WHERE MaKH NOT IN (SELECT MaKH FROM VoucherKhachHang WHERE MaVoucher = '{cmbVoucher.SelectedValue}') AND MaKH <> 'KH000'"; 
                int count = (int)cmd.ExecuteScalar();
                quantityCustomers = count;
                lblQuantity.Text = count.ToString();
                lblCurrCustomers.Text = $"Số lượng khách hàng khả dụng: {quantityCustomers}";
            }
        }//Lấy số lượng khách hàng chưa nhận voucher chỉ định
        private DataTable ListCustomer()
        {
            return kn.CreateTable($"SELECT MaKH FROM KhachHang WHERE MaKH NOT IN (SELECT MaKH FROM VoucherKhachHang WHERE MaVoucher = '{cmbVoucher.SelectedValue}') AND MaKH <> 'KH000'");
        }//Danh sách khách hàng chưa nhận voucher chỉ định
        private void frmRandomVoucher_Load(object sender, EventArgs e)
        {
            kn.ConnOpen();
            CmbVoucher_Load();
            QuantityCustomers_Load();
            currQuantity = quantityCustomers;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (currQuantity >= quantityCustomers) return;
            lblQuantity.Text = (currQuantity + 1).ToString();
            currQuantity = Convert.ToInt32(lblQuantity.Text);
            isChangedQuantily = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (currQuantity <= 1) return;
            lblQuantity.Text = (currQuantity - 1).ToString();
            currQuantity = Convert.ToInt32(lblQuantity.Text);
            isChangedQuantily = true;
        }

        private void cmbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuantityCustomers_Load();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!isChangedQuantily)
            {
                currQuantity = quantityCustomers;
                isChangedQuantily = false;
            }//Nếu không thay đổi sl mặc định sl = max KH

            StringBuilder strBuilder = new StringBuilder();

            if (quantityCustomers == 0) return;
            while (true)
            {
                Random randInt = new Random();
                int i = randInt.Next(0, currQuantity);

                QuantityCustomers_Load(); //Cập nhật lại số lượng khách hàng khả dụng sau mỗi lần phát voucher

                if (currQuantity > quantityCustomers) currQuantity = quantityCustomers;

                DataTable dt = ListCustomer();
                
                string maKH = i==0 ? dt.Rows[i]["MaKH"].ToString() : dt.Rows[i-1]["MaKH"].ToString();
                
                try
                {
                    if(!Session.VoucherData.InspectQuantityVoucher(cmbVoucher.SelectedValue.ToString())) return;
                    using (cmd = new SqlCommand())
                    {
                        int stt = Session.AutoCreateID_Interger("STT", "VoucherKhachHang");
                        cmd.Connection = kn.conn;
                        cmd.CommandText = $"INSERT INTO VoucherKhachHang (STT, MaKH, MaVoucher, NgayNhan, NgayHetHan, TrangThai) " +
                            $"VALUES (@STT, @MKH, @MVC, GETDATE(), @NHH, 0)";
                        cmd.Parameters.AddWithValue("@STT", stt);
                        cmd.Parameters.AddWithValue("@MKH", maKH);
                        cmd.Parameters.AddWithValue("@MVC", cmbVoucher.SelectedValue);
                        cmd.Parameters.AddWithValue("@NHH", DateTime.Now.AddDays(expDate));
                        cmd.ExecuteNonQuery();
                        currQuantity--;
                        strBuilder.AppendLine($"Đã phát voucher {cmbVoucher.Text} cho khách hàng {maKH}");

                    }
                    if(currQuantity < 1)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmRandomVoucher - btnPlay_Click Lỗi: " + ex.Message);
                }
            }
            MessageBox.Show(strBuilder.ToString(), "Thông báo");
            QuantityCustomers_Load(); //Cập nhật kh
            currQuantity = quantityCustomers;
        }
    }
}
