
using TestFrameworkCore.Helper.Report;

//Parallel.
[assembly: Parallelize(Workers = 3, Scope = ExecutionScope.MethodLevel)]

namespace DemoProject2.Test
{
    [TestClass]
    public class AssemblyTest 
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            BaseTest.ReportHelper = new ReportHelper();
        }

 
        /// <summary>
        /// 
        /// </summary>
        [AssemblyCleanup] 
        public static void AssemblyCleanup()
        {
            if(BaseTest.ReportHelper != null)
            {
                BaseTest.ReportHelper.ExportReport();
            }
        }
    }
}
