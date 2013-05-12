using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolNS
{
    public class Course
    {
        const int MaxStudentsInCourse = 30;

        private Student[] students;

        public Course()
        {
            this.Students = new Student[MaxStudentsInCourse];
        }

        public Course(Student[] students)
            :this()
        {
            this.Students = students;
        }

        public Student[] Students
        {
            get 
            {
                Student[] studentsCopy = (Student[])this.students.Clone();
                return studentsCopy; 
            }
            
            private set 
            { 
                this.students = value; 
            }
        }

        public void AddStudent(Student student)
        {
            bool isAdded = false;
            
            for (int i = 0; i < this.students.Length; i++)
            {
                if (this.students[i] == null)
                {
                    this.students[i] = student;
                    isAdded = true;
                    break;
                }
            }

            if (!isAdded)
            {
                throw new ArgumentOutOfRangeException(
                    "Trying to add a student in a full course.Course can't contain more than 30 students.");
            }

        }

        public void RemoveStudent(int idNumber)
        {
            bool isRemoved = false;
            for (int i = 0; i < this.students.Length; i++)
            {
                if (this.students[i] != null && this.students[i].Number == idNumber)
                {
                    this.students[i] = null;
                    isRemoved = true;
                    break;
                }
            }

            if (!isRemoved)
            {
                throw new ArgumentException("Trying to remove a non-existend student from course");
            }
        }
    }
}
