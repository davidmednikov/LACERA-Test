using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebApp.Models;
using TestLibrary;
using System.IO;

namespace TestWebApp.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ShouldShowUploadViewWithNullFilePath()
        {
            // Arrange
            var sut = new HomeViewModels();
            string FilePath = null;

            // Act
            if (FilePath != null)
            {
                sut.Message = "Your results page.";
            }
            else
            {
                sut.Message = "Parse your CSV file here.";
            }

            // Assert
            Assert.AreEqual(sut.Message, "Parse your CSV file here.");
        }

        [TestMethod]
        public void ShouldShowResultsViewWithValidFilePath()
        {
            // Arrange
            var sut = new HomeViewModels();
            string FilePath = "/folder/file/";

            // Act
            if (FilePath != null)
            {
                sut.Message = "Your results page.";
            }
            else
            {
                sut.Message = "Parse your CSV file here.";
            }

            // Assert
            Assert.AreEqual(sut.Message, "Your results page.");
        }

        [TestMethod]
        public void ShouldNotThrowExceptionWithValidFilePath()
        {
            // Arrange
            var sut = new HomeViewModels();
            Parser parser = new TestLibrary.Parser();
            string FilePath = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";
            sut.Employee = parser.Parse(FilePath);

            // Act

            // Assert
            // No Exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWithInvalidFilePath()
        {
            // Arrange
            var sut = new HomeViewModels();
            Parser parser = new TestLibrary.Parser();
            string FilePath = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList1.csv";    

            // Act
            sut.Employee = parser.Parse(FilePath);

            // Assert
            // Expected Exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWithNullFilePath()
        {
            // Arrange
            var sut = new HomeViewModels();
            Parser parser = new TestLibrary.Parser();
            string FilePath = null;

            // Act
            sut.Employee = parser.Parse(FilePath);

            // Assert
            // Expected Exception
        }

        [TestMethod]
        public void ShouldSaveUploadedCSVAndCreateStringWithFilePath()
        {
            // Arrange
            var sut = new HomeViewModels();
            Parser parser = new TestLibrary.Parser();
            string FilePath = @"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv";

            // Act
            string[] CSVFile = File.ReadAllLines(FilePath);
            // Not takinge extension so that I can add "Test.csv" to the end of the file name
            var FileName = Path.GetFileNameWithoutExtension(@"C:\Users\davem\Documents\CS\lacera test\MyTest\EmployeeList.csv");
            // Using WriteAllText instead of SaveAs Because SaveAs only works with web server controllers, not unit tests
            File.WriteAllText(@"C:\Users\davem\Documents\CS\lacera test\MyTest\TestWebApp\Content\" + FileName + "Test.csv", CSVFile.ToString());
            string FilePathOnServer = Path.GetFullPath(@"C:\Users\davem\Documents\CS\lacera test\MyTest\TestWebApp\Content\EmployeeListTest.csv");


            // Assert
            Assert.AreEqual(FilePathOnServer, @"C:\Users\davem\Documents\CS\lacera test\MyTest\TestWebApp\Content\EmployeeListTest.csv");
        }
    }
}
