using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.StudentService
{
    public class StudentService : IStudentService
    {   
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        //Implment The interface
        //public IEnumerable<Student> GetStudents()
        //{
        //    _unitOfWork.Students.ToList();
        //}
    }
}
