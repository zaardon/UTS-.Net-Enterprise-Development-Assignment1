using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BlueConsultingManagementSystemUI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void ConsultantBtn_Click(object sender, EventArgs e)
        {
          Response.Redirect("ConsultantOnlyPages/ConsultantMain.aspx");
        }

        protected void SuperStaffbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorAndStaffOnlyPages/SupervisorAndStaffMain.aspx");
        }
    }
}