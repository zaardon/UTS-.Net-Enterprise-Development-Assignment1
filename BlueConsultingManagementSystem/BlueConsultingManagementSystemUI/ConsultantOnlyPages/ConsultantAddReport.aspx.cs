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
using System.Web.Security;
using System.IO;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantAddReport : System.Web.UI.Page
    {
        DateTime TODAY;
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportName = HttpUtility.HtmlDecode(Session["reportName"].ToString());

            if (reportName != "")
            {
                reportBox.Text = reportName.ToString();
                reportBox.ReadOnly = true;
            }

            TODAY = DateTime.Today;
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (new InputChecker().hasNonAlphaNumCharacters(reportBox.Text) || new InputChecker().hasNonAlphaNumCharacters(LocationBox.Text) || new InputChecker().hasNonAlphaNumCharacters(DescriptionBox.Text))
                    throw new Exception("This report uses non-alphanumeric characters.");

                if (new DatabaseHandler().isReportNameUsed(reportBox.Text))
                    throw new Exception("This report name has currently been processed, and is awaiting approval or has been declined. \nPlease use another one.");

                if (new DatabaseHandler().isExpenseRepeated(reportBox.Text, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), DropDownList1.Text, DropDownList2.Text, Calendar1.SelectedDate.Date))
                    throw new Exception("This individual expense currently exists, please alter it's details.");              

                if (reportBox.Text == null || reportBox.Text =="") 
                {
                    throw new Exception("Missing report name !");
                }
                if (LocationBox.Text == null || LocationBox.Text=="")
                {
                    throw new Exception("Missing Location!");
                }
                if(DescriptionBox.Text == null || DescriptionBox.Text=="")
                {
                    throw new Exception("Missing Description !");
                }
                if(AmountBox.Text == null || AmountBox.Text=="")
                {
                    throw new Exception("Missing Amount !");
                }
                if(Calendar1.SelectedDate.ToString()=="" || Calendar1.SelectedDate.ToString() == null)
                {
                    throw new Exception("Missing Date !");
                }

                if (DateTime.Compare(Calendar1.SelectedDate, TODAY) > 0)
                {
                    throw new Exception("Date is pointing to the future.");
                }

                if (FileUpload1.FileName == null || FileUpload1.FileName == "")
                {
                    DatabaseHandler dh = new DatabaseHandler();
                    dh.ConsultantsInsertExpenseQuery(reportBox.Text, User.Identity.Name, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), DropDownList1.Text, DropDownList2.Text, Calendar1.SelectedDate.Date);
                }
                else
                {
                    byte[] file = FileUpload1.FileBytes;
                    DatabaseHandler dh = new DatabaseHandler();
                    dh.ConsultantsInsertExpenseQueryWithPDF(reportBox.Text, User.Identity.Name, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), DropDownList1.Text, DropDownList2.Text, Calendar1.SelectedDate.Date, file);
                }

                Response.Redirect("ConsultantMain.aspx");
            }
            catch (Exception ex)
            {
                excLbl.Text = ex.Message;
            }

            try
            {
                double.Parse(AmountBox.Text);
            }              
            catch (FormatException ex)
            {
                excLbl.Text = "You have entered non-numeric characters for the amount";
            }
        }
    }
}
    
