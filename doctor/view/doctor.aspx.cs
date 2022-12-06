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
    public partial class doctor : System.Web.UI.Page
    {
        string temporary = "";
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

        private void GetValues()
        {
            var obj = new Doctor
            {
                username = Session["username"].ToString(),
                password = Session["password"].ToString()
            };

            var doctor = Query.LoginDoc(obj);
            if (doctor != null)
            {
                txtFullName.Text = doctor.fullname;
                txtIdCard.Text = doctor.idcard;
                txtEmail.Text = doctor.email;
                txtPassword.Text = doctor.password;
                txtAddress.Text = doctor.address;
                txtAddress2.Text = doctor.addresstwo;
                txtPhone.Text = doctor.phone;
                txtCity.Text = doctor.city;
                txtState.Text = doctor.state;
                txtZip.Text = doctor.zipcode;
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

            var obj = new database.Doctor
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


            string sql = "UPDATE doctor set fullname=@fullname, email=@email, password=@password, idcard=@idcard, address=@address, addresstwo=@addresstwo, phone=@phone, city=@city, state=@state, zipcode=@zipcode where username=@username";
            if (Query.Update(obj, sql))
            {
                lblError.Text = "Data updated successfully!";
                GetValues();
            }
            else
            {
                lblError.Text = "Data failed to update please try again";
            }
            string formatDate = Global.Format_Date("select CONVERT(char(10), '" + DateTime.Today.ToString() + "',103) as date");
            sql = "UPDATE appointments set doctorname=@fullname, doctoremail=@email where doctorusername='" + Session["username"].ToString() + "' and date >= '" + formatDate + "'";
            if(Query.Update(obj, sql))
            {
                lblError.Text = "Data updated successfully!";
                GetValues();
            }
            else
            {
                lblError.Text = "Data failed to update please try again";
            }
            sql = "update time set doctor=@email where doctorusername='" + Session["username"].ToString() + "'";
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

        protected void txtIdCard_TextChanged(object sender, EventArgs e)
        {

        }
    }
}