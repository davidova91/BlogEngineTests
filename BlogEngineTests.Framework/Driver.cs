using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlogEngineTests.Framework
{
    public class Driver
    {
        private static string _windowHandle;
        public static IWebDriver Instance { get; set; }

        public static object BaseAddress
        {
            get { return ConfigurationManager.AppSettings["BaseAddress"]; }
        }

        public static void Initialize()
        {
            //Instance = new FirefoxDriver();
            Instance = new ChromeDriver(@"D:\proj\driver\");
            Instance.Manage().Window.Maximize();
            _windowHandle = Instance.CurrentWindowHandle;
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)timeSpan.TotalMilliseconds);
        }

        public static void WaitOneSecond()
        {
            Wait(TimeSpan.FromSeconds(1));
        }

        public static void ClickElementWithAction(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Instance;
            js.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('click',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", element);
        }

        public static void SwitchToOriginalWindow()
        {
            var handle = Instance.CurrentWindowHandle;
            if (_windowHandle == handle) return;
            Instance.Close();
            Instance.SwitchTo().Window(_windowHandle);
        }

        public static void SwitchToNewWindow()
        {
            var handle = Instance.WindowHandles[Instance.WindowHandles.Count - 1];
            Instance.SwitchTo().Window(handle);
        }
    }
}
