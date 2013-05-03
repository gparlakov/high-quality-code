using System;

namespace Methods
{
    class Student
    {
        public Student(string firstName, string lastName, string birthDay)            
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = DateTime.Parse(birthDay);
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string OtherInfo { get; set; }
                
        public bool CompareTo(Student other)
        {
            return this.BirthDate > other.BirthDate;
        }
    }
}