using System;
using OpenQA.Selenium;

namespace BlogEngineTests.Framework
{
    public class HomePage
    {
        public static bool IsAuthorized
        {
            get
            {
                try
                {
                    return Driver.Instance.FindElement(By.Id("ctl00_aLogin")).Text.Trim() == "Log off";
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public static void LogOff()
        {
            Driver.Instance.FindElement(By.Id("ctl00_aLogin")).Click();
        }

        public static bool HasTitle(string name)
        {
            return Driver.Instance.FindElements(By.XPath("//h1/a[.='" + name + "']")).Count > 0;
        }

        public static bool HasPost(string title)
        {
            return Driver.Instance.FindElements(By.XPath("//h2/a[.='" + title + "']")).Count > 0;
        }

        public static bool HasPage(string title)
        {
            return Driver.Instance.FindElements(By.XPath("//h2[.='" + title + "']")).Count > 0;
        }

        public static CreateCommentCommand AddComment()
        {
            return new CreateCommentCommand();
        }

        public static bool HasCommentOnPage(string comment)
        {
            return Driver.Instance.FindElements(By.XPath("//div/p[.='" + comment +"']")).Count > 0;
        }
    }

    public class CreateCommentCommand
    {
        private string _name;
        private string _mail;
        private string _comment;

        public CreateCommentCommand WithName(string name)
        {
            _name = name;
            return this;
        }

        public CreateCommentCommand WithMail(string mail)
        {
            _mail = mail;
            return this;
        }

        public CreateCommentCommand WithBody(string comment)
        {
            _comment = comment;
            return this;
        }

        public void SaveComment()
        {
           Driver.Instance.FindElement(By.Id("txtName")).SendKeys(_name);
            Driver.Instance.FindElement(By.Id("txtEmail")).SendKeys(_mail);
            Driver.Instance.FindElement(By.Id("txtContent")).SendKeys(_comment);
            Driver.Instance.FindElement(By.Id("btnSaveAjax")).Click();
            Driver.WaitOneSecond();
        }
    }
}
