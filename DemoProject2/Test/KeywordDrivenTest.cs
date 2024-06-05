using DemoProject2.Helper;
using TestFrameworkCore.Helper;

namespace DemoProject2.Test
{
    [TestClass]
    public class KeywordDrivenTest
    {
        [TestMethod("TC04: Verify login by using Keyword driven")]
        public void VerifyLogin()
        {
            //Read file Excel
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriver.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            //Get Data keywords
            KeywordHelper keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywords();

        }

        [TestMethod("TC5: Verify login using Keyword driven with json")]
        public void VerifyLoginWithJson() {
            //Read file Excel
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resources", "KeywordDriver2.xlsx"));
            var keywords = excelHelper.GetKeywordDatas();

            //Get Data keywords
            KeywordHelper keywordHelper = new KeywordHelper(keywords);
            keywordHelper.ExecuteKeywordsJson();
        }
    }
}
