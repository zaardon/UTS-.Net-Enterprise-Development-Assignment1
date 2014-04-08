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
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "null";
            reportName = (string)Session["reportName"];
            Label1.Text = reportName;

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT ConsultantName, Location, Description, Amount, Currency, DateExpense FROM ExpenseDB WHERE ReportName = '"+reportName+"'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            DisplayResultsGridSQLConnection.DataSource = resultSet;
            DisplayResultsGridSQLConnection.DataBind();

            connection.Close();
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {


            if (isUnder())
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Approved' WHERE ReportName = '" + reportName + "'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                connection.Close();
                Response.Redirect("SupervisorAndStaffMain.aspx");
            }
            else
            { 

            }
        }

        protected void DenyButton_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("UPDATE [dbo].[ExpenseDB] SET StatusReport = 'Declined' WHERE ReportName = '" + reportName + "'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            connection.Close();

            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        protected bool isUnder()
        {
            double totalNumber = 0;
            int index = 0;
            string colNumb = "";

            foreach (GridViewRow row in DisplayResultsGridSQLConnection.Rows)
            {
                //totalNumber += Convert.ToDouble(row.Cells[4].Text.ToString());
                colNumb = row.Cells[3].Text.ToString();
                totalNumber += Convert.ToDouble(colNumb);
            }

            if (totalNumber < returnCurrentDeptMoney())
            {
                
                DisplayNumber.Text = totalNumber.ToString();
                return true;
            }
            else
            {
                ConfirmLabel.Visible = true;
                ConfirmButton.Visible = true;
                DisplayNumber.Text = totalNumber.ToString();
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


    }
}