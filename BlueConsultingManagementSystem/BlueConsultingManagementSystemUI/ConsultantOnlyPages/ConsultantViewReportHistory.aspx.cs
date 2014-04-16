using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantViewReportHistory : System.Web.UI.Page
    {
        string reportName;
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportType = (string)Session["reportType"];

            if (Session["reportName"] == null)
            {

                Session["reportName"] = reportName;
            }

            if (reportType == "AllSubmitted")
            {
                loadSubmittedReports();
            }
            else if (reportType == "AllApproved")
            {
                loadApprovedReports();
            }
            else if (reportType == "InProgress")
            {
                loadInProgressReports();
            }
            
        }

        public void loadSubmittedReports()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName, StatusReport as 'Supvervisor Approval', StaffApproved as 'Account Staff Approval' FROM ExpenseDB WHERE ConsultantName = '" + User.Identity.Name +"'", con);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            con.Close();
            ConsultantHistorySQLConnection.DataSource = resultSet;
            ConsultantHistorySQLConnection.DataBind();
        }

        public void loadApprovedReports()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName, StatusReport as 'Supvervisor Approval', StaffApproved as 'Account Staff Approval' FROM ExpenseDB WHERE ConsultantName = '" + User.Identity.Name + "' AND StatusReport = 'Approved'", con);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            con.Close();
            ConsultantHistorySQLConnection.DataSource = resultSet;
            ConsultantHistorySQLConnection.DataBind();
        }

        public void loadInProgressReports()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName FROM ExpenseDB WHERE ConsultantName = '" + User.Identity.Name + "' AND StatusReport = 'Submitted'", con);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            con.Close();
            ConsultantHistorySQLConnection.DataSource = resultSet;
            ConsultantHistorySQLConnection.DataBind();
        }

        protected void ConsultantHistorySQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ConsultantHistorySQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("ConsultantViewReportHistoryExpenses.aspx");
            //fix that hardcode
        }
    }
}