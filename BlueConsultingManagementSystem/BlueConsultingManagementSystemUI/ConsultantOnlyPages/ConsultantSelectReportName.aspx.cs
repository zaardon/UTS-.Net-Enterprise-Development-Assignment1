using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantSelectReportName : System.Web.UI.Page
    {
        public string reportName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reportName"] == null)
            {

                Session["reportName"] = reportName;
            }

            WelcomeMessage.Text = "Welcome: " + Membership.GetUser().UserName + ", you may continue the following reports";

            loadCurrentReports();
        }

        public void loadCurrentReports()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var con = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ReportName FROM ExpenseDB WHERE ConsultantName = '" + User.Identity.Name + "' AND StatusReport = 'Submitted'", con);
            var adapter = new SqlDataAdapter(selectCommand);
            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            con.Close();
            CurrentReportNamesSQLConnection.DataSource = resultSet;
            CurrentReportNamesSQLConnection.DataBind();

        }
    

        protected void CurrentReportNamesSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = CurrentReportNamesSQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("ConsultantAddReport.aspx");
            //fix that hardcode
        }

        protected void NewReportButton_Click(object sender, EventArgs e)
        {
            Session["reportName"] = "";
            Response.Redirect("ConsultantAddReport.aspx");
        }
    }
}