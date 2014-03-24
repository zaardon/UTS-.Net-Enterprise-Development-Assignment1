using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI
{
    public partial class index : System.Web.UI.Page
    {
        public AccountsProfile sesDerp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["loginu"] == null)
            {
                sesDerp = new AccountsProfile("James", "pass");               
            }
            else
                sesDerp = (AccountsProfile)Session["loginu"];
           

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // alex this redirects put i wanted to see something.
            //LoginLogic checkLogin = (LoginLogic)Session["login"];

            //ErrorLabel.Visible = true;
            //if (!checkLogin.correctDetails(UserBox.Text, PassBox.Text))
            //    ErrorLabel.Text = "Please reconsider your details";
            //else
            //{
            //    ErrorLabel.Text = "Success!";
            //    Server.Transfer("userpage.aspx");
            //}
            if (sesDerp == null)
                ErrorLabel.Text = " you done fucked up the session";
            else
            {
                if (!sesDerp.login(UserBox.Text, PassBox.Text))
                    ErrorLabel.Text = "Please reconsider your details";
                else
                {
                    ErrorLabel.Text = "Success!";
                    Session["loginu"] = sesDerp;
                    Server.Transfer("userpage.aspx");
                    
                }
            }
            
     
        }

    }
}