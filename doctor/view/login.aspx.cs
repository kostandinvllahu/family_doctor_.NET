using doctor.database;
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
            
            Session.Contents.RemoveAll();
            DemoTest();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["accessToken"] != null) //shiko ketu te besh kodin invisible
            {
                if (txtpassword.Text.Equals(Request.Cookies["accessToken"].Value))
                {
                    var fb_username = txtusername.Text.Trim();
                    var fb_password = txtpassword.Text.Trim();

                    var fb_obj = new Users
                    {
                        username = fb_username
                    };
                    string sql = "SELECT * from login where username=@username COLLATE SQL_Latin1_general_CP1_CS_AS";
                    var fb_user = Query.Login(fb_obj, sql);
                    if(fb_user != null)
                    {
                        Session["username"] = txtusername.Text;
                        Session["password"] = txtpassword.Text;
                        Session["doctorId"] = fb_user.doctor;
                        Response.Redirect("main.aspx");
                    }
                    else
                    {
                        lblError.Text = "Wrong username/password";
                        return;
                    }
                }
            }
            lblError.Text = "";
            var username = txtusername.Text.Trim();
            var password = txtpassword.Text.Trim();

            var obj = new Users
            {
                username = username,
                password = password

            };

            if (ckbDoc.Checked == false)
            {
                string sqlQuery = "SELECT * from login where username=@username COLLATE SQL_Latin1_general_CP1_CS_AS and password=@password COLLATE SQL_Latin1_general_CP1_CS_AS";
                var user = Query.Login(obj,sqlQuery);
                if (user != null)
                {
                    Session["username"] = txtusername.Text;
                    Session["password"] = txtpassword.Text;
                    Session["doctorId"] = user.doctor;
                    Response.Redirect("main.aspx");
                }
                else
                {
                    lblError.Text = "Wrong username/password";
                    return;
                }
            }
            else
            {
                var doc = new Doctor()
                {
                    username = username,
                    password = password
                };
                var doctor = Query.LoginDoc(doc);
                if(doctor != null)
                {
                    Session["username"] = txtusername.Text;
                    Session["password"] = txtpassword.Text;
                    Session["doctorEmail"] = doc.email;
                    Response.Redirect("doctor.aspx");
                }
                else
                {
                    lblError.Text = "Wrong username/password";
                    return;
                }
            }
        }

        protected void ckbDoc_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void DemoTest()
        {
            DemoTest test = new DemoTest();
            Response.Write(test.username + " " + test.password);
        }
    }
}