using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //Add your Repo here
        //It will cause a compiler error because there is no entity calles (Student)
        IBaseRepository<Student>Students { get; }
        ITARepository TAs { get; }
        void Commit();
    }
}
