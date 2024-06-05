using DemoProject2.Page;
using FluentAssertions;
using TestFrameworkCore.Helper;

namespace DemoProject2.Test
{
    [TestClass]
    public class DashboardTest : BaseTest
    {
        private DashboardPage dashboardPage;
        private LoginPage loginPage;

        public override void SetUpPage()
        {
            dashboardPage = new DashboardPage(browserHelper.Driver);
            loginPage = new LoginPage(browserHelper.Driver);
        }



        [TestMethod("TC03: Verify that Time at work widget is displayed")]
        public void VerifyTitleWidgetTimeAtWork()
        {
            //Get account from config file.
            var username = ConfiguationHelper.GetConfig<string>("username");
            var password = ConfiguationHelper.GetConfig<string>("password");

            loginPage.EnterUserNameAndPassword(username, password);
            loginPage.ClickLogin();

            //Check Dashboard page is display.
            dashboardPage.IsDashboardPageDisplay(2).Should().BeTrue();

            //Verify the title of time at work is display correctly.
            dashboardPage.WidgetTimeAtWorkTitle().Should().Be("Time at Work");
        }

        [TestMethod("TC04: Verify that My actions widget is displayed")]
        public void VerifyTitleWidgetMyAction()
        {
            //Enter admin account
            var username = ConfiguationHelper.GetConfig<string>("username");
            var password = ConfiguationHelper.GetConfig<string>("password");

            loginPage.EnterUserNameAndPassword(username, password);
            loginPage.ClickLogin();

            //Check Dashboard page is display.
            dashboardPage.IsDashboardPageDisplay(2).Should().BeTrue();

            //Verify the title of widget My Actions is display correctly.
            dashboardPage.WidgetMyActionsTitle().Should().Be("My Actions");
        }
    }
}
