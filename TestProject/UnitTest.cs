using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            
        }

        [TestMethod]
        public void TestMethod()
        {
            TestClass222 testClass222 = new TestClass222();
            testClass222.TestClassTestMethod();
        }

        bool testOutputField(string input_field, string expected)
        {

            return true;
        }
    }
}