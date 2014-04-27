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
         private readonly int NAME_POS = 1;
         private readonly int LOC_POS = 2;
         private readonly int DESC_POS = 3;
         private readonly int AMOUNT_POS = 4;
         private readonly int CURR_POS = 5;

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

         /**
         * If the user choses to view a receipt, the gridview's row command is used. 
         **/
         protected void RejectedReportInfoSQLConnection_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
         {
             string currentCommand = e.CommandName;
             int index = Convert.ToInt32(e.CommandArgument);
             GridViewRow selectedRow = RejectedReportInfoSQLConnection.Rows[index];

             string name = selectedRow.Cells[NAME_POS].Text.ToString();
             string location = selectedRow.Cells[LOC_POS].Text.ToString();
             string description = selectedRow.Cells[DESC_POS].Text.ToString();
             double amount = Convert.ToDouble(selectedRow.Cells[AMOUNT_POS].Text.ToString());
             string currency = selectedRow.Cells[CURR_POS].Text.ToString();

             //If a PDF file exists for an individual expense, it is loaded in it's PDF format to the page...
             byte[] pdfFile = new DatabaseHandler().RetrievePDFPage(reportName, name, location, description, amount, currency);
             if(pdfFile != null)
             {
                   HttpContext.Current.Response.ContentType = "application/pdf";
                   HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename =test.pdf");
                   HttpContext.Current.Response.BinaryWrite((byte[])pdfFile);//get data in variable in binary format
                   HttpContext.Current.Response.End();
             }
             //...else it returns a message saying one cannot be found.
             else
                 excLbl.Text = "No PDF File for expense has been added";
        }

        protected void BacktoSupervisor_Click(object sender, EventArgs e)
        {
             Response.Redirect("SupervisorViewRejectedReports.aspx");
        }
    }
}