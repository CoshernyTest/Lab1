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
        public void Test1()
        {
            string input = "";
            ConwaysMatrix matrix = Converter.ConvertTextToMatrix(input.Split("\r\n"));
        }

        [TestMethod]
        public void Test2()
        {

        }

        [TestMethod]
        public void Test3()
        {

        }


        bool testOutputField(string input_field, string expected)
        {

            return true;
        }
    }
}