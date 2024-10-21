using DataAccessLayer.UnitOfWork;
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
        public string AddStudents()
        {
            //_unitOfWork
            return "";
        }
    }
}
