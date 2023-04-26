using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.core.Interfaces;
using RepositoryPatternWithUOW.core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _Book;
        public BookController(IBaseRepository<Book> Book)
        {
            _Book = Book;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_Book.GetById(id));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsnc(int id)
        {
            return Ok(await _Book.GetByIdAsync(id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_Book.GetAll());
        }

        [HttpGet("GetByBookTitle")]
        public IActionResult GetById(string title)
        {
            return Ok(_Book.FindByExpression(a => a.Title == title));
        }

        [HttpGet("GetBookByIdIncludeAuthorName")]
        public IActionResult GetBookByIdIncludeAuthorName(int id)
        {


            //string[] cars = { "Author" };


            return Ok(_Book.FindByExpression(a => a.Id == id, new[] { "Author" }));
        }


        [HttpPost]
        public IActionResult AddNewBook(Book book)
        {
            _Book.Add(book);

            return Ok();
        }

        //[HttpPost("AddBookList")]
        //public IActionResult ActionName()
        //{
        //    return Ok();
        //}



    }
}
