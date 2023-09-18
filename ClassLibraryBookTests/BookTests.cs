using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBook.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void ExceptionIdLessOrEqual0() // Checks if the id is less or equal to 0
        {
            // Arrange
            var book = new Book(0, "Test Title", 500);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.ValidateId());
        }
        [TestMethod]
        public void ExceptionNullOrLess3Char() // Checks if the title is null or less than 3 characters
        {
            // Arrange
            var book = new Book(1, "", 500);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.ValidateTitle());
            // Arrange
            book = new Book(1, "ab", 500);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.ValidateTitle());
        }
        [TestMethod]
        public void ExceptionGreater1200or0() // Checks if the price is greater than 1200 or less than 0
        {
            // Arrange
            var book = new Book(1, "Test Title", -1);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.ValidatePrice());
            // Arrange
            book = new Book(1, "Test Title", 1201);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.ValidatePrice());
        }


        [TestMethod]
        public void ToStringEqual() // Checks if the ToString method returns the correct string
        {
            // Arrange
            var book = new Book(1, "Test", 500);
            var expected = "Id: 1, Title: Test, Price: 500";
            // Act
            var actual = book.ToString();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoParanmeterConstructor() // Checks if the no parameter constructor works
        {
            // Arrange & Act
            var book = new Book();
            // Assert
            Assert.IsNotNull(book);
        }
    }
}

