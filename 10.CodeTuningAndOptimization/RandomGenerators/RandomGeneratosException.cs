using System;
using System.Linq;

namespace RandomGenerators
{
    internal class RandomGeneratosException : Exception
    {
        public string MethodName { get; set; }
        public string ArgumentName { get; set; }
        
        public RandomGeneratosException(string message) : base(message)
        {
            this.MethodName = null;
            this.ArgumentName = null;
        }


        public RandomGeneratosException(string message, string methodName, string argumentName = null)
            : base(message)
        {
            this.MethodName = methodName;
            this.ArgumentName = argumentName;
        }
    }
}
