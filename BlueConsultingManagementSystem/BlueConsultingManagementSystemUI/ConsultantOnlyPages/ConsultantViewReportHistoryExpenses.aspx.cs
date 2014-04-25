using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantViewReportHistoryExpenses : System.Web.UI.Page
    {
        private string reportName;
        private string deptName;
        private int NAME_POS = 1;
        private int LOC_POS = 2;
        private int DESC_POS = 3;
        private int AMOUNT_POS = 4;
        private int CURR_POS = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            reportName = (string)(Session["reportName"].ToString());
            deptName = Session["deptName"].ToString();
            Label1.Text = reportName;
            LoadData();
        }

        private void LoadData()
        {
            ReportExpenseHistoryDetailsSQLConnection.DataSource = new DatabaseHandler().ReturnExpenseTable(reportName, deptName);
            ReportExpenseHistoryDetailsSQLConnection.DataBind();
        }

        protected void ReportExpenseHistoryDetailsSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ReportExpenseHistoryDetailsSQLConnection.Rows[index];

            string name = selectedRow.Cells[NAME_POS].Text.ToString();
            string location = selectedRow.Cells[LOC_POS].Text.ToString();
            string description = selectedRow.Cells[DESC_POS].Text.ToString();
            double amount = Convert.ToDouble(selectedRow.Cells[AMOUNT_POS].Text.ToString());
            string currency = selectedRow.Cells[CURR_POS].Text.ToString();

            byte[] pdfFile = new DatabaseHandler().RetrievePDFPage(reportName, name, location, description, amount, currency);
            if (pdfFile != null && pdfFile.Length != 0)
            {
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename =test.pdf");
                HttpContext.Current.Response.BinaryWrite((byte[])pdfFile);//get data in variable in binary format
                HttpContext.Current.Response.End();
            }
            else
                Response.Write("No PDF File for expense has been added");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultantMain.aspx");
        }
    }
}