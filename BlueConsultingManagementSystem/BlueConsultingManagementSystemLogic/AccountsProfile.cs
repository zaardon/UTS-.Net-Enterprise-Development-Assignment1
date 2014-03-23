using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
    public class AccountsProfile
    {

        public string username { get; set; }
        public string password { get; set; }

        public AccountsProfile(string name, string pass)
        {
            this.username = name;
            this.password = pass;
        }
        public AccountsProfile() { }

        public bool login(string name, string pass) 
        {
            if (name == username && pass == password)
                return true;
            else
                return false;
        }
        public void createAccount() { }

        public void viewExpenseReports() { }



    }

    //create bools on what the accounts can/can't do
}
