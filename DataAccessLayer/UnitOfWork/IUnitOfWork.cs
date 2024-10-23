using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //Add your Repo here
        //It will cause a compiler error because there is no entity calles (Student)
        IBaseRepository<Student>Students { get; }
        IBaseRepository<DataAccessLayer.Entities.Task> Tasks { get;}
        IBaseRepository<Course> Courses { get; }
        IBaseRepository<Department> Departments { get; }
        ProfessorsRepoitory Professors { get;}

        ITARepository TAs { get; }
        void Commit();
    }
}
