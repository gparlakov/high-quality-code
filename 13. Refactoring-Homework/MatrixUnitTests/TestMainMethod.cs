using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MatrixWalk;

namespace MatrixUnitTests
{
    [TestClass]
    public class TestMainMethod
    {
        [TestMethod]
        public void TestMain_InputThree()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("3"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();
            var arrangedOutput = ArrangeString(consoleOutput.ToString());
            Assert.AreEqual(@"Enter a positive number 1 7 8 6 2 9 5 4 3", arrangedOutput);
        }

        [TestMethod]
        public void TestMain_InputOne()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("1"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();
            var arrangedOutput = ArrangeString(consoleOutput.ToString());
            Assert.AreEqual(@"Enter a positive number 1", arrangedOutput);
        }

        [TestMethod]
        public void TestMain_InputHundred()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("100"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();
            var outputSplit = consoleOutput.ToString().Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(10004, outputSplit.Length);
        }

        [TestMethod]
        public void TestMain_InputZero()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("0\n1"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();
            var arrangedOutput = ArrangeString(consoleOutput.ToString());
            Assert.AreEqual(@"Enter a positive number You haven't entered a correct positive number 1", arrangedOutput);
        }

        //two inputs because otehrwise will run out of memory
        [TestMethod]
        public void TestMain_InputMinusOneThenOne()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("-1\n1"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();
            
            var arrangedOutput = ArrangeString(consoleOutput.ToString());
            Assert.AreEqual(@"Enter a positive number You haven't entered a correct positive number 1", arrangedOutput);
        }

        [TestMethod]
        public void TestMain_InputHundredOneThenOne()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("101\n1"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();

            var arrangedOutput = ArrangeString(consoleOutput.ToString());
            Assert.AreEqual(@"Enter a positive number You haven't entered a correct positive number 1", arrangedOutput);
        }

        [TestMethod]
        public void TestMain_InputMinusOneThenMinusThousandThanHundredThenOne()
        {
            var consoleOutput = new StringWriter();
            Console.SetIn(new StringReader("-1\n-1000\n101\n1"));
            Console.SetOut(consoleOutput);

            WalkInMatrix.Main();

            var arrangedOutput = ArrangeString(consoleOutput.ToString());
            Assert.AreEqual(@"Enter a positive number You haven't entered a correct positive number" + 
                " You haven't entered a correct positive number You haven't entered a correct positive number 1",
                arrangedOutput);
        }

        private string ArrangeString(string str)
        {
            var outputSplit = str.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var arrangedOutput = String.Join(" ", outputSplit);

            return arrangedOutput;
        }
    }
}
