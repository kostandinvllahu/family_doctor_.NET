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
            string sqlQuery = "SELECT * from login where (username=@username) and (password=@password)";

            using (var con = Script.GetConnection())
            {
                return con.Query <Users>(sqlQuery, obj).FirstOrDefault();
            }
        }
        
        public static Users VerifyEmail(Object obj, String sql)
        {
            using (var con = Script.GetConnection())
            {
                return con.Query<Users>(sql, obj).FirstOrDefault();
            }
        }

    
        public static bool Insert(Object user, String sql)
        {
            using (var con = Script.GetConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }

        public static Doctor FetchDoctor()
        {
            string sqlQuery = "SELECT * from doctor";
            using (var con = Script.GetConnection())
            {
                return con.Query<Doctor>(sqlQuery).FirstOrDefault();
            }
        } 

        public static bool Update(Object user, String sql)
        {
            using (var con = Script.GetConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }

    }

}