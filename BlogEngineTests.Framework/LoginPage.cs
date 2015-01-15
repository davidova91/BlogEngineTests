using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BlogEngineTests.Framework
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "Account/login.aspx");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "UserName");
        }

        public static LoginCommand LoginAs(string name)
        {
            return new LoginCommand(name);
        }
    }

    public class LoginCommand
    {
        private readonly string _name;
        private string _pass;

        public LoginCommand(string name)
        {
            _name = name;
        }

        public LoginCommand WithPassword(string pass)
        {
            _pass = pass;
            return this;
        }

        public void Login()
        {
            Driver.Instance.FindElement(By.Id("UserName")).SendKeys(_name);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(_pass);
            Driver.Instance.FindElement(By.Id("LoginButton")).Click();
        }
    }
}
