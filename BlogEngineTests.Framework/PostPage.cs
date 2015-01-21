using System.Configuration;
using OpenQA.Selenium;

namespace BlogEngineTests.Framework
{
    public class PostPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseAddress"] + "/admin/#/content");
            Driver.WaitOneSecond();
        }

        public static void WriteNewPost()
        {
            Driver.Instance.FindElement(By.XPath("//a[@class='btn btn-success btn-header pull-right ng-binding']")).Click();
        }

        public static CreatePostCommand InitPost()
        {
            return new CreatePostCommand();
        }

        public static void SearchPost(string title)
        {
            Driver.Instance.FindElement(By.XPath("//div/input[@placeholder='Search']")).SendKeys(title);
        }

        public static void GoToHomePage()
        {
            Driver.Instance.FindElement(By.XPath("//a/i[@class='fa fa-external-link']")).Click();
            Driver.WaitOneSecond();
        }

        public static void DeletePost()
        {
            Driver.Instance.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            Driver.Instance.FindElement(By.XPath("//button[@class='btn btn-danger btn-sm ng-binding']")).Click();
            Driver.WaitOneSecond();
        }

        public static bool IsPostInTheList(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Count > 0;
        }

        public static void Draft()
        {
            Driver.Instance.FindElement(By.Id("fltr-dft")).Click();
        }
    }

    public class CreatePostCommand
    {
        private string _title;
        private string _body;

        public CreatePostCommand WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public CreatePostCommand WithBody(string body)
        {
            _body = body;
            return this;
        }

        public void Publish()
        {
            Driver.WaitOneSecond();
            Driver.Instance.FindElement(By.Id("txtTitle")).SendKeys(_title);
            Driver.Instance.FindElement(By.Id("editor")).SendKeys(_body);
            Driver.Instance.FindElement(By.XPath("//a[@data-ng-click='publish(true)']")).Click();
        }

        public void Save()
        {
           Driver.Instance.FindElement(By.XPath("//a[@ng-click='save()']")).Click();
        }
    }
}
