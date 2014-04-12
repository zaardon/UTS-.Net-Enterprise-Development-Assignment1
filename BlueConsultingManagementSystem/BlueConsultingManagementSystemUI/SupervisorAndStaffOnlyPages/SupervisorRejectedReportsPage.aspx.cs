using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SuperVisorOnlyPages
{
    public partial class SupervisorRejectedReportsPage : System.Web.UI.Page
    {

        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        //STAFF ACCOUNTS CANNOT DO THIS!!!!!!!!!!
        string userGroupMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "HigherEducation";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "Logistic";
            else
                userGroupMember = "State";
            loadResults();
        }

        public void loadResults()
        {
            RejectedResultsGridViewSQLConnection.Visible = true;

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName, StatusReport as 'Status', Location, Description, Amount, Currency, DateExpense FROM ExpenseDB WHERE StatusReport = 'Declined' AND ProcessedByDept = 'Staff'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            RejectedResultsGridViewSQLConnection.DataSource = resultSet;
            RejectedResultsGridViewSQLConnection.DataBind();

            connection.Close();
        }
    }
}