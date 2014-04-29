using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueConsultingManagementSystemLogic;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;




namespace BlueConsultingManagementSystemTests
{
    [TestClass]
    public class BlueConsultingUnitTest
    {
        public DatabaseHandler dh = new DatabaseHandler();
        [TestCategory("Currency")]
        [TestMethod]
        public void CurrencyTest()
        {
            double expected;
            CurrencyConverter cc = new CurrencyConverter();
            expected = cc.ConvertCurrencyToAUD("EUR", 1);
            Assert.AreEqual(1.49, expected);
            expected = cc.ConvertCurrencyToAUD("CNY", 1);
            Assert.AreEqual(0.172175, expected);
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

        // this is the consultant test which tests all methods involved with consultant 
        // 11 methods have been tested.
        // it follows the functionality of consultant and the ouutput methods to the ui
        // adding an expense then checking the expensereports status etc
        [TestCategory("Consultant")]
        [TestMethod]
        public void ConsultantTest()
        {
           
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                bool inUse = dh.CheckReportNameInUse("ApprovedReport");
                Assert.IsFalse(inUse);


                dh.InsertConsultantExpenseQuery("ApprovedReport", "User", "Location", "Description", 100.00, "AUD", "TestDBLogistic", DateTime.Today);
                dh.InsertConsultantExpenseQuery("InProgressReport", "User", "Location", "Description", 100.00, "AUD", "TestDBLogistic", DateTime.Today);


                var submitted = dh.ReturnConsultantSubmittedReports("User");
                Assert.AreEqual(submitted.Tables[0].Rows[0]["Report Name"].ToString(), "ApprovedReport");
                var reportNames = dh.ReturnConsultantSubmittedReports("User");
                Assert.AreEqual(reportNames.Tables[0].Rows[0]["Report Name"].ToString(), "ApprovedReport");
                Assert.AreEqual(reportNames.Tables[0].Rows[1]["Report Name"].ToString(), "InProgressReport");

                var approvedReport = dh.ReturnExpenseTable("ApprovedReport", "TestDBLogistic");
                Assert.AreEqual(approvedReport.Tables[0].Rows[0]["Consultant Name"].ToString(), "User");

                Assert.AreEqual(submitted.Tables[0].Rows[1]["Report Name"].ToString(), "InProgressReport");
                var inprogressReport = dh.ReturnNonRejectedOrApprovedExpenses("InProgressReport", "TestDBLogistic");
                Assert.AreEqual(inprogressReport.Tables[0].Rows[0]["Consultant Name"].ToString(), "User");

                dh.ApproveReportForSupervisor("Supervisor", "ApprovedReport", "TestDBLogistic");
                dh.ApproveReportForStaffMember("ApprovedReport", "TestDBLogistic");
                var approved = dh.ReturnConsultantApprovedReports("User");
                Assert.AreEqual(approved.Tables[0].Rows[0]["Report Name"].ToString(), "ApprovedReport");

                inUse = dh.CheckReportNameInUse("ApprovedReport");
                Assert.IsTrue(inUse);




                var inprogress = dh.ReturnConsultantInProgressReports("User");
                Assert.AreEqual(inprogress.Tables[0].Rows[0]["Report Name"].ToString(), "InProgressReport");

                TestTransaction.Dispose();
            }
        }

        // this is the Supervisor test which tests all methods involved with Supervisor 
        // 12 methods have been tested.
        // it follows the functionality of Supervisor and the output to the ui 
        // approving reports submited by the consultant 
        // approving budgets subtractions or deny consultants, viewing rejected reports 
        [TestCategory("Supervisor")]
        [TestMethod]
        public void SupervisorTest()
        {
            // un approved scope
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("StateServicesReport1", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.InsertConsultantExpenseQuery("StateServicesReport2", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.InsertConsultantExpenseQuery("LogisticServicesReport1", "User", "Location", "Description", 100.00, "AUD", "TestDBLogistic", DateTime.Today);

                var unapproved = dh.ReturnSubmittedReportsForDepartmentSupervisor("TestDBState");
                string deptType1 = unapproved.Tables[0].Rows[0]["Report Name"].ToString();
                Assert.AreEqual(deptType1, "StateServicesReport1");
                string deptType2 = unapproved.Tables[0].Rows[1]["Report Name"].ToString();
                Assert.AreEqual(deptType2, "StateServicesReport2");

                unapproved = dh.ReturnSubmittedReportsForDepartmentSupervisor("TestDBLogistic");
                Assert.AreEqual(unapproved.Tables[0].Rows[0]["Report Name"].ToString(), "LogisticServicesReport1");
                TestTransaction.Dispose();
            }
            // checking supervisor approval
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "TestDBState");

                var selectCommand = new SqlCommand("select StatusReport from [dbo].[ExpenseDB] where StatusReport='Approved' AND ReportName='ApprovedTest1';", dh.RetrieveSQLConnection());
                var adapter = new SqlDataAdapter(selectCommand);
                var report = new DataSet();
                adapter.Fill(report);

                string testify = report.Tables[0].Rows[0]["StatusReport"].ToString();
                Assert.AreEqual(testify, "Approved");
                TestTransaction.Dispose();
            }
            // viewing rejected reports
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("UnapprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.DenyReportForSupervisor("Supervisor", "UnapprovedTest1", "TestDBState");

                var selectCommand = new SqlCommand("select StatusReport from [dbo].[ExpenseDB] where StatusReport='Declined' AND ReportName='UnapprovedTest1';", dh.RetrieveSQLConnection());
                var adapter = new SqlDataAdapter(selectCommand);
                var report = new DataSet();
                adapter.Fill(report);

                string testify = report.Tables[0].Rows[0]["StatusReport"].ToString();
                Assert.AreEqual(testify, "Declined");
                TestTransaction.Dispose();
            }

