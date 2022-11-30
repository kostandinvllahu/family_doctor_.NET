﻿using doctor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            var username = txtusername.Text.Trim();
            var password = txtpassword.Text.Trim();

            var obj = new Users
            {
                username = username,
                password = password
            };

            var user = Query.Login(obj);
            if(user != null)
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                lblError.Text = "Wrong username/password";
            }
        }

    }
}