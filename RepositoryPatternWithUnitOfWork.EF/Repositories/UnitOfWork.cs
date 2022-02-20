using RepositoryPatternWithUnitOfWork.Core.Interfacees;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.Core.UnitOfWork;
using RepositoryPatternWithUnitOfWork.EF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _conext;

        public IBaseRepository<Author> Authors { get; private set; }

        public IBookRepository Books { get; private set; }

        //public IBaseRepository<Book> Books { get; private set; }
        public UnitOfWork(ApplicationDbContext conext)
        {
           _conext = conext;
            Authors = new BaseRepository<Author>(_conext);
            //Books = new BaseRepository<Book>(_conext);
            Books = new BookRepository(_conext);
        }


        public int Complete()
        {
            return _conext.SaveChanges();
        }

        public void Dispose()
        {
            _conext.Dispose();
        }
    }
}
