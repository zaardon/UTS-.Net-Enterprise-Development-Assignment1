using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class SupervisorExpenseResultsPage : System.Web.UI.Page
    {

        public String ReportNameValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            //SQL command using the session data of ReportName as the WHERE function of the statement

            //ReportNameValue = SessionObjectValue
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            //update command for statusreport (with ReportNameValue)
        }

        protected void Deny_Click(object sender, EventArgs e)
        {
            //update command for statusreport
        }
    }
}