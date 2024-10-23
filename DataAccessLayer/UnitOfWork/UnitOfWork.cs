using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Create context reference here 
        private readonly AppDbContext _context;
        public IBaseRepository<Student> Students { get; private set; }
        public IBaseRepository<DataAccessLayer.Entities.Task> Tasks { get; private set; }
        public IBaseRepository<Course> Courses { get; private set; }
        public IBaseRepository<Department> Departments { get; private set; }
        public ProfessorsRepoitory Professors { get; private set; }

        public ITARepository TAs { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Students = new BaseRepository<Student>(_context);
            Tasks = new BaseRepository<DataAccessLayer.Entities.Task>(_context);    
            TAs = new TARepository(_context);
            Courses = new BaseRepository<Course>(_context);
            Departments = new DepartmentRepository(_context);
            Professors = new ProfessorsRepoitory(_context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
