using AventStack.ExtentReports;
using System.Reflection;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;
using WebDriverHelper.Helper;

namespace DemoProject2.Test
{
    public class BaseTest
    {
        protected BrowserHelper browserHelper;
        public static ReportHelper ReportHelper;

        public TestContext TestContext { get; set; }
        protected ExtentTest extentTest;

        public virtual void SetUpPage() { }

        [TestInitialize]
        public void SetUp()
        {
            browserHelper = new BrowserHelper();
            browserHelper.OpenBrowser(ConfiguationHelper.GetConfig<string>("url"));

            //Call setup page
            SetUpPage();

            //Create setup page
            //REFECTION
            MethodInfo testMethod = GetType().GetMethod(TestContext.TestName);
            TestMethodAttribute testMethodAttribute = testMethod.GetCustomAttribute<TestMethodAttribute>();
            string displayName = testMethodAttribute.DisplayName != null ? testMethodAttribute.DisplayName : TestContext.TestName;

            extentTest = ReportHelper.CreateTest(TestContext.TestName, displayName);
        }


        [TestCleanup]
        public void Cleanup()
        {
            //Add result
            if (extentTest != null)
            {
                extentTest.AddResult(TestContext.CurrentTestOutcome.ToString()); if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                {
                    extentTest.AddImageBase64(browserHelper.TakeScreenshotAsBase64());
                }
            }

            browserHelper.CloseBrowser();
        }


    }
}
