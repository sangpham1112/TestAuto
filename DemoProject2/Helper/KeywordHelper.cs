using DemoProject2.Model;
using DemoProject2.Page;
using FluentAssertions;
using Newtonsoft.Json;
using TestFrameworkCore.Model;
using WebDriverHelper.Helper;

namespace DemoProject2.Helper
{
    public class KeywordHelper
    {
        private List<KeywordData> keywords;
        private BrowserHelper browserHelper;

        public KeywordHelper(List<KeywordData> _keywords)
        {
            keywords = _keywords;
        }

        /// <summary>
        /// Execute keyword in List
        /// </summary>
        public void ExecuteKeywords()
        {
            foreach (var keyword in keywords)
            {
                ExecuteKeyword(keyword);
            }
        }

        public void ExecuteKeyword(KeywordData keyword)
        {
            switch (keyword.Keyword)
            {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keyword.Data);
                    break;

                case "Close Browser":
                    browserHelper.CloseBrowser();
                    break;

                case "Go to URL":
                    browserHelper.GotoURL(keyword.Data);
                    break;

                case "Enter username":
                    EnterUserName(keyword.Data);
                    break;

                case "Enter password":
                    EnterPassword(keyword.Data);
                    break;

                case "Click login button":
                    ClickLoginButton();
                    break;

                case "Verify dashboard display":
                    VerifyDashboardDisplay(bool.Parse(keyword.Data));
                    break;

                default:
                    throw new Exception("Not support this keyword");
            }
        }




        //Working with JSOn.

        public void ExecuteKeywordsJson()
        {
            foreach (var keyword in keywords)
            {
                ExecuteKeywordWithJson(keyword);
            }
        }

        public void ExecuteKeywordWithJson(KeywordData keyword)
        {
            switch (keyword.Keyword)
            {
                case "Open Browser":
                    browserHelper = new BrowserHelper();
                    browserHelper.OpenBrowser(browserType: keyword.Data);
                    break;

                case "Close Browser":
                    browserHelper.CloseBrowser();
                    break;

                case "Go to URL":
                    browserHelper.GotoURL(keyword.Data);
                    break;

                case "Enter username and password":
                    UserModel userData = JsonConvert.DeserializeObject<UserModel>(keyword.Data);
                    EnterUserNameAndPassword(userData);
                    break;

                case "Click login button":
                    ClickLoginButton();
                    break;

                case "Verify dashboard display":
                    VerifyDashboardModel verifyData = JsonConvert.DeserializeObject<VerifyDashboardModel>(keyword.Data);
                    VerifyDashboardDisplayJson(verifyData);
                    break;

                default:
                    throw new Exception("Not support this keyword");
            }
        }

        public void EnterUserNameAndPassword(UserModel data)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.EnterUserName(data.UserName);
            loginPage.EnterUserPassword(data.Password);
        }

        public void VerifyDashboardDisplayJson(VerifyDashboardModel verifyData)
        {
            DashboardPage dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsDashboardPageDisplay(verifyData.Timeout).Should().Be(verifyData.Expected);
        }



        public void EnterUserName(string username)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.EnterUserName(username);
        }

        public void EnterPassword(string password)
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.EnterUserPassword(password);
        }

        public void ClickLoginButton()
        {
            LoginPage loginPage = new LoginPage(browserHelper.Driver);
            loginPage.ClickLogin();
        }

        public void VerifyDashboardDisplay(bool expected)
        {
            DashboardPage dashboardPage = new DashboardPage(browserHelper.Driver);
            dashboardPage.IsDashboardPageDisplay(10).Should().Be(expected);
        }

    }
}


