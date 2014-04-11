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

        }

        protected void ReportsButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("SupervisorUnapprovedResults.aspx");
        }      

        protected void ExpenseResultsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorExpenseTotalPage.aspx");

        }

        protected void RejectedResultsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorRejectedReportsPage.aspx");
        }


    }
}