            // adding to the budget
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "TestDBState");
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest2", "TestDBState");

                double expenses = dh.ReturnDepartmentExpensesMade("TestDBState");
                Assert.AreEqual(expenses, 200);
                TestTransaction.Dispose();
            }
            // checking your department budget
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.ApproveReportForStaffMember("ApprovedTest1", "TestDBState");
                dh.ApproveReportForStaffMember("ApprovedTest2", "TestDBState");
                dh.UpdateDepartmentBudget("TestDBState", 200.00);


                double currentMoney = dh.ReturnCurrentDepartmentMoney("TestDBState");
                Assert.AreEqual(currentMoney, 9800);

                var budgetRemaining = dh.ReturnSingleDepartmentBudgetRemaining("TestDBState");
                Assert.AreEqual(budgetRemaining, 9800.00);
                TestTransaction.Dispose();
            }

            // complex functionality test
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("RejectedTest1", "User", "Location", "Description", 200.00, "AUD", "TestDBHigher", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "RejectedTest1", "TestDBHigher");
                dh.DenyReportForStaffMember("RejectedTest1", 100.00, "TestDBHigher");

                dh.InsertConsultantExpenseQuery("RejectedTest2", "User", "Location", "Description", 200.00, "AUD", "TestDBHigher", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "RejectedTest2", "TestDBHigher");
                dh.DenyReportForStaffMember("RejectedTest2", 200.00, "TestDBHigher");

                var rejected = dh.ReturnRejectedReportNamesForSupervisor("TestDBHigher", "Supervisor");
                var rejectedReport = dh.ReturnRejectedReportExpensesForSupervisor("RejectedTest1", "TestDBHigher");
                Assert.AreEqual(rejectedReport.Tables[0].Rows[0]["Consultant Name"].ToString(), "User");

                Assert.AreEqual(rejected.Tables[0].Rows[0]["Report Name"].ToString(), "RejectedTest1");
                Assert.AreEqual(rejected.Tables[0].Rows[1]["Report Name"].ToString(), "RejectedTest2");

                TestTransaction.Dispose();
            }
        }
        // this is the Staff test which tests all methods involved with Staff 
        // 8 methods have been tested.
        // it follows the functionality of Staff and the output to the ui 
        // approving reports submited by the Supervisors 
        // approving budgets subtractions or deny Supervisors, viewing  reports, total budgets etc 

        [TestCategory("Staff")]
        [TestMethod]
        public void StaffTest()
        {
            
            // approval
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBLogistic", DateTime.Today);
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 200.00, "AUD", "TestDBHigher", DateTime.Today);

                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "TestDBLogistic");
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest2", "TestDBHigher");

                var ds = dh.ReturnUnapprovedReportNamesForStaff();

                Assert.AreEqual("ApprovedTest1", ds.Tables[0].Rows[0]["Report Name"].ToString());
                Assert.AreEqual("ApprovedTest2", ds.Tables[0].Rows[1]["Report Name"].ToString());

                dh.ApproveReportForStaffMember("ApprovedTest1", "TestDBLogistic");
                dh.ApproveReportForStaffMember("ApprovedTest2", "TestDBHigher");
                TestTransaction.Dispose();
            }
            // checking budget approvals , remaining budget
            using (TransactionScope TestTransaction = new TransactionScope())
            {

                StaffSetupDepartment();
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBLogistic", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor1", "ApprovedTest1", "TestDBLogistic");
                dh.UpdateDepartmentBudget("TestDBLogistic", 100.00);
                dh.ApproveReportForStaffMember("ApprovedTest1", "TestDBLogistic");
                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 200.00, "AUD", "TestDBHigher", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor2", "ApprovedTest2", "TestDBHigher");
                dh.UpdateDepartmentBudget("TestDBHigher", 200.00);
                dh.ApproveReportForStaffMember("ApprovedTest2", "TestDBHigher");

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
                dh.InsertConsultantExpenseQuery("ApprovedTest3", "User", "Location", "Description", 500.00, "AUD", "TestDBLogistic", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor1", "ApprovedTest3", "TestDBLogistic");
                dh.UpdateDepartmentBudget("TestDBLogistic", 500.00);
                dh.ApproveReportForStaffMember("ApprovedTest3", "TestDBLogistic");

                dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                var budget = dh.ReturnDepartmentBudgetForStaffExpenses("TestDBLogistic");
                Assert.AreEqual(9400.00, budget);

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
            // all budgets checking total ammounts and multiple approvals
            using (TransactionScope TestTransaction = new TransactionScope())
            {
                StaffSetupDepartment();
                var dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                double AmountMissing = 0.0;
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                    AmountMissing = AmountMissing + Convert.ToDouble(totalAUD);
                }
                double budget = dh.ReturnTotalBudgetRemaining();
                Assert.AreEqual((60000.00 - AmountMissing), budget);
                dh.InsertConsultantExpenseQuery("ApprovedTest1", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);

                Assert.AreEqual(100.00, dh.ReturnReportTotalAmountForStaff("ApprovedTest1", "TestDBState"));

                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest1", "TestDBState");
                dh.ApproveReportForStaffMember("ApprovedTest1", "TestDBState");
                dh.UpdateDepartmentBudget("TestDBState", 100.00);
                budget = dh.ReturnTotalBudgetRemaining();
                dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                AmountMissing = 0.0;
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                    AmountMissing = AmountMissing + Convert.ToDouble(totalAUD);
                }
                Assert.AreEqual((59900.00 - (AmountMissing - 100)), budget);




                dh.InsertConsultantExpenseQuery("ApprovedTest2", "User", "Location", "Description", 100.00, "AUD", "TestDBState", DateTime.Today);
                dh.ApproveReportForSupervisor("Supervisor", "ApprovedTest2", "TestDBState");
                dh.ApproveReportForStaffMember("ApprovedTest2", "TestDBState");
                dh.UpdateDepartmentBudget("TestDBState", 100.00);
                budget = dh.ReturnTotalBudgetRemaining();
                dsStaffExpenses = dh.ReturnStaffApprovedExpenses();
                AmountMissing = 0.0;
                for (int i = 0; i < dsStaffExpenses.Tables[0].Rows.Count; i++)
                {
                    var totalAUD = dsStaffExpenses.Tables[0].Rows[i]["Total in AUD"];
                    AmountMissing = AmountMissing + Convert.ToDouble(totalAUD);
                }
                Assert.AreEqual((59800 - (AmountMissing - 200)), budget);

                double approved = dh.ReturnTotalStaffExpensesApproved();
                Assert.AreEqual(Convert.ToDouble(approved), SetSigFigs(AmountMissing, 5));

                TestTransaction.Dispose();
            }
            

        }
        // setup for testing methods.
        public void StaffSetupDepartment()
        {
            dh.RetrieveSQLConnection().Open();
            string cmd = "INSERT INTO [dbo].[DepartmentDB] ( [Dept_Name], [Budget]) VALUES ( N'TestDBLogistic', CAST(10000.0000 AS Money))";
            string cmd2 = "INSERT INTO [dbo].[DepartmentDB] ( [Dept_Name], [Budget]) VALUES ( N'TestDBHigher', CAST(10000.0000 AS Money))";
            string cmd3 = "INSERT INTO [dbo].[DepartmentDB] ( [Dept_Name], [Budget]) VALUES ( N'TestDBState', CAST(10000.0000 AS Money))";
            SqlCommand sqlcmd = new SqlCommand(cmd, dh.RetrieveSQLConnection());
            sqlcmd.ExecuteNonQuery();
            sqlcmd = new SqlCommand(cmd2, dh.RetrieveSQLConnection());
            sqlcmd.ExecuteNonQuery();
            sqlcmd = new SqlCommand(cmd3, dh.RetrieveSQLConnection());
            sqlcmd.ExecuteNonQuery();
            dh.RetrieveSQLConnection().Close();
        }

        // when testing money amounts it won't assert true is equal unless you round properly
        public static double SetSigFigs(double d, int digits)
        {
            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);

            return scale * Math.Round(d / scale, digits);
        }

    }
}