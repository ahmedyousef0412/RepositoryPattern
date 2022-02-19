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

        T Find(Expression<Func<T, bool>> match);
        T Find(Expression<Func<T, bool>> match ,string[] include =null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> match , string[] include = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match ,int? take  , int? skip ,string[] include = null);



    }
}
