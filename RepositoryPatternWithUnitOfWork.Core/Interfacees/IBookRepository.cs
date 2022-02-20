using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Interfacees
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SecialMethod();
    }
}
