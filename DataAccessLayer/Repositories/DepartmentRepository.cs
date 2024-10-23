using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DepartmentRepository : IBaseRepository<Department>
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext appDbContext) 
        { 
            _context = appDbContext;    
        }
        public Department Delete(Department Entity)
        {
            _context.Remove(Entity);
            return Entity;
        }

        public Department DeleteById(int id)
        {
            var department = _context.Departments.Where(d => d.DepartmentId == id).FirstOrDefault();
            if (department != null)
            {
                _context.Remove(department);
                return department;
            }
            throw new Exception("There is no department with this ID !");
        }

        public IEnumerable<Department> Get(Expression<Func<Department, bool>> criteria)
        {
            var departments = _context.Departments.Where(criteria);
            return departments; 
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _context.Departments.Include(d => d.Head)
                                                  .ThenInclude(p => p.ProfessorNavigation);
                                                 
            return departments;
        }

        public Department GetById(int id)
        {
            var department = _context.Departments.Where(d => d.DepartmentId == id).FirstOrDefault();
            if (department != null)
            {
                return department;
            }
            throw new Exception("There is no department with this ID !");
        }

        public Department Insert(Department entity)
        {
            if (entity != null)
            {
                _context.Add(entity);
                return entity;
            }
            throw new ArgumentNullException("Can't add a department of null value");
        }

        public Department Update(Department entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
