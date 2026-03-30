using System.Collections.Generic;
using AutomationProjectTest.TestsLayer.TestData;
using AutomationProjectTest.CoreLayer;
using AutomationProjectTest.BusinessLayer.PageObjects;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationProjectTest.TestsLayer
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class LoginTest : BaseTest
    {
        public static IEnumerable<TestCaseData> Browsers()
        {
            yield return new TestCaseData(BrowserType.Chrome).SetName("Chrome Browser");
            yield return new TestCaseData(BrowserType.Edge).SetName("Edge Browser");
        }
        
        [Test]
        [TestCaseSource(nameof(Browsers))]
        public void TC1_EmptyUsernameAndPassword_ShowsUsernameRequired(BrowserType browser)
        {
            SetUpDriver(browser);
            
            var loginPage = new LoginPage(Driver);

            loginPage.EnterUsername((string)Credentials.InvalidUsername[0][1]);
            loginPage.EnterPassword(Credentials.Password);
            loginPage.ClearCredentialsManually();
            
            loginPage.WaitUntilCredentialsAreEmpty();
            
            loginPage.ClickLoginButton();
            loginPage.WaitAndGetErrorMessage().Should().Contain("Username is required");
        }

        [Test]
        [TestCaseSource(nameof(Browsers))]
        public void TC2_EmptyPassword_ShowsPasswordRequired(BrowserType browser)
        {
            SetUpDriver(browser);
            
            var loginPage = new LoginPage(Driver);
            
            loginPage.EnterUsername(Credentials.AcceptedUsernames[0]);
            loginPage.EnterPassword(Credentials.Password);
            loginPage.ClearPasswordManually();
            
            loginPage.ClickLoginButton();
            loginPage.WaitAndGetErrorMessage().Should().Contain("Password is required");
        }

        [Test]
        [TestCaseSource(nameof(Browsers))]
        public void TC3_LoginWithValidCredentials_DisplayMainPageElements(BrowserType browser)
        {
            SetUpDriver(browser);
            
            var loginPage = new LoginPage(Driver);
            //Precondition
            var productsPage = loginPage.LoginAsValid(Credentials.AcceptedUsernames[0], Credentials.Password);

            productsPage.EnsureBurgerMenuIsVisible().Displayed.Should().BeTrue();
            productsPage.EnsureAppLogoIsVisible().Displayed.Should().BeTrue();
            productsPage.EnsureCartIconIsVisible().Displayed.Should().BeTrue();
            productsPage.EnsureSortDropdownIsVisible().Displayed.Should().BeTrue();
            productsPage.EnsureInventoryListIsVisible().Displayed.Should().BeTrue();
        }
    }
}