using System.Configuration;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    public class BlogEngineTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs(ConfigurationManager.AppSettings["login"])
                .WithPassword(ConfigurationManager.AppSettings["pass"])
                .Login();
        }

        [TestCleanup]

        public void Cleanup()
        {
            Driver.Close();
            Driver.WaitOneSecond();
        }
    }
}
