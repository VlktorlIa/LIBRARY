using System;

namespace LIBRARY
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User! Welcome to library app.");
            Console.WriteLine("Please select action:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Get list of books");
            Console.WriteLine("3. Search books");

            string action = Console.ReadLine();

            Console.WriteLine(action);
        }
    }
}
