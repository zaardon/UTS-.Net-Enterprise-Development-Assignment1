using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlueConsultingManagementSystemLogic
{
    public class DatabaseHandler
    {
        // naming convention
        /*
         * [Person][Command][Name][Query] 
         * 
         * ALLWAYS FOLLOW
         */
        public SqlConnection SQLConnection;
        public DatabaseHandler()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            this.SQLConnection = con;
        }

        public DataSet AllApprovedReports()
        {
            var selectCommand = new SqlCommand("SELECT DISTINCT ReportName, ConsultantName, StatusReport, Dept_type FROM ExpenseDB WHERE StatusReport = 'Approved'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }
        public void ConsultantsInsertExpenseQuery(string RepName, string User, string Location, string Description, double Amount, string Currency, string Dept_Type, DateTime DateExp)
        {
            SQLConnection.Open();

            string cmd = "INSERT INTO [dbo].[ExpenseDB] ( [ReportName], [ConsultantName], [StatusReport], [Location], [Description], [Amount], [Currency], [Dept_type], [DateExpense]) VALUES(@repName, @user, @status, @location, @description, @amount, @currency, @dept_type, @dateExp)";
            SqlCommand sqlcmd = new SqlCommand(cmd, SQLConnection);
            sqlcmd.Parameters.AddWithValue("@repName", RepName);
            sqlcmd.Parameters.AddWithValue("@user", User);
            sqlcmd.Parameters.AddWithValue("@status", "Submitted");
            sqlcmd.Parameters.AddWithValue("@location", Location);
            sqlcmd.Parameters.AddWithValue("@description", Description);
            sqlcmd.Parameters.AddWithValue("@amount", Amount);
            sqlcmd.Parameters.AddWithValue("@currency", Currency);
            sqlcmd.Parameters.AddWithValue("@dept_type", Dept_Type);
            sqlcmd.Parameters.AddWithValue("@DateExp", DateExp);

            sqlcmd.ExecuteNonQuery();

            SQLConnection.Close();
        }

        public DataSet LoadDepartmentSupervisorData(string userGroupMember)
        {
            var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName FROM ExpenseDB WHERE Dept_Type = '" + userGroupMember + "' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }

        public double ReturnCurrentDepartmentMoney(string userGroupMember)
        {
            double numb = 0.0;
            var selectCommand = new SqlCommand("SELECT Budget FROM DepartmentDB WHERE Dept_Name = '" + userGroupMember + "'", SQLConnection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            return numb;
        }

        public double ReturnDepartmentExpensesMade(string userGroupMember)
        {
            double numb = 0.0;
            var selectCommand = new SqlCommand("SELECT SUM(Amount) FROM ExpenseDB WHERE Dept_type = '" + userGroupMember + "' AND StatusReport = 'Approved' AND (StaffApproved = 'YES' OR StaffApproved IS NULL)", SQLConnection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
                SQLConnection.Close();
            }
            catch
            {
                numb = 0;
                SQLConnection.Close();
            }
            return numb;
            
        }


        public void UpdateDepartmentBudget(string userGroupMember, double total)
        {

            double result = (ReturnCurrentDepartmentMoney(userGroupMember) - total);
            var selectCommand = new SqlCommand("UPDATE [dbo].[DepartmentDB] SET Budget = " + result + " WHERE Dept_Name = '" + userGroupMember + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();

        }

        public void DenyReportStaff(string reportName)
        {
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StaffApproved = 'NO' WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
        }

        public void ApproveReportStaff(string reportName)
        {
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StaffApproved = 'YES' WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            SQLConnection.Close();
        }

        public void DenyReportSupervisor(string name, string reportName)
        {
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Declined', ProcessedBy ='" + name + "' WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            SQLConnection.Close();
        }

        public void ApproveReportSupervisor(string name, string reportName)
        {
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Approved', ProcessedBy ='" + name + "' WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            SQLConnection.Close();
        }

        public DataSet LoadExpenseTable(string reportName)
        {

            var selectCommand = new SqlCommand("SELECT ConsultantName as 'Name', Location, Description, Amount, Currency, DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;          
         
        }


        public DataSet LoadStaffDataExpenses()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ProcessedBy, SUM(Amount) FROM ExpenseDB WHERE StatusReport ='Approved' GROUP BY ProcessedBy", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            return resultSet;
        }

        public double ReturnTotalBudgetRemaining()
        {
            double numb = 0.0;

            var selectCommand = new SqlCommand("SELECT SUM(Budget) FROM DepartmentDB", SQLConnection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                numb = 0;
            }
            SQLConnection.Close();
            return numb;
        }

        public double ReturnTotalExpensesApproved()
        {
            double numb = 0.0;
            var selectCommand = new SqlCommand("SELECT distinct SUM(Amount) FROM ExpenseDB WHERE StatusReport = 'Approved'", SQLConnection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                numb = 0;
            }
            SQLConnection.Close();
            return numb;
        }

        public DataSet LoadRejectedReportInfo(string reportName)
        {
            var selectCommand = new SqlCommand("SELECT ConsultantName as 'Name', Location, Description, Amount, Currency, DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;

        }
        public DataSet LoadRejectedReportNames()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName FROM ExpenseDB WHERE StaffApproved = 'NO'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);          
            SQLConnection.Close();
            return resultSet;
        }

        public DataSet LoadStaffUnapprovedReportInfo(string reportName)
        {

            var selectCommand = new SqlCommand("SELECT ConsultantName as 'Name', Location, Description, Amount, Currency, DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }

        public DataSet LoadStaffUnapprovedReportNames()
        {
           var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName, StatusReport, Dept_type FROM ExpenseDB WHERE StatusReport = 'Approved' AND StaffApproved is NULL", SQLConnection);
           var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }

        public double ReturnStaffReportTotalAmountForSupervisorName(string name)
        {
            double numb = 0.0;

            var selectCommand = new SqlCommand("SELECT SUM(Amount) FROM ExpenseDB WHERE ReportName = '" + name + "'", SQLConnection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            SQLConnection.Close();
            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                numb = 0;
            }
            return numb;
        }

        public double ReturnSingleDepartmentBudgetRemaining(string dept)
        {
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT Budget FROM DepartmentDB WHERE Dept_name = '" + dept + "'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {

                numb = 0;
            }

            return numb;
        }

        public DataSet ConsultantLoadSubmittedReports(string name)
        {
            var selectCommand = new SqlCommand("SELECT distinct ReportName, StatusReport as 'Supvervisor Approval', StaffApproved as 'Account Staff Approval' FROM ExpenseDB WHERE ConsultantName = '" + name + "'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }

        public DataSet ConsultantLoadApprovedReports(string name)
        {
            var selectCommand = new SqlCommand("SELECT distinct ReportName, StatusReport as 'Supvervisor Approval', StaffApproved as 'Account Staff Approval' FROM ExpenseDB WHERE ConsultantName = '" + name + "' AND StatusReport = 'Approved'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }

        public DataSet ConsultantLoadInProgressReports(string name)
        {
            var selectCommand = new SqlCommand("SELECT distinct ReportName FROM ExpenseDB WHERE ConsultantName = '" + name + "' AND StatusReport = 'Submitted'", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }
    }
}
