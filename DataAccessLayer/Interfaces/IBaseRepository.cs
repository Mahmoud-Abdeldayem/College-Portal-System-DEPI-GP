using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        IEnumerable<T> Get(Expression<Func<T , bool>> criteria);
        T DeleteById(int id);
        T Delete(T Entity);
        T Update(T entity);
        T Insert(T entity);
    }
}
