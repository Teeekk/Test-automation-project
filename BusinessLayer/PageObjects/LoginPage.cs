using OpenQA.Selenium;

namespace AutomationProjectTest.BusinessLayer.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver, int timeoutSeconds = 10) : base(driver, timeoutSeconds) {}
        
        //Locators
        private readonly By UsernameInput = By.CssSelector("#user-name");
        private readonly By PasswordInput = By.CssSelector("#password");
        private readonly By LoginButton = By.CssSelector("#login-button");
        private readonly By ErrorMessageContainer = By.CssSelector("[data-test='error']");
        
        // Enter values into input fields
        public void EnterUsername(string username) => TypeText(UsernameInput, username);
        public void EnterPassword(string password) => TypeText(PasswordInput, password);
        public void ClickLoginButton() => Click(LoginButton);
        
        //Manual clear input
        public void ClearUsernameManually() => ClearByTyping(UsernameInput);
        public void ClearPasswordManually() => ClearByTyping(PasswordInput);
        
        public void ClearCredentialsManually()
        {
            ClearByTyping(UsernameInput);
            ClearByTyping(PasswordInput);
        }
        
        
        //Get error messages
        public void WaitUntilCredentialsAreEmpty()
        {
            Until(d =>
            {
                var u = d.FindElement(UsernameInput).GetAttribute("value") ?? "";
                var p = d.FindElement(PasswordInput).GetAttribute("value") ?? "";
                return u == "" && p == "";
            });
        }
        
        //Precondition
        public ProductPage LoginAsValid(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
            
            return new ProductPage(Driver);
        }
        
        public string WaitAndGetErrorMessage() => Text(ErrorMessageContainer);
        
        private void ClearByTyping(By locator)
        {
            var element = Visible(locator);
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            
            Until(d => string.IsNullOrEmpty(d.FindElement(locator).GetAttribute("value") ?? ""));
        }
        
    }
}
