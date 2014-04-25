using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantSelectReportName : System.Web.UI.Page
    {
        private string reportName;
        private int REP_POS = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            WelcomeMessage.Text = "Welcome " + User.Identity.Name + "!";
            LoadCurrentReports();
        }

        private void LoadCurrentReports()
        {
            CurrentReportNamesSQLConnection.DataSource = new DatabaseHandler().ReturnConsultantInProgressReports(User.Identity.Name);
            CurrentReportNamesSQLConnection.DataBind();
        }
    
        protected void CurrentReportNamesSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = CurrentReportNamesSQLConnection.Rows[index];
            reportName = selectedRow.Cells[REP_POS].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("ConsultantAddReport.aspx");
        }

        protected void NewReportButton_Click(object sender, EventArgs e)
        {
            Session["reportName"] = "";
            Response.Redirect("ConsultantAddReport.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultantMain.aspx");
        }
    }
}