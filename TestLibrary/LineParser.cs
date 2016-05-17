using System.Collections.Generic;

namespace TestLibrary
{
    /// <summary>
    /// Parses employee data in each line before assigning it to variables in instance of the <see cref="Employee"/> class.
    /// </summary>
    public class LineParser
    {
        /// <summary>
        /// Creates dependencies for LineParser.
        /// </summary>
        private readonly IStringConverter stringConverter;
        private readonly EmployeeGenerator employeeGenerator;

        public LineParser(IStringConverter stringConverter, EmployeeGenerator employeeGenerator)
        {
            this.stringConverter = stringConverter;
            this.employeeGenerator = employeeGenerator;
        }

        /// <summary>
        /// Takes all text read from file and splits it into individual lines to be parsed.
        /// </summary>
        /// <param name="lines">String containing all text read from file to be parsed.</param>
        /// <returns>List of instances of the <see cref="Employee"/> class. Each instance contains data assigned to the variables within the class. </returns>
        public List<Employee> ParseAll(string[] lines)
        {
            List<Employee> employees = new List<Employee>();

            /// <summary>
            /// Skips first line of file, which contains header data. Sends each subsequent line to ParseLine method, which returns <see cref="Employee"/> instance with parsed data inside.
            /// </summary>
            bool SkippedHeader = false;
            foreach (string line in lines)
            {
                if (SkippedHeader == false)
                {
                    SkippedHeader = true;
                    continue;
                }

                Employee employee = ParseLine(line);
                employees.Add(employee);
            }

            return employees;
        }

        /// <summary>
        /// Splits line of employee data separated by commas into string list, parses through resulting data, and assigns values to variables in <see cref="Employee"/> class. 
        /// </summary>
        /// <param name="line">Data sent from <see cref="ParseAll"/> method, containts data for each individual employee.</param>
        /// <returns>Instance of <see cref="Employee"/> class containing data parsed from file.</returns>
        private Employee ParseLine(string line)
        {
            string[] dataEntries = line.Split(',');
            int lineLength = line.Length;

            var employee = employeeGenerator.GenerateEmployee(dataEntries, lineLength);

            return employee;
        }
    }
}
