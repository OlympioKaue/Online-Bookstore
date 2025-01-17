using Bookstore.API.Communication.RequestBook;

namespace Bookstore.API.Home.BookApi
{
    public class Book 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Gender { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Password { get; set; }
    }
}
