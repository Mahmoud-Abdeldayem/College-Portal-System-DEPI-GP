using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //Create context reference here 
        private readonly AppDbContext _context;
        public IBaseRepository<Student> Students { get; private set; }
        public IBaseRepository<Professor> Professors { get; private set; }
        public ITARepository TAs { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Students = new BaseRepository<Student>(_context);
            TAs = new TARepository(_context);
            Professors = new BaseRepository<Professor>(_context);            
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
