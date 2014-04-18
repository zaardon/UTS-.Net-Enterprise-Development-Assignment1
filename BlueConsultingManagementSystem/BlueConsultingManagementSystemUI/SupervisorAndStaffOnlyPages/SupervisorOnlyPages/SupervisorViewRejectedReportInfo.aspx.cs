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

            string reportName;
            protected void Page_Load(object sender, EventArgs e)
            {
                reportName = Session["reportName"].ToString();
                loadData();
            }

            public void loadData()
            {

                RejectedReportInfoSQLConnection.DataSource = new DatabaseHandler().LoadRejectedReportInfo(reportName);
                RejectedReportInfoSQLConnection.DataBind();

            } 
    }
}