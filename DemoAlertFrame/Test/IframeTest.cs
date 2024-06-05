using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertFrame.Test
{
    [TestClass]
    public class IframeTest
    {
        private BrowserHelper browserHelper;
        private string iFrameXpath = "//*[@id=\"singleframe\"]";
        private string textIframeXpath = "/html/body/section/div/div/div/input";
        private string iframeButtonXpath = "/html/body/section/div[1]/div/div/div/div[1]/div/ul/li[2]/a";

        [TestInitialize]
        public void SetUp()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://demo.automationtesting.in/Frames.html");
        }

        [TestMethod]
        public void VerifyIframe()
        {
            //get iframeElement
            var frameElement = browserHelper.Driver.FindElement(By.XPath(iFrameXpath));
            //swith to iframe and senkey to input.
            browserHelper.Driver.SwitchTo().Frame(frameElement);
            browserHelper.Driver.FindElement(By.XPath(textIframeXpath)).SendKeys("Sang");

            //switch to default page.
            browserHelper.Driver.SwitchTo().DefaultContent();
            browserHelper.Driver.FindElement(By.XPath(iframeButtonXpath)).Click();

        }

        [TestCleanup]
        public void Cleanup()
        {
            browserHelper.CloseBrowser();
        }
    }
}
