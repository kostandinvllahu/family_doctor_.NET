using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doctor.database
{
    public class Query
    {
        public static Users Login(Users obj)
        {
            string sqlQuery = "SELECT  username,password from login where (username=@username) and (password=@password)";

            using (var con = Script.GetConnection())
            {
                return con.Query <Users>(sqlQuery, obj).FirstOrDefault();
            }
        }

        public static bool Insert(Users user)
        {
            string sql = "INSERT INTO login (fullname, email, username, password) VALUES (@fullname, @email, @username, @password)";

            using (var con = Script.GetConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }

    }

}