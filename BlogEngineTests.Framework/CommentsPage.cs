using System;
using OpenQA.Selenium;

namespace BlogEngineTests.Framework
{
    public class CommentsPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost:63129/admin/#/content/comments");
        }

        public static void SearchThisComment(string comment)
        {
            Driver.Instance.FindElement(By.XPath("//input[@ng-change='search()']")).SendKeys(comment);
        }

        public static void DeleteComment()
        {
            Driver.Instance.FindElement(By.XPath("//input[@data-ng-model='item.IsChecked']")).Click();
            Driver.Instance.FindElement(By.XPath("//button/i[@class='fa fa-times']")).Click();
            Driver.WaitOneSecond();
        }

        public static bool IsCommentInTheList(string comment)
        {
            return Driver.Instance.FindElements(By.LinkText(comment)).Count > 0;
        }
    }
}
