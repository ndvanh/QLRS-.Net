using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DALTdotNet
{
    class ketnoi
    {
        private string con_str = "";
        private SqlConnection conn = null;
        public ketnoi()
        {
            con_str = @"Data Source=(local);Initial Catalog=QlyRauSach;User Id=sa;Password=123456";
            conn = new SqlConnection(con_str);
        }
        public DataSet getdata(string sql, string table_name)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, table_name);
            }
            catch
            {

            }
            return ds;
        }
        public bool excute(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
