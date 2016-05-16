using System;
using System.Collections.Generic;
using System.IO;

namespace TestLibrary
{
    public class Parser
    {
        public List<Employee> Parse(string FileName)
        {
            // Throw exception if FileName is blank
            if (string.IsNullOrWhiteSpace(FileName))
            {
                throw new ArgumentNullException("FileName", "filename is required");
            }

            // Throw exception if FileName does not match an actual file
            if (File.Exists(FileName) == false)
            {
                throw new ArgumentException("FileName", "filename must exist");
            }

            // Send FileName string to ReadFile method, returns array of strings
            string[] lines = ReadFile(FileName);

            // Returns parsed data
            return ParseLines(lines);
        }

        // Method to read all lines of file and return
        private string[] ReadFile(string FileName)
        {
            return File.ReadAllLines(FileName);
        }

        // Method to parse all lines of CSV
        private List<Employee> ParseLines(string[] lines)
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

        // Method to parse each individual line of CSV, returns list
        private Employee ParseLine(string row)
        {
            // Create new instance of employee class and string converter class
            Employee employee = new Employee();
            StringConverter converter = new StringConverter();

            // Create string array, using comma as delimiter
            string[] entries = row.Split(',');


            // Loop through all 4 fields in each row, assigning value to public variables in the instance of the Employee class
            for (int i = 0; i < row.Length; i++)
            {
                switch (i)
                {
                    case 0: // Index of Name
                        employee.FullName = entries[i].Trim('"');
                        break;
                    case 1: // Index of Birthdate
                        employee.Birthdate = converter.ConvertDate(entries[i]);
                        break;
                    case 2: // Index of Salary
                        employee.Salary = converter.ConvertSalary(entries[i]);
                        break;
                    case 3: // Index of DateHired
                        employee.DateHired = converter.ConvertDate(entries[i]);
                        break;
                }
            }

            // Add string to be printed to employee instance depending on whether or not data is valid or invalid
            if (employee.IsValid)
            {
                employee.PrintIfValid = "Data is valid";
            }
            else
            {
                employee.PrintIfValid = "Invalid record found";
            }

            // Returns list of employee data for ParseLines() function
            return employee;
        }
    }
}
