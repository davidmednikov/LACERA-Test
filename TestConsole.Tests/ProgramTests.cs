using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibrary;

namespace TestConsoleTests
{
    [TestClass]
    public class ProgramTests
    {
        private readonly Parser parser;

        public ProgramTests(Parser parser)
        {
            this.parser = parser;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWithInvalidFilePath()
        {
            // Arrange
            String FileName = "notactualfile.csv";

            // Act
            var employees = parser.Parse(FileName);

            // Assert
            // Expected Exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWithNullFileName()
        {
            // Arrange
            String FileName = null;

            // Act
            var employees = parser.Parse(FileName);

            // Assert
            // Expected Exception
        }

        [TestMethod]
        public void ShouldNotThrowExceptionWithValidFilePath()
        {
            // Arrange
            String FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            try
            {
                var employees = parser.Parse(FileName);
            }
            catch
            {
                throw new ArgumentException("File path is not valid");
            }

            // Assert
            // No Exception passes
        }

        [TestMethod]
        public void ShouldReplaceDecimalMinValueWithZeroForNeatPrinting()
        {
            // Arrange
            String FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            var employees = parser.Parse(FileName);

            foreach (var employee in employees)
            {
                if (employee.Salary == Decimal.MinValue)
                {
                    employee.Salary = 0;
                }
            }

            // Assert
            Assert.AreEqual(employees[2].Salary, 0, "Mark Stowell's Salary must be 0");
            Assert.AreEqual(employees[3].Salary, 0, "Tony Spronan's Salary must be 0");
            // No Exception passes

        }
    }
}
