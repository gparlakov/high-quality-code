using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    abstract public class Course
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        protected Course(string name)
        {
            this.Name = name;
            this.TeacherName = null; 
            this.Students = new List<string>();           
        }

        protected Course(string name, string teacherName)
            :this(name)
        {
            this.TeacherName = teacherName;
        }
       
        protected Course(string name, string teacherName, IList<string> students)
            :this(name, teacherName)
        {
            this.Students = students;
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString()); 
            return result.ToString();
        }
    }
}
