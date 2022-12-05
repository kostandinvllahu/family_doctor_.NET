using doctor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class drugs : System.Web.UI.Page
    {
        string sql = "";
        Boolean check = false;
        string formatDate = "";

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
                formatDate = Global.Format_Date("select CONVERT(char(10), '" + DateTime.Today.ToString() + "',103) as date");
                Global.Check_Appointments(txtEmail.Text.Trim(), formatDate);
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
                    sql = "update time set status=0 where time=@Time and doctor='" + txtEmail.Text.Trim() + "'";
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

                if (selectDay > DateTime.Today)
                {
                    //string formatDate =  Global.Format_Date("SELECT [dbo].[ufn_GetDateOnly] ('"+ selectDay + "') as date");
                    formatDate = Global.Format_Date("select CONVERT(char(10), '" + selectDay + "',103) as date");
                    var appointments = new appointment()
                    {
                        Date = formatDate,
                        Time = selectTime.SelectedItem.Value,
                        Doctoremail = txtEmail.Text.Trim()
                    };
                    sql = "select * from appointments where date=@Date and time=@Time  and doctoremail=@Doctoremail";
                    var book = Query.Check_Future_Appointments(appointments, sql);
                    if (book != null)
                    {
                        lblError.Text = "This time is already booked please choose another time";
                        selectTime.Items.Clear();
                        GetTime();
                        EnableTime();
                        check = false;
                    }
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

        private void GetTime()
        {
            Global.bindDropdown(selectTime, "select * from time where status='1' and doctor='" + txtEmail.Text.Trim() + "'", "time", "time");
        }

        private void EnableTime()
        {
            if (Convert.ToDateTime(System.DateTime.Now.ToString("HH:mm")) >= Convert.ToDateTime("16:00:00"))
            {
                formatDate = Global.Format_Date("select CONVERT(char(10), '" + DateTime.Today.ToString() + "',103) as date");
                var obj = new database.time
                {
                    Status = "1",
                    Date = formatDate
                };

                sql = "UPDATE time set status=@Status where status=0";
                Query.Update(obj, sql);

                sql = "update appointments set status = '0' where date = @Date";
                Query.Update(obj, sql);
            }

            if (Convert.ToDateTime(System.DateTime.Now.ToString("HH:mm")) <= Convert.ToDateTime("08:00:00"))
            {
                formatDate = Global.Format_Date("select CONVERT(char(10), '" + DateTime.Today.ToString() + "',103) as date");
                var obj = new database.time
                {
                    Status = "1",
                    Date = formatDate
                };

                sql = "UPDATE time set status=@Status where status=0";
                Query.Update(obj, sql);
                sql = "UPDATE appointments set status='0' where date=@Date";
                Query.Update(obj, sql);
            }
        }

        protected void txtDate_SelectionChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtDate.SelectedDate.ToShortDateString()) > DateTime.Today)
            {
                selectTime.Items.Clear();
                formatDate = Global.Format_Date("select CONVERT(char(10), '" + txtDate.SelectedDate.ToShortDateString() + "',103) as date");
                Global.Check_Appointments(txtEmail.Text.Trim(), formatDate);
                GetTime();
                EnableTime();
                check = false;
            }
            else
            {
                selectTime.Items.Clear();
                GetTime();
            }
        }

    }
}