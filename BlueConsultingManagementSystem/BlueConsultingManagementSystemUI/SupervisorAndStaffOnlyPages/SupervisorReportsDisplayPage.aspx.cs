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
        private string reportName;
        private string deptNameForStaff;
        private string userGroupMember = "";
        private string department = "";
        private int NAME_POS = 1;
        private int LOC_POS = 2;
        private int DESC_POS = 3;
        private int AMOUNT_POS = 4;
        private int CURR_POS = 5;
        
        protected void Page_Load(object sender, EventArgs e)
        {
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

            FillExpenseTable();
            CurrentAmount.Text = "The total is: $" + GetTotalReportAmount().ToString() + " AUD";
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            if (IsUnderBudget())
            {
                ApproveReport();                
                Response.Redirect("SupervisorAndStaffMain.aspx");
            }
            else
            {
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

        public double ReturnCurrentDeptMoney()
        {
            if (department == "DepartmentSupervisor")
                return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember);
            else
            {
                string deptName = DisplayResultsGridSQLConnection.Rows[0].Cells[7].Text.ToString();
                return new DatabaseHandler().ReturnDepartmentBudgetForStaffExpenses(deptName);
            }
        }

        public double GetTotalReportAmount()
        {
            double totalAmount = 0;
            string amount = "";
            string currency = "";

            foreach (GridViewRow row in DisplayResultsGridSQLConnection.Rows)
            {
                amount = row.Cells[AMOUNT_POS].Text.ToString();
                currency = row.Cells[CURR_POS].Text.ToString();
                totalAmount += new CurrencyConverter().ConvertCurrencyToAUD(currency, Convert.ToDouble(amount));
            }
            return totalAmount;
        }

        public void DeductBudget()
        {
            new DatabaseHandler().UpdateDepartmentBudget(userGroupMember, GetTotalReportAmount());
        }

        public void ApproveReport()
        {
            if (department == "DepartmentSupervisor")
            {
                ApproveSupervisor();
                DeductBudget();
            }
            else if (department == "Staff")
                ApproveReportStaff();
        }

        public void DenyReport()
        {
            if(department == "DepartmentSupervisor")
                DenySupervisor();
            else if (department == "Staff")
                DenyReportStaff();
        }

        public void DenyReportStaff()
        {
            new DatabaseHandler().DenyReportForStaffMember(reportName, GetTotalReportAmount(), deptNameForStaff);
        }

        public void ApproveReportStaff()
        {
            new DatabaseHandler().ApproveReportForStaffMember(reportName, deptNameForStaff);
        }

        public void DenySupervisor()
        {
            new DatabaseHandler().DenyReportForSupervisor(User.Identity.Name, reportName, userGroupMember);
        }

        public void ApproveSupervisor()
        {
            new DatabaseHandler().ApproveReportForSupervisor(User.Identity.Name, reportName, userGroupMember);
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            ApproveReport();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        public void FillExpenseTable()
        {
            if (User.IsInRole("Department Supervisor"))
                DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().ReturnNonRejectedOrApprovedExpensesForSupervisor(reportName,userGroupMember);
            else if (department == "Staff")
                DisplayResultsGridSQLConnection.DataSource = new DatabaseHandler().ReturnNonRejectedOrApprovedExpensesForStaff(reportName, deptNameForStaff);

            DisplayResultsGridSQLConnection.DataBind();
        }

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

            byte[] pdfFile = new DatabaseHandler().RetrievePDFPage(reportName, name, location, description, amount, currency);
            if(pdfFile != null && pdfFile.Length !=0)
            {
                  HttpContext.Current.Response.ContentType = "application/pdf";
                  HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename =test.pdf");
                  HttpContext.Current.Response.BinaryWrite((byte[])pdfFile);//get data in variable in binary format
                  HttpContext.Current.Response.End();
            }
            else
                 Response.Write("No PDF File for expense has been added");
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }
    }
}