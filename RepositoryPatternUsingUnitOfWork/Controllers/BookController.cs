using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Const;
using RepositoryPatternWithUnitOfWork.Core.Dtos;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.Core.UnitOfWork;

namespace RepositoryPatternUsingUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly IBaseRepository<Book> _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _unitOfWork.Books.GetAll();
            var dto = _mapper.Map<IEnumerable<BookDetailsDto>>(books);
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var bookId = _unitOfWork.Books.GetById(id);

            if (bookId == null)
                return BadRequest($"The Id that you find {id} Not Found");

            var dto = _mapper.Map<IEnumerable<BookDetailsDto>>(bookId);
            return Ok(dto);
        }

        [HttpGet("GetByBookName")]
        public IActionResult GetByBookName(string title)
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title.Contains(title)));
        }

        [HttpGet("GetAllIncludeAuthorsName")]
        public IActionResult GetAllIncludeAuthorsName(string title, string include)
        {
            var books = _unitOfWork.Books.Find(b => b.Title.Contains(title), new[] { include });
            var dto = _mapper.Map<BookDetailsDto>(books);
            return Ok(dto);
        }



        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered(string title)
        {
            var books = _unitOfWork.Books.FindAll(b => b.Title.Contains(title), null, null, b => b.Id, OrderBy.Descending);
            var dto = _mapper.Map<IEnumerable<BookDetailsDto>>(books);
            return Ok(dto);
        }


        [HttpPost("AddOneBook")]
     
        public IActionResult AddBook( Book book)
        {
            var bok = _unitOfWork.Books.Add(book);
            _unitOfWork.Complete(); //SaveChanges();
          return Ok(bok);
            //return Ok(_bookRepository.Add(new Book()
            //{
            //    Title = "DataBase",
            //    AuthorId = 5
            //}));
        }
        [HttpPost("AddMultiBooks")]
      
        [HttpPost]
        public IActionResult AddMultiBooks(List<Book> books)
        {

            var book = _unitOfWork.Books.AddRange(books);
            _unitOfWork.Complete();
            return Ok(book);
        }



    }
}
