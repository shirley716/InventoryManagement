using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
namespace InventoryManagement.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var user = new User("david","DAVID","123456","1234567890");
            Assert.IsTrue(user.Ufullname == "DAVID");
            Assert.IsTrue(user.Uname == "david");
            Assert.IsTrue(user.Upassword == "123456");
            Assert.IsTrue(user.Uphone== "1234567890");

        }
    }
}
