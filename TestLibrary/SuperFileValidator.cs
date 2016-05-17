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
        public void ValidateFile( String fileName )
        {
            // Throw exception if FileName is blank
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "filename is required");
            }

            // Throw exception if FileName does not match an actual file
            if (File.Exists(fileName) == false)
            {
                throw new ArgumentException(nameof(fileName), "filename must exist");
            }

            // Get the extension of the file and make sure it's a CSV file
            var extension = Path.GetExtension(fileName);
            if( extension.ToUpper() != ".CSV")
            {
                throw new ArgumentException(nameof(fileName), "The file does not have a CSV extension");
            }
        }
    }
}
