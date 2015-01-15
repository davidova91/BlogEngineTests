using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class CreateAndDeleteCommentTest : BlogEngineTest
    {
        [TestMethod]
        public void Create_Delete_Comment()
        {
            var title = Guid.NewGuid().ToString();
            var body = Guid.NewGuid().ToString();
            var name = Guid.NewGuid().ToString();
            var mail = Guid.NewGuid() + "@test.com";
            var comment = Guid.NewGuid().ToString();

            PostPage.GoTo();
            PostPage.WriteNewPost();

            PostPage.InitPost().WithTitle(title).WithBody(body).Publish();

            PostPage.GoTo();
            PostPage.SearchPost(title);
            PostPage.GoToHomePage();

            Driver.SwitchToNewWindow();

            HomePage.AddComment().WithName(name).WithMail(mail).WithBody(comment).SaveComment();

            Assert.IsTrue(HomePage.HasCommentOnPage(comment));

            Driver.SwitchToOriginalWindow();

            CommentsPage.GoTo();
            CommentsPage.SearchThisComment(comment);
            CommentsPage.DeleteComment();

            Assert.IsFalse(CommentsPage.IsCommentInTheList(comment));



        }
    }
}
