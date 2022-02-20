using RepositoryPatternWithUnitOfWork.Core.Interfacees;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.EF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{
    public class BookRepository : BaseRepository<Book> , IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context): base(context)
        {
            
        }

        public IEnumerable<Book> SecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
