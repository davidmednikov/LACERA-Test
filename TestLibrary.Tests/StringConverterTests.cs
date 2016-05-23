using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLibrary.Tests
{
    [TestClass]
    public class StringConverterTests
    {
        StringConverter sut = new StringConverter();

        [TestMethod]
        public void ShouldReturnMinValueWhenDateIsInvalid()
        {
            // Arrange
            var expected = DateTime.MinValue;

            // Act
            var actual = sut.ConvertDate("02/225/19995");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnMinValueWhenDateIsBlank()
        {
            // Arrange
            var expected = DateTime.MinValue;

            // Act
            var actual = sut.ConvertDate("");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldConvertDateFromValidString()
        {
            // Arrange
            var expected = new DateTime(2016, 05, 12);

            // Act
            var actual = sut.ConvertDate("05/12/2016");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnMinValueWhenSalaryIsInvalid()
        {
            // Arrange
            var expected = Decimal.MinValue;

            // Act
            var actual = sut.ConvertSalary("sixty five thousand");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnMinValueWhenSalaryIsBlank()
        {
            // Arrange
            var expected = Decimal.MinValue;

            // Act
            var actual = sut.ConvertSalary("");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldConvertSalaryFromValidString()
        {
            // Arrange
            var expected = new Decimal(125000);

            // Act
            var actual = sut.ConvertSalary("125000");

            // Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
