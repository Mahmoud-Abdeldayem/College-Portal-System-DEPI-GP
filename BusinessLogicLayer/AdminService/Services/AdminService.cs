using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using BusinessLogicLayer.DTOs.AdminDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AdminService.Services
{
    public class AdminService(/*ApplicationDbContext context,*/ IUnitOfWork unitOfWork/*, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager*/) //: IAdminService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        //private readonly UserManager<ApplicationUser> _userManager = userManager;
        //private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private static int lastUsedAcademicYear = GetAcademicYear(); // Track the academic year in memory
        private static int sequence = 0;

        public string GetCourseByName(string courseName)
        {
            var course = _unitOfWork.Courses.Get(c => c.Name == courseName).FirstOrDefault();
            return course?.Name;
        }
        public string GetCourseByCode(string courseCode)
        {
            var course = _unitOfWork.Courses.Get(c => c.Code == courseCode).FirstOrDefault();
            return course?.Code;
        }

        public IEnumerable<AddCourseDTO> GetCourses()
        {
            return _unitOfWork.Courses.GetAll().Select(
                    c => new AddCourseDTO
                    {
                        CourseId = c.CourseId,
                        Name = c.Name,
                        Hours = c.Hours,
                        Code = c.Code,
                        PrerequisiteCourseId = c.PrerequisiteCourseId,
                        Semseter = c.Semseter,
                        CourseLevel = c.CourseLevel,
                        DepartmentId = c.DepartmentId,
                    }
                );
        }
        public List<DepartmentDTO> GetDepartments()
        {
            var departments = _unitOfWork.Departments.GetAll().Select(d => new DepartmentDTO()
            {
                DepartmentId = d.DepartmentId,
                Code = d.Code,
                Name = d.Name,
                HeadId = d.HeadId,
                HeadName = d.Head != null && d.Head.ProfessorNavigation != null
                ? d.Head.ProfessorNavigation.FirstName + " " + d.Head.ProfessorNavigation.LastName
                : "No Head Assigned" // if the props returned null
            })
            .ToList();
            return departments;
        }

        public List<Department> GetDepts()
        {
            var depts = _unitOfWork.Departments.GetAll().ToList();
            return depts;
        }

        public Course AddCourse(AddCourseDTO newCourse)
        {
            var course = new Course()
            {
                Name = newCourse.Name,  
                Code = newCourse.Code,
                Hours = newCourse.Hours,
                PrerequisiteCourseId = newCourse.PrerequisiteCourseId,
                Semseter = newCourse.Semseter,
                CourseLevel = newCourse.CourseLevel,
                DepartmentId = newCourse.DepartmentId,
            };
            _unitOfWork.Courses.Insert(course);
            _unitOfWork.Commit();
            return course;
        }

        public List<AddCourseDTO> GetAllCourses()
        {
            var courses = _unitOfWork.Courses.GetAll().Select(c => new AddCourseDTO()
            {
                CourseId = c.CourseId,
                Name = c.Name,
                Code = c.Code,
                Hours = c.Hours,
                PrerequisiteCourseId = c.PrerequisiteCourseId,
                Semseter = c.Semseter,
                CourseLevel = c.CourseLevel,
                DepartmentId = c.DepartmentId,
            }).ToList();
            return courses;
        }
        public List<AddCourseDTO> GetCoursesByDepartment(int deptId)
        {
            var courses = _unitOfWork.Courses.Get(c => c.DepartmentId == deptId).Select(c => new AddCourseDTO()
            {
                CourseId = c.CourseId,
                Name = c.Name,
                Code = c.Code,
                Hours = c.Hours,
                PrerequisiteCourseId = c.PrerequisiteCourseId,
                Semseter = c.Semseter,
                CourseLevel = c.CourseLevel,
                DepartmentId = c.DepartmentId,
            }).ToList();
            return courses;
        }

        public void AddDepartment(DepartmentDTO department)
        {
            var newDepartment = new Department()
            {
                Name = department.Name,
                Code = department.Code,
                HeadId = department.HeadId,
            };
            _unitOfWork.Departments.Insert(newDepartment);
            _unitOfWork.Commit();
        }

        public void DeleteDepartment(int departmentId)
        {
            try
            {
                _unitOfWork.Departments.DeleteById(departmentId);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        //------------------------------------<Professors>-----------------------------------------
        public IEnumerable<Professor> GetAllProfessors()
        {
            var professors = _unitOfWork.Professors.GetAll();
            return professors;
        }

        //public string AddStudents()
        //{
        //    var user = new ApplicationUser
        //    {
        //        Email = userForm.Email,
        //        UserName = userForm.Email,
        //        EmailConfirmed = true,
        //        NationalId = userForm.NationalId,
        //        FirstName = userForm.FirstName,
        //        LastName = userForm.LastName,
        //        PhoneNumber = userForm.PhoneNumber,
        //        Address = userForm.Address,
        //        Gender = userForm.Gender,
        //        Picture = userForm?.Picture,
        //    };

        //    var createUserResult = await _userManager.CreateAsync(user, userForm.Password);

        //    if (!createUserResult.Succeeded)
        //        return (IsSuccess: false, AppUser: null, Error: string.Join(',', createUserResult.Errors.Select(e => e.Description)));

        //    var addToRoleResult = await _userManager.AddToRoleAsync(user, userForm.SelectedRole);

        //    if (!addToRoleResult.Succeeded)
        //        return (IsSuccess: false, AppUser: null, Error: string.Join(',', addToRoleResult.Errors.Select(e => e.Description)));

        //    return (IsSuccess: true, AppUser: user, Error: null);
        //}
        //public async Task<Student> CreateStudentAsync(StudentFormViewModel model)
        //{
        //    int currentAcademicYear = GetAcademicYear();

        //    if (currentAcademicYear != lastUsedAcademicYear)
        //    {                
        //        sequence = 0;
        //        lastUsedAcademicYear = currentAcademicYear;
        //    }            

        //    ++sequence;

        //    string GeneratedstudentId = $"{currentAcademicYear}{sequence.ToString("D4")}";

        //    var student = new Student
        //    {
        //        //Add Student Data to Student Table
        //    };

        //    student.StudentId = GeneratedstudentId;
        //    await _context.Student.Update(student);
        //    _context.SaveChanges();


        //    return student;

        //}
        private static int GetAcademicYear()
        {
            var currentDate = DateTime.Now;

            if (currentDate.Month >= 9)
            {
                return currentDate.Year;
            }
            else { return currentDate.Year - 1; }
        }
    }
}
