using System.Configuration;
using OpenQA.Selenium;

namespace BlogEngineTests.Framework
{
    public class ListPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseAddress"] + "/admin/#/content/pages");
            Driver.WaitOneSecond();
        }

        public static void AddNewPage()
        {
            Driver.Instance.FindElement(By.XPath("//a/i[@class='fa fa-plus']")).Click();
        }

        public static CreatePageCommand InitPage()
        {
            return new CreatePageCommand();
        }

        public static void SearchNewPage(string title)
        {
            Driver.Instance.FindElement(By.XPath("//input[@ng-change='search()']")).SendKeys(title);
        }

        public static void GoToHomePage()
        {
            Driver.Instance.FindElement(By.XPath("//i[@class='fa fa-external-link']")).Click();
        }

        public static void DeleteThisPage()
        {
            Driver.Instance.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            Driver.Instance.FindElement(By.XPath("//button/i[@class='fa fa-times']")).Click();
        }

        public static bool HasThispage(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Count > 0;
        }
    }

    public class CreatePageCommand
    {
        private string _title;
        private string _body;

        public CreatePageCommand WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public CreatePageCommand WithBody(string body)
        {
            _body = body;
            return this;
        }

        public void Save()
        {
            Driver.WaitOneSecond();
            Driver.Instance.FindElement(By.Id("txtTitle")).SendKeys(_title);
            Driver.Instance.FindElement(By.Id("editor")).SendKeys(_body);
            Driver.Instance.FindElement(By.XPath("//a[@data-ng-click='save()']")).Click();
        }
    }
}
