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
        /// Ensures the file exists on the drive.
        /// </summary>
        /// <param name="fileName">The file to validate.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="fileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="fileName"/> does not exist.</exception>
        public void ValidateFile( String fileName )
        {
            // Throw exception if FileName is blank
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("FileName", "filename is required");
            }

            // Throw exception if FileName does not match an actual file
            if (File.Exists(fileName) == false)
            {
                throw new ArgumentException("FileName", "filename must exist");
            }
        }
    }
}
