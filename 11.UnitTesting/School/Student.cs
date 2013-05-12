using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolNS
{
    public class Student
    {
        private string name;

        private int number;

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }

            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Passed null or empty string as name in Student constructor.");
                } 

                this.name = value; 
            }
        }

        public int Number
        {
            get 
            { 
                return this.number; 
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Passed invalid.Number range in student constructor is 10000 to 99999");
                }

                this.number = value; 
            }
        }

        public override string ToString()
        {
            return "Name: " + this.Name + " SN: " + this.Number;
        }
    }
}
