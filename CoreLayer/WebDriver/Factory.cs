using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using AutomationProjectTest.CoreLayer;

namespace AutomationProjectTest.CoreLayer.WebDriver
{
    public class Factory
    {
        public static IWebDriver Create(CoreLayer.BrowserType browser)
        {
            switch (browser)
            {
                case CoreLayer.BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    return new ChromeDriver(chromeOptions);
                
                case CoreLayer.BrowserType.Edge:
                    var EdgeOptions = new EdgeOptions();
                    return new EdgeDriver(EdgeOptions);
                
                default: //For unknown browsers
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }
    }
}