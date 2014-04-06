using System;
using System.Collections.Generic;
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            private void DisplayAllFoodsSqlConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("SELECT * FROM FOODS", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            var resultSet = new DataSet();
            adapter.Fill(resultSet);

            FoodListGridViewSqlConnection.DataSource = resultSet;
            FoodListGridViewSqlConnection.DataBind();

            connection.Close();
        }
        }
    }
}