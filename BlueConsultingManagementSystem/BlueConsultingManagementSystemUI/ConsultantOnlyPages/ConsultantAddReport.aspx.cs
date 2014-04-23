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
        protected void Page_Load(object sender, EventArgs e)
        {
            string reportName = HttpUtility.HtmlDecode(Session["reportName"].ToString());

            if (reportName != "")
            {
                reportBox.Text = reportName.ToString();
                reportBox.ReadOnly = true;
            }

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
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
        }


    }
    
}