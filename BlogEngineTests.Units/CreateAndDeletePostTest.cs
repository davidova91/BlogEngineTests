using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class CreateAndDeletePostTest : BlogEngineTest
    {
        [TestMethod]
        public void Create_Delete_Post()
        {
            var title = Guid.NewGuid().ToString();
            var body = Guid.NewGuid().ToString();

            PostPage.GoTo();
            PostPage.WriteNewPost();

            PostPage.InitPost().WithTitle(title).WithBody(body).Publish();

            PostPage.GoTo();
            PostPage.SearchPost(title);
            PostPage.GoToHomePage();

            Driver.SwitchToNewWindow();

            Assert.IsTrue(HomePage.HasPost(title));

            Driver.SwitchToOriginalWindow();

            PostPage.SearchPost(title);
            PostPage.DeletePost();

            Assert.IsFalse(PostPage.IsPostInTheList(title));
        }
    }
}
