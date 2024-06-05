using DemoProject2.Page;
using FluentAssertions;
using TestFrameworkCore.Helper;
using TestFrameworkCore.Helper.Report;

namespace DemoProject2.Test
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        public override void SetUpPage()
        {
            loginPage = new LoginPage(browserHelper.Driver);
            dashboardPage = new DashboardPage(browserHelper.Driver);
        }

        [TestMethod("TC01: Login valid account")]
        public void VerifyValidUser()
        {
            var username = ConfiguationHelper.GetConfig<string>("username");
            var password = ConfiguationHelper.GetConfig<string>("password");

            // Enter valid Account
            extentTest.LogMessage("Enter valid username and Password");
            loginPage.EnterUserNameAndPassword(username, password);

            extentTest.LogMessage("Click Login button");
            loginPage.ClickLogin();

            // Verify Dasboard page is displayed.
            extentTest.LogMessage("Verify Dashboard page");
            dashboardPage.IsDashboardPageDisplay(10).Should().BeTrue();
        }



        [TestMethod("TC02: Login invalid accout")]
        public void VerifyInValidUser()
        {
            // Enter invalid Account
            extentTest.LogMessage("Input invalid username and password");
            loginPage.EnterUserNameAndPassword("Admin", "2343254654");

            //Click button
            extentTest.LogMessage("Click button");
            loginPage.ClickLogin();

            // Verify error message is displayed.
            extentTest.LogMessage("Verify Error Message");
            loginPage.MessageErrorText().Should().Contain("Invalid");

            // Verify the dashboard is NOT display
            extentTest.LogMessage("Verify the dashboard is NOT display");
            dashboardPage.IsDashboardPageIsNotDisplay(10).Should().BeFalse();
        }



        /// <summary>
        /// Test case with Excel file.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isLabelDashboardDisplay"></param>
        [TestMethod("TC03: Login with Excel")]
        [DynamicData(nameof(DataLoginUser))]
        public void LoginExcelFile(string username, string password, bool isLabelDashboardDisplay)
        {
            loginPage.EnterUserNameAndPassword(username, password);
            dashboardPage.IsDashboardPageDisplay().Should().Be(isLabelDashboardDisplay);
        }
        
        public static IEnumerable<object[]> DataLoginUser
        {
            get
            {
                return new ExcelHelper(Path.Combine("Resources", "book.xlsx")).GetLoginUserData();
            }
        }
    }
}
