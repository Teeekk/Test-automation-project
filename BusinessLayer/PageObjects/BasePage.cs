using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.DevTools.V143.Security;

namespace AutomationProjectTest.BusinessLayer.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver, int timeoutSeconds = 10)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        }
        // Element interaction methods
        protected void Click(By locator) => Clickable(locator).Click();
        protected string Text(By locator) => Visible(locator).Text.Trim();
        // Element state checks
        protected bool IsEnabled(By locator) => Visible(locator).Enabled;
        protected bool IsSelected(By locator) => Visible(locator).Selected;
        // Element Attribute helpers
        protected string GetAttribute(By locator, string attribute) => Visible(locator).GetAttribute(attribute);
        protected bool IsAttributePresent(By locator, string attribute) => Visible(locator).GetAttribute(attribute) != null;
        protected bool IsAttributeMissingOrEmpty(By locator, string attribute)
        {
            var value = GetAttribute(locator, attribute);
            return value == null || value == string.Empty;
        }

        protected void TypeText(By locator, string text)
        {
            var element = Visible(locator);
            element.Clear();
            element.SendKeys(text);
        }
        // Element visibility checks

        protected IWebElement Visible(By locator)
        {
            return Wait.Until(d => 
            {
                try 
                {
                    var element =d.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        protected IWebElement Clickable(By locator)
        {
            return Wait.Until(d => 
            {
                try 
                {
                    var element =d.FindElement(locator);
                    return element.Displayed && element.Enabled ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        protected bool IsVisible(By locator)
        {
            try 
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool Exists(By locator) => Driver.FindElements(locator).Count > 0;
        //wait helpers

        protected void WaitForUrl(string url)
        {
            Wait.Until(d => d.Url.Equals(url, StringComparison.OrdinalIgnoreCase));
        }
        protected void WaitForTitle(string title)
        {
            Wait.Until(d => d.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        protected void Until(Func<IWebDriver, bool> condition)
        {
            Wait.Until(driver =>
            {
                try
                {
                    return condition(driver);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }
    }

}