using LIBRARY.entity;
using System;

namespace LIBRARY.classes
{
    internal class ItemInitializator
    {
        public static Object Initialize(Type type)
        {
            Console.Clear();
            Object item = Activator.CreateInstance(type);
            foreach (var prop in item.GetType().GetProperties())
            {
                Console.WriteLine("Please enter {1} {0}", prop.Name, type.Name);
                bool success = false;
                do {
                    try
                    {
                        string value = Console.ReadLine();
                        prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType));
                        success = true;
                    } catch (Exception e)
                    {
                        Console.WriteLine("Invalid value. Please try again.");
                    }
                } while (!success);
                Console.Clear();
            }          
            return item;
        }
    }
}
