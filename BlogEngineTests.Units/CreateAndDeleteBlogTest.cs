using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class CreateAndDeleteBlogTest : BlogEngineTest
    {
        [TestMethod]
        public void Create_Delete_Blog()
        {
            var name = Guid.NewGuid().ToString();
            var admin = Guid.NewGuid().ToString();
            var mail = Guid.NewGuid() + "@test.com";
            var pass = Guid.NewGuid().ToString();

            BlogsPage.GoTo();
            BlogsPage.AddNew();

            BlogsPage.InitBlog().WithBlogName(name).WithAdmin(admin).WithMail(mail).WithPass(pass).Save();
            BlogsPage.SearchBlog(name);
            BlogsPage.GoToHomePage();

            Driver.SwitchToNewWindow();

            Assert.IsTrue(HomePage.HasTitle(name));

            Driver.SwitchToOriginalWindow();

            BlogsPage.GoTo();
            BlogsPage.DeleteBlog();

            Assert.IsFalse(BlogsPage.IsBlogInTheList(name));
        }
    }
}
