using doctor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class appointments : System.Web.UI.Page
    {
        string formatDate = "";
        string sql = "";
        string doctorEmail = "";
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
                    Id = Convert.ToInt32(Session["doctorId"]),
                };
                GetValues(Id);
                //GetTime();
                EnableTime();
                //Ketu ka error!
                GetAppointments("select appointments.date, appointments.time from appointments left join future_bookingon on appointments.time = future_booking.time where appointments.doctoremail = '"+doctorEmail+"' and appointments.date = '05/12/2022' and appointments.status = 1");
            }
            //EnableTime();
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

        private void GetAppointments(string sql)
        {
            Global.FillGrid(gvList, sql);
        }

        private void GetValues(Doctor Id)
        {

            var doctor = Query.FetchDoctor(Id);
            if (doctor != null)
            {
                doctorEmail = doctor.email;
            }
        }
    }
}