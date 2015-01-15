using System;
using BlogEngineTests.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogEngineTests.Units
{
    [TestClass]
    public class CreateAndDeleteUserTest : BlogEngineTest
    {
        [TestMethod]
        public void Create_Delete_User()
        {
            var name = Guid.NewGuid().ToString();
            var mail = Guid.NewGuid() + "@test.com";
            var pass = Guid.NewGuid().ToString();
            const string role = "Editors";

            UserPage.GoTo();
            UserPage.AddNewUser();
            UserPage.InitNewUser().WithName(name).WithMail(mail).WithPassword(pass).ChoiseRole(role).Save();
            UserPage.SearchUser(name);

            Assert.IsTrue(UserPage.IsUserInTheList(name));

            UserPage.DeleteUser(name);

            Assert.IsFalse(UserPage.IsUserInTheList(name));
        }
    }
}

