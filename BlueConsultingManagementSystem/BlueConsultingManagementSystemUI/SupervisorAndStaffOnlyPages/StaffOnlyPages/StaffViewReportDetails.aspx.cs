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

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages.StaffOnlyPages
{
    public partial class StaffViewReportDetails : System.Web.UI.Page
    {
        string reportName;
        protected void Page_Load(object sender, EventArgs e)
        {
            reportName = (string)Session["reportName"];
            loadData();
        }

        public void loadData()
        {
            ApprovedReportDetailsSQLConnection.DataSource = new DatabaseHandler().LoadStaffUnapprovedReportInfo(reportName);
            ApprovedReportDetailsSQLConnection.DataBind();


            //connection.Close();

        }
    }
}