using System;
using System.Linq;

namespace Exceptions_Homework
{
    public class ExamException : Exception
    {
        public ExamException(string message) : base(message)
        {
        }

        public ExamException(string message, string methodName) : this(message)
        {
            this.MethodName = methodName;
        }

        public ExamException(string message, string methodName, string argumentName) : this(message, methodName)
        {
            this.MethodName = methodName;
            this.ArgumentName = argumentName;
        }

        public string MethodName { get; private set; }

        public string ArgumentName { get; private set; }
    }
}