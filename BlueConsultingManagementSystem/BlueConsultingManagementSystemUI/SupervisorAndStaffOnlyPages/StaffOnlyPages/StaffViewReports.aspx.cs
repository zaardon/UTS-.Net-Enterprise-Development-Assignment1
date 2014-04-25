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
    public partial class StaffViewReports : System.Web.UI.Page
    {
        private string reportName;
        private string deptName;
        private int REP_POS = 0;
        private int DEPT_POS = 2; 

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            DataSet results = new DatabaseHandler().ReturnUnapprovedReportNamesForStaff();
            AllApprovedReportsGridViewSQLConnection.DataSource = results;
            AllApprovedReportsGridViewSQLConnection.DataBind();
            
            int rowNum = 0;
            string dept = "";
            string report = "";
            foreach (GridViewRow row in AllApprovedReportsGridViewSQLConnection.Rows)
            {
                report = (results.Tables[0].Rows[rowNum].ItemArray[REP_POS].ToString());
                dept = results.Tables[0].Rows[rowNum].ItemArray[DEPT_POS].ToString();

                if (GetReportTotal(report, dept) > DepartmentBudgetRemaining(dept))
                    row.CssClass = "info";

                rowNum++;
            }
        }

        private double GetReportTotal(string name, string dept)
        {
            return new DatabaseHandler().ReturnReportTotalAmountForStaff(name, dept);
        }

        private double DepartmentBudgetRemaining(string dept)
        {
            return new DatabaseHandler().ReturnSingleDepartmentBudgetRemaining(dept);
        }

        protected void AllApprovedReportsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = AllApprovedReportsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[REP_POS + 1].Text.ToString();
            deptName = selectedRow.Cells[DEPT_POS + 1].Text.ToString();
            Session["reportName"] = reportName;
            Session["deptNameForStaff"] = deptName;
            Response.Redirect("~/SupervisorAndStaffOnlyPages/ViewReports.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SupervisorAndStaffMain.aspx");
        }

    }
}