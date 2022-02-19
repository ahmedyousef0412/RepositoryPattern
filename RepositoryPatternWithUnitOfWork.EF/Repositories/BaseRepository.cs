using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using RepositoryPatternWithUnitOfWork.EF.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{

    //Implementation To IBaseRepository
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly ApplicationDbConext _context;


        public BaseRepository(ApplicationDbConext conext)
        {
            _context = conext;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Find(Expression<Func<T, bool>> match)
        {
          return _context.Set<T>().SingleOrDefault(match);
             
        }
        public T Find(Expression<Func<T, bool>> match , string [] include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if(include != null)
            foreach (var includes in include)
             query = query.Include(includes);

            return query.SingleOrDefault(match);

        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
                foreach (var includes in include)
                    query = query.Include(includes);

            return query.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip, string[] include = null)
        {
            IQueryable<T> query = _context.Set<T>().Where(match);

            if (include != null)
                foreach (var includes in include)
                    query = query.Include(includes);

            if(take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            return query.ToList();



        }
    }
}
