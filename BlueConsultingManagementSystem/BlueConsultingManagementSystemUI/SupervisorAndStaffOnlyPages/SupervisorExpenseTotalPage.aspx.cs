using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemLogic;

namespace BlueConsultingManagementSystemUI.SupervisorAndStaffOnlyPages
{
    public partial class SupervisorExpenseTotalPage : System.Web.UI.Page
    {
        string userGroupMember;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "HigherEducation";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "LogisticServices";
            else
                userGroupMember = "StateServices";
            loadData();
        }




        public void loadData()
        {
            if (User.IsInRole("Department Supervisor"))
            {
                TotalExpenses.Text = "Total expenses for your department, " + userGroupMember + ", are: $" + new DatabaseHandler().ReturnDepartmentExpensesMade(userGroupMember).ToString();
                RemainingBudget.Text = "Remaining budget for your department is: $" + departmentBudgetRemaining().ToString();
            }
            else if(User.IsInRole("Staff"))
            {
                loadStaffData();
                AllDepartmentExpensesGridViewSQLConnection.Visible = true;
                TotalExpenses.Text = "The total expenses currently approved is: $" + totalExpensesApproved();
                RemainingBudget.Text = "The remaining company budget is: $" + remainingTotalBudgetForStaff();
            }
        }

        public double departmentBudgetRemaining()
        {


            return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }


        public void loadStaffData()
        {


            AllDepartmentExpensesGridViewSQLConnection.DataSource = new DatabaseHandler().LoadStaffDataExpenses();
            AllDepartmentExpensesGridViewSQLConnection.DataBind();
        }

        public double remainingTotalBudgetForStaff()
        {
            return new DatabaseHandler().ReturnTotalBudgetRemaining();
        }

        public double totalExpensesApproved()
        {
            return new DatabaseHandler().ReturnTotalExpensesApproved();
        }
    }
}