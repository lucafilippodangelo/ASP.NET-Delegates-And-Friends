using System;

//LD TEST010
namespace ExtensionMethodsLd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Extension Methods!");
        }
    }

    public static class MyExtensions
    {
        public static string concatBookInfo(this BookLd aBook)
        {
            return string.Concat(aBook.title + " " + aBook.price);
        }
    }

    public class BookLd
    {
        public string title { get; set; }
        public int pages { get; set; }
        public int price { get; set; }
    }
}
