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
        public ITARepository TAs { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Students = new BaseRepository<Student>(_context);
            TAs = new TARepository(_context);
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
