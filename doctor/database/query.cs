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
        
        public static Users VerifyEmail(Users obj)
        {
            string sqlQuery = "SELECT  * from login where (email=@email)";
            using (var con = Script.GetConnection())
            {
                return con.Query<Users>(sqlQuery, obj).FirstOrDefault();
            }
        }

        public static Users VerifyUsername(Users obj)
        {
            string sqlQuery = "SELECT  * from login where (username=@username)";
            using (var con = Script.GetConnection())
            {
                return con.Query<Users>(sqlQuery, obj).FirstOrDefault();
            }
        }

        public static bool Insert(Users user)
        {
            string sql = "INSERT INTO login (fullname, email, username, password, doctor) VALUES (@fullname, @email, @username, @password, @doctor)";

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

        public static bool Update(Users user)
        {
            string sql = "UPDATE login set fullname=@fullname, email=@email, password=@password, idcard=@idcard, address=@address, addresstwo=@addresstwo, phone=@phone, city=@city, state=@state, zipcode=@zipcode where username=@username";
            using (var con = Script.GetConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }

    }

}