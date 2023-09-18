﻿using ClassLibraryBook;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryBook

{
    public class BooksRepository
    {


        private List<Book> books;

        public BooksRepository()
        {
            books = new List<Book>();
            // Add at least 5 initial books
            books.Add(new Book(1, "Harry Potter and the Philosopher's Stone", 499));
            books.Add(new Book(2, "Harry Potter and the Chamber of Secrets", 499));
            books.Add(new Book(3, "Harry Potter and the Prisoner of Azkaban", 499));
            books.Add(new Book(4, "Harry Potter and the Goblet of Fire", 499));
            books.Add(new Book(5, "Harry Potter and the Order of the Phoenix", 499));

        }

        public List<Book> Get() // Get list of books 
        {
            return new List<Book>(books);
        }
         



        public List<Book> Get(Func<Book, bool> filter = null, Func<IEnumerable<Book>, IOrderedEnumerable<Book>> orderBy = null) // Get list of books with filter and order by price or title 
        {
            IEnumerable<Book> result = books;

            if (filter != null)
            {
                result = result.Where(filter);
            }

            if (orderBy != null)
            {
                result = orderBy(result);
            }

            return result.ToList();
        }


        public Book GetById(int id) // Get book by id
        {
            return books.FirstOrDefault(book => book.Id == id);
        }


        //Add metode 
        public Book Add(Book book)
        {
            book.ValidateId();
            book.ValidateTitle();
            book.ValidatePrice();

            books.Add(book);
            return book;
        }


        //Delete metode 
        public Book Delete(int id)
        {
            Book bookToRemove = GetById(id);

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }

            return bookToRemove;
        }


        //Update metode 
        public Book Update(int id, Book values)
        {
            Book bookToUpdate = GetById(id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = values.Title;
                bookToUpdate.Price = values.Price;
            }

            return bookToUpdate;
        }
    }
}