using doctor.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace doctor.view
{
    public partial class free_time : System.Web.UI.Page
    {
        string sql = "";
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
                EnableTime();
                GetAppointments();
                //GetValues(Id);
                // GetTime();
            }
            EnableTime();
        }

        private void GetAppointments()
        {
            Global.FillGrid(gvList, "select * from appointments where patientname='"+ Session["username"].ToString() + "'");
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
    }
}