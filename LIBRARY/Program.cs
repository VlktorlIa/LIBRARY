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
    Console.WriteLine("4. Add user");
    Console.WriteLine("5. Get list of users");
    Console.WriteLine("6. User take a book");
    string action = Console.ReadLine();
    Repository<Book> bookRepository = new Repository<Book>();
    Repository<User> userRepository = new Repository<User>();
    Repository<Libr> librRepository = new Repository<Libr>();
    Console.Clear();
    switch (action)
    {
        case "1":
            Book book = (Book)ItemInitializator.Initialize(typeof(Book));

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
        case "4":
            User user = (User)ItemInitializator.Initialize(typeof(User));
            userRepository.Add(user);
            Console.WriteLine("User added: {0}", user.Name);
            break;
        case "5":
            List<User> users = Repository<User>.GetAll(typeof(User));
            users.ForEach(b => Console.WriteLine("Name: {0} , INN: {1}", b.Name, b.INN));
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Count of users: {0}. Press enter to continue...", users.Count);
            Console.ReadLine();
            break;
        case "6":
            Libr libr = new Libr();
            libr.Date = DateTime.Now;
            bool userFound = false;
            bool bookFound = false;
            do
            {
                Console.WriteLine("Please enter user ID:");
                string userID = Console.ReadLine();

                if (userRepository.isExist(int.Parse(userID)))
                {
                    userFound = true;
                    libr.INN = int.Parse(userID);

                }
            } while (!userFound);
            Console.WriteLine("Please enter book ISBN:");
            string bookISBN = Console.ReadLine();
            libr.ISBN = bookISBN;
            librRepository.Add(libr);

            break;
        default:
            Console.WriteLine("Invalid action");
            break;
    }
    //Console.WriteLine(action);

} while (true);
