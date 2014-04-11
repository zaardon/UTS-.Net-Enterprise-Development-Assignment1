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
                userGroupMember = "State Services";
            else
                userGroupMember = "State";
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
                if (numb == null)
                    numb = 0;
            }
            
            return numb - departmentExpensesMade();
        }

        public double departmentExpensesMade()
        {
            double numb = 0.0;


            var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT SUM(Amount) FROM ExpenseDB WHERE Dept_type = '" + userGroupMember + "' AND StatusReport = 'Approved'", connection);
            //ONLY SHOW REPORTNAMES - DONT LET IT REPEAT ITSELF WITH THE OTHER INFO
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            numb = Convert.ToDouble(resultSet.Tables[0].Rows[0].ItemArray[0]);
            return numb;
        }

        public void loadData()
        {
            DepartmentLabel.Text = userGroupMember;
            TotalExpenses.Text = departmentExpensesMade().ToString();
            RemainingBudget.Text = departmentBudgetRemaining().ToString();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }
    }
}