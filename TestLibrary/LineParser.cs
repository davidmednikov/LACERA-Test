using System.Collections.Generic;

namespace TestLibrary
{
    /// <summary>
    /// Parses lines and generates a list of employees
    /// </summary>
    public class LineParser
    {
        private readonly IStringConverter stringConverter;

        public LineParser(IStringConverter stringConverter)
        {
            this.stringConverter = stringConverter;
        }

        public List<Employee> Parse(string[] lines)
        {
            // Create new instance of employee list
            List<Employee> employees = new List<Employee>();

            // Change to true once header has been read
            bool SkippedHeader = false;

            foreach (string row in lines)
            {
                // After reading the first row, SkippedHeader changed to true and program continues to top of foreach loop to parse 2nd line
                if (SkippedHeader == false)
                {
                    SkippedHeader = true;
                    continue;
                }

                // Create instance of Employee class with data from parsing line
                Employee employee = ParseLine(row);

                // Add instance of employee class to list of all employees
                employees.Add(employee);
            }

            // Return list of all employees
            return employees;
        }

        private Employee ParseLine(string line)
        {
            // Create new instance of employee class and string converter class
            Employee employee = new Employee();

            // Create string array, using comma as delimiter
            string[] entries = line.Split(',');

            // Loop through all 4 fields in each row, assigning value to public variables in the instance of the Employee class
            for (int i = 0; i < line.Length; i++)
            {
                switch (i)
                {
                    case 0: // Index of Name
                        employee.FullName = entries[i].Trim('"');
                        break;
                    case 1: // Index of Birthdate
                        employee.Birthdate = this.stringConverter.ConvertDate(entries[i]);
                        break;
                    case 2: // Index of Salary
                        employee.Salary = this.stringConverter.ConvertSalary(entries[i]);
                        break;
                    case 3: // Index of DateHired
                        employee.DateHired = this.stringConverter.ConvertDate(entries[i]);
                        break;
                }
            }

            // Add string to be printed to employee instance depending on whether or not data is valid or invalid
            if (employee.IsValid)
            {
                employee.PrintIfValid = "Employee is valid";
            }
            else
            {
                employee.PrintIfValid = "Invalid employee found";
            }

            // Returns list of employee data for ParseLines() function
            return employee;
        }
    }
}
