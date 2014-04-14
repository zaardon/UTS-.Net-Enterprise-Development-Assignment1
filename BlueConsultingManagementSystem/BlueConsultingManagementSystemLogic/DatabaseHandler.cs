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
        private SqlConnection SQLConnection;
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
        public void ConsultantsInsertExpenseQuery(string RepName, string User, string Location, string Description, string Amount, string Currency, string Dept_Type, DateTime DateExp)
        {
            SQLConnection.Open();
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO [dbo].[ExpenseDB] ( [ReportName], [ConsultantName], [StatusReport], [Location], [Description], [Amount], [Currency], [Dept_type], [DateExpense]) VALUES('" + RepName + "', '" + User + "', " + "'Submitted'" + ", '" + Location + "', '" + Description + "', '" + Amount + "', '" + Currency + "', '" + Dept_Type + "', '" + DateExp + "')", SQLConnection);
            sqlcmd.ExecuteScalar();
            SQLConnection.Close();
        }

    }
}
