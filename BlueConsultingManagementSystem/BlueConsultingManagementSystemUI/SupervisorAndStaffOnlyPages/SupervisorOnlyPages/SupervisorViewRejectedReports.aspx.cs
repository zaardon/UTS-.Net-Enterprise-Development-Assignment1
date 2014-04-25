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

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SuperVisorOnlyPages
{
    public partial class SupervisorViewRejectedReports : System.Web.UI.Page
    {
        private string reportName;
        private string userGroupMember;
        private int REP_POS = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "HigherEducation";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "Logistic";
            else
                userGroupMember = "StateServices";
            LoadResults();
        }

        private void LoadResults()
        {
            RejectedResultsGridViewSQLConnection.Visible = true;
            RejectedResultsGridViewSQLConnection.DataSource = new DatabaseHandler().ReturnRejectedReportNamesForSupervisor(userGroupMember, User.Identity.Name);
            RejectedResultsGridViewSQLConnection.DataBind();
        }

        protected void RejectedResultsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = RejectedResultsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[REP_POS].Text.ToString();
            Session["reportName"] = reportName;
            Session["deptName"] = userGroupMember;
            Response.Redirect("SupervisorViewRejectedReportInfo.aspx");
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }
    }
}