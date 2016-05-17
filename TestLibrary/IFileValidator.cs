using System;

namespace TestLibrary
{
    public interface IFileValidator
    {
        /// <summary>
        /// Ensures the file exists on the drive.
        /// </summary>
        /// <param name="fileName">The file to validate.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="fileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="fileName"/> does not exist.</exception>
        void ValidateFile(String fileName);
    }
}
