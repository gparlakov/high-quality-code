using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContent;

namespace UnitTests.FreeCatalogue
{
    /// <summary>
    /// Summary description for UnitTestsIContent
    /// </summary>
    [TestClass]
    public class UnitTestsIContent
    {
        public UnitTestsIContent()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region Content.Title tests

        [TestMethod]
        public void TestTitle_CreateContentAndCheckIfTitleIsSame()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle1", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle2", "TestAuthor2", "100", "http://testUrl3.test" });

            Assert.AreEqual("TestTitle", testContent.Title);
            Assert.AreEqual("TestTitle1", testContent1.Title);
            Assert.AreEqual("TestTitle2", testContent2.Title);
        }

        [TestMethod]
        public void TestTitle_ChangeTitle()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            
            testContent.Title = "NewTestTitle";
            Assert.AreEqual("NewTestTitle", testContent.Title);
        }

        [TestMethod]
        public void TestTitle_CreateContentWithLongestPossibleTitle()
        {
            //create a 1000 symbols word and add 1 sybmol
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append("TenSymbols");
            }

            IContent testContent = new Content(
                ContentType.Book, new string[] { sb.ToString(), "TestAuthor", "10000", "http://testUrl.test" });

            var expected = sb.ToString();

            Assert.AreEqual(expected, testContent.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTitle_CreateContentWithTitleTooLong()
        {
            //create a 1000 symbols word and add 1 sybmol
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append("TenSymbols");
            }
            sb.Append("1");
            var length = sb.Length;
            IContent testContent = new Content(
                ContentType.Book, new string[] { sb.ToString(), "TestAuthor", "10000", "http://testUrl.test" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTitle_ChangeTitleToEmptyString()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.Title = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTitle_ChangeTitleToNull()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.Title = null;
        }

        #endregion

        #region Content.Author tests

        [TestMethod]
        public void TestAuthor_CreateContentAndCheckIfAuthorIsSame()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle1", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle2", "TestAuthor2", "100", "http://testUrl3.test" });

            Assert.AreEqual("TestAuthor", testContent.Author);
            Assert.AreEqual("TestAuthor1", testContent1.Author);
            Assert.AreEqual("TestAuthor2", testContent2.Author);
        }

        [TestMethod]
        public void TestAuthor_CreateContentWithLongestPossibleTitle()
        {
            //create a 1000 symbols word and add 1 sybmol
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append("TenSymbols");
            }

            IContent testContent = new Content(
                ContentType.Book, new string[] { sb.ToString(), "TestAuthor", "10000", "http://testUrl.test" });

            var expected = sb.ToString();

            Assert.AreEqual(expected, testContent.Author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAuthor_CreateContentWithTitleTooLong()
        {
            //create a 1000 symbols word and add 1 sybmol
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append("TenSymbols");
            }
            sb.Append("1");
            var length = sb.Length;
            IContent testContent = new Content(
                ContentType.Book, new string[] { sb.ToString(), "TestAuthor", "10000", "http://testUrl.test" });
        }

        [TestMethod]
        public void TestAuthor_ChangeAuthor()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            testContent.Author = "NewTestAuthor";

            Assert.AreEqual("NewTestAuthor", testContent.Author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAuthor_ChangeAuthorToNull()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.Author = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAuthor_ChangeAuthorToEmpty()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.Author = "";
        }
        #endregion

        #region Content.URL tests

        [TestMethod]
        public void TestUrl_CreateContentAndCheckIfUrlIsSame()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle1", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle2", "TestAuthor2", "100", "http://testUrl2.test" });

            Assert.AreEqual("http://testUrl.test", testContent.URL);
            Assert.AreEqual("http://testUrl1.test", testContent1.URL);
            Assert.AreEqual("http://testUrl2.test", testContent2.URL);
        }

        [TestMethod]
        public void TestUrl_ChangeUrl()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            testContent.URL = "http://newTestUrl.test";

            Assert.AreEqual("http://newTestUrl.test", testContent.URL);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUrl_ChangeUrlToNull()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.URL = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUrl_ChangeUrlToEmpty()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.URL = "";
        }
        #endregion

        #region Content.Size tests

        [TestMethod]
        public void TestSize_CreateContentAndCheckIfSizeIsSame()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle1", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle2", "TestAuthor2", "100", "http://testUrl2.test" });

            Assert.AreEqual(10000, testContent.Size);
            Assert.AreEqual(1000000, testContent1.Size);
            Assert.AreEqual(100, testContent2.Size);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSize_SizeTooLargeNumber()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000000001", "http://testUrl.test" });

            testContent.Size += 1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSize_SizeZero()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "0", "http://testUrl.test" });
        }

        [TestMethod]
        public void TestSize_ChangeSize()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            testContent.Size = 5;

            Assert.AreEqual(5, testContent.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSize_ChangeSizeToNegative()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.Size = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSize_ChangeSizeToZero()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testContent.Size = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSize_ChangeSizeTooLargeNumber()
        {
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000000000", "http://testUrl.test" });

            testContent.Size+= 1;
        }
        #endregion
    }
}
