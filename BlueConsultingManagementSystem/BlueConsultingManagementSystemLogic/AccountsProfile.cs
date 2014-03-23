using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
    class AccountsProfile
    {

        string username;
        string password;

        public void login() { }


        //public void createAccount() { }
        protected void viewExpenseReports() { }
        protected bool canSubmitExpenses() { return false;}
        protected bool canAttachReceipts() { return false; }
        protected bool submitExpenses() { return false; }
        protected bool canViewPDFFile() { return false; }




    }

    //create bools on what the accounts can/can't do
}
