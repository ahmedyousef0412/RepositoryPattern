using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.Core.Const;
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




        public T Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }
       public T Find(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            //Must Check if i have [Include] 

            IQueryable<T> query = _context.Set<T>();
             
            if (includes != null)
                foreach (var includeValue in includes)
                    query = query.Include(includeValue);
            return query.SingleOrDefault(expression);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(expression).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, int skip, int take)
        {
           return _context.Set<T>().Where(expression).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, int? skip, int? take, Expression<Func<T, object>> orderby, string OrderByDirection =OrderBy.Ascending)
        {

            // But Where [first] because i need to [filter] data first
            // then do opeartion like[skip,take, orderby,....]
            IQueryable<T> query = _context.Set<T>().Where(expression);

            if(skip.HasValue)
                query = query.Skip(skip.Value);     

            if(take.HasValue)   
                query = query.Take(take.Value);

            if(orderby !=null)
            {
                if(OrderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);
            }
            return query.ToList();    
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }















        #region Test
        //public T Find(Expression<Func<T, bool>> match)
        //{
        //  return _context.Set<T>().SingleOrDefault(match);

        //}
        //public T Find(Expression<Func<T, bool>> match , string [] include = null)
        //{
        //    IQueryable<T> query = _context.Set<T>();

        //    if(include != null)
        //    foreach (var includes in include)
        //     query = query.Include(includes);

        //    return query.SingleOrDefault(match);

        //}

        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] include = null)
        //{
        //    IQueryable<T> query = _context.Set<T>();

        //    if (include != null)
        //        foreach (var includes in include)
        //            query = query.Include(includes);

        //    return query.Where(match).ToList();
        //}

        //public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip, string[] include = null)
        //{
        //    IQueryable<T> query = _context.Set<T>().Where(match);

        //    if (include != null)
        //        foreach (var includes in include)
        //            query = query.Include(includes);

        //    if(take.HasValue)
        //        query = query.Take(take.Value);

        //    if (skip.HasValue)
        //        query = query.Skip(skip.Value);

        //    return query.ToList();



        //}

        #endregion
    }
}
