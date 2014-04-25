using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class ViewUnapprovedReports : System.Web.UI.Page
    {
        private string reportName;
        private string userGroupMember;
        private int REP_POS = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reportName"] == null)
            {
                Session["reportName"] = reportName;
            }

            if (User.IsInRole("Department Supervisor"))
            {
                if (User.IsInRole("Higher Education Services"))
                    userGroupMember = "Higher Education";
                else if (User.IsInRole("Logistic Services"))
                    userGroupMember = "Logistic Services";
                else
                    userGroupMember = "State Services";

                LoadDepartmentSupervisorData();
            }
        }

        protected void LoadDepartmentSupervisorData()
        {
            UnapprovedReportsGridViewSQLConnection.DataSource = new DatabaseHandler().ReturnSubmittedReportsForDepartmentSupervisor(userGroupMember);
            UnapprovedReportsGridViewSQLConnection.DataBind();
        }

        protected void UnapprovedReportsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = UnapprovedReportsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[REP_POS].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("ViewReports.aspx");
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }
    }
}