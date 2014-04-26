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
        private SqlConnection SQLConnection;
        private DateTime START_OF_THIS_MONTH;

        public DatabaseHandler()
        {
            SetConnectionString();
            SetStartOfCurrentMonth();
            RoleBackOldMonthlyExpenses();
        }

        public SqlConnection RetrieveSQLConnection()
        {
            return this.SQLConnection;
        }

        private void SetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            this.SQLConnection = con;
        }

        private void SetStartOfCurrentMonth()
        {
            DateTime today = DateTime.Today;
            START_OF_THIS_MONTH = today.AddDays(1 - today.Day);
        }
        private void RoleBackOldMonthlyExpenses()
        {
            DataSet nonRolledBackReports = ReturnNonRolledBackReports();
            string reportName;
            double amount;
            string dept;
            DateTime dateApproved;

            foreach (DataRow row in nonRolledBackReports.Tables[0].Rows)
            {
                reportName = row.ItemArray[0].ToString();
                dateApproved = Convert.ToDateTime(row.ItemArray[1]);
                amount = Convert.ToDouble(row.ItemArray[2]);
                dept = row.ItemArray[3].ToString();

                if (!IsReportProcessedDateWithinThisMonth(dateApproved))
                {
                    ReturnRolledBackFundsToDepartmentBudget(amount, dept);
                    SetReportRolledBackStatus(reportName);
                }
            }
        }

        private void DataSetCommandStandard(SqlCommand command)
        {
            SQLConnection.Open();
            var selectCommand = command;
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
        }

        private DataSet DataSetCommandReturnDataSet(SqlCommand command)
        {
            var selectCommand = command;
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();
            return resultSet;
        }

        private double DataSetCommandReturnDouble(SqlCommand command)
        {
            double amount = 0.0;
            var selectCommand = command;
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();

            if (resultSet.Tables[0].Rows[0].ItemArray[0] == DBNull.Value)
                return amount = 0;
            else
                return amount = (double)(Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]));
        }

        private bool DataSetCommandReturnBool(SqlCommand command, string reportName)
        {
            SQLConnection.Open();
            var selectCommand = command;
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();

            string foundName = "";
            foreach (DataRow row in resultSet.Tables[0].Rows)
            {
                foundName = row.ItemArray[0].ToString();

                if (foundName == reportName)
                {
                    return true;
                }
            }
            return false;
        }


        private void SetReportRolledBackStatus(string reportName)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[ExpenseDB] SET RolledBack = 'YES' WHERE ReportName = '" + reportName + "' AND DateApproved is not NULL", SQLConnection));
        }

        private void ReturnRolledBackFundsToDepartmentBudget(double amount, string department)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[DepartmentDB] SET Budget = Budget + " + amount + " WHERE Dept_Name = '" + department + "'", SQLConnection));
        }

        private DataSet ReturnNonRolledBackReports()
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT DISTINCT ReportName, DateApproved, SUM(TotalAUD), DeptType, RolledBack FROM ExpenseDB WHERE DateApproved is not NULL AND RolledBack is NULL GROUP BY ReportName, DateApproved, DeptType, RolledBack", SQLConnection));
        }

        private bool IsReportProcessedDateWithinThisMonth(DateTime approvedDate)
        {
            if (DateTime.Compare(approvedDate, START_OF_THIS_MONTH) >= 0)
                return true;
            else
                return false;
        }

        public void InsertConsultantExpenseQuery(string repName, string user, string location, string description, double amount, string currency, string deptType, DateTime dateExp)
        {
            SQLConnection.Open();

            string cmd = "INSERT INTO [dbo].[ExpenseDB] ( [ReportName], [ConsultantName], [StatusReport], [Location], [Description], [Amount], [Currency], [DeptType], [DateExpense], [TotalAUD]) VALUES(@repName, @user, @status, @location, @description, @amount, @currency, @depttype, @dateExp, @totalAUD)";
            SqlCommand sqlcmd = new SqlCommand(cmd, SQLConnection);
            sqlcmd.Parameters.AddWithValue("@repName", repName);
            sqlcmd.Parameters.AddWithValue("@user", user);
            sqlcmd.Parameters.AddWithValue("@status", "Submitted");
            sqlcmd.Parameters.AddWithValue("@location", location);
            sqlcmd.Parameters.AddWithValue("@description", description);
            sqlcmd.Parameters.AddWithValue("@amount", amount);
            sqlcmd.Parameters.AddWithValue("@currency", currency);
            sqlcmd.Parameters.AddWithValue("@depttype", deptType);
            sqlcmd.Parameters.AddWithValue("@dateExp", dateExp);
            sqlcmd.Parameters.AddWithValue("@totalAUD", new CurrencyConverter().ConvertCurrencyToAUD(currency, amount));
            sqlcmd.ExecuteNonQuery();

            SQLConnection.Close();
        }

        public void InsertConsultantExpenseQueryWithPDF(string repName, string user, string location, string description, double amount, string currency, string deptType, DateTime dateExp, byte[] file)
        {
            SQLConnection.Open();

            string cmd = "INSERT INTO [dbo].[ExpenseDB] ( [ReportName], [ConsultantName], [StatusReport], [Location], [Description], [Amount], [Currency], [DeptType], [DateExpense], [PDF_File], [TotalAUD]) VALUES(@repName, @user, @status, @location, @description, @amount, @currency, @depttype, @dateExp, @PDF_File, @totalAUD)";
            SqlCommand sqlcmd = new SqlCommand(cmd, SQLConnection);
            sqlcmd.Parameters.AddWithValue("@repName", repName);
            sqlcmd.Parameters.AddWithValue("@user", user);
            sqlcmd.Parameters.AddWithValue("@status", "Submitted");
            sqlcmd.Parameters.AddWithValue("@location", location);
            sqlcmd.Parameters.AddWithValue("@description", description);
            sqlcmd.Parameters.AddWithValue("@amount", amount);
            sqlcmd.Parameters.AddWithValue("@currency", currency);
            sqlcmd.Parameters.AddWithValue("@depttype", deptType);
            sqlcmd.Parameters.AddWithValue("@dateExp", dateExp);
            sqlcmd.Parameters.AddWithValue("@totalAUD", new CurrencyConverter().ConvertCurrencyToAUD(currency, amount));
            sqlcmd.Parameters.Add("@PDF_File", SqlDbType.VarBinary, file.Length).Value = file;
            sqlcmd.ExecuteNonQuery();

            SQLConnection.Close();
        }

        public DataSet ReturnSubmittedReportsForDepartmentSupervisor(string userGroupMember)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ReportName as 'Report Name', ConsultantName as 'Consultant Name' FROM ExpenseDB WHERE DeptType = '" + userGroupMember + "' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", SQLConnection));
        }

        public double ReturnCurrentDepartmentMoney(string userGroupMember)
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT Budget FROM DepartmentDB WHERE Dept_Name = '" + userGroupMember + "'", SQLConnection));
        }

        public double ReturnDepartmentExpensesMade(string userGroupMember)
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT distinct SUM(TotalAUD) FROM ExpenseDB WHERE Depttype = '" + userGroupMember + "' AND StatusReport = 'Approved' AND (StaffApproved = 'Approved' OR StaffApproved IS NULL) AND RolledBack is null", SQLConnection));
        }

        public void UpdateDepartmentBudget(string userGroupMember, double totalAmount)
        {
            double result = (ReturnCurrentDepartmentMoney(userGroupMember) - totalAmount);
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[DepartmentDB] SET Budget = " + result + " WHERE Dept_Name = '" + userGroupMember + "'", SQLConnection));
        }

        public void DenyReportForStaffMember(string reportName, double returnedMoney, string dept)
        {
            SetReportStaffApprovalForDecline(reportName, dept);
            ReturnDeclinedSupervisorBudget(dept, returnedMoney);
        }

        private void SetReportStaffApprovalForDecline(string reportName, string dept)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StaffApproved = 'Declined' WHERE ReportName = '" + reportName + "' AND DeptType = '" + dept + "'", SQLConnection));
        }

        private void ReturnDeclinedSupervisorBudget(string dept, double returnedMoney)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[DepartmentDB] SET Budget = Budget + " + returnedMoney + " WHERE Dept_Name = '" + dept + "'", SQLConnection));
        }

        public void ApproveReportForStaffMember(string reportName, string dept)
        {
            SetReportStaffApprovalDate(reportName, dept);
            SetReportStaffApprovalForApprove(reportName, dept);
        }

        private void SetReportStaffApprovalForApprove(string reportName, string dept)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StaffApproved = 'Approved' WHERE ReportName = '" + reportName + "' AND DeptType = '" + dept + "'", SQLConnection));
        }

        private void SetReportStaffApprovalDate(string reportName, string dept)
        {
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET DateApproved = @dateApproved WHERE ReportName = '" + reportName + "' AND StatusReport = 'Approved' AND StaffApproved is NULL AND DeptType = '" + dept + "'", SQLConnection);
            selectCommand.Parameters.AddWithValue("@dateApproved", DateTime.Now.Date);
            DataSetCommandStandard(selectCommand);
        }

        public void DenyReportForSupervisor(string name, string reportName, string dept)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Declined', ProcessedBy ='" + name + "' WHERE ReportName = '" + reportName + "' AND DeptType = '" + dept + "'", SQLConnection));
        }

        public void ApproveReportForSupervisor(string name, string reportName, string dept)
        {
            DataSetCommandStandard(new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Approved', ProcessedBy ='" + name + "' WHERE ReportName = '" + reportName + "' AND DeptType = '" + dept + "'", SQLConnection));
        }
        // not tested
        public DataSet ReturnExpenseTable(string reportName, string dept)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT ConsultantName as 'Consultant Name', Location, Description, Amount, Currency, TotalAUD as 'Amount in AUD', DeptType as 'Department', DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "' AND DeptType = '" + dept + "'", SQLConnection));
        }
        // not tested
        public DataSet ReturnNonRejectedOrApprovedExpenses(string reportName, string dept)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT ConsultantName as 'Consultant Name', Location, Description, Amount, Currency, TotalAUD as 'Amount in AUD', DeptType, DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "' AND (StatusReport = 'Submitted' OR StaffApproved is NULL) AND DeptType = '" + dept + "'", SQLConnection));
        }

        public DataSet ReturnStaffApprovedExpenses()
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ProcessedBy as 'Supervisor Name', SUM(TotalAUD) as 'Total in AUD' FROM ExpenseDB WHERE StatusReport ='Approved' AND StaffApproved = 'Approved' AND RolledBack is null GROUP BY ProcessedBy", SQLConnection));
        }

        public double ReturnTotalBudgetRemaining()
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT SUM(Budget) FROM DepartmentDB", SQLConnection)) + ReturnTotalUnapprovedSpentBudget();
        }
        
        private double ReturnTotalUnapprovedSpentBudget()
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT SUM(TotalAUD) FROM ExpenseDB WHERE (StaffApproved is NULL) AND StatusReport = 'Approved'", SQLConnection));
        }

        public double ReturnTotalStaffExpensesApproved()
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT distinct SUM(TotalAUD) FROM ExpenseDB WHERE StatusReport = 'Approved' AND StaffApproved = 'Approved' AND RolledBack is null", SQLConnection));
        }
        //not tested
        public DataSet ReturnRejectedReportExpensesForSupervisor(string reportName, string dept)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT ConsultantName as 'Consultant Name', Location, Description, Amount, Currency, DateExpense as 'Date' FROM ExpenseDB WHERE ReportName = '" + reportName + "' AND DeptType = '" + dept + "'", SQLConnection));
        }
        public DataSet ReturnRejectedReportNamesForSupervisor(string dept, string processedBy)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ReportName as 'Report Name', ConsultantName as 'Consultant Name' FROM ExpenseDB WHERE StaffApproved = 'Declined' AND DeptType = '" + dept + "' AND processedBy = '" + processedBy + "'", SQLConnection));
        }

        public DataSet ReturnUnapprovedReportNamesForStaff()
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ReportName as 'Report Name', ConsultantName as 'Consultant Name', DeptType as 'Department' FROM ExpenseDB WHERE StatusReport = 'Approved' AND StaffApproved is NULL", SQLConnection));
        }

        //not tested
        public double ReturnReportTotalAmountForStaff(string reportName, string dept)
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT SUM(TotalAUD) FROM ExpenseDB WHERE ReportName = '" + reportName + "'  AND StaffApproved is NULL AND DeptType = '" + dept + "'", SQLConnection));
        }
        //not tested
        public double ReturnSingleDepartmentBudgetRemaining(string dept)
        {
            return ReturnCurrentDepartmentMoney(dept) + ReturnNonStaffApprovedDepartmentTotal(dept);
        }

        private double ReturnNonStaffApprovedDepartmentTotal(string dept)
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT SUM(TotalAUD) FROM ExpenseDB WHERE DeptType = '" + dept + "' AND StatusReport = 'Approved' AND StaffApproved is null", SQLConnection));
        }
        //not tested
        public DataSet ReturnConsultantSubmittedReports(string name)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ReportName as 'Report Name', DeptType as 'Department', StatusReport as 'Supervisor Approval', StaffApproved as 'Staff Approval' FROM ExpenseDB WHERE ConsultantName = '" + name + "'", SQLConnection));
        }

        public DataSet ReturnConsultantApprovedReports(string name)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ReportName as 'Report Name', DeptType as 'Department' FROM ExpenseDB WHERE ConsultantName = '" + name + "' AND StaffApproved = 'Approved'", SQLConnection));
        }

        public DataSet ReturnConsultantInProgressReports(string name)
        {
            return DataSetCommandReturnDataSet(new SqlCommand("SELECT distinct ReportName as 'Report Name', DeptType as 'Department' FROM ExpenseDB WHERE ConsultantName = '" + name + "' AND StatusReport = 'Submitted'", SQLConnection));
        }
        //not tested
        public byte[] RetrievePDFPage(string reportName, string consultantName, string location, string description, double amount, string currency)
        {
            byte[] pdfFile;
            SQLConnection.Open();
            var selectCommand = new SqlCommand("SELECT [PDF_File] FROM ExpenseDB WHERE reportName = '" + reportName + "' AND ConsultantName = '" + consultantName + "' AND Location = '" + location + "' AND Description = '" + description + "' AND Amount = '" + amount + "' AND Currency = '" + currency + "' AND PDF_File is not NULL", SQLConnection);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            SQLConnection.Close();

            try
            {
                pdfFile = (byte[])(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                pdfFile = null;
            }

            return pdfFile;
        }
        // not tested
        public double ReturnDepartmentBudgetForStaffExpenses(string dept)
        {
            return ReturnCurrentDepartmentMoney(dept) + ReturnDepartmentBudgetSpentUnapproved(dept);
        }

        private double ReturnDepartmentBudgetSpentUnapproved(string dept)
        {
            return DataSetCommandReturnDouble(new SqlCommand("SELECT SUM(TotalAUD) FROM ExpenseDB WHERE (StaffApproved is NULL) AND StatusReport = 'Approved' AND DeptType ='" + dept + "'", SQLConnection));
        }
        //not tested
        public bool CheckReportNameInUse(string reportName)
        {
            return DataSetCommandReturnBool(new SqlCommand("SELECT distinct ReportName FROM ExpenseDB WHERE ReportName = '" + reportName + "' AND (StatusReport = 'Approved' OR StatusReport = 'Rejected')", SQLConnection), reportName);
        }

        public bool CheckExpenseIsRepeated(string reportName, string location, string description, double amount, string currency, string deptType, DateTime dateExpense)
        {
            var selectCommand = new SqlCommand("SELECT distinct ReportName FROM ExpenseDB WHERE ReportName = '" + reportName + "' AND Location = '" + location + "' AND Description = '" + description + "' AND Amount = " + amount + " AND Currency = '" + currency + "' AND DeptType = '" + deptType + "' AND DateExpense = @dateExpense", SQLConnection);
            selectCommand.Parameters.AddWithValue("@dateExpense", dateExpense);
            return DataSetCommandReturnBool(selectCommand, reportName);
        }
    }
}
