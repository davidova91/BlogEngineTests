using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class LoginTest : BlogEngineTest
    {
        [TestMethod]
        public void Admin_Can_Login()
        {
            Assert.IsTrue(HomePage.IsAuthorized);
       }
    }
}
