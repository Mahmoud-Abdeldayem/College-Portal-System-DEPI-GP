using DataAccessLayer.Entities;
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
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context) //=> from the UnitOfWork
        {
            _context = context;
        }

        public T Delete(T Entity)
        {
            _context.Remove(Entity);
            return Entity;
        }

        public T DeleteById(int id)
        {
            var entitiy = _context.Set<T>().Find(id);
            _context.Remove(entitiy);
            return entitiy;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> criteria)
        {
            var entity = _context.Set<T>().Where(criteria);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            _context.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

    }
}
