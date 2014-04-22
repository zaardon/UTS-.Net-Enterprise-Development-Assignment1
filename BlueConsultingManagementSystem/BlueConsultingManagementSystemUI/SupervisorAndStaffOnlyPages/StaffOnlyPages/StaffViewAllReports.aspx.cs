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
    public partial class StaffViewAllReports : System.Web.UI.Page
    {
        public string reportName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reportName"] == null)
            {

                Session["reportName"] = reportName;
            }
            loadStaffData();
        }

        public void loadStaffData()
        {

            DataSet results = new DatabaseHandler().LoadStaffUnapprovedReportNames();
            AllApprovedReportsGridViewSQLConnection.DataSource = results;
            AllApprovedReportsGridViewSQLConnection.DataBind();

            
            int temp = 0;
            string dept = "";
            string report = "";
            foreach (GridViewRow row in AllApprovedReportsGridViewSQLConnection.Rows)
            {
                dept = results.Tables[0].Rows[temp].ItemArray[3].ToString();
                report = (results.Tables[0].Rows[temp].ItemArray[0].ToString());
                //if (Convert.ToDouble(resultSet.Tables[0].Rows[temp].ItemArray[3]) > departmentBudgetRemaining(dept))
                if (getReportTotal(report) >= departmentBudgetRemaining(dept))
                {
                    row.CssClass = "info";
                }
                temp++;
            }

        }

        public double getReportTotal(string name)
        {
            return new DatabaseHandler().ReturnStaffReportTotalAmountForSupervisorReportName(name);
        }

        public double departmentBudgetRemaining(string dept)
        {
            return new DatabaseHandler().ReturnSingleDepartmentBudgetRemaining(dept);
        }

        protected void AllApprovedReportsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = AllApprovedReportsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorReportsDisplayPage.aspx");
            //fix that hardcode
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SupervisorAndStaffMain.aspx");
        }

    }
}