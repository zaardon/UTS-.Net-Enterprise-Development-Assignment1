using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI
{
    public partial class userpage : System.Web.UI.Page
    {
         AccountsProfile sesDerp;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesDerp = (AccountsProfile)Session["loginu"];
            LBName.Text ="the account name is : " + sesDerp.username;

        }
    }
}