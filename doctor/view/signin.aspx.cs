using doctor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtPassword.Text.Length < 8)
            {
                lblError.Text = "Your password must be at least 8 characters long";
                return;
            }

            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();
            var fullname = txtFullName.Text.Trim();

            var users = new database.Users
            {
                fullname = fullname,
                email = email,
                password = password,
                username = username
            };

            if (Query.Insert(users))
            {
                lblError.Text = "Account created successfully!";
            }
            else
            {
                lblError.Text = "Opss.. Something went wrong!";
            }
            
        }
    }
}