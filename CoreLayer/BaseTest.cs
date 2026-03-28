using OpenQA.Selenium;
using System;
using NUnit.Framework;

using AutomationProjectTest.CoreLayer.WebDriver;

namespace AutomationProjectTest.CoreLayer
{
    public abstract class BaseTest 
    {
        protected IWebDriver Driver { get; private set; }

        protected void SetUpDriver(BrowserType browser)
        {
            Driver?.Quit();
            Driver = Factory.Create(browser);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Configuration.PageLoadTimeoutSeconds);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Driver.Navigate().GoToUrl(Configuration.BaseUrl);
        }

        [TearDown]
        public void CleanUpDriver()
        {
            if (Driver == null)
                return;

            try
            {
                Driver.Manage().Cookies.DeleteAllCookies();

                ((IJavaScriptExecutor)Driver).ExecuteScript(@"
            window.localStorage.clear();
            window.sessionStorage.clear();
        ");
            }
            catch (Exception ex)
            {
                // log ex if you have logger
            }
            finally
            {
                try { Driver.Quit(); } 
                catch 
                {
                    //No need to log quit failures, we're already in cleanup and will dispose anyway
                }
                try { Driver.Dispose(); } 
                catch 
                {
                    //No need to log dispose failures, we're already in cleanup and will dispose anyway
                }
                Driver = null;
            }
        }
    }
}