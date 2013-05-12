using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolNS;

namespace SchoolTest
{
    /// <summary>
    /// Summary description for SchoolUnitTests
    /// </summary>
    [TestClass]
    public class SchoolUnitTests
    {
        public SchoolUnitTests()
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

        [TestMethod]
        public void InstantiateEmptySchool_AddStudent()
        {
            School school = new School();
            school.AddStudent(new Student("testStudent", 10000));

            int expected = 10000;
            int actual = school.Students[0].Number;
            Assert.AreEqual(expected, actual, "Trying to add a first student in a school. Not successful. First student number is not the number expected.");
        }

        [TestMethod]
        public void InstantiateEmptySchool_AddStudent_AddSecond()
        {
            School school = new School();
            school.AddStudent(new Student("testStudent", 10000));
            school.AddStudent(new Student("testStudent1", 10001));

            int expected = 10001;
            int actual = school.Students[1].Number;
            Assert.AreEqual(expected, actual, "Trying to add a second student in a school. Not successful. Second student number is not the number expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InstantiateEmptySchool_AddStudent_AddSecondWithSameNumber()
        {
            School school = new School();
            school.AddStudent(new Student("testStudent", 10000));
            school.AddStudent(new Student("testStudent1", 10000));

            int expected = 10000;
            int actual = school.Students[1].Number;
            Assert.AreEqual(expected, actual, "Trying to add a second student in a school. Not successful. Second student number is not the number expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InstantiateEmptySchool_RemoveStudent()
        {
            School school = new School();
            school.RemoveStudent(10000);
        }

        [TestMethod]
        public void InstantiateEmptySchool_AddStudent_AddSecond_RemoveFirst()
        {
            School school = new School();
            school.AddStudent(new Student("testStudent", 10000));
            school.AddStudent(new Student("testStudent1", 10001));
            school.RemoveStudent(10000);

            int expected = 1;
            int actual = school.Students.Count;
            Assert.AreEqual(expected, actual, "Removing one out of two students in school does not succeed. Students' count still is not 1!");
        }

        [TestMethod]
        public void InstantiateEmptySchool_Add30Students_RemoveOne()
        {
            School school = new School();
            for (int i = 0; i < 30; i++)
            {
                var name = "testStudent" + i;
                var number = 10000 + i;
                school.AddStudent(new Student(name, number));
            }
            
            school.RemoveStudent(10015);

            bool expectedFoundStudent = false;
            bool actualFoundStudent = false;
            for (int i = 0; i < school.Students.Count; i++)
            {
                if (school.Students[i].Number == 10015)
                {
                    actualFoundStudent = true;
                    break;
                }
            }

            Assert.AreEqual(expectedFoundStudent, actualFoundStudent,
                "Removing student from school does not succeed. Student with same number is still found!");
        }
    }
}
