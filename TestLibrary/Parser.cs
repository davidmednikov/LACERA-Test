using System;
using System.Collections.Generic;
using System.IO;

namespace TestLibrary
{
    /// <summary>
    /// Parses through file and returns data as a list of employee class instances.
    /// </summary>
    public class Parser
    {
        private readonly IFileValidator fileValidator;
        private readonly LineParser lineParser;

        /// <summary>
        /// Initializes an instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="fileValidator">Ensures a file to be parsed is valid.</param>
        /// <param name="stringConverter">Converts text to various types without throwing exceptions.</param>
        public Parser( IFileValidator fileValidator, LineParser lineParser )
        {
            this.fileValidator = fileValidator;
            this.lineParser = lineParser;
        }

        /// <summary>
        /// Parses all lines from a file, generates a <see cref="Employee"/> from each line,
        /// and returns a <see cref="List{T}"/> of all <see cref="Employee"/>.
        /// </summary>
        /// <param name="fileName">Absolute path of file to be parsed.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="fileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="fileName"/> does not exist.</exception>
        /// <returns>Returns a <see cref="List{T}"> of employees generated from the file.</returns>
        public List<Employee> Parse(string fileName)
        {
            this.fileValidator.ValidateFile(fileName);

            // Send FileName string to ReadFile method, returns array of strings
            string[] lines = File.ReadAllLines(fileName);

            // Returns parsed data
            return this.lineParser.Parse(lines);
        }
    }
}
