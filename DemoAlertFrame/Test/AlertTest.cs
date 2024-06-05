using FluentAssertions;
using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertFrame.Test
{
    [TestClass]
    public class AlertTest
    {
        private string alertElement(string text) => $"//button[contains(.,'{text}')]";
        private string resultAlert = "//*[@id=\"result\"]";
        private BrowserHelper browserHelper;

        [TestInitialize]
        public void SetUp()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser("https://the-internet.herokuapp.com/javascript_alerts");

        }

        [TestCategory("smoketest")]
        [TestMethod]
        public void VerifyAlert()
        {

            //click button
            browserHelper.Driver.FindElement(By.XPath(alertElement("Click for JS Alert"))).Click();
            browserHelper.Driver.SwitchTo().Alert().Accept();

            //verify successful alert.

        }

        [TestCategory("smoketest1")]
        [TestMethod]
        public void VerifyResultAlert()
        {

            //click button
            browserHelper.Driver.FindElement(By.XPath(alertElement("Click for JS Confirm"))).Click();
            browserHelper.Driver.SwitchTo().Alert().Dismiss();
        }

        [TestMethod]
        public void VerifyPromptAlert()
        {

            string input = "Sang" + DateTime.Now.ToFileTimeUtc();

            //click button
            browserHelper.Driver.FindElement(By.XPath(alertElement("Click for JS Prompt"))).Click();
            browserHelper.Driver.SwitchTo().Alert().SendKeys(input);
            browserHelper.Driver.SwitchTo().Alert().Accept();

            //verify stirng
            //browserHelper.Driver.FindElement(By.XPath(resultAlert)).Text;
            List<string> acutalString = browserHelper.Driver.FindElement(By.XPath(resultAlert)).Text.Split(':').ToList();
            string actualName = acutalString.Last().Trim();

            //Assert
            actualName.Should().Be(input);

        }

        [TestCleanup]
        public void Cleanup()
        {
            browserHelper.CloseBrowser();
        }

    }
}
