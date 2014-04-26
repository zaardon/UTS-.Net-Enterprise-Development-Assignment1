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
        public DatabaseHandler dh = new DatabaseHandler();


        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void AllApprovedReportsTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    DataSet ds = dh.ReturnAllApprovedReports();
        ////    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        ////    {
        ////        String testify = ds.Tables[0].Rows[j]["StatusReport"].ToString();
        ////        Assert.AreEqual("Approved", testify);
        ////    }
        ////}
        //////[TestCategory("staff")]
        //////[TestMethod]
        //////public void DenyReportForSupervisor()
        //////{
        //////    DatabaseHandler dh = new DatabaseHandler();
        //////    using (TransactionScope TestTransaction = new TransactionScope())
        //////    {
        //////        dh.DenyReportForSupervisor("supervisor", "JamesLoves");
        //////        DataSet ds = dh.ReturnRejectedReportNamesForSupervisor();
        //////        Assert.AreEqual("JamesLoves", ds.Tables[0].Rows[""].Contains);
        //////fell asleep at keyboard commiting and going to sleep.
        //////        TestTransaction.Dispose();
        //////    }
        //////}
        //////[TestCategory("staff")]
        //////[TestMethod]
        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void ReturnDepExpensesMadeTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    double result = dh.ReturnDepartmentExpensesMade("Logistic Services");
        ////    Assert.AreEqual(0, result);
        ////}
        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void LoadRejectedInfoTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    DataSet ds = dh.LoadStaffUnapprovedReportInfo("The Big Meeting");
        ////    Assert.AreEqual("dsfdsfds", ds.Tables[0].Rows[0]["Location"].ToString());
        ////}
        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void ReturnRejectedReportNamesForSupervisor()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    DataSet ds = dh.ReturnUnapprovedReportNamesForStaff();
        ////    string result = ds.Tables[0].Rows[0]["ReportName"].ToString();
        ////    Assert.AreEqual("The Big Meeting", result);
        ////}
        ////[TestCategory("staff")]
        ////[TestMethod]
        //////this test I am unsure about.
        ////public void UpdateDeptBudgetTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////     using (TransactionScope TestTransaction = new TransactionScope())
        ////    {
        ////        dh.UpdateDepartmentBudget("Logistic Services", 1.2);
        ////        double result = dh.ReturnDepartmentExpensesMade("Higher Education");
        ////        Assert.AreEqual(424537.31, result);

        ////        TestTransaction.Dispose();
        ////    }
        ////}
        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void UnapprovedReportNames()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    DataSet ds = dh.ReturnUnapprovedReportNamesForStaff();
        ////    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        ////    {
        ////        String teststatus = ds.Tables[0].Rows[j]["StatusReport"].ToString();
        ////        Assert.AreEqual("Approved", teststatus);

        ////    }
        ////}
        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void LoadStaffUnapprovedInfoTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    DataSet ds = dh.LoadStaffUnapprovedReportInfo("bacon");
        ////    string result = ds.Tables[0].Rows[0]["name"].ToString();
        ////    Assert.AreEqual("james",result);

        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void CurrentDeptBudgetTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    double result = dh.ReturnCurrentDepartmentMoney("Higher Education");
        ////    //Assert.AreEqual(10000.000, result);
        ////    result = dh.ReturnCurrentDepartmentMoney("Logistic Services");
        ////    Assert.AreEqual(10000.000, result);
        ////}
        ////[TestCategory("staff")]
        ////[TestMethod]
        ////public void DenyReportTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    using (TransactionScope TestTransaction = new TransactionScope())
        ////    {

        ////        dh.InsertConsultantExpenseQuery("testReport", "test", "test", "test", 12.04, "AUD", "TestDept", DateTime.Today);
        ////       // dh.DenyReportForStaffMember("testReport");
        ////        var selectCommand = new SqlCommand("select ReportName,StaffApproved from [dbo].[ExpenseDB] where ReportName='testReport';", dh.SQLConnection);
        ////        var adapter = new SqlDataAdapter(selectCommand);
        ////        var resultSet = new DataSet();
        ////        adapter.Fill(resultSet);
        ////        string testify = resultSet.Tables[0].Rows[0]["StaffApproved"].ToString();
        ////        Assert.AreEqual("NO", testify);
        ////        TestTransaction.Dispose();
        ////    }
        ////}
        //// [TestCategory("staff")]
        ////[TestMethod]
        ////public void ApproveReportTest()
        ////{
        ////    DatabaseHandler dh = new DatabaseHandler();
        ////    using (TransactionScope TestTransaction = new TransactionScope())
        ////    {

        ////        dh.InsertConsultantExpenseQuery("testReport", "test", "test", "test", 12.04, "AUD", "TestDept", DateTime.Today);
        ////        dh.ApproveReportForStaffMember("testReport");
        ////        var selectCommand = new SqlCommand("select ReportName,StaffApproved from [dbo].[ExpenseDB] where ReportName='testReport';", dh.SQLConnection);
        ////        var adapter = new SqlDataAdapter(selectCommand);
        ////        var resultSet = new DataSet();
        ////        adapter.Fill(resultSet);
        ////        string testify = resultSet.Tables[0].Rows[0]["StaffApproved"].ToString();
        ////        Assert.AreEqual("YES", testify);
        ////        TestTransaction.Dispose();
        ////    }
        ////}
        ////INSERTION TEST METHOD.


        //[TestCategory("Consultant")]
        //[TestMethod]
        //public void ConsultantTest()
        //{

        //    using (TransactionScope TestTransaction = new TransactionScope())
        //    {

        //        dh.InsertConsultantExpenseQuery("CONSULTANTSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "Logistic Services", DateTime.Today);
        //        DataSet dsInprogress = dh.ReturnConsultantInProgressReports("Hugh");
        //        Assert.AreEqual(1, dsInprogress.Tables[0].Rows.Count);
        //        dh.InsertConsultantExpenseQuery("CONSULTANTSUPERTEST", "Hugh", "work", "ICac Champagne, 1959 was a good year", 3000, "AUD", "Logistic Services", DateTime.Today);
        //        DataSet dsSubmitted = dh.ReturnConsultantSubmittedReports("hugh");
        //        Assert.AreEqual(1, dsSubmitted.Tables[0].Rows.Count);
        //        DataSet dsApproved = dh.ReturnConsultantApprovedReports("hugh");
        //        Assert.AreEqual(0, dsApproved.Tables[0].Rows.Count);
        //        TestTransaction.Dispose();
        //    }

        //    //}
        //    //[TestCategory("Supervisor")]
        //    //[TestMethod]
        //    //public void SupervisorTest1()
        //    //{

        //    //    DatabaseHandler dh = new DatabaseHandler();
        //    //    using (TransactionScope TestTransaction = new TransactionScope())
        //    //    {

        //    //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "Logistic Services", DateTime.Today);
        //    //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "Logistic Services", DateTime.Today);
        //    //        DataSet dsDepartmentSupervisor = dh.ReturnSubmittedReportsForDepartmentSupervisor("Logistic Services");
        //    //       int i = 0;
        //    //       bool resultDepsup= false;
        //    //       while (i < dsDepartmentSupervisor.Tables[0].Rows.Count)
        //    //       {
        //    //           if (dsDepartmentSupervisor.Tables[0].Rows[i]["Report Name"].ToString() == "SUPERVISORSUPERTEST" && dsDepartmentSupervisor.Tables[0].Rows[i]["Consultant Name"].ToString() == "Hugh")
        //    //           {
        //    //               resultDepsup = true;
        //    //               break;
        //    //           }
        //    //           i++;
        //    //       }
        //    //       Assert.AreEqual(true, resultDepsup);
        //    //       DataSet dsExpenseSupervisor = dh.ReturnExpenseTable("SUPERVISORSUPERTEST", "Logistic Services");
        //    //       Assert.AreEqual("Hugh", dsExpenseSupervisor.Tables[0].Rows[0]["Consultant Name"].ToString());
        //    //       dh.ApproveReportForSupervisor("SuperSupervisor", "SUPERVISORSUPERTEST", "Logistic Services");
        //    //       dh.UpdateDepartmentBudget("Logistic Services", 3001.00);
        //    //       DataSet dsStatus = dh.ReturnConsultantSubmittedReports("Hugh");
        //    //       Assert.AreEqual("Approved", dsStatus.Tables[0].Rows[0]["Supervisor Approval"].ToString());

        //    //       var selectCommand = new SqlCommand("select Budget from [dbo].[DepartmentDB] where Dept_Name='Logistic Services';", dh.SQLConnection);
        //    //       var adapter = new SqlDataAdapter(selectCommand);
        //    //       var resultSet = new DataSet();
        //    //       adapter.Fill(resultSet);
        //    //       Assert.AreEqual(6999, dh.ReturnCurrentDepartmentMoney("Logistic Services"));
        //    //        TestTransaction.Dispose();
        //    //    }

        //    //    //deny route
        //    //    using (TransactionScope TestTransaction = new TransactionScope())
        //    //    {

        //    //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "Logistic Services", DateTime.Today);
        //    //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 1500.50, "AUD", "Logistic Services", DateTime.Today);
        //    //        DataSet dsDepartmentSupervisor = dh.ReturnSubmittedReportsForDepartmentSupervisor("Logistic Services");
        //    //        int i = 0;
        //    //        bool resultDepsup = false;
        //    //        while (i < dsDepartmentSupervisor.Tables[0].Rows.Count)
        //    //        {
        //    //            if (dsDepartmentSupervisor.Tables[0].Rows[i]["Report Name"].ToString() == "SUPERVISORSUPERTEST" && dsDepartmentSupervisor.Tables[0].Rows[i]["Consultant Name"].ToString() == "Hugh")
        //    //            {
        //    //                resultDepsup = true;
        //    //                break;
        //    //            }
        //    //            i++;
        //    //        }
        //    //        Assert.AreEqual(true, resultDepsup);
        //    //        DataSet dsExpenseSupervisor = dh.ReturnExpenseTable("SUPERVISORSUPERTEST", "Logistic Services");
        //    //        Assert.AreEqual("Hugh", dsExpenseSupervisor.Tables[0].Rows[0]["Consultant Name"].ToString());
        //    //        dh.DenyReportForSupervisor("SuperSupervisor", "SUPERVISORSUPERTEST", "Logistic Services");
        //    //        DataSet dsStatus = dh.ReturnConsultantSubmittedReports("Hugh");
        //    //        Assert.AreEqual("Declined", dsStatus.Tables[0].Rows[0]["Supervisor Approval"].ToString());
        //    //        TestTransaction.Dispose();
        //    //    }
        //}


        //[TestCategory("Staff")]
        //[TestMethod]
        //public void StaffTest1()
        //{
        //    DatabaseHandler dh = new DatabaseHandler();
        //    using (TransactionScope TestTransaction = new TransactionScope())
        //    {

        //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 50.00, "AUD", "Logistic Services", DateTime.Today);
        //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 50.00, "AUD", "Logistic Services", DateTime.Today);
        //        DataSet dsDepartmentSupervisor = dh.ReturnSubmittedReportsForDepartmentSupervisor("Logistic Services");
        //        int i = 0;
        //        bool resultDepsup = false;
        //        while (i < dsDepartmentSupervisor.Tables[0].Rows.Count)
        //        {
        //            if (dsDepartmentSupervisor.Tables[0].Rows[i]["Report Name"].ToString() == "SUPERVISORSUPERTEST" && dsDepartmentSupervisor.Tables[0].Rows[i]["Consultant Name"].ToString() == "Hugh")
        //            {
        //                resultDepsup = true;
        //                break;
        //            }
        //            i++;
        //        }
        //        Assert.AreEqual(true, resultDepsup);
        //        DataSet dsExpenseSupervisor = dh.ReturnExpenseTable("SUPERVISORSUPERTEST", "Logistic Services");
        //        Assert.AreEqual("Hugh", dsExpenseSupervisor.Tables[0].Rows[0]["Consultant Name"].ToString());
        //        dh.ApproveReportForSupervisor("SuperSupervisor", "SUPERVISORSUPERTEST", "Logistic Services");
        //        dh.UpdateDepartmentBudget("Logistic Services", 100.00);

        //        //DataSet dsStatus = dh.ReturnConsultantSubmittedReports("Hugh");
        //        //Assert.AreEqual("Approved", dsStatus.Tables[0].Rows[0]["StatusReport"].ToString());
        //        //Assert.AreEqual(9900, dh.ReturnCurrentDepartmentMoney("Logistic Services"));
        //        dh.ApproveReportForStaffMember("SUPERVISORSUPERTEST", "Logistic Services");
        //        var selectCommand = new SqlCommand("select ReportName,StaffApproved from [dbo].[ExpenseDB] where ReportName='SUPERVISORSUPERTEST';", dh.SQLConnection);
        //        var adapter = new SqlDataAdapter(selectCommand);
        //        var resultSet = new DataSet();
        //        adapter.Fill(resultSet);
        //        string testify = resultSet.Tables[0].Rows[0]["StaffApproved"].ToString();
        //        Assert.AreEqual("Approved", testify);
        //        TestTransaction.Dispose();
        //    }

        //    using (TransactionScope TestTransaction = new TransactionScope())
        //    {

        //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 50.00, "AUD", "Logistic Services", DateTime.Today);
        //        dh.InsertConsultantExpenseQuery("SUPERVISORSUPERTEST", "Hugh", "Home", "Doing testing peasants", 50.00, "AUD", "Logistic Services", DateTime.Today);
        //        DataSet dsDepartmentSupervisor = dh.ReturnSubmittedReportsForDepartmentSupervisor("Logistic Services");
        //        int i = 0;
        //        bool resultDepsup = false;
        //        while (i < dsDepartmentSupervisor.Tables[0].Rows.Count)
        //        {
        //            if (dsDepartmentSupervisor.Tables[0].Rows[i]["Report Name"].ToString() == "SUPERVISORSUPERTEST" && dsDepartmentSupervisor.Tables[0].Rows[i]["Consultant Name"].ToString() == "Hugh")
        //            {
        //                resultDepsup = true;
        //                break;
        //            }
        //            i++;
        //        }
        //        Assert.AreEqual(true, resultDepsup);
        //        DataSet dsExpenseSupervisor = dh.ReturnExpenseTable("SUPERVISORSUPERTEST", "Logistic Services");
        //        Assert.AreEqual("Hugh", dsExpenseSupervisor.Tables[0].Rows[0]["Consultant Name"].ToString());
        //        dh.ApproveReportForSupervisor("SuperSupervisor", "SUPERVISORSUPERTEST", "Logistic Services");
        //        dh.UpdateDepartmentBudget("Logistic Services", 100.00);
        //        DataSet dsStatus = dh.ReturnConsultantSubmittedReports("Hugh");
        //        Assert.AreEqual("Approved", dsStatus.Tables[0].Rows[0]["Supervisor Approval"].ToString());
        //        Assert.AreEqual(9900, dh.ReturnCurrentDepartmentMoney("Logistic Services"));
        //        dh.DenyReportForStaffMember("SUPERVISORSUPERTEST", 100.00, "Logistic Services");
        //        var selectCommand = new SqlCommand("select ReportName,StaffApproved from [dbo].[ExpenseDB] where ReportName='SUPERVISORSUPERTEST';", dh.SQLConnection);
        //        var adapter = new SqlDataAdapter(selectCommand);
        //        var resultSet = new DataSet();
        //        adapter.Fill(resultSet);
        //        string testify = resultSet.Tables[0].Rows[0]["StaffApproved"].ToString();
        //        Assert.AreEqual("Declined", testify);
        //        dh.ReturnSingleDepartmentBudgetRemaining("Logistic Services");
        //        TestTransaction.Dispose();
        //    }
        //}




        //currency tests below here
        [TestCategory("Currency")]
        [TestMethod]
        public void TestEUR()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertCurrencyToAUD("EUR", 1);
            Assert.AreEqual(1.49, expected);
        }
        [TestCategory("Currency")]
        [TestMethod]
        public void TestCNY()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertCurrencyToAUD("CNY", 1);
            Assert.AreEqual(0.172175, expected);

        }
        [TestCategory("Currency")]
        [TestMethod]
        public void TestCurrencyConvertFails()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertCurrencyToAUD("fsd", 1);
            Assert.AreEqual(0, expected);

        }
        [TestCategory("InputChecker")]
        [TestMethod]
        public void CheckString()
        {
            InputChecker ic = new InputChecker();
            bool result = ic.HasPunctuationCharacters("'''!@#$%^&*()");
            Assert.AreEqual(true, result);
            result = ic.HasPunctuationCharacters("n0p3");
            Assert.AreEqual(false, result);

        }


        [TestCategory("Consultant")]
        [TestMethod]
        public void ConsultantTest1()
        {

            using (TransactionScope TestTransaction = new TransactionScope())
            {

                dh.InsertConsultantExpenseQuery("ApprovedReport", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.InsertConsultantExpenseQuery("InProgressReport", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);

                var submitted = dh.ReturnConsultantSubmittedReports("User");
                Assert.AreEqual(submitted.Tables[0].Rows[0]["Report Name"].ToString(), "ApprovedReport");
                Assert.AreEqual(submitted.Tables[0].Rows[1]["Report Name"].ToString(), "InProgressReport");

                dh.ApproveReportForSupervisor("Supervisor", "ApprovedReport", "State Services");
                dh.ApproveReportForStaffMember("ApprovedReport", "State Services");
                var approved = dh.ReturnConsultantApprovedReports("User");
                Assert.AreEqual(approved.Tables[0].Rows[0]["Report Name"].ToString(), "ApprovedReport");

                var inprogress = dh.ReturnConsultantInProgressReports("User");
                Assert.AreEqual(inprogress.Tables[0].Rows[0]["Report Name"].ToString(), "InProgressReport");

                TestTransaction.Dispose();
            }
        }


        [TestCategory("Supervisor")]
        [TestMethod]
        public void SupervisorTest()
        {
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.InsertConsultantExpenseQuery("StateServicesReport1", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.InsertConsultantExpenseQuery("StateServicesReport2", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.InsertConsultantExpenseQuery("LogisticServicesReport1", "User", "Location", "Description", 100.00, "AUD", "Logistic Services", DateTime.Today);

                var unapproved = dh.ReturnSubmittedReportsForDepartmentSupervisor("State Services");
                string deptType1 = unapproved.Tables[0].Rows[0]["Report Name"].ToString();
                Assert.AreEqual(deptType1, "StateServicesReport1");
                string deptType2 = unapproved.Tables[0].Rows[1]["Report Name"].ToString();
                Assert.AreEqual(deptType2, "StateServicesReport2");

                unapproved = dh.ReturnSubmittedReportsForDepartmentSupervisor("Logistic Services");
                Assert.AreEqual(unapproved.Tables[0].Rows[0]["Report Name"].ToString(), "LogisticServicesReport1");
                TestTransaction.Dispose();
            }

            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "State Services");

                var selectCommand = new SqlCommand("select StatusReport from [dbo].[ExpenseDB] where StatusReport='Approved' AND ReportName='ApprovedTest1';", dh.RetrieveSQLConnection());
                var adapter = new SqlDataAdapter(selectCommand);
                var report = new DataSet();
                adapter.Fill(report);

                string testify = report.Tables[0].Rows[0]["StatusReport"].ToString();
                Assert.AreEqual(testify, "Approved");
                TestTransaction.Dispose();
            }

            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.InsertConsultantExpenseQuery("UnapprovedTest1", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.DenyReportForSupervisor("Supervisor", "UnapprovedTest1", "State Services");

                var selectCommand = new SqlCommand("select StatusReport from [dbo].[ExpenseDB] where StatusReport='Declined' AND ReportName='UnapprovedTest1';", dh.RetrieveSQLConnection());
                var adapter = new SqlDataAdapter(selectCommand);
                var report = new DataSet();
                adapter.Fill(report);

                string testify = report.Tables[0].Rows[0]["StatusReport"].ToString();
                Assert.AreEqual(testify, "Declined");
                TestTransaction.Dispose();
            }


            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "State Services");
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest2", "State Services");

                double expenses = dh.ReturnDepartmentExpensesMade("State Services");
                Assert.AreEqual(expenses, 200);
                TestTransaction.Dispose();
            }

            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.ApproveReportForStaffMember("ApprovedTest1", "State Services");
                dh.ApproveReportForStaffMember("ApprovedTest2", "State Services");
                dh.UpdateDepartmentBudget("State Services", 200.00);
                double currentMoney = dh.ReturnCurrentDepartmentMoney("State Services");
                Assert.AreEqual(currentMoney, 9800);
                TestTransaction.Dispose();
            }


            using (TransactionScope TestTransaction = new TransactionScope())
            {
                dh.InsertConsultantExpenseQuery("RejectedTest1", "User", "Location", "Description", 200.00, "AUD", "Higher Education", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "RejectedTest1", "Higher Education");
                dh.DenyReportForStaffMember("RejectedTest1", 100.00, "Higher Education");

                dh.InsertConsultantExpenseQuery("RejectedTest2", "User", "Location", "Description", 200.00, "AUD", "Higher Education", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "RejectedTest2", "Higher Education");
                dh.DenyReportForStaffMember("RejectedTest2", 200.00, "Higher Education");

                var rejected = dh.ReturnRejectedReportNamesForSupervisor("Higher Education", "Supervisor");

                Assert.AreEqual(rejected.Tables[0].Rows[0]["Report Name"].ToString(), "RejectedTest1");
                Assert.AreEqual(rejected.Tables[0].Rows[1]["Report Name"].ToString(), "RejectedTest2");

                TestTransaction.Dispose();
            }

        }

        [TestCategory("Staff")]
        [TestMethod]
        public void StaffTest()
        {
            //higher edu = AlsoTest
            //logic = Test

            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "Test", DateTime.Today);
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 200.00, "AUD", "AlsoTest", DateTime.Today);

                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "Test");
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest2", "AlsoTest");

                var ds = dh.ReturnUnapprovedReportNamesForStaff();

                Assert.AreEqual("ApprovedTest1", ds.Tables[0].Rows[0]["Report Name"].ToString());
                Assert.AreEqual("ApprovedTest2", ds.Tables[0].Rows[1]["Report Name"].ToString());

                dh.ApproveReportForStaffMember("ApprovedTest1", "Test");
                dh.ApproveReportForStaffMember("ApprovedTest2", "AlsoTest");
                TestTransaction.Dispose();
            }

            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "Test", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor1", "ApprovedTest1", "Test");
                dh.UpdateDepartmentBudget("Test", 100.00);
                dh.ApproveReportForStaffMember("ApprovedTest1", "Test");

                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 200.00, "AUD", "AlsoTest", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor2", "ApprovedTest2", "AlsoTest");
                dh.UpdateDepartmentBudget("AlsoTest", 200.00);
                dh.ApproveReportForStaffMember("ApprovedTest2", "AlsoTest");

                var dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    if (dsStaffExpenses.Tables[0].Rows[i]["Supervisor Name"].ToString() == "Supervisor1")
                    {
                        var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                        Assert.AreEqual(totalAUD, (Decimal)100.0000);
                    }
                    if (dsStaffExpenses.Tables[0].Rows[i]["Supervisor Name"].ToString() == "Supervisor2")
                    {
                        var totalAUD2 = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                        Assert.AreEqual(totalAUD2, (Decimal)200.0000);
                    }
                }
                dh.InsertConsultantExpenseQuery("ApprovedTest3", "User", "Location", "Description", 500.00, "AUD", "Test", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor1", "ApprovedTest3", "Test");
                dh.UpdateDepartmentBudget("Test", 500.00);
                dh.ApproveReportForStaffMember("ApprovedTest3", "Test");

                dsStaffExpenses = dh.ReturnStaffApprovedExpenses();

                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    if (dsStaffExpenses.Tables[0].Rows[i]["Supervisor Name"].ToString() == "Supervisor1")
                    {
                        var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                        Assert.AreEqual(totalAUD, (Decimal)600.0000);
                    }
                }

                TestTransaction.Dispose();


            }

            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                var dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                double AmountMissing=0.0;
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                        var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                        AmountMissing = AmountMissing + Convert.ToDouble(totalAUD);
                }
                double budget = dh.ReturnTotalBudgetRemaining();
                Assert.AreEqual((50000.00 - AmountMissing) , budget);
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "State Services");
                dh.ApproveReportForStaffMember("ApprovedTest1", "State Services");
                dh.UpdateDepartmentBudget("State Services", 100.00);
                budget = dh.ReturnTotalBudgetRemaining();
                dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                AmountMissing = 0.0;
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                    AmountMissing = AmountMissing + Convert.ToDouble(totalAUD);
                }
                Assert.AreEqual((49900.00 - (AmountMissing-100)), budget);
         

                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 100.00, "AUD", "State Services", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest2", "State Services");
                dh.ApproveReportForStaffMember("ApprovedTest2", "State Services");
                dh.UpdateDepartmentBudget("State Services", 100.00);
                budget = dh.ReturnTotalBudgetRemaining();
                dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                AmountMissing = 0.0;
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                    AmountMissing = AmountMissing + Convert.ToDouble(totalAUD);
                }
                Assert.AreEqual((49800.00 - (AmountMissing - 200)), budget);

                double approved = dh.ReturnTotalStaffExpensesApproved();
                Assert.AreEqual(Convert.ToDouble(approved),SetSigFigs(AmountMissing, 5));

                TestTransaction.Dispose();
            }


        }
        public void StaffSetupDepartment()
        {
            dh.RetrieveSQLConnection().Open();
            string cmd = "INSERT INTO [dbo].[DepartmentDB] ( [Dept_Name], [Budget]) VALUES ( N'Test', CAST(10000.0000 AS Money))";
            string cmd2 = "INSERT INTO [dbo].[DepartmentDB] ( [Dept_Name], [Budget]) VALUES ( N'AlsoTest', CAST(10000.0000 AS Money))";
            SqlCommand sqlcmd = new SqlCommand(cmd, dh.RetrieveSQLConnection());
            sqlcmd.ExecuteNonQuery();
            sqlcmd = new SqlCommand(cmd2, dh.RetrieveSQLConnection());
            sqlcmd.ExecuteNonQuery();
            dh.RetrieveSQLConnection().Close();
        }

        public static double SetSigFigs(double d, int digits)
        {
            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);

            return scale * Math.Round(d / scale, digits);
        }


    }
}
