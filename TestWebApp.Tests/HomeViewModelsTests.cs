using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebApp.Models;

namespace TestWebApp.Tests
{
    [TestClass]
    public class HomeViewModelsTests
    {
        [TestMethod]
        public void ShouldShowFiveObjectsInHomeViewModelAsNull()
        {
            // Arrange
            var sut = new HomeViewModels();

            // Act

            // Assert
            Assert.IsNull(sut.Title);
            Assert.IsNull(sut.Message);
            Assert.IsNull(sut.Exception);
            // Boolean cannot be false, so assert that sut.Uploaded is False
            Assert.IsFalse(sut.Uploaded);
            Assert.IsNull(sut.Employees);
        }
    }
}