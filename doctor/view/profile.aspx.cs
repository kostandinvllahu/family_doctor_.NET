using doctor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                var obj = new Users
                {
                    username = Session["username"].ToString(),
                    password = Session["password"].ToString()
                };

                var user = Query.Login(obj);
                if (user != null)
                {
                    Session["zip"] = txtZip.Text.Trim(); //rruaj me session vlerat qe behen update dhe pastaj fshiji
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // lblError.Text = "";
           
                var fullname = txtFullName.Text.Trim();
                var password = txtPassword.Text.ToString() == "" ? Session["password"].ToString() : txtPassword.Text.Trim();
                var email = txtEmail.Text.Trim();
                var username = Session["username"].ToString();
                var idcard = txtIdCard.Text.Trim();
                var address = txtAddress.Text;
                var addresstwo = txtAddress2.Text.Trim();
                var phone = txtPhone.Text.Trim();
                var city = txtCity.Text.Trim();
                var state = txtState.Text.Trim();
                var zipcode = txtZip.Text.Trim();

            var obj = new database.Users
            {
                fullname = fullname,
                password = password,
                email = email,
                username = username,
                idcard = idcard,
                address = address,
                addresstwo = addresstwo,
                phone = phone,
                city = city,
                state = state,
                zipcode = Session["zip"].ToString()
                };



            if (Query.Update(obj))
            {
                lblError.Text = "Data updated successfully!";

            }
            else
            {
                lblError.Text = "Data failed to update please try again";

            }
        }
    }
}