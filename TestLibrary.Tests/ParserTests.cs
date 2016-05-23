using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestLibrary;
using TestLibrary.Tests;

namespace TestLibrary.Tests
{
    [TestClass]
    public class ParserTests
    {

        private Parser parser;
        private FileValidator fileValidator;
        private LineParser lineParser;
        private EmployeeGenerator employeeGenerator;
        private StringConverter stringConverter;

        [TestInitialize]
        public void TestInitialize()
        {
            fileValidator = new FileValidator();
            stringConverter = new StringConverter();
            employeeGenerator = new EmployeeGenerator(stringConverter);
            lineParser = new LineParser(stringConverter, employeeGenerator);
            parser = new Parser(fileValidator, lineParser); ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfGivenAnInvalidFileName()
        {
            // Arrange

            // Act
            parser.Parse(null);

            // Assert
            // Expected exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfGivenNonexistentFileName()
        {
            // Arrange

            // Act
            parser.Parse("readme.txt");

            // Assert
            // Expected exception
        }

        [TestMethod]
        public void ShouldNotThrowExceptionIfGivenValidFileName()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            try
            {
                parser.Parse(FileName);
            }
            catch
            {
                throw new ArgumentException("File name is invalid/File cannot be found");
            }

            // Assert
            // No Exception
        }

        // Same method as previous test because if program can parse 
        // Successfully then it can read all lines successfully
        [TestMethod]
        public void ShouldReadAllLinesOfValidFile()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            try
            {
                parser.Parse(FileName);
            }
            catch
            {
                throw new ArgumentException("File name is invalid/File cannot be found");
            }

            // Assert
            // No Exception passes
        }

        [TestMethod]
        public void ShouldParseAllFiveEmployees()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.AreEqual(5, employees.Count);
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithMissingFieldsAsInvalid()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[3].IsValid, "Tony Sprona must be invalid");
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithInvalidBirthdateAsInvalid()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employee = parser.Parse(FileName);

            // Assert
            Assert.IsFalse(employee[2].IsValid, "Mark Stowell must be invalid");
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithInvalidSalaryAsInvalid()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[2].IsValid, "Mark Stowell must be invalid");
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithInvalidDateHiredAsInvalid()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[4].IsValid, "Jan Seveg must be invalid");
        }

        [TestMethod]
        public void ShouldRemoveQuotesFromNames()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.AreEqual("John Smith", employees[0].FullName, "Name should have no double quotes");
            Assert.AreEqual("Karl Johnson", employees[1].FullName, "Name should have no double quotes");
            Assert.AreEqual("Mark Stowell", employees[2].FullName, "Name should have no double quotes");
            Assert.AreEqual("Tony Spronan", employees[3].FullName, "Name should have no double quotes");
            Assert.AreEqual("Jan Seveg", employees[4].FullName, "Name should have no double quotes");
        }

        [TestMethod]
        public void ShouldMarkEmployeesWithValidRecordsAsValid()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.IsTrue(employees[0].IsValid, "John Smith's record must be valid");
            Assert.IsTrue(employees[1].IsValid, "Karl Johnson's record must be valid");
        }

        [TestMethod]
        public void ShouldMarkEmployeesWithInvalidRecordsAsInvalid()
        {
            // Arrange
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = parser.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[2].IsValid, "Mark Stowell's record must be valid");
            Assert.IsFalse(employees[3].IsValid, "Tony Spronan's record must be valid");
            Assert.IsFalse(employees[4].IsValid, "Jan Seveg's record must be valid");
        }

    }
}
