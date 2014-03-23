using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingManagementSystemLogic
{
    class SupervisorProfile : AccountsProfile
    {
        protected void approveReport(){}
        protected void rejectReport() { }
        protected void confirmApproval() { }
        protected void seeExpenses() { }
        public void displayRemainingBudget() { }
        public void displayRejectedReports() { }

    }
}
