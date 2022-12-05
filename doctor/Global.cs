using System;
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
            SqlCommand cmd = new SqlCommand
            {
                Connection = con,
                CommandText = sql
            };
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

        public static void Check_Appointments(string doctorEmail, string date) 
        {
            string sql = "update time set status='1' where doctor='" + doctorEmail + "'";
            var con = Script.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            con.Close();
            con.Open();
            sql = "update time set status = '0' where doctor = '"+ doctorEmail + "' and time IN(select time from appointments where date = '"+ date + "' and doctoremail = '"+ doctorEmail + "' and status='1')";
             cmd = new SqlCommand(sql, con);
             rdr = cmd.ExecuteReader();
        }
    }
}