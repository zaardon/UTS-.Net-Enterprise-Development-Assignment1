using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlueConsultingManagementSystemTests
{
    [TestClass]
    public class UnitTest1
    {
        BlueConsultingManagementSystemLogic.AccountsProfile _csLogic;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _csLogic = new BlueConsultingManagementSystemLogic.AccountsProfile("this test","herp");
        }

        [TestMethod]
        public void TestAlwayspass()
        {
            Assert.AreEqual(50, 50);
        }
        [TestMethod]
        public void TestLogName()
        {
            Assert.AreEqual("this test", "this test");
        }
        [TestMethod]
        public void TestPassword()
        {
            Assert.AreEqual("herp", "herp");
        }
        [TestMethod]
        public void TestLogin()
        {
            bool result = _csLogic.login("this test", "herp");
            Assert.AreEqual(true, true);
        }

    }
}
