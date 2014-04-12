using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT Budget FROM DepartmentDB WHERE Dept_name = '"+ userGroupMember +"'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                    numb = 0;
            }
            
            return numb - departmentExpensesMade();
        }

        public double departmentExpensesMade()
        {
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT SUM(Amount) FROM ExpenseDB WHERE Dept_type = '" + userGroupMember + "' AND StatusReport = 'Approved' AND (StaffApproved = 'YES' OR StaffApproved IS NULL)", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                    numb = 0;
            }
            return numb;
        }

        public void loadData()
        {
            if (User.IsInRole("Department Supervisor"))
            {
                TotalExpenses.Text = "Total expenses for your department, " + userGroupMember + ", are: " + departmentExpensesMade().ToString();
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
            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct ProcessedBy, SUM(Amount) FROM ExpenseDB WHERE StatusReport ='Approved' GROUP BY ProcessedBy", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            AllDepartmentExpensesGridViewSQLConnection.DataSource = resultSet;
            AllDepartmentExpensesGridViewSQLConnection.DataBind();
        }

        public double remainingTotalBudget()
        {
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT SUM(Budget) FROM DepartmentDB", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                numb = 0;
            }
            return numb;
        }

        public double totalExpensesApproved()
        {
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT distinct SUM(Amount) FROM ExpenseDB WHERE StatusReport = 'Approved'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            try
            {
                numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            }
            catch
            {
                numb = 0;
            }
            return numb;
        }
    }
}