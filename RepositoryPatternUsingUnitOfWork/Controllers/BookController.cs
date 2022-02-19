using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Dtos;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;

namespace RepositoryPatternUsingUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBaseRepository<Book> bookRepository ,IMapper mapper)
        {
           _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAll();
            var dto = _mapper.Map<IEnumerable<BookDetailsDto>>(books);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var bookId = _bookRepository.GetById(id);

            if(bookId == null)
                return BadRequest($"The Id that you find {id} Not Found");

            var dto = _mapper.Map<IEnumerable<BookDetailsDto>>(bookId);
            return Ok(dto);
        }

        [HttpGet("GetByBookName")]
        public IActionResult GetByBookName()
        {
            return Ok( _bookRepository.Find(b => b.Title =="Sql Server"));

           
        }

        [HttpGet("GetAllIncludeAuthorsName")]
        public IActionResult GetAllIncludeAuthorsName()
        {
            var books = _bookRepository.Find(b => b.Title == "Design Pattern",new[] {"Author"});
            var dto = _mapper.Map<BookDetailsDto>(books);
            return Ok(dto);
        }
        [HttpGet("GetAllIncludeAuthorsNameAndTakeAndSkip")]
        public IActionResult GetAllIncludeAuthorsNameAndTakeAndSkip()
        {
            var books = _bookRepository.FindAll(b => b.Title == "Design Pattern", 2,2, new[] { "Author" });
            var dto = _mapper.Map< IEnumerable<BookDetailsDto>>(books);
            return Ok(dto);
        }
    }
}
