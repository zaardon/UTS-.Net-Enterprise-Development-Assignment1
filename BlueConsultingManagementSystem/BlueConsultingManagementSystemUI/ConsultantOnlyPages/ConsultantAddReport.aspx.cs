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

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (new InputChecker().HasPunctuationCharacters(reportBox.Text) || new InputChecker().HasPunctuationCharacters(LocationBox.Text) || new InputChecker().HasPunctuationCharacters(DescriptionBox.Text))
                    throw new Exception("This report uses punctuation characters, please remove them.");

                if (new DatabaseHandler().CheckReportNameInUse(reportBox.Text))
                    throw new Exception("This report name has currently been processed, and is awaiting approval or has been declined. \nPlease use another one.");

                if (new DatabaseHandler().CheckExpenseIsRepeated(reportBox.Text, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), CurrencyList.Text, DepartmentList.Text, Calendar1.SelectedDate.Date))
                    throw new Exception("This individual expense currently exists, please alter it's details.");              

                if (reportBox.Text == null || reportBox.Text =="") 
                    throw new Exception("Missing report name !");

                if (LocationBox.Text == null || LocationBox.Text=="")
                    throw new Exception("Missing Location!");

                if(DescriptionBox.Text == null || DescriptionBox.Text=="")
                    throw new Exception("Missing Description !");

                if(AmountBox.Text == null || AmountBox.Text=="")
                    throw new Exception("Missing Amount !");

                if(Calendar1.SelectedDate.ToString()=="" || Calendar1.SelectedDate.ToString() == null)
                    throw new Exception("Missing Date !");

                if (DateTime.Compare(Calendar1.SelectedDate, TODAY) > 0)
                    throw new Exception("Date is pointing to the future.");

                if (FileUpload1.FileName == null || FileUpload1.FileName == "")
                    new DatabaseHandler().InsertConsultantExpenseQuery(reportBox.Text, User.Identity.Name, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), CurrencyList.Text, DepartmentList.Text, Calendar1.SelectedDate.Date);
                else
                {
                    byte[] file = FileUpload1.FileBytes;
                    new DatabaseHandler().InsertConsultantExpenseQueryWithPDF(reportBox.Text, User.Identity.Name, LocationBox.Text, DescriptionBox.Text, Convert.ToDouble(AmountBox.Text), CurrencyList.Text, DepartmentList.Text, Calendar1.SelectedDate.Date, file);
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
    }
}
    
