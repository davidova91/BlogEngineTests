using System;
using OpenQA.Selenium;

namespace BlogEngineTests.Framework
{
    public class BlogsPage
    {
        public static string CombineVirtualPath(string baseAddress, string virtualPath)
        {
            return baseAddress + virtualPath.Substring(2);
        }

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost:63129/admin/#/blogs");
        }
        public static void AddNew()
        {
            Driver.Instance.FindElement(By.XPath("//button[@class='btn btn-success btn-header pull-right ng-binding']")).Click();
        }

        public static CreateBlogCommand InitBlog()
        {
            return new CreateBlogCommand();
        }

        public static void SearchBlog(string name)
        {
            Driver.Instance.FindElement(By.XPath("//div/input[@class='form-control input-sm pull-right ng-pristine ng-valid']")).SendKeys(name);
        }

        public static void DeleteBlog()
        {
            Driver.Instance.FindElement(By.XPath("//td/input[@class='ng-pristine ng-valid']")).Click();
            Driver.Instance.FindElement(By.XPath("//button[@class='btn btn-sm btn-danger ng-binding']")).Click();
            Driver.WaitOneSecond();
        }

        public static void GoToHomePage()
        {
            var element = Driver.Instance.FindElement(By.XPath("//a[@class='external-link pull-right']"));
            Driver.ClickElementWithAction(element);
        }

        public static bool IsBlogInTheList(string name)
        {
            return Driver.Instance.FindElements(By.LinkText(name)).Count > 0;
        }
    }

    public class CreateBlogCommand
    {
        private string _name;
        private string _admin;
        private string _mail;
        private string _pass;

        public CreateBlogCommand WithBlogName(string name)
        {
            _name = name;
            return this;
        }

        public CreateBlogCommand WithAdmin(string admin)
        {
            _admin = admin;
            return this;
        }

        public CreateBlogCommand WithMail(string mail)
        {
            _mail = mail;
            return this;
        }

        public CreateBlogCommand WithPass(string pass)
        {
            _pass = pass;
            return this;
        }

        public void Save()
        {
            Driver.Wait(TimeSpan.FromSeconds(2));
            Driver.Instance.FindElement(By.Id("txtBlogName")).SendKeys(_name);
            Driver.Instance.FindElement(By.Id("txtUserName")).SendKeys(_admin);
            Driver.Instance.FindElement(By.Id("txtEmail")).SendKeys(_mail);
            Driver.Instance.FindElement(By.Id("txtPassword")).SendKeys(_pass);
            Driver.Instance.FindElement(By.Id("txtConfirmPassword")).SendKeys(_pass);
            Driver.Instance.FindElement(By.XPath("//button[@data-ng-click='saveNew()']")).Click();
        }
    }
}
