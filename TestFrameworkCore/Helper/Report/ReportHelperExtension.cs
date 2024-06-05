using AventStack.ExtentReports;

namespace TestFrameworkCore.Helper.Report
{
    public static class ReportHelperExtension
    {
        public static void LogMessage(this ExtentTest test, string message)
        {
            test.Log(Status.Info, message);
        }

        /// <summary>
        /// Pass/Failed
        /// </summary>
        /// <param name="test"></param>
        /// <param name="result"></param>
        public static void AddResult(this ExtentTest test, string result)
        {
            if (result.Equals("Passed")) test.Pass();
            else test.Fail("Testcase is failed");
        }

        public static void AddImageBase64(this ExtentTest test, string imageBase64)
        {
            test.AddScreenCaptureFromBase64String(imageBase64,"Screenshot");
        }
    }
}
