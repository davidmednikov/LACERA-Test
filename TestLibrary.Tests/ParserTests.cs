using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestLibrary.Tests
{
    [TestClass]
    public class ParserTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfGivenAnInvalidFileName()
        {
            // Arrange
            Parser sut = new Parser();

            // Act
            sut.Parse(null);

            // Assert
            // Expected exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfGivenNonexistentFileName()
        {
            // Arrange
            Parser sut = new Parser();

            // Act
            sut.Parse("readme.txt");

            // Assert
            // Expected exception
        }

        [TestMethod]
        public void ShouldNotThrowExceptionIfGivenValidFileName()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            try
            {
                sut.Parse(FileName);
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
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            try
            {
                sut.Parse(FileName);
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
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

            // Assert
            Assert.AreEqual(5, employees.Count);
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithMissingFieldsAsInvalid()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[3].IsValid, "Tony Sprona must be invalid");
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithInvalidBirthdateAsInvalid()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employee = sut.Parse(FileName);

            // Assert
            Assert.IsFalse(employee[2].IsValid, "Mark Stowell must be invalid");
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithInvalidSalaryAsInvalid()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[2].IsValid, "Mark Stowell must be invalid");
        }

        [TestMethod]
        public void ShouldFlagEmployeesWithInvalidDateHiredAsInvalid()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[4].IsValid, "Jan Seveg must be invalid");
        }

        [TestMethod]
        public void ShouldRemoveQuotesFromNames()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

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
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

            // Assert
            Assert.IsTrue(employees[0].IsValid, "John Smith's record must be valid");
            Assert.IsTrue(employees[1].IsValid, "Karl Johnson's record must be valid");
        }

        [TestMethod]
        public void ShouldMarkEmployeesWithInvalidRecordsAsInvalid()
        {
            // Arrange
            Parser sut = new Parser();
            string FileName = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            List<Employee> employees = sut.Parse(FileName);

            // Assert
            Assert.IsFalse(employees[2].IsValid, "Mark Stowell's record must be valid");
            Assert.IsFalse(employees[3].IsValid, "Tony Spronan's record must be valid");
            Assert.IsFalse(employees[4].IsValid, "Jan Seveg's record must be valid");
        }

    }
}
