using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.EF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{

    //Implementation To IBaseRepository
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly  ApplicationDbConext _context;

        public BaseRepository(ApplicationDbConext conext)
        {
            _context = conext;
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
