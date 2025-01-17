using Bookstore.API.Home.BookApi;

namespace Bookstore.API.Communication.RequestBook
{
    public class RequestUpdateBook : Book
    {
        public string? UpdateEmail { get; set; } // email Confirmação

    }
}
