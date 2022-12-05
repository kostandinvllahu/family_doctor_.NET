using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace doctor.database
{
     class Script
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            var con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
            
        }
    }
}