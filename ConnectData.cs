using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SuperProjectQ
{
    internal class ConnectData
    {
        string strconn = "Data Source=HQUAN\\SQLEXPRESS;Initial Catalog=QLKaraok;Integrated Security=True;";
        public SqlConnection conn = null;
        public SqlDataAdapter adapter = null;
        DataTable dt = null;

        public void ConnOpen()
        {
            if(conn == null) conn = new SqlConnection(strconn);
            if(conn.State != ConnectionState.Open) conn.Open();
        }
        public void ConnClose()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }
        public DataTable CreateTable(string sql)
        {
            adapter = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
