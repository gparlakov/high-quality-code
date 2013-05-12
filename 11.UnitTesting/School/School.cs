using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolNS
{
    public class School
    {
        private List<Student> students;

        public School()
        {
            this.students = new List<Student>();
        }

        public School(List<Student> students)
            :this()
        {
            this.Students = students;
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            private set
            {
                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (HasUniqueNumber(student))
            {
                this.Students.Add(student);
            }
            else
            {
                throw new ArgumentException("Trying to add a second student with an already existing Students Number.");
            }
        }

        private bool HasUniqueNumber(Student student)
        {
            bool hasUniqueNumber = true;
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (student.Number == this.Students[i].Number)
                {
                    hasUniqueNumber = false;
                    break;
                }
            }

            return hasUniqueNumber;
        }

        public void RemoveStudent(int number)
        {
            bool isRemoved = false;

            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].Number == number)
                {
                    this.Students.RemoveAt(i);
                    isRemoved = true;
                    break;
                }
            }

            if (!isRemoved)
            {
                throw new ArgumentException("Trying to remove a nonexistent student!!! ");
            }
        }
    }
}
