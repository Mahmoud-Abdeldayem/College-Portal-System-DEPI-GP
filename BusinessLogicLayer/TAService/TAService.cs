using BusinessLogicLayer.DTOs.TADTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.TAService
{
    public class TAService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TAService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<TACoursesDTO> GetTACourses(string teachingAssistantId)
        { 
            var courses = _unitOfWork.TAs.GetCourseTeachings(teachingAssistantId)
                          .Select(ct => new TACoursesDTO{CourseID = ct.CourseId ,CourseName = ct.Course.Name,ProfessorName =
                          (ct.Professor.ProfessorNavigation.FirstName + " " + ct.Professor.ProfessorNavigation.LastName)
                          });
            return courses.ToList();
        }
    }
}
