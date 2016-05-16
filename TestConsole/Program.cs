using System;
using TestLibrary;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get filepath as startup argument
            var FileName = args[0];

            // Use try method to parse
            try
            {
                // Create parser object from Parser class
                Parser parser = new Parser();

                // Parse file and return data to list of employees
                var employees = parser.Parse(FileName);

                // Loop through each entry in list of employees to print out their info
                foreach (var employee in employees)
                {

                    // Decimal.MinValue doesn't print out well, so replacing MinValue in 
                    // Employee.Salary with 0 for the sake of neat printing

                    if (employee.Salary == Decimal.MinValue)
                    {
                        employee.Salary = 0;
                    }
                        
                    // Print out each employee's data
                    var PrintLine = $"{employee.FullName}\t{employee.Birthdate.ToShortDateString()}\t${employee.Salary}\t{employee.DateHired.ToShortDateString()}\t{employee.PrintIfValid}";
                    Console.WriteLine(PrintLine);
                }
            }
            // Throw exception if parsing fails
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            // Wait for user to press enter before quitting
            Console.ReadKey();
        }
    }
}
