using OpenQA.Selenium;

namespace DemoProject2.Page
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver _driver)
        {
            driver = _driver;
        }
    }
}
