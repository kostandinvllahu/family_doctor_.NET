using doctor.database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class signin : System.Web.UI.Page
    {
        String sql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.bindDropdown(selectdoctor, "select * from doctor", "fullname", "Id");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtPassword.Text.Length <= 8)
            {
                lblError.Text = "Your password must be more then 8 characters long";
                return;
            }
         
            if (!txtPassword.Text.Any(char.IsUpper))
            { 
            lblError.Text = "Your password must contain one upper case character";
            return;
            }


            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var doctor = selectdoctor.SelectedItem.Value;

            var users = new database.Users
            {
                fullname = fullname,
                email = email,
                password = password,
                username = username,
                doctor = doctor
            };
            sql = "SELECT  * from login where (username=@username)";
            var user = Query.VerifyEmail(users, sql);

            if (user != null)
            {
                lblError.Text = "Username is already in use, please choose another one";
                return;
            }

            sql = "SELECT  * from login where (email=@email)";
            user = Query.VerifyEmail(users, sql);
            if (user != null)
            {
                lblError.Text = "Email is already registered login?";
                return;
            }

            sql = "INSERT INTO login (fullname, email, username, password, doctor) VALUES (@fullname, @email, @username, @password, @doctor)";
            if (Query.Insert(users, sql))
            {
                lblError.Text = "Account created successfully!";
            }
            else
            {
                lblError.Text = "Opss.. Something went wrong!";
                return;
            }
        }

        protected void btnGoogle_Click(object sender, EventArgs e)
        {
            //nothing yet
        }
     }
}