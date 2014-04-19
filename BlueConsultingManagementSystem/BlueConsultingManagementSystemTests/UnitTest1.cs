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
        DatabaseHandler dh;

        [TestInitialize]
        public void Initialize()
        {
            this.dh = new DatabaseHandler();
        }

        [TestCategory("staff")]
        [TestMethod]
        public void AllApprovedReportsTest()
        {
            var ds = dh.AllApprovedReports();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Assert.AreEqual("Approved", row["StatusReport"].ToString());
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
        //[TestCategory("staff")]
        //[TestMethod]
        [TestCategory("staff")]
        [TestMethod]
        public void ReturnDepExpensesMadeTest()
        {
            Assert.AreEqual(0, dh.ReturnDepartmentExpensesMade("LogisticServices"));
        }

        [TestCategory("staff")]
        [TestMethod]
        public void LoadRejectedInfoTest()
        {
            var ds = dh.LoadStaffUnapprovedReportInfo("The Big Meeting");
            Assert.AreEqual("dsfdsfds", ds.Tables[0].Rows[0]["Location"].ToString());
        }

        [TestCategory("staff")]
        [TestMethod]
        public void LoadRejectedReportNames()
        {
            var ds = dh.LoadStaffUnapprovedReportNames();
            Assert.AreEqual("The Big Meeting", ds.Tables[0].Rows[0]["ReportName"].ToString());
        }

        [TestCategory("staff")]
        [TestMethod]
        //this test I am unsure about.
        public void UpdateDeptBudgetTest()
        {
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.UpdateDepartmentBudget("LogisticServices", 1.2);
                Assert.AreEqual(424537.31, dh.ReturnDepartmentExpensesMade("HigherEducation"));

                // not sure if you need this, as the transaction should dispose at the end of the using block.
                TestTransaction.Dispose();
            }
        }
        [TestCategory("staff")]
        [TestMethod]
        public void UnapprovedReportNames()
        {
            var ds = dh.LoadStaffUnapprovedReportNames();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Assert.AreEqual("Approved", row["StatusReport"].ToString());
            }
        }
        [TestCategory("staff")]
        [TestMethod]
        public void LoadStaffUnapprovedInfoTest()
        {
            var ds = dh.LoadStaffUnapprovedReportInfo("bacon");
            Assert.AreEqual("james", ds.Tables[0].Rows[0]["name"].ToString());
        }

        [TestCategory("staff")]
        [TestMethod]
        public void CurrentDeptBudgetTest()
        {
            // This test isn't testing anything different across departments - perhaps make LogisticServices return a different number
            var result = dh.ReturnCurrentDepartmentMoney("HigherEducation");
            Assert.AreEqual(10000.00, result);
            result = dh.ReturnCurrentDepartmentMoney("LogisticServices");
            Assert.AreEqual(10000.000, result);
        }

        [TestCategory("staff")]
        [TestMethod]
        public void DenyReportTest()
        {
            // Would strongly recommend combining all the parameters of ConsultantsInsertExpenseQuery into
            // their own class, as this is way too many parameters for one function that looks pretty simple at
            // first glance.

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
        public void ConsultantTest()
        {
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.ConsultantsInsertExpenseQuery("CONSULTANTSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "LogisticServices", DateTime.Today);
                DataSet dsInprogress = dh.ConsultantLoadInProgressReports("Hugh");
                Assert.AreEqual(1, dsInprogress.Tables[0].Rows.Count);
                dh.ConsultantsInsertExpenseQuery("CONSULTANTSUPERTEST", "Hugh", "work", "ICac Champagne, 1959 was a good year", 3000, "AUD", "LogisticServices", DateTime.Today);
                DataSet dsSubmitted = dh.ConsultantLoadSubmittedReports("hugh");
                Assert.AreEqual(1, dsSubmitted.Tables[0].Rows.Count);
                DataSet dsApproved = dh.ConsultantLoadApprovedReports("hugh");
                Assert.AreEqual(0, dsApproved.Tables[0].Rows.Count);
                TestTransaction.Dispose();
            }
        }
        [TestCategory("Supervisor")]
        [TestMethod]
        public void SupervisorTest()
        {

            DatabaseHandler dh = new DatabaseHandler();
            using (TransactionScope TestTransaction = new TransactionScope())
            {

                dh.ConsultantsInsertExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "LogisticServices", DateTime.Today);
                dh.ConsultantsInsertExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "LogisticServices", DateTime.Today);
               DataSet dsDepartmentSupervisor = dh.LoadDepartmentSupervisorData("LogisticServices");
               int i = 0;
               bool resultDepsup= false;
               while (i < dsDepartmentSupervisor.Tables[0].Rows.Count)
               {
                   if (dsDepartmentSupervisor.Tables[0].Rows[i]["ReportName"].ToString() == "SUPERVISORSUPERTEST" && dsDepartmentSupervisor.Tables[0].Rows[i]["ConsultantName"].ToString() == "Hugh")
                   {
                       resultDepsup = true;
                       break;
                   }
                   i++;
               }
               Assert.AreEqual(true, resultDepsup);
               DataSet dsExpenseSupervisor = dh.LoadExpenseTable("SUPERVISORSUPERTEST");
               Assert.AreEqual("Hugh", dsExpenseSupervisor.Tables[0].Rows[0]["Name"].ToString());
               dh.ApproveReportSupervisor("SuperSupervisor", "SUPERVISORSUPERTEST");
               dh.UpdateDepartmentBudget("LogisticServices", 3001.00);



              
                 

                TestTransaction.Dispose();
            }
        }

        //currency tests below here
        [TestCategory("Currency")]
        [TestMethod]
        public void TestEUR()
        {
            var expected = CurrencyConverter.ConvertCurrencyToAUD("EUR", 1);
            Assert.AreEqual(0.680265, expected);
        }

        [TestCategory("Currency")]
        [TestMethod]
        public void TestCAD()
        {
            var expected = CurrencyConverter.ConvertCurrencyToAUD("CNY", 1);
            Assert.AreEqual(1.03215, expected);

        }
        [TestCategory("Currency")]
        [TestMethod]
        public void TestCurrencyConvertFails()
        {
            var expected = CurrencyConverter.ConvertCurrencyToAUD("fsd", 1);
            Assert.AreEqual(-1.0, expected);

        }


    }
}
