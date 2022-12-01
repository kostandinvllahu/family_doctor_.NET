using doctor.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class checkup : System.Web.UI.Page
    {
        String sql = "";
        Boolean check = false;
        int num = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            GetValues();
            Global.bindDropdown(selectTime, "select * from time where status='1'", "time", "time");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var appointment = new database.appointment()
            {
                Doctorname = txtDoctorName.Text.Trim(),
                Doctoremail = txtEmail.Text.Trim(),
                Patientname = Session["username"].ToString(),
                Service = selectService.SelectedItem.Value,
                Comment = txtComment.Text.Trim(),
                Time = selectTime.SelectedItem.Value,
                Date = txtDate.SelectedDate.ToShortDateString()
        };
            CheckTime(Convert.ToDateTime(selectTime.SelectedItem.Value), Convert.ToDateTime(txtDate.SelectedDate.ToShortDateString()), txtDate.SelectedDate.DayOfWeek.ToString());
            if (check)
            {
                sql = "INSERT INTO appointments (doctorname, doctoremail, patientname, service, comment, time, date) VALUES" +
                    " (@Doctorname, @Doctoremail, @Patientname, @Service, @Comment, @Time, @Date)";
                if (Query.Insert(appointment, sql))
                {
                    lblError.Text = "Appointment booked successfully!";
                    sql = "update time set status=0 where time=@Time";
                    Query.Update(appointment, sql);
                    return; //beje refresh faqen ketu
                }
                else
                {
                    lblError.Text = "Opss.. Something went wrong!";
                    return;
                }
            }
        }

        private void GetValues()
        {
            var doctor = Query.FetchDoctor();
            if (doctor != null)
            {
                txtDoctorName.Text = doctor.fullname;
                txtEmail.Text = doctor.email;
                txtDoctorName.ReadOnly = true;
                txtEmail.ReadOnly = true;

            }
        }

        private void CheckTime(DateTime selectedTime, DateTime selectDay, String weekname)
         {
            if (weekname.Equals("Sunday"))
            {
                lblError.Text = "Today is Sunday we are closed please choose another day of the week!";
                check = false;
            }
            else
            {
                if (selectDay < DateTime.Today)
                {
                    lblError.Text = "This date has passed please choose different time!";
                    check = false;
                }

                if (selectDay == DateTime.Today)
                {
                    if (Convert.ToDateTime(System.DateTime.Now.ToString("HH:mm")) > selectedTime)
                    {
                        lblError.Text = "This time has passed please choose different time!";
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    check = true;
                }
            } 
        }

   
    }
}