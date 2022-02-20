using RepositoryPatternWithUnitOfWork.Core.Interfacees;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.UnitOfWork
{
    public interface IUnitOfWork  : IDisposable
    {

        IBaseRepository<Author> Authors { get; }
        //IBaseRepository<Book> Books { get; }

        //Because [IBookRepository] Inherit from IBaseRepository
        IBookRepository Books { get; }

        int Complete();
    }
}
