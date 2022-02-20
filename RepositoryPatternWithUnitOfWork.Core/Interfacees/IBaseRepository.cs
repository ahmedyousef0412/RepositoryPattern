using RepositoryPatternWithUnitOfWork.Core.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Repositories
{
    //This Mean the[IBaseRepository<T>] will accept Any [Class] i will pass to it.
    public interface IBaseRepository<T> where T : class
    {

        //Interface have only [Signature] => Head Of Function.

        T GetById(int id); // T => the return type of the class i will pass it.[Book ,Author, etc...]
          

       Task<IEnumerable<T>> GetAll();



        //Expression Using Lambda Expreesion [I Create It]
        T Find(Expression<Func<T,bool>> expression);


        //If I need to Use [Include]
        // Make it Null beacuse may be Optional
        T Find(Expression<Func<T, bool>> expression, string[] includes = null);


        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes =null);



        IEnumerable<T> FindAll(Expression<Func<T,bool>> expression, int skip , int take);

        IEnumerable<T> FindAll(Expression<Func<T,bool>> expression , int? skip , int? take ,
            
            Expression<Func<T,object>> orderby , string OrderByDirection = OrderBy.Ascending);


        T Add (T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);


        #region Test
        //T Find(Expression<Func<T, bool>> match);
        //T Find(Expression<Func<T, bool>> match ,string[] include =null);

        //IEnumerable<T> FindAll(Expression<Func<T, bool>> match , string[] include = null);
        //IEnumerable<T> FindAll(Expression<Func<T, bool>> match ,int? take  , int? skip ,string[] include = null);

        #endregion

    }
}
