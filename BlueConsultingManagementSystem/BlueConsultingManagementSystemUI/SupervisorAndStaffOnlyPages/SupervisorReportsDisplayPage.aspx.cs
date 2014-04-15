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

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class SupervisorReportsDisplayPage : System.Web.UI.Page
    {
        public string reportName;
        public string userGroupMember = "";
        public string department = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = User.Identity.AuthenticationType.ToString();
            Label1.Text = "null";
            reportName = (string)Session["reportName"];
            Label1.Text = reportName;
            fillExpenseTable();
            CurrentAmount.Text = "The total is: " + getTotalNumber().ToString();

            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "HigherEducation";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "LogisticServices";
            else
                userGroupMember = "StateServices";

            if(User.IsInRole("Staff"))
            {
                department = "Staff";
            }
            else if(User.IsInRole("Department Supervisor"))
            {
                department = "DepartmentSupervisor";
            }

        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {


            if (isUnder())
            {
                approveReport();
                deductBudget();
                Response.Redirect("SupervisorAndStaffMain.aspx");
            }
            else
            {
                ConfirmLabel.Text = "Are you sure you want to proceed? The current department budget is: " + returnCurrentDeptMoney();
                ConfirmLabel.Visible = true;
                ConfirmButton.Visible = true;
            }
        }

        protected void DenyButton_Click(object sender, EventArgs e)
        {
            denyReport();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        protected bool isUnder()
        {
            if (getTotalNumber() < returnCurrentDeptMoney())
            {                              
                return true;
            }
            else
            {

                return false;
            }
        }

        public double returnCurrentDeptMoney()
        {
            return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember);
        }

        public double getTotalNumber()
        {
            double totalNumber = 0;
            string colNumb = "";

            foreach (GridViewRow row in DisplayResultsGridSQLConnection.Rows)
            {
                //totalNumber += Convert.ToDouble(row.Cells[4].Text.ToString());
                colNumb = row.Cells[4].Text.ToString();
                totalNumber += Convert.ToDouble(colNumb);
            }

            return totalNumber;
        }

        public void deductBudget()
        {
            new DatabaseHandler().UpdateDepartmentBudget(userGroupMember, getTotalNumber());
        }

        public void approveReport()
        {
            if (department == "DepartmentSupervisor")
                approveSupervisor();
            else if (department == "Staff")
                approveReportStaff();
        }



        public void denyReport()
        {
            if(department == "DepartmentSupervisor")
                denySupervisor();
            else if (department == "Staff")
                denyReportStaff();
        }

        public void denyReportStaff()
        {

            new DatabaseHandler().DenyReportStaff(reportName);

        }

        public void approveReportStaff()
        {
            new DatabaseHandler().ApproveReportStaff(reportName);
        }

        public void denySupervisor()
        {
            new DatabaseHandler().DenyReportSupervisor(User.Identity.Name, reportName);
        }

        public void approveSupervisor()
        {
            new DatabaseHandler().ApproveReportSupervisor(User.Identity.Name, reportName);
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            approveReport();
            deductBudget();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        public void fillExpenseTable()
        {


            DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().LoadExpenseTable(reportName);
            DisplayResultsGridSQLConnection.DataBind();

        }

    }
}