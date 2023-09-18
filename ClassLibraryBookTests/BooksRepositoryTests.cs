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
public class BooksRepositoryTests
{
    [TestMethod]
    public void FiveBooks() // Checks if there are 5 books in the list
    {
        // Act
        var repository = new BooksRepository();
        // Assert
        Assert.AreEqual(5, repository.Get().Count);
    }


    [TestMethod]
    public void Get_ShouldReturnListOfBooks() // Checks if the list is a list of books
    {
        // Arrange
        var repository = new BooksRepository();
        // Act
        var result = repository.Get();
        // Assert
        Assert.IsInstanceOfType(result, typeof(List<Book>));
    }


    [TestMethod()]
    public void AddTest() // Add a book to the list test
    {
        //Arrange
        var c = new BooksRepository();
        //Act
        var book = new Book(1, "Tester", 1100);
        c.Add(book);
        //Assert
       Assert.AreEqual(5, c.Get().Count); 
       Assert.AreEqual(1, c.Get()[0].Id);
       Assert.AreEqual("Tester", c.Get()[0].Title);
       Assert.AreEqual(1100, c.Get()[0].Price);
    }


    [TestMethod]
    public void RemoveTest() // remove a book from the list
    {
        //Arrange
        var c = new BooksRepository();
        //Act
        c.Delete(2);
        //Assert
        Assert.AreEqual(2, c.Get().Count);
        Assert.AreEqual(1, c.Get()[0].Id);
        Assert.AreEqual(3, c.Get()[1].Id);
        Assert.ThrowsException<ArgumentException>(() => c.Delete(4));

    }


    [TestMethod]
    public void UpdateTest() // update a book in the list
    {
        var c = new BooksRepository();
        c.Update(2, new Book(2, "Hobitten",1100));
        Assert.AreEqual(3, c.Get().Count);
        Assert.AreEqual(2, c.Get()[1].Id);
        Assert.AreEqual("Hobitten", c.Get()[1].Title);
        Assert.AreEqual(1100, c.Get()[1].Price);


    }





    [TestMethod]
    public void GetByIdReturnBook() // Returns a book by Id
    {
        // Arrange
        var repository = new BooksRepository();
        // Act
        var result = repository.GetById(1);
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void GetByIdNull_IfNoBook() // Returns null if no book matching the Id
    {
        // Arrange
        var repository = new BooksRepository();
        // Act
        var result = repository.GetById(999);
        // Assert
        Assert.IsNull(result);
    }
}


}
