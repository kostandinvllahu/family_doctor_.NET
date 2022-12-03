﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doctor.database;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace doctor
{
    public static class Global
    {
        
        public static void bindDropdown(DropDownList ddl, string sql, string fieldText, string fieldValue)
        {
            var con = Script.GetConnection();

            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddl.DataSource = dt;
            ddl.DataTextField = fieldText;
            ddl.DataValueField = fieldValue;
            ddl.DataBind();
        }

        public static void FillGrid(GridView dtg, string sql)
        {
            var con = Script.GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dtg.DataSource = dt;
            dtg.DataBind();
        }

        public static string Format_Date(string sql)
        {
            string format = "";
            var con = Script.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    format = rdr.GetString(0);
                }
            }
            return format;
        }
    }
}