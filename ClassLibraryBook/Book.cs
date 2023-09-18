using System;
namespace ClassLibraryBook  
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Book(int id, string title, double price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
        public Book ()      { }   

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price: {Price}";
        }

        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Id skal være ligmed eller over 0");
            }
        }

        public void ValidateTitle()
        {
            if (string.IsNullOrEmpty(Title) &&  Title.Length < 3)
            {
                throw new ArgumentException("Titel må ikke være null og skal være mindst 3 karaktere lang");
            }
        }

        public void ValidatePrice()
        {
            if (Price <= 0  || Price > 1200)
            {
                throw new ArgumentException("Pris skal være mellem 0-1200!");
            }
        }

        

    }
}