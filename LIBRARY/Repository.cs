using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LIBRARY
{
    internal class Repository<T>
    {

        public void Add(T item)
        {
            string _filePath = GetFilePath(item.GetType());
            if (!File.Exists(_filePath))
            {
                // Create an empty array and serialize it to create the file
                var emptyArray = new List<T>();
                Save(emptyArray, _filePath);
            }
            var items = GetAll(item.GetType());
            items.Add(item);
            Save(items, _filePath);
        }

        public static List<T> GetAll(Type type)
        {
            string _filePath = GetFilePath(type);
            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static void Save(List<T> items, string _filePath)
        {
            var json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public static string GetFilePath(Type type)
        {
            return Directory.GetCurrentDirectory() + "\\" + type.Name + ".json";
        }

    }
}
