using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestLibrary.Tests
{
    [TestClass]
    public class EmployeeTests
    {

        [TestMethod]
        public void ShouldAssignNewGuidWhenNewInstanceOfEmployeeClass()
        {
            // Arrange
            Employee sut = new Employee();

            // Act

            // Assert
            Assert.AreNotEqual("00000000-0000-0000-0000-000000000000", sut.Id.ToString());
        }

        [TestMethod]
        public void ShouldShowInvalidWhenFieldsAreMissing()
        {
            // Arrange
            Employee sut = new Employee();

            // Act

            // Assert
            Assert.IsFalse(sut.IsValid, "Employee should be invalid");
        }

        [TestMethod]
        public void ShouldShowInvalidWhenBirthdateIsInvalid()
        {
            // Arrange
            Employee sut = new Employee();
            sut.FullName = "FullName";
            sut.DateHired = DateTime.Parse("07/04/1776");
            sut.Salary = 100000;

            // Act
            try
            {
                sut.Birthdate = DateTime.Parse("02/30/1992");
            }
            catch
            {
                sut.Birthdate = DateTime.MinValue;
            }

            // Assert
            Assert.IsFalse(sut.IsValid, "Birthdate should be invalid");
        }

        [TestMethod]
        public void ShouldShowInvalidWhenDateHiredIsInvalid()
        {
            // Arrange
            Employee sut = new Employee();
            sut.FullName = "FullName";
            sut.Birthdate = DateTime.Parse("07/04/1776");
            sut.Salary = 100000;

            // Act
            try
            {
                sut.DateHired = DateTime.Parse("02/30/2016");
            }
            catch
            {
                sut.DateHired = DateTime.MinValue;
            }

            // Assert
            Assert.IsFalse(sut.IsValid, "Date hired should be invalid");
        }

        [TestMethod]
        public void ShouldShowInvalidWhenSalaryIsNotGreaterThanZero()
        {
            // Arrange
            Employee sut = new Employee();
            sut.FullName = "FullName";
            sut.Birthdate = DateTime.Parse("07/04/1776");
            sut.DateHired = DateTime.Parse("07/04/1776");
            sut.Salary = 0;

            // Act

            // Assert
            Assert.IsFalse(sut.IsValid, "Salary should be invalid");
        }

        [TestMethod]
        public void ShouldShowInvalidWhenSalaryIsInvalid()
        {
            // Arrange
            Employee sut = new Employee();
            sut.FullName = "FullName";
            sut.Birthdate = DateTime.Parse("07/04/1776");
            sut.DateHired = DateTime.Parse("07/04/1776");

            // Act
            try
            {
                sut.Salary = Decimal.Parse("58000a");
            }
            catch
            {
                sut.Salary = Decimal.MinValue;
            }

            // Assert
            Assert.IsFalse(sut.IsValid, "Salary should be invalid");
        }

        [TestMethod]
        public void ShouldShowValidIfAllFieldsAreValid()
        {
            // Arrange
            Employee sut = new Employee();
            sut.FullName = "FullName";
            sut.Birthdate = DateTime.Parse("11/20/1992");
            sut.DateHired = DateTime.Parse("05/12/2016");
            sut.Salary = 55000;

            // Act

            // Assert
            Assert.IsTrue(sut.IsValid, "Employee should be valid");
        }

    }
}
