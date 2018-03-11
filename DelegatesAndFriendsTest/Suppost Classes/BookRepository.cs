using System.Collections.Generic;

namespace AdvancedCSharp
{
    public class BookRepository
    {
        //public BookRepository() { }

        public List<Book> GetBooks()
        {
            List<Book> Books = new List<Book>
            { 
                new Book() { title = "book title 1", pages= 10, price = 5},
                new Book() { title = "book title 2", pages= 20 , price=7},
                new Book() { title = "book title 3", pages= 30 , price = 17}
            };
            return Books;
        }

    }
}
