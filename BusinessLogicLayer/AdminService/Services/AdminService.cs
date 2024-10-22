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
    public class AdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetCourseByName(string courseName)
        {
            var course = _unitOfWork.Courses.Get(c => c.Name == courseName).FirstOrDefault();
            return course?.Name;
        }
        public string GetCourseByCode(string courseCode)
        {
            var course = _unitOfWork.Courses.Get(c => c.Code == courseCode).FirstOrDefault();
            return course?.Name;
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
        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            return _unitOfWork.Departments.GetAll().Select(
                    d => new DepartmentDTO()
                    {
                        DepartmentId = d.DepartmentId,
                        Code = d.Code,
                        Name = d.Name,
                        HeadId = d.HeadId,
                    }
                );
            
        }
        public string AddStudents()
        {
            //_unitOfWork
            return "";
        }
    }
}
