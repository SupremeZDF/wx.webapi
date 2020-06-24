using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ORM.model
{
    public class BaseModelSql
    {
        public readonly static string SqlConin = "server=192.168.100.48;database=BtYinLong;uid=sa;pwd=Rl123456;";

        public SqlConnection GetSqlConnection() 
        {
            return new SqlConnection(SqlConin);
        }
    }
}
