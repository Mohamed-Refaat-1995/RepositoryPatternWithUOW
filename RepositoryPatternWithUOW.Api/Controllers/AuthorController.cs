using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.core.Interfaces;
using RepositoryPatternWithUOW.core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name) => Ok(_unitOfWork.Authors.FindByExpression(a => a.Name == name));

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            _unitOfWork.Authors.Add(author);
            return Ok();
        }

    }
}
