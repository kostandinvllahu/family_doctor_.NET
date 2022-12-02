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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }
                var Id = new database.Doctor()
                {
                    Id = Convert.ToInt32(Session["doctorId"])
            };
                GetValues(Id);
                GetTime();
                //EnableTime();
            }
            EnableTime();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var appointment = new database.appointment()
            {
                Doctorname = txtDoctorName.Text.Trim(),
                Doctoremail = txtEmail.Text.Trim(),
                Patientname = Session["username"].ToString(),
                Service = selectService.SelectedItem.Text,
                Comment = txtComment.Text.Trim(),
                Time = selectTime.SelectedItem.Value,
                Date = txtDate.SelectedDate.ToShortDateString()
        };
            CheckTime(Convert.ToDateTime(selectTime.SelectedItem.Value), Convert.ToDateTime(txtDate.SelectedDate.ToShortDateString()), txtDate.SelectedDate.DayOfWeek.ToString());
            if (check)
            {
                sql = "INSERT INTO appointments (doctorname, doctoremail, patientname, service, comment, time, date, status) VALUES" +
                    " (@Doctorname, @Doctoremail, @Patientname, @Service, @Comment, @Time, @Date, 1)";
                if (Query.Insert(appointment, sql))
                {
                   
                    lblError.Text = "Appointment booked successfully!";
                    sql = "update time set status=0 where time=@Time and doctor='"+txtEmail.Text.Trim()+"'";
                    Query.Update(appointment, sql);
                    selectTime.Items.Clear();
                    GetTime();
                    EnableTime();
                    return; 
                }
                else
                {
                    lblError.Text = "Opss.. Something went wrong!";
                    selectTime.Items.Clear();
                    GetTime();
                    EnableTime();
                    return;
                }
            }
        }

        private void GetValues(Doctor Id)
        {
            
            var doctor = Query.FetchDoctor(Id);
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
            check = true;
            if (weekname.Equals("Sunday"))
            {
                lblError.Text = "Today is Sunday we are closed please choose another day of the week!";
                selectTime.Items.Clear();
                GetTime();
                EnableTime();
                check = false;

            }
            else
            {
                if (selectDay < DateTime.Today)
                {
                    lblError.Text = "This date has passed please choose different time!";
                    selectTime.Items.Clear();
                    GetTime();
                    EnableTime();
                    check = false;
                }

                if (selectDay == DateTime.Today)
                {
                    if (Convert.ToDateTime(System.DateTime.Now.ToString("HH:mm")) > selectedTime)
                    {
                        lblError.Text = "This time has passed please choose different time!";
                        selectTime.Items.Clear();
                        GetTime();
                        EnableTime();
                        check = false;
                    }
                }

                if(selectDay > DateTime.Today)
                {
                    Global.Format_Date("SELECT [dbo].[ufn_GetDateOnly] ('03/12/2022 00:00:00') as date");
                    //var appointments = new appointment()
                    //{
                    //    Date = txtDate.SelectedDate.ToString(),
                    //    Time = selectTime.SelectedItem.Value
                    //};

                    //var book = Query.Check_Future_Appointments(appointments);
                    //if (book != null)
                    //{
                    //    lblError.Text = "This time is already booked please choose another time";
                    //    selectTime.Items.Clear();
                    //    GetTime();
                    //    EnableTime();
                    //    check = false;
                    //}
                }
            } 
        }

        private void GetTime()
        {
            Global.bindDropdown(selectTime, "select * from time where status='1' and doctor='" + txtEmail.Text.Trim() +"'", "time", "time");
        } //ketu duhet me @email jo me tekst!

        private void EnableTime()
        {
            //01/12/2022 15:30:00
            if (Convert.ToDateTime(System.DateTime.Now.ToString("HH:mm")) >= Convert.ToDateTime("16:00:00"))
            {
                var obj = new database.time
                {
                    Status = "1",
                    Date = DateTime.Today.ToString()
                };

                 sql = "UPDATE time set status=@Status where status=0";
                Query.Update(obj, sql);
                sql = "UPDATE appointments set status=0 where date=@Date"; //same date problem here
                Query.Update(obj, sql);
            }

            if (Convert.ToDateTime(System.DateTime.Now.ToString("HH:mm")) <= Convert.ToDateTime("08:00:00"))
            {
                var obj = new database.time
                {
                    Status = "1",
                     Date = DateTime.Today.ToString()
                };
               
                sql = "UPDATE time set status=@Status where status=0";
                Query.Update(obj, sql);
                sql = "UPDATE appointments set status=0 where date=@Date"; //same date problem here
                Query.Update(obj, sql);
            }
        }

        protected void txtDate_SelectionChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtDate.SelectedDate.ToShortDateString()) > DateTime.Today)
            {
                selectTime.Items.Clear();
                Global.bindDropdown(selectTime, "select * from future_booking", "time", "time");
                EnableTime();
                check = false;
            }
            else
            {
                selectTime.Items.Clear();
                GetTime();
            }
        }

        private void time_format(Object date)
        {
            
        }
    }
}