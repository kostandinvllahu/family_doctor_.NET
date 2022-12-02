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
    }
}