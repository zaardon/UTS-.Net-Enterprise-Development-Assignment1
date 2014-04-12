﻿using System;
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
        string reportName;
        string userGroupMember;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["reportName"] == null)
            {

                Session["reportName"] = reportName;
            }

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
            var selectCommand = new SqlCommand("SELECT distinct ReportName, ConsultantName FROM ExpenseDB WHERE StaffApproved = 'NO'", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            RejectedResultsGridViewSQLConnection.DataSource = resultSet;
            RejectedResultsGridViewSQLConnection.DataBind();

            connection.Close();
        }

        protected void RejectedResultsGridViewSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = RejectedResultsGridViewSQLConnection.Rows[index];
            reportName = selectedRow.Cells[1].Text.ToString();
            Session["reportName"] = reportName;
            Response.Redirect("SupervisorViewRejectedReportInfo.aspx");
            //fix that hardcode
        }
    }
}