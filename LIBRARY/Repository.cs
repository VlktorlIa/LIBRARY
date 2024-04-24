using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace LIBRARY
{
    internal class Repository<T>
    {

        public void Add(T item)
        {
            string fileName = item.GetType().Name + ".json";
            string path = Directory.GetCurrentDirectory();
            string _filePath = GetFilePath(item);
            if (!File.Exists(_filePath))
            {
                // Create an empty array and serialize it to create the file
                var emptyArray = new List<T>();
                Save(emptyArray, _filePath);
            }
            var items = GetAll(_filePath);
            items.Add(item);
            Save(items, _filePath);
        }

        public List<T> GetAll(string _filePath)
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void Save(List<T> items, string _filePath)
        {
            var json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public string GetFilePath(T item)
        {
            return Directory.GetCurrentDirectory() + "\\" + item.GetType().Name + ".json";
        }

    }
}
