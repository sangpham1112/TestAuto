using OpenQA.Selenium;

namespace DemoProject2.Page
{
    public class LoginPage : BasePage
    {
        private string errorMessageXpath = "//p[contains(@class,'oxd-text oxd-text--p oxd-alert-content-text')] | //div[@class='toast-message']";
        private string userNameXpath = "//input[contains(@name,'username')] | //input[contains(@id,'iusername')]";
        private string passwordXpath = "//input[contains(@name,'password')] | //input[contains(@id,'ipassword')]";
        private string loginButtonXpath = "//button[@type='submit'][contains(.,'Login')] | //button[contains(.,'Login')]";


        public LoginPage(IWebDriver _driver) : base(_driver) { }

        public void EnterUserNameAndPassword(string username, string password)
        {
            driver.FindElement(By.XPath(userNameXpath)).SendKeys(username);
            driver.FindElement(By.XPath(passwordXpath)).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(By.XPath(loginButtonXpath)).Click();
        }


        public string MessageErrorText()
        {
            return driver.FindElement(By.XPath(errorMessageXpath)).Text;
        }

        public void EnterUserName(string username) {
            driver.FindElement(By.XPath(userNameXpath)).SendKeys(username);
        }

        public void EnterUserPassword(string password)
        {
            driver.FindElement(By.XPath(passwordXpath)).SendKeys(password);
        }
    }
}
