using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingManagementSystemUI.ExpensesTableAdapters;

namespace BlueConsultingManagementSystemUI.ConsultantOnlyPages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayAllReportsDataSet();
        }

        private void DisplayAllReportsDataSet()
        {
           //<asp:GridView runat="server" ID="ExpenseListGridViewTypedDataSet" />
            //var table = new FoodsTableAdapter().GetData();

            //FoodListGridViewTypedDataSet.DataSource = table;
            //FoodListGridViewTypedDataSet.DataBind();

            var table = new ExpenseDBTableAdapter().GetData();

            ExpenseListGridViewTypedDataSet.DataSource = table;
            ExpenseListGridViewTypedDataSet.DataBind();
        }
    }
}