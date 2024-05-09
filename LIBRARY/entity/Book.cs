
namespace LIBRARY.entity
{
    class Book : ItemInterface
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }

        public bool IsMatch(string search)
        {
            return Title.Contains(search) || Author.Contains(search);
        }
    }
 }
