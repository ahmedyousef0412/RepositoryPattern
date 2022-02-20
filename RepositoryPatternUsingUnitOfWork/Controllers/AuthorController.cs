using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.Core.UnitOfWork;

namespace RepositoryPatternUsingUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _authorrRepository;
        
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork  unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {

            //here [GetById] know that i need to get data from[Authors] Table
            //var authorId = _authorrRepository.GetById(id);
            var authorId = _unitOfWork.Authors.GetById(id);


            if (authorId == null)
                return BadRequest($"The Id that you find {id} Not Found");

            return Ok(authorId);
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            //return Ok(await _authorrRepository.GetAll());          
            return Ok(await _unitOfWork.Authors.GetAll());
        }
    }
}
