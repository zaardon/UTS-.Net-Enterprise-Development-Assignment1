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
    public partial class SupervisorAndStaffMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UnapprovedResultsButton_Click(object sender, EventArgs e)
        {
            clearPage();
            loadData();
        }

        protected void clearPage()
        {
         HigherEducationGridViewSQLConnection.Visible = false;
                Label1.Visible = false;

                LogisticServicesGridViewSQLConnection.Visible = false;
            Label2.Visible = false;

            StateServicesGridViewSQLConnection.Visible = false;
                Label3.Visible = false;
        }

        protected void loadData()
        {

            if (User.IsInRole("Higher Education Services"))
            {
                HigherEducationGridViewSQLConnection.Visible = true;
                Label1.Visible = true;
                //SQL Command goes here to show datas
                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT ReportName, ConsultantName, StatusReport, Location, Description, Amount, Currency, DateExpense FROM ExpenseDB WHERE Dept_Type = 'HigherEducation' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                HigherEducationGridViewSQLConnection.DataSource = resultSet;
                HigherEducationGridViewSQLConnection.DataBind();

                connection.Close();


            }

            if (User.IsInRole("Logistic Services"))
            {
                LogisticServicesGridViewSQLConnection.Visible = true;
                Label2.Visible = true;

                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT ReportName, ConsultantName, StatusReport, Location, Description, Amount, Currency, DateExpense FROM ExpenseDB WHERE Dept_Type = 'LogisticServices' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                LogisticServicesGridViewSQLConnection.DataSource = resultSet;
                LogisticServicesGridViewSQLConnection.DataBind();

                connection.Close();
            }

            if (User.IsInRole("State Services"))
            {
                StateServicesGridViewSQLConnection.Visible = true;
                Label3.Visible = true;

                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT ReportName, ConsultantName, StatusReport, Location, Description, Amount, Currency, DateExpense FROM ExpenseDB WHERE Dept_Type = 'StateServices' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                StateServicesGridViewSQLConnection.DataSource = resultSet;
                StateServicesGridViewSQLConnection.DataBind();

                connection.Close();
            }
        }

        protected void ExpenseResultsButton_Click(object sender, EventArgs e)
        {
            clearPage();
        }

        protected void RejectedResultsButton_Click(object sender, EventArgs e)
        {
            clearPage();
        }

        protected void loadRejectItems()
        {
            HigherEducationGridViewSQLConnection.Visible = true;

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT ReportName, ConsultantName, StatusReport, Location, Description, Amount, Currency, DateExpense FROM ExpenseDB WHERE Dept_Type = 'StateServices' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            StateServicesGridViewSQLConnection.DataSource = resultSet;
            StateServicesGridViewSQLConnection.DataBind();

            connection.Close();
        }

        protected void HigherEducationGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);   
            GridViewRow selectedRow = HigherEducationGridViewSQLConnection.Rows[index];
            Label1.Text = selectedRow.Cells[1].Text;
 
        }
        
    }
}