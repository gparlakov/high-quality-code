using System;
using System.Linq;
using System.Text;

namespace CohesionAndCoupling
{
    /// <summary>
    /// Gives information about utilities exception
    /// </summary>
    public class UtilsException : Exception
    {
        /// <summary>
        /// Mandatory
        /// </summary>
        public string MessageOfException { get; private set; }

        /// <summary>
        /// Mandatory
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// Optional
        /// </summary>
        public string Argument { get; private set; }

        /// <summary>
        /// Generates instance with information about the message and the name of the method where it occured
        /// </summary>
        public UtilsException(string message, string methodName)
        {
            this.MessageOfException = message;
            this.MethodName = methodName;
            this.Argument = null;
        }

        /// <summary>
        /// Generates instance with information about the message, argument name and the name of the method where it occured
        /// </summary>
        public UtilsException(string message, string methodName, string argument)
            :this(message, methodName)
        {
            this.Argument = argument;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Exception was thrown from : {0}, {1}", this.MethodName, this.MessageOfException);            
            if (this.Argument != null)
            {
                result.AppendFormat(" , Argument(s): {0}", this.Argument);
            }

            return result.ToString();
        }
    }
}
