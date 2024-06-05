using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using TestFrameworkCore.Helper;

namespace WebDriverHelper.Helper
{
    /// <summary>
    /// Init browser/open browser and navigate to url
    /// </summary name="url"></param>
    public class BrowserHelper
    {
        public IWebDriver Driver;
        public void OpenBrowser(string url = null, string browserType = null)
        {
            if (string.IsNullOrEmpty(browserType))
            {
                //Read browser value from config file
                browserType = ConfiguationHelper.GetConfig<string>("browser");
            }

            //Handle getting driver base on browserType.
            Driver = DriverFactoryHelper.GetDriver(browserType);

            //read timeout from config file.
            int timeout = ConfiguationHelper.GetConfig<int>("timeout");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            Driver.Manage().Window.Maximize();

            if (!string.IsNullOrEmpty(url))
            {
                Driver.Navigate().GoToUrl(url);
            }

        }

        public void CloseBrowser()
        {

            if (Driver is null)
            {
                return;
            }
            Driver.Quit();
        }

        public void GotoURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string TakeScreenshotAsBase64()
        {
            // Convert WebDriver object to ITakesScreenshot
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)Driver;

            // Take the screenshot
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }
    }
}
