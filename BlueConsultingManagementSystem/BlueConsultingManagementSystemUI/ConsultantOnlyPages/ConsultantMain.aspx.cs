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
    public partial class ConsultantMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {

            //var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            //var connection = new SqlConnection(connectionString);
            //connection.Open();
            ////var selectCommand = new SqlCommand("SELECT * FROM ExpenseDB", connection);
            ////var adapter = new SqlDataAdapter(selectCommand);
            ////var resultSet = new DataSet();
            ////adapter.Fill(resultSet);

            //string cmd = "INSERT INTO [dbo].[ExpenseDB] ( [ReportName], [ConsultantName], [StatusReport], [Location], [Description], [Amount], [Currency], [Dept_type], [DateExpense]) VALUES(@repName, @user, @status, @location, @description, @amount, @currency, @dept_type, @dateExp)";
            //SqlCommand sqlcmd = new SqlCommand(cmd, connection);
            //sqlcmd.Parameters.AddWithValue("@repName", reportBox.Text);
            //sqlcmd.Parameters.AddWithValue("@user", "james");
            //sqlcmd.Parameters.AddWithValue("@status", "Submitted");
            //sqlcmd.Parameters.AddWithValue("@location", TextBox1.Text);
            //sqlcmd.Parameters.AddWithValue("@description", TextBox2.Text);
            //sqlcmd.Parameters.AddWithValue("@amount", TextBox3.Text);
            //sqlcmd.Parameters.AddWithValue("@currency", DropDownList1.Text);
            //sqlcmd.Parameters.AddWithValue("@dept_type", DropDownList2.Text);
            //sqlcmd.Parameters.AddWithValue("DateExp", Calendar1.SelectedDate.Date);
           
            //sqlcmd.ExecuteNonQuery();

            //connection.Close();
            DatabaseHandler dh = new DatabaseHandler();
            dh.ConsultantsInsertExpenseQuery(reportBox.Text, User.Identity.Name, TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList1.Text, DropDownList2.Text, Calendar1.SelectedDate.Date);
            Response.Redirect("../index.aspx");
        }


    }
}