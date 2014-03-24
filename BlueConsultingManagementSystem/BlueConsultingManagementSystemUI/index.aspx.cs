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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] == null)
            {
               LoginLogic checkLogin = new LoginLogic();
               Session["login"] = checkLogin;
                
            }
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
           AccountsProfile derp= new AccountsProfile("James", "pass");
            if(!derp.login(UserBox.Text, PassBox.Text))
                    ErrorLabel.Text = "Please reconsider your details";
                else
                {
                    ErrorLabel.Text = "Success!";
                    Server.Transfer("userpage.aspx");
                }
                
            
     
        }

    }
}