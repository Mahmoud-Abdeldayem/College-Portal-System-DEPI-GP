using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
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

        public IdentityUserRole<string> AddRole(ApplicationUser user, int roleId)
        {
            var userRole = new IdentityUserRole<string>
            {
                UserId = user.NationalId, // Use the user's primary key (NationalId)
                RoleId = roleId.ToString() // Assuming role.Id is already a string
            };

            _context.UserRoles.Add(userRole);
            _context.SaveChangesAsync();
            return userRole;
        }        

        public string GetRole(string Id)
        {
            var role = _context.Users.FirstOrDefault(x => x.Id == Id);

            return role.Role;
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

        public T GetByEmail(string email)
        {
            return _context.Set<T>().Find(email);
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

        public IdentityUserRole<string> AddRole(ApplicationUser user, IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public IdentityUserRole<string> AddRole(ApplicationUser user, string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
