using LIBRARY;
using LIBRARY.entity;
using LIBRARY.classes;
using System;
using System.Collections.Generic;

do
{
    Console.Clear();
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
            Book book = ItemInitializator.InitializeBook();
            bookRepository.Add(book);
            Console.WriteLine("Book added: {0}", book.Title);
            break;
        case "2":
            List<Book> books = Repository<Book>.GetAll(typeof(Book));
            books.ForEach(b => Console.WriteLine("Autor: {0} , Title: {1}", b.Author, b.Title));
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Count of books: {0}. Press enter to continue...", books.Count);
            Console.ReadLine();
            break;
        case "3":
            Console.WriteLine("Search books by Title or author:");
            string searchRequest = Console.ReadLine();
            List<Book> searchResult = Repository<Book>.GetAll(typeof(Book)).FindAll(b => b.IsMatch(searchRequest));
            searchResult.ForEach(b => Console.WriteLine("Autor: {0} , Title: {1}", b.Author, b.Title));
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Count of finded books: {0}. Press enter to continue...", searchResult.Count);
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Invalid action");
            break;
    }
    //Console.WriteLine(action);

} while (true);
