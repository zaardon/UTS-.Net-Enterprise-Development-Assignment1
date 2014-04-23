using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BlueConsultingManagementSystemLogic;


namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class SupervisorReportsDisplayPage : System.Web.UI.Page
    {
        public string reportName;
        public string deptNameForStaff;
        public string userGroupMember = "";
        public string department = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = User.Identity.AuthenticationType.ToString();
            Label1.Text = "null";
            reportName = Session["reportName"].ToString();
            
            Label1.Text = reportName;
            
            

            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "HigherEducation";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "LogisticServices";
            else
                userGroupMember = "StateServices";

            

            if(User.IsInRole("Staff"))
            {
                department = "Staff";
                deptNameForStaff = Session["deptNameForStaff"].ToString();
            }
            else if(User.IsInRole("Department Supervisor"))
            {
                department = "DepartmentSupervisor";
            }

            fillExpenseTable();
            CurrentAmount.Text = "The total is: $" + getTotalNumber().ToString() + " AUD";

        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            if (isUnder())
            {
                approveReport();                
                Response.Redirect("SupervisorAndStaffMain.aspx");
            }
            else
            {
                ConfirmLabel.Text = "Are you sure you want to proceed? The current department budget is: $" + returnCurrentDeptMoney()+" AUD";
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
            if (getTotalNumber() <= returnCurrentDeptMoney())
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
            if (department == "DepartmentSupervisor")
                return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember);
            else
            {
                string deptName = DisplayResultsGridSQLConnection.Rows[0].Cells[7].Text.ToString();
                return new DatabaseHandler().ReturnDepartmentBudgetForStaffExpenses(deptName);
            }
        }

        public double getTotalNumber()
        {
            double totalNumber = 0;
            string colNumb = "";
            string currency = "";

            foreach (GridViewRow row in DisplayResultsGridSQLConnection.Rows)
            {
                //totalNumber += Convert.ToDouble(row.Cells[4].Text.ToString());
                colNumb = row.Cells[4].Text.ToString();
                currency = row.Cells[5].Text.ToString();
                totalNumber += new CurrencyConverter().ConvertCurrencyToAUD(currency, Convert.ToDouble(colNumb));
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
            {
                approveSupervisor();
                deductBudget();
            }
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
            double temp = getTotalNumber();
            new DatabaseHandler().DenyReportStaff(reportName, temp, deptNameForStaff);

        }

        public void approveReportStaff()
        {
            new DatabaseHandler().ApproveReportStaff(reportName, deptNameForStaff);
        }

        //sdfsdfdsf
        public void denySupervisor()
        {
            new DatabaseHandler().DenyReportSupervisor(User.Identity.Name, reportName, userGroupMember);
        }

        //dgdfgsfgds
        public void approveSupervisor()
        {
            new DatabaseHandler().ApproveReportSupervisor(User.Identity.Name, reportName, userGroupMember);
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            approveReport();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        public void fillExpenseTable()
        {

            if (User.IsInRole("Department Supervisor"))
                DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().LoadExpenseTableNonRejectedOrApprovedForSupervisor(reportName,userGroupMember);
            else if (department == "Staff")
                DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().LoadExpenseTableNonRejectedOrApprovedForStaff(reportName, deptNameForStaff);

            DisplayResultsGridSQLConnection.DataBind();

        }

        protected void DisplayResultsGridSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = DisplayResultsGridSQLConnection.Rows[index];

            string name  = selectedRow.Cells[1].Text.ToString();
            string location = selectedRow.Cells[2].Text.ToString();
            string description = selectedRow.Cells[3].Text.ToString();
            double amount = Convert.ToDouble(selectedRow.Cells[4].Text.ToString());
            string currency = selectedRow.Cells[5].Text.ToString();


            byte[] pdfFile = new DatabaseHandler().RetrievePDFPage(reportName, name, location, description, amount, currency);
            if(pdfFile != null && pdfFile.Length !=0)
            {
                  HttpContext.Current.Response.ContentType = "application/pdf";
                  HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename =test.pdf");
                  HttpContext.Current.Response.BinaryWrite((byte[])pdfFile);//get data in variable in binary format
                  HttpContext.Current.Response.End();
            }
            else
            {
                 Response.Write("No PDF File for expense has been added");
            }

        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }

            
        

    }
}