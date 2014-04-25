﻿using System;
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
    public partial class ViewExpenseTotal : System.Web.UI.Page
    {
        private string userGroupMember;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Higher Education Services"))
                userGroupMember = "Higher Education";
            else if (User.IsInRole("Logistic Services"))
                userGroupMember = "Logistic Services";
            else
                userGroupMember = "State Services";
            LoadData();
        }

        private void LoadData()
        {
            if (User.IsInRole("Department Supervisor"))
            {
                TotalExpenses.Text = "Total expenses for your department for this month, " + userGroupMember + ", are: $" + new DatabaseHandler().ReturnDepartmentExpensesMade(userGroupMember).ToString();
                RemainingBudget.Text = "Remaining budget for your department for this month is: $" + DepartmentBudgetRemaining().ToString();
            }
            else if(User.IsInRole("Staff"))
            {
                LoadStaffData();
                AllDepartmentExpensesGridViewSQLConnection.Visible = true;
                TotalExpenses.Text = "The total expenses currently approved this month is: $" + TotalExpensesApproved();
                RemainingBudget.Text = "The remaining company budget for this month is: $" + RemainingTotalBudgetForStaff();
            }
        }

        private double DepartmentBudgetRemaining()
        {
            return new DatabaseHandler().ReturnCurrentDepartmentMoney(userGroupMember);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorAndStaffMain.aspx");
        }

        private void LoadStaffData()
        {
            AllDepartmentExpensesGridViewSQLConnection.DataSource = new DatabaseHandler().ReturnStaffApprovedExpenses();
            AllDepartmentExpensesGridViewSQLConnection.DataBind();
        }

        private double RemainingTotalBudgetForStaff()
        {
            //How is this working?
            return new DatabaseHandler().ReturnTotalBudgetRemaining();
        }

        private double TotalExpensesApproved()
        {
            return new DatabaseHandler().ReturnTotalStaffExpensesApproved();
        }
    }
}