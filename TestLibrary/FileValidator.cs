using System;
using System.IO;

namespace TestLibrary
{
    /// <summary>
    /// Ensures files are valid (exists on the drive)
    /// </summary>
    public class FileValidator : IFileValidator
    {
        /// <summary>
        /// Ensures the file exists on the drive. Throws exception if file name is blank or does not refer to an actual file.
        /// </summary>
        /// <param name="fileName">The file to validate.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="fileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="fileName"/> does not exist.</exception>
        public void ValidateFile( String fileName )
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("FileName", "filename is required");
            }

            if (File.Exists(fileName) == false)
            {
                throw new ArgumentException("FileName", "filename must exist");
            }
        }
    }
}
