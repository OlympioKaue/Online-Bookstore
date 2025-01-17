using Bookstore.API.Communication;
using Bookstore.API.Communication.RequestBook;
using Bookstore.API.Communication.ResponseBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Bookstore.API.Home.BookApi;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;


namespace Bookstore.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreFirstController : ControllerBase
    {
        // armazenamento temporario em formato List
        private static List<Book> bookstore = new List<Book>();
        // private torna a lista segura e livre de modificações (forçamos a implementação no post e get).
        // static torna o compartilhamento de dados (métodos ou insância utilizam os mesmos dados).


        //criação do livro
        [HttpPost]
        [ProducesResponseType(typeof(ResponseBook), StatusCodes.Status201Created)]
        public IActionResult Creat([FromBody] Book Receiving)
        {
            //adicione a lista
            bookstore.Add(Receiving);

            return Created(string.Empty, Receiving);


        }


        //recupe a lista
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(bookstore);
        }


        //recupe a lista (atraves do Id especifico).
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseBook), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            
            var book = bookstore.FirstOrDefault(x => x.Id == id); //usando LinQ

            if (book != null)
            {
                if (book.Id == book.Id) // Post == GetById
                {
                    return Ok($"Id encontrado {id}");
                }
                else
                {
                    return NotFound("Erro ao encontrar id");
                }
            }
            else
            {
                // se id for null
                return NotFound("Nenhum id encotrado !");
            }


        }


        //Atualize o email
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BookUpdate([FromBody] ResponseBook Update)
        {
            var email = new RequestUpdateBook
            {
                UpdateEmail = Update.Email
            };

            // Por que optei por manter o (200 OK), ao ínves do (204 NoContent) ?
            //  - Para que o user veja o email alterado.
            return Ok(email);
        }


        //Deleta 
        [HttpDelete]
        [Route("{password}")]
        [ProducesResponseType(typeof(RequestDeleteBookCreated), StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int password)
        {
            
            var book = bookstore.FirstOrDefault(x => x.Password == password);

            // se a senha for 123, exclua a lista, caso for falso, permaneca com a lista.
            var application = password == 123 ? bookstore : bookstore;

            return Ok(application);
            
            
            
        }


    }
}
