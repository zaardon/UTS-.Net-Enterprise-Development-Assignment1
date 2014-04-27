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
    public partial class ViewReports : System.Web.UI.Page
    {
        private string reportName;
        private string deptNameForStaff;
        private string userGroupMember = "";
        private string department = "";
        private readonly int NAME_POS = 1;
        private readonly int LOC_POS = 2;
        private readonly int DESC_POS = 3;
        private readonly int AMOUNT_POS = 4;
        private readonly int CURR_POS = 5;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            reportName = Session["reportName"].ToString();
            ReportLabel.Text = reportName;

            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "Higher Education";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "Logistic Services";
            else
                userGroupMember = "State Services";     

            if(User.IsInRole("Staff"))
            {
                department = "Staff";
                deptNameForStaff = Session["deptNameForStaff"].ToString();
            }
            else if(User.IsInRole("Department Supervisor"))
            {
                department = "DepartmentSupervisor";
            }

            FillExpenseTable();
            CurrentAmount.Text = "The total is: $" + GetTotalReportAmount().ToString() + " AUD";
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            if (IsUnderBudget())
            {
                //Approves the report, no questions asked.
                ApproveReport();                
                Response.Redirect("SupervisorAndStaffMain.aspx");
            }
            else
            {
                //Provides a confirmation to approve the report...
                ConfirmLabel.Text = "Are you sure you want to proceed? The current department budget is: $" + ReturnCurrentDeptMoney()+" AUD";
                ConfirmLabel.Visible = true;
                ConfirmButton.Visible = true;
            }
        }

        protected void DenyButton_Click(object sender, EventArgs e)
        {
            DenyReport();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        protected bool IsUnderBudget()
        {
            if (GetTotalReportAmount() <= ReturnCurrentDeptMoney()) 
                return true;
            else 
                return false;               
        }

        private double ReturnCurrentDeptMoney()
        {
            //If a Department Supervisor, returns the current department money from the P.O.V. of their user account
            if (department == "DepartmentSupervisor")
                return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember);
            else
            //If a Staff member, returns the current department money from the P.O.V. of their user account, according to the supervisor's department name
            {
                string deptName = DisplayResultsGridSQLConnection.Rows[0].Cells[7].Text.ToString();
                return new DatabaseHandler().ReturnDepartmentBudgetForStaffExpenses(deptName);
            }
        }

        private double GetTotalReportAmount()
        {
            double totalAmount = 0;
            string amount = "";
            string currency = "";

            //Returns the current amount of money (in AUD) of the report
            foreach (GridViewRow row in DisplayResultsGridSQLConnection.Rows)
            {
                amount = row.Cells[AMOUNT_POS].Text.ToString();
                currency = row.Cells[CURR_POS].Text.ToString();
                totalAmount += new CurrencyConverter().ConvertCurrencyToAUD(currency, Convert.ToDouble(amount));
            }
            return totalAmount;
        }

        private void DeductBudget()
        {
            new DatabaseHandler().UpdateDepartmentBudget(userGroupMember, GetTotalReportAmount());
        }

        private void ApproveReport()
        {
            if (department == "DepartmentSupervisor")
            {
                ApproveReportForSupervisor();
                //Deducts the budget from the supervisor's department
                DeductBudget();
            }
            else if (department == "Staff")
                ApproveReportForStaffMember();
        }

        private void DenyReport()
        {
            if(department == "DepartmentSupervisor")
                DenyReportForSupervisor();
            else if (department == "Staff")
                DenyReportForStaffMember();
        }

        private void DenyReportForStaffMember()
        {
            new DatabaseHandler().DenyReportForStaffMember(reportName, GetTotalReportAmount(), deptNameForStaff);
        }

        private void ApproveReportForStaffMember()
        {
            new DatabaseHandler().ApproveReportForStaffMember(reportName, deptNameForStaff);
        }

        private void DenyReportForSupervisor()
        {
            new DatabaseHandler().DenyReportForSupervisor(User.Identity.Name, reportName, userGroupMember);
        }

        private void ApproveReportForSupervisor()
        {
            new DatabaseHandler().ApproveReportForSupervisor(User.Identity.Name, reportName, userGroupMember);
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            ApproveReport();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        private void FillExpenseTable()
        {
            //Loads the gridview according to what account the user belongs to.
            if (User.IsInRole("Department Supervisor"))
                DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().ReturnNonRejectedOrApprovedExpenses(reportName,userGroupMember);
            else if (department == "Staff")
                DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().ReturnNonRejectedOrApprovedExpenses(reportName, deptNameForStaff);

            DisplayResultsGridSQLConnection.DataBind();
        }

        /*
        * Allows the user to view the PDF file of an expense, if available
        */
        protected void DisplayResultsGridSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = DisplayResultsGridSQLConnection.Rows[index];

            string name  = selectedRow.Cells[NAME_POS].Text.ToString();
            string location = selectedRow.Cells[LOC_POS].Text.ToString();
            string description = selectedRow.Cells[DESC_POS].Text.ToString();
            double amount = Convert.ToDouble(selectedRow.Cells[AMOUNT_POS].Text.ToString());
            string currency = selectedRow.Cells[CURR_POS].Text.ToString();

            //If a PDF file exists for an individual expense, it is loaded in it's PDF format to the page...
            byte[] pdfFile = new DatabaseHandler().RetrievePDFPage(reportName, name, location, description, amount, currency);
            if(pdfFile != null && pdfFile.Length !=0)
            {
                  HttpContext.Current.Response.ContentType = "application/pdf";
                  HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename =test.pdf");
                  HttpContext.Current.Response.BinaryWrite((byte[])pdfFile);//get data in variable in binary format
                  HttpContext.Current.Response.End();
            }
            //...else it returns a message saying one cannot be found.
            else
                excLbl.Text = "No PDF File for expense has been added";
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }
    }
}