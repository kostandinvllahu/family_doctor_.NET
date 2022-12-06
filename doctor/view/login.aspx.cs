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

            if (ckbDoc.Checked == false)
            {
                var user = Query.Login(obj);
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
    }
}