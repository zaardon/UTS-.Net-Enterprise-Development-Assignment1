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
    public partial class SupervisorUnapprovedResults : System.Web.UI.Page
    {

        //THIS CLASS NEEDS TO BE NAMED
        //THIS CLASS NEEDS TO BE NAMED
        //THIS CLASS NEEDS TO BE NAMED
        //THIS CLASS NEEDS TO BE NAMED
        public string reportName;
        public string userGroupMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reportName"] == null)
            {

                Session["reportName"] = reportName;
            }

            if (User.IsInRole("Department Supervisor"))
            {
                if (User.IsInRole("Higher Education Services"))
                    userGroupMember = "HigherEducation";
                else if (User.IsInRole("Logistic Services"))
                    userGroupMember = "LogisticServices";
                else
                    userGroupMember = "StateServices";

                loadDepartmentSupervisorData();
            }
        }

        protected void loadDepartmentSupervisorData()
        {
                UnapprovedReportsGridViewSQLConnection.DataSource = new DatabaseHandler().LoadDepartmentSupervisorData(userGroupMember);
                UnapprovedReportsGridViewSQLConnection.DataBind();
        }



        protected void UnapprovedReportsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = UnapprovedReportsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("SupervisorReportsDisplayPage.aspx");
            //fix that hardcode
        }

    }
}