using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessSystemLogic;
using DataAccessSystemLogic.ExpenseTableAdapters;

namespace BlueConsultingManagementSystemLogic
{
    public class DatabaseHandler
    {
        public Expense.ExpenseDBDataTable doThis()
        {
            ExpenseDBTableAdapter db = new ExpenseDBTableAdapter();
            return db.StaffViewAll();
        }
    }
}
