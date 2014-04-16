using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class ConsultantMain : System.Web.UI.Page
    {
        public string reportType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["reportType"] == null)
            {
                Session["reportType"] = reportType;
            }

        }

        protected void AddReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultantSelectReportName.aspx");
        }

        protected void SubmittedReportsButton_Click(object sender, EventArgs e)
        {
            reportType = "AllSubmitted";
            Session["reportType"] = reportType;
            Response.Redirect("ConsultantViewReportHistory.aspx");
        }

        protected void ApprovedReportsButton_Click(object sender, EventArgs e)
        {
            reportType = "AllApproved";
            Session["reportType"] = reportType;
            Response.Redirect("ConsultantViewReportHistory.aspx");
        }

        protected void UnapprovedReportsButton_Click(object sender, EventArgs e)
        {
            reportType = "InProgress";
            Session["reportType"] = reportType;
            Response.Redirect("ConsultantViewReportHistory.aspx");
        }
    }
}