using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantViewReportHistory : System.Web.UI.Page
    {
        string reportName;
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportType = (string)Session["reportType"];

            if (Session["reportName"] == null)
                Session["reportName"] = reportName;
            
            if (reportType == "AllSubmitted")
                loadSubmittedReports();
            else if (reportType == "AllApproved")
                loadApprovedReports();
            else if (reportType == "InProgress")
                loadInProgressReports();            
        }

        public void loadSubmittedReports()
        {
            ConsultantHistorySQLConnection.DataSource = new DatabaseHandler().ConsultantLoadSubmittedReports(User.Identity.Name);
            ConsultantHistorySQLConnection.DataBind();
        }

        public void loadApprovedReports()
        {
            ConsultantHistorySQLConnection.DataSource = new DatabaseHandler().ConsultantLoadApprovedReports(User.Identity.Name);
            ConsultantHistorySQLConnection.DataBind();
        }

        public void loadInProgressReports()
        {
            ConsultantHistorySQLConnection.DataSource = new DatabaseHandler().ConsultantLoadInProgressReports(User.Identity.Name);
            ConsultantHistorySQLConnection.DataBind();
        }

        protected void ConsultantHistorySQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ConsultantHistorySQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("ConsultantViewReportHistoryExpenses.aspx");
            //fix that hardcode
        }

    }
}