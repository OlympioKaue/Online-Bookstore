using Bookstore.API.Communication.RequestBook;
using Bookstore.API.Home.BookApi;
using System.Text.Json.Serialization;

namespace Bookstore.API.Communication.ResponseBook
{
    public class ResponseBook
    {
        public string? Name { get; set; }
        public string? Email { get; set; }


    }
}
