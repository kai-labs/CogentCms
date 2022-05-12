using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Sql
{
    public class SqlConnectionFactory
    {
        private readonly string connString;

        public SqlConnectionFactory(string connString)
        {
            this.connString = connString;
        }

        public SqlConnection Open()
        {
            var conn = new SqlConnection(connString);
            conn.Open();

            return conn;
        }
    }
}
