using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;

namespace SuperProjectQ.Classes
{
    internal class AIChatbotRepository
    {
        ConnectData kn = new ConnectData();
        SqlCommand cmd = null;
        DataTable dt = null;

        public void SaveNewMessage(string ten, string noiDung)
        {
            kn.ConnOpen();

            cmd = new SqlCommand("INSERT INTO AIChatbotHistory VALUES (@Ten, @ND, GETDATE())", kn.conn);
            cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@STT", Session.AutoCreateID_Interger("STT", "AIChatbotHistory"));
            cmd.Parameters.AddWithValue("@Ten", ten);
            cmd.Parameters.AddWithValue("ND", noiDung);
            cmd.ExecuteNonQuery();
        } //Lưu hội thoại cũ
        public List<ContentResponse> GetHistory(int limit = 999)
        {
            kn.ConnOpen();
            var history = new List<ContentResponse>();
            dt = kn.CreateTable($"SELECT TOP {limit} Ten, NoiDung FROM AIChatbotHistory ORDER BY ThoiGian DESC");

            if (dt.Rows.Count < 1) return history;
            foreach(DataRow row in dt.Rows)
            {
                string name = row["Ten"].ToString();
                string content = row["NoiDung"].ToString();

                history.Insert(0, new ContentResponse(content, name == "user" ? Role.User : Role.Model));
            }

            return history;
        } //Lấy ra hội thoại cũ
        public string GetDataFromSQL()
        {
            kn.ConnOpen();
            StringBuilder sb = new StringBuilder();

            Dictionary<string, string> dictTable = new Dictionary<string, string>()
            {
                {"Dưới đây là danh sách loại phòng:", "SELECT * FROM LoaiPhong" },
                {"Dưới đây là danh sách nhân viên:", "SELECT * FROM NhanVien" },
                {"Dưới đây là danh sách khách hàng:", "SELECT * FROM KhachHang" },
                {"Dưới đây là danh sách sản phẩm:", "SELECT * FROM SanPham" },
                {"Dưới đây là danh sách kho hàng:", "SELECT * FROM KhoHang" },
            };

            foreach(string key in dictTable.Keys)
            {
                dt = new DataTable();
                dt = kn.CreateTable(dictTable[key]);

                if (dt.Rows.Count < 1) return null;
                sb.AppendLine(key);
                foreach(DataRow row in dt.Rows)
                {
                    if (dictTable[key].Contains("LoaiPhong"))
                    {
                        sb.AppendLine($"- Tên loại: {row["TenLoaiPhong"].ToString()} {Convert.ToDecimal(row["GiaTheoGio"])}đ/giờ");
                    }
                    //else if (dictTable[key].Contains("NhanVien"))
                    //{
                    //    sb.AppendLine($"- Tên loại: {row["TenLoaiPhong"].ToString()} {Convert.ToDecimal(row["GiaTheoGio"])}đ/giờ");
                    //}
                    else if (dictTable[key].Contains("KhachHang"))
                    {
                        sb.AppendLine($"- MãKH: {row["MaKH"].ToString()} " +
                            $"TênKH: {row["TenKH"].ToString()}" +
                            $"Địa chỉ: {row["DiaChi"].ToString()}" +
                            $"Số điện thoại: {row["SoDienThoai"].ToString()}" +
                            $"VIP: {row["VIP"].ToString()}" +
                            $"Điểm tích luỹ: {row["DiemTichLuy"].ToString()}" +
                            $"Triết khấu: {row["Discount"].ToString()}");
                    }
                    else if (dictTable[key].Contains("SanPham"))
                    {
                        sb.AppendLine($"- Mã SP: {row["MaSP_Menu"].ToString()} " +
                            $"Mã SP ở kho: {row["MaSP_Kho"].ToString()}" +
                            $"Tên: {row["TenMatHang"].ToString()}" +
                            $"Định lượng: {row["DinhLuong"].ToString()}" +
                            $"Đơn vị định lượng: {row["DVTDinhLuong"].ToString()}" +
                            $"Giá bán ra: {row["GiaBan"].ToString()}");

                    }
                }
            }
            return sb.ToString();
        }
    }
}
