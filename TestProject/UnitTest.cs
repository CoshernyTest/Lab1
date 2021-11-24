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
            throw new System.Exception("TEST EXCEPTION");
        }

        bool testOutputField(string input_field, string expected)
        {

            return true;
        }
    }
}