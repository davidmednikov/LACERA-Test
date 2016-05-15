using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLibrary.Tests
{
    [TestClass]
    public class StringConverterTests
    {
        [TestMethod]
        public void ShouldReturnMinValueWhenDateIsInvalid()
        {
            // Arrange
            StringConverter sut = new StringConverter();
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
            StringConverter sut = new StringConverter();
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
            StringConverter sut = new StringConverter();
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
            StringConverter sut = new StringConverter();
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
            StringConverter sut = new StringConverter();
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
            StringConverter sut = new StringConverter();
            var expected = new Decimal(125000);

            // Act
            var actual = sut.ConvertSalary("125000");

            // Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
