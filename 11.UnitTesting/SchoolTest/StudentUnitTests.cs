using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolNS;

namespace SchoolTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class StudentUnitTests
    {
        //public static StudentTests()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}

        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        //#region Additional test attributes
        ////
        //// You can use the following additional attributes as you write your tests:
        ////
        //// Use ClassInitialize to run code before running the first test in the class
        //// [ClassInitialize()]
        //// public static void MyClassInitialize(TestContext testContext) { }
        ////
        //// Use ClassCleanup to run code after all tests in a class have run
        //// [ClassCleanup()]
        //// public static void MyClassCleanup() { }
        ////
        //// Use TestInitialize to run code before running each test 
        //// [TestInitialize()]
        //// public void MyTestInitialize() { }
        ////
        //// Use TestCleanup to run code after each test has run
        //// [TestCleanup()]
        //// public void MyTestCleanup() { }
        ////
        //#endregion

        [TestMethod]
        public void StudentConstructor_AddNewStudent()
        {
            var student = new Student("petar", 10001);
            Assert.AreEqual("petar", student.Name);
            Assert.AreEqual(10001, student.Number);
        }

        [TestMethod]
        public void StudentToString_AddNewStudent()
        {
            var student = new Student("TestStudent", 10001);
            var actual = student.ToString();
            var expected = "Name: TestStudent SN: 10001";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructorPassedNull_ThrowArgumentException()
        {
            var student = new Student(null, 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructorPassedWhiteSpace_ThrowArgumentException()
        {
            var student = new Student("  ", 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentConstructorPassedSmallerNumber_ThrowArgumentOutOfRangeException()
        {
            var student = new Student("Petar", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentConstructorPassedBiggerrNumber_ThrowArgumentOutOfRangeException()
        {
            var student = new Student("Petar", 100000);
        }
    }
}
