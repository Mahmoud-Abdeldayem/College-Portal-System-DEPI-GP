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
        public IBaseRepository<DataAccessLayer.Entities.Task> Tasks { get; private set; }
        public IBaseRepository<Course> Courses { get; private set; }
        public IBaseRepository<Department> Departments { get; private set; }
        public ProfessorsRepoitory Professors { get; private set; }

        public ITARepository TAs { get; private set; }
        public IStudentRepo StudentRepo { get; private set; }
        public IBaseRepository<ApplicationUser> ApplicationUserRepo { get; private set; }
        public IBaseRepository<CourseEnrollment> CourseEnrollmentRepo { get; private set; }
        public IBaseRepository<Department> DepartmentRepo { get; private set; }
        public IBaseRepository<Course> CourseRepo { get; private set; }
        public IBaseRepository<Submission> TaskSubmissions { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Students = new BaseRepository<Student>(_context);
            Tasks = new BaseRepository<DataAccessLayer.Entities.Task>(_context); 
            Courses = new BaseRepository<Course>(_context);
            TAs = new TARepository(_context);
            Departments = new BaseRepository<Department>(_context);
            Professors = new ProfessorsRepoitory(_context);
            ApplicationUserRepo = new BaseRepository<ApplicationUser>(_context);    
            CourseEnrollmentRepo = new BaseRepository<CourseEnrollment>(_context);
            StudentRepo = new StudentRepo(_context);
            DepartmentRepo = new BaseRepository<Department>(_context);  
            CourseRepo = new BaseRepository<Course>(_context);
            TaskSubmissions = new BaseRepository<Submission>(_context); 
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
