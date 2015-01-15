using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class CreateAndDeletePageTest : BlogEngineTest
    {
        [TestMethod]
        public void Create_Delete_Page()
        {
            var title = Guid.NewGuid().ToString();
            var body = Guid.NewGuid().ToString();

            ListPage.GoTo();
            ListPage.AddNewPage();

            ListPage.InitPage().WithTitle(title).WithBody(body).Save();

            ListPage.GoTo();
            ListPage.SearchNewPage(title);
            ListPage.GoToHomePage();

            Driver.SwitchToNewWindow();
            
            Assert.IsTrue(HomePage.HasPage(title));

            Driver.SwitchToOriginalWindow();

            ListPage.SearchNewPage(title);
            ListPage.DeleteThisPage();

            Assert.IsFalse(ListPage.HasThispage(title));
        }
    }
}
