using System;
using System.Linq;

namespace AdvancedCSharp
{
    public class LinqTests
    {
        public void LastExtensionMethod()
        {
            var books = new BookRepository().GetBooks();

            //LD "first"
            //var book = books.First();
            //Console.WriteLine(book.title);

            //LD "filter"
            var filteredBooks = books.Where(bokkk => bokkk.pages < 30);
            foreach (var aBook in filteredBooks)
            {
                Console.WriteLine(aBook.title);
            }

            //LD "max"
            //var count = books.Max(b => b.pages);
            //Console.WriteLine(count);

            //LD "skip and Take"
            //var pagedBooks = books.Skip(2).Take(3);
            //foreach (var aBook in pagedBooks)
            //{
            //    Console.WriteLine(aBook.title);
            //}

        }
    }
}
