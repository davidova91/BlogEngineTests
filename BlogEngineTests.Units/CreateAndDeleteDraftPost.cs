using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class CreateAndDeleteDraftPost : BlogEngineTest
    {
        [TestMethod]
        public void Create_Delete_Draft_Post()
        {
            var title = Guid.NewGuid().ToString();
            var body = Guid.NewGuid().ToString();

            PostPage.GoTo();
            PostPage.WriteNewPost();

            PostPage.InitPost().WithTitle(title).WithBody(body).Save();

            PostPage.GoTo();
            PostPage.Draft();
            PostPage.SearchPost(title);
            PostPage.DeletePost();

            Assert.IsFalse(PostPage.IsPostInTheList(title));
        }
    }
}
