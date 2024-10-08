using DataAccessLayer.Interfaces;
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
        //Ex : private readonly AppDbContext _context
        //Inject it into the constructor
        //You also need to inject this context to the Entities Repositories

        // Suppose you have this repo (Implemented from the IUnitOfWork) : 
        // public IBaseRepository<Student> Students {get; private set;}

        // Ex : 
        //public UnitOfWork(AppDbContext context , IBaseRepository<Student> repository) 
        //{
        //    _context = context
        //    Students = new BaseRepository<Student>(_context) || or any Implementer
        //}
        public void Commit()
        {
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}
