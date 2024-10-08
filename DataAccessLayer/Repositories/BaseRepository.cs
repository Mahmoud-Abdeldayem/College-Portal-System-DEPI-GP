using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //DB Context reference
        //protected ApplicationDbContext _context;
        //Inject the Context object using constructor injection
        //Implement the methods using this context

        //public BaseRepository(ApplicationDbContext context) => from the UnitOfWork
        //{
        //    _context = context;
        //}

        public T Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public T DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
