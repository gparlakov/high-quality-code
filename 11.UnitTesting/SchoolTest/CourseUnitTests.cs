using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolNS;

namespace SchoolTest
{
    /// <summary>
    /// Summary description for CourseTests
    /// </summary>
    [TestClass]
    public class CourseUnitTests
    {
        public CourseUnitTests()
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
        public void CourseConstructor_InstantiateEmptyCourse_AddFirstStudent()
        {
            Course course = new Course();
            Student student = new Student("testStudent", 10000);
            course.AddStudent(student);
            Assert.AreEqual(student.Name, course.Students[0].Name, 
                "Trying to add a first student in a course does not put him in position 0 of the course.Students array");
        }

        [TestMethod]
        public void InstantiateEmptyCourse_Add30Students()
        {
            Course course = GetFullCourse();

            var expected = 30;
            
            Assert.AreEqual(expected, course.Students.Length, 
                "Adding 30 students one after another does not result in an 30 item array");
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentOutOfRangeException))]
        public void InstantiateEmptyCourse_Add30Students_TryAddOneMore()
        {
            Course course = GetFullCourse();
            course.AddStudent(new Student("testStudent", 10030));
        }

        [TestMethod]
        public void InstantiateEmptyCourse_Add30Students_RemoveFirst()
        {
            var course = GetFullCourse();

            course.RemoveStudent(10000);

            Assert.AreEqual(null, course.Students[0], 
                "Trying to remove first from array students in a course instance does not succeed. First student is not null");
        }

        [TestMethod]
        public void InstantiateEmptyCourse_Add30Students_RemoveFirst_AddNew()
        {
            var course = GetFullCourse();

            course.RemoveStudent(10000);

            course.AddStudent(new Student("testStudent", 55555));

            Assert.AreEqual("testStudent", course.Students[0].Name, 
                "Trying to add a student in a course after removing from it one student does not succeed. First student is not \"testStudent\" ");
        }

        [TestMethod]
        public void InstantiateEmptyCourse_Add30Students_RemoveLast()
        {
            var course = GetFullCourse();

            course.RemoveStudent(10029);

            Assert.AreEqual(null, course.Students[29], 
                "Trying to remove last from array students in a course instance does not succeed. Last student is not null");
        }

        [TestMethod]
        public void InstantiateEmptyCourse_Add30Students_RemoveLast_AddNewStudent()
        {
            var course = GetFullCourse();

            course.RemoveStudent(10029);
            course.AddStudent(new Student("testStudent", 55555));

            Assert.AreEqual("testStudent", course.Students[29].Name, 
                "Trying to add student does not succeed. The student in expected position is not the newly added");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFullCourseOfStudents_RemoveLast_AddTwoNewStudent_ExpectedException_ArgumentOutOfRange()
        {
            var course = GetFullCourse();

            course.RemoveStudent(10029);
            course.AddStudent(new Student("testStudent", 55555));
            course.AddStudent(new Student("testStudent1", 55556));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void InstantiateEmptyCourse_RemoveStudents_ExceptionExpected()
        {
            Course course = new Course();

            course.RemoveStudent(10029);
        }

        /// <summary>
        /// Fills a course with students numbers 10000 to 10029
        /// </summary>
        /// <returns></returns>
        public static Course GetFullCourse()
        {
            Course course = new Course();
            for (int i = 0; i < 30; i++)
            {
                string name = "testStudent" + i;
                var student = new Student(name, 10000 + i);
                course.AddStudent(student);
            }

            return course;
        }
    }


}
