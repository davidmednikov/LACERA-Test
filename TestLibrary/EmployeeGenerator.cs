using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    /// <summary>
    /// Assigns data gathered from parsing to instance of the employee class.
    /// </summary>
    public class EmployeeGenerator
    {
        /// <summary>
        /// Create dependencies for <see cref="EmployeeGenerator"/> method.
        /// </summary>
        private readonly IStringConverter stringConverter;

        public EmployeeGenerator(IStringConverter stringConverter)
        {
            this.stringConverter = stringConverter;
        }

        /// <summary>
        /// Parses employee data sent from <c>ParseLine</c> method and assigns values to variables within instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="dataEntries">Fields of data that have been split by commas and placed into a string list.</param>
        /// <param name="lineLength">Number of elements per line so <c>for</c> loop stops after all elements in the line have been parsed.</param>
        /// <returns>Returns an instance of the <see cref="Employee"/> class with all employee data assigned.</returns>
        public Employee GenerateEmployee(string[] dataEntries, int lineLength)
        {
            Employee employee = new Employee();

            for (int i = 0; i < lineLength; i++)
            {
                switch (i)
                {
                    case 0:
                        employee.FullName = dataEntries[i].Trim('"');
                        break;
                    case 1:
                        employee.Birthdate = this.stringConverter.ConvertDate(dataEntries[i]);
                        break;
                    case 2:
                        employee.Salary = this.stringConverter.ConvertSalary(dataEntries[i]);
                        break;
                    case 3:
                        employee.DateHired = this.stringConverter.ConvertDate(dataEntries[i]);
                        break;
                }
           
            }

            /// <summary>
            /// Assigns string to employee instance that states whether or not the employee's data is valid.
            /// </summary>
            if (employee.IsValid)
            {
                employee.PrintIfValid = "Employee is valid";
            }
            else
            {
                employee.PrintIfValid = "Invalid employee found";
            }

            return employee;

        }

    }
}
