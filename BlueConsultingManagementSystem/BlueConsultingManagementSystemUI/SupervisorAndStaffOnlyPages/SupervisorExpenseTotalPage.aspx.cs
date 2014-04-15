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

        public double departmentBudgetRemaining()
        {
            //double numb = 0.0;


            //var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            //var connection = new SqlConnection(connectionString);
            //var selectCommand = new SqlCommand("SELECT Budget FROM DepartmentDB WHERE Dept_name = '"+ userGroupMember +"'", connection);
            ////ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            //var adapter = new SqlDataAdapter(selectCommand);

            //var resultSet = new DataSet();
            //adapter.Fill(resultSet);

            //try
            //{
            //    numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            //}
            //catch
            //{
            //        numb = 0;
            //}

            return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember) - new DatabaseHandler().ReturnDepartmentExpensesMade(userGroupMember);
        }


        public void loadData()
        {
            if (User.IsInRole("Department Supervisor"))
            {
                TotalExpenses.Text = "Total expenses for your department, " + userGroupMember + ", are: " + new DatabaseHandler().ReturnDepartmentExpensesMade(userGroupMember).ToString();
                RemainingBudget.Text = "Remaining budget for your department is: " + departmentBudgetRemaining().ToString();
            }
            else if(User.IsInRole("Staff"))
            {
                loadStaffData();
                AllDepartmentExpensesGridViewSQLConnection.Visible = true;
                TotalExpenses.Text = "The total expenses currently approved is: " + totalExpensesApproved();
                RemainingBudget.Text = "The remaining company budget is: " + remainingTotalBudget();
            }
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

        public double remainingTotalBudget()
        {
            return new DatabaseHandler().ReturnTotalBudgetRemaining();
        }

        public double totalExpensesApproved()
        {
            return new DatabaseHandler().ReturnTotalExpensesApproved();
        }
    }
}