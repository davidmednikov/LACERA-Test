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
        public void ShouldBeInvalidWhenFieldsAreMissing()
        {
            // Arrange
            Employee sut = new Employee();

            // Act

            // Assert
            Assert.IsFalse(sut.IsValid, "Employee should be invalid");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenBirthdateIsInvalid()
        {
            // Arrange
            Employee sut = CreateSut();

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
        public void ShouldBeInvalidWhenDateHiredIsInvalid()
        {
            // Arrange
            Employee sut = CreateSut();

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
        public void ShouldBeInvalidWhenSalaryIsNotGreaterThanZero()
        {
            // Arrange
            Employee sut = CreateSut();

            // Act
            try
            {
                sut.Salary = Decimal.Parse("-1000");
            }
            catch
            {
                sut.DateHired = DateTime.MinValue;
            }

            // Assert
            Assert.IsFalse(sut.IsValid, "Salary should be invalid");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenSalaryIsInvalid()
        {
            // Arrange
            Employee sut = CreateSut();

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
        public void ShouldBeValidIfAllFieldsAreValid()
        {
            // Arrange
            Employee sut = CreateSut();

            // Act

            // Assert
            Assert.IsTrue(sut.IsValid, "Employee should be valid");
        }

        private static Employee CreateSut()
        {
            return new Employee()
            {
                FullName = "FullName",
                Birthdate = DateTime.Parse("11/20/1992"),
                DateHired = DateTime.Parse("05/12/2016"),
                Salary = 55000
            };
        }
    }
}
