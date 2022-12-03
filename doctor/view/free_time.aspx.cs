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
                GetAppointments("select * from appointments where patientname='" + Session["username"].ToString() + "'");
            }
            EnableTime();
        }

        private void GetAppointments(string sql)
        {
            Global.FillGrid(gvList, sql);
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

        protected void selectFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                GetAppointments("select * from appointments where concat(Id, service, comment, time, date) Like '%" + txtSearch.Text + "%'");
            }
            else
            {
                formatDate = Global.Format_Date("select CONVERT(char(10), '" + DateTime.Today.ToString() + "',103) as date");
                switch (selectFilter.SelectedValue.ToString())
                {
                    case "1":
                        GetAppointments("select * from appointments where patientname='" + Session["username"].ToString() + "'");
                        break;
                    case "2":
                        GetAppointments("select * from appointments where patientname='" + Session["username"].ToString() + "' and date > '" + formatDate + "'");
                        break;
                    case "3":
                        GetAppointments("select * from appointments where patientname='" + Session["username"].ToString() + "' and date <'" + formatDate + "'");
                        break;
                    case "4":
                        GetAppointments("select * from appointments where patientname='" + Session["username"].ToString() + "' and date = '" + formatDate + "'");
                        break;
                }
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=Appointments"+formatDate+".xls";
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
        }
    }
}