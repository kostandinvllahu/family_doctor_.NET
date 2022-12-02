﻿using Dapper;
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

        public static Doctor FetchDoctor(Doctor id)
        {
            string sqlQuery = "SELECT * from doctor where (Id=@id) "; 
            using (var con = Script.GetConnection())
            {
                return con.Query<Doctor>(sqlQuery, id).FirstOrDefault();
            }
        } 

        public static time GetTimeFormat(Object date) 
        {
            string sql = "SELECT [dbo].[ufn_GetDateOnly] (@date)";
            using (var con = Script.GetConnection())
            {
                return con.Query<time>(sql, date).FirstOrDefault();
            }
        }

        public static appointment Check_Future_Appointments(appointment book)
        {
           string sql = "select * from appointments where date=@Date and time=@Time";
            using (var con = Script.GetConnection())
            {
                return con.Query<appointment>(sql, book).FirstOrDefault(); 
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