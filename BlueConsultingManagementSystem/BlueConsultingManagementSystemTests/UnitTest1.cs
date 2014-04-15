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
        [TestMethod]
        public void AddExpense()
        {
            DatabaseHandler dh = new DatabaseHandler();
            //using (TransactionScope TestTransaction = new TransactionScope())
           // {
                
                dh.ConsultantsInsertExpenseQuery("test", "test", "test", "test", 12.04 , "AUD","TestDept" ,DateTime.Today );
                var selectCommand = new SqlCommand("select ReportName from [dbo].[ExpenseDB] where ReportName='test';", dh.SQLConnection);
                var adapter = new SqlDataAdapter(selectCommand);
                var resultSet = new DataSet();
                adapter.Fill(resultSet);
                string testify = resultSet.Tables[0].Rows[0]["ReportName"].ToString();
                Assert.AreEqual("test", testify);
               // TestTransaction.Dispose();
            //}

        }

    }
}
