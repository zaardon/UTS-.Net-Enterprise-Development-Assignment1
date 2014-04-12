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
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT Budget FROM DepartmentDB WHERE Dept_Name = 'HigherEducation'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            return numb;
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

            double result = (returnCurrentDeptMoney() - getTotalNumber());


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("UPDATE [dbo].[DepartmentDB] SET Budget = " + result + " WHERE Dept_Name = '"+userGroupMember+"'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            connection.Close();
        }

        public void approveReport()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Approved', ProcessedBy ='" + User.Identity.Name + "' , ProcessedByDept = '" + department + "' WHERE ReportName = '" + reportName + "'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            connection.Close();
        }

        public void denyReport()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Declined', ProcessedBy ='" + User.Identity.Name + "' , ProcessedByDept = '" + department + "' WHERE ReportName = '" + reportName + "'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            connection.Close();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            approveReport();
            deductBudget();
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        public void fillExpenseTable()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT ConsultantName as 'Name', Location, Description, Amount, Currency, DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            DisplayResultsGridSQLConnection.DataSource = resultSet;
            DisplayResultsGridSQLConnection.DataBind();

            connection.Close();
        }

    }
}