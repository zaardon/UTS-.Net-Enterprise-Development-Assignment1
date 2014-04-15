using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueConsultingManagementSystemLogic;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;




namespace BlueConsultingManagementSystemTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("staff")]
        [TestMethod]
        public void AllApprovedReportsTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            DataSet ds= dh.AllApprovedReports();
            for(int j = 0; j< ds.Tables[0].Rows.Count; j++)
            {
                    String testify = ds.Tables[0].Rows[j]["StatusReport"].ToString();
                    Assert.AreEqual("Approved", testify);
            }
        }
        //[TestCategory("staff")]
        //[TestMethod]
        //public void DenyReportSupervisor()
        //{
        //    DatabaseHandler dh = new DatabaseHandler();
        //    using (TransactionScope TestTransaction = new TransactionScope())
        //    {
        //        dh.DenyReportSupervisor("supervisor", "JamesLoves");
        //        DataSet ds = dh.LoadRejectedReportNames();
        //        Assert.AreEqual("JamesLoves", ds.Tables[0].Rows[""].Contains);
        //fell asleep at keyboard commiting and going to sleep.
        //        TestTransaction.Dispose();
        //    }
        //}
        [TestCategory("staff")]
        [TestMethod]
        [TestCategory("staff")]
        [TestMethod]
        public void ReturnDepExpensesMadeTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            double result = dh.ReturnDepartmentExpensesMade("LogisticServices");
            Assert.AreEqual(0, result);
        }
        [TestCategory("staff")]
        [TestMethod]
        public void LoadRejectedInfoTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            DataSet ds = dh.LoadStaffUnapprovedReportInfo("The Big Meeting");
            Assert.AreEqual("dsfdsfds", ds.Tables[0].Rows[0]["Location"].ToString());
        }
        [TestCategory("staff")]
        [TestMethod]
        public void LoadRejectedReportNames()
        {
            DatabaseHandler dh = new DatabaseHandler();
            DataSet ds = dh.LoadStaffUnapprovedReportNames();
            string result = ds.Tables[0].Rows[0]["ReportName"].ToString();
            Assert.AreEqual("The Big Meeting", result);
        }
        [TestCategory("staff")]
        [TestMethod]
        //this test I am unsure about.
        public void UpdateDeptBudgetTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
             using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.UpdateDepartmentBudget("LogisticServices", 1.2);
                double result = dh.ReturnDepartmentExpensesMade("HigherEducation");
                Assert.AreEqual(424537.31, result);
               
                TestTransaction.Dispose();
            }
        }
        [TestCategory("staff")]
        [TestMethod]
        public void UnapprovedReportNames()
        {
            DatabaseHandler dh = new DatabaseHandler();
            DataSet ds = dh.LoadStaffUnapprovedReportNames();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                String teststatus = ds.Tables[0].Rows[j]["StatusReport"].ToString();
                Assert.AreEqual("Approved", teststatus);
   
            }
        }
        [TestCategory("staff")]
        [TestMethod]
        public void LoadStaffUnapprovedInfoTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            DataSet ds = dh.LoadStaffUnapprovedReportInfo("bacon");
            string result = ds.Tables[0].Rows[0]["name"].ToString();
            Assert.AreEqual("james",result);


        }
        [TestCategory("staff")]
        [TestMethod]
        public void CurrentDeptBudgetTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            double result = dh.ReturnCurrentDepartmentMoney("HigherEducation");
            //Assert.AreEqual(10000.000, result);
            result = dh.ReturnCurrentDepartmentMoney("LogisticServices");
            Assert.AreEqual(10000.000, result);
        }
        [TestCategory("staff")]
        [TestMethod]
        public void DenyReportTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            using (TransactionScope TestTransaction = new TransactionScope())
            {

                dh.ConsultantsInsertExpenseQuery("testReport", "test", "test", "test", 12.04, "AUD", "TestDept", DateTime.Today);
                dh.DenyReportStaff("testReport");
                var selectCommand = new SqlCommand("select ReportName,StaffApproved from [dbo].[ExpenseDB] where ReportName='testReport';", dh.SQLConnection);
                var adapter = new SqlDataAdapter(selectCommand);
                var resultSet = new DataSet();
                adapter.Fill(resultSet);
                string testify = resultSet.Tables[0].Rows[0]["StaffApproved"].ToString();
                Assert.AreEqual("NO", testify);
                TestTransaction.Dispose();
            }
        }
         [TestCategory("staff")]
        [TestMethod]
        public void ApproveReportTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            using (TransactionScope TestTransaction = new TransactionScope())
            {

                dh.ConsultantsInsertExpenseQuery("testReport", "test", "test", "test", 12.04, "AUD", "TestDept", DateTime.Today);
                dh.ApproveReportStaff("testReport");
                var selectCommand = new SqlCommand("select ReportName,StaffApproved from [dbo].[ExpenseDB] where ReportName='testReport';", dh.SQLConnection);
                var adapter = new SqlDataAdapter(selectCommand);
                var resultSet = new DataSet();
                adapter.Fill(resultSet);
                string testify = resultSet.Tables[0].Rows[0]["StaffApproved"].ToString();
                Assert.AreEqual("YES", testify);
                TestTransaction.Dispose();
            }
        }
        //INSERTION TEST METHOD.
        [TestCategory("Consultant")]
        [TestMethod]
        public void AddExpenseTest()
        {
            DatabaseHandler dh = new DatabaseHandler();
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                
                dh.ConsultantsInsertExpenseQuery("test", "test", "test", "test", 12.04 , "AUD","TestDept" ,DateTime.Today );
                var selectCommand = new SqlCommand("select ReportName from [dbo].[ExpenseDB] where ReportName='test';", dh.SQLConnection);
                var adapter = new SqlDataAdapter(selectCommand);
                var resultSet = new DataSet();
                adapter.Fill(resultSet);
                string testify = resultSet.Tables[0].Rows[0]["ReportName"].ToString();
                
                Assert.AreEqual("test", testify);
                TestTransaction.Dispose();
            }

        }

        //currency tests below here
         [TestCategory("Currency")]
                [TestMethod]
        public void TestEUR()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertDollars("EUR", 1);
            Assert.AreEqual(0.680265,expected);
        }
         [TestCategory("Currency")]
        [TestMethod]
        public void TestCAD()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertDollars("CND", 1);
            Assert.AreEqual(1.03215, expected);

        }
         [TestCategory("Currency")]
        [TestMethod]
        public void TestCurrencyConvertFails()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertDollars("fsd", 1);
            Assert.AreEqual(-1.0, expected);

        }

    }
}
