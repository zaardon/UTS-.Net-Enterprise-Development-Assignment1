using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class SupervisorUnapprovedResults : System.Web.UI.Page
    {

        //THIS CLASS NEEDS TO BE NAMED
        //THIS CLASS NEEDS TO BE NAMED
        //THIS CLASS NEEDS TO BE NAMED
        //THIS CLASS NEEDS TO BE NAMED
        public string reportName;
        public string userGroupMember;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reportName"] == null)
            {

                Session["reportName"] = reportName;
            }

            if (User.IsInRole("Department Supervisor"))
            {
                if (User.IsInRole("Higher Education Services"))
                    userGroupMember = "HigherEducation";
                else if (User.IsInRole("Logistic Services"))
                    userGroupMember = "LogisticServices";
                else
                    userGroupMember = "StateServices";

                loadDepartmentSupervisorData();
            }
            else if(User.IsInRole("Staff"))
            {
                loadStaffData();
            }
        }

        protected void loadDepartmentSupervisorData()
        {
                //SQL Command goes here to show datas
                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName FROM ExpenseDB WHERE Dept_Type = '" + userGroupMember + "' AND StatusReport <> 'Approved' AND StatusReport <> 'Declined'", connection);
                //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                UnapprovedReportsGridViewSQLConnection.DataSource = resultSet;
                UnapprovedReportsGridViewSQLConnection.DataBind();

                connection.Close();


        }

        public void loadStaffData()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName, Dept_type FROM ExpenseDB WHERE StatusReport  <> 'Approved' AND StatusReport <> 'Declined'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            UnapprovedReportsGridViewSQLConnection.DataSource = resultSet;
            UnapprovedReportsGridViewSQLConnection.DataBind();

            connection.Close();
            int temp = 0;
            string dept = "";
            string report = "";
            foreach (GridViewRow row in UnapprovedReportsGridViewSQLConnection.Rows)
            {
                dept = resultSet.Tables[0].Rows[temp].ItemArray[2].ToString();
                report = (resultSet.Tables[0].Rows[temp].ItemArray[0].ToString());
                //if (Convert.ToDouble(resultSet.Tables[0].Rows[temp].ItemArray[3]) > departmentBudgetRemaining(dept))
                if (getReportTotal(report) > departmentBudgetRemaining(dept))
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                }
                temp++;
            }

        }

        public double getReportTotal(string name)
        {
            double numb = 0.0;

            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT SUM(Amount) FROM ExpenseDB WHERE ReportName = '" + name + "'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            connection.Close();
            numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            return numb;
        }

        public double departmentBudgetRemaining(string dept)
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

        protected void UnapprovedReportsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = UnapprovedReportsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("SupervisorReportsDisplayPage.aspx");
            //fix that hardcode
        }

    }
}