using LIBRARY.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.classes
{
    internal class ItemInitializator
    {
        public static Book InitializeBook()
        {
            Console.Clear();
            Book book = new Book();
            foreach (var prop in book.GetType().GetProperties())
            {
                Console.WriteLine("Please enter book {0}", prop.Name);
                bool success = false;
                do {
                    try
                    {
                        string value = Console.ReadLine();
                        prop.SetValue(book, Convert.ChangeType(value, prop.PropertyType));
                        success = true;
                    } catch (Exception e)
                    {
                        Console.WriteLine("Invalid value. Please try again.");
                    }
                } while (!success);
                Console.Clear();
            }          
            return book;
        }
    }
}
