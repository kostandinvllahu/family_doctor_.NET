using doctor.database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                formatDate = Global.Format_Date("select CONVERT(char(10), '" + DateTime.Today.ToString() + "',103) as date");
                Global.Check_Appointments(doctorEmail, formatDate);
                Global.FillGrid(gvList, "select time, doctor from time where status='1' and doctor='"+doctorEmail+"'");
            }
             var id = new database.Doctor()
            {
                Id = Convert.ToInt32(Session["doctorId"]),
            };
            GetValues(id);
            EnableTime();
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
           
        }

        private void GetValues(Doctor Id)
        {

            var doctor = Query.FetchDoctor(Id);
            if (doctor != null)
            {
                doctorEmail = doctor.email;
            }
        }

        protected void txtDate_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Global.Check_Appointments(doctorEmail, txtDate.SelectedDate.ToShortDateString());
            Global.FillGrid(gvList, "select time, doctor from time where status='1' and doctor='" + doctorEmail + "'");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (gvList.Rows.Count == 0)
            {
                lblError.Text = "There are no values to be downloaded please try again.";
                return;
            }
            string attachment = "attachment; filename=DoctorFreeTime" + formatDate + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            // Create a form to contain the grid
            HtmlForm frm = new HtmlForm();
            gvList.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(gvList);
            frm.RenderControl(htw);
            //GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            lblError.Text = "Doctor free time downloaded successfully!";
        }
    }
}