using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using doctor;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DemoTest obj = new DemoTest();
            Assert.AreEqual("admin", obj.username);
            Assert.AreEqual("k05t21998", obj.password);
        }
    }
}
