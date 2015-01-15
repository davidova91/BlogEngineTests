using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class LogOffTest : BlogEngineTest
    {
        [TestMethod]
        public void Can_Log_Off_By_Site()
        {
            HomePage.LogOff();

            Assert.IsFalse(HomePage.IsAuthorized);
        }
    }
}
