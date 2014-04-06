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
    public partial class SupervisorAndStaffMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Higher Education Services"))
            {
                HigherEducationGridViewSQLConnection.Visible = true;
                Label1.Visible = true;
                //SQL Command goes here to show datas
                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT * FROM ExpenseDB WHERE Dept_Type = 'HigherEducation'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                HigherEducationGridViewSQLConnection.DataSource = resultSet;
                HigherEducationGridViewSQLConnection.DataBind();

                connection.Close();


            }

            if (User.IsInRole("Logistic Services"))
            {
                LogisticServicesGridViewSQLConnection.Visible = true;
                Label2.Visible = true;

                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT * FROM ExpenseDB WHERE Dept_Type = 'LogisticServices'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                LogisticServicesGridViewSQLConnection.DataSource = resultSet;
                LogisticServicesGridViewSQLConnection.DataBind();

                connection.Close();
            }

            if (User.IsInRole("State Services"))
            {
                StateServicesGridViewSQLConnection.Visible = true;
                Label3.Visible = true;

                var connectionString = ConfigurationManager.ConnectionStrings["BlueConsultingDBString"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                var selectCommand = new SqlCommand("SELECT * FROM ExpenseDB WHERE Dept_Type = 'StateServices'", connection);
                var adapter = new SqlDataAdapter(selectCommand);

                var resultSet = new DataSet();
                adapter.Fill(resultSet);

                StateServicesGridViewSQLConnection.DataSource = resultSet;
                StateServicesGridViewSQLConnection.DataBind();

                connection.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e){


        }
        
        
    }
}