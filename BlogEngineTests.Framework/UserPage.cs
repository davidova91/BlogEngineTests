using System.Configuration;
using OpenQA.Selenium;

namespace BlogEngineTests.Framework
{
    public class UserPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseAddress"] + "/admin/#/users");
            Driver.WaitOneSecond();
        }

        public static void AddNewUser()
        {
            Driver.Instance.FindElement(By.XPath("//button[@class='btn btn-success btn-header pull-right ng-binding']")).Click();
            Driver.WaitOneSecond();
        }

        public static CreateUserCommand InitNewUser()
        {
            return new CreateUserCommand();
        }

        public static void SearchUser(string name)
        {
            Driver.Instance.FindElement(By.XPath("//input[@class='input-sm form-control search-grid pull-right ng-pristine ng-valid']")).SendKeys(name);
        }

        public static bool IsUserInTheList(string name)
        {
            return Driver.Instance.FindElements(By.LinkText(name)).Count > 0;
        }

        public static void DeleteUser(string name)
        {
            Driver.Instance.FindElement(By.Id("cb-" + name)).Click();
            Driver.Instance.FindElement(By.XPath("//span[@class='btn btn-danger btn-sm ng-binding']")).Click();
            Driver.WaitOneSecond();
        }
    }

    public class CreateUserCommand
    {
        private string _name;
        private string _mail;
        private string _pass;
        private string _role;

        public CreateUserCommand WithName(string name)
        {
            _name = name;
            return this;
        }

        public CreateUserCommand WithMail(string mail)
        {
            _mail = mail;
            return this;
        }

        public CreateUserCommand WithPassword(string pass)
        {
            _pass = pass;
            return this;
        }

        public CreateUserCommand ChoiseRole(string role)
        {
            _role = role;
            return this;
        }

        public void Save()
        {
            Driver.Instance.FindElement(By.Id("txtUserName")).SendKeys(_name);
            Driver.Instance.FindElement(By.Id("txtEmail")).SendKeys(_mail);
            Driver.Instance.FindElement(By.Id("txtPassword")).SendKeys(_pass);
            Driver.Instance.FindElement(By.Id("txtConfirmPassword")).SendKeys(_pass);
            Driver.Instance.FindElement(By.XPath("//label[contains(., '" + _role + "')]/input")).Click();
            Driver.Instance.FindElement(By.XPath("//button[@data-ng-click='saveUser()']")).Click();
        }
    }
}
