using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContent;

namespace UnitTests.FreeCatalogue
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestsICatalog
    {

        public UnitTestsICatalog()
        {
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

        #region Add method tests
        [TestMethod]
        public void TestAdd_OneBookTitle()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] {"TestTitle","TestAuthor","10000", "http://testUrl.test"} );

            testCatalog.Add(testContent);
            var list = testCatalog.GetListContent("TestTitle", 1);

            Assert.AreEqual(1,
                list.Count(cont => 
                    cont.TextRepresentation == "Book: TestTitle; TestAuthor; 10000; http://testUrl.test"));
        }

        [TestMethod]
        public void TestAdd_TwoBooksDifferentTitles()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Book, new string[] { "TestTitle1", "TestAuthor1", "9999", "http://testUrl1.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);

            var list = testCatalog.GetListContent("TestTitle", 1);

            Assert.AreEqual(1,
                list.Count(cont => cont.TextRepresentation == "Book: TestTitle; TestAuthor; 10000; http://testUrl.test"));

            var list1 = testCatalog.GetListContent("TestTitle1", 1);

            Assert.AreEqual(1,
                list1.Count(cont => cont.TextRepresentation == "Book: TestTitle1; TestAuthor1; 9999; http://testUrl1.test"));
        }

        [TestMethod]
        public void TestAdd_TwoMatchingTitlesBooks()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);

            var list = testCatalog.GetListContent("TestTitle", 2);

            Assert.AreEqual(2,
                list.Count(cont => cont.TextRepresentation == "Book: TestTitle; TestAuthor; 10000; http://testUrl.test"));
        }

        [TestMethod]
        public void TestAdd_TwoMatchingTitlesBooksShowOnlyOne()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);

            var list = testCatalog.GetListContent("TestTitle", 1);

            Assert.AreEqual(1,
                list.Count(cont => cont.TextRepresentation == "Book: TestTitle; TestAuthor; 10000; http://testUrl.test"));
        }

        [TestMethod]
        public void TestAdd_BookMovieAppWithSameTitle()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle", "TestAuthor2", "100", "http://testUrl3.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);
            testCatalog.Add(testContent2);

            var list = testCatalog.GetListContent("TestTitle", 3);

            Assert.AreEqual(3, list.Count(cont => cont.Title == "TestTitle"));
            Assert.AreEqual(1, list.Count(cont => cont.Type == ContentType.Application));
            Assert.AreEqual(1, list.Count(cont => cont.Type == ContentType.Movie));
            Assert.AreEqual(1, list.Count(cont => cont.Type == ContentType.Book));
        }
        #endregion

        #region ListContent method tests
        [TestMethod]
        public void TestListContent_ListWithMoreThanContentNumber()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle", "TestAuthor2", "100", "http://testUrl3.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);
            testCatalog.Add(testContent2);

            var list = testCatalog.GetListContent("TestTitle", 5);

            Assert.AreEqual(3, list.Count(cont => cont.Title == "TestTitle"));
        }

        [TestMethod]
        public void TestListContent_ListWithMoreThanContentNumberBigNumberUsed()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            for (int i = 0; i < 10; i++)
            {
                testCatalog.Add(testContent);
            }

            var list = testCatalog.GetListContent("TestTitle", 100);

            Assert.AreEqual(10, list.Count(cont => cont.Title == "TestTitle"));
        }

        [TestMethod]
        public void TestListContent_ListWithLessThanContentNumber()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle", "TestAuthor2", "100", "http://testUrl3.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);
            testCatalog.Add(testContent2);

            var list = testCatalog.GetListContent("TestTitle", 2);

            Assert.AreEqual(2, list.Count(cont => cont.Title == "TestTitle"));
        }

        [TestMethod]
        public void TestListContent_AddDifferentTitlesListOnlyNumberMatchingOneOfThem()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle1", "TestAuthor1", "1000000", "http://testUrl1.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle2", "TestAuthor2", "100", "http://testUrl3.test" });
            for (int i = 0; i < 100; i++)
            {
                testCatalog.Add(testContent);
                testCatalog.Add(testContent1);
                testCatalog.Add(testContent2);
            }

            var list = testCatalog.GetListContent("TestTitle", 50);
            var list1 = testCatalog.GetListContent("TestTitle1", 110);
            var list2 = testCatalog.GetListContent("TestTitle2", 5);

            Assert.AreEqual(50, list.Count(cont => cont.Title == "TestTitle"));
            Assert.AreEqual(100, list1.Count(cont => cont.Title == "TestTitle1"));
            Assert.AreEqual(5, list2.Count(cont => cont.Title == "TestTitle2"));            
        }
        #endregion

        #region UpdateContent tests
        
        [TestMethod]
        public void TestUpdateContent_DifferentTypesOfContent()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle", "TestAuthor1", "1000000", "http://testUrl.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle", "TestAuthor2", "100", "http://testUrl.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);
            testCatalog.Add(testContent2);

            testCatalog.UpdateContent("http://testUrl.test", "http://newTestUrl.test");

            var list = testCatalog.GetListContent("TestTitle", 3);

            Assert.AreEqual(3, list.Count(cont => cont.URL == "http://newTestUrl.test"));
        }

        [TestMethod]
        public void TestUpdateContent_ChangeToNewUrlThanBackToOld()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            IContent testContent1 = new Content(
                ContentType.Movie, new string[] { "TestTitle", "TestAuthor1", "1000000", "http://testUrl.test" });
            IContent testContent2 = new Content(
                ContentType.Application, new string[] { "TestTitle", "TestAuthor2", "100", "http://testUrl.test" });

            testCatalog.Add(testContent);
            testCatalog.Add(testContent1);
            testCatalog.Add(testContent2);

            testCatalog.UpdateContent("http://testUrl.test", "http://newTestUrl.test");

            testCatalog.UpdateContent("http://newTestUrl.test", "http://testUrl.test");
            var list = testCatalog.GetListContent("TestTitle",10);
            Assert.AreEqual(3,list.Count(cont => cont.URL == "http://testUrl.test"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateContent_TryUpdtadeFromEmptyString()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });


            testCatalog.Add(testContent);

            testCatalog.UpdateContent("", "http://testUrl.test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateContent_TryUpdtadeWithEmptyString()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });
            

            testCatalog.Add(testContent);

            testCatalog.UpdateContent("http://testUrl.test", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateContent_TryUpdtadeFromNull()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });


            testCatalog.Add(testContent);

            testCatalog.UpdateContent(null, "http://testUrl.test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateContent_TryUpdtadeWithNull()
        {
            ICatalog testCatalog = new Catalog();
            IContent testContent = new Content(
                ContentType.Book, new string[] { "TestTitle", "TestAuthor", "10000", "http://testUrl.test" });


            testCatalog.Add(testContent);

            testCatalog.UpdateContent("http://testUrl.test", null);
        }

        #endregion
    }
}
