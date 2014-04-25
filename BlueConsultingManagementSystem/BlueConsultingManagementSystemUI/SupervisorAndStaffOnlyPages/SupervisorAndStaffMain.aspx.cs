using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class SupervisorAndStaffMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Staff"))
            {
                ApprovedReportsButton.Visible = true;
                RejectedResultsButton.Visible = false;
                ReportsButton.Visible = false;
            }
        }

        protected void ReportsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUnapprovedReports.aspx");
        }      

        protected void ExpenseResultsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewExpenseTotal.aspx");
        }

        protected void RejectedResultsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorOnlyPages/SupervisorViewRejectedReports.aspx");
        }

        protected void ApprovedReportsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffOnlyPages/StaffViewReports.aspx");
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }


    }
}