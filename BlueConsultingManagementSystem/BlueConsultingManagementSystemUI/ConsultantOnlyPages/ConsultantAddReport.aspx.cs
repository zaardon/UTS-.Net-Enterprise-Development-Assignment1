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

            DatabaseHandler dh = new DatabaseHandler();
            dh.ConsultantsInsertExpenseQuery(reportBox.Text, User.Identity.Name, TextBox1.Text, TextBox2.Text, Convert.ToDouble( TextBox3.Text), DropDownList1.Text, DropDownList2.Text, Calendar1.SelectedDate.Date);
            Response.Redirect("ConsultantMain.aspx");
        }


    }
    
}