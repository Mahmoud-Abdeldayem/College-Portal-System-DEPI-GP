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
        IBaseRepository<Professor> Professors { get; }
        ITARepository TAs { get; }
        IStudentRepo StudentRepo { get; }
        IBaseRepository<ApplicationUser> ApplicationUserRepo { get; }
        IBaseRepository<CourseEnrollment> CourseEnrollmentRepo { get; }
        IBaseRepository<Department> DepartmentRepo { get; }
        IBaseRepository<Course> CourseRepo { get; }
        void Commit();
    }
}
