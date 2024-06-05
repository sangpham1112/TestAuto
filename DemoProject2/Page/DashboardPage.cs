using OpenQA.Selenium;

namespace DemoProject2.Page
{
    public class DashboardPage : BasePage
    {

        private string dashboardXpath = "//h6[contains(.,'Dashboard')] | //a[contains(@class,'btn btn-smb btn-outline-primary rounded-pill')]";
        private string timeworkXpath = "//p[contains(.,'Time at Work')]";
        private string myActionsXpath = "//p[contains(.,'My Actions')]";

        public DashboardPage(IWebDriver _driver) : base(_driver) { }

        public bool IsDashboardPageDisplay(int timeouts = 1)
        {
            //Save default time out to a variable
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeouts);
                return driver.FindElement(By.XPath(dashboardXpath)).Displayed;
            }
            catch
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }
        }

        public string WidgetTimeAtWorkTitle()
        {
            return driver.FindElement(By.XPath(timeworkXpath)).Text;
        }

        public string WidgetMyActionsTitle()
        {
            return driver.FindElement(By.XPath(myActionsXpath)).Text;
        }

        public bool IsDashboardPageIsNotDisplay(int timeouts = 500)
        {
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeouts);
                return driver.FindElement(By.XPath(dashboardXpath)).Displayed;
            }
            catch
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }
        }


    }
}
