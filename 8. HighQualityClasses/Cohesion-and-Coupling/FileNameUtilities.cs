using System;
using System.Linq;

namespace CohesionAndCoupling
{
    public static class FileNameUtilities
    {
        /// <summary>
        /// Extracts the extension (*.exe, *.pdf) out of a given <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">Full file name WITH extension.</param>
        /// <returns>Extension</returns>
        /// <exception>UtilsException</exception>
        public static string ExtractFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new UtilsException("No extension to extract", "ExtractFileExtension", "fileName");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        /// Extracts the file name (start.*, adobe.*) out of a given <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">Full file name WITH extension.</param>
        /// <returns>File name</returns>
        /// <exception>UtilsException</exception>
        public static string ExtractFileName(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new UtilsException("There is no extension in given param.", "GetFileNameWithoutExtension", "fileName");
            }

            string resultFileName = fileName.Substring(0, indexOfLastDot);
            return resultFileName;
        }
    }
}
