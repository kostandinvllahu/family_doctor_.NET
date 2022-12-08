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
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    GetValues();
                }
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // lblError.Text = "";

            string pattern = @"^[A-Z]{1}[0-9]{8}[A-Z]{1}$";
            var maches = Regex.Match(txtIdCard.Text.ToString(), pattern, RegexOptions.IgnoreCase);
            if (!maches.Success)
            {
                lblError.Text = "ID Card must start with 1 capital letter, contain 8 digits and end with another 1 capital letter!";
                return;
            }

            lblError.Text = "";
            if (txtPassword.Text != ""  && txtPassword.Text.Length <= 8)
            {
                lblError.Text = "Your password must be more then 8 characters long";
                return;
            }

            if (txtPassword.Text != "" && !txtPassword.Text.Any(char.IsUpper))
            {
                lblError.Text = "Your password must contain one upper case character";
                return;
            }

            var obj = new database.Users
            {
                fullname = txtFullName.Text.Trim(),
                password = txtPassword.Text.ToString() == "" ? Session["password"].ToString() : txtPassword.Text.Trim(),
                email = txtEmail.Text.Trim(),
                username = Session["username"].ToString(),
                idcard = txtIdCard.Text.ToString(),
                address = txtAddress.Text.Trim(),
                addresstwo = txtAddress2.Text.Trim(),
                phone = txtPhone.Text.Trim(),
                city = txtCity.Text.Trim(),
                state = txtState.Text.Trim(),
                zipcode = txtZip.Text.Trim()
                };


            string sql = "UPDATE login set fullname=@fullname, email=@email, password=@password, idcard=@idcard, address=@address, addresstwo=@addresstwo, phone=@phone, city=@city, state=@state, zipcode=@zipcode where username=@username";
            if (Query.Update(obj, sql))
            {
                lblError.Text = "Data updated successfully!";
                GetValues();
            }
            else
            {
                lblError.Text = "Data failed to update please try again";

            }
        }


        private void GetValues()
        {
            var obj = new Users
            {
                username = Session["username"].ToString(),
                password = Session["password"].ToString()
            };
            string sql = "SELECT * from login where username=@username COLLATE SQL_Latin1_general_CP1_CS_AS";
            var user = Query.Login(obj, sql);
            if (user != null)
            {
                txtFullName.Text = user.fullname;
                txtIdCard.Text = user.idcard;
                txtEmail.Text = user.email;
                txtPassword.Text = user.password;
                txtAddress.Text = user.address;
                txtAddress2.Text = user.addresstwo;
                txtPhone.Text = user.phone;
                txtCity.Text = user.city;
                txtState.Text = user.state;
                txtZip.Text = user.zipcode;
            }
        }

        protected void txtIdCard_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}