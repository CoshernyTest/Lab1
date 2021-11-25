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
            int generations = 3;
            string input = "" +
                "........\r\n" +
                "..x.....\r\n" +
                "..x.....\r\n" +
                "..x.....\r\n" +
                "........";
            string expected = "" +
                "\r\n" +
                "\r\n" +
                "........\r\n" +
                "........\r\n" +
                ".xxx....\r\n" +
                "........\r\n" +
                "........\r\n";

            ConwaysMatrix matrix = Converter.ConvertTextToMatrix(input.Split("\r\n"));
            matrix.Field = matrix.LiveSteps(matrix.Field, generations);
            
            string output = Converter.ConwaysMatrixToText(matrix.Field);

            if (output != expected) { throw new System.Exception("TEST 1 FAILED"); }
        }
    }
}