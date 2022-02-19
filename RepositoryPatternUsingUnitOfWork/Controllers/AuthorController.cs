using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;

namespace RepositoryPatternUsingUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorrRepository;

        public AuthorController(IBaseRepository<Author> authorrRepository )
        {
            _authorrRepository = authorrRepository;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {

            //here [GetById] know that i need to get data from[Authors] Table
            var authorId = _authorrRepository.GetById(id);

            if (authorId == null)
                return BadRequest($"The Id that you find {id} Not Found");

            return Ok(authorId);
        }
    }
}
