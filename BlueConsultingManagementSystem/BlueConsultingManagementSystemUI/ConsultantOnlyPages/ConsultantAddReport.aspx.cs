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
            if (FileUpload1.FileName == null)
            {
                DatabaseHandler dh = new DatabaseHandler();
                dh.ConsultantsInsertExpenseQuery(reportBox.Text, User.Identity.Name, TextBox1.Text, TextBox2.Text, Convert.ToDouble(TextBox3.Text), DropDownList1.Text, DropDownList2.Text, Calendar1.SelectedDate.Date);
            }
            else
            {
                byte[] file = FileUpload1.FileBytes;


                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var con = new SqlConnection(connectionString);

                con.Open();


                string cmd = "INSERT INTO [dbo].[ExpenseDB] ( [ReportName], [ConsultantName], [StatusReport], [Location], [Description], [Amount], [Currency], [Dept_type], [DateExpense], [PDF_File]) VALUES(@repName, @user, @status, @location, @description, @amount, @currency, @dept_type, @dateExp, @PDF_File)";
                SqlCommand sqlcmd = new SqlCommand(cmd, con);
                sqlcmd.Parameters.AddWithValue("@repName", reportBox.Text);
                sqlcmd.Parameters.AddWithValue("@user", User.Identity.Name);
                sqlcmd.Parameters.AddWithValue("@status", "Submitted");
                sqlcmd.Parameters.AddWithValue("@location", TextBox1.Text);
                sqlcmd.Parameters.AddWithValue("@description", TextBox2.Text);
                sqlcmd.Parameters.AddWithValue("@amount", Convert.ToDouble(TextBox3.Text));
                sqlcmd.Parameters.AddWithValue("@currency", DropDownList1.Text);
                sqlcmd.Parameters.AddWithValue("@dept_type", DropDownList2.Text);
                sqlcmd.Parameters.AddWithValue("@DateExp", Calendar1.SelectedDate.Date);

                sqlcmd.Parameters.Add("@PDF_File", SqlDbType.VarBinary, file.Length).Value = file;

                sqlcmd.ExecuteNonQuery();

                con.Close();
            }

            Response.Redirect("ConsultantMain.aspx");
        }


    }
    
}