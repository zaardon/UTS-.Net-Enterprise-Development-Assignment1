using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlueConsultingManagementSystemTests
{
    [TestClass]
    public class UnitTest1
    {
        BlueConsultingManagementSystemLogic.Class1 _csLogic;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void Setup()
        {
            _csLogic = new BlueConsultingManagementSystemLogic.Class1();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(50, 50);
        }
    }
}
