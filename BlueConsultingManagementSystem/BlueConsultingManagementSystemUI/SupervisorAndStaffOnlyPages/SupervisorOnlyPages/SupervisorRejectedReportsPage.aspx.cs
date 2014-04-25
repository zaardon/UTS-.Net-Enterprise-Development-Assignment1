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
    public partial class SupervisorRejectedReportsPage : System.Web.UI.Page
    {

        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        string reportName;
        string userGroupMember;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["reportName"] == null)
            {
                Session["reportName"] = reportName;
            }

            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "HigherEducation";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "Logistic";
            else
                userGroupMember = "StateServices";
            loadResults();
        }

        public void loadResults()
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
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Session["deptName"] = userGroupMember;
            Response.Redirect("SupervisorViewRejectedReportInfo.aspx");
            //fix that hardcode
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }
    }
}