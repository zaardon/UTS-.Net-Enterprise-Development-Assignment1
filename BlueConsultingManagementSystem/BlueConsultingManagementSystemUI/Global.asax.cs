using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace BlueConsultingManagementSystemUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string pathToData = "../BlueConsultingManagementSystemLogic/App_Data";
            string dataDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathToData));
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
        }

    }
}