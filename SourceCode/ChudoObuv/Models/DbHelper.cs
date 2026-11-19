using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ChudoObuv.Models
{
    public static class DbHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["ChudoObuvDb"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}