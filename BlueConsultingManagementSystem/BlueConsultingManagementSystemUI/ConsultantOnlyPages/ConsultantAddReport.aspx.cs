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
        DateTime TODAY = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportName = HttpUtility.HtmlDecode(Session["reportName"].ToString());
            string deptName = HttpUtility.HtmlDecode(Session["deptName"].ToString());
            if (reportName != "")
            {
                reportBox.Text = reportName.ToString();
                reportBox.ReadOnly = true;
                DepartmentList.Text = deptName.ToString();
                DeptLabel.Text = deptName.ToString();
                DeptLabel.Visible = true;
                DepartmentList.Visible = false;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (new InputChecker().HasPunctuationCharacters(reportBox.Text) || new InputChecker().HasPunctuationCharacters(LocationBox.Text) || new InputChecker().HasPunctuationCharacters(DescriptionBox.Text))
                    throw new Exception("This report uses punctuation characters, please remove them.");

                if (new DatabaseHandler().CheckReportNameInUse(reportBox.Text))
                    throw new Exception("This report name has currently been processed, and is awaiting approval or has been declined. \nPlease use another one.");

                if (new DatabaseHandler().CheckExpenseIsRepeated(reportBox.Text, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), CurrencyList.Text, DepartmentList.Text, ExpenseCalendar.SelectedDate.Date))
                    throw new Exception("This individual expense currently exists, please alter it's details.");              

                if (reportBox.Text == null || reportBox.Text =="") 
                    throw new Exception("Missing report name !");

                if (LocationBox.Text == null || LocationBox.Text=="")
                    throw new Exception("Missing Location!");

                if(DescriptionBox.Text == null || DescriptionBox.Text=="")
                    throw new Exception("Missing Description !");

                if(AmountBox.Text == null || AmountBox.Text=="")
                    throw new Exception("Missing Amount !");

                if (ExpenseCalendar.SelectedDate.ToString() == "" || ExpenseCalendar.SelectedDate.ToString() == null)
                    throw new Exception("Missing Date !");

                if (DateTime.Compare(ExpenseCalendar.SelectedDate, TODAY) > 0)
                    throw new Exception("Date is pointing to the future.");

                if (PDFFileUpload.FileName == null || PDFFileUpload.FileName == "")
                    new DatabaseHandler().InsertConsultantExpenseQuery(reportBox.Text, User.Identity.Name, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), CurrencyList.Text, DepartmentList.Text, ExpenseCalendar.SelectedDate.Date);
                else
                {

                    if (Path.GetExtension(PDFFileUpload.FileName) == ".pdf")
                    {
                        byte[] file = PDFFileUpload.FileBytes;
                        new DatabaseHandler().InsertConsultantExpenseQueryWithPDF(reportBox.Text, User.Identity.Name, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), CurrencyList.Text, DepartmentList.Text, ExpenseCalendar.SelectedDate.Date, file);
                    }
                    else
                        throw new Exception("Sorry this File upload only accepts PDF's");
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
            catch (FormatException)
            {
                excLbl.Text = "You have entered non-numeric characters for the amount";
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultantSelectReportName.aspx");
        }
    }
}
    
