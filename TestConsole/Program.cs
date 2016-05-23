using System;
using TestLibrary;

namespace TestConsole
{
    class Program
    {
        /// <summary>
        /// Runs the program by parsing the file, given as a startup argument, and displaying the employee data in table form.
        /// </summary>
        /// <param name="args">Uses file path as startup argument</param>
        static void Main(string[] args)
        {
            var FileName = args[0];

            try
            {
                /// <summary>
                /// Create dependencies for Parser class.
                /// </summary>
                var fileValidator = new SuperFileValidator();
                var stringConverter = new StringConverter();
                var employeeGenerator = new EmployeeGenerator(stringConverter);
                var lineParser = new LineParser(stringConverter, employeeGenerator);

                Parser parser = new Parser(fileValidator, lineParser);

                var employees = parser.Parse(FileName);

                var TableHeader = "Full Name\t|Date of Birth\t|Salary\t|Date Hired\t|Valid Employee?";
                Console.WriteLine(TableHeader);

                /// <summary>
                /// Loops through each employee in <see cref="employees"/>, changes Decimal.MinValue to 0 for neater display, and prints out parsing results in table form.
                /// </summary>
                foreach (var employee in employees)
                {

                    if (employee.Salary == Decimal.MinValue)
                    {
                        employee.Salary = 0;
                    }
                        
                    var PrintLine = $"{employee.FullName}\t|{employee.Birthdate.ToShortDateString()}\t|${employee.Salary}\t|{employee.DateHired.ToShortDateString()}\t|{employee.PrintIfValid}";
                    Console.WriteLine(PrintLine);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            Console.ReadKey();
        }
    }
}
