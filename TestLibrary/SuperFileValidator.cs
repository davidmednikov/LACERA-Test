using System;
using System.IO;

namespace TestLibrary
{
    /// <summary>
    /// Ensures files are valid (exists on the drive)
    /// </summary>
    public class SuperFileValidator : IFileValidator
    {
        /// <summary>
        /// Ensures the file exists on the drive.
        /// </summary>
        /// <param name="fileName">The file to validate.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="fileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="fileName"/> does not exist.</exception>
        /// <exception cref="ArgumentException">The <paramref name="fileName"/> is not a CSV file.</exception>
        public void ValidateFile( String fileName )
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "filename is required");
            }

            if (File.Exists(fileName) == false)
            {
                throw new ArgumentException(nameof(fileName), "filename must exist");
            }

            var extension = Path.GetExtension(fileName);
            if( extension.ToUpper() != ".CSV")
            {
                throw new ArgumentException(nameof(fileName), "The file does not have a CSV extension");
            }
        }
    }
}
