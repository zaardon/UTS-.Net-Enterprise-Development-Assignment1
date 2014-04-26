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

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.SupervisorOnlyPages
{
    public partial class SupervisorViewRejectedReportInfo : System.Web.UI.Page
    {
         private string reportName;
         private string deptName;

         protected void Page_Load(object sender, EventArgs e)
         {
             reportName = Session["reportName"].ToString();
             deptName = Session["deptName"].ToString();
             LoadData();
         }

         private void LoadData()
         {
             RejectedReportInfoSQLConnection.DataSource = new DatabaseHandler().ReturnRejectedReportExpensesForSupervisor(reportName, deptName);
             RejectedReportInfoSQLConnection.DataBind();
         }

         protected void RejectedReportInfoSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
         {
             string currentCommand = e.CommandName;
             int index = Convert.ToInt32(e.CommandArgument);
             GridViewRow selectedRow = RejectedReportInfoSQLConnection.Rows[index];

             string name  = selectedRow.Cells[1].Text.ToString();
             string location = selectedRow.Cells[2].Text.ToString();
             string description = selectedRow.Cells[3].Text.ToString();
             double amount = Convert.ToDouble(selectedRow.Cells[4].Text.ToString());
             string currency = selectedRow.Cells[5].Text.ToString();

             byte[] pdfFile = new DatabaseHandler().RetrievePDFPage(reportName, name, location, description, amount, currency);
             if(pdfFile != null)
             {
                   HttpContext.Current.Response.ContentType = "application/pdf";
                   HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename =test.pdf");
                   HttpContext.Current.Response.BinaryWrite((byte[])pdfFile);//get data in variable in binary format
                   HttpContext.Current.Response.End();
             }
             else
                 excLbl.Text = "No PDF File for expense has been added";
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
             Response.Redirect("SupervisorViewRejectedReports.aspx");
        }
    }
}