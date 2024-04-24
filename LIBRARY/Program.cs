using LIBRARY.entity;
using System;

namespace LIBRARY
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
            Console.WriteLine("Hello User! Welcome to library app.");
            Console.WriteLine("Please select action:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Get list of books");
            Console.WriteLine("3. Search books");
            string action = Console.ReadLine();
            Repository<Book> bookRepository = new Repository<Book>();
                Console.Clear();     
            switch (action)
            {
                case "1":
                    Book book = classes.ItemInitializator.InitializeBook();
                    bookRepository.Add(book);
                    Console.WriteLine("Book added: {0}", book.Title);
                    break;
                case "2":
                 var books = bookRepository.GetAll("Book.json");
                    Console.WriteLine("List of books: {0}", books.Count);
                    break;
                case "3":
                    Console.WriteLine("Search books:");
                    break;
                default:
                    Console.WriteLine("Invalid action");
                    break;
            }
            Console.WriteLine(action);
          
            } while (true);
          
           
        }
    }
}
