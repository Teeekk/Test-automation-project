using OpenQA.Selenium;

namespace AutomationProjectTest.BusinessLayer.PageObjects
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver, int timeoutSeconds =10) : base(driver, timeoutSeconds) {}
        
        //Locators
        private readonly By MenuButton = By.CssSelector("#react-burger-menu-btn");
        private readonly By AppLogo = By.CssSelector(".app_logo");
        private readonly By CartIcon  = By.CssSelector("[data-test='shopping-cart-link']");
        private readonly By SortContainer = By.CssSelector("[data-test='product-sort-container']");
        private readonly By InventoryList = By.CssSelector("[data-test='inventory-list']");

        public IWebElement EnsureBurgerMenuIsVisible() => Visible(MenuButton);
        public IWebElement EnsureAppLogoIsVisible() => Visible(AppLogo);
        public IWebElement EnsureCartIconIsVisible() => Visible(CartIcon);
        public IWebElement EnsureSortDropdownIsVisible() => Visible(SortContainer);
        public IWebElement EnsureInventoryListIsVisible() => Visible(InventoryList);
    }
